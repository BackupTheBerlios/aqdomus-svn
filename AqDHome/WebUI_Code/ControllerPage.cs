/*
 * ControllerPage.cs
 *
 * Copyright (c) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */

using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace AqDHome.WebUI {

  /// <summary> </summary>
  public abstract class ControllerPage: BasePage {


    private const string COOKIE_USER = "Controller.User";
    private const string COOKIE_PASSWORD = "Controller.Password";
    private bool isLogon = false;
    private string oldClientUser = null;
    private string oldClientPasswordHash = null;
    private string newClientUser = null;
    private string newClientPasswordHash = null;

    private string sectionKey = null;
    private string sectionQuery = null;
    private string section = null;

    private string emPageDir = null;
    private string emPageExt = null;
    private string javascriptDir = null;
    private string javascriptExt = null;
    private string stylesheetDir = null;
    private string stylesheetExt = null;


    /// <summary>
    /// The user name that client sends in cookies
    /// </summary>
    public string ClientUser {
      get {
        HttpCookie c = null;

        if (this.newClientUser != null) {
          return this.newClientUser;
        }

        if ((c = this.Page.Request.Cookies[COOKIE_USER]) != null) {
          return c.Value;
        }

        return string.Empty;
      }
    }


    /// <summary>
    /// The hash code of the user password that client sends in cookies
    /// </summary>
    public string ClientPasswordHash {
      get {
        HttpCookie c = null;

        if (this.newClientPasswordHash != null) {
          return this.newClientPasswordHash;
        }

        if ((c = this.Page.Request.Cookies[COOKIE_PASSWORD]) != null) {
          return c.Value;
        }

        return string.Empty;
      }
    }


    /// <summary>
    /// Indicate whether both of the <see cref="ControllerPage.ClientUser"/>
    /// and the <see cref="ControllerPage.ClientPasswordHash"/> are correct.
    /// </summary>
    public bool IsLogon {
      get {
        string cUser = this.ClientUser;
        string cHash = this.ClientPasswordHash;

        if ((this.oldClientUser != cUser)
            || (this.oldClientPasswordHash != cHash)) {
          string sUser
            = ConfigurationSettings.AppSettings["Controller.AdminName"];
          string sPassword
            = ConfigurationSettings.AppSettings["Controller.AdminPassword"];

          // MD5 md5 = MD5.Create();
          // UTF8Encoding utf8e = new UTF8Encoding();
          //string sHash
          //  = Convert.ToBase64String(md5.ComputeHash(utf8e.GetBytes(sPassword)));
          string sHash = sPassword;
          if ((cUser == sUser) && (cHash == sHash)) {
            this.isLogon = true;
          } else {
            this.isLogon = false;
          }

          this.oldClientUser = cUser;
          this.oldClientPasswordHash = cHash;
        }

        return this.isLogon;
      }
    }


    /// <summary>
    /// The section that client requests, specified in QueryString.
    /// </summary>
    public string Section {
      get {
        if (this.section == null) {
          this.section = this.Request.QueryString[this.sectionKey];
          if ((this.section == null)
              || (this.ValidateSection(this.section) == false)) {
            this.section
              = ConfigurationSettings.AppSettings["Controller.DefaultSection"];
          }
        }

        return this.section;
      }
    }


    /// <summary>
    /// Add a new &lt;link&gt; in &lt;head&lt; to reference the javascript of
    /// the given <paramref name="path"/>.
    /// </summary>
    public abstract void AddJavascriptLink(string path);


    /// <summary>
    /// Delete a &lt;link&gt; that references the javascript of the given
    /// <paramref name="path"/> in &lt;head&lt;.
    /// </summary>
    /// <remarks>
    /// The method can't delete links that are not added by <see
    /// cref="ControllerPage.AddJavascriptLink"/>.
    /// </remarks>
    public abstract void RemoveJavascriptLink(string path);


    /// <summary>
    /// Add a new &lt;link&gt; in &lt;head&lt; to reference the stylesheet of
    /// the given <paramref name="path"/>.
    /// </summary>
    public abstract void AddStylesheetLink(string path);


    /// <summary>
    /// Delete a &lt;link&gt; that references the stylesheet of the given
    /// <paramref name="path"/> in &lt;head&lt;.
    /// </summary>
    /// <remarks>
    /// The method can't delete links that are not added by <see
    /// cref="ControllerPage.AddStylesheetLink"/>.
    /// </remarks>
    public abstract void RemoveStylesheetLink(string path);


    /// <summary> </summary>
    public string GetSectionLink(string sectionName) {
      return this.sectionQuery + sectionName;
    }


    /// <summary>
    /// Get full page path by page name.
    /// <seealso cref="ControllerPage.Section"/>
    /// </summary>
    public string GetEmPagePath(string pageName) {
      return this.emPageDir + pageName + this.emPageExt;
    }


    /// <summary>
    /// Get full javascript path by javascript name.
    /// </summary>
    public string GetJavascriptPath(string javascriptName) {
      return this.javascriptDir + javascriptName + this.javascriptExt;
    }


    /// <summary>
    /// Get full stylesheet path by stylesheet name.
    /// </summary>
    public string GetStylesheetPath(string stylesheetName) {
      return this.stylesheetDir + stylesheetName + this.stylesheetExt;
    }


    /// <summary>
    /// Set client user name and the password, which will be sent back as
    /// cookies.
    /// <seealso cref="ControllerPage.IsLogon"/>
    /// </summary>
    /// <remarks>
    /// <see cref="ControllerPage.ClientUser"/>, <see
    /// cref="ControllerPage.ClientPasswordHash"/>, and <see
    /// cref="ControllerPage.IsLogon"/> are updated immediatedly after you call
    /// this method.
    /// </remarks>
    public void SetUserPassword(string userName, string password) {
      //MD5 md5 = MD5.Create();
      //UTF8Encoding utf8e = new UTF8Encoding();
      //string passwordHash
      //  = Convert.ToBase64String(md5.ComputeHash(utf8e.GetBytes(password)));
      string passwordHash = password;

      this.newClientUser = this.Response.Cookies[COOKIE_USER].Value = userName;
      this.newClientPasswordHash
        = this.Response.Cookies[COOKIE_PASSWORD].Value = passwordHash;
    }


    /// <summary> </summary>
    protected override void Construct() {
      this.sectionKey = this.Conf["Controller.SectionKey"];
      this.sectionQuery = "?" + this.sectionKey + "=";

      this.emPageDir = this.Conf["Controller.EmPageDir"];
      this.emPageExt = this.Conf["Controller.EmPageExt"];
      this.javascriptDir = this.Conf["Controller.JavascriptDir"];
      this.javascriptExt = this.Conf["Controller.JavascriptExt"];
      this.stylesheetDir = this.Conf["Controller.StylesheetDir"];
      this.stylesheetExt = this.Conf["Controller.StylesheetExt"];

      base.Construct();
    }


    /// <summary> </summary>
    protected bool ValidateSection(string sect) {
      if (sect.IndexOf("\\") != -1) return false;
      if (sect.IndexOf("/") != -1) return false;

      return true;
    }


  }

}

/*
 * LoginBar.ascx.cs
 *
 * Copyright (c) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace AqDHome.WebUI {

  public class LoginBar: BaseControl {


    protected LinkButton LoginButton = null;
    protected LinkButton LogoutButton = null;
    protected TextBox UserTextBox = null;
    protected TextBox PasswordTextBox = null;
    protected Label ErrorLabel = null;


    protected virtual string LogonCssPostfix {
      get {
        if (this.Controller.IsLogon) {
          return "-Logon";
        } else {
          return string.Empty;
        }
      }
    }


    protected override void OnLoad(EventArgs e) {
      this.Controller.AddStylesheetLink("LoginBar.css.aspx");

      base.OnLoad(e);
    }


    protected override void OnPreRender(EventArgs e) {
      this.UserTextBox.Text = this.Controller.ClientUser;

      if (this.Controller.IsLogon) {
        this.LoginButton.Visible = false;
        this.LogoutButton.Visible = true;
        this.UserTextBox.Enabled = false;
        this.UserTextBox.CssClass += this.LogonCssPostfix;
        this.PasswordTextBox.Enabled = false;
        this.PasswordTextBox.CssClass += this.LogonCssPostfix;
      } else {
        this.LoginButton.Visible = true;
        this.LogoutButton.Visible = false;
        this.UserTextBox.Enabled = true;
        this.PasswordTextBox.Enabled = true;
      }

      base.OnPreRender(e);
    }


    protected virtual void LoginButton_Click(object sender, EventArgs e) {
      this.Controller.SetUserPassword(this.UserTextBox.Text,
                                 this.PasswordTextBox.Text);
      if (! this.Controller.IsLogon) {
        this.ErrorLabel.Visible = true;
      }
    }


    protected virtual void LogoutButton_Click(object sender, EventArgs e) {
      this.Controller.SetUserPassword("", "");
    }


  }

}

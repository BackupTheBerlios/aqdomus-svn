/*
 * BasePage.cs
 *
 * Copyright (c) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */

using System;
using System.Configuration;
using System.Web;
using System.Web.UI;


namespace AqDHome.WebUI {

  /// <summary> </summary>
  public abstract class BasePage: Page {


    private class ConfigIndexer: ISimpleIndexer {

      private BasePage basePage = null;

      public ConfigIndexer(BasePage basePage) {
        this.basePage = basePage;
      }

      public string this[string configName] {
        get {
          return this.basePage.GetConfigSetting(configName);
        }
      }
    }


    private class ImageIndexer: ISimpleIndexer {

      private BasePage basePage = null;

      public ImageIndexer(BasePage basePage) {
        this.basePage = basePage;
      }

      public string this[string imageName] {
        get {
          return this.basePage.GetImagePath(imageName);
        }
      }
    }


    private string imageDir = null;
    private string imageExt = null;
    private ConfigIndexer configIndexer = null;
    private ImageIndexer imageIndexer = null;

    private bool isIE = false;
    private bool isMoz = false;
    private string lang = null;


    /// <summary>
    /// Language
    /// </summary>
    public string Lang {
      get {
        return this.lang;
      }
    }


    /// <summary>
    /// Indicate whether the client browser is Internet Explorer
    /// </summary>
    public bool IsIE {
      get {
        return this.isIE;
      }
    }


    /// <summary>
    /// Indicate whether the client browser is Mozilla
    /// </summary>
    public bool IsMoz {
      get {
        return this.isMoz;
      }
    }


    /// <summary>
    /// Shortcut to <see cref="GetConfigSetting"/>.
    /// </summary>
    /// <remarks>
    /// All pages should use this method to retrieve config settings.
    /// </remarks>
    public ISimpleIndexer Conf {
      get {
        if (this.configIndexer == null) {
          this.configIndexer = new ConfigIndexer(this);
        }
        return this.configIndexer;
      }
    }


    /// <summary>
    /// Shortcut to <see cref="GetImagePath"/>.
    /// </summary>
    /// <example>
    /// <code> Img["HomePage-Header"] </code>
    /// returns "MyImages/HomePage-Header.png".
    /// </example>
    /// <remarks>
    /// All pages should use this method to locate images.
    /// </remarks>
    public ISimpleIndexer Img {
      get {
        if (this.imageIndexer == null) {
          this.imageIndexer = new ImageIndexer(this);
        }
        return this.imageIndexer;
      }
    }


    /// <summary>
    /// Return the path of blank image 'spacer'.
    /// </summary>
    public string ImgSpacer {
      get {
        return this.Img["spacer"];
      }
    }


    /// <summary>
    /// Get configuration setting.
    /// </summary>
    protected internal virtual string GetConfigSetting(string settingName) {
      return ConfigurationSettings.AppSettings[settingName];
    }


    /// <summary>
    /// Get full image path by image name.
    /// </summary>
    protected internal virtual string GetImagePath(string imageName) {
      if (this.imageDir == null) {
        this.imageDir = this.Conf["Controller.ImageDir"];
      }
      if (this.imageExt == null) {
        this.imageExt = this.Conf["Controller.ImageExt"];
      }
      return this.imageDir + imageName + this.imageExt;
    }


    /// <summary> </summary>
    protected override void Construct() {

      base.Construct();
    }


    /// <summary> </summary>
    protected override void OnLoad(EventArgs e) {
      string uagent = this.Request.UserAgent;
      if (uagent.IndexOf("Mozilla/4.0 (compatible; MSIE ") == 0) {
        this.isIE = true;
      } else if (uagent.IndexOf("Mozilla/5.0 ") == 0) {
        this.isMoz = true;
      }

      string qlang = this.Request.QueryString["lang"];
      if (qlang != null) {
        this.lang = qlang.ToLower();
      } else {
        this.lang = "en-us";
      }

      base.OnLoad(e);
    }


    /// <summary> </summary>
    protected override void Render(HtmlTextWriter writer) {
      this.DataBind();

      base.Render(writer);
    }


  }

}

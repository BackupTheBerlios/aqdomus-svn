/*
 * Global.asax.cs
 *
 * Copyright (c) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */

using System;
using System.IO;
using System.Web;


namespace AqDHome.WebUI {

  public class GlobalApplication: HttpApplication {


    public override void Init() {
      this.BeginRequest += new EventHandler(this.Application_BeginRequest);
    }


    private void Application_BeginRequest(object sender, EventArgs e) {
      this.ValidateRequestPath();
      this.RewriteUrl();
    }


    private void RewriteUrl() {
      string urlPath = this.Request.Path;
      string appPath = this.Request.ApplicationPath;
      if (urlPath == appPath + "/") {
        this.Context.RewritePath(appPath + "/Default.aspx"
                                 + this.Request.Url.Query);
      } else if (urlPath == appPath) {
        this.Response.Redirect(appPath + "/" + this.Request.Url.Query);
      }
    }


    // http://support.microsoft.com/Default.aspx?kbid=887459
    private void ValidateRequestPath() {
      if ((this.Request.Path.IndexOf('\\') >= 0) ||
          (Path.GetFullPath(this.Request.PhysicalPath)
           != this.Request.PhysicalPath)) {
        throw new HttpException(404, "not found");
      }
    }


  }

}

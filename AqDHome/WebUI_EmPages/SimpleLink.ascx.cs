/*
 * SimpleLink.ascx.cs
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

  public class SimpleLink: BaseControl {


    private string linkUrl = null;


    public string LinkUrl {
      get {
        return this.linkUrl;
      }

      set {
        this.linkUrl = value;
      }
    }


    protected override void OnLoad(EventArgs e) {
      this.Controller.AddStylesheetLink(this.Controller.GetStylesheetPath("SimpleLink"));

      base.OnLoad(e);
    }


  }

}

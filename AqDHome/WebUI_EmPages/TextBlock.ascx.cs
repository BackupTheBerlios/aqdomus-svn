/*
 * TextBlock.ascx.cs
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

  public class TextBlock: BaseControl {


    private string header = null;


    public string Header {
      get {
        return this.header;
      }

      set {
        this.header = value;
      }
    }


    protected override void OnLoad(EventArgs e) {
      this.Controller.AddStylesheetLink(this.Controller.GetStylesheetPath("TextBlock"));

      base.OnLoad(e);
    }


  }

}

/*
 * MenuBase.ascx.cs
 *
 * Copyright (c) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */

using System;
using System.Web;


namespace AqDHome.WebUI {

  public class MenuBase: BaseControl {


    protected override void OnLoad(EventArgs e) {
      this.Controller.AddStylesheetLink("MenuBase.css.aspx");

      base.OnLoad(e);
    }


  }

}

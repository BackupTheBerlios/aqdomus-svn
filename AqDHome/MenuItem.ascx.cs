/*
 * MenuItem.ascx.cs
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

  public class MenuItem: BaseControl {


    private string itemID = string.Empty;
    private string itemName = string.Empty;
    private string itemIconPath = string.Empty;
    private string itemLink = string.Empty;


    public bool Selected {
      get {
        if (this.Controller.Section == this.ItemID) {
          return true;
        } else {
          return false;
        }
      }
    }


    public string BorderClassNormal {
      get {
        if (this.Selected) {
          return "MenuItemBorder-Selected";
        } else {
          return "MenuItemBorder";
        }
      }
    }


    public string BorderClassHover {
      get {
        if (this.Selected) {
          return "MenuItemBorder-Selected";
        } else {
          return "MenuItemBorder-Hover";
        }
      }
    }


    public string ClassNormal {
      get {
        if (this.Selected) {
          return "MenuItem-Selected";
        } else {
          return "MenuItem";
        }
      }
    }


    public string ClassHover {
      get {
        if (this.Selected) {
          return "MenuItem-Selected";
        } else {
          return "MenuItem-Hover";
        }
      }
    }


    public string ItemID {
      get {
        if (this.itemID == null) {
          this.itemID = string.Empty;
        }
        return this.itemID;
      }

      set {
        this.itemID = value;
      }
    }


    public string ItemName {
      get {
        if (this.itemName == null) {
          this.itemName = string.Empty;
        }
        return this.itemName;
      }

      set {
        this.itemName = value;
      }
    }


    public string ItemIconPath {
      get {
        return this.Img["MenuItem-" + this.ItemID];
      }
    }


    public string ItemLink {
      get {
        return this.Controller.GetSectionLink(this.ItemID);
      }
    }


    public string GoToItemLink {
      get {
        if (this.Selected) {
          return "";
        } else {
          return "window.location = \"" + this.ItemLink + "\";";
        }
      }
    }


    protected override void OnLoad(EventArgs e) {
      this.Controller.AddStylesheetLink("MenuItem.css.aspx");

      base.OnLoad(e);
    }


  }

}

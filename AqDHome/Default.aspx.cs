/*
 * Default.aspx.cs
 *
 * Copyright (c) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */

using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AqDHome.WebUI {

  public class DefaultPage: ControllerPage {


    private ArrayList stylesheetLinks = null;
    private ArrayList javascriptLinks = null;

    protected PlaceHolder JavascriptLinkHolder = null;
    protected PlaceHolder StylesheetLinkHolder = null;
    protected PlaceHolder EmPageHolder = null;


    public override void AddJavascriptLink(string jsPath) {
      if (this.javascriptLinks.Contains(jsPath) == false) {
        this.javascriptLinks.Add(jsPath);
      }
    }


    public override void RemoveJavascriptLink(string jsPath) {
      this.javascriptLinks.Remove(jsPath);
    }


    public override void AddStylesheetLink(string cssPath) {
      if (this.stylesheetLinks.Contains(cssPath) == false) {
        this.stylesheetLinks.Add(cssPath);
      }
    }


    public override void RemoveStylesheetLink(string cssPath) {
      this.stylesheetLinks.Remove(cssPath);
    }


    protected override void Construct() {
      this.javascriptLinks = new ArrayList();
      this.stylesheetLinks = new ArrayList();

      base.Construct();
    }


    protected override void OnLoad(EventArgs e) {
      Control c = this.LoadControl(this.GetEmPagePath(this.Section));
      this.EmPageHolder.Controls.Add(c);
      this.AddStylesheetLink(this.GetStylesheetPath(this.Section));

      base.OnLoad(e);
    }


    protected override void Render(HtmlTextWriter writer) {
      StringBuilder jslinksBuilder = new StringBuilder("\n");
      foreach (object obj in this.javascriptLinks) {
        string jsPath = (string) obj;
        jslinksBuilder.Append("<script type='text/javascript' src='");
        jslinksBuilder.Append(jsPath);
        jslinksBuilder.Append("'></script>\n");
      }

      this.JavascriptLinkHolder.Controls.Clear();
      Literal lcj = new Literal();
      lcj.Text = jslinksBuilder.ToString();
      this.JavascriptLinkHolder.Controls.Add(lcj);

      StringBuilder sslinksBuilder = new StringBuilder("\n");
      foreach (object obj in this.stylesheetLinks) {
        string cssPath = (string) obj;
        sslinksBuilder.Append("<link rel='stylesheet' type='text/css' href='");
        sslinksBuilder.Append(cssPath);
        sslinksBuilder.Append("'/>\n");
      }

      this.StylesheetLinkHolder.Controls.Clear();
      Literal lcs = new Literal();
      lcs.Text = sslinksBuilder.ToString();
      this.StylesheetLinkHolder.Controls.Add(lcs);

      base.Render(writer);
    }
  }

}

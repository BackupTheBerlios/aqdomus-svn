/*
 * BaseControl.cs
 *
 * Copyright (c) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AqDHome.WebUI {

  /// <summary>
  /// BaseControl provides a easy way to create UserControl that can contain
  /// nested controls which are appended to Controls by default. See
  /// MenuBase.ascx and its use in /Default.aspx for example.
  ///
  /// <list>
  /// <item> ChildrenHolder is the place where nested controls will be moved to when
  /// rendering. </item>
  /// <item> EndMarker must be put in the end of UserControl code. </item>
  /// </list>
  /// </summary>
  ///
  /// <remarks>
  /// <list>
  /// <item> You may append new nested controls and call Render() more than
  /// one time. </item>
  /// <item> BaseControl can only be used in ControllerControl. </item>
  /// </list>
  /// </remarks>
  [ParseChildren(false)]
  public abstract class BaseControl: UserControl {


    /// <summary> </summary>
    protected PlaceHolder ChildrenHolder = null;


    /// <summary> </summary>
    protected PlaceHolder EndMarker = null;


    /// <summary>
    /// Return the ControllerPage that contains this UserControl.
    /// </summary>
    protected virtual ControllerPage Controller {
      get {
        return (ControllerPage) this.Page;
      }
    }


    /// <summary>
    /// Get full image path by image name.
    /// </summary>
    public ISimpleIndexer Img {
      get {
        return this.Controller.Img;
      }
    }


    /// <summary>
    /// Return the path of the blank image 'spacer'.
    /// </summary>
    public string ImgSpacer {
      get {
        return this.Controller.ImgSpacer;
      }
    }


    /// <summary> </summary>
    protected override void RenderChildren(HtmlTextWriter writer) {
      if ((this.ChildrenHolder !=null)
          && (this.EndMarker != null)) {
        int cIndex = this.ChildrenHolder.Controls.Count;
        int eIndex = this.Controls.IndexOf(this.EndMarker);
        int maxIndex = this.Controls.Count - 1;

        for (int i = maxIndex; i > eIndex; i --) {
          Control c = this.Controls[i];
          this.Controls.RemoveAt(i);
          this.ChildrenHolder.Controls.AddAt(cIndex, c);
        }
      }

      base.RenderChildren(writer);
    }


  }
}

/*
 * ISimpleIndexer.cs
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
  public interface ISimpleIndexer {


    /// <summary> </summary>
    string this[string arg] {
      get;
    }


  }

}

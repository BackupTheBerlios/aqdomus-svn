/*
 * StorageInternalException.cs
 *
 * Copyright (c) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */


using System;


namespace AqDHome.Storage {

  /// <summary>
  /// StorageInternalException is thrown when unresolvable internal errors
  /// occurred during IStorageProvider operates. The catcher should report this
  /// kind of error to users and/or log.
  /// </summary>
  public class StorageInternalException: Exception {


    /// <summary> </summary>
    public StorageInternalException(): base("StorageInternalException") {
    }


    /// <summary> </summary>
    public StorageInternalException(string message): base(message) {
    }


    /// <summary> </summary>
    public StorageInternalException(string message, Exception innerException): base(message, innerException) {
    }


  }

}

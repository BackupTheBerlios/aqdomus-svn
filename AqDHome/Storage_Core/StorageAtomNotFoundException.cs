/*
 * StorageAtomNotFoundException.cs
 *
 * Copyright (c) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */


using System;


namespace AqDHome.Storage {

  /// <summary>
  /// StorageAtomNotFoundException is thrown when unresolvable internal errors
  /// occurred during IStorageProvider operates. The catcher should report this
  /// kind of error to users and/or log.
  /// </summary>
  public class StorageAtomNotFoundException: Exception {


    /// <summary> </summary>
    public StorageAtomNotFoundException(): base("StorageAtomNotFoundException") {
    }


    /// <summary> </summary>
    public StorageAtomNotFoundException(string message): base(message) {
    }


    /// <summary> </summary>
    public StorageAtomNotFoundException(string message, Exception innerException): base(message, innerException) {
    }


  }

}

/*
 * AssemblyProviderBase.cs
 *
 * Copyright (C) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */


using System;
using System.Collections.Generic;
using System.IO;

using AqDHome.ServiceHost;


namespace AqDHome.ServiceHost.AssemblyProviders
{

  /// <summary>
  ///   Simple Implementation of IAssemblyProvider
  /// </summary>
  public abstract class AssemblyProviderBase: MarshalByRefObject,
                                              IAssemblyProvider
  {


    private bool isLocked = false;


    /// <summary>
    ///   <seealso cref="IAssemblyProvider.BaseDirectory"/>
    /// </summary>
    public abstract string BaseDirectory { get; }


    /// <summary>
    ///   <seealso cref="IAssemblyProvider.IsLocked"/>
    /// </summary>
    public bool IsLocked
    {
      get
      {
        return this.isLocked;
      }
    }


    /// <summary>
    ///   <seealso cref="IAssemblyProvider.RemoteLoaderName"/>
    /// </summary>
    public abstract string RemoteLoaderName { get; }


    /// <summary>
    ///   <seealso cref="IAssemblyProvider.RemoteLoaderLocation"/>
    /// </summary>
    public abstract string RemoteLoaderLocation { get; }


    /// <summary>
    ///   <seealso cref="IAssemblyProvider.Lock"/>
    /// </summary>
    /// <remarks>
    ///   <see cref="IAssemblyProvider.IsLocked"/> will not be set if
    ///   <see cref="AssemblyProviderBase.OnLock"/> throws an exception.
    /// </remarks>
    public void Lock()
    {
      this.OnLock();
      this.isLocked = true;
    }


    /// <summary>
    ///   <seealso cref="IAssemblyProvider.Unlock"/>
    /// </summary>
    /// <remarks>
    ///   <see cref="IAssemblyProvider.IsLocked"/> will not be cleared if
    ///   <see cref="AssemblyProviderBase.OnUnlock"/> throws an exception.
    /// </remarks>
    public void Unlock()
    {
      this.OnUnlock();
      this.isLocked = false;
    }


    /// <summary>
    ///   <seealso cref="IAssemblyProvider.GetLibraryAssemblyNames"/>
    /// </summary>
    public abstract string[] GetLibraryAssemblyNames();


    /// <summary>
    ///   <seealso cref="IAssemblyProvider.GetServiceAssemblyNames"/>
    /// </summary>
    public abstract string[] GetServiceAssemblyNames();


    /// <summary>
    ///   <seealso cref="IAssemblyProvider.GetUpdatedServiceAssemblyNames"/>
    /// </summary>
    public string[] GetUpdatedServiceAssemblyNames(DateTime timestamp)
    {
      // Create a new AppDomain to gather assemblies' info
      AppDomain asmTrackDomain = AppDomain.CreateDomain(
        "asmTrackDomain",
        null,
        Path.GetFullPath(this.BaseDirectory),
        "./",
        false);

      IRemoteLoader remoteLoader =
        (IRemoteLoader) asmTrackDomain.CreateInstanceFromAndUnwrap(
          this.RemoteLoaderLocation, this.RemoteLoaderName);

      remoteLoader.InitLoader();

      string[] servAsmNames = this.GetServiceAssemblyNames();
      List<string> updatedServAsmList = new List<string>();
      List<string> trackedAsmNames = new List<string>();

      foreach (string asmName in servAsmNames) {
        bool updated =
          remoteLoader.TrackAssembly(asmName, timestamp, trackedAsmNames);
        if (updated == true) {
          updatedServAsmList.Add(asmName);
        }
      }

      AppDomain.Unload(asmTrackDomain);

      // trackedAsmNames is used to remove un-referenced library assemblies.

      string[] upServAsmNames = new string[updatedServAsmList.Count];
      for (int i = 0; i < updatedServAsmList.Count; i ++) {
        upServAsmNames[i] = (string) updatedServAsmList[i];
      }

      return upServAsmNames;
    }


    /// <summary>
    ///   Perform locking.
    /// </summary>
    protected abstract void OnLock();


    /// <summary>
    ///   Perform unlocking.
    /// </summary>
    protected abstract void OnUnlock();


  }

}

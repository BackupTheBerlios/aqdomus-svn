/*
 * IRemoteLoader.cs
 *
 * Copyright (C) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */


using System;
using System.Collections.Generic;


namespace AqDHome.ServiceHost
{

  /// <summary>
  ///   IRemoteLoader is used together with IAssemblyProvider to help loading
  ///   assemblies into service AppDomains.
  /// </summary>
  public interface IRemoteLoader
  {


    /// <summary>
    ///   Initialize the loader (in service's own AppDomain).
    /// </summary>
    /// <remarks>
    ///   This method should setup AppDomain.AssemblyResolve property if the
    ///   sources of assemblies involve remote computers or non-filesystem
    ///   devices.
    /// </remarks>
    void InitLoader();


    /// <summary>
    ///   For remote AppDomains to load assemblies into current service
    ///   AppDomain.
    /// </summary>
    /// <param name="assemblyName">
    ///   The name of the assembly to load.
    /// </param>
    /// <exception cref="System.ArgumentException">
    ///   Throws if <paramref name="assemblyName"/> is null.
    /// </exception>
    void LoadAssembly(string assemblyName);


    /// <summary>
    ///   Load and track assembly to see if it or its library assemblies have
    ///   been modified (old than <paramref name="timestamp"/>).
    /// </summary>
    /// <param name="assemblyName">
    ///   The name of the assembly to track.
    /// </param>
    /// <param name="timestamp">
    ///   The UTC time used to test whether assemblies are modified or not.
    /// </param>
    /// <param name="trackedAssemblyNames">
    ///   This List will contain assembly names walked during the tracking
    ///   process.
    /// </param>
    /// <returns>
    ///   true if modified, otherwise false.
    /// </returns>
    /// <exception cref="System.ArgumentException">
    ///   Throws if <paramref name="assemblyName"/> or
    ///   <paramref name="trackedAssemblyNames"/> is null.
    /// </exception>
    bool TrackAssembly(string assemblyName,
                       DateTime timestamp,
                       List<string> trackedAssemblyNames);


  }

}

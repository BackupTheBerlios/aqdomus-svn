/*
 * RemoteLoaderBase.cs
 *
 * Copyright (C) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using AqDHome.ServiceHost;


namespace AqDHome.ServiceHost.RemoteLoaders
{

  /// <summary>
  ///   A single-source remote loader that loads assemblies from
  ///   <see cref="AppDomain.BaseDirectory"/>.
  /// </summary>
  public abstract class RemoteLoaderBase: MarshalByRefObject, IRemoteLoader
  {


    /// <summary>
    ///   <seealso cref="IRemoteLoader.InitLoader"/>
    /// </summary>
    public abstract void InitLoader();


    /// <summary>
    ///   <seealso cref="IRemoteLoader.LoadAssembly"/>
    /// </summary>
    public void LoadAssembly(string assemblyName)
    {
      if (assemblyName == null) {
        throw new ArgumentException("must not be null", "assemblyName");
      }

      AppDomain.CurrentDomain.Load(assemblyName);
    }


    /// <summary>
    ///   <seealso cref="IRemoteLoader.TrackAssembly"/>
    /// </summary>
    public bool TrackAssembly(string assemblyName,
                              DateTime timestamp,
                              List<string> trackedAssemblyNames)
    {
      if (assemblyName == null) {
        throw new ArgumentException("must not be null", "assemblyName");
      }

      if (trackedAssemblyNames == null) {
        throw new ArgumentException("must not be null", "trackedAssemblyNames");
      }

      bool updated = false;
      Assembly assembly = AppDomain.CurrentDomain.Load(assemblyName);
      DateTime newDate = File.GetLastWriteTimeUtc(assembly.Location);
      if (newDate > timestamp) {
        updated = true;
      }

      AssemblyName[] depAsmNames = assembly.GetReferencedAssemblies();

      foreach (AssemblyName asmName in depAsmNames) {
        if (trackedAssemblyNames.Contains(asmName.Name) == false) {
          trackedAssemblyNames.Add(asmName.Name);
        }
        updated |= this.TrackAssembly(asmName.Name,
                                      timestamp,
                                      trackedAssemblyNames);
      }

      return updated;
    }


  }

}

/*
 * SimpleAssemblyProvider.cs
 *
 * Copyright (C) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */


using System;
using System.IO;
using System.Reflection;

using AqDHome.ServiceHost;


namespace AqDHome.ServiceHost.AssemblyProviders
{

  /// <summary>
  ///   A simple AssemblyProvider
  /// </summary>
  public class SimpleAssemblyProvider: AssemblyProviderBase
  {


    string assemblyDirectory;


    /// <summary>
    ///   Create a new SimpleAssemblyProvider with a specified assembly path.
    /// </summary>
    /// <param name="assemblyDirectory">
    ///   Path to the directory where assemblies are stored, with '/' as the
    ///   directory separator. And it must end with '/'.
    /// </param>
    /// <exception cref="System.ArgumentException">
    ///   Throws if <paramref name="assemblyDirectory"/> is null or an invalid
    ///   path name.
    /// </exception>
    public static IAssemblyProvider CreateProvider(string assemblyDirectory)
    {
      if (assemblyDirectory == null) {
        throw new ArgumentException(
          "must not be null", "assemblyDirectory");
      }

      if (assemblyDirectory.EndsWith("/") == false) {
        throw new ArgumentException(
          "must end with '/'", "assemblyDirectory");
      }

      return new SimpleAssemblyProvider(assemblyDirectory);
    }


    private SimpleAssemblyProvider()
    {
    }


    /// <summary>
    ///   Initialize a SimpleAssemblyProvider with a specified
    ///   assembly path.
    /// </summary>
    /// <remarks>
    ///   <paramref name="assemblyDirectory"/> is not checked in this
    ///   constructor.
    /// </remarks>
    protected SimpleAssemblyProvider(string assemblyDirectory)
    {
      this.assemblyDirectory = assemblyDirectory;
    }


    /// <summary>
    ///   <seealso cref="AssemblyProviderBase.BaseDirectory"/>
    /// </summary>
    public override string BaseDirectory
    {
      get
      {
        return this.assemblyDirectory;
      }
    }


    /// <summary>
    ///   <seealso cref="AssemblyProviderBase.RemoteLoaderName"/>
    /// </summary>
    public override string RemoteLoaderName
    {
      get
      {
        return "AqDHome.ServiceHost.RemoteLoaders.SimpleRemoteLoader";
      }
    }


    /// <summary>
    ///   <seealso cref="AssemblyProviderBase.RemoteLoaderLocation"/>
    /// </summary>
    public override string RemoteLoaderLocation
    {
      get
      {
        Type loaderType =
          typeof(AqDHome.ServiceHost.RemoteLoaders.SimpleRemoteLoader);
        Assembly loaderAsm = Assembly.GetAssembly(loaderType);

        return loaderAsm.Location;
      }
    }


    /// <summary>
    ///   <seealso cref="AssemblyProviderBase.OnLock"/>
    /// </summary>
    protected override void OnLock()
    {
    }


    /// <summary>
    ///   <seealso cref="AssemblyProviderBase.OnUnlock"/>
    /// </summary>
    protected override void OnUnlock()
    {
    }


    /// <summary>
    ///   <seealso cref="AssemblyProviderBase.GetLibraryAssemblyNames"/>
    /// </summary>
    public override string[] GetLibraryAssemblyNames()
    {
      string[] assemblieFiles = null;
      assemblieFiles = Directory.GetFiles(this.assemblyDirectory, "*.dll");

      string[] assemblyNames = new string[assemblieFiles.Length];
      for (int i = 0; i < assemblieFiles.Length; i ++) {
        string asmFile = assemblieFiles[i];
        assemblyNames[i] = Path.GetFileNameWithoutExtension(asmFile);
      }

      return assemblyNames;
    }


    /// <summary>
    ///   <seealso cref="AssemblyProviderBase.GetServiceAssemblyNames"/>
    /// </summary>
    public override string[] GetServiceAssemblyNames()
    {
      string[] assemblieFiles = null;
      assemblieFiles = Directory.GetFiles(this.assemblyDirectory, "*.exe");

      string[] assemblyNames = new string[assemblieFiles.Length];
      for (int i = 0; i < assemblieFiles.Length; i ++) {
        string asmFile = assemblieFiles[i];
        assemblyNames[i] = Path.GetFileNameWithoutExtension(asmFile);
      }

      return assemblyNames;
    }


  }

}

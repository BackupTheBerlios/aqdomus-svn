/*
 * IAssemblyProvider.cs
 *
 * Copyright (C) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */


using System;


namespace AqDHome.ServiceHost
{

  /// <summary>
  ///   IAssemblyProvider lists service assemblies and their library
  ///   assemblies from pre-configured sources and help loading them into
  ///   different AppDomains.
  ///
  ///   Its goal is to abstract the low-level system to locate assemblies, thus
  ///   you could load them from different sources (ex: local file system or
  ///   FTP) by the same interface.
  /// </summary>
  public interface IAssemblyProvider
  {


    /// <summary>
    ///   The base directory where assemblies are loaded from.
    /// </summary>
    /// <remarks>
    ///   This property should always be a valid directory path to an existing
    ///   directory on file system, but it doesn't necessarily contain all
    ///   assemblies in this provider because some may be loaded from memory or
    ///   remote computers.
    /// </remarks>
    string BaseDirectory { get; }


    /// <summary>
    ///   The name of the remote loader used by this assembly provider.
    /// </summary>
    /// <remarks>
    ///   The name returned should be a complete class name, including its
    ///   namespace.
    /// </remarks>
    string RemoteLoaderName { get; }


    /// <summary>
    ///   The location of the remote loader assembly used by this assembly
    ///   provider.
    /// </summary>
    /// <remarks>
    ///   The location returned should be an absolute path to a physical
    ///   assembly on filesystem.
    /// </remarks>
    string RemoteLoaderLocation { get; }


    /// <summary>
    ///   Indicate whether this IAssemblyProvider is locked or not.
    /// </summary>
    bool IsLocked { get; }


    /// <summary>
    ///   Lock the system where assemblies are loaded from, to make sure no
    ///   change will occur during assembly listing and loading.
    /// </summary>
    /// <remarks>
    ///   (throw exception when fails??)
    /// </remarks>
    void Lock();


    /// <summary>
    ///   Unlock the system where assemblies are loaded from.
    ///   <seealso cref="IAssemblyProvider.Lock"/>
    /// </summary>
    void Unlock();


    /// <summary>
    ///   Get the names of library assemblies in this provider.
    /// </summary>
    /// <returns>
    ///   Array of assemblies names (no extension file name). If there is no
    ///   library assemblies, an empty array is returned.
    /// </returns>
    string[] GetLibraryAssemblyNames();


    /// <summary>
    ///   Get the names of service assemblies in this provider.
    /// </summary>
    /// <returns>
    ///   Array of assemblies names (no extension file name). If there is no
    ///   service assemblies, an empty array is returned.
    /// </returns>
    string[] GetServiceAssemblyNames();


    /// <summary>
    ///   Get the names of services whose assemblies or library assemblies
    ///   have modification date newer than <paramref name="timestamp"/>.
    /// </summary>
    /// <param name="timestamp">
    ///   UTC timestamp.
    /// </param>
    /// <returns>
    ///   Array of assemblies names (no extension file name). If there is no
    ///   updated assemblies, an empty array is returned.
    /// </returns>
    string[] GetUpdatedServiceAssemblyNames(DateTime timestamp);


  }

}

/*
 * IServiceContainer.cs
 *
 * Copyright (C) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */


using System;


namespace AqDHome.ServiceHost
{

  /// <summary>
  ///   IServiceContainer is a simple controller to start, stop, and restart
  ///   services in a <see cref="IAssemblyProvider"/>.
  /// </summary>
  public interface IServiceContainer
  {


    /// <summary>
    ///   The class instance that list and help loading service assemblies. It
    ///   should never be null.
    /// </summary>
    IAssemblyProvider AssemblyProvider { get; }


    /// <summary>
    ///   The UTC timestamp when the last time you call
    ///   <see cref="IServiceContainer.Update"/>. Any service whose assemblies
    ///   have modification date newer than this timestamp will be restarted
    ///   when the next time you call <see cref="IServiceContainer.Update"/>.
    /// </summary>
    DateTime LastUpdateTimestamp { get; }


    /// <summary>
    ///   Get a list of active (running) services. There is no way for the
    ///   IServiceContainer to track inactive services because they may have
    ///   been removed.
    /// </summary>
    /// <returns>
    ///   Array of service names. If there is no service running, an empty
    ///   array is returned.
    /// </returns>
    string[] GetActiveServiceNames();


    /// <summary>
    ///   This method performs:
    ///   <list type="number">
    ///     <item>
    ///       Shut down services that don't exist in
    ///       <see cref="IServiceContainer.AssemblyProvider"/> (removed
    ///       services).
    ///     </item>
    ///     <item>
    ///       Restart services whose assemblies or library assemblies in
    ///       <see cref="IServiceContainer.AssemblyProvider"/> have been
    ///       modified.
    ///     </item>
    ///     <item>
    ///       Start services which are present in
    ///       <see cref="IServiceContainer.AssemblyProvider"/> but not running
    ///       currently (newly-added services).
    ///     </item>
    ///     <item>
    ///       Delete un-referenced library assemblies in
    ///       <see cref="IServiceContainer.AssemblyProvider"/>.
    ///     </item>
    ///   </list>
    /// </summary>
    /// <remarks>
    ///   Assemblies under <see cref="IServiceContainer.AssemblyProvider"/>
    ///   should not be modified when this method is executing.
    /// </remarks>
    void Update();


    /// <summary>
    ///   Shut down all services.
    /// </summary>
    /// <remarks>
    ///   All service AppDomains which correspond to service assemblies in
    ///   <see cref="IServiceContainer.AssemblyProvider"/> are unloaded after
    ///   calling this method.
    /// </remarks>
    void Stop();


  }

}

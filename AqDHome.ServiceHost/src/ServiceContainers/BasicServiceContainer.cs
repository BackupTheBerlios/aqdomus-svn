/*
 * BasicServiceContainer.cs
 *
 * Copyright (C) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */


using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Threading;

using AqDHome.ServiceHost;


namespace AqDHome.ServiceHost.ServiceContainers
{

  /// <summary>
  ///   The service container.
  ///   <seealso cref="IServiceContainer"/>.
  /// </summary>
  public class BasicServiceContainer: MarshalByRefObject, IServiceContainer
  {


    private delegate void AppDomainInvoker(AppDomain domain);

    private IAssemblyProvider assemblyProvider;

    private List<AppDomain> serviceAppDomainList;

    private DateTime lastUpdateTimestamp = DateTime.MaxValue;


    /// <summary>
    ///   Create a new BasicServiceContainer with a specified
    ///   IAssemblyProvider.
    /// </summary>
    /// <exception cref="System.ArgumentException">
    ///   Throws if <paramref name="assemblyProvider"/> is null.
    /// </exception>
    public static IServiceContainer CreateContainer(
      IAssemblyProvider assemblyProvider)
    {
      if (assemblyProvider == null) {
        throw new ArgumentException("Must be a valid provider",
                                    "assemblyProvider");
      }

      return new BasicServiceContainer(assemblyProvider);
    }


    private BasicServiceContainer()
    {
    }


    /// <summary>
    ///   Initialize a BasicServiceContainer with a specified
    ///   IAssemblyProvider
    /// </summary>
    /// <remarks>
    ///   <paramref name="assemblyProvider"/> is not checked in this
    ///   constructor.
    /// </remarks>
    protected BasicServiceContainer(IAssemblyProvider assemblyProvider)
    {
      this.assemblyProvider = assemblyProvider;
    }


    /// <summary>
    ///   <seealso cref="IServiceContainer.AssemblyProvider"/>
    /// </summary>
    public virtual IAssemblyProvider AssemblyProvider
    {
      get
      {
        return this.assemblyProvider;
      }
    }


    /// <summary>
    ///   <seealso cref="IServiceContainer.LastUpdateTimestamp"/>
    /// </summary>
    public virtual DateTime LastUpdateTimestamp
    {
      get
      {
        return this.lastUpdateTimestamp;
      }
    }


    /// <summary>
    ///   <seealso cref="IServiceContainer.GetActiveServiceNames"/>
    /// </summary>
    public virtual string[] GetActiveServiceNames()
    {
      string[] serviceList = new string[this.serviceAppDomainList.Count];

      for (int i = 0; i < this.serviceAppDomainList.Count; i ++) {
        AppDomain ad = (AppDomain) this.serviceAppDomainList[i];
        serviceList[i] = ad.FriendlyName;
      }

      return serviceList;
    }


    /// <summary>
    ///   <seealso cref="IServiceContainer.Update"/>
    /// </summary>
    public virtual void Update()
    {
      if (this.assemblyProvider == null) {
        throw new InvalidOperationException(
          "AssemblyProvider has not been initialized");
      }

      if (this.serviceAppDomainList == null) {
        this.serviceAppDomainList = new List<AppDomain>();
      }

      string[] updatedServiceNames
        = this.assemblyProvider.GetUpdatedServiceAssemblyNames(
          this.lastUpdateTimestamp);

      string[] newServiceNames
        = this.assemblyProvider.GetServiceAssemblyNames();

      // Shut down and remove services whose assemblies have been updated since
      // last Update() call.
      foreach (AppDomain servDomain in this.serviceAppDomainList) {
        if (Array.IndexOf(updatedServiceNames, servDomain.FriendlyName)
            != -1) {
          this.ShutDownService(servDomain);
          this.serviceAppDomainList.Remove(servDomain);
        }
      }

      // Shut down and remove services that doesn't exist in current
      // AssemblyProvider.
      foreach (AppDomain oldServDomain in this.serviceAppDomainList) {
        if (Array.IndexOf(newServiceNames, oldServDomain.FriendlyName) == -1) {
          this.ShutDownService(oldServDomain);
          this.serviceAppDomainList.Remove(oldServDomain);
        }
      }

      // Launch services that are not running but exist in current
      // AssemblyProvider (including updatesServices).
      string[] currentServices = this.GetActiveServiceNames();

      foreach (string newServName in newServiceNames) {
        if (Array.IndexOf(currentServices, newServName) == -1) {
          AppDomain newServDomain = this.LaunchNewService(newServName);
          this.serviceAppDomainList.Add(newServDomain);
        }
      }

      this.lastUpdateTimestamp = DateTime.UtcNow;
    }


    /// <summary>
    ///   <seealso cref="IServiceContainer.Stop"/>
    /// </summary>
    public virtual void Stop()
    {
      foreach (AppDomain serviceDomain in this.serviceAppDomainList) {
        AppDomain.Unload(serviceDomain);
      }

      this.serviceAppDomainList.Clear();
    }


    /// <summary>
    ///   Shut down a service.
    /// </summary>
    protected virtual void ShutDownService(AppDomain serviceDomain)
    {
      AppDomain.Unload(serviceDomain);
    }


    /// <summary>
    ///   Create a new AppDomain for the given <paramref name="serviceName"/>
    ///   and start it.
    /// </summary>
    protected virtual AppDomain LaunchNewService(string serviceName)
    {
      AppDomain serviceDomain = AppDomain.CreateDomain(
        serviceName,
        new Evidence(),
        this.assemblyProvider.BaseDirectory,
        string.Empty,
        false);

      AppDomainInvoker invoker = new AppDomainInvoker(this.InvokeAppDomain);

      invoker.BeginInvoke(serviceDomain,
                          new AsyncCallback(this.EndAppDomainInvoker),
                          new object());

      return serviceDomain;
    }


    private void InvokeAppDomain(AppDomain domain)
    {
      domain.ExecuteAssembly(domain.FriendlyName);
    }


    private void EndAppDomainInvoker(IAsyncResult result)
    {
      AsyncResult asyncResult = (AsyncResult) result;
      AppDomainInvoker invoker = (AppDomainInvoker) asyncResult.AsyncDelegate;
      invoker.EndInvoke(result);
    }


  }

}

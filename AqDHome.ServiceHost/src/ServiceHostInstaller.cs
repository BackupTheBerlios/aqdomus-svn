/*
 * ServiceHostInstaller.cs
 *
 * Copyright (C) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */


using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;


namespace AqDHome.ServiceHost
{

  /// <summary>
  ///   Installer for AqDHome.SerciceHost
  /// </summary>
  [RunInstaller(true)]
  public class ServiceHostInstaller: Installer
  {


    private ServiceProcessInstaller servProcInst;
    private ServiceInstaller servInst;


    /// <summary>
    ///   Perform installation. This method should be called only by
    ///   InstallUtil.exe
    /// </summary>
    public ServiceHostInstaller()
    {
      this.servProcInst = new ServiceProcessInstaller();
      this.servInst = new ServiceInstaller();

      this.servProcInst.Account = ServiceAccount.NetworkService;

      this.servInst.ServiceName = "AqDHome.ServiceHost";
      this.servInst.DisplayName= "AqDHome.ServiceHost";
      this.servInst.StartType = ServiceStartMode.Automatic;

      this.Installers.Add(this.servInst);
      this.Installers.Add(this.servProcInst);
    }


  }

}

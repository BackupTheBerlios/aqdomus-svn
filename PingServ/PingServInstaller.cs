using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace PingServ {

  [RunInstaller(true)]
    public class PingServInstaller: Installer {


      private ServiceProcessInstaller servProcInst;
      private ServiceInstaller servInst;


      public PingServInstaller() {
        this.servProcInst = new ServiceProcessInstaller();
        this.servInst = new ServiceInstaller();

        this.servProcInst.Account = ServiceAccount.NetworkService;

        this.servInst.ServiceName = "PingServ";
        this.servInst.DisplayName= "Ping Server";
        this.servInst.StartType = ServiceStartMode.Automatic;

        this.Installers.Add(this.servInst);
        this.Installers.Add(this.servProcInst);
      }


    }

}

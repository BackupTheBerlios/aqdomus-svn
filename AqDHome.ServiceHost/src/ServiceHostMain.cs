/*
 * ServiceHostMain.cs
 *
 * Copyright (C) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */


using System;
using System.ServiceProcess;


namespace AqDHome.ServiceHost
{

  /// <summary>
  ///   The service host.
  /// </summary>
  public class ServiceHostMain: ServiceBase
  {


    /// <summary>
    ///   Run!
    /// </summary>
    public static void Main(string[] args)
    {
      ServiceHostMain servHostMain = new ServiceHostMain();
      servHostMain.ServiceName = "AqDHome.ServiceHost";
      ServiceBase.Run(servHostMain);
      //ServiceHostMain.TestSimpleAssemblyProvider("test/", DateTime.UtcNow);
    }


    /// <summary>
    ///   <seealso cref="System.ServiceProcess.ServiceBase.OnStart"/>
    /// </summary>
    protected override void OnStart(string[] args)
    {
    }


    /// <summary>
    ///   <seealso cref="System.ServiceProcess.ServiceBase.OnStop"/>
    /// </summary>
    protected override void OnStop()
    {
    }


    /// <summary>
    ///   <seealso cref="System.ServiceProcess.ServiceBase.OnPause"/>
    /// </summary>
    protected override void OnPause()
    {
    }


    /// <summary>
    ///   <seealso cref="System.ServiceProcess.ServiceBase.OnContinue"/>
    /// </summary>
    protected override void OnContinue()
    {
    }


    /// <summary>
    ///   Test SimpleServiceAssemblyProvider.
    /// </summary>
    public static void TestSimpleAssemblyProvider(string path,
                                                  DateTime timestamp)
    {
      IAssemblyProvider provider
        = AssemblyProviders.SimpleAssemblyProvider.CreateProvider(path);

      Console.WriteLine("Service Assembly Names:");
      string[] servAsmNames = provider.GetServiceAssemblyNames();
      foreach (string n in servAsmNames) {
        Console.WriteLine("  " + n);
      }

      Console.WriteLine("");

      Console.WriteLine("Library Assembly Names:");
      string[] libAsmNames = provider.GetLibraryAssemblyNames();
      foreach (string n in libAsmNames) {
        Console.WriteLine("  " + n);
      }

      Console.WriteLine("\nPress ENTER to test GetUpdatedServiceAssemblyNames");
      Console.ReadLine();
      string[] upAsmNames = provider.GetUpdatedServiceAssemblyNames(timestamp);
      foreach (string n in upAsmNames) {
        Console.WriteLine("  " + n);
      }
    }


  }

}

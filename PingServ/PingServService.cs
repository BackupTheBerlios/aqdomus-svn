using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;

[assembly:AssemblyTitle("PingServ")]
[assembly:AssemblyVersion("1.0.0")]
[assembly:AssemblyKeyFile("PingServ.snk")]

namespace PingServ {

  public class PingServService: ServiceBase {
    protected Timer timer;
    protected EventLog log;
    protected int timerInterval;
    protected int webReqTimeout;
    protected string urlListFile = "PingUrls.txt";
    protected string urlListPath;


    public static void Main(string[] Args) {
      PingServService pingServ = new PingServService();
      pingServ.ServiceName = "PingServ";
      ServiceBase.Run(pingServ);
    }


    public PingServService() {
      string sdir = AppDomain.CurrentDomain.BaseDirectory;
      this.urlListPath = sdir + "\\" + this.urlListFile;
    }


    protected override void OnStart(string[] args) {
      if (!EventLog.SourceExists("PingServ")) {
        EventLog.CreateEventSource("PingServ", "PingServ");
      }
      this.timerInterval =
        Int32.Parse(ConfigurationSettings.AppSettings["PingServ.PingInterval"]);
      this.webReqTimeout =
        Int32.Parse(ConfigurationSettings.AppSettings["PingServ.PingTimeout"]);
      this.log = new EventLog();
      this.log.Source = "PingServ";
      this.timer = new Timer(new TimerCallback(this.Ping),
          null, 1000, this.timerInterval);
    }


    protected override void OnStop() {
      this.timer.Change(Timeout.Infinite, Timeout.Infinite);
    }


    protected override void OnPause() {
      this.timer.Change(Timeout.Infinite, Timeout.Infinite);
    }


    protected override void OnContinue() {
      this.timer.Change(0, this.timerInterval);
    }


    public void Ping() {
      this.Ping(null);
    }


    protected void Ping(object state) {
      StreamReader reader = null;
      string line;

      try {
        reader = new StreamReader(this.urlListPath, Encoding.UTF8);
        while ((line = reader.ReadLine()) != null) {
          string url = line.Trim();
          if (url != "")
            this.PingUrl(url);
        }
      } catch (Exception e) {
        log.WriteEntry("Exception: " + e.Message);
      } finally {
        if (reader != null)
          reader.Close();
      }
    }


    protected void PingUrl(string url) {
      WebRequest wreq;
      IAsyncResult result;
      wreq = WebRequest.Create(url);
      wreq.Timeout = this.webReqTimeout;
      result = wreq.BeginGetResponse(
          new AsyncCallback(this.WebRequestEndCallback), wreq);
    }


    protected void WebRequestEndCallback(IAsyncResult result) {
      WebRequest wreq = (WebRequest) result.AsyncState;
      WebResponse wres = wreq.EndGetResponse(result);
      wres.Close();
    }


  }

}

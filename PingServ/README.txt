PingServ is a simple Windows Service Demo. It pings all URLs listed in
PingUrls.txt every 30 seconds.

Install:
  InstallUtil.exe PingServ.exe


Uninstall:
  InstallUtil.exe /u PingServ.exe

  (InstallUtil.exe is put in .NET framework directory, together with csc.exe)


Setting ping interval:
  Modify the value of AppSetting "PingServ.PingInterval".  The unit is ms
  (microsecond).


Setting ping timeout:
  Modify the value of AppSetting "PingServ.PingTimeout". The unit is ms
  (microsecond).


Setting ping URLs:
  Edit PingUrls.txt which is under the directory where PingServ.exe resides.
  URLs are separated by newline.


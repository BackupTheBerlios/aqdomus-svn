@setlocal
@set CSC_OPTS=/nologo /target:exe /optimize+ /debug /warn:4 /keyfile:AqDHome.snk
@set CSC_REFS=/r:System.dll /r:System.Configuration.Install.dll /r:System.ServiceProcess.dll
csc %CSC_OPTS% %CSC_REFS% /out:bin\AqDHome.ServiceHost.exe /doc:bin\AqDHome.ServiceHost.xml /recurse:src\*.cs
:end

@setlocal
@echo off
@set CSC_OPTS=/nologo /target:library /optimize+ /debug-
csc %CSC_OPTS% /out:bin\AqDHome.WebUI.dll /doc:bin\AqDHome.WebUI.xml /recurse:WebUI_Code\*.cs /recurse:WebUI_EmPages\*.cs *.cs
csc %CSC_OPTS% /out:bin\AqDHome.Storage.dll /doc:bin\AqDHome.Storage.xml /recurse:Storage_Core\*.cs /recurse:Storage_DBs\*.cs
:end

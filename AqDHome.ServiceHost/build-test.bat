@setlocal
@echo off
@set CSC_OPTS=/nologo /optimize+ /debug- /warn:4
cd test
csc %CSC_OPTS% /t:library testdep2.cs
csc %CSC_OPTS% /t:library /r:testdep2.dll testdep1.cs
csc %CSC_OPTS% /t:exe /r:testdep1.dll testserv1.cs
cd ..
:end

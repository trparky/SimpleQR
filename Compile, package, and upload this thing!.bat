MSBuild.exe "SimpleQR.sln" /noconsolelogger /t:Rebuild /p:Configuration=Debug
MSBuild.exe "SimpleQR.sln" /noconsolelogger /t:Rebuild /p:Configuration=Release
cd "SimpleQR\bin\Release"
"Package This Program!.bat"
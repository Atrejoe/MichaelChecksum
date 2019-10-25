@echo off
dotnet publish MichaelChecksum.Console -r osx.10.13-x64 -c ReleaseConsole /p:PublishSingleFile=true /p:PublishTrimmed=true 
dotnet publish MichaelChecksum.Console -r linux-x64     -c ReleaseConsole /p:PublishSingleFile=true /p:PublishTrimmed=true
dotnet publish MichaelChecksum.Console -r win-x64       -c ReleaseConsole /p:PublishSingleFile=true /p:PublishTrimmed=true 
dotnet publish MichaelChecksum.Console -r linux-arm     -c ReleaseConsole /p:PublishSingleFile=true /p:PublishTrimmed=true 

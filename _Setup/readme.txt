DO NOT FORGET dotnet restore after any .csproj change !

File explorer:

 sudo nautilus

create release : 
  dotnet publish -c Release

  dotnet publish -c Release -r ubuntu.16.04-x64 
  (for self contained application)

Save ftp-worker.service to /etc/systemd/system/

status service: 
 systemctl status ftp-worker

 all development on github.com/dotnet


 List of runtime identifiers :
 https://docs.microsoft.com/en-us/dotnet/core/rid-catalog
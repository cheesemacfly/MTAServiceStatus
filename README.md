[![Build Status](https://travis-ci.org/cheesemacfly/MTAServiceStatus.svg?branch=master)](https://travis-ci.org/cheesemacfly/MTAServiceStatus)
[![Build status](https://ci.appveyor.com/api/projects/status/g03ekujid04nep5m?svg=true)](https://ci.appveyor.com/project/cheesemacfly/mtaservicestatus)

###What?

Simple C# library to get the latest MTA service status.  
Available as a nuget package here: https://www.nuget.org/packages/MTAServiceStatus  
or running the command: `PM> Install-Package MTAServiceStatus`

###How?

```C#
var repo = new MTARepository();
var status = await repo.GetServiceAsync();
var goodService = from s in status.Subway
                  where s.Status == ServiceStatus.GOOD_SERVICE
                  select s;

Console.WriteLine("Currently {0} subway lines with \"GOOD SERVICE\"", goodService.Count());
//Displays "Currently 4 subway lines with "GOOD SERVICE""
```

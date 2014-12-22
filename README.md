[![Build Status](https://travis-ci.org/cheesemacfly/MTAServiceStatus.svg?branch=master)](https://travis-ci.org/cheesemacfly/MTAServiceStatus)
[![Build status](https://ci.appveyor.com/api/projects/status/g03ekujid04nep5m/branch/master?svg=true)](https://ci.appveyor.com/project/cheesemacfly/mtaservicestatus/branch/master)

###What?

Simple C# library to get the latest MTA service status.  
Available as a nuget package here: https://www.nuget.org/packages/MTAServiceStatus  
or running the command: `PM> Install-Package MTAServiceStatus`

###How?

If you need to get the status per subway line, you can use the [`MTASubwayStatus`](MTAServiceStatus/MTASubwayStatus.cs) class.

```C#
var status = new MTASubwayStatus();
var lines = await status.GetLinesAsync();
foreach(var line in lines)
{
	Console.WriteLine("Line {0} current status: {1}", line.Name, line.Status);
}
// Displays:
// Line 1 current status: GOOD_SERVICE
// Line 2 current status: DELAYS
// Line A current status: PLANNED_WORK
```

If you are looking for buses or other trains, you have to use the [`MTARepository`](MTAServiceStatus/Repositories/MTARepository.cs) class:

```C#
var repo = new MTARepository();
var status = await repo.GetServiceAsync();
var goodService = from s in status.Bus
                  where s.Status == ServiceStatus.GOOD_SERVICE
                  select s;

Console.WriteLine("Currently {0} bus line groups with \"GOOD SERVICE\"", goodService.Count());
//Displays "Currently 4 bus line groups with "GOOD SERVICE""
```

Available groups available through this class are: `BT`, `Bus`, `LIRR`, `MetroNorth` and `Subway`.  

I am planning on getting the same process used for subway (per line status versus per group) applied to the other groups in a later release.
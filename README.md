[![Build Status](https://travis-ci.org/cheesemacfly/MTAServiceStatus.svg?branch=master)](https://travis-ci.org/cheesemacfly/MTAServiceStatus)

###What?

Simple C# library to get the latest MTA service status.

###How?

```C#
var repo = new MTARepository();
var status = await repo.GetStatusAsync();
var goodService = from s in status.Subway
                  where s.Status == "GOOD SERVICE"
                  select s;

Console.WriteLine("Currently {0} subway lines with \"GOOD SERVICE\"", goodService.Count());
//Displays "Currently 4 subway lines with "GOOD SERVICE""
```

###Why?

Who knows...

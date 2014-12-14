###What?

Simple C# library to get the latest MTA service status.

###How?

```
var repo = new MTARepository();
var status = await repo.GetStatusAsync();
var goodService = from s in status.subway
                  where s.status == "GOOD SERVICE"
                  select s;

Console.WriteLine("Currently {0} subway lines with \"GOOD SERVICE\"", goodService.Count());
//Displays "Currently 4 subway lines with "GOOD SERVICE""
```

###Why?

Who knows...
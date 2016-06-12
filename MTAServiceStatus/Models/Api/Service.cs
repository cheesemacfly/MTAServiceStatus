using System;
using System.Collections.Generic;

namespace MTAServiceStatus.Models.Api
{
    public class Service
    {
        public DateTime TimeStamp { get; set; }
        public List<Line> BT { get; set; }
        public List<Line> Bus { get; set; }
        public List<Line> LIRR { get; set; }
        public List<Line> MetroNorth { get; set; }
        public List<Line> Subway { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAServiceStatus.Models
{
    public class SubwayLine
    {
        public string Name { get; set; }
        public ServiceStatus Status { get; set; }
    }
}

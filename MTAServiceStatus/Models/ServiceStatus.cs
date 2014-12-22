using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAServiceStatus.Models
{
    public enum ServiceStatus
    {
        UNKNOWN,
        GOOD_SERVICE,
        PLANNED_WORK,
        SERVICE_CHANGE,
        DELAYS
    }
}

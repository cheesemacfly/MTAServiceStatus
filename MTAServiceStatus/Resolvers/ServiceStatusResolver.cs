using AutoMapper;
using MTAServiceStatus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAServiceStatus.Resolvers
{
    class ServiceStatusResolver : ValueResolver<RawLine, ServiceStatus>
    {
        protected override ServiceStatus ResolveCore(RawLine source)
        {
            if(!string.IsNullOrWhiteSpace(source.Status))
            {
                string status = source.Status.Replace(" ", "_").ToUpper();
                return (ServiceStatus)Enum.Parse(typeof(ServiceStatus), status);
            }

            return ServiceStatus.UNKNOWN;
        }
    }
}

using AutoMapper;
using MTAServiceStatus.Models;
using System;

namespace MTAServiceStatus.Resolvers
{
    internal sealed class ServiceStatusResolver : IValueResolver<RawLine, Line, ServiceStatus>
    {
        public ServiceStatus Resolve(RawLine source, Line destination, ServiceStatus destMember, ResolutionContext context)
        {
            if (!string.IsNullOrWhiteSpace(source.Status))
            {
                string status = source.Status.Replace(" ", "_").ToUpper();
                return (ServiceStatus)Enum.Parse(typeof(ServiceStatus), status);
            }

            return ServiceStatus.NONE;
        }
    }
}

using AutoMapper;
using MTAServiceStatus.Models;
using MTAServiceStatus.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAServiceStatus.Configs
{
    static class AutoMapperConfig
    {
        internal static void CreateMaps()
        {
            Mapper.CreateMap<RawService, Service>()
                .ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(s => DateTime.Parse(s.TimeStamp)));
            Mapper.CreateMap<RawLine, Line>()
                .ForMember(dest => dest.Status, opt => opt.ResolveUsing<ServiceStatusResolver>())
                .ForMember(dest => dest.Date, opt => opt.ResolveUsing<LineDateTimeResolver>());
        }
    }
}

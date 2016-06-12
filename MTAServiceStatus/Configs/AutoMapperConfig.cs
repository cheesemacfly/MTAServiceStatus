using AutoMapper;
using MTAServiceStatus.Models.Api;
using MTAServiceStatus.Resolvers;
using System;

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

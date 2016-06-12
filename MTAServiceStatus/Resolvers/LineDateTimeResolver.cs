using AutoMapper;
using MTAServiceStatus.Models.Api;
using System;

namespace MTAServiceStatus.Resolvers
{
    class LineDateTimeResolver : ValueResolver<RawLine, DateTime>
    {
        protected override DateTime ResolveCore(RawLine source)
        {
            if (!string.IsNullOrWhiteSpace(source.Date) && !string.IsNullOrWhiteSpace(source.Time))
            {
                var date = string.Format("{0} {1}", source.Date, source.Time);
                return DateTime.Parse(date);
            }

            return DateTime.Now;
        }
    }
}

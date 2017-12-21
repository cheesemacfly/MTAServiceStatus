using AutoMapper;
using MTAServiceStatus.Models;
using System;

namespace MTAServiceStatus.Resolvers
{
    internal sealed class LineDateTimeResolver : IValueResolver<RawLine, Line, DateTime>
    {
        public DateTime Resolve(RawLine source, Line destination, DateTime destMember, ResolutionContext context)
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

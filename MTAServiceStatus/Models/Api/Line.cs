using System;

namespace MTAServiceStatus.Models.Api
{
    public class Line
    {
        public string Name { get; set; }
        public ServiceStatus Status { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}

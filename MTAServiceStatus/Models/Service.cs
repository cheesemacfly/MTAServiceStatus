using System.Collections.Generic;
using System.Xml.Serialization;

namespace MTAServiceStatus.Models
{
    [XmlRoot("service")]
    public class Service
    {
        public int responsecode { get; set; }
        public string timestamp { get; set; }
        [XmlArrayItem("line")]
        public List<Line> subway { get; set; }
        [XmlArrayItem("line")]
        public List<Line> bus { get; set; }
        [XmlArrayItem("line")]
        public List<Line> BT { get; set; }
        [XmlArrayItem("line")]
        public List<Line> LIRR { get; set; }
        [XmlArrayItem("line")]
        public List<Line> MetroNorth { get; set; }
    }    
}

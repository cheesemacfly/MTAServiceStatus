using System.Collections.Generic;
using System.Xml.Serialization;

namespace MTAServiceStatus.Models
{
    [XmlRoot("service")]
    public class Service
    {
        [XmlElement("responsecode")]
        public int ResponseCode { get; set; }

        [XmlElement("timestamp")]
        public string TimeStamp { get; set; }

        [XmlElement("subway")]
        [XmlArrayItem("line")]
        public List<Line> Subway { get; set; }

        [XmlElement("bus")]
        [XmlArrayItem("line")]
        public List<Line> Bus { get; set; }

        [XmlArrayItem("line")]
        public List<Line> BT { get; set; }

        [XmlArrayItem("line")]
        public List<Line> LIRR { get; set; }

        [XmlArrayItem("line")]
        public List<Line> MetroNorth { get; set; }
    }    
}

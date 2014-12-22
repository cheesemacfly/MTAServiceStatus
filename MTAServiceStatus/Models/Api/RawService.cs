using System.Collections.Generic;
using System.Xml.Serialization;

namespace MTAServiceStatus.Models.Api
{
    [XmlRoot("service")]
    public class RawService
    {
        [XmlElement("responsecode")]
        public int ResponseCode { get; set; }

        [XmlElement("timestamp")]
        public string TimeStamp { get; set; }

        [XmlArrayItem("line")]
        public List<RawLine> BT { get; set; }

        [XmlArray("bus")]
        [XmlArrayItem("line")]
        public List<RawLine> Bus { get; set; }

        [XmlArrayItem("line")]
        public List<RawLine> LIRR { get; set; }

        [XmlArrayItem("line")]
        public List<RawLine> MetroNorth { get; set; }

        [XmlArray("subway")]
        [XmlArrayItem("line")]
        public List<RawLine> Subway { get; set; }
    }    
}

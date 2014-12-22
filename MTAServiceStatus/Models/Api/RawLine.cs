using System.Xml.Serialization;

namespace MTAServiceStatus.Models.Api
{
    public class RawLine
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("status")]
        public string Status { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }
    }
}

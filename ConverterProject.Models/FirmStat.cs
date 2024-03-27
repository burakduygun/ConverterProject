using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "FIRMSTAT")]
    public class FirmStat
    {

        [XmlElement(ElementName = "ROW")]
        public Row Row { get; set; }
    }
}

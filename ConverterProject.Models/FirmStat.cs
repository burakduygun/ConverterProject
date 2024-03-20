using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "FIRMSTAT")]
    public class FirmStat
    {

        [XmlElement(ElementName = "ROW")]
        public Row ROW { get; set; }
    }
}

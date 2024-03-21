using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "MOBILEUSERCOUNT")]
    public class MobileUserCount
    {

        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; set; }
    }

}

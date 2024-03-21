using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "USERCOUNT")]
    public class UserCount
    {

        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; set; }
    }
}

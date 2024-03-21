using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "DBSIZE")]
    public class DbSize
    {

        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; set; }
    }
}

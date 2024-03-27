using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "COL")]
    public class Col
    {

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }
    }
}

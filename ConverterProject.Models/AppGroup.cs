using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "APPGROUP")]
    public class AppGroup
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}

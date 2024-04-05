using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "APPNAME")]
    public class AppName
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}

using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "WINDOWSVERSION")]
    public class WindowsVersion
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }

        public override string ToString() { 
            return Value;
        }
    }
}

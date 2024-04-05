using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "WINDOWSPRODUCTSTRING")]
    public class WindowsProductString
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }
        public override string ToString()
        {
            return Value;
        }
    }
}

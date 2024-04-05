using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "WINDOWSEDITION")]
    public class WindowsEdition
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}

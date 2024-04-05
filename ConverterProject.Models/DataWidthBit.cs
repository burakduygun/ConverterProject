using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "DATAWIDTH_BIT")]
    public class DataWidthBit
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; set; }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}

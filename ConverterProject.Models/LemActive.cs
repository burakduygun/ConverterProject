using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "LEMACTIVE")]
    public class LemActive
    {

        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}

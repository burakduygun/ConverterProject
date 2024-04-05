using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "DBEDITION")]
    public class DbEdition
    {

        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }
        public override string ToString()
        {
            return Value;
        }
    }
}

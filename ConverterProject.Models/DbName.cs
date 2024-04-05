using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "DBNAME")]
    public class DbName
    {

        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}

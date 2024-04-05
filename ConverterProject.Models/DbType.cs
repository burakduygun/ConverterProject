using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "DBTYPE")]
    public class DbType
    {

        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}

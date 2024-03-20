using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "FORM")]
    public class UsageStatForm
    {

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "Type")]
        public int Type { get; set; }

        [XmlAttribute(AttributeName = "UsageCount")]
        public int UsageCount { get; set; }
    }
}

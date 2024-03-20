using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "USAGESTAT")]
    public class UsageStat
    {

        [XmlElement(ElementName = "FORM")]
        public List<UsageStatForm> FORMS { get; set; }
    }
}

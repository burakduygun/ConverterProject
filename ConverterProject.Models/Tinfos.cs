using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "TINFOS")]
    public class Tinfos
    {

        [XmlElement(ElementName = "USAGESTAT")]
        public UsageStat UsageStat { get; set; }

        [XmlElement(ElementName = "FIRMSTAT")]
        public FirmStat FirmStat { get; set; }

        [XmlElement(ElementName = "DBINFORMATION")]
        public DbInformation DbInformation { get; set; }

        [XmlElement(ElementName = "USERINFORMATION")]
        public UserInformation UserInformation { get; set; }
        [XmlElement(ElementName = "APPINFORMATION")]
        public AppInformation AppInformation { get; set; }
    }
}

using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "TINFOS")]
    public class Tinfos
    {
        [XmlElement(ElementName = "USAGESTAT")]
        public UsageStat UsageStat { get; set; }

        // güncellendi
        [XmlElement(ElementName = "APPINFORMATION")]
        public AppInformation AppInformation { get; set; }
        
        // yeni eklendi
        [XmlElement(ElementName = "INSIGHTINFORMATION")]
        public InsightInformation InsightInformation { get; set; }

        // güncellendi
        [XmlElement(ElementName = "SYSTEMINFORMATION")]
        public SystmInformation SystemInformation { get; set; }

        // güncellendi
        [XmlElement(ElementName = "DBINFORMATION")]
        public DbInformation DbInformation { get; set; }

        // güncellendi
        [XmlElement(ElementName = "USERINFORMATION")]
        public UserInformation UserInformation { get; set; }

        [XmlElement(ElementName = "FIRMSTAT")]
        public FirmStat FirmStat { get; set; }
    }
}

using System.Xml.Serialization;

namespace ConverterProject.Models
{
    // yeni eklendi hepsi
    [XmlRoot(ElementName = "INSIGHTINFORMATION")]
    public class InsightInformation
    {
        [XmlElement(ElementName = "INTEGRATIONCOUNT")]
        public int IntegrationCount { get; set; }

        [XmlElement(ElementName = "INTEGRATIONLASTRELOADTIME")]
        public DateTime IntegrationLastReloadTime { get; set; }

        [XmlElement(ElementName = "INSIGHTAPPCOUNT")]
        public int InsightAppCount { get; set; }

        [XmlElement(ElementName = "INSIGHTAPPLASTRELOADTIME")]
        public DateTime InsightAppLastReloadTime { get; set; }

        [XmlElement(ElementName = "INSIGHTAPPLASTMODIFIEDTIME")]
        public DateTime InsightAppLastModifiedTime { get; set; }

        [XmlElement(ElementName = "MAILSCHEDULERCOUNT")]
        public int MailSchedulerCount { get; set; }

        [XmlElement(ElementName = "MAILSCHEDULERLASTSENTTIME")]
        public string MailSchedulerLastSentTime { get; set; }
    }
}

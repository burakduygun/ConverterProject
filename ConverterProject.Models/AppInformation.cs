using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "APPINFORMATION")]
    public class AppInformation
    {
        [XmlElement(ElementName = "APPVERSION")]
        public AppVersion AppVersion { get; set; }
    }
}

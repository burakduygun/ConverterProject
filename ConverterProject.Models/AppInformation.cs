using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "APPINFORMATION")]
    public class AppInformation
    {
        [XmlElement(ElementName = "APPVERSION")]
        public AppVersion AppVersion { get; set; }

        [XmlElement(ElementName = "APPGROUP")]
        public AppGroup AppGroup { get; set; }

        [XmlElement(ElementName = "APPNAME")]
        public AppName AppName { get; set; }
    }
}

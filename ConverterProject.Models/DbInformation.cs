using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "DBINFORMATION")]
    public class DBInformation
    {

        [XmlElement(ElementName = "DB")]
        public DB DB { get; set; }
    }
}

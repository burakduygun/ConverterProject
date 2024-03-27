using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "DBINFORMATION")]
    public class DbInformation
    {

        [XmlElement(ElementName = "DB")]
        public Db Db { get; set; }
    }
}

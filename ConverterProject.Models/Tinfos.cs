using Microsoft.VisualBasic;
using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "TINFOs")]
    public class TINFOs
    {

        [XmlElement(ElementName = "USAGESTAT")]
        public UsageStat USAGESTAT { get; set; }

        [XmlElement(ElementName = "FIRMSTAT")]
        public FirmStat FIRMSTAT { get; set; }

        [XmlElement(ElementName = "DBINFORMATION")]
        public DBInformation DBINFORMATION { get; set; }

        [XmlElement(ElementName = "USERINFORMATION")]
        public UserInformation USERINFORMATION { get; set; }
    }
}

using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "USERINFORMATION")]
    public class UserInformation
    {

        [XmlElement(ElementName = "LICENSEDUSERCOUNT")]
        public LicensedUserCount LICENSEDUSERCOUNT { get; set; }

        [XmlElement(ElementName = "USERCOUNT")]
        public UserCount USERCOUNT { get; set; }

        [XmlElement(ElementName = "LEMACTIVE")]
        public LemActive LEMACTIVE { get; set; }

        [XmlElement(ElementName = "MOBILEUSERCOUNT")]
        public MobileUserCount MOBILEUSERCOUNT { get; set; }
    }
}

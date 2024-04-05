using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "USERINFORMATION")]
    public class UserInformation
    {

        [XmlElement(ElementName = "LICENSEDUSERCOUNT")]
        public LicensedUserCount LicensedUserCount { get; set; }

        [XmlElement(ElementName = "USERCOUNT")]
        public UserCount UserCount { get; set; }

        [XmlElement(ElementName = "LEMACTIVE")]
        public LemActive LemActive { get; set; }

        [XmlElement(ElementName = "MOBILEUSERCOUNT")]
        public MobileUserCount MobileUserCount { get; set; }

        // yeni eklendi
        [XmlElement(ElementName = "USERLASTMODIFIEDTIME")]
        public DateTime UserLastModified { get; set; }
    }
}

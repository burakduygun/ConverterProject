using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "LICENSEDUSERCOUNT")]
    public class LicensedUserCount
    {

        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; set; }
    }
}

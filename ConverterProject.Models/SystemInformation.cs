using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "SYSTEMINFORMATION")]
    public class SystmInformation
    {
        [XmlElement(ElementName = "WINDOWSVERSION")]
        public WindowsVersion WindowsVersion { get; set; }

        [XmlElement(ElementName = "WINDOWSEDITION")]
        public WindowsEdition WindowsEdition { get; set; }

        [XmlElement(ElementName = "WINDOWSPRODUCTSTRING")]
        public WindowsProductString WindowsProductString { get; set; }

        [XmlElement(ElementName = "DATAWIDTH_BIT")]
        public DataWidthBit DataWidthBit { get; set; }

        // yeni eklendi
        [XmlElement(ElementName = "RAM")]
        public string Ram { get; set; }

        // yeni eklendi
        [XmlElement(ElementName = "DISK")]
        public string Disk { get; set; }
    }
}

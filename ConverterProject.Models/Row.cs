using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "ROW")]
    public class Row
    {

        [XmlElement(ElementName = "COL")]
        public List<Col> Cols { get; set; }
    }
}

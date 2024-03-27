using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "DB")]
    public class Db
    {
        [XmlElement(ElementName = "DBSIZE")]
        public DbSize DbSize { get; set; }
    }
}

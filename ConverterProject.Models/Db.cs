using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "DB")]
    public class DB
    {
        [XmlElement(ElementName = "DBSIZE")]
        public DbSize DBSIZE { get; set; }
    }
}

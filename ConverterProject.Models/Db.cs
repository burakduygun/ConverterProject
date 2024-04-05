using System.Data;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConverterProject.Models
{
    [XmlRoot(ElementName = "DB")]
    public class Db
    {
        [XmlElement(ElementName = "DBTYPE")]
        public DbType DbType { get; set; }

        [XmlElement(ElementName = "DBNAME")]
        public DbName DbName { get; set; }

        [XmlElement(ElementName = "DBVERSION")]
        public DbVersion DbVersion { get; set; }

        [XmlElement(ElementName = "DBLEVEL")]
        public DbLevel DbLevel { get; set; }

        [XmlElement(ElementName = "DBEDITION")]
        public DbEdition DbEdition { get; set; }

        [XmlElement(ElementName = "DBSIZE")]
        public DbSize DbSize { get; set; }
    }
}

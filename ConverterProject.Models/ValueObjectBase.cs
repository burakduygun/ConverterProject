using System.Xml.Serialization;

namespace ConverterProject.Models
{
    public class ValueObjectBase
    {
        public string Value { get; set; }

        [XmlAttribute("Value")]
        public string AttributeValue
        {
            get { return Value; }
            set { Value = value; }
        }

        [XmlText]
        public string TextValue
        {
            get { return Value; }
            set { Value = value; }
        }

        private bool ShouldSerializeAttributeValue() => Value != null;

        public static string GetValue(ValueObjectBase obj)
        {
            string str = "";

            if (obj != null && obj.ShouldSerializeAttributeValue())
                str = obj.AttributeValue;

            return str;
        }
    }
}

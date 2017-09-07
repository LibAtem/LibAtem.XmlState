using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace LibAtem.XmlState.MacroSpec
{
    [XmlRoot("Macros", IsNullable = false)]
    public class XmlSpec
    {
        [XmlArrayItem("Field")]
        public List<XmlField> Fields { get; set; }

        [XmlArrayItem("Op")]
        public List<XmlOperation> Operations { get; set; }


        public static XmlSpec Load(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlSpec));
            FileStream fs = new FileStream(path, FileMode.Open);
            var res = (XmlSpec)serializer.Deserialize(fs);
            fs.Dispose();
            return res;
        }
    }

    public class XmlField
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("namespace")]
        public string Namespace { get; set; }

        [XmlAttribute("enumAsString")]
        public bool EnumAsString { get; set; }
    }

    public class XmlOperation
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("Field")]
        public List<XmlOpeationField> Fields { get; set; }
    }

    public class XmlOpeationField
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}

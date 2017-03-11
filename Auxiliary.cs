using System.Xml.Serialization;

namespace AtemEmulator.State
{
    public class Auxiliary
    {
        [XmlAttribute("id")]
        public VideoSource Id { get; set; }

        [XmlAttribute("input")]
        public VideoSource Input { get; set; }
    }
}
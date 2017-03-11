using System.Xml.Serialization;

namespace AtemEmulator.State
{
    public class ColorGenerator
    {
        [XmlAttribute("index")]
        public int Index { get; set; }
        
        [XmlAttribute("hue")]
        public int Hue { get; set; }

        [XmlAttribute("saturation")]
        public int Saturation { get; set; }

        [XmlAttribute("luma")]
        public int Luma { get; set; }
    }
}
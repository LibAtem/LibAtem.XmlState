using System.Xml.Serialization;

namespace AtemEmulator.State.MixEffects.Key
{
    public class PatternKeyParameters
    {
        [XmlAttribute("style")]
        public Pattern Style { get; set; }

        [XmlAttribute("inverse")]
        public AtemBool Inverse { get; set; }

        [XmlAttribute("size")]
        public double Size { get; set; }

        [XmlAttribute("symmetry")]
        public double Symmetry { get; set; }

        [XmlAttribute("softness")]
        public double Softness { get; set; }

        [XmlAttribute("xPosition")]
        public double XPosition { get; set; }

        [XmlAttribute("yPosition")]
        public double YPosition { get; set; }
    }
}
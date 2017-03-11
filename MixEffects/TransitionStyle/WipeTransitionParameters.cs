using System.Xml.Serialization;

namespace AtemEmulator.State.MixEffects.TransitionStyle
{
    public class WipeTransitionParameters
    {
        [XmlAttribute("rate")]
        public int Rate { get; set; }

        [XmlAttribute("pattern")]
        public Pattern Pattern { get; set; }

        [XmlAttribute("symmetry")]
        public int Symmetry { get; set; }

        [XmlAttribute("xPosition")]
        public double XPosition { get; set; }

        [XmlAttribute("yPosition")]
        public double YPosition { get; set; }

        [XmlAttribute("reverseDirection")]
        public AtemBool ReverseDirection { get; set; }

        [XmlAttribute("flipFlip")]
        public AtemBool FlipFlip { get; set; }

        [XmlAttribute("borderInput")]
        public VideoSource BorderInput { get; set; }

        [XmlAttribute("borderWidth")]
        public int BorderWidth { get; set; }

        [XmlAttribute("borderSoftness")]
        public int BorderSoftness { get; set; }
    }
}
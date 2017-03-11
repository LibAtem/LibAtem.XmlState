using System.Xml.Serialization;

namespace AtemEmulator.State.MixEffects.TransitionStyle
{
    public class DveTransitionParameters
    {
        public enum DVEEffect
        {
            // TODO 
            PushRight
        }

        [XmlAttribute("rate")]
        public int Rate { get; set; }

        [XmlAttribute("logoRate")]
        public int LogoRate { get; set; }
        
        [XmlAttribute("reverseDirection")]
        public AtemBool ReverseDirection { get; set; }

        [XmlAttribute("flipFlip")]
        public AtemBool FlipFlip { get; set; }

        [XmlAttribute("effect")]
        public DVEEffect Effect { get; set; }

        [XmlAttribute("fillSource")]
        public VideoSource FillSource { get; set; }

        [XmlAttribute("keySource")]
        public VideoSource KeySource { get; set; }

        [XmlAttribute("enableKey")]
        public AtemBool EnableKey { get; set; }

        [XmlAttribute("preMultipliedKey")]
        public AtemBool PreMultipliedKey { get; set; }

        [XmlAttribute("clip")]
        public int Clip { get; set; }

        [XmlAttribute("gain")]
        public int Gain { get; set; }

        [XmlAttribute("invertKey")]
        public AtemBool InvertKey { get; set; }
    }
}
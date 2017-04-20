using System.Xml.Serialization;

namespace AtemEmulator.State.MixEffects.Key
{
    public class MixEffectsKey
    {
        public enum KeyType
        {
            Luma = 0,
            Chroma = 1,
            Pattern = 2,
            DVE = 3
        }

        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("type")]
        public KeyType Type { get; set; }

        [XmlAttribute("inputCut")]
        public VideoSource InputCut { get; set; }
        [XmlAttribute("inputFill")]
        public VideoSource InputFill { get; set; }

        [XmlAttribute("onAir")]
        public AtemBool OnAir { get; set; }

        [XmlAttribute("masked")]
        public AtemBool Masked { get; set; }

        [XmlAttribute("maskTop")]
        public double MaskTop { get; set; }
        [XmlAttribute("maskBottom")]
        public double MaskBottom { get; set; }
        [XmlAttribute("maskLeft")]
        public double MaskLeft { get; set; }
        [XmlAttribute("maskRight")]
        public double MaskRight { get; set; }

        public LumaKeyParameters LumaParameters { get; set; }
        public ChromaKeyParameters ChromaParameters { get; set; }
        public PatternKeyParameters PatternParameters { get; set; }
        public DveKeyParameters DVEParameters { get; set; }
        public FlyKeyParameters FlyParameters { get; set; }
    }
}

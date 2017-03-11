using System.Xml.Serialization;

namespace AtemEmulator.State.MixEffects.TransitionStyle
{
    public class StingerTransitionParameters
    {
        [XmlAttribute("source")]
        public string Source { get; set; } // TODO

        [XmlAttribute("preMultipliedKey")]
        public AtemBool PreMultipliedKey { get; set; }

        [XmlAttribute("clip")]
        public int Clip { get; set; }

        [XmlAttribute("gain")]
        public int Gain { get; set; }

        [XmlAttribute("invert")]
        public AtemBool Invert { get; set; }

        [XmlAttribute("clipDuration")]
        public int ClipDuration { get; set; }

        [XmlAttribute("triggerPoint")]
        public int TriggerPoint { get; set; }

        [XmlAttribute("mixRate")]
        public int MixRate { get; set; }

        [XmlAttribute("preroll")]
        public int Preroll { get; set; }
    }
}
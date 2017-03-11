using System.Xml.Serialization;

namespace AtemEmulator.State.MixEffects.TransitionStyle
{
    public class DipTransitionParameters
    {
        [XmlAttribute("rate")]
        public int Rate { get; set; }

        [XmlAttribute("input")]
        public VideoSource Input { get; set; }
    }
}
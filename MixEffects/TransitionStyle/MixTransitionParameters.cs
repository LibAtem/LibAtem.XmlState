using System.Xml.Serialization;

namespace AtemEmulator.State.MixEffects.TransitionStyle
{
    public class MixTransitionParameters
    {
        [XmlAttribute("rate")]
        public int Rate { get; set; }
    }
}
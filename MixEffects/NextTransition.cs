using System.Xml.Serialization;

namespace AtemEmulator.State.MixEffects
{
    public class NextTransition
    {
        public enum Transition
        {
            Background,
            Key1,
            Key2,
            Key3,
            Key4
        }

        [XmlAttribute("selection")]
        public Transition Selection { get; set; }

        [XmlAttribute("nextSelection")]
        public Transition NextSelection { get; set; }
    }

}
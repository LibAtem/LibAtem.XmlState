using System;
using System.Xml.Serialization;

namespace AtemEmulator.State.MixEffects
{
    public class NextTransition
    {
        [Flags]
        public enum Transition
        {
            None = 0,
            Background = 1 << 1,
            Key1 = 1 << 2,
            Key2 = 1 << 3,
            Key3 = 1 << 4,
            Key4 = 1 << 5,
        }

        [XmlAttribute("selection")]
        public Transition Selection { get; set; }

        [XmlAttribute("nextSelection")]
        public Transition NextSelection { get; set; }
    }

}
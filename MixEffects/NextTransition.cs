using System;
using System.Xml.Serialization;

namespace AtemEmulator.State.MixEffects
{
    public class NextTransition
    {
        [Flags]
        public enum Transition
        {
            Background = 1 << 0,
            Key1 = 1 << 1,
            Key2 = 1 << 2,
            Key3 = 1 << 3,
            Key4 = 1 << 4,
        }

        [XmlAttribute("selection")]
        public Transition Selection { get; set; }

        [XmlAttribute("nextSelection")]
        public Transition NextSelection { get; set; }
    }

}
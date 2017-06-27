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
            Background = 1 << 0,
            Key1 = 1 << 1,
            Key2 = 1 << 2,
            Key3 = 1 << 3,
            Key4 = 1 << 4,
        }

        public NextTransition()
        {
            Selection = Transition.Background;
            NextSelection = Transition.Background;
        }

        [XmlIgnore]
        public Transition Selection { get; set; }

        [XmlAttribute("selection")]
        public string SelectionString
        {
            get => Selection.ToString();
            set => Selection = (Transition) Enum.Parse(typeof(Transition), value);
        }

        [XmlIgnore]
        public Transition NextSelection { get; set; }

        [XmlAttribute("nextSelection")]
        public string NextSelectionString
        {
            get => NextSelection.ToString();
            set => NextSelection = (Transition)Enum.Parse(typeof(Transition), value);
        }
    }

}
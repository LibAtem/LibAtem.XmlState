using System.Xml.Serialization;

namespace AtemEmulator.State.MixEffects.TransitionStyle
{
    public class TransitionStyle
    {
        public enum TStyle
        {
            Mix,
            Dip,
            Wipe,
            DVE,
            Stinger
        }

        [XmlAttribute("style")]
        public TStyle Style { get; set; }

        [XmlAttribute("nextStyle")]
        public TStyle NextStyle { get; set; }

        [XmlAttribute("previewTransition")]
        public AtemBool PreviewTransition { get; set; }

        [XmlAttribute("transitionPosition")]
        public int TransitionPosition { get; set; }

        public MixTransitionParameters MixParameters { get; set; }
        public DipTransitionParameters DipParameters { get; set; }
        public WipeTransitionParameters WipeParameters { get; set; }
        public StingerTransitionParameters StingerParameters { get; set; }
        public DveTransitionParameters DVEParameters { get; set; }
    }
}
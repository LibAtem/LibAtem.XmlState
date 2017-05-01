using System.Collections.Generic;
using System.Xml.Serialization;
using AtemEmulator.State.MixEffects.Key;

namespace AtemEmulator.State.MixEffects
{
    public class MixEffectBlock
    {
        public MixEffectBlock()
        {
        }

        public MixEffectBlock(MixEffectBlockId id)
        {
            Index = id;
        }

        public class ProgamPreview
        {
            [XmlAttribute("input")]
            public VideoSource Input { get; set; }
        }

        [XmlAttribute("index")]
        public MixEffectBlockId Index { get; set; }

        public ProgamPreview Program { get; set; }
        public ProgamPreview Preview { get; set; }

        public NextTransition NextTransition { get; set; }

        public TransitionStyle.TransitionStyle TransitionStyle { get; set; }

        [XmlArrayItem("Key")]
        public List<MixEffectsKey> Keys { get; set; }

        public FadeToBlack FadeToBlack { get; set; }
    }

    public class FadeToBlack
    {
        [XmlAttribute("rate")]
        public uint Rate { get; set; }

        [XmlAttribute("isFullyBlack")]
        public AtemBool IsFullyBlack { get; set; }
    }

}
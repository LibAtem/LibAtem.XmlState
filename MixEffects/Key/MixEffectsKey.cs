﻿using System.Xml.Serialization;

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

        public MixEffectsKey() : this(0)
        {
        }

        public MixEffectsKey(int index)
        {
            Index = index;
            Mode = KeyType.Luma;

            FillSource = VideoSource.Black;
            CutSource = VideoSource.Black;

            OnAir = AtemBool.False;
            MaskEnabled = AtemBool.False;

            LumaParameters = new LumaKeyParameters();
            ChromaParameters = new ChromaKeyParameters();
            PatternParameters = new PatternKeyParameters();
            DVEParameters = new DveKeyParameters();
            FlyParameters = new FlyKeyParameters();
        }

        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("type")]
        public KeyType Mode { get; set; }

        [XmlAttribute("inputFill")]
        public VideoSource FillSource { get; set; }
        [XmlAttribute("inputCut")]
        public VideoSource CutSource { get; set; }

        [XmlAttribute("onAir")]
        public AtemBool OnAir { get; set; }

        [XmlAttribute("masked")]
        public AtemBool MaskEnabled { get; set; }

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

using System.Collections.Generic;
using System.Xml.Serialization;

namespace AtemEmulator.State
{
    public class Macro
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }

        [XmlElement("Op")]
        public List<MacroOperation> Operations { get; set; }
    }

    public enum MacroOperationType
    {
        MediaPlayerSourceStillIndex,
        MediaPlayerSourceStill,
        MediaPlayerSourceClipIndex,
        MediaPlayerSourceClip,
        MediaPlayerPlay,

        MacroSleep,
        CutTransition,

        SuperSourceArtFillInput,
        SuperSourceBoxEnable,

        AuxiliaryInput,
        ProgramInput,

        AudioMixerInputGain,
    }

    public class MacroOperation
    {
        [XmlAttribute("id")]
        public MacroOperationType Id { get; set; }

        [XmlAttribute("mediaPlayer")]
        public MediaPlayerId MediaPlayer { get; set; }
        public bool ShouldSerializeMediaPlayer()
        {
            switch (Id)
            {
                case MacroOperationType.MediaPlayerSourceStillIndex:
                case MacroOperationType.MediaPlayerSourceStill:
                case MacroOperationType.MediaPlayerSourceClipIndex:
                case MacroOperationType.MediaPlayerSourceClip:
                case MacroOperationType.MediaPlayerPlay:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("index")]
        public int Index { get; set; }
        public bool ShouldSerializeIndex()
        {
            switch (Id)
            {
                case MacroOperationType.MediaPlayerSourceStillIndex:
                case MacroOperationType.MediaPlayerSourceClipIndex:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("frames")]
        public int Frames { get; set; }
        public bool ShouldSerializeFrames()
        {
            switch (Id)
            {
                case MacroOperationType.MacroSleep:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("mixEffectBlockIndex")]
        public MixEffectBlockId MixEffectBlockIndex { get; set; }
        public bool ShouldSerializeMixEffectBlockIndex()
        {
            switch (Id)
            {
                case MacroOperationType.CutTransition:
                case MacroOperationType.ProgramInput:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("input")]
        public MacroInput Input { get; set; }
        public bool ShouldSerializeInput()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceArtFillInput:
                case MacroOperationType.AuxiliaryInput:
                case MacroOperationType.ProgramInput:
                case MacroOperationType.AudioMixerInputGain:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("auxiliaryIndex")]
        public uint AuxiliaryIndex { get; set; }
        public bool ShouldSerializeAuxiliaryIndex()
        {
            switch (Id)
            {
                case MacroOperationType.AuxiliaryInput:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("boxIndex")]
        public int BoxIndex { get; set; }
        public bool ShouldSerializeBoxIndex()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxEnable:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("enable")]
        public AtemBool Enable { get; set; }
        public bool ShouldSerializeEnable()
        {
            switch (Id)
            {
                case MacroOperationType.SuperSourceBoxEnable:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("gain")]
        public int Gain { get; set; }
        public bool ShouldSerializeGain()
        {
            switch (Id)
            {
                case MacroOperationType.AudioMixerInputGain:
                    return true;
                default:
                    return false;
            }
        }
    }

    public enum MacroInput
    {
        Camera1 = 1,
        Camera2 = 2,
        Camera3 = 3,
        Camera4 = 4,
        Camera5 = 5,
        Camera6 = 6,
        Camera7 = 7,
        Camera8 = 8,
        Camera9 = 9,
        Camera10 = 10,
        Camera11 = 11,
        Camera12 = 12,
        Camera13 = 13,
        Camera14 = 14,
        Camera15 = 15,
        Camera16 = 16,
        Camera17 = 17,
        Camera18 = 18,
        Camera19 = 19,
        Camera20 = 20,

        Color1 = 2001,

        MediaPlayer1 = 3010,

        ME1Program = 10010,

        ExternalXLR = 20000,
    }

    public class MacroControl
    {
        [XmlAttribute("loop")]
        public AtemBool Loop { get; set; }
    }
}
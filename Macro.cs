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
        MediaPlayerSourceClipIndex,
        MediaPlayerSourceClip,
        MediaPlayerPlay,
        MacroSleep,
        CutTransition,
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
                    return true;
                default:
                    return false;
            }
        }

    }
}
﻿using System.Xml.Serialization;

namespace AtemEmulator.State.Media
{
    public enum MediaPlayerSource
    {
        Still,
        Clip
    }

    public class MediaPlayer
    {
        [XmlAttribute("index")]
        public MediaPlayerId Index { get; set; }

        [XmlAttribute("sourceType")]
        public MediaPlayerSource SourceType { get; set; }

        [XmlAttribute("sourceIndex")]
        public int SourceIndex { get; set; }

        [XmlAttribute("playing")]
        public AtemBool Playing { get; set; }
        public bool ShouldSerializePlaying()
        {
            return SourceType == MediaPlayerSource.Clip;
        }

        [XmlAttribute("loop")]
        public AtemBool Loop { get; set; }
        public bool ShouldSerializeLoop()
        {
            return SourceType == MediaPlayerSource.Clip;
        }

        [XmlAttribute("atBeginning")]
        public AtemBool AtBeginning { get; set; }
        public bool ShouldSerializeAtBeginning()
        {
            return SourceType == MediaPlayerSource.Clip;
        }

        [XmlAttribute("clipFrame")]
        public int ClipFrame { get; set; }
        public bool ShouldSerializeClipFrame()
        {
            return SourceType == MediaPlayerSource.Clip;
        }
    }
}
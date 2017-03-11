using System.Collections.Generic;
using System.Xml.Serialization;

namespace AtemEmulator.State.Settings
{
    public class MediaPoolSettings
    {
        [XmlArrayItem("Clip")]
        public List<MediaPoolClipSettings> Clips { get; set; }
    }

    public class MediaPoolClipSettings
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("maxFrameCount")]
        public int MaxFrameCount { get; set; }
    }
}
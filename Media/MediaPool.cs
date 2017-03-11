using System.Collections.Generic;
using System.Xml.Serialization;

namespace AtemEmulator.State.Media
{
    public class MediaPool
    {
        [XmlArrayItem("Still")]
        public List<MediaPoolStill> Stills { get; set; }

        [XmlArrayItem("Clip")]
        public List<MediaPoolClip> Clips { get; set; }
    }

    public class MediaPoolStill
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("path")]
        public string Path { get; set; }
    }

    public class MediaPoolClip
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("Frame")]
        public List<MediaPoolFrame> Frames { get; set; }

        public MediaPoolAudio Audio { get; set; }
    }

    public class MediaPoolFrame
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("path")]
        public string Path { get; set; }
    }

    public class MediaPoolAudio
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("path")]
        public string Path { get; set; }
    }
    
}
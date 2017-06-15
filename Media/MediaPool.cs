﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using AtemEmulator.Util;

namespace AtemEmulator.State.Media
{
    public class MediaPool
    {
        public MediaPool()
        {
            Stills = new List<MediaPoolStill>();
            Clips = new List<MediaPoolClip>();
        }

        public MediaPool(uint stillCount, uint clipCount)
        {
            Stills = Collections.Repeat(i => new MediaPoolStill(i), stillCount).ToList();
            Clips = Collections.Repeat(i => new MediaPoolClip(i), clipCount).ToList();
        }

        [XmlArrayItem("Still")]
        public List<MediaPoolStill> Stills { get; set; }
        public bool ShouldSerializeStills()
        {
            return Stills != null && Stills.Count > 0;
        }
        
        [XmlArrayItem("Clip")]
        public List<MediaPoolClip> Clips { get; set; }
        public bool ShouldSerializeClips()
        {
            return Clips != null && Clips.Count > 0;
        }
    }

    public class MediaPoolStill
    {
        public MediaPoolStill()
        {    
        }

        public MediaPoolStill(int index)
        {
            Index = index;
        }

        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("path")]
        public string Path { get; set; }
    }

    public class MediaPoolClip
    {
        public MediaPoolClip()
        {
        }

        public MediaPoolClip(int index)
        {
            Index = index;
        }

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
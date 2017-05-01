using System;
using System.Xml.Serialization;

namespace AtemEmulator.State.Settings
{
    public enum VideoMode
    {
        [VideoModeRate(59.94)]
        [XmlEnum("525i5994 NTSC")]
        N525i5994NTSC = 0,
        [VideoModeRate(50)]
        [XmlEnum("625i50 PAL")]
        P625i50PAL = 1,
        [VideoModeRate(59.94)]
        [XmlEnum("525i5994 16:9")]
        N525i5994169 = 2,
        [VideoModeRate(50)]
        [XmlEnum("625i50 16:9")]
        P625i50169 = 3,

        [VideoModeRate(50)]
        [XmlEnum("720p50")]
        P720p50 = 4,
        [VideoModeRate(59.94)]
        [XmlEnum("720p5994")]
        N720p5994 = 5,
        [VideoModeRate(50)]
        [XmlEnum("1080i50")]
        P1080i50 = 6,
        [VideoModeRate(59.94)]
        [XmlEnum("1080i5994")]
        N1080i5994 = 7,
        [VideoModeRate(23.98)]
        [XmlEnum("1080p2398")]
        N1080p2398 = 8,
        [VideoModeRate(24)]
        [XmlEnum("1080p24")]
        N1080p24 = 9,
        [VideoModeRate(25)]
        [XmlEnum("1080p25")]
        P1080p25 = 10,
        [VideoModeRate(29.97)]
        [XmlEnum("1080p2997")]
        N1080p2997 = 11,

        [VideoModeRate(50)]
        [XmlEnum("1080p50")]
        P1080p50 = 12,
        [VideoModeRate(59.94)]
        [XmlEnum("1080p5994")]
        N1080p5994 = 13,

        [VideoModeRate(23.98)]
        [XmlEnum("4KHDp2398")]
        N4KHDp2398 = 14,
        [VideoModeRate(24)]
        [XmlEnum("4KHDp24")]
        N4KHDp24 = 15,
        [VideoModeRate(25)]
        [XmlEnum("4KHDp25")]
        P4KHDp25 = 16,
        [VideoModeRate(29.97)]
        [XmlEnum("4KHDp2997")]
        N4KHDp2997 = 17,

    }

    public class VideoModeRateAttribute : Attribute
    {
        public double Rate { get; }

        public VideoModeRateAttribute(double rate)
        {
            Rate = rate;
        }
    }
}
using System.Xml.Serialization;

namespace AtemEmulator.State.Settings
{
    public enum VideoMode
    {
        [XmlEnum("525i5994 NTSC")]
        N525i5994NTSC = 0,
        [XmlEnum("625i50 PAL")]
        P625i50PAL = 1,
        [XmlEnum("525i5994 16:9")]
        N525i5994169 = 2,
        [XmlEnum("625i50 16:9")]
        P625i50169 = 3,

        [XmlEnum("720p50")]
        P720p50 = 4,
        [XmlEnum("720p5994")]
        N720p5994 = 5,
        [XmlEnum("1080i50")]
        P1080i50 = 6,
        [XmlEnum("1080i5994")]
        N1080i5994 = 7,
        [XmlEnum("1080p2398")]
        N1080p2398 = 8,
        [XmlEnum("1080p24")]
        N1080p24 = 9,
        [XmlEnum("1080p25")]
        P1080p25 = 10,
        [XmlEnum("1080p2997")]
        N1080p2997 = 11,

        [XmlEnum("1080p50")]
        P1080p50 = 12,
        [XmlEnum("1080p5994")]
        N1080p5994 = 13,

        [XmlEnum("4KHDp2398")]
        N4KHDp2398 = 14,
        [XmlEnum("4KHDp24")]
        N4KHDp24 = 15,
        [XmlEnum("4KHDp25")]
        P4KHDp25 = 16,
        [XmlEnum("4KHDp2997")]
        N4KHDp2997 = 17,

    }
}
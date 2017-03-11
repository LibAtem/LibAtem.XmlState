using System.Xml.Serialization;

namespace AtemEmulator.State.Settings
{
    public enum VideoMode
    {
        [XmlEnum("525i5994 NTSC")]
        N525i5994NTSC,
        [XmlEnum("625i50 PAL")]
        P625i50PAL,
        [XmlEnum("525i5994 16:9")]
        N525i5994169,
        [XmlEnum("625i50 16:9")]
        P625i50169,

        [XmlEnum("720p50")]
        P720p50,
        [XmlEnum("720p5994")]
        N720p5994,
        [XmlEnum("1080i50")]
        P1080i50,
        [XmlEnum("1080i5994")]
        N1080i5994,
        [XmlEnum("1080p2398")]
        N1080p2398,
        [XmlEnum("1080p24")]
        N1080p24,
        [XmlEnum("1080p25")]
        P1080p25,
        [XmlEnum("1080p2997")]
        N1080p2997,

        [XmlEnum("1080p50")]
        P1080p50,
        [XmlEnum("1080p5994")]
        N1080p5994,

        [XmlEnum("4KHDp2398")]
        N4KHDp2398,
        [XmlEnum("4KHDp24")]
        N4KHDp24,
        [XmlEnum("4KHDp25")]
        P4KHDp25,
        [XmlEnum("4KHDp2997")]
        N4KHDp2997,

    }
}
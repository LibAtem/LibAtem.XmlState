using System.Xml.Serialization;

namespace AtemEmulator.State
{
    public enum MixEffectBlockId
    {
        [XmlEnum("0")]
        One = 0,
        [XmlEnum("1")]
        Two = 1
    }

    public enum MediaPlayerId
    {
        [XmlEnum("0")]
        One = 0,
        [XmlEnum("1")]
        Two = 1
    }

    public enum DownstreamKeyId
    {
        [XmlEnum("0")]
        One = 0,
        [XmlEnum("1")]
        Two = 1
    }
}

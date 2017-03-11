using System.Xml.Serialization;

namespace AtemEmulator.State
{
    public enum AudioSource
    {
        [XmlEnum("1")]
        Input1 = 1,
        [XmlEnum("2")]
        Input2 = 2,
        [XmlEnum("3")]
        Input3 = 3,
        [XmlEnum("4")]
        Input4 = 4,
        [XmlEnum("5")]
        Input5 = 5,
        [XmlEnum("6")]
        Input6 = 6,
        [XmlEnum("7")]
        Input7 = 7,
        [XmlEnum("8")]
        Input8 = 8,
        [XmlEnum("9")]
        Input9 = 9,
        [XmlEnum("10")]
        Input10 = 10,
        [XmlEnum("11")]
        Input11 = 11,
        [XmlEnum("12")]
        Input12 = 12,
        [XmlEnum("13")]
        Input13 = 13,
        [XmlEnum("14")]
        Input14 = 14,
        [XmlEnum("15")]
        Input15 = 15,
        [XmlEnum("16")]
        Input16 = 16,
        [XmlEnum("17")]
        Input17 = 17,
        [XmlEnum("18")]
        Input18 = 18,
        [XmlEnum("19")]
        Input19 = 19,
        [XmlEnum("20")]
        Input20 = 20,

        [XmlEnum("1001")]
        XLR = 1001,
        [XmlEnum("1101")]
        AESEBU = 1101,
        [XmlEnum("1201")]
        RCA = 1201,

        [XmlEnum("2001")]
        MP1 = 2001,
        [XmlEnum("2002")]
        MP2 = 2002,
    }
}
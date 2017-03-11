using System.Xml.Serialization;

namespace AtemEmulator.State
{
    public enum VideoSource
    {
        [XmlEnum("0")]
        Black = 0,

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

        [XmlEnum("1000")]
        ColorBars = 1000,

        [XmlEnum("2001")]
        Color1 = 2001,
        [XmlEnum("2002")]
        Color2 = 2002,

        [XmlEnum("3010")]
        MediaPlayer1 = 3010,
        [XmlEnum("3011")]
        MediaPlayer1Key = 3011,
        [XmlEnum("3020")]
        MediaPlayer2 = 3020,
        [XmlEnum("3021")]
        MediaPlayer2Key = 3021,

        [XmlEnum("4010")]
        Key1Mask = 4010,
        [XmlEnum("4020")]
        Key2Mask = 4020,
        [XmlEnum("4030")]
        Key3Mask = 4030,
        [XmlEnum("4040")]
        Key4Mask = 4040,
        [XmlEnum("5010")]
        DSK1Mask = 5010,
        [XmlEnum("5020")]
        DSK2Mask = 5020,

        [XmlEnum("6000")]
        SuperSource = 6000,

        [XmlEnum("7001")]
        CleanFeed1 = 7001,
        [XmlEnum("7002")]
        CleanFeed2 = 7002,

        [XmlEnum("8001")]
        Auxilary1 = 8001,
        [XmlEnum("8002")]
        Auxilary2 = 8002,
        [XmlEnum("8003")]
        Auxilary3 = 8003,
        [XmlEnum("8004")]
        Auxilary4 = 8004,
        [XmlEnum("8005")]
        Auxilary5 = 8005,
        [XmlEnum("8006")]
        Auxilary6 = 8006,

        [XmlEnum("10010")]
        ME1Prog = 10010,
        [XmlEnum("10011")]
        ME1Prev = 10011,
        [XmlEnum("10020")]
        ME2Prog = 10020,
        [XmlEnum("10021")]
        ME2Prev = 10021,
    }
}

using System;
using System.Xml.Serialization;
using AtemEmulator.State.Settings;

namespace AtemEmulator.State
{
    public enum VideoSource
    {
        [VideoSource(InternalPortType.Black, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("0")]
        Black = 0,

        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("1")]
        Input1 = 1,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("2")]
        Input2 = 2,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("3")]
        Input3 = 3,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("4")]
        Input4 = 4,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("5")]
        Input5 = 5,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("6")]
        Input6 = 6,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("7")]
        Input7 = 7,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("8")]
        Input8 = 8,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("9")]
        Input9 = 9,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("10")]
        Input10 = 10,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("11")]
        Input11 = 11,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("12")]
        Input12 = 12,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("13")]
        Input13 = 13,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("14")]
        Input14 = 14,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("15")]
        Input15 = 15,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("16")]
        Input16 = 16,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("17")]
        Input17 = 17,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("18")]
        Input18 = 18,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("19")]
        Input19 = 19,
        [VideoSource(InternalPortType.External, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("20")]
        Input20 = 20,

        [VideoSource(InternalPortType.ColorBars, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("1000")]
        ColorBars = 1000,

        [VideoSource(InternalPortType.ColorGenerator, SourceAvailability.Auxilary | SourceAvailability.Multiviewer | SourceAvailability.SuperSourceBox | SourceAvailability.SuperSourceArt, MeAvailability.All)]
        [XmlEnum("2001")]
        Color1 = 2001,
        [VideoSource(InternalPortType.ColorGenerator, SourceAvailability.Auxilary | SourceAvailability.Multiviewer | SourceAvailability.SuperSourceBox | SourceAvailability.SuperSourceArt, MeAvailability.All)]
        [XmlEnum("2002")]
        Color2 = 2002,

        [VideoSource(InternalPortType.MediaPlayerFill, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("3010")]
        MediaPlayer1 = 3010,
        [VideoSource(InternalPortType.MediaPlayerKey, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("3011")]
        MediaPlayer1Key = 3011,
        [VideoSource(InternalPortType.MediaPlayerFill, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("3020")]
        MediaPlayer2 = 3020,
        [VideoSource(InternalPortType.MediaPlayerKey, SourceAvailability.All, MeAvailability.All)]
        [XmlEnum("3021")]
        MediaPlayer2Key = 3021,

        [VideoSource(InternalPortType.Mask, SourceAvailability.Auxilary | SourceAvailability.Multiviewer)]
        [XmlEnum("4010")]
        Key1Mask = 4010,
        [VideoSource(InternalPortType.Mask, SourceAvailability.Auxilary | SourceAvailability.Multiviewer)]
        [XmlEnum("4020")]
        Key2Mask = 4020,
        [VideoSource(InternalPortType.Mask, SourceAvailability.Auxilary | SourceAvailability.Multiviewer)]
        [XmlEnum("4030")]
        Key3Mask = 4030,
        [VideoSource(InternalPortType.Mask, SourceAvailability.Auxilary | SourceAvailability.Multiviewer)]
        [XmlEnum("4040")]
        Key4Mask = 4040,
        [VideoSource(InternalPortType.Mask, SourceAvailability.Auxilary | SourceAvailability.Multiviewer)]
        [XmlEnum("5010")]
        DSK1Mask = 5010,
        [VideoSource(InternalPortType.Mask, SourceAvailability.Auxilary | SourceAvailability.Multiviewer)]
        [XmlEnum("5020")]
        DSK2Mask = 5020,

        [VideoSource(InternalPortType.SuperSource, SourceAvailability.Auxilary | SourceAvailability.Multiviewer | SourceAvailability.KeySource, MeAvailability.All)]
        [XmlEnum("6000")]
        SuperSource = 6000,

        [VideoSource(InternalPortType.MEOutput, SourceAvailability.Auxilary | SourceAvailability.Multiviewer)]
        [XmlEnum("7001")]
        CleanFeed1 = 7001,
        [VideoSource(InternalPortType.MEOutput, SourceAvailability.Auxilary | SourceAvailability.Multiviewer)]
        [XmlEnum("7002")]
        CleanFeed2 = 7002,
        
        [VideoSource(InternalPortType.Auxilary, SourceAvailability.Multiviewer)]
        [XmlEnum("8001")]
        Auxilary1 = 8001,
        [VideoSource(InternalPortType.Auxilary, SourceAvailability.Multiviewer)]
        [XmlEnum("8002")]
        Auxilary2 = 8002,
        [VideoSource(InternalPortType.Auxilary, SourceAvailability.Multiviewer)]
        [XmlEnum("8003")]
        Auxilary3 = 8003,
        [VideoSource(InternalPortType.Auxilary, SourceAvailability.Multiviewer)]
        [XmlEnum("8004")]
        Auxilary4 = 8004,
        [VideoSource(InternalPortType.Auxilary, SourceAvailability.Multiviewer)]
        [XmlEnum("8005")]
        Auxilary5 = 8005,
        [VideoSource(InternalPortType.Auxilary, SourceAvailability.Multiviewer)]
        [XmlEnum("8006")]
        Auxilary6 = 8006,

        [VideoSource(InternalPortType.MEOutput, SourceAvailability.Auxilary | SourceAvailability.Multiviewer)]
        [XmlEnum("10010")]
        ME1Prog = 10010,
        [VideoSource(InternalPortType.MEOutput, SourceAvailability.Auxilary | SourceAvailability.Multiviewer)]
        [XmlEnum("10011")]
        ME1Prev = 10011,
        [VideoSource(InternalPortType.MEOutput, SourceAvailability.Auxilary | SourceAvailability.Multiviewer | SourceAvailability.SuperSourceBox, MeAvailability.Me1)]
        [XmlEnum("10020")]
        ME2Prog = 10020,
        [VideoSource(InternalPortType.MEOutput, SourceAvailability.Auxilary | SourceAvailability.Multiviewer | SourceAvailability.SuperSourceBox, MeAvailability.Me1)]
        [XmlEnum("10021")]
        ME2Prev = 10021,
    }

    public class VideoSourceAttribute : Attribute
    {
        public InternalPortType PortType { get; }
        public SourceAvailability SourceAvailability { get; }
        public MeAvailability MeAvailability { get; }

        public VideoSourceAttribute(InternalPortType portType, SourceAvailability sourceAvailability, MeAvailability me=MeAvailability.None)
        {
            PortType = portType;
            SourceAvailability = sourceAvailability;
            MeAvailability = me;
        }
    }

    [Flags]
    public enum MeAvailability
    {
        None = 0,
        Me1 = 1,
        Me2 = 2,
        All = Me1|Me2,
    }

    [Flags]
    public enum SourceAvailability
    {
        None = 1 << 0,
        Auxilary = 1 << 1,
        Multiviewer = 1 << 2,
        SuperSourceArt = 1 << 3,
        SuperSourceBox = 1 << 4,
        KeySource = 1 << 5,
        All = Auxilary|Multiviewer|SuperSourceArt|SuperSourceBox|KeySource,
    }
}

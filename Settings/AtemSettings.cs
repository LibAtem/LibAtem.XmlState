using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace AtemEmulator.State.Settings
{
    public class AtemSettings
    {
        [XmlAttribute("videoMode")]
        public VideoMode VideoMode { get; set; }

        [XmlAttribute("downConvertMode")]
        public DownConvertMode DownConvertMode { get; set; }

        [XmlAttribute("abDirect")]
        public AtemBool AbDirect { get; set; }

        [XmlAttribute("cameraAux")]
        public int CameraAux { get; set; }

        [XmlAttribute]
        public SDI3GOutputLevel SDI3GOutputLevel { get; set; }

        public List<MultiViewVideoMode> MultiViewVideoModes { get; set; }

        public List<DownConvertedHDVideoMode> DownConvertedHDVideoModes { get; set; }
        public bool ShouldSerializeDownConvertedHDVideoModes()
        {
            return DownConvertedHDVideoModes != null && DownConvertedHDVideoModes.Count > 0;
        }

        public List<AudioMonitor> AudioMonitors { get; set; }

        public Talkback Talkback { get; set; }

        public List<Input> Inputs { get; set; }

        public MediaPoolSettings MediaPool { get; set; }

        public List<MultiView> MultiViews { get; set; }

        [XmlArrayItem("Button")]
        public List<ButtonMap> ButtonMapping { get; set; }

        public List<Remote> Remotes { get; set; }
        public bool ShouldSerializeRemotes()
        {
            return Remotes != null && Remotes.Count > 0;
        }

        public UpstreamKeys UpstreamKeys { get; set; }
    }

    public enum SDI3GOutputLevel
    {
        LevelA,
        LevelB,
    }

    public enum DownConvertMode
    {
        CentreCut = 0,
        Letterbox = 1,
        Anamorphic = 2,
    }

    public class MultiViewVideoMode
    {
        [XmlAttribute("coreVideoMode")]
        public VideoMode CoreVideoMode { get; set; }

        [XmlAttribute("multiViewVideoMode")]
        public VideoMode MultiViewMode { get; set; }
    }

    public class DownConvertedHDVideoMode
    {
        [XmlAttribute("coreVideoMode")]
        public VideoMode CoreVideoMode { get; set; }

        [XmlAttribute("downConvertedHDVideoMode")]
        public VideoMode DownConvertedMode { get; set; }
    }

    public class AudioMonitor
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("monitorEnabled")]
        public AtemBool MonitorEnabled { get; set; }
    }

    public class Input
    {
        [XmlAttribute("id")]
        public VideoSource Id { get; set; }

        [XmlAttribute("shortName")]
        public string ShortName { get; set; }

        [XmlAttribute("longName")]
        public string LongName { get; set; }

        [XmlAttribute("externalPortType")]
        public ExternalPortType PortType { get; set; }
    }

    public enum ExternalPortType
    {
        Internal = 0,
        SDI = 1,
        HDMI = 2,
        Composite = 3,
        Component = 4,
        SVideo = 5,
    }
    public enum InternalPortType
    {
        External = 0,
        Black = 1,
        ColorBars = 2,
        ColorGenerator = 3,
        MediaPlayerFill = 4,
        MediaPlayerKey = 5,
        SuperSource = 6,

        MEOutput = 128,
        Auxilary = 129,
        Mask = 130,
    }

    public enum AudioPortType
    {
        Internal = 0,
        SDI = 1,
        HDMI = 2,
        Component = 3,
        Composite = 4,
        SVideo = 5,
        XLR = 32,
        AESEBU = 64,
        RCA = 128,
    }

    public static class ExternalPortTypeExtensions
    {
        public static AudioPortType GetAudioPortType(this ExternalPortType type)
        {
            switch (type)
            {
                case ExternalPortType.Internal:
                    return AudioPortType.Internal;
                case ExternalPortType.SDI:
                    return AudioPortType.SDI;
                case ExternalPortType.HDMI:
                    return AudioPortType.HDMI;
                case ExternalPortType.Component:
                    return AudioPortType.Component;
                case ExternalPortType.Composite:
                    return AudioPortType.Composite;
                case ExternalPortType.SVideo:
                    return AudioPortType.SVideo;
                default:
                    Debug.Fail(string.Format("Unhandled ExternalPortType {0}", type));
                    return AudioPortType.Internal;
            }
        }   
    }

    public class ButtonMap
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("externalInputIndex")]
        public int Input { get; set; }

        [XmlAttribute("mappedToCamera")]
        public AtemBool MappedToCamera { get; set; }
    }

    public class Remote
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("function")]
        public RemoteFunction Function { get; set; }
    }

    public enum RemoteFunction
    {
        None,
  
        [XmlEnum("PTZ VISCA")]
        PTZVISCA,
        //TODO
    }

    public class Talkback
    {
        [XmlAttribute("sdiMuted")]
        public AtemBool SdiMuted { get; set; }
    }

    public class UpstreamKeys
    {
        [XmlAttribute("sizeLink")]
        public AtemBool SizeLink { get; set; }
    }
}
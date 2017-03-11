using System.Collections.Generic;
using System.Xml.Serialization;

namespace AtemEmulator.State.Settings
{
    public class AtemSettings
    {
        [XmlAttribute("videoMode")]
        public VideoMode VideoMode { get; set; }

        [XmlAttribute("abDirect")]
        public AtemBool AbDirect { get; set; }

        [XmlAttribute("cameraAux")]
        public int CameraAux { get; set; }

        public List<MultiViewVideoMode> MultiViewVideoModes { get; set; }

        public List<DownConvertedHDVideoMode> DownConvertedHDVideoModes { get; set; }

        public List<AudioMonitor> AudioMonitors { get; set; }

        public List<Input> Inputs { get; set; }

        public MediaPoolSettings MediaPool { get; set; }

        public List<MultiView> MultiViews { get; set; }

        [XmlArrayItem("Button")]
        public List<ButtonMap> ButtonMapping { get; set; }
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
        public int Id { get; set; }

        [XmlAttribute("shortName")]
        public string ShortName { get; set; }

        [XmlAttribute("longName")]
        public string LongName { get; set; }

        [XmlAttribute("externalPortType")]
        public PortType PortType { get; set; }
    }

    public enum PortType
    {
        SDI,
        HDMI,
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
}
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AtemEmulator.State.Settings
{
    public class MultiView
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("layout")]
        public MultiViewLayout Layout { get; set; }

        [XmlAttribute("vuMeterOpacity")]
        public double VuMeterOpacity { get; set; }

        [XmlAttribute("safeAreaEnabled")]
        public AtemBool SafeAreaEnabled { get; set; }

        [XmlAttribute("programPreviewSwapped")]
        public AtemBool ProgramPreviewSwapped { get; set; }

        [XmlArrayItem("Window")]
        public List<MultiViewWindow> Windows { get; set; }
    }

    public enum MultiViewLayout
    {
        ProgramTop,
        ProgramBottom,
        ProgramLeft,
        ProgramRight
    }

    public class MultiViewWindow
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("input")]
        public VideoSource Input { get; set; }

        [XmlAttribute("vuMeterEnabled")]
        public AtemBool VuMeterEnabled { get; set; }
    }
}
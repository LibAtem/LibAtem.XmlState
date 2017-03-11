using System.Collections.Generic;
using System.Xml.Serialization;

namespace AtemEmulator.State
{
    public class CameraControl
    {
        [XmlElement("Parameter")]
        public List<CameraControlParameter> Parameters { get; set; }

        [XmlElement("Property")]
        public List<CameraControlProperty> Properties { get; set; }
    }

    public class CameraControlProperty
    {
        [XmlAttribute("device")]
        public int Device { get; set; }

        [XmlAttribute("property")]
        public CameraControlPropertyProperty Property { get; set; }

        [XmlAttribute("value")]
        public string PrValueoperty { get; set; }
    }

    public enum CameraControlPropertyProperty
    {
        ApertureCoarse,
        Locked,
    }

    public class CameraControlParameter
    {
        [XmlAttribute("device")]
        public int Device { get; set; }

        [XmlAttribute("category")]
        public CameraControlParameterCategory Category { get; set; }
        [XmlAttribute("parameter")]
        public CameraControlParameterParameter Paremeter { get; set; }

        [XmlAttribute("value")]
        public double Value { get; set; }

        [XmlAttribute("red")]
        public double Red { get; set; }
        [XmlAttribute("green")]
        public double Green { get; set; }
        [XmlAttribute("blue")]
        public double Blue { get; set; }
        [XmlAttribute("luma")]
        public double Luma { get; set; }

        [XmlAttribute("pivot")]
        public double Pivot { get; set; }
        [XmlAttribute("adjust")]
        public double Adjust { get; set; }

        [XmlAttribute("hue")]
        public double Hue { get; set; }
        [XmlAttribute("saturation")]
        public double Saturation { get; set; }
    }

    /*<Parameter device = "1" category="Lens" parameter="ApertureNormalised" value="0.5"/>
        <Parameter device = "1" category="Video" parameter="SensorGain" value="2"/>
        <Parameter device = "1" category="Video" parameter="ManualWhiteBalance" value="5600"/>
        <Parameter device = "1" category="Video" parameter="Exposure" value="20000"/>
        <Parameter device = "1" category="Video" parameter="DetailLevel" value="1"/>
        <Parameter device = "1" category="ColorCorrection" parameter="LiftAdjust" red="0" green="0" blue="0" luma="0"/>
        <Parameter device = "1" category="ColorCorrection" parameter="GammaAdjust" red="0" green="0" blue="0" luma="0"/>
        <Parameter device = "1" category="ColorCorrection" parameter="GainAdjust" red="1" green="1" blue="1" luma="1"/>
        <Parameter device = "1" category="ColorCorrection" parameter="OffsetAdjust" red="0" green="0" blue="0" luma="0"/>
        <Parameter device = "1" category="ColorCorrection" parameter="ContrastAdjust" pivot="0.5" adjust="1"/>
        <Parameter device = "1" category="ColorCorrection" parameter="LumaMix" value="1"/>
        <Parameter device = "1" category="ColorCorrection" parameter="ColorAdjust" hue="0" saturation="1"/>*/

    public enum CameraControlParameterCategory
    {
        Lens,
        Video,
        ColorCorrection,
    }
    public enum CameraControlParameterParameter
    {
        ApertureNormalised,
        SensorGain,
        ManualWhiteBalance,
        Exposure,
        DetailLevel,
        LiftAdjust,
        GammaAdjust,
        GainAdjust,
        OffsetAdjust,
        ContrastAdjust,
        LumaMix,
        ColorAdjust,
    }
}
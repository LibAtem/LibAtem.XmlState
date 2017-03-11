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
        public CameraControlParameterParameter Parameter { get; set; }

        [XmlAttribute("value")]
        public double Value { get; set; }
        public bool ShouldSerializeValue()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.ApertureNormalised:
                case CameraControlParameterParameter.SensorGain:
                case CameraControlParameterParameter.ManualWhiteBalance:
                case CameraControlParameterParameter.Exposure:
                case CameraControlParameterParameter.DetailLevel:
                case CameraControlParameterParameter.LumaMix:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("red")]
        public double Red { get; set; }
        public bool ShouldSerializeRed()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.LiftAdjust:
                case CameraControlParameterParameter.GammaAdjust:
                case CameraControlParameterParameter.GainAdjust:
                case CameraControlParameterParameter.OffsetAdjust:
                    return true;
                default:
                    return false;
            }
        }
        [XmlAttribute("green")]
        public double Green { get; set; }
        public bool ShouldSerializeGreen()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.LiftAdjust:
                case CameraControlParameterParameter.GammaAdjust:
                case CameraControlParameterParameter.GainAdjust:
                case CameraControlParameterParameter.OffsetAdjust:
                    return true;
                default:
                    return false;
            }
        }
        [XmlAttribute("blue")]
        public double Blue { get; set; }
        public bool ShouldSerializeBlue()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.LiftAdjust:
                case CameraControlParameterParameter.GammaAdjust:
                case CameraControlParameterParameter.GainAdjust:
                case CameraControlParameterParameter.OffsetAdjust:
                    return true;
                default:
                    return false;
            }
        }
        [XmlAttribute("luma")]
        public double Luma { get; set; }
        public bool ShouldSerializeLuma()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.LiftAdjust:
                case CameraControlParameterParameter.GammaAdjust:
                case CameraControlParameterParameter.GainAdjust:
                case CameraControlParameterParameter.OffsetAdjust:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("pivot")]
        public double Pivot { get; set; }
        public bool ShouldSerializePivot()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.ContrastAdjust:
                    return true;
                default:
                    return false;
            }
        }
        [XmlAttribute("adjust")]
        public double Adjust { get; set; }
        public bool ShouldSerializeAdjust()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.ContrastAdjust:
                    return true;
                default:
                    return false;
            }
        }

        [XmlAttribute("hue")]
        public double Hue { get; set; }
        public bool ShouldSerializeHue()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.ColorAdjust:
                    return true;
                default:
                    return false;
            }
        }
        [XmlAttribute("saturation")]
        public double Saturation { get; set; }
        public bool ShouldSerializeSaturation()
        {
            switch (Parameter)
            {
                case CameraControlParameterParameter.ColorAdjust:
                    return true;
                default:
                    return false;
            }
        }
    }

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
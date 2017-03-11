using System.Xml.Serialization;

namespace AtemEmulator.State.MixEffects.Key
{
    public class DveKeyParameters
    {
        [XmlAttribute("maskEnabled")]
        public AtemBool MaskEnabled { get; set; }

        [XmlAttribute("maskTop")]
        public double MaskTop { get; set; }
        [XmlAttribute("maskBottom")]
        public double MaskBottom { get; set; }
        [XmlAttribute("maskLeft")]
        public double MaskLeft { get; set; }
        [XmlAttribute("maskRight")]
        public double MaskRight { get; set; }

        [XmlAttribute("shadowEnabled")]
        public AtemBool ShadowEnabled { get; set; }

        [XmlAttribute("lightSourceDirection")]
        public int LightSourceDirection { get; set; }
        [XmlAttribute("lightSourceAltitude")]
        public int LightSourceAltitude { get; set; }

        [XmlAttribute("borderEnabled")]
        public AtemBool BorderEnabled { get; set; }
        [XmlAttribute("borderStyle")]
        public BorderStyle BorderStyle { get; set; }
        [XmlAttribute("borderBevelHue")]
        public int BorderBevelHue { get; set; }
        [XmlAttribute("borderBevelSaturation")]
        public int BorderBevelSaturation { get; set; }
        [XmlAttribute("borderBevelLuma")]
        public int BorderBevelLuma { get; set; }

        [XmlAttribute("borderWidthOut")]
        public double BorderWidthOut { get; set; }
        [XmlAttribute("borderWidthIn")]
        public double BorderWidthIn { get; set; }
        [XmlAttribute("borderSoftnessOut")]
        public double BorderSoftnessOut { get; set; }
        [XmlAttribute("borderSoftnessIn")]
        public double BorderSoftnessIn { get; set; }
        [XmlAttribute("borderBevelOpacity")]
        public double BorderBevelOpacity { get; set; }
        [XmlAttribute("borderBevelPosition")]
        public double BorderBevelPosition { get; set; }
        [XmlAttribute("borderBevelSoftness")]
        public double BorderBevelSoftness { get; set; }
    }
}
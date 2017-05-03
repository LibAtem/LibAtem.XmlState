using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace AtemEmulator.State
{
    public class AudioMixer
    {
        [XmlAttribute("programOutGain")]
        public string ProgramOutGainXmlString
        {
            get => double.IsNegativeInfinity(ProgramOutGain) ? "-inf" : ProgramOutGain.ToString(CultureInfo.InvariantCulture);
            set => ProgramOutGain = value == "-inf" ? double.NegativeInfinity : double.Parse(value);
        }

        [XmlIgnore]
        public double ProgramOutGain { get; set; }

        [XmlAttribute("programOutBalance")]
        public double ProgramOutBalance { get; set; }

        [XmlAttribute("programOutFollowFadeToBlack")]
        public AtemBool ProgramOutFollowFadeToBlack { get; set; }

        public List<AudioInput> AudioInputs { get; set; }

        public List<AudioMonitorOutput> AudioMonitorOutputs { get; set; }
    }

    public class AudioInput
    {
        [XmlAttribute("id")]
        public AudioSource Id { get; set; }

        [XmlAttribute("mixOption")]
        public MixOption MixOption { get; set; }

        [XmlAttribute("gain")]
        public string GainXmlString
        {
            get => double.IsNegativeInfinity(Gain) ? "-inf" : Gain.ToString(CultureInfo.InvariantCulture);
            set => Gain = value == "-inf" ? double.NegativeInfinity : double.Parse(value);
        }

        [XmlIgnore]
        public double Gain { get; set; }

        [XmlAttribute("balance")]
        public double Balance { get; set; }
    }
    
    public enum MixOption
    {
        Off = 0,
        On = 1,
        AudioFollowVideo = 2
    }

    public class AudioMonitorOutput
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("gain")]
        public double Gain { get; set; }

        [XmlAttribute("mute")]
        public AtemBool Mute { get; set; }

        [XmlAttribute("solo")]
        public AtemBool Solo { get; set; }

        [XmlAttribute("soloInput")]
        public AudioSource SoloInput { get; set; }

        [XmlAttribute("dim")]
        public AtemBool Dim { get; set; }

        [XmlAttribute("dimLevel")]
        public double DimLevel { get; set; }
    }
}
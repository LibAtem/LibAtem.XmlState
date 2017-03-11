using System.Collections.Generic;
using System.Xml.Serialization;

namespace AtemEmulator.State
{
    public class AudioMixer
    {
        [XmlAttribute("programOutGain")]
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
        public double Gain { get; set; }

        [XmlAttribute("balance")]
        public double Balance { get; set; }
    }

    public enum MixOption
    {
        Off,
        On,
        AudioFollowVideo
    }

    public class AudioMonitorOutput
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

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
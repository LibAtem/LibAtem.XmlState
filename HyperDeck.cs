using System.Xml.Serialization;

namespace AtemEmulator.State
{
    public class HyperDeck
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("networkAddress")]
        public string NetworkAddress { get; set; }

        [XmlAttribute("input")]
        public VideoSource Input { get; set; }

        [XmlAttribute("autoRoll")]
        public AtemBool AutoRoll { get; set; }

        [XmlAttribute("autoRollFrameDelay")]
        public int AutoRollFrameDelay { get; set; }
    }
}
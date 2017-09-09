namespace LibAtem.XmlState.MacroSpec
{
    public class TypeMappings
    {
        public static string MapType(string type)
        {
            switch (type)
            {
                case "LibAtem.Common.VideoSource":
                    return "LibAtem.XmlState.MacroInput";
                case "LibAtem.Common.AudioSource":
                    return "LibAtem.XmlState.MacroInput";
                case "System.Boolean":
                    return "LibAtem.XmlState.AtemBool";
                case "LibAtem.Common.DownstreamKeyId":
                    return "System.UInt32";
                default:
                    return type;
            }
        }

    }
}
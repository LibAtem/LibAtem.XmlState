using System;

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

        public static Tuple<string, bool> MapTypeFull(Type type)
        {
            switch (type.FullName)
            {
                case "LibAtem.Common.VideoSource":
                    return Tuple.Create("LibAtem.XmlState.MacroInput", true);
                case "LibAtem.Common.AudioSource":
                    return Tuple.Create("LibAtem.XmlState.MacroInput", true);
                case "System.Boolean":
                    return Tuple.Create("LibAtem.XmlState.AtemBool", true);
                case "LibAtem.Common.DownstreamKeyId":
                    return Tuple.Create("System.UInt32", false);
                default:
                    return Tuple.Create(type.FullName, type.IsEnum);
            }
        }

    }
}
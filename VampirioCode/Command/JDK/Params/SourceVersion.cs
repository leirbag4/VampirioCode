using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.JDK.Params
{
    public class SourceVersionInfo
    {
        public static string Get(SourceVersion sourceVersion)
        {
            switch (sourceVersion)
            {
                case SourceVersion.None:    return "";
                case SourceVersion.Ver_1_3: return "1.3";
                case SourceVersion.Ver_1_4: return "1.4";
                case SourceVersion.Ver_1_5: return "1.5";
                case SourceVersion.Ver_5:   return "5";
                case SourceVersion.Ver_1_6: return "1.6";
                case SourceVersion.Ver_6:   return "6";
                case SourceVersion.Ver_1_7: return "1.7";
                case SourceVersion.Ver_7:   return "7";
                case SourceVersion.Ver_1_8: return "1.8";
                case SourceVersion.Ver_8:   return "8";
                default: return "";
            }
        }
    }

    public enum SourceVersion
    {
        None,
        Ver_1_3,
        Ver_1_4,
        Ver_1_5,
        Ver_5,
        Ver_1_6,
        Ver_6,
        Ver_1_7,
        Ver_7,
        Ver_1_8,
        Ver_8
    }
}

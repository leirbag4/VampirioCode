using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.Dotnet.Params
{
    public class LanguageInfo
    {
        public Language Language { get; set; }
        public string Name { get; set; }
        public string Param { get; set; }

        public static LanguageInfo Get(Language language)
        { 
            LanguageInfo lang = new LanguageInfo();

            switch (language)
            {
                case Language.None:         return new LanguageInfo() { Language = Language.None,           Name = "",              Param = ""};
                case Language.CSharp:       return new LanguageInfo() { Language = Language.CSharp,         Name = "CSharp",        Param = "C#"};
                case Language.FSharp:       return new LanguageInfo() { Language = Language.FSharp,         Name = "FSharp",        Param = "F#"};
                case Language.VisualBasic:  return new LanguageInfo() { Language = Language.VisualBasic,    Name = "VisualBasic",   Param = "VB"};
                default:                    return null;
            }
        }

    }
}

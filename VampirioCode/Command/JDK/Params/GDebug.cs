using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.JDK.Params
{
    public class GDebugInfo
    {
        public static string Get(GDebug g)
        {
            switch (g)
            {
                case GDebug.DoNotUse:           return "";
                case GDebug.All:                return "-g";
                case GDebug.None:               return "-g:none";
                case GDebug.Source:             return "-g:source";
                case GDebug.Lines:              return "-g:lines";
                case GDebug.Vars:               return "-g:vars";
                case GDebug.SourceLines:        return "-g:source,lines";
                case GDebug.SourceVars:         return "-g:source,vars";
                case GDebug.SourceLinesVars:    return "-g:source,lines,vars";
                case GDebug.LinesVars:          return "-g:lines,vars";
                default: return "";
            }
        }
    }

    public enum GDebug
    { 
        DoNotUse, // do not include any option
        All,
        None,
        Source,
        Lines,
        Vars,
        SourceLines,
        SourceVars,
        SourceLinesVars,
        LinesVars
    }
}

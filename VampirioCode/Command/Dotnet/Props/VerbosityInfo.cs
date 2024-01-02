using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VampirioCode.Command.Dotnet.Props
{
    public class VerbosityInfo
    {
        public Verbosity Verbosity { get; set; }
        public string Name { get; set; }
        public string Param { get; set; }

        private static VerbosityInfo _Create(Verbosity verbosity, string name, string param)
        { 
            VerbosityInfo verb = new VerbosityInfo();
            verb.Verbosity =    verbosity;
            verb.Name =         name;
            verb.Param =        param;
            return verb;
        }

        public static VerbosityInfo Get(Verbosity verb) 
        {
            switch (verb) 
            { 
                case Verbosity.None:        return _Create(verb, "",            "");
                case Verbosity.Quiet:       return _Create(verb, "Quiet",       "q");
                case Verbosity.Minimal:     return _Create(verb, "Minimal",     "m");
                case Verbosity.Normal:      return _Create(verb, "Normal",      "n");
                case Verbosity.Detailed:    return _Create(verb, "Detailed",    "d");
                case Verbosity.Diagnostic:  return _Create(verb, "Diagnostic",  "diag");
                default:                    return null;
            }
        }

    }
}

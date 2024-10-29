using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.MSVC.Params
{
    public class StandardVersionInfo
    {
        // IMPORTANT: it must be called equal to its own Type, otherwise, reflection won't work
        public StandardVersion StandardVersion { get; set; }
        public string Name { get; set; }
        public string Param { get; set; }

        private static StandardVersionInfo _Create(StandardVersion std, string name, string param)
        {
            StandardVersionInfo eh = new StandardVersionInfo();
            eh.StandardVersion = std;
            eh.Name =   name;
            eh.Param =  param;
            return eh;
        }

        public static StandardVersionInfo Get(StandardVersion version)
        {
            switch (version)
            {
                case StandardVersion.None:               return _Create(version, "", "");
                case StandardVersion.StdCpp14:           return _Create(version, "Standard Version c++14",       "/std:c++14");
                case StandardVersion.StdCpp17:           return _Create(version, "Standard Version c++17",       "/std:c++17");
                case StandardVersion.StdCpp20:           return _Create(version, "Standard Version c++20",       "/std:c++20");
                case StandardVersion.StdCppLatest:       return _Create(version, "Standard Version c++latest",   "/std:c++latest");
                case StandardVersion.StdC11:             return _Create(version, "Standard Version c11",         "/std:c11");
                case StandardVersion.StdC17:             return _Create(version, "Standard Version c17",         "/std:c17");
                case StandardVersion.StdCLatest:         return _Create(version, "Standard Version clatest",     "/std:clatest");
                default: return null;
            }
        }

        public static StandardVersionInfo GetByParam(string param)
        {
            switch (param)
            {
                case "":                return Get(StandardVersion.None);
                case "/std:c++14":      return Get(StandardVersion.StdCpp14);
                case "/std:c++17":      return Get(StandardVersion.StdCpp17);
                case "/std:c++20":      return Get(StandardVersion.StdCpp20);
                case "/std:c++latest":  return Get(StandardVersion.StdCppLatest);
                case "/std:c11":        return Get(StandardVersion.StdC11);
                case "/std:c17":        return Get(StandardVersion.StdC17);
                case "/std:clatest":    return Get(StandardVersion.StdCLatest);
                default: return null;
            }
        }
    }

}

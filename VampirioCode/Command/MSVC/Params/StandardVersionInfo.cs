using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.MSVC.Params
{
    public class StandardVersionInfo
    {
        public StandardVersion ExceptionHandlingModel { get; set; }
        public string Name { get; set; }
        public string Param { get; set; }

        private static StandardVersionInfo _Create(StandardVersion except, string name, string param)
        {
            StandardVersionInfo eh = new StandardVersionInfo();
            eh.ExceptionHandlingModel = except;
            eh.Name = name;
            eh.Param = param;
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
    }

}

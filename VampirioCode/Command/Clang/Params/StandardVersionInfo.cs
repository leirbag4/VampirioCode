using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.Clang.Params
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
                case StandardVersion.None:      return _Create(version, "", "");
                case StandardVersion.StdCpp98:  return _Create(version, "Standard Version c++98",   "-std=c++98");
                case StandardVersion.StdCpp03:  return _Create(version, "Standard Version c++03",   "-std=c++03");
                case StandardVersion.StdCpp11:  return _Create(version, "Standard Version c++11",   "-std=c++11");
                case StandardVersion.StdCpp14:  return _Create(version, "Standard Version c++14",   "-std=c++14");
                case StandardVersion.StdCpp17:  return _Create(version, "Standard Version c++17",   "-std=c++17");
                case StandardVersion.StdCpp20:  return _Create(version, "Standard Version c++20",   "-std=c++20");
                case StandardVersion.StdCpp23:  return _Create(version, "Standard Version c++23",   "-std=c++23");
                default: return null;
            }
        }
    }

}

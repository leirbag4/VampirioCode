using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.Emscripten.Emcc.Params
{
    public class StandardVersionInfo
    {
        public StandardVersion StandardVersion { get; set; }
        public string Name { get; set; }
        public string Param { get; set; }

        private static StandardVersionInfo _Create(StandardVersion std, string name, string param)
        {
            StandardVersionInfo eh = new StandardVersionInfo();
            eh.StandardVersion = std;
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

        public static StandardVersionInfo GetByParam(string param)
        {
            switch (param)
            {
                case "":                return Get(StandardVersion.None);
                case "-std=c++98":      return Get(StandardVersion.StdCpp98);
                case "-std=c++03":      return Get(StandardVersion.StdCpp03);
                case "-std=c++11":      return Get(StandardVersion.StdCpp11);
                case "-std=c++14":      return Get(StandardVersion.StdCpp14);
                case "-std=c++17":      return Get(StandardVersion.StdCpp17);
                case "-std=c++20":      return Get(StandardVersion.StdCpp20);
                case "-std=c++23":      return Get(StandardVersion.StdCpp23);
                default: return null;
            }
        }
    }

}

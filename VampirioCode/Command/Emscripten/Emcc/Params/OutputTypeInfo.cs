using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.Emscripten.Emcc.Params
{
public class OutputTypeInfo
    {
        // IMPORTANT: it must be called equal to its own Type, otherwise, reflection won't work
        public OutputType OutputType { get; set; } 
        public string Name { get; set; } = "";
        public string Param { get; set; } = "";
        public string Param2 { get; set; } = "";

        private static bool _init = false;
        private static List<OutputTypeInfo> outputTypeInfos = new List<OutputTypeInfo>();

        private static void Initialize()
        {
            if (_init)
                return;

            _Create(OutputType.Executable,  "Executable",   "");
            _Create(OutputType.DynamicLib,  "Dynamic Lib",  "-shared", "-fPIC");
            _Create(OutputType.StaticLib,   "Static Lib",   "-c");

            _init = true;
        }

        public static OutputTypeInfo Get(OutputType mode)
        {
            Initialize();
            return outputTypeInfos.FirstOrDefault(info => info.OutputType == mode);
        }

        public static OutputTypeInfo GetByName(string name)
        {
            Initialize();
            return outputTypeInfos.FirstOrDefault(info => info.Name == name);
        }

        public static OutputTypeInfo GetByParam(string param)
        {
            Initialize();
            return outputTypeInfos.FirstOrDefault(info => info.Param == param);
        }

        private static OutputTypeInfo _Create(OutputType type, string name, string param, string param2 = "")
        {
            OutputTypeInfo modeInfo = new OutputTypeInfo();
            modeInfo.OutputType =   type;
            modeInfo.Name =         name;
            modeInfo.Param =        param;
            modeInfo.Param2 =       param2;
            outputTypeInfos.Add(modeInfo);
            return modeInfo;
        }
    }
}

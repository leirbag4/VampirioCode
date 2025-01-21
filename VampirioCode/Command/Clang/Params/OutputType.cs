using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VampirioCode.Command.Clang.Params
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OutputType
    {
        Executable = 0,
        DynamicLib = 1,
        StaticLib = 2
    }
}

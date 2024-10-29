using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VampirioCode.Command.MSVC.Params
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OutputType
    {
        Executable = 0,
        Shared = 1,
        Static = 2
    }
}

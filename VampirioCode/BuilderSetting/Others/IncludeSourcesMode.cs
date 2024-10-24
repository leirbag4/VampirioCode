using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VampirioCode.BuilderSetting.Others
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IncludeSourcesMode
    {
        Default =   0,
        Manually =  1,
        Automatic = 2
    }
}

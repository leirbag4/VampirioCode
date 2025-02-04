using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.SaveData.Builders.Cpp
{
    public class GnuGppSaveSettings : BuilderSaveSettingsBase
    {
#if RELEASE
        public string wsl_distro_name { get; set; } = "Ubuntu";
#else
        public string wsl_distro_name { get; set; } = "Ubuntu-test";
#endif
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.BuilderSetting.Actions;
using VampirioCode.Command.GnuGppWSL.Params;

namespace VampirioCode.BuilderSetting.CppSettings.Settings
{
    public class GnuCppBSetting : CppBSettingBase
    {
        public StandardVersion StandardVersion { get; set; } = StandardVersion.None;
    }
}

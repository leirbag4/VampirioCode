using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.BuilderSetting.Actions;
using VampirioCode.Command.Clang.Params;

namespace VampirioCode.BuilderSetting.CppSettings.Settings
{
    public class CLangBSetting : CppBSettingBase
    {
        public OutputType OutputType { get; set; } = OutputType.Executable;
        public StandardVersion StandardVersion { get; set; } = StandardVersion.None;
    }
}

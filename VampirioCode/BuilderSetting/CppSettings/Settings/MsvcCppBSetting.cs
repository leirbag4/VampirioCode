using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.BuilderSetting.Actions;
using VampirioCode.Command.MSVC.Params;

namespace VampirioCode.BuilderSetting.CppSettings.Settings
{
    public class MsvcCppBSetting : CppBSettingBase
    {
        public OutputType OutputType { get; set; } = OutputType.Executable;
        public StandardVersion StandardVersion { get; set; } = StandardVersion.None;
        public ExceptionHandlingModel ExceptionHanldingModel { get; set; } = ExceptionHandlingModel.None;
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.BuilderSetting.CppSettings.Settings;

namespace VampirioCode.BuilderSetting.CppSettings
{
    public class CppBGroupSettings
    {
        public MsvcCppBSetting MsvcSetting { get; set; } = new MsvcCppBSetting();
        public GnuCppBSetting GnuSetting { get; set; } = new GnuCppBSetting();


    }
}

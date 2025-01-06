using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.SaveData.Builders.Cpp
{
    public class MsvcSaveSettings : BuilderSaveSettingsBase
    {
        // Compiler Executables 'cl.exe'
        public string CL_EXE_path{ get; set; } = "";
        public string LIB_EXE_path { get; set; } = "";

        // 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.SaveData.Builders.Cpp
{
    public class CLangSaveSettings : BuilderSaveSettingsBase
    {
        // Compiler Executables 'clang++.exe'
        public string clang_exe_path { get; set; } = "";
        
        // Includes
        public string clang_include_dir { get; set; } = "";
        
        // Library Directories
        public string clang_lib_dir { get; set; } = "";

        // Others
        public bool auto_fill_checked { get; set; } = true;

    }
}

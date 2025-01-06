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
        public string cl_exe_path{ get; set; } = "";
        public string lib_exe_path { get; set; } = "";

        // Includes
        public string stl_include { get; set; } = "";
        public string ucrt_include { get; set; } = "";

        // Library Directories
        public string stl_lib_dir { get; set; } = "";
        public string um_lib_dir { get; set; } = "";
        public string ucrt_lib_dir { get; set; } = "";
    }
}

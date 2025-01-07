using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI;

namespace VampirioCode.BuilderInstall.Java
{
    public partial class JavacBuildSetup : BuildSetupBase
    {
        public JavacBuildSetup()
        {
            InitializeComponent();
        }

        public override void LoadData()
        {
            XConsole.Println("load javac");

            //cl_exe_input.Setup(".exe", "cl.exe msvc file");

            LoadSaveData();
        }

        private void LoadSaveData()
        {
            //cl_exe_input.FilePath =         Config.BuildersSettings.Msvc.cl_exe_path;
        }

        public override void SaveData()
        {
            // Executable files
            //Config.BuildersSettings.Msvc.cl_exe_path = cl_exe_input.FilePath.Trim();
        }
    }
}

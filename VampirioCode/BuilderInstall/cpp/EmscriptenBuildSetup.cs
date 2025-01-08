using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.SaveData;
using VampirioCode.UI;

namespace VampirioCode.BuilderInstall.cpp
{
    public partial class EmscriptenBuildSetup : BuildSetupBase
    {
        public EmscriptenBuildSetup()
        {
            InitializeComponent();
        }

        public override void LoadData()
        {
            XConsole.Println("load emscripten");

            //cl_exe_input.Setup(".exe", "cl.exe msvc file");

            LoadSaveData();
        }

        private void LoadSaveData()
        {
            emsdk_bat_input.FilePath =  Config.BuildersSettings.Emscripten.emsdk_bat_path;
            nodejs_exe_input.FilePath = Config.BuildersSettings.Emscripten.nodejs_exe_path;
        }

        public override void SaveData()
        {
            // Executable files
            Config.BuildersSettings.Emscripten.emsdk_bat_path =     emsdk_bat_input.FilePath;
            Config.BuildersSettings.Emscripten.nodejs_exe_path =    nodejs_exe_input.FilePath;
        }

        private void OnUseHardcodedPaths(object sender, EventArgs e)
        {
            emsdk_bat_input.FilePath =  @"C:\programs_dev\emsdk\emsdk.bat";
            nodejs_exe_input.FilePath = @"C:\programs_dev\node-v20.11.0-win-x64\node.exe";
        }
    }
}

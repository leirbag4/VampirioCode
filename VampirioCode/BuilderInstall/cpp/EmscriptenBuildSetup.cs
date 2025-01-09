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
using VampirioCode.Utils;

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

            emsdk_bat_input.Setup(".bat", "emsdk.bat file");
            nodejs_exe_input.Setup(".exe", "nodejs.exe file");

            LoadSaveData();
        }

        private void LoadSaveData()
        {
            emsdk_bat_input.FilePath = Config.BuildersSettings.Emscripten.emsdk_bat_path;
            nodejs_exe_input.FilePath = Config.BuildersSettings.Emscripten.nodejs_exe_path;
        }

        public override void SaveData()
        {
            // Executable files
            Config.BuildersSettings.Emscripten.emsdk_bat_path = emsdk_bat_input.FilePath;
            Config.BuildersSettings.Emscripten.nodejs_exe_path = nodejs_exe_input.FilePath;
        }

        private void OnUseHardcodedPaths(object sender, EventArgs e)
        {
            emsdk_bat_input.FilePath = @"C:\programs_dev\emsdk\emsdk.bat";
            nodejs_exe_input.FilePath = @"C:\programs_dev\node-v20.11.0-win-x64\node.exe";
        }

        private void OnEmscriptenDownloadPressed(object sender, EventArgs e)
        {
            FileBrowserUtils.NavigateToWebPage(@"https://www.mediafire.com/file/mik872obwv3wzw8/emsdk.zip/file");
        }

        private void OnNodeJsDownloadPressed(object sender, EventArgs e)
        {
            FileBrowserUtils.NavigateToWebPage(@"https://www.mediafire.com/file/a4w46t1fkoz1h8i/node-v20.11.0-win-x64.zip/file");
        }
    }
}

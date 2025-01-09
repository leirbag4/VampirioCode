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

namespace VampirioCode.BuilderInstall.Javascript
{
    public partial class NodeJsBuildSetup : BuildSetupBase
    {
        public NodeJsBuildSetup()
        {
            InitializeComponent();
        }

        public override void LoadData()
        {
            XConsole.Println("load nodejs");

            nodejs_exe_input.Setup(".exe", "nodejs.exe msvc file");

            LoadSaveData();
        }

        private void LoadSaveData()
        {
            nodejs_exe_input.FilePath = Config.BuildersSettings.NodeJs.nodejs_exe_path;
        }

        public override void SaveData()
        {
            // Executable files
            Config.BuildersSettings.NodeJs.nodejs_exe_path = nodejs_exe_input.FilePath;
        }

        private void OnUseHardcodedPaths(object sender, EventArgs e)
        {
            nodejs_exe_input.FilePath = @"C:\programs_dev\node-v20.11.0-win-x64\node.exe";
        }

        private void OnDownloadPressed(object sender, EventArgs e)
        {
            FileBrowserUtils.NavigateToWebPage(@"https://www.mediafire.com/file/a4w46t1fkoz1h8i/node-v20.11.0-win-x64.zip/file");
        }
    }
}

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

namespace VampirioCode.BuilderInstall.PHP
{
    public partial class XamppBuildSetup : BuildSetupBase
    {
        public XamppBuildSetup()
        {
            InitializeComponent();
        }

        public override void LoadData()
        {
            XConsole.Println("load php xampp");

            php_exe_input.Setup(".exe", "php.exe interpreter");

            LoadSaveData();
        }

        private void LoadSaveData()
        {
            php_exe_input.FilePath = Config.BuildersSettings.PhpXampp.php_exe_path;
        }

        public override void SaveData()
        {
            // Executable files
            Config.BuildersSettings.PhpXampp.php_exe_path = php_exe_input.FilePath;
        }

        private void OnUseHardcodedPaths(object sender, EventArgs e)
        {
            php_exe_input.FilePath = @"C:\programs_dev\php-v8.1.3_usbwebserver\php\php.exe";
        }

        private void OnDownloadPressed(object sender, EventArgs e)
        {
            FileBrowserUtils.NavigateToWebPage(@"https://www.mediafire.com/file/4ycop27lngvrq9l/php-v8.1.3_usbwebserver.zip/file");
        }
    }
}

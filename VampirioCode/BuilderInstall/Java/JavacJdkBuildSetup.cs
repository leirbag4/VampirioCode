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

namespace VampirioCode.BuilderInstall.Java
{
    public partial class JavacJdkBuildSetup : BuildSetupBase
    {
        public JavacJdkBuildSetup()
        {
            InitializeComponent();
        }

        public override void LoadData()
        {
            XConsole.Println("load javac");

            javac_exe_input.Setup(".exe", "javac.exe compiler");
            java_exe_input.Setup(".exe", "java.exe runtime");

            LoadSaveData();
        }

        private void LoadSaveData()
        {
            javac_exe_input.FilePath = Config.BuildersSettings.JavaJDK.javac_exe_path;
            java_exe_input.FilePath = Config.BuildersSettings.JavaJDK.java_exe_path;
        }

        public override void SaveData()
        {
            // Executable files
            Config.BuildersSettings.JavaJDK.javac_exe_path = javac_exe_input.FilePath;
            Config.BuildersSettings.JavaJDK.java_exe_path = java_exe_input.FilePath;
        }

        private void OnUseHardcodedPaths(object sender, EventArgs e)
        {
            javac_exe_input.FilePath = @"C:\programs_dev\java\jdk-22\bin\javac.exe";
            java_exe_input.FilePath = @"C:\programs_dev\java\jdk-22\bin\java.exe";
        }

        private void OnDownloadPressed(object sender, EventArgs e)
        {
            FileBrowserUtils.NavigateToWebPage(@"https://www.mediafire.com/file/19u9xsp80551tkz/java.zip/file");
        }

    }
}

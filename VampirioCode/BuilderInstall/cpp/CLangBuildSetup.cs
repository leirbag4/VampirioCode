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
    public partial class CLangBuildSetup : BuildSetupBase
    {
        public CLangBuildSetup()
        {
            InitializeComponent();
        }

        public override void LoadData()
        {
            XConsole.Println("load clang");

            clang_exe_input.Setup(".exe", "clang.exe clang file");
            clang_include_input.Setup("CLang 'include' directory");
            clang_lib_input.Setup("CLang 'include' directory");

            LoadSaveData();

            clang_exe_input.FilePathChanged += OnExePathChanged;
        }

        private void LoadSaveData()
        {
            clang_exe_input.FilePath = Config.BuildersSettings.CLang.clang_exe_path;
            clang_include_input.DirPath = Config.BuildersSettings.CLang.clang_include_dir;
            clang_lib_input.DirPath = Config.BuildersSettings.CLang.clang_lib_dir;
            auto_fill_ckbox.Checked = Config.BuildersSettings.CLang.auto_fill_checked;
        }

        public override void SaveData()
        {
            Config.BuildersSettings.CLang.clang_exe_path = clang_exe_input.FilePath;
            Config.BuildersSettings.CLang.clang_include_dir = clang_include_input.DirPath;
            Config.BuildersSettings.CLang.clang_lib_dir = clang_lib_input.DirPath;
            Config.BuildersSettings.CLang.auto_fill_checked = auto_fill_ckbox.Checked;
        }

        private void OnExePathChanged(string path)
        {
            if (auto_fill_ckbox.Checked)
            {
                int index = path.LastIndexOf("bin\\clang++.exe");
                if (index != -1)
                {
                    string basePath = path.Substring(0, index);
                    clang_include_input.DirPath = basePath + "include";
                    clang_lib_input.DirPath = basePath + "lib";
                }
            }
        }

        private void OnUseHardcodedPaths(object sender, EventArgs e)
        {
            clang_exe_input.FilePath = @"C:\programs_dev\clang_llvm_18_1_0\bin\clang++.exe";
            clang_include_input.DirPath = @"C:\programs_dev\clang_llvm_18_1_0\include";
            clang_lib_input.DirPath = @"C:\programs_dev\clang_llvm_18_1_0\lib";
        }

        private void OnDownloadPressed(object sender, EventArgs e)
        {
            FileBrowserUtils.NavigateToWebPage(@"https://www.mediafire.com/file/69zai46pvn51pha/clang_llvm_18_1_0.zip/file");
        }

        private void labelAdv1_Click(object sender, EventArgs e)
        {

        }
    }
}

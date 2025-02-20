﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.Command.Dotnet;
using VampirioCode.UI;
using VampirioCode.Utils;

namespace VampirioCode.BuilderInstall.csharp
{
    public partial class DotnetBuildSetup : BuildSetupBase
    {
        public DotnetBuildSetup()
        {
            InitializeComponent();
        }

        public override void LoadData()
        {
            XConsole.Println("load dotnet");

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

        private void OnDownloadPressed(object sender, EventArgs e)
        {
            FileBrowserUtils.NavigateToWebPage("https://dotnet.microsoft.com/en-us/download");
        }

        private async void OnTestInstallationPressed(object sender, EventArgs e)
        {
            Dotnet dotnet = new Dotnet();
            var result = await dotnet.VersionAsync();

            XConsole.Println("Dotnet installed. Version: " + result.Version);
        }
    }
}

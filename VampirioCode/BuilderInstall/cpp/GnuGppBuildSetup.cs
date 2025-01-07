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
    public partial class GnuGppBuildSetup : BuildSetupBase
    {
        public GnuGppBuildSetup()
        {
            InitializeComponent();
        }

        public override void LoadData()
        {
            XConsole.Println("load gnu c++");

            //cl_exe_input.Setup(".exe", "cl.exe msvc file");

            LoadSaveData();
        }

        private void LoadSaveData()
        {
            wsl_distro_name.Text = Config.BuildersSettings.GnuGpp.wsl_distro_name;
        }

        public override void SaveData()
        {
            Config.BuildersSettings.GnuGpp.wsl_distro_name = wsl_distro_name.Text.Trim();
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.IO;
using VampirioCode.SaveData;
using VampirioCode.UI;
using VampirioCode.Utils;

namespace VampirioCode.BuilderInstall.cpp
{
    public partial class GnuGppBuildSetup : BuildSetupBase
    {
        public string CurrDistroName { get { return wsl_distro_name.Text.Trim(); } }

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

        private void CheckWSLInstalled()
        {
            const string wslRegistryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Lxss";

            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(wslRegistryKey))
                {
                    if (key != null)
                    {
                        XConsole.Println("WSL is installed [yes]");
                        SetWslInstalled(true);
                        CheckDistroInstalled();
                    }
                    else
                    {
                        XConsole.Println("WSL is not installed [no]");
                        SetWslInstalled(false);
                    }
                }
            }
            catch (Exception ex)
            {
                XConsole.PrintError("Error verifying registry [no]: " + ex.Message);
                SetWslInstalled(false);
            }
        }

        private void CheckDistroInstalled()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "wsl.exe";
                process.StartInfo.Arguments = "--list"; // Lista todas las distribuciones instaladas
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.StartInfo.StandardOutputEncoding = Encoding.Unicode;
                process.StartInfo.StandardErrorEncoding = Encoding.Unicode;

                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (!string.IsNullOrEmpty(output))
                {
                    XConsole.Println("Installed Distros:");
                    XConsole.Println(output);

                    if (output.Contains(CurrDistroName, StringComparison.OrdinalIgnoreCase))
                    {
                        XConsole.Println($"The distro '{CurrDistroName}' is installed [yes]");
                        SetDistroInstalled(true);
                    }
                    else
                    {
                        XConsole.PrintWarning($"The distro '{CurrDistroName}' is not installed [no]");
                        SetDistroInstalled(false);
                    }
                }
                else
                {
                    XConsole.Println("No distro installed where found. [no]");
                    SetDistroInstalled(false);
                }
            }
            catch (Exception ex)
            {
                XConsole.PrintError("Error while verifying distros [no]: " + ex.Message);
                SetDistroInstalled(false);
            }
        }

        private void OpenWSLManDownloadPage()
        {
            FileBrowserUtils.NavigateToWebPage("https://github.com/leirbag4/WSLMan");
        }

        private void SetWslInstalled(bool installed)
        {
            wslInstalledTick.Image = installed ? Properties.Resources.med_tick_on : Properties.Resources.med_tick_off;
        }

        private void SetDistroInstalled(bool installed)
        {
            distroInstalledTick.Image = installed ? Properties.Resources.med_tick_on : Properties.Resources.med_tick_off;
        }

        private void OnCheckPressed(object sender, EventArgs e)
        {
            CheckWSLInstalled();
        }

        private void OnDownloadWSLManPressed(object sender, EventArgs e)
        {
            OpenWSLManDownloadPage();
        }
    }
}

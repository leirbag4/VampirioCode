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
using VampirioCode.UI;
using System.IO;
using System.Runtime.InteropServices;


namespace VampirioCode.BuilderInstall.cpp
{
    public partial class MsvcBuildSetup : BuildSetupBase
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern uint GetEnvironmentVariable(string lpName, StringBuilder lpBuffer, uint nSize);


        public MsvcBuildSetup()
        {
            InitializeComponent();
        }

        public override void LoadData()
        {
            XConsole.Println("load msvc");

            cl_exe_input.Setup(".exe", "cl.exe msvc file");
            lib_exe_input.Setup(".exe", "lib.exe msvc file");
        }

        public void FindCompilersPath()
        {
            string clPath = GetCompilerPath();

            if (clPath != "")
            {
                string basePath = clPath.Substring(0, clPath.LastIndexOf("\\"));
                string libPath = Path.Combine(basePath, "lib.exe");

                cl_exe_input.FilePath = clPath;
                lib_exe_input.FilePath = libPath;
            }
            else
                MsgBox.Show("Can't find", "Can't find 'cl.exe' and 'lib.exe' of MSVC Visual Studio installation. Install Visual Studio with C++ features first or setup path manually of each program.");
        }

        public string GetCompilerPath()
        {
            string programFilesX86Path;
            var buffer = new StringBuilder(1024);

            uint size = GetEnvironmentVariable("ProgramFiles(x86)", buffer, (uint)buffer.Capacity);

            if (size > 0)
                programFilesX86Path = "C:\\Program Files (x86)";
            else
                programFilesX86Path = "";


            // Default path where 'vswhere.exe' usually is
            string vswherePath = Path.Combine(programFilesX86Path,
                                              "Microsoft Visual Studio", "Installer", "vswhere.exe");

            XConsole.Println("vswherePath: " + vswherePath);

            if (!File.Exists(vswherePath))
            {
                XConsole.Println("Can't find 'vswhere.exe'. Check that Visual Studio is installed.");
                return null;
            }

            // Ejecutar vswhere.exe para obtener la ruta de instalación de Visual Studio
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = vswherePath,
                Arguments = "-latest -requires Microsoft.VisualStudio.Component.VC.Tools.x86.x64 -property installationPath",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using (Process process = Process.Start(startInfo))
                using (StreamReader reader = process.StandardOutput)
                {
                    string installationPath = reader.ReadLine()?.Trim();
                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(installationPath))
                    {
                        // Ruta al compilador
                        string clExePath = Path.Combine(installationPath, "VC", "Tools", "MSVC");
                        if (Directory.Exists(clExePath))
                        {
                            // Buscar subdirectorios que contengan cl.exe
                            foreach (string versionDir in Directory.GetDirectories(clExePath))
                            {
                                string clPath = Path.Combine(versionDir, "bin", "Hostx64", "x64", "cl.exe");
                                if (File.Exists(clPath))
                                {
                                    return clPath;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XConsole.PrintWarning($"Error looking for compiler: {ex.Message}");
            }


            return "";
        }

        private void AutoFillIncludesAndLibraries()
        {
            FindLibAndInclude();
            FindIncludeUcrt();
            FindLibUmAndUcrt();
        }

        private void FindLibUmAndUcrt()
        {
            string libraryBase =        FindDirWithVersion("C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\");
            lib_um_input.DirPath =      Path.Combine(libraryBase, "um\\x64");
            lib_ucrt_input.DirPath =    Path.Combine(libraryBase, "ucrt\\x64");
        }

        private void FindIncludeUcrt() 
        {

            // 'include ucrt'
            string include = FindDirWithVersion("C:\\Program Files (x86)\\Windows Kits\\10\\Include\\");
            if (include != "")
            {
                // hardcoded fixed bug
                include = include.Replace("\\libd", "");

                include_ucrt_input.DirPath = Path.Combine(include, "ucrt");
            }
        }

        private void FindLibAndInclude()
        {
            string clPath = cl_exe_input.FilePath;
            string includePath;
            string libPath;

            // Find 'include' and 'lib'
            int index = clPath.IndexOf("bin\\Hostx64\\x64\\cl.exe");

            if (index != -1)
            {
                include_input.DirPath = Path.Combine(clPath.Substring(0, index), "include");
                lib_input.DirPath =     Path.Combine(clPath.Substring(0, index), "lib\x64");
            }

            
        }

        // You can pass as argument 'C:\Program Files (x86)\Windows Kits\10\Include\' and it will return
        //                          'C:\Program Files (x86)\Windows Kits\10\Include\10.0.22621.0'
        private string FindDirWithVersion(string path)
        {
            // Ensure the main directory exists
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"The specified directory does not exist: {path}");
            }

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            // Filter subdirectories with valid names representing version numbers
            var versionedDirectories = dirInfo.GetDirectories()
                .Where(d => Version.TryParse(d.Name, out _)) // Use Version.TryParse to filter valid version names
                .ToList();

            if (versionedDirectories.Count == 0)
            {
                throw new InvalidOperationException("No subdirectories with version names were found in the specified directory.");
            }

            // Find the directory with the highest version number
            var highestVersionDir = versionedDirectories
                .OrderByDescending(d => Version.Parse(d.Name)) // Sort by version in descending order
                .First();

            // Return the full path of the directory with the highest version
            return highestVersionDir.FullName;
        }

        private void OnAutoCheckInstallation(object sender, EventArgs e)
        {
            FindCompilersPath();
        }

        private void OnAutoFillIncludesAndLibraries(object sender, EventArgs e)
        {
            AutoFillIncludesAndLibraries();
        }
    }
}

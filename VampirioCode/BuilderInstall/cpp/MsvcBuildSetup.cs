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
using VampirioCode.SaveData;
using VampirioCode.Utils;


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
            panelContainer.AutoScroll = true;
            panelContainer.VerticalScroll.Visible = true;

            LoadSaveData();
        }

        private void LoadSaveData()
        {
            cl_exe_input.FilePath = Config.BuildersSettings.Msvc.cl_exe_path;
            lib_exe_input.FilePath = Config.BuildersSettings.Msvc.lib_exe_path;

            // Includes
            stl_include_input.DirPath = Config.BuildersSettings.Msvc.stl_include;
            ucrt_include_input.DirPath = Config.BuildersSettings.Msvc.ucrt_include;

            // Library Directories
            stl_lib_dir_input.DirPath = Config.BuildersSettings.Msvc.stl_lib_dir;
            um_kernel32_lib_input.DirPath = Config.BuildersSettings.Msvc.um_lib_dir;
            ucrt_lib_input.DirPath = Config.BuildersSettings.Msvc.ucrt_lib_dir;
        }

        public override void SaveData()
        {
            XConsole.Println("save msvc data");

            // Executable files
            Config.BuildersSettings.Msvc.cl_exe_path = cl_exe_input.FilePath.Trim();
            Config.BuildersSettings.Msvc.lib_exe_path = lib_exe_input.FilePath.Trim();

            // Includes
            Config.BuildersSettings.Msvc.stl_include = stl_include_input.DirPath.Trim();
            Config.BuildersSettings.Msvc.ucrt_include = ucrt_include_input.DirPath.Trim();

            // Library Directories
            Config.BuildersSettings.Msvc.stl_lib_dir = stl_lib_dir_input.DirPath.Trim();
            Config.BuildersSettings.Msvc.um_lib_dir = um_kernel32_lib_input.DirPath.Trim();
            Config.BuildersSettings.Msvc.ucrt_lib_dir = ucrt_lib_input.DirPath.Trim();

            Config.Save();
        }

        public void FindCompilersPath()
        {
            string clPath = GetCompilerPath();

            try
            {
                if (clPath != "")
                {
                    string basePath = clPath.Substring(0, clPath.LastIndexOf("\\"));
                    string libPath = Path.Combine(basePath, "lib.exe");

                    cl_exe_input.FilePath = clPath;
                    lib_exe_input.FilePath = libPath;
                }
                else
                    MsgBox.Show(this, "Can't find", "Can't find 'cl.exe' and 'lib.exe' of MSVC Visual Studio installation. Install Visual Studio with C++ features first or setup path manually of each program.");
            }
            catch (Exception e)
            {
                MsgBox.Show(this, "Can't find", "Can't auto find 'cl.exe' and 'lib.exe'");
            }
        }

        public string GetCompilerPath()
        {
            string programFilesX86Path;
            var buffer = new StringBuilder(1024);
            ProcessStartInfo startInfo = null;

            try
            {
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
                startInfo = new ProcessStartInfo
                {
                    FileName = vswherePath,
                    Arguments = "-latest -requires Microsoft.VisualStudio.Component.VC.Tools.x86.x64 -property installationPath",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

            }
            catch (Exception e)
            {
                XConsole.PrintWarning($"Error checking compiler: {e.Message}");
                return "";
            }

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
            try
            {
                string libraryBase = FindDirWithVersion("C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\");
                um_kernel32_lib_input.DirPath = Path.Combine(libraryBase, "um\\x64");
                ucrt_lib_input.DirPath = Path.Combine(libraryBase, "ucrt\\x64");
            }
            catch (Exception e)
            {
                MsgBox.Show(this, "Can't find", "Can't auto find directories for 'um kernel32lib' and 'ucrt lib'. Setup by hand please.");
            }
        }

        private void FindIncludeUcrt()
        {
            try
            {
                // 'include ucrt'
                string include = FindDirWithVersion("C:\\Program Files (x86)\\Windows Kits\\10\\Include\\");
                if (include != "")
                {
                    // hardcoded fixed bug
                    include = include.Replace("\\libd", "");

                    ucrt_include_input.DirPath = Path.Combine(include, "ucrt");
                }
            }
            catch (Exception e)
            {
                MsgBox.Show(this, "Can't find", "Can't auto find 'ucrt input' directory. Setup by hand please.");
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
                stl_include_input.DirPath = Path.Combine(clPath.Substring(0, index), "include");
                stl_lib_dir_input.DirPath = Path.Combine(clPath.Substring(0, index), "lib\\x64");
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

        private void OnUseVisualStudioCommonHardcodedPaths(object sender, EventArgs e)
        {
            cl_exe_input.FilePath =     @"C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC\14.39.33519\bin\Hostx64\x64\cl.exe";
            lib_exe_input.FilePath =    @"C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC\14.39.33519\bin\Hostx64\x64\lib.exe";

            // Includes
            stl_include_input.DirPath =     @"C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC\14.39.33519\include";
            ucrt_include_input.DirPath =    @"C:\Program Files (x86)\Windows Kits\10\Include\10.0.22621.0\ucrt";

            // Library Directories
            stl_lib_dir_input.DirPath =     @"C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC\14.39.33519\lib\x64";
            um_kernel32_lib_input.DirPath = @"C:\Program Files (x86)\Windows Kits\10\Lib\10.0.22621.0\um\x64";
            ucrt_lib_input.DirPath =        @"C:\Program Files (x86)\Windows Kits\10\Lib\10.0.22621.0\ucrt\x64";
        }



        private void OnSelectVisualStudioPaths(object sender, EventArgs e)
        {
            MsgBox.Show(this, "'Microsoft Visual Studio' directory", "Please select the 'Microsoft Visual Studio' directory. Usually located at:\n\nC:\\Program Files\\Microsoft Visual Studio");
            string visualStudioPath = SelectFolder("Select the 'Microsoft Visual Studio' directory. Usually located at:\n\nC:\\Program Files\\Microsoft Visual Studio", "Microsoft Visual Studio", "C:\\Program Files\\Microsoft Visual Studio");
            if (string.IsNullOrEmpty(visualStudioPath)) return;

            MsgBox.Show(this, "'Windows Kits' directory", "Please select the 'Windows Kits' directory. Usually located at:\n\nC:\\Program Files (x86)\\Windows Kits");
            string windowsKitsPath = SelectFolder("Select the 'Windows Kits' directory. Usually located at:\n\nC:\\Program Files (x86)\\Windows Kits", "Windows Kits", "C:\\Program Files (x86)\\Windows Kits");
            if (string.IsNullOrEmpty(windowsKitsPath)) return;

            //string visualStudioPath = "C:\\Program Files\\Microsoft Visual Studio";
            //string windowsKitsPath = "C:\\Program Files (x86)\\Windows Kits";

            string latestVsYear = GetLatestYearDirectory(visualStudioPath);
            //string latestVsEdition = GetLatestVersionDirectory2(Path.Combine(visualStudioPath, latestVsYear, "Community\\VC\\Tools\\MSVC"));
            string latestVsEdition = GetEdition(Path.Combine(visualStudioPath, latestVsYear));
            //XConsole.Alert("latestVsEdition: " + latestVsEdition);


            string latestMsvcVersion = GetLatestVersionDirectory2(Path.Combine(visualStudioPath, latestVsYear, latestVsEdition, "VC", "Tools", "MSVC"));
            //XConsole.Alert("latestMsvcVersion: " + latestMsvcVersion);

            string latestWindowsKitsVersion = GetLatestVersionDirectoryFloat(windowsKitsPath);
            //XConsole.Alert("[-] latestWindowsKitsVersion: " + latestWindowsKitsVersion);

            //string windowsKitsNumber = GetLatestVersionDirectory(windowsKitsPath);
            //XConsole.Alert("windowsKitsNumber: " + windowsKitsNumber);

            string latestWindowsSdkVersion = GetLatestVersionDirectory2(Path.Combine(windowsKitsPath, latestWindowsKitsVersion, "Include"));
            //XConsole.Alert("STR: " + Path.Combine(windowsKitsPath, latestWindowsKitsVersion, "Include"));
            //XConsole.Alert("latestWindowsSdkVersion: " + latestWindowsSdkVersion);

            if (latestVsYear == null || latestVsEdition == null || latestMsvcVersion == null || latestWindowsKitsVersion == null || latestWindowsSdkVersion == null)
            {
                MessageBox.Show("Can't find valid versions for selected directories.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string msvcVersionPath = Path.Combine(visualStudioPath, latestVsYear, latestVsEdition, "VC", "Tools", "MSVC", latestMsvcVersion);
            string windowsKitsVersionPath = Path.Combine(windowsKitsPath, latestWindowsKitsVersion, "Include", latestWindowsSdkVersion);

            cl_exe_input.FilePath = Path.Combine(msvcVersionPath, "bin", "Hostx64", "x64", "cl.exe");
            lib_exe_input.FilePath = Path.Combine(msvcVersionPath, "bin", "Hostx64", "x64", "lib.exe");

            stl_include_input.DirPath = Path.Combine(msvcVersionPath, "include");
            ucrt_include_input.DirPath = Path.Combine(windowsKitsVersionPath, "ucrt");

            stl_lib_dir_input.DirPath = Path.Combine(msvcVersionPath, "lib", "x64");
            um_kernel32_lib_input.DirPath = Path.Combine(windowsKitsPath, latestWindowsKitsVersion, "Lib", latestWindowsSdkVersion, "um", "x64");
            ucrt_lib_input.DirPath = Path.Combine(windowsKitsPath, latestWindowsKitsVersion, "Lib", latestWindowsSdkVersion, "ucrt", "x64");
        }

        private string SelectFolder(string description, string lookFor, string possiblePath)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = description;
                folderDialog.ShowNewFolderButton = false;
                folderDialog.SelectedPath = possiblePath;

                var dialog = folderDialog.ShowDialog();
                string dir = Path.GetFileName(folderDialog.SelectedPath);

                if (dir != lookFor)
                {
                    MsgBox.Show("Directory '" + dir + "' is not compatible.\n\nYou must select the one called '" + lookFor + "' usually located at:\n\n'" + possiblePath + "'", DialogButtons.OK, DialogIcon.Error);
                    return null;
                }

                return dialog == DialogResult.OK ? folderDialog.SelectedPath : null;
            }
        }

        private string GetEdition(string basePath)
        {
            string[] editions = { "Community", "Professional", "Enterprise", "BuildTools" };

            string installedEdition = editions.FirstOrDefault(edition => Directory.Exists(Path.Combine(basePath, edition)));

            if (installedEdition.Trim() == "")
            {
                MsgBox.Show("Can't find the VS edition like 'Community', 'Professional', 'etc'");
                return null;
            }
            else
                return installedEdition;
        }

        private string GetLatestYearDirectory(string parentPath)
        {
            if (!Directory.Exists(parentPath)) return null;

            var versionDirs = Directory.GetDirectories(parentPath)
                .Select(Path.GetFileName)
                .Where(name => int.TryParse(name, out _))
                .OrderByDescending(name => name)
                .ToList();

            return versionDirs.FirstOrDefault();
        }

        private string GetLatestVersionDirectory(string parentPath)
        {
            if (!Directory.Exists(parentPath)) return null;

            var versionDirs = Directory.GetDirectories(parentPath)
                .Select(Path.GetFileName)
                .Where(name => Version.TryParse(name, out _))
                .OrderByDescending(name => new Version(name))
                .ToList();

            return versionDirs.FirstOrDefault();
        }

        private string GetLatestVersionDirectory2(string parentPath)
        {
            if (!Directory.Exists(parentPath)) return null;

            var versionDirs = Directory.GetDirectories(parentPath)
                .Select(Path.GetFileName)
                .Where(name => Version.TryParse(name, out _))
                .OrderByDescending(name => new Version(name))
                .ToList();

            return versionDirs.FirstOrDefault();
        }

        private string GetLatestVersionDirectoryFloat(string parentPath)
        {
            if (!Directory.Exists(parentPath)) return null;

            var versionDirs = Directory.GetDirectories(parentPath)
                .Select(Path.GetFileName)
                .Where(name => float.TryParse(name, out _))
                .OrderByDescending(name => name)
                .ToList();

            if (versionDirs.Count <= 0)
                return null;

            return versionDirs[versionDirs.Count - 1];

        }















        private void OnUseBuildToolsHardcodedPaths(object sender, EventArgs e)
        {
            OnSelectBuildTools();
            return;

            cl_exe_input.FilePath = @"C:\BuildTools\VC\Tools\MSVC\14.42.34433\bin\Hostx64\x64\cl.exe";
            lib_exe_input.FilePath = @"C:\BuildTools\VC\Tools\MSVC\14.42.34433\bin\Hostx64\x64\lib.exe";

            // Includes
            stl_include_input.DirPath = @"C:\BuildTools\VC\Tools\MSVC\14.42.34433\include";
            ucrt_include_input.DirPath = @"C:\BuildTools\Windows Kits\10\Include\10.0.26100.0\ucrt";

            // Library Directories
            stl_lib_dir_input.DirPath = @"C:\BuildTools\VC\Tools\MSVC\14.42.34433\lib\x64";
            um_kernel32_lib_input.DirPath = @"C:\BuildTools\Windows Kits\10\Lib\10.0.26100.0\um\x64";
            ucrt_lib_input.DirPath = @"C:\BuildTools\Windows Kits\10\Lib\10.0.26100.0\ucrt\x64";
        }

        private void OnSelectBuildTools()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the 'BuildTools' directory";
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    string vcPath = Path.Combine(selectedPath, "VC");
                    string kitsPath = Path.Combine(selectedPath, "Windows Kits");

                    if (!Directory.Exists(vcPath) || !Directory.Exists(kitsPath))
                    {
                        MessageBox.Show("It's not the 'BuildTools' directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string msvcPath = Path.Combine(vcPath, "Tools", "MSVC");
                    string windowsKitsIncludePath = Path.Combine(kitsPath, "10", "Include");
                    string windowsKitsLibPath = Path.Combine(kitsPath, "10", "Lib");

                    string latestMsvcVersion = GetLatestVersionDirectory(msvcPath);
                    string latestWindowsKitsVersion = GetLatestVersionDirectory(windowsKitsIncludePath);

                    if (latestMsvcVersion == null || latestWindowsKitsVersion == null)
                    {
                        MessageBox.Show("Can't find valid versions on 'BuildTools'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // update paths
                    string msvcVersionPath = Path.Combine(msvcPath, latestMsvcVersion);
                    string windowsKitsVersionPath = Path.Combine(windowsKitsIncludePath, latestWindowsKitsVersion);

                    cl_exe_input.FilePath = Path.Combine(msvcVersionPath, "bin", "Hostx64", "x64", "cl.exe");
                    lib_exe_input.FilePath = Path.Combine(msvcVersionPath, "bin", "Hostx64", "x64", "lib.exe");

                    stl_include_input.DirPath = Path.Combine(msvcVersionPath, "include");
                    ucrt_include_input.DirPath = Path.Combine(windowsKitsVersionPath, "ucrt");

                    stl_lib_dir_input.DirPath = Path.Combine(msvcVersionPath, "lib", "x64");
                    um_kernel32_lib_input.DirPath = Path.Combine(windowsKitsLibPath, latestWindowsKitsVersion, "um", "x64");
                    ucrt_lib_input.DirPath = Path.Combine(windowsKitsLibPath, latestWindowsKitsVersion, "ucrt", "x64");
                }
            }
        }

 



        private void OnDownloadFromGithubPressed(object sender, EventArgs e)
        {
            FileBrowserUtils.NavigateToWebPage(@"https://github.com/Data-Oriented-House/PortableBuildTools?tab=readme-ov-file");
        }

        private void OnDirectDownloadPressed(object sender, EventArgs e)
        {
            FileBrowserUtils.NavigateToWebPage(@"https://www.mediafire.com/file/0kryca7n20gdgip/PortableBuildTools.zip/file");
        }

        private void OnClearPressed(object sender, EventArgs e)
        {
            cl_exe_input.FilePath =         "";
            lib_exe_input.FilePath =        "";

            stl_include_input.DirPath =     "";
            ucrt_include_input.DirPath =    "";

            stl_lib_dir_input.DirPath =     "";
            um_kernel32_lib_input.DirPath = "";
            ucrt_lib_input.DirPath =        "";
        }
    }
}

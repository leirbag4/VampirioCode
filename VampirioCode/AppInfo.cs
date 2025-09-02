using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.SaveData;

namespace VampirioCode
{

    public class AppInfo
    {
        // Current version of the application in the form of '1.0.0'
        public static string Version { get { string ver = Application.ProductVersion; int i = ver.IndexOf("+"); if (i != -1) return ver.Substring(0, i); else return ver; } }

        // Current directory root path of the application at the same level of its executable. 'E.g: C:\Programs\AppDir\'
        public static string BasePath { get { return AppDomain.CurrentDomain.BaseDirectory; } }
        public static string ConfigFileName { get { return AppDataDir + "config.cfg"; } }
        public static string SettingsFileName { get { return "settings.ini"; } }
        public static string VampDataDir { get { return "VampirioCode"; } }

        // Temporary files path directory. 'E.g: C\Programs\AppDir\temp_files'
        //public static string TemporaryFilesPath         { get { return AppDomain.CurrentDomain.BaseDirectory + "temp_files\\"; } }
        public static string TemporaryFilesPath         { get { return AppDataDir + "temp_files\\"; } }
        //public static string TemporaryBuildPath         { get { return AppDomain.CurrentDomain.BaseDirectory + "temp_build\\"; } }
        public static string TemporaryBuildPath         { get { return AppDataDir + "temp_build\\"; } }
        public static string VampTempDir                { get { return "_vamp"; } }
        public static string BSettingsFileName          { get { return ".bsettings"; } }
        public static string WorkspaceFileName          { get { return ".workspace"; } }
        public static string ResDirName                 { get { return "res"; } }

        public static string PackagesPath               { get { return AppDomain.CurrentDomain.BaseDirectory + "packages\\"; } }

        public static string AppDataDir
        {
            get
            {
                // Designed for a 'portable' version of the application
                // Program and all of its temp dirs and files run inside the same main program folder
                if (Settings.Portable)
                {
                    //[rootAppDir\]
                    return AppDomain.CurrentDomain.BaseDirectory;
                }
                // Designed for the 'installable' version of the application
                // Program runs from 'C:\Program Files\VampirioCode' as an example. In this case temp dir and temp files
                // can't be inside that folder because it is protected by windows after installation.
                // So 'AppData' must be used in this case
                else // if (Settings.Installable)
                {
                    // [...AppData\Roaming\VampirioCode\]
                    return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), VampDataDir) + "\\";
                }
            }
        }

    }
}

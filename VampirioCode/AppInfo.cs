using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode
{
    public class AppInfo
    {
        // Current version of the application in the form of '1.0.0'
        public static string Version { get { string ver = Application.ProductVersion; int i = ver.IndexOf("+"); if (i != -1) return ver.Substring(0, i); else return ver; } }

        // Current directory root path of the application at the same level of its executable. 'E.g: C:\Programs\AppDir\'
        public static string BasePath { get { return AppDomain.CurrentDomain.BaseDirectory; } }

        // Temporary files path directory. 'E.g: C\Programs\AppDir\temp_files'
        public static string TemporaryFilesPath { get { return AppDomain.CurrentDomain.BaseDirectory + "temp_files\\"; } }
        public static string TemporaryBuildPath { get { return AppDomain.CurrentDomain.BaseDirectory + "temp_build\\"; } }
        public static string PackagesPath { get { return AppDomain.CurrentDomain.BaseDirectory + "packages\\"; } }

    }
}

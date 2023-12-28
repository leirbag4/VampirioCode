using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI;

namespace VampirioCode.Utils
{
    public class FileUtils
    {

        public static string[] GetFilesAt(string path)
        {
            return Directory.GetFiles(path);
        }

        public static string[] GetFileNamesAt(string path)
        {
            return Directory.GetFiles(path).Select(Path.GetFileName).ToArray();
        }

    }
}

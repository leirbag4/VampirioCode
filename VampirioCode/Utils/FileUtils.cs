using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampDocManager;
using VampirioCode.UI;

namespace VampirioCode.Utils
{
    public class FileUtils
    {
        public static void DeleteFilesAndDirs(String dirPath)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(dirPath);

            foreach (FileInfo file in di.GetFiles())
                file.Delete();

            foreach (DirectoryInfo dir in di.GetDirectories())
                dir.Delete(true);
        }

        public static string[] GetFilesAt(string path)
        {
            return Directory.GetFiles(path);
        }

        public static string[] GetFileNamesAt(string path, bool includeExtension = true)
        {
            if (includeExtension)
            {
                return Directory.GetFiles(path).Select(Path.GetFileName).ToArray();
            }
            else
            {
                return Directory.GetFiles(path)
                        .Select(file => Path.GetFileNameWithoutExtension(file))
                        .ToArray();
            }
        }

        public static string SaveFileDialog()
        { 
            String text;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title =      "Save file as";
            dialog.Filter =     "All Files (*.*)|*.*|Text Files (*.txt)|*.txt";
            dialog.FilterIndex = 1; // set first index

            dialog.ShowDialog();
            return dialog.FileName;
        }

    }
}

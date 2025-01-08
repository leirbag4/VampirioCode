using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI;

namespace VampirioCode.Utils
{
    public class FileBrowserUtils
    {
        // open file directory
        /*public static void OpenFileLocation(string path)
        { 
        
        }*/

        // open file directory and select it
        // path = "c:\prog\file.exe"
        public static void OpenAndLocateFile(string path)
        {
            Process.Start("explorer.exe", string.Format("/select,\"{0}\"", path));
        }

        public static void NavigateToWebPage(string url)
        {
            try
            {
                // Usa la clase Process para abrir el navegador predeterminado
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Necesario para abrir URLs en el navegador
                });
            }
            catch (Exception ex)
            {
                XConsole.PrintError("can't open page");
            }
        }
    }
}

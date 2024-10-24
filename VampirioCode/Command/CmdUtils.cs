using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command
{
    public class CmdUtils
    {
        // This fixes an issue with WSL where you can't use absolute paths
        // [DOESN'T WORK]:  wsl -d Ubuntu-test g++ "C:\tests\capitan\untitled 1.cpp"
        // [DOESN'T WORK]:  wsl -d Ubuntu-test g++ "C:/tests/capitan/untitled 1.cpp"
        // [WORKS OK]:      wsl -d Ubuntu-test g++ "../capitan/untitled 1.cpp"
        public static string ToUnixRelativePath(string absoluteFilePath)
        {
            return ("./" + Path.GetRelativePath(AppInfo.BasePath, absoluteFilePath)).Replace("\\", "/");
        }
    }
}

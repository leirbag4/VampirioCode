using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.JDK.Result;

namespace VampirioCode.Command.JDK
{
    public class Java : BaseCmdProgram
    {
        public static string ProgramPath = @"C:\programs_dev\java\jdk-22\bin\java.exe";

        public async Task<RunResult> RunAsync(string filename, List<string> classPath = null)
        {
            RunCmd cmd =    new RunCmd();
            cmd.Filename =  filename;
            cmd.ClassPath = classPath;
            var result =    await cmd.RunAsync();
            CheckCmd(cmd);
            return result;
        }
    }
}

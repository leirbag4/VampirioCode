using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.JDK.Result;
using VampirioCode.SaveData;

namespace VampirioCode.Command.JDK
{
    public class Java : BaseCmdProgram
    {
        public static string ProgramPath = "";//@"C:\programs_dev\java\jdk-22\bin\java.exe";

        public async Task<RunResult> RunAsync(string filename, List<string> classPath = null)
        {
            SetupProgramPaths();

            RunCmd cmd =    new RunCmd();
            cmd.Filename =  filename;
            cmd.ClassPath = classPath;
            SetVariables(cmd);

            var result =    await cmd.RunAsync();
            CheckCmd(cmd);
            return result;
        }

        protected override void SetupProgramPaths()
        {
            ProgramPath = Config.BuildersSettings.JavaJDK.java_exe_path;
        }

        protected override void SetVariables(BaseCmd cmd)
        {

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.JDK.Result;
using VampirioCode.Command.MSVC.Params;
using VampirioCode.SaveData;

namespace VampirioCode.Command.JDK
{
    public class Javac : BaseCmdProgram
    {
        public static string ProgramPath = "";//@"C:\programs_dev\java\jdk-22\bin\javac.exe";

        public async Task<BuildResult> BuildAsync(List<string> sources, string outputDir = "", List<string> classes = null, List<string> classPath = null)
        {
            SetupProgramPaths();

            BuildCmd cmd =  new BuildCmd();
            cmd.Sources =   sources;
            cmd.OutputDir = outputDir;
            cmd.Classes =   classes;
            cmd.ClassPath = classPath;
            var result =    await cmd.BuildAsync();
            CheckCmd(cmd);
            return result;
        }

        public async Task<BuildResult> BuildAsync(BuildCmd cmd)
        {
            SetupProgramPaths();
            SetVariables(cmd);

            var result = await cmd.BuildAsync();
            CheckCmd(cmd);
            return result;
        }

        protected override void SetupProgramPaths()
        {
            ProgramPath = Config.BuildersSettings.JavaJDK.javac_exe_path;
        }

        protected override void SetVariables(BaseCmd cmd)
        {

        }
    }
}

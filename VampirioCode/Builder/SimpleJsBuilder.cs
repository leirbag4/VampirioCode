using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Nodejs;

namespace VampirioCode.Builder
{
    public class SimpleJsBuilder : Builder
    {
        public override void Prepare()
        { 
            TempDir =               AppInfo.TemporaryBuildPath;         // temporary directory ->   \temp_build\
            ProjectDir =            TempDir + projectName + "\\";       // temporary project dir -> \temp_build\proj_name\
            ProgramFile =           ProjectDir + projectName + ".js";   // .js program file ->      \temp_build\proj_name\proj.js
            OutputFilename =        "";
        }

        public override async Task BuildAndRun()
        {
            Prepare();

            // if '\temp_build' dir does not exist, just create it for the first time
            if (!Directory.Exists(TempDir))
                Directory.CreateDirectory(TempDir);

            // if '\temp_build\proj_name' dir does not exist, just create it for the first time
            if (!Directory.Exists(ProjectDir))
                Directory.CreateDirectory(ProjectDir);

            // delete all content of '\temp_build\proj_name\' 
            //FileUtils.DeleteFilesAndDirs(projDirPath);

            // write all code to '\temp_build\proj_name\proj.cs' main program file
            File.WriteAllText(ProgramFile, code);

            // [ COMPILATION PROCESS ]
            Nodejs nodejs = new Nodejs();
            await nodejs.RunAsync(ProgramFile);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.PHP;

namespace VampirioCode.Builder
{
    public class SimplePhpBuilder : Builder
    {
        public SimplePhpBuilder() 
        {
            Name = "Xampp PHP";
            Type = BuilderType.SimplePhp;
        }

        public override void Prepare()
        { 
            TempDir =               AppInfo.TemporaryBuildPath;         // temporary directory ->   \temp_build\
            ProjectDir =            TempDir + projectName + "\\";       // temporary project dir -> \temp_build\proj_name\
            ProgramFile =           ProjectDir + projectName + ".php";  // .php program file ->     \temp_build\proj_name\proj.php
            OutputFilename =        "";
        }

        protected override async Task OnBuildAndRun()
        {
            Prepare();

            // if '\temp_build' dir does not exist, just create it for the first time
            //if (!Directory.Exists(TempDir))
            //    Directory.CreateDirectory(TempDir);

            // if '\temp_build\proj_name' dir does not exist, just create it for the first time
            //if (!Directory.Exists(ProjectDir))
            //    Directory.CreateDirectory(ProjectDir);

            CreateProjectStructure();

            // delete all content of '\temp_build\proj_name\' 
            //FileUtils.DeleteFilesAndDirs(projDirPath);

            // write all code to '\temp_build\proj_name\proj.cs' main program file
            File.WriteAllText(ProgramFile, code);

            // [ COMPILATION PROCESS ]
            PHP php = new PHP();
            var result = await php.RunAsync(ProgramFile);

            CheckResult(result);
        }
    }
}

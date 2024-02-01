using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Nodejs;

namespace VampirioCode.Builder
{
    public class SimpleJsBuilder
    {
        private string projectName;
        private string code = "";

        public void Setup(string projectName, string code)
        {
            this.projectName = projectName;
            this.code = code;
        }

        public async Task Build()
        {
            string tempDir =        AppInfo.TemporaryBuildPath;         // temporary directory ->   \temp_build\
            string projDir =        tempDir + projectName + "\\";       // temporary project dir -> \temp_build\proj_name\
            string programFile =    projDir + projectName + ".js";      // .js program file ->      \temp_build\proj_name\proj.js

            // if '\temp_build' dir does not exist, just create it for the first time
            if (!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir);

            // if '\temp_build\proj_name' dir does not exist, just create it for the first time
            if (!Directory.Exists(projDir))
                Directory.CreateDirectory(projDir);

            // delete all content of '\temp_build\proj_name\' 
            //FileUtils.DeleteFilesAndDirs(projDirPath);

            // write all code to '\temp_build\proj_name\proj.cs' main program file
            File.WriteAllText(programFile, code);

            // [ COMPILATION PROCESS ]
            Nodejs nodejs = new Nodejs();
            await nodejs.RunAsync(programFile);
        }
    }
}

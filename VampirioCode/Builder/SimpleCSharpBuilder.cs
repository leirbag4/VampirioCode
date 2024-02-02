using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Dotnet;
using VampirioCode.IO;
using VampirioCode.SaveData;
using VampirioCode.UI;
using VampirioCode.Utils;

namespace VampirioCode.Builder
{
    public class SimpleCSharpBuilder : Builder
    {
        private string projectName;
        private string code = "";

        public void Setup(string projectName, string code)
        { 
            this.projectName =  projectName;
            this.code =         code;
        }

        public async Task Build()
        {
            string tempDir =        AppInfo.TemporaryBuildPath;         // temporary directory ->   \temp_build\
            string projDir =        tempDir + projectName + "\\";       // temporary project dir -> \temp_build\proj_name\
            string csprojFilePath = projDir + projectName + ".csproj";  // temp .csproj file ->     \temp_build\proj_name\proj.csproj
            string programFile =    projDir + projectName + ".cs";      // .cs program file ->      \temp_build\proj_name\proj.cs
            string outputDir =      projDir + "bin";                    // output binaries dir ->   \temp_build\proj_name\bin

            // if '\temp_build' dir does not exist, just create it for the first time
            if (!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir);

            // if '\temp_build\proj_name' dir does not exist, just create it for the first time
            if (!Directory.Exists(projDir))
                Directory.CreateDirectory(projDir);

            // delete all content of '\temp_build\proj_name\' 
            //FileUtils.DeleteFilesAndDirs(projDirPath);

            // create '\temp_build\proj_name\proj.csproj' project file if does not exist
            //if(!File.Exists(csprojFilePath))
                File.WriteAllText(csprojFilePath, GetCsprojData());

            // write all code to '\temp_build\proj_name\proj.cs' main program file
            File.WriteAllText(programFile, code);

            // [ COMPILATION PROCESS ]
            Dotnet dotnet = new Dotnet();
            await dotnet.RunAsync(csprojFilePath);
        }

        private string GetCsprojData()
        { 
            return  "<Project Sdk=\"Microsoft.NET.Sdk\">\n" +
                    "   <PropertyGroup>\n" +
                    "       <OutputType>Exe</OutputType>\n" +
                    "       <TargetFramework>net8.0</TargetFramework>\n" +
                    "       <ImplicitUsings>enable</ImplicitUsings>\n" +
                    "       <Nullable>enable</Nullable>\n" +
                    "       <OutputPath>bin</OutputPath>" +
                    "   </PropertyGroup>\n" +
                    "</Project>\n";
        }

    }
}

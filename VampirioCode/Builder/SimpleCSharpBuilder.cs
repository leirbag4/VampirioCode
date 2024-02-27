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
        private string csprojFilePath;
        private string outputDir;

        public SimpleCSharpBuilder()
        {
            Type = BuilderType.SimpleCSharp;
        }

        public override void Prepare()
        {
            TempDir =               AppInfo.TemporaryBuildPath;                         // temporary directory ->   \temp_build\
            ProjectDir =            TempDir + projectName + "\\";                       // temporary project dir -> \temp_build\proj_name\
            ProgramFile =           ProjectDir + projectName + ".cs";                   // .cs program file ->      \temp_build\proj_name\proj.cs
            csprojFilePath =        ProjectDir + projectName + ".csproj";               // temp .csproj file ->     \temp_build\proj_name\proj.csproj
            outputDir =             ProjectDir + "bin";                                 // output binaries dir ->   \temp_build\proj_name\bin
            OutputFilename =        outputDir + "\\net8.0\\" + projectName + ".exe";    // output filename ->       \temp_build\proj_name\bin\net8.0\proj.exe
        }

        protected override async Task OnBuildAndRun()
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

            // create '\temp_build\proj_name\proj.csproj' project file if does not exist
            //if(!File.Exists(csprojFilePath))
                File.WriteAllText(csprojFilePath, GetCsprojData());

            // write all code to '\temp_build\proj_name\proj.cs' main program file
            File.WriteAllText(ProgramFile, code);

            // [ COMPILATION PROCESS ]
            Dotnet dotnet = new Dotnet();
            var result = await dotnet.RunAsync(csprojFilePath);

            CheckResult(result);
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

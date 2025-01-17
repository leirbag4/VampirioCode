using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.GnuGppWSL.Params;
using VampirioCode.Command.GnuGppWSL.Result;

namespace VampirioCode.Command.GnuGppWSL
{
    public class BuildCmd : BaseCmd
    {
        /// <summary>
        /// Executable, Shared Library or Static Library
        /// </summary>
        public OutputType OutputType { get; set; } = OutputType.Executable;
        public StandardVersion StandardVersion { get; set; } = StandardVersion.StdCpp17;
        public List<string> Includes { get; set; } = new List<string>();
        public List<string> Sources { get; set; }
        public List<string> LibraryPaths { get; set; } = new List<string>();
        public List<string> LibraryFiles { get; set; } = new List<string>();
        public string OutputFilename { get; set; } = "";

        public List<string> PreprocessorDefinitions { get; set; } = new List<string>();

        public async Task<BuildResult> BuildAsync()
        {
            SetIfExists(OutputTypeInfo.Get(OutputType).Param);

            SetIfExists(StandardVersionInfo.Get(StandardVersion).Param);
            SetPreprocessor(PreprocessorDefinitions); // -D

            //if (CanUse(LibraryPaths) || CanUse(LibraryFiles))
            //{
            //    SetLibPaths(LibraryPaths);
            //    SetLibFiles(LibraryFiles);
            //}

            SetIncludes(Includes);          // -I
            SetLibPaths(LibraryPaths);      // -L
            SetIfExists(Sources.ToArray());
            SetLibFiles(LibraryFiles);      // -l

            SetIfExists("-o", OutputFilename);

            ConfirmProgramPath = false;

            //return await CreateCommand<BuildResult>("wsl", "-d Ubuntu-test g++", cmd.ToString());
            return await CreateCommand<BuildResult>("wsl", $"-d {GnuGppWSL.DistroName} g++", cmd.ToString());
        }

        private void SetIncludes(List<string> includes)
        {
            if ((includes != null) && (includes.Count > 0))
            {
                foreach (string include in includes)
                {
                    string inc = ReplaceVars(include, Environment.OperatingSystemType.Linux);
                    cmd += "-I\"" + _fixLastEscapeBar(inc) + "\" ";
                }
            }
        }

        private void SetLibPaths(List<string> libraries)
        {
            if ((libraries != null) && (libraries.Count > 0))
            {
                foreach (string library in libraries)
                {
                    string lib = ReplaceVars(library, Environment.OperatingSystemType.Linux);
                    cmd += "-L\"" + _fixLastEscapeBar(lib) + "\" ";
                }
            }
        }

        private void SetLibFiles(List<string> libraries)
        {
            if ((libraries != null) && (libraries.Count > 0))
            {
                foreach (string library in libraries)
                {
                    //string lib = ReplaceVars(library, Environment.OperatingSystemType.Linux);
                    //cmd += "-l\"" + _fixLastEscapeBar(lib) + "\" ";
                    cmd += "-l\"" + library + "\" ";
                }
            }
        }

        private void SetPreprocessor(List<string> preprocessorDefinitions)
        {
            if ((preprocessorDefinitions != null) && (preprocessorDefinitions.Count > 0))
            {
                foreach (string directive in preprocessorDefinitions)
                    cmd += "-D\"" + _fixLastEscapeBar(directive) + "\" ";
            }
        }

        protected override void OnDataReceived(string data)
        {
            Println(data);
        }

        protected override void OnErrorDataReceived(string data)
        {
            PrintError(data);
        }

        protected override void OnComplete(BaseResult result)
        {
            Println("[complete]");
        }

    }
}

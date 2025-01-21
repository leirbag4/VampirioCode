using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Clang.Result;
using VampirioCode.Command.Clang.Params;
using VampirioCode.Properties;

namespace VampirioCode.Command.Clang
{
    public class BuildCmd : BaseCmd
    {

        public StandardVersion StandardVersion { get; set; } = StandardVersion.StdCpp17;
        public List<string> Includes { get; set; } = new List<string>();
        public List<string> Sources { get; set; }
        public List<string> LibraryPaths { get; set; } = new List<string>();
        public List<string> LibraryFiles { get; set; } = new List<string>();
        public OutputType OutputType { get; set; } = OutputType.Executable;
        public string OutputFilename { get; set; } = "";
        public List<string> PreprocessorDefinitions { get; set; } = new List<string>();
        //public string OutputObjsDir { get; set; } = "";

        public async Task<BuildResult> BuildAsync()
        {
            SetIfExists(OutputTypeInfo.Get(OutputType).Param);
            //SetIfExists(OutputTypeInfo.Get(OutputType).Param2);

            SetIfExists(Sources.ToArray());
            SetIfExists(StandardVersionInfo.Get(StandardVersion).Param);
            SetPreprocessor(PreprocessorDefinitions); // -D

            SetIncludes(Includes);

            if (CanUse(LibraryPaths))   SetLibPaths(LibraryPaths);
            if (CanUse(LibraryFiles))   SetLibFiles(LibraryFiles);

            SetIfExists("-o", OutputFilename);

            return await CreateCommand<BuildResult>(_quotes(Clang.ProgramPath), cmd.Trim());
        }

        private void SetPreprocessor(List<string> preprocessorDefinitions)
        {
            if ((preprocessorDefinitions != null) && (preprocessorDefinitions.Count > 0))
            {
                foreach (string directive in preprocessorDefinitions)
                    cmd += "-D\"" + _fixLastEscapeBar(directive) + "\" ";
            }
        }

        private void SetIncludes(List<string> includes)
        {
            if ((includes != null) && (includes.Count > 0))
            {
                foreach (string include in includes)
                    cmd += "-I\"" + _fixLastEscapeBar(include) + "\" ";
            }
        }

        private void SetLibPaths(List<string> libraries)
        {
            if ((libraries != null) && (libraries.Count > 0))
            {
                foreach (string lib in libraries)
                    cmd += "-L\"" + _fixLastEscapeBar(lib) + "\" ";
            }
        }

        private void SetLibFiles(List<string> libraries)
        {
            if ((libraries != null) && (libraries.Count > 0))
            {
                foreach (string lib in libraries)
                    cmd += "-l\"" + _fixLastEscapeBar(lib) + "\" ";
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

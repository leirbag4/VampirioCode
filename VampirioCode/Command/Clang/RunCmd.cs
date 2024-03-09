using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Clang.Result;

namespace VampirioCode.Command.Clang
{
    public class RunCmd : BaseCmd
    {
        public List<string> LibraryPaths { get; set; } = new List<string>();
        public string Filename { get; set; } = ""; 

        public async Task<RunResult> RunAsync()
        {
            AutoTriggerErrors = false;

            // If you compile your program with anly library like for example 'libclang.lib'
            // then the program won't run because you need to setup the environment variables
            // PATH and LIB. So for this case, a batch file called 'run.bat' will be created and
            // it will set those variables but also launch the program
            // The call to the program is -> \path\run.bat
            if (CanUse(LibraryPaths))
            {
                string runBatFilename = Path.GetDirectoryName(Filename) + "\\run.bat";
                CreateRunHelper(runBatFilename);
                //LogParams = false;
                return await CreateCommand<RunResult>(runBatFilename, "");
            }
            // The call to the program is -> \path\app.exe
            else
            {
                LogParams = false;
                return await CreateCommand<RunResult>(Filename, "");
            }
        }

        private void CreateRunHelper(string runBatFilename)
        {
            string batFileContent = $":: This file set the environment variables needed by Clang++\n"+
$"::such as PATH and LIB. You can compile without them but not run the program\n" +
$"@echo off\n" +
$"set PATH={Path.GetDirectoryName(Clang.ProgramPath)}\n" +
$"set LIB={string.Join(";", LibraryPaths)}\n" +
$"call {_quotes(Filename)}";

            File.WriteAllText(runBatFilename, batFileContent);
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
            //Println("[complete]");
        }

    }
}

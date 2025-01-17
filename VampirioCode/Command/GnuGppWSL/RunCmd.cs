using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.GnuGppWSL.Result;
using VampirioCode.Properties;
using VampirioCode.UI;

namespace VampirioCode.Command.GnuGppWSL
{
    public class RunCmd : BaseCmd
    {
        /// <summary>
        /// Executable file to be run
        /// </summary>
        public string Filename { get; set; } = "";

        /// <summary>
        /// Adds libraries like 'tester.so', 'xxx.so' to linux internal 
        /// variable for libraries 'LD_LIBRARY_PATH'
        /// </summary>
        public List<string> LibraryPaths { get; set; } = new List<string>();

        public async Task<RunResult> RunAsync()
        {
            LogParams = true;

            ConfirmProgramPath = false;

            if (CanUse(LibraryPaths))
            {
                SetLibraryPaths(LibraryPaths);
                return await CreateCommand<RunResult>("wsl", "-d Ubuntu-test", "bash -c \"" + cmd + " && '" + Filename + "'\"");
            }
            else
                return await CreateCommand<RunResult>("wsl", "-d Ubuntu-test", _quotes(Filename));
        }

        private void SetLibraryPaths(List<string> libPaths)
        {
            if (CanUse(libPaths))
            {
                cmd = "export LD_LIBRARY_PATH=";

                foreach (string lib in libPaths)
                {
                    //XConsole.Alert(lib);
                    string library = ReplaceVars(lib, Environment.OperatingSystemType.Linux);
                    cmd += $"'{library}':";
                }
                cmd = cmd.TrimEnd(':');
            }
        }

        protected bool CanUse(List<string> list)
        {
            return ((list != null) && (list.Count > 0));
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

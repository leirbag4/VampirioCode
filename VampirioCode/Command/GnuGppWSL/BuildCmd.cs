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
        public StandardVersion StandardVersion { get; set; } = StandardVersion.StdCpp17;

        public List<string> Sources { get; set; }

        public string OutputFilename { get; set; } = "";

        public async Task<BuildResult> BuildAsync()
        {
            SetIfExists(Sources.ToArray());
            SetIfExists(StandardVersionInfo.Get(StandardVersion).Param);
            SetIfExists("-o", OutputFilename);

            return await CreateCommand<BuildResult>("wsl", "-d Ubuntu-test g++", cmd.ToString());
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

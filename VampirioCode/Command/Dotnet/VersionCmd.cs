using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VampirioCode.Command.Dotnet.Models;
using VampirioCode.Command.Dotnet.Params;
using VampirioCode.Command.Dotnet.Result;

namespace VampirioCode.Command.Dotnet
{
    public class VersionCmd : BaseCmd
    {
        private string version = "";

        public async Task<VersionResult> VersionAsync()
        {
            return await CreateCommand<VersionResult>("dotnet", "--version", cmd.Trim());
        }

        protected override void OnDataReceived(string data)
        {
            Println("data: " + data);

            if (data.Length > 0)
            {
                if (int.TryParse(data[0].ToString(), out _))
                    version = data;
            }
        }

        protected override void OnErrorDataReceived(string data)
        {
            PrintError("err: " + data);
        }

        protected override void OnComplete(BaseResult result)
        {
            ((VersionResult)result).Version = version;
        }

    }
}
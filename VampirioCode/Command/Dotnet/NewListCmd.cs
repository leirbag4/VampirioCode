using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Dotnet.Models;
using VampirioCode.Command.Dotnet.Params;
using VampirioCode.Command.Dotnet.Result;
using VampirioCode.Command.Dotnet.Utils;
using VampirioCode.UI;

namespace VampirioCode.Command.Dotnet
{
    public class NewListCmd : BaseCmd
    {
        /*
        dotnet new list [<TEMPLATE_NAME>] 
        [--author <AUTHOR>] 
        [-lang|--language {"C#"|"F#"|VB}]
        [--tag <TAG>] 
        [--type <TYPE>] 
        [--columns <COLUMNS>] 
        [--columns-all]
        [-o|--output <output>] 
        [--project <project>] 
        [--ignore-constraints]
        [-d|--diagnostics] 
        [--verbosity <LEVEL>] [-h|--help]
         */

        /// <summary>
        /// Filters templates based on template author. Partial match is supported. Available since .NET SDK 5.0.300.
        /// </summary>
        public string Author { get; set; } = "";
        /// <summary>
        /// Filters templates based on language supported by the template. The language accepted varies by the template. Not valid for some templates.
        /// </summary>
        public Language Language { get; set; } = Params.Language.Default;
        /// <summary>
        /// Filters templates based on template tags. To be selected, a template must have at least one tag that exactly matches the criteria. Available since .NET SDK 5.0.300.
        /// </summary>
        public string Tag { get; set; } = "";
        /// <summary>
        /// Filters templates based on template type. Predefined values are project, item, and solution.
        /// </summary>
        public string Type { get; set; } = "";
        /// <summary>
        /// Enables diagnostic output. Available since .NET SDK 7.0.100.
        /// </summary>
        public bool Diagnostics { get; set; } = false;
        /// <summary>
        /// Sets the verbosity level of the command. Allowed values are q[uiet], m[inimal], n[ormal], and diag[nostic]. Available since .NET SDK 7.0.100.
        /// </summary>
        public Verbosity Verbosity { get; set; } = Verbosity.Default;

        private List<string> dataArr = null;

        public async Task<NewListResult> NewListAsync()
        {
            dataArr = new List<string>();

            SetIfExists("--author",         Author);
            SetIfExists("--laguage",        LanguageInfo.Get(Language).Param);
            SetIfExists("--tag",            Tag);
            SetIfExists("--type",           Type);
                    Set("--diagnostics",    Diagnostics);
            SetIfExists("--verbosity",      VerbosityInfo.Get(Verbosity).Param);

            ConfirmProgramPath = false;

            return await CreateCommand<NewListResult>("dotnet", "new list", "--columns-all", cmd.Trim());
        }

        protected override void OnDataReceived(string data)
        {
            dataArr.Add(data);
        }

        protected override void OnErrorDataReceived(string data)
        {
            PrintError("err: " + data);
        }

        protected override void OnComplete(BaseResult result)
        {
            TableResultParser table = new TableResultParser();
            List<Template> templates = new List<Template>();
            table.Parse(dataArr);

            if (table.Error)
            {
                CallError(table.ErrorInfo);
                return;
            }

            foreach (var row in table.Rows)
            {
                string[] items = row.Items;
                templates.Add(new Template(items[0], items[1], LangUtils.SplitLanguages(items[2]), items[3], items[4], items[5]));
            }

            ((NewListResult)result).Templates = templates.ToArray();
            Println("[complete]");
        }
    }
}

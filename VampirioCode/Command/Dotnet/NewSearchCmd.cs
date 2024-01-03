using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using VampirioCode.Command.Dotnet.Models;
using VampirioCode.Command.Dotnet.Params;
using VampirioCode.Command.Dotnet.Result;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using VampirioCode.UI;
using VampirioCode.Command.Dotnet.Utils;

namespace VampirioCode.Command.Dotnet
{
    public class NewSearchCmd : BaseCmd
    {
        /*
            dotnet new search [<TEMPLATE_NAME>] 
            [--author <AUTHOR>] 
            [-lang|--language {"C#"|"F#"|VB}]
            [--package <PACKAGE>] 
            [--tag <TAG>] 
            [--type <TYPE>]
            [--columns <COLUMNS>] 
            [--columns-all]
            [-d|--diagnostics] 
            [--verbosity <LEVEL>] 
            [-h|--help]
         */

        /// <summary>
        /// If the argument is specified, only templates containing <TEMPLATE_NAME> in the template name or short name will be shown.
        /// The argument is mandatory when --author, --language, --package, --tag or --type options are not specified.
        /// </summary>
        public string TemplateName { get; set; } = "";
        /// <summary>
        /// Filters templates based on NuGet package ID. Partial match is supported.
        /// </summary>
        public string Package { get; set; } = "";
        /// <summary>
        /// Filters templates based on template author. Partial match is supported.
        /// </summary>
        public string Author { get; set; } = "";
        /// <summary>
        /// Filters templates based on language supported by the template. The language accepted varies by the template. Not valid for some templates.
        /// </summary>
        public Language Language { get; set; } = Params.Language.Default;
        /// <summary>
        /// Filters templates based on template tags. To be selected, a template must have at least one tag that exactly matches the criteria.
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

        public async Task<NewSearchResult> NewSearchAsync()
        {
            dataArr = new List<string>();

            SetIfExists("--package",        Package);
            SetIfExists("--author",         Author);
            SetIfExists("--laguage",        LanguageInfo.Get(Language).Param);
            SetIfExists("--tag",            Tag);
            SetIfExists("--type",           Type);
                    Set("--diagnostics",    Diagnostics);
            SetIfExists("--verbosity",      VerbosityInfo.Get(Verbosity).Param);

            return await CreateCommand<NewSearchResult>("dotnet", "new search \"" + TemplateName + "\"", "--columns-all", cmd.Trim());
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
            TableResultParser table =   new TableResultParser();
            List<STemplate> templates =  new List<STemplate>();
            table.Parse(dataArr);

            if (table.Error)
            {
                CallError(table.ErrorInfo);
                return;
            }


            foreach (var row in table.Rows)
            {
                string[] items = row.Items;
                templates.Add(new STemplate(items[0], items[1], items[2], LangUtils.SplitLanguages(items[3]), items[4], items[5], items[6], items[7], items[8]));
            }

            ((NewSearchResult)result).Templates = templates.ToArray();
            Println("[complete]");
        }


    }
}

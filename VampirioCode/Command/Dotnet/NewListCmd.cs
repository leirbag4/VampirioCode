using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Dotnet.Models;
using VampirioCode.Command.Dotnet.Params;
using VampirioCode.Command.Dotnet.Result;
using static System.Windows.Forms.AxHost;

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

        private List<Template> _templates;
        private int state = 0;

        public async Task<NewListResult> NewListAsync()
        {
            _templates = new List<Template>();
            state = 0;

            SetIfExists("--author",         Author);
            SetIfExists("--laguage",        LanguageInfo.Get(Language).Param);
            SetIfExists("--tag",            Tag);
            SetIfExists("--type",           Type);
                    Set("--diagnostics",    Diagnostics);
            SetIfExists("--verbosity",      VerbosityInfo.Get(Verbosity).Param);

            return await CreateCommand<NewListResult>("dotnet", "new list", "--columns-all", cmd.Trim());
        }

        protected override void OnDataReceived(string data)
        {
            //Println("data: " + data);

            try
            {
                if (state == 0)
                {
                    // first find any '-' dividing titles and data
                    if (data.IndexOf("----") != -1)
                        state = 1;
                }
                else if (state == 1)
                {
                    // next line will contain the column data
                    string[] arr = data.Trim().Split(new[] { "  " }, StringSplitOptions.RemoveEmptyEntries);

                    // columns ->   Template Name | Short Name | Author | Tags
                    if (arr.Length == 4)
                    {
                        _templates.Add(new Template() { Name = arr[0].Trim(), ShortName = arr[1].Trim(), Author = arr[2].Trim(), Tags = arr[3].Trim(), Languages = new Language[0] });
                    }
                    // columns ->   Template Name | Short Name | Type | Author | Tags
                    else if (arr.Length == 5)
                    {
                        _templates.Add(new Template() { Name = arr[0].Trim(), ShortName = arr[1].Trim(), Type = arr[2].Trim(), Author = arr[3].ToString(), Tags = arr[4].Trim(), Languages = new Language[0] });
                    }
                    // columns ->   Template Name | Short Name | Language | Type | Author | Tags
                    else if (arr.Length == 6)
                    {
                        string[] str = arr[2].Split(',');
                        List<Language> langs = new List<Language>();
                        foreach (string s in str)
                            langs.Add(ToLanguage(s));
                        _templates.Add(new Template() { Name = arr[0].Trim(), ShortName = arr[1].Trim(), Languages = langs.ToArray(), Type = arr[3].Trim(), Author = arr[4].ToString(), Tags = arr[5].Trim() });
                    }
                }
            }
            catch (Exception e) 
            {
                CallError("Can't parse 'dotnet new list' item", e);
            }
                
        }

        private Language ToLanguage(string str)
        {
            str = str.ToLower();

                 if (str.IndexOf("c#") != -1) return Language.CSharp;
            else if (str.IndexOf("f#") != -1) return Language.FSharp;
            else if (str.IndexOf("vb") != -1) return Language.VisualBasic;
            return Language.Default;
        }

        protected override void OnErrorDataReceived(string data)
        {
            PrintError("err: " + data);
        }

        protected override void OnComplete(BaseResult result)
        {
            ((NewListResult)result).Templates = _templates.ToArray();
            Println("[complete]");
        }
    }
}

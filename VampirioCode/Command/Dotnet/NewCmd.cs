using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Dotnet.Params;
using VampirioCode.Command.Dotnet.Result;

namespace VampirioCode.Command.Dotnet
{
    /*
        dotnet new <TEMPLATE> 
        [-n|--name <OUTPUT_NAME>] 
        [-o|--output <OUTPUT_DIRECTORY>] 
        [--project <PROJECT_PATH>]
        [-f|--framework <FRAMEWORK>] 
        [-lang|--language {"C#"|"F#"|VB}]
        [--verbosity <LEVEL>]
        [-d|--diagnostics] 
        [--dry-run] 
        [--force] 
        [--no-update-check]
        [Template options]
     */

    public class NewCmd : BaseCmd
    {
        /// <summary>
        /// The template to instantiate when the command is invoked. Each template might have specific options you can pass.
        /// </summary>
        public string Template { get; set; } = "";
        /// <summary>
        /// Directory location to place the generated output. The default is the current directory.
        /// </summary>
        public string Output { get; set; } = "";
        /// <summary>
        /// The name for the created output. If no name is specified, the name of the current directory is used.
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// The project that the template is added to. This project is used for context evaluation. If not specified, the project in the current or parent directories will be used.
        /// Available since .NET SDK 7.0.100.
        /// </summary>
        public string Project { get; set; } = "";
        /// <summary>
        /// Specifies the target framework. It expects a target framework moniker (TFM). Examples: "net6.0", "net7.0-macos". This value will be reflected in the project file.
        /// </summary>
        public Framework Framework { get; set; } = Framework.Default;
        /// <summary>
        /// The language of the template to create. The language accepted varies by the template
        /// (see defaults in the arguments section). Not valid for some templates.
        /// </summary>
        public Language Language { get; set; } = Language.Default;
        /// <summary>
        /// Sets the verbosity level of the command. Allowed values are q[uiet], m[inimal], n[ormal], and diag[nostic]. 
        /// Available since .NET SDK 7.0.100.
        /// </summary>
        public Verbosity Verbosity { get; set; } = Verbosity.Default;
        /// <summary>
        /// Enables diagnostic output. Available since .NET SDK 7.0.100.
        /// </summary>
        public bool Diagnostics { get; set; } = false;
        /// <summary>
        /// Displays a summary of what would happen if the given command were run if it
        /// would result in a template creation. Available since .NET Core 2.2 SDK.
        /// </summary>
        public bool DryRun { get; set; } = false;
        /// <summary>
        /// Forces content to be generated even if it would change existing files.
        /// This is required when the template chosen would override existing files in the output directory.
        /// </summary>
        public bool Force { get; set; } = false;
        /// <summary>
        /// Disables checking for template package updates when instantiating a template. Available since .NET SDK 6.0.100.
        /// When instantiating the template from a template package that was installed by using dotnet new --install,
        /// dotnet new checks if there is an update for the template. Starting with .NET 6, no update checks are done for
        /// .NET default templates. To update .NET default templates, install the patch version of the .NET SDK.
        /// </summary>
        public bool NoUpdateCheck { get; set; } = false;


        public async Task<NewResult> NewAsync()
        {
            SetRequire(Template,                nameof(Template));
            SetIfExists("--output",             Output);
            SetIfExists("--name",               Name);
            SetIfExists("--project",            Project);
            SetIfExists("--framework",          FrameworkInfo.Get(Framework).Param);
            SetIfExists("--laguage",            LanguageInfo.Get(Language).Param);
            SetIfExists("--verbosity",          VerbosityInfo.Get(Verbosity).Param);
                    Set("--diagnostics",        Diagnostics);
                    Set("--dry-run",            DryRun);
                    Set("--force",              Force);
                    Set("--no-update-check",    NoUpdateCheck);

            return await CreateCommand<NewResult>("dotnet", "new", cmd.Trim());
        }

        protected override void OnDataReceived(string data)
        {
            Println("data: " + data);
        }

        protected override void OnErrorDataReceived(string data)
        {
            PrintError("err: " + data);
        }

        protected override void OnComplete(BaseResult result)
        {
            Println("[complete]");
        }
    }
}

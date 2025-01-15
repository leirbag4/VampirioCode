using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Dotnet.Params;
using VampirioCode.Command.Dotnet.Result;
using VampirioCode.UI;

namespace VampirioCode.Command.Dotnet
{
    public class RunCmd : BaseCmd
    {
        /*
        dotnet run 
      x [-a|--arch <ARCHITECTURE>] 
        [-c|--configuration <CONFIGURATION>]
        [-f|--framework <FRAMEWORK>] 
        [--force] 
        [--interactive]
        [--launch-profile <NAME>] 
        [--no-build]
        [--no-dependencies] 
        [--no-launch-profile] 
        [--no-restore]
      x [--os <OS>] 
        [--project <PATH>] 
        [-r|--runtime <RUNTIME_IDENTIFIER>]
        [--tl:[auto|on|off]] 
        [-v|--verbosity <LEVEL>]
        [[--] [application arguments]]
         */

        /// <summary>
        /// Defines the build configuration. The default for most projects is Debug, but you can override the build configuration settings in your project.
        /// </summary>
        public string Configuration { get; set; } = ""; // can be 'Debug', 'Release', 'CustomConfig', 'etc'
        /// <summary>
        /// Builds and runs the app using the specified framework. The framework must be specified in the project file.
        /// </summary>
        public Framework Framework { get; set; } = Framework.Default;
        /// <summary>
        /// Forces all dependencies to be resolved even if the last restore was successful. Specifying this flag is the same as deleting the project.assets.json file.
        /// </summary>
        public bool Force { get; set; } = false;
        /// <summary>
        /// Allows the command to stop and wait for user input or action. For example, to complete authentication. Available since .NET Core 3.0 SDK.
        /// </summary>
        public bool Interactive { get; set; } = false;
        /// <summary>
        /// The name of the launch profile (if any) to use when launching the application. Launch profiles are defined in the launchSettings.json file and are typically called Development, Staging, and Production. For more information, see Working with multiple environments.
        /// </summary>
        public string LaunchProfile { get; set; } = "";
        /// <summary>
        /// Doesn't build the project before running. It also implicitly sets the --no-restore flag.
        /// </summary>
        public bool NoBuild { get; set; } = false;
        /// <summary>
        /// When restoring a project with project-to-project (P2P) references, restores the root project and not the references.
        /// </summary>
        public bool NoDependencies { get; set; } = false;
        /// <summary>
        /// Doesn't try to use launchSettings.json to configure the application.
        /// </summary>
        public bool NoLaunchProfile { get; set; } = false;
        /// <summary>
        /// Doesn't execute an implicit restore when running the command.
        /// </summary>
        public bool NoRestore { get; set; } = false;
        /// <summary>
        /// Specifies the path of the project file to run (folder name or full path). If not specified, it defaults to the current directory.
        /// </summary>
        public string ProjectPath { get; set; } = "";
        /// <summary>
        /// Specifies the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the RID catalog.
        /// </summary>
        public RuntimeIdentifier Runtime { get; set; } = RuntimeIdentifier.Default;
        /// <summary>
        /// Specifies whether the terminal logger should be used for the build output. The default is auto, which first verifies the environment
        /// before enabling terminal logging. The environment check verifies that the terminal is capable of using modern output features and
        /// isn't using a redirected standard output before enabling the new logger. 
        /// [on] skips the environment check and enables terminal logging. 
        /// [off] skips the environment check and uses the default console logger.
        /// </summary>
        public TerminalLogger TerminalLogger { get; set; } = TerminalLogger.Default;
        /// <summary>
        /// Sets the verbosity level of the command. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic]. The default is minimal. For more information, see 
        /// </summary>
        public Verbosity Verbosity { get; set; } = Verbosity.Default;
        /// <summary>
        /// Arguments passed to the running program
        /// </summary>
        public string[] Arguments { get; set; } = new string[0];


        private bool _dataReceived = false;

        public async Task<RunResult> RunAsync()
        {
            SetIfExists("--configuration",      Configuration);
            SetIfExists("--framework",          FrameworkInfo.Get(Framework).Param);
                    Set("--force",              Force);
                    Set("--interactive",        Interactive);
            SetIfExists("--launch-profile",     LaunchProfile);
                    Set("--no-build",           NoBuild);
                    Set("--no-dependencies",    NoDependencies);
                    Set("--no-launch-profile",  NoLaunchProfile);
                    Set("--no-restore",         NoRestore);
            SetIfExists("--runtime",            RuntimeIdentifierInfo.Get(Runtime).Param);
                    if(TerminalLogger != TerminalLogger.Default) 
                    Set("--tl",                 TerminalLogger.ToString().ToLower());
            SetIfExists("--verbosity",          VerbosityInfo.Get(Verbosity).Param);
            SetIfExists("--project",            ProjectPath);
            SetIfExists(Arguments);

            ConfirmProgramPath = false;

            return await CreateCommand<RunResult>("dotnet", "run", cmd.Trim());
        }

        protected override void OnDataReceived(string data)
        {
            if (!_dataReceived)
            {
                XConsole.Clear();
                _dataReceived = true;
            }

            Println(data);
        }

        protected override void OnErrorDataReceived(string data)
        {
            PrintError("err: " + data);
        }

        protected override void OnComplete(BaseResult result)
        {
            //Println("[complete]");
        }
    }
}

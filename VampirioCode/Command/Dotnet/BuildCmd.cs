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
    public class BuildCmd : BaseCmd
    {
        /*
        dotnet build -h
        
        Description:
          .NET Builder

        Usage:
          dotnet build [<PROJECT | SOLUTION>...] [options]

        Arguments:
          <PROJECT | SOLUTION>  The project or solution file to operate on. If a file is not specified, the command will search
                                the current directory for one.

        Options:
          --ucr, --use-current-runtime         Use current runtime as the target runtime.
          -f, --framework <FRAMEWORK>          The target framework to build for. The target framework must also be specified
                                               in the project file.
          -c, --configuration <CONFIGURATION>  The configuration to use for building the project. The default for most projects
                                               is 'Debug'.
          -r, --runtime <RUNTIME_IDENTIFIER>   The target runtime to build for.
          --version-suffix <VERSION_SUFFIX>    Set the value of the $(VersionSuffix) property to use when building the project.
          --no-restore                         Do not restore the project before building.
          --interactive                        Allows the command to stop and wait for user input or action (for example to
                                               complete authentication).
          -v, --verbosity <LEVEL>              Set the MSBuild verbosity level. Allowed values are q[uiet], m[inimal],
                                               n[ormal], d[etailed], and diag[nostic].
          --debug
          -o, --output <OUTPUT_DIR>            The output directory to place built artifacts in.
          --artifacts-path <ARTIFACTS_DIR>     The artifacts path. All output from the project, including build, publish, and
                                               pack output, will go in subfolders under the specified path.
          --no-incremental                     Do not use incremental building.
          --no-dependencies                    Do not build project-to-project references and only build the specified project.
          --nologo                             Do not display the startup banner or the copyright message.
          --sc, --self-contained               Publish the .NET runtime with your application so the runtime doesn't need to be
                                               installed on the target machine.
                                               The default is 'false.' However, when targeting .NET 7 or lower, the default is
                                               'true' if a runtime identifier is specified.
          --no-self-contained                  Publish your application as a framework dependent application. A compatible .NET
                                               runtime must be installed on the target machine to run your application.
          -a, --arch <ARCH>                    The target architecture.
          --os <OS>                            The target operating system.
          --disable-build-servers              Force the command to ignore any persistent build servers.
          -?, -h, --help                       Show command line help.
         */



        public string ProjectPath { get; set; } = "";
        public string SolutionPath { get; set; } = "";

        public Framework Framework { get; set; } = Framework.None;
        public string Configuration { get; set; } = ""; // can be 'Debug', 'Release', 'CustomConfig', 'etc'
        public RuntimeIdentifier RuntimeIdentifier { get; set; } = RuntimeIdentifier.None;
        public Verbosity Verbosity { get; set; } = Verbosity.None;
        public string Output { get; set; } = "";
        public string ArtifactsPath { get; set; } = "";
        public string VersionSuffix { get; set; } = "";
        public bool UseCurrentRuntime { get; set; } = false;
        public bool NoRestore { get; set; } = false;
        public bool Interactive { get; set; } = false;
        public bool Debug { get; set; } = false;
        public bool NoIncremental { get; set; } = false;
        public bool NoDependencies { get; set; } = false;
        public bool NoLogo { get; set; } = false;
        public bool SelfContained { get; set; } = false;
        public bool NoSelfContained { get; set; } = false;
        public bool DisableBuildServers { get; set; } = false;

        public async Task<BuildResult> BuildAsync()
        {
            SetAnyIfExists(ProjectPath, SolutionPath);

            SetIfExists("--framework",      FrameworkInfo.Get(Framework).Param);
            SetIfExists("--configuration",  Configuration);
            SetIfExists("--runtime",        RuntimeIdentifierInfo.Get(RuntimeIdentifier).Param);
            SetIfExists("--version-suffix", VersionSuffix);
            SetIfExists("--verbosity",      VerbosityInfo.Get(Verbosity).Param);
            SetIfExists("--output",         Output);
            SetIfExists("--artifacts-path", ArtifactsPath);

            Set("--use-current-runtime",    UseCurrentRuntime);
            Set("--no-restore",             NoRestore);
            Set("--interactive",            Interactive);
            Set("--debug",                  Debug);
            Set("--no-incremental",         NoIncremental);
            Set("--no-dependencies",        NoDependencies);
            Set("--nologo",                 NoLogo);
            Set("--self-contained",         SelfContained);
            Set("--no-self-contained",      NoSelfContained);
            Set("--disable-build-servers",  DisableBuildServers);


            //return await CreateCommand<BuildResult>("build", @"C:\dotnet_test\projects\Capitan");
            return await CreateCommand<BuildResult>("build", cmd.Trim());
        }

        protected override void OnDataReceived(string data)
        {
            Println("data: " + data);
        }

        protected override void OnErrorDataReceived(string data)
        {
            Println("err: " + data);
        }

        protected override void OnComplete(BaseResult result)
        {
            Println("[complete]");
        }
    }
}

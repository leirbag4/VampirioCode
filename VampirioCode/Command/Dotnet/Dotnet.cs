using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Dotnet.Result;
using VampirioCode.Command.Dotnet.Params;
using VampirioCode.UI;

namespace VampirioCode.Command.Dotnet
{
    public class Dotnet : BaseCmdProgram
    {

        /// <summary>
        /// Compile code calling 'dotnet build'
        /// </summary>
        /// <param name="projectOrSolution">The project (c:\path\myproj.csproj), solution (c:\path\mysol.sln ) or project directory (c:\myproj) path. If nothing is specified (e.g: empty string) the command will search the current directory for one.</param>
        /// <param name="output">The output directory for the files</param>
        /// <param name="configuration">Can be 'Debug', 'Release' or 'AnyCustomConfig'</param>
        /// <param name="runtime">The target runtime to build for. E.g: you can build from windows to linux.</param>
        /// <returns></returns>
        public async Task<BuildResult> BuildAsync(string projectOrSolution, string output = "", string configuration = "Debug", RuntimeIdentifier runtime = RuntimeIdentifier.Default)
        { 
            BuildCmd cmd =          new BuildCmd();
            cmd.ProjectPath =       projectOrSolution;
            cmd.Output =            output;
            cmd.Runtime = runtime;

            var result = await cmd.BuildAsync(); CheckCmd(cmd);
            return result;
        }

        public async Task<BuildResult> BuildAsync(BuildCmd cmd)
        {
            var result = await cmd.BuildAsync();
            CheckCmd(cmd);
            return result;
        }

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <param name="template">The template to instantiate when the command is invoked. Each template might have specific options you can pass.</param>
        /// <param name="output">The project that the template is added to. This project is used for context evaluation. If not specified, the project in the current or parent directories will be used. Available since .NET SDK 7.0.100.</param>
        /// <param name="name">Directory location to place the generated output. The default is the current directory.</param>
        /// <param name="framework">Specifies the target framework. It expects a target framework moniker (TFM). Examples: "net6.0", "net7.0-macos". This value will be reflected in the project file.</param>
        /// <returns></returns>
        public async Task<NewResult> NewAsync(string template, string output = "", string name = "", Framework framework = Framework.Default)
        {
            NewCmd cmd = new NewCmd();
            cmd.Template =  template;
            cmd.Output =    output;
            cmd.Name =      name;
            cmd.Framework = framework;
            
            var result = await cmd.NewAsync();
            CheckCmd(cmd);
            return result;
        }

        public async Task<NewResult> NewAsync(NewCmd cmd)
        {
            var result = await cmd.NewAsync();
            CheckCmd(cmd);
            return result;
        }

        /// <summary>
        /// The dotnet new list command lists available templates to use with dotnet new.
        /// </summary>
        /// <param name="author">Filters templates based on template author. Partial match is supported. Available since .NET SDK 5.0.300.</param>
        /// <param name="tags">Filters templates based on template tags. To be selected, a template must have at least one tag that exactly matches the criteria. Available since .NET SDK 5.0.300.</param>
        /// <param name="type">Filters templates based on template type. Predefined values are project, item, and solution.</param>
        /// <param name="language">Filters templates based on language supported by the template. The language accepted varies by the template. Not valid for some templates.</param>
        /// <returns></returns>
        public async Task<NewListResult> NewListAsyc(string author = "", string tags = "", string type = "", Language language = Language.Default)
        {
            NewListCmd cmd = new NewListCmd();
            cmd.Author =    author;
            cmd.Tag =       tags;
            cmd.Type=       type;
            cmd.Language =  language;
            var result =    await cmd.NewListAsync();
            CheckCmd(cmd);
            return result;
        }

        public async Task<NewListResult> NewListAsyc(NewListCmd cmd)
        {
            var result = await cmd.NewListAsync();
            CheckCmd(cmd);
            return result;
        }

        /// <summary>
        /// Runs source code without any explicit compile or launch commands.
        /// </summary>
        /// <param name="projectPath">Specifies the path of the project file to run (folder name or full path). If not specified, it defaults to the current directory.</param>
        /// <param name="configuration">Defines the build configuration. The default for most projects is Debug, but you can override the build configuration settings in your project.</param>
        /// <param name="launchProfile">The name of the launch profile (if any) to use when launching the application. Launch profiles are defined in the launchSettings.json file and are typically called Development, Staging, and Production. For more information, see Working with multiple environments.</param>
        /// <param name="runtime">Specifies the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the RID catalog.</param>
        /// <param name="force">Forces all dependencies to be resolved even if the last restore was successful. Specifying this flag is the same as deleting the project.assets.json file.</param>
        /// <param name="noDependencies">When restoring a project with project-to-project (P2P) references, restores the root project and not the references.</param>
        /// <param name="noLaunchProfile">Doesn't try to use launchSettings.json to configure the application.</param>
        /// <param name="noRestore">Doesn't execute an implicit restore when running the command.</param>
        /// <returns></returns>
        public async Task<RunResult> RunAsync(string projectPath, string[] arguments = null, string configuration = "Debug", string launchProfile = "", RuntimeIdentifier runtime = RuntimeIdentifier.Default, bool force = false, bool noDependencies = false, bool noLaunchProfile = false, bool noRestore = false)
        {
            RunCmd cmd =            new RunCmd();

            if(arguments != null)
                cmd.Arguments = arguments;

            cmd.ProjectPath =       projectPath;
            cmd.Configuration =     configuration;
            cmd.LaunchProfile =     launchProfile;
            cmd.Runtime =           runtime;
            cmd.Force =             force;
            cmd.NoDependencies =    noDependencies;
            cmd.NoLaunchProfile =   noLaunchProfile;
            cmd.NoRestore =         noRestore;
            var result =            await cmd.RunAsync();
            CheckCmd(cmd);
            return result;
        }

        /// <summary>
        /// The dotnet new search command searches for templates supported by dotnet new on NuGet.org. 
        /// </summary>
        /// <param name="templateName">The template name you are looking for or a part of the name</param>
        /// <param name="author">Filters templates based on template author. Partial match is supported.</param>
        /// <param name="package">Filters templates based on NuGet package ID. Partial match is supported.</param>
        /// <param name="tags">Filters templates based on template type. Predefined values are project, item, and solution.</param>
        /// <param name="type">Enables diagnostic output. Available since .NET SDK 7.0.100.</param>
        /// <param name="language">Filters templates based on template tags. To be selected, a template must have at least one tag that exactly matches the criteria.</param>
        /// <returns></returns>
        public async Task<NewSearchResult> NewSearchAsync(string templateName, string author = "", string package = "", string tags = "", string type = "", Language language = Language.Default)
        {
            NewSearchCmd cmd =  new NewSearchCmd();
            cmd.TemplateName =  templateName;
            cmd.Author =        author;
            cmd.Tag =           tags;
            cmd.Type =          type;
            cmd.Language =      language;
            var result = await cmd.NewSearchAsync();
            CheckCmd(cmd);

            return result;
        }

        public async Task<NewSearchResult> NewSearchAsync(NewSearchCmd cmd)
        {
            var result = await cmd.NewSearchAsync();
            CheckCmd(cmd);
            return result;
        }

        public async Task<VersionResult> VersionAsync()
        {
            VersionCmd cmd = new VersionCmd();
            var result = await cmd.VersionAsync();
            CheckCmd(cmd);
            return result;
        }

    }
}

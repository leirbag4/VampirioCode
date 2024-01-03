using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Dotnet.Result;
using static System.Runtime.InteropServices.JavaScript.JSType;
using VampirioCode.IO;
using VampirioCode.Command.Dotnet.Params;
using VampirioCode.UI;

namespace VampirioCode.Command.Dotnet
{
    public class Dotnet
    {
        public ErrorInfo ErrorInfo { get; private set; } = null;
        public bool Error { get; private set; } = false;


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
            cmd.RuntimeIdentifier = runtime;

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

        public async Task<NewListResult> NewListAsyc()
        {
            NewListCmd cmd = new NewListCmd();
            var result = await cmd.NewListAsync();
            CheckCmd(cmd);
            return result;
        }

        public async Task<NewListResult> NewListAsyc(NewListCmd cmd)
        {
            var result = await cmd.NewListAsync();
            CheckCmd(cmd);
            return result;
        }

        public async Task<NewSearchResult> NewSearchAsyc(string templateName, string author = "", string package = "", string tags = "", string type = "", Language language = Language.Default)
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

        public async Task<NewSearchResult> NewSearchAsyc(NewSearchCmd cmd)
        {
            var result = await cmd.NewSearchAsync();
            CheckCmd(cmd);
            return result;
        }

        private void CheckCmd(BaseCmd cmd)
        {
            if (cmd.Error)
            {
                ErrorInfo = cmd.ErrorInfo;
                Error = true;
            }
        }

    }
}

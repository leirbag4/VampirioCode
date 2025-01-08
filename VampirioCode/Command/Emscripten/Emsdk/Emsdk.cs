using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Emscripten.Emsdk.Result;
using VampirioCode.SaveData;

namespace VampirioCode.Command.Emscripten.Emsdk
{
    public class Emsdk : BaseCmdProgram
    {

        //public static string ProgramPath = @"C:\programs_dev\emsdk\emsdk.bat";
        public static string ProgramPath = "";

        /// <summary>
        /// Sets the specified tool or SDK as the default tool in the system environment. For simple reasons if you pass '3.1.53' or 'latest' it will change this sdk version.
        /// </summary>
        /// <param name="toolOrSdk">A name or|and version number to activate the sdk like '3.1.53' or 'latest' or any other tool or sdk lile 'node-0.10.17-64bit'. If you leave it as it is, 'latest' will be used.</param>
        /// <param name="permanent">On Windows, you can pass the option --permanent to the activate command to register the environment permanently for the current user.</param>
        /// <param name="system">On Windows, you can pass the option --system to the activate command to register the environment permanently for all users.</param>
        /// <returns></returns>
        public async Task<ActivateResult> ActivateAsync(string toolOrSdk = "latest", bool permanent = false, bool system = false)
        {
            SetupProgramPaths();

            ActivateCmd cmd =   new ActivateCmd();
            cmd.ToolOrSdk =     toolOrSdk;
            cmd.Permanent =     permanent;
            cmd.System =        system;
            var result =        await cmd.ActivateAsync();
            CheckCmd(cmd);
            return result;
        }

        /// <summary>
        /// Lists all current SDKs and tools and their installation status.
        /// </summary>
        /// <param name="old">With the --old parameter, historical versions are also shown.</param>
        /// <returns></returns>
        public async Task<ListResult> ListAsync(bool old = false)
        {
            SetupProgramPaths();

            ListCmd cmd =   new ListCmd();
            cmd.Old = old;
            var result =    await cmd.ListAsync();
            CheckCmd(cmd);
            return result;
        }

        /// <summary>
        /// Downloads and installs the specified tool or SDK.
        /// </summary>
        /// <param name="toolOrSdk">A name or|and version number to activate the sdk like '3.1.53' or 'latest' or any other tool or sdk lile 'node-0.10.17-64bit'. If you leave it as it is, 'latest' will be used.</param>
        /// <returns></returns>
        public async Task<InstallResult> InstallAsync(string toolOrSdk = "latest")
        {
            SetupProgramPaths();

            InstallCmd cmd =    new InstallCmd();
            cmd.ToolOrSdk =     toolOrSdk;
            var result =        await cmd.InstallAsync();
            CheckCmd(cmd);
            return result;
        }

        /// <summary>
        /// Removes the specified tool or SDK from the disk.
        /// </summary>
        /// <param name="toolOrSdk">A name or|and version number to activate the sdk like '3.1.53' or 'latest' or any other tool or sdk lile 'node-0.10.17-64bit'. If you leave it as it is, 'latest' will be used.</param>
        /// <returns></returns>
        public async Task<UninstallResult> UninstallAsync(string toolOrSdk = "latest")
        {
            SetupProgramPaths();

            UninstallCmd cmd =  new UninstallCmd();
            cmd.ToolOrSdk =     toolOrSdk;
            var result =        await cmd.UninstallAsync();
            CheckCmd(cmd);
            return result;
        }

        /// <summary>
        /// Fetches the latest list of all available tools and SDKs (but does not install them).
        /// </summary>
        /// <returns></returns>
        public async Task<UpdateResult> UpdateAsync()
        {
            SetupProgramPaths();

            UpdateCmd cmd =     new UpdateCmd();
            var result =        await cmd.UpdateAsync();
            CheckCmd(cmd);
            return result;
        }

        /// <summary>
        /// Lists all supported commands. The same list is output if no command is specified.
        /// </summary>
        /// <returns></returns>
        public async Task<HelpResult> HelpAsync()
        {
            SetupProgramPaths();

            HelpCmd cmd =   new HelpCmd();
            var result =    await cmd.HelpAsync();
            CheckCmd(cmd);
            return result;
        }

        protected override void SetupProgramPaths()
        {
            ProgramPath = Config.BuildersSettings.Emscripten.emsdk_bat_path;
        }
    }
}

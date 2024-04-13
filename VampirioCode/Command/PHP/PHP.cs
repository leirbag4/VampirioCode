using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.PHP.Result;

namespace VampirioCode.Command.PHP
{
    public class PHP : BaseCmdProgram
    {
        //public static string ProgramPath = @"C:\programs_dev\xampp_7.2.22\php\php.exe";
        public static string ProgramPath = @"C:\programs_dev\php-v8.1.3_usbwebserver\php\php.exe";

        /// <summary>
        /// Run the script file '.php'
        /// </summary>
        /// <param name="filename">The php file '.php' to run</param>
        /// <returns></returns>
        public async Task<RunResult> RunAsync(string filename)
        {
            RunCmd cmd = new RunCmd();
            cmd.Filename = filename;
            var result = await cmd.RunAsync();
            CheckCmd(cmd);
            return result;
        }
    }
}

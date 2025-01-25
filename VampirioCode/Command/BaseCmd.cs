using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Environment;
using VampirioCode.IO;
using VampirioCode.UI;

namespace VampirioCode.Command
{
    public class BaseCmd
    {
        public bool Error { get; private set; }
        public ErrorInfo ErrorInfo { get; private set; } = null;
        public bool AutoTriggerErrors { get; set; } = true;
        public bool LogParams { get; set; } = true;
        public bool ConfirmProgramPath { get; set; } = true;

        protected CmdRun proc;
        protected BaseResult baseResult = null;
        protected string cmd = "";

        private Dictionary<string, string> variables = new Dictionary<string, string>() { { "${base}", AppInfo.BasePath } };

        /*protected async Task<T> CreateCommand<T>(string command, string param0 = "", string param1 = "") where T : BaseResult, new()
        {
            return await _CreateCommand<T>("dotnet", command, param0, param1);
        }

        protected async Task<T> CreateCommandProg<T>(string program, string command, string param0 = "", string param1 = "") where T : BaseResult, new()
        {
            return await _CreateCommand<T>(program, command, param0, param1);
        }*/

        //protected async Task<T> _CreateCommand<T>(string program, string command, string param0 = "", string param1 = "") where T : BaseResult, new()
        
        protected async Task<T> CreateCommand<T>(string program, string command, string param0 = "", string param1 = "", bool useRelativePath = false) where T : BaseResult, new()
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
            baseResult = new T();

            if (ConfirmProgramPath && !File.Exists(program.Replace('"', ' ').Trim()))
                MsgBox.Show("Incorrect Path", "Incorrect 'Compiler or Interpreter' path.\n\nPath:'"+program+"'\n\nConfigure it at 'Config -> Setup Compilers | Interpreters'", DialogButtons.OK, DialogIcon.Error);

            string arguments = command;

            if (param0 != "") arguments += " " + param0;
            if (param1 != "") arguments += " " + param1;

            if(LogParams)
                Println(program + " " + arguments);
            
            proc = new CmdRun(program, arguments, useRelativePath);
            proc.DataReceived += _OnDataReceived;
            proc.ErrorDataReceived += _OnErrorDataReceived;
            //proc.Complete +=          OnComplete;
            //proc.Start();

            proc.Complete += () => _OnComplete(tcs);
            await Task.Run(() =>
            {
                try
                {
                    proc.Start();
                }
                catch (Exception e)
                {
                    CallError("CreateCommand() cannot launch process", e);
                    _OnComplete(tcs);
                }
            });

            return await tcs.Task;
        }

        private void _OnDataReceived(string data)
        {
            /*try
            {
                XConsole.Println(data);
            }
            catch (Exception e)
            {
                CallError("Can't parse 'wsl " + proc.Arguments + "'", e);
            }*/

            OnDataReceived(data);
        }

        protected virtual void OnDataReceived(string data)
        { }

        private void _OnErrorDataReceived(string data)
        {
            if(AutoTriggerErrors)
                CallError("DataReceivedError -> " + data);

            OnErrorDataReceived(data);
        }

        protected virtual void OnErrorDataReceived(string data)
        { }

        private void _OnComplete<T>(TaskCompletionSource<T> tcs) where T : BaseResult
        {
            T result = (T)baseResult;
            OnComplete(result);
            tcs.SetResult(result);
        }

        protected virtual void OnComplete(BaseResult result)
        { }

        /*private void OnComplete(TaskCompletionSource<BaseResult> tcs)
        {
            tcs.SetResult(baseResult);
        }*/

        protected void Set(string value)
        {
            cmd += "\"" + value + "\" ";
        }

        protected void Set(string argumentName, bool active)
        {
            if(active)
                cmd += argumentName + " ";
        }

        protected void Set(string argumentName, string value)
        {
            cmd += argumentName + " \"" + value + "\" ";
        }

        protected bool SetRequire(string value, string internalVariableName)
        {
            if (value == "")
            {
                CallError("Argument: '" + internalVariableName + "' can't be empty!");
                return false;
            }
            else
            {
                cmd += "\"" + value + "\" ";
                return true;
            }
        }

        protected void SetIfExists(string argumentName, string value, bool spaceSeparator = true)
        {
            if (value != "")
            {
                if(spaceSeparator)
                    cmd += argumentName + " \"" + value + "\" ";
                else
                    cmd += argumentName + "\"" + value + "\" ";
            }
        }


        protected void SetIfExists(string value)
        {
            if(value != "")
                cmd += "\"" + value + "\" ";
        }

        protected void SetIfExists(string[] value)
        {
            if ((value != null) && (value.Length > 0))
            {
                foreach (string val in value)
                    cmd += "\"" + val + "\" ";
            }
        }

        protected void SetIfExists(List<string> value)
        {
            if ((value != null) && (value.Count > 0))
            {
                foreach (string val in value)
                    cmd += "\"" + val + "\" ";
            }
        }

        /*protected void SetIfExists(string argumentName, int? value)
        {
            if (value.HasValue)
                cmd += argumentName + "\"" + value + "\" ";
        }*/

        /*protected void SetIfExists(string argumentName, bool? value)
        {
            if (value.HasValue)
                cmd += argumentName + "\"" + value + "\" ";
        }*/

        protected void SetAnyIfExists(string value, string value2)
        {
            if (value != "")
                cmd += "\"" + value + "\" ";
            else if (value2 != "")
                cmd += "\"" + value2 + "\" ";
        }

        protected void SetIfNot(string argumentName, string value, string notThisValue)
        { 
            if(value != notThisValue)
                cmd += argumentName + " \"" + value + "\"";
        }

        public void AddVariable(string varName, string varValue)
        { 
            if(variables.ContainsKey(varName))
                variables[varName] = varValue;
            else
                variables.Add(varName, varValue);

        }
        public string ReplaceVars(string path, OperatingSystemType os = OperatingSystemType.Windows)
        {
            if (os == OperatingSystemType.Windows)
            {
                foreach (var currVar in variables)
                {
                    path = path.Replace(currVar.Key, currVar.Value);
                    path = path.Replace("\\\\", "\\");
                }
                return path;
            }
            else if ((os == OperatingSystemType.Linux) || (os == OperatingSystemType.MacOS))
            {
                foreach (var currVar in variables)
                {
                    path = path.Replace(currVar.Key, currVar.Value);
                    
                    if(currVar.Key == Variables.ProjDir)
                        path = CmdUtils.ToUnixRelativePath(path);

                    //path = path.Replace("\\\\", "\\");
                }
                return path;
            }

            return ""; // never reaches here
        }

        protected string _quotes(string str)
        {
            return '"' + str + '"';
        }

        //
        // FIX the last bar that escapes a quote at the end.
        // Input  -> "C:\tests\"  [BAD] to
        // Output -> "C:\tests\\" [OK]
        //
        // If you don't fix it, this could happened:
        //   -> [cmd.exe "C:\tests\" "app"]  will be see as
        //      [cmd.exe "C:\tests\ "app" ]
        //
        protected string _fixLastEscapeBar(string str)
        {
            if (str.EndsWith("\\") && !str.EndsWith("\\\\"))
                return (str + "\\");
            
            return str;
        }

        protected bool RequireArgument(string value, string internalVariableName)
        {
            if (value == "")
            {
                CallError("Argument: '" + internalVariableName + "' can't be empty!");
                return false;
            }
            else
                return true;
        }

        protected bool CanUse(List<string> list)
        {
            return ((list != null) && (list.Count > 0));
        }

        protected void CallError(ErrorInfo error)
        {
            ErrorInfo = error;
            Error = true;
            PrintError(ErrorInfo);

            if (baseResult != null)
                baseResult.SetError(ErrorInfo);
        }

        protected void CallError(string str)
        {
            ErrorInfo = ErrorInfo.Create(str);
            Error = true;
            PrintError(ErrorInfo);

            if (baseResult != null)
                baseResult.SetError(ErrorInfo);
        }

        protected void CallError(string str, Exception e)
        {
            ErrorInfo = ErrorInfo.Create(str, e);
            Error = true;
            PrintError(ErrorInfo);

            if (baseResult != null)
                baseResult.SetError(ErrorInfo);
        }

        protected void Print(string str)
        {
            XConsole.Print(str);
        }

        protected void Println(string str)
        {
            XConsole.Println(str);
        }

        protected void PrintError(string str)
        {
            XConsole.PrintError(str);
        }

        protected void PrintError(ErrorInfo error)
        {
            XConsole.PrintError(error);
        }

        protected void Alert(string str)
        {
            XConsole.Alert(str);
        }

    }
}

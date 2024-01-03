using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.IO;
using VampirioCode.UI;

namespace VampirioCode.Command
{
    public class BaseCmd
    {
        public bool Error { get; private set; }
        public ErrorInfo ErrorInfo { get; private set; } = null;

        protected CmdRun proc;
        protected BaseResult baseResult = null;
        protected string cmd = "";

        /*protected async Task<T> CreateCommand<T>(string command, string param0 = "", string param1 = "") where T : BaseResult, new()
        {
            return await _CreateCommand<T>("dotnet", command, param0, param1);
        }

        protected async Task<T> CreateCommandProg<T>(string program, string command, string param0 = "", string param1 = "") where T : BaseResult, new()
        {
            return await _CreateCommand<T>(program, command, param0, param1);
        }*/

        //protected async Task<T> _CreateCommand<T>(string program, string command, string param0 = "", string param1 = "") where T : BaseResult, new()
        
        protected async Task<T> CreateCommand<T>(string program, string command, string param0 = "", string param1 = "") where T : BaseResult, new()
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
            baseResult = new T();

            string arguments = command;

            if (param0 != "") arguments += " " + param0;
            else if (param1 != "") arguments += " " + param1;

            Println(program + " " + arguments);

            proc = new CmdRun(program, arguments);
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
                    CallError("dotnet is not installed", e);
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

        protected void SetIfExists(string argumentName, string value)
        {
            if(value != "")
                cmd += argumentName + " \"" + value + "\" ";
        }

        protected void SetIfExists(string value)
        {
            if(value != "")
                cmd += "\"" + value + "\" ";
        }

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

        protected string _quotes(string str)
        {
            return '"' + str + '"';
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

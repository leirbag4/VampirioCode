using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command
{
    public class CmdRun
    {
        public delegate void DataReceivedEvent(string data);
        public delegate void ErrorDataReceivedEvent(string data);
        public delegate void CompleteEvent();

        public event DataReceivedEvent DataReceived;
        public event ErrorDataReceivedEvent ErrorDataReceived;
        public event CompleteEvent Complete;

        public string WorkingDirectory { get; set; } = ".";
        public string FileName { get; set; } = "";
        public string Arguments { get; set; } = "";

        public Process Process { get { return _process; } }

        private Process? _process;
        private bool _error = false;
        

        public CmdRun(string fileName, string arguments)
        {
            WorkingDirectory = ".";
            FileName = fileName;
            Arguments = arguments;
        }

        public CmdRun(string workingDirectory, string fileName, string arguments)
        {
            WorkingDirectory = workingDirectory;
            FileName = fileName;
            Arguments = arguments;
        }
        

        public void Start()
        {
            ProcessStartInfo startInfo;
            _error = false;

            _process = new Process();
            startInfo = _process.StartInfo;


            startInfo.WorkingDirectory = WorkingDirectory;
            startInfo.FileName = FileName;
            startInfo.Arguments = Arguments;

            startInfo.CreateNoWindow = true;
            //compiler.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            //compiler.StartInfo.RedirectStandardInput = true;

            //if (_type == CmdType.WSL)
            {
                //startInfo.StandardOutputEncoding = System.Text.Encoding.Unicode;
                // startInfo.StandardErrorEncoding =   System.Text.Encoding.Unicode;
            }
            //else if (_type == CmdType.Windows) { }

            _process.OutputDataReceived +=  OnDataReceived;
            _process.ErrorDataReceived +=   OnErrorDataReceived;

            _process.EnableRaisingEvents = true;
            //compiler.Exited += onExitFinished;

            _process.Start();

            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();

            //compiler.StandardInput.WriteLine("wsl --list");

        }

        public void OpenAndLaunch()
        {

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WorkingDirectory = WorkingDirectory,
                FileName = FileName,
                Arguments = Arguments,
                UseShellExecute = false,
                CreateNoWindow = false,
            };

            Process process = new Process { StartInfo = startInfo };
            process.Start();
        }

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null)
            {
                OnFinished();
            }
            else
            {
                if (DataReceived != null)
                    DataReceived(e.Data);
            }
        }

        private void OnErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null)
            {
                //Println("error null");
            }
            /*else if (e.Data.IndexOf("INFO:") == 0)
            {
                Println("ERROR: " + e.Data);
            }*/
            else
            {
                if (ErrorDataReceived != null)
                    ErrorDataReceived(e.Data);

                /*if (e.Data.IndexOf(": error:") != -1)
                    decodeErrorWarningLine(CmdErrorType.ERROR, e.Data, ": error:");
                else if (e.Data.IndexOf(": fatal error:") != -1)
                    decodeErrorWarningLine(CmdErrorType.ERROR, e.Data, ": fatal error:");
                else if (e.Data.IndexOf(": warning:") != -1)
                    decodeErrorWarningLine(CmdErrorType.WARNING, e.Data, ": warning:");*/

                _error = true;
            }
        }

        private void OnFinished()
        {
            if (Complete != null)
                Complete();
        }

    }
}

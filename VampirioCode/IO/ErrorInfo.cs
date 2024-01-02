using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.IO
{
    public class ErrorInfo
    {
        public string Message { get; private set; } = "";
        public Exception Exception { get; private set; } = null;

        public static ErrorInfo Create(string message)
        {
            ErrorInfo error = new ErrorInfo() { Message = message, Exception = null };
            return error;
        }

        public static ErrorInfo Create(string message, Exception exception)
        {
            ErrorInfo error = new ErrorInfo() { Message = message, Exception = exception };
            return error;
        }

        public override string ToString()
        {
            string str = "Error: " + Message;

            if (Exception != null)
                str += "\nException Msg: " + Exception.Message + "\nStackTrace: " + Exception.StackTrace;

            return str;
        }
    }
}

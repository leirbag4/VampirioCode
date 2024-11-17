using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.IO
{
    public class ResultInfo
    {
        public string Message { get; set; }
        public bool IsOk { get { return (ErrorInfo == null); } }
        public bool HasErrors { get { return (ErrorInfo != null); } }
        public ErrorInfo ErrorInfo { get; set; } = null;


        public static ResultInfo CreateOk(string message = "")
        {
            ResultInfo result = new ResultInfo();
            result.Message = message;
            return result;
        }

        public static ResultInfo CreateError(string message = "", Exception e = null)
        {
            ResultInfo result = new ResultInfo();
            result.ErrorInfo =  ErrorInfo.Create(message, e);
            result.Message =    message;
            return result;
        }
    }
}

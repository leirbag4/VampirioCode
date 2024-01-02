using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.IO;

namespace VampirioCode.Command
{
    public class BaseResult
    {
        public bool IsOk { get { return !Error; } }

        public bool Error { get; private set; } = false;
        public ErrorInfo ErrorInfo { get; private set; } = null;

        public void SetError(ErrorInfo error)
        {
            this.Error = true;
            this.ErrorInfo = error;
        }

    }
}

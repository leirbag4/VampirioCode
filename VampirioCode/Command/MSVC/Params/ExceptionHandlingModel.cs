using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ScintillaNET.Style;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace VampirioCode.Command.MSVC.Params
{
    /// <summary>
    /// a  - /EHa
    ///   Enables standard C++ stack unwinding.Catches both structured (asynchronous) and standard C++ (synchronous) exceptions when you use catch(...) syntax. /EHa overrides both /EHs and /EHc arguments.
    ///
    /// s  - /EHs
    ///   Enables standard C++ stack unwinding. Catches only standard C++ exceptions when you use catch(...) syntax.Unless /EHc is also specified, the compiler assumes that functions declared as extern "C" may throw a C++ exception.
    ///
    /// c  - /EHc
    ///   When used with /EHs, the compiler assumes that functions declared as extern "C" never throw a C++ exception.It has no effect when used with /EHa(that is, /EHca is equivalent to /EHa). /EHc is ignored if /EHs or /EHa aren't specified.
    ///
    /// r  - /EHr
    ///   Tells the compiler to always generate runtime termination checks for all noexcept functions.By default, runtime checks for noexcept may be optimized away if the compiler determines the function calls only non-throwing functions.This option gives strict C++ conformance at the cost of some extra code. /EHr is ignored if /EHs or /EHa aren't specified.
    ///
    /// sc - /EHsc
    ///   A combination of /EHs and /EHc
    /// </summary>
    public enum ExceptionHandlingModel
    {
        None,
        EHa,
        EHs,
        EHc,
        EHr,
        EHsc
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Builder
{
    public enum BuilderTemplate
    {
        CppGnuGppWSLBasic,
        CppMsvcBasic,
        CppClangBasic,
        CppEmscriptenBasic,
        CSharpDotnetBasic,
        JavascriptBasic,
        JavaBasic,
        PhpBasic,
        HtmlBasic,

        CppMsvcSDL2,
        CppGnuGppSDL2,
        CppMsvcVampEngine,
        CppMsvcVampEngineComplex
    }
}

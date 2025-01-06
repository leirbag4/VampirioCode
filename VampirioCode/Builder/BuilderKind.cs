using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Builder
{
    public enum BuilderKind
    {
        // C++
        CppMsvc,
        CppGnuGpp,
        CppCLang,
        CppEmscripten,
        // C#
        CSharpDotnet,
        // Javascript
        JavascriptNodeJs,
        // Java
        JavaJavac,
        // Php
        PhpXampp

    }
}

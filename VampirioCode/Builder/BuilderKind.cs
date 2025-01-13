using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VampirioCode.Builder
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BuilderKind
    {
        None,
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

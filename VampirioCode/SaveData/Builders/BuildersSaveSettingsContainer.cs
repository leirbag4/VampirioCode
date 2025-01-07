using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.SaveData.Builders.Cpp;
using VampirioCode.SaveData.Builders.CSharp;
using VampirioCode.SaveData.Builders.Java;
using VampirioCode.SaveData.Builders.Javascript;
using VampirioCode.SaveData.Builders.PHP;

namespace VampirioCode.SaveData.Builders
{
    public class BuildersSaveSettingsContainer
    {
        // C++
        public MsvcSaveSettings Msvc { get; set; } = new MsvcSaveSettings();
        public GnuGppSaveSettings GnuGpp { get; set; } = new GnuGppSaveSettings();
        public CLangSaveSettings CLang { get; set; } = new CLangSaveSettings();
        public EmscriptenSaveSettings Emscripten { get; set; } = new EmscriptenSaveSettings();

        // C#
        public DotnetBuildSettings Dotnet { get; set; } = new DotnetBuildSettings();

        // Javascript
        public NodeJsBuildSettings NodeJs { get; set; } = new NodeJsBuildSettings();

        // JAVA
        public JavacBuildSettings Javac { get; set; } = new JavacBuildSettings();

        // PHP
        public PhpXamppBuildSettings PhpXampp { get; set; } = new PhpXamppBuildSettings();

    }
}

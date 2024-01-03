using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.Dotnet.Params
{
    public class RuntimeIdentifierInfo
    {
        public RuntimeIdentifier RuntimeIdentifier { get; set; }
        public string Name { get; set; }
        public string Param { get; set; }
        public string Description { get; set; }

        private static RuntimeIdentifierInfo _Create(RuntimeIdentifier runtime, string name, string param, string description)
        {
            RuntimeIdentifierInfo rid = new RuntimeIdentifierInfo();
            rid.RuntimeIdentifier = runtime;
            rid.Name =              name;
            rid.Param =             param;
            rid.Description =       description;
            return rid;
        }

        public static RuntimeIdentifierInfo Get(RuntimeIdentifier runtime)
        {

            switch (runtime) 
            {
                case RuntimeIdentifier.Default:                return _Create(runtime, "", "", "");

                // Windows
                case RuntimeIdentifier.WinX64:              return _Create(runtime, "Windows x64",          "win-x64",              "Windows");
                case RuntimeIdentifier.WinX86:              return _Create(runtime, "Windows x86",          "win-x86",              "Windows");
                case RuntimeIdentifier.WinArm64:            return _Create(runtime, "Windows Arm64",        "win-arm64",            "Windows");

                // Linux
                case RuntimeIdentifier.LinuxX64:            return _Create(runtime, "Linux x64",            "linux-x64",            "Most desktop distributions like CentOS, Debian, Fedora, Ubuntu, and derivatives");
                case RuntimeIdentifier.LinuxMuslX64:        return _Create(runtime, "Linux musl X64",       "linux-musl-x64",       "Lightweight distributions using musl like Alpine Linux");
                case RuntimeIdentifier.LinuxMuslArm64:      return _Create(runtime, "Linux musl Arm64",     "linux-musl-arm64",     "Used to build Docker images for 64-bit Arm v8 and minimalistic base images");
                case RuntimeIdentifier.LinuxArm:            return _Create(runtime, "Linux Arm",            "linux-arm",            "Linux distributions running on Arm like Raspbian on Raspberry Pi Model 2+");
                case RuntimeIdentifier.LinuxArm64:          return _Create(runtime, "Linux Arm64",          "linux-arm64",          "Linux distributions running on 64-bit Arm like Ubuntu Server 64-bit on Raspberry Pi Model 3+");
                case RuntimeIdentifier.LinuxBionicArm64:    return _Create(runtime, "Linux Bionic Arm64",   "linux-bionic-arm64",   "Linux");

                // OSX
                case RuntimeIdentifier.OsxX64:              return _Create(runtime, "OSX x64",              "osx-x64",              "Minimum OS version is macOS 10.12 Sierra");
                case RuntimeIdentifier.OsxArm64:            return _Create(runtime, "OSX Arm64",            "osx-arm64",            "OSX");

                // IOS
                case RuntimeIdentifier.IosArm64:            return _Create(runtime, "IOS Arm64",            "ios-arm64",            "IOS");

                // Android
                case RuntimeIdentifier.AndroidArm64:        return _Create(runtime, "Android Arm64",        "android-arm64",        "Android");
                default:                                    return null;
            }
        }
    }
}

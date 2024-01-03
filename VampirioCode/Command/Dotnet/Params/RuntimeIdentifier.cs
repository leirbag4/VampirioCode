using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.Dotnet.Params
{
    public enum RuntimeIdentifier
    {
        Default,

        // Windows
        WinX64,
        WinX86,
        WinArm64,

        // Linux
        LinuxX64,
        LinuxMuslX64,
        LinuxMuslArm64,
        LinuxArm,
        LinuxArm64,
        LinuxBionicArm64,

        // OSX
        OsxX64,
        OsxArm64,

        // IOS
        IosArm64,

        // Android
        AndroidArm64
    }
}

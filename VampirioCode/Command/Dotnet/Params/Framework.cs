using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.Dotnet.Params
{
    public enum Framework
    {
        None,

        // .NET 5+ (and .NET Core)
        NetCore1_0,
        NetCore1_1,
        NetCore2_0,
        NetCore2_1,
        NetCore2_2,
        NetCore3_0,
        NetCore3_1,
        DotNet5_0,
        DotNet5_0_windows,
        DotNet6_0,
        DotNet6_0_android,
        DotNet6_0_ios,
        DotNet6_0_maccatalyst,
        DotNet6_0_macos,
        DotNet6_0_tvos,
        DotNet6_0_windows,
        DotNet7_0,
        DotNet7_0_android,
        DotNet7_0_ios,
        DotNet7_0_maccatalyst,
        DotNet7_0_macos,
        DotNet7_0_tvos,
        DotNet7_0_windows,
        DotNet8_0,
        DotNet8_0_android,
        DotNet8_0_browser,
        DotNet8_0_ios,
        DotNet8_0_maccatalyst,
        DotNet8_0_macos,
        DotNet8_0_tvos,
        DotNet8_0_windows,

        // .NET Standard
        NetStandard1_0,
        NetStandard1_1,
        NetStandard1_2,
        NetStandard1_3,
        NetStandard1_4,
        NetStandard1_5,
        NetStandard1_6,
        NetStandard2_0,
        NetStandard2_1,

        // .NET Framework
        NetFramework1_1,
        NetFramework2_0,
        NetFramework3_5,
        NetFramework4_0,
        NetFramework4_0_3,
        NetFramework4_5,
        NetFramework4_5_1,
        NetFramework4_5_2,
        NetFramework4_6,
        NetFramework4_6_1,
        NetFramework4_6_2,
        NetFramework4_7,
        NetFramework4_7_1,
        NetFramework4_7_2,
        NetFramework4_8,

        // Windows Store
        WindowsStoreNetCore,
        WindowsStoreNetCore4_5,
        WindowsStoreNetCore4_5_1,

        // .NET Micro Framework
        MicroFramework,

        // Silverlight
        Silverlight1_4,
        Silverlight1_5,

        // Windows Phone
        WindowsPhone,
        WindowsPhone7,
        WindowsPhone7_5,
        WindowsPhone8,
        WindowsPhone8_1,
        WindowsPhoneA8_1,

        // Universal Windows Platform
        UniversalWinPlatform,
        UniversalWinPlatform10
    }
}

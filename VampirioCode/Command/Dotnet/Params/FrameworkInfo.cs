using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.Dotnet.Params
{
    public class FrameworkInfo
    {
        public Framework Framework { get; set; }
        public string Name { get; set; }
        public string Param { get; set; }
        public string Description { get; set; }

        private static FrameworkInfo _Create(Framework fw, string name, string param, string description)
        { 
            FrameworkInfo finfo =   new FrameworkInfo();
            finfo.Framework =       fw;
            finfo.Name =            name;
            finfo.Param =           param;
            finfo.Description =     description;
            return finfo;
        }

        public static FrameworkInfo Get(Framework framework)
        {
            Framework fw = framework;

            string strNet5AndCore =     ".NET 5+ (and .NET Core)";
            string strNetStandard =     ".NET Standard";
            string strNetFramework =    ".NET Framework";
            string strWindowsStore =    "Windows Store";
            string strMicroFramework =  "Micro Framework";
            string strSilverlight =     "Silverlight";
            string strWindowsPhone =    "Windows Phone";
            string strUniversalWinPlat ="Universal Windows Platform";

            switch (framework) 
            {
                case Framework.None:                    return _Create(fw, "", "", "");

                // .NET 5+ (and .NET Core)
                case Framework.NetCore1_0:              return _Create(fw, "NetCore1_0",            "netcoreapp1.0",        strNet5AndCore);
                case Framework.NetCore1_1:              return _Create(fw, "NetCore1_1",            "netcoreapp1.1",        strNet5AndCore);
                case Framework.NetCore2_0:              return _Create(fw, "NetCore2_0",            "netcoreapp2.0",        strNet5AndCore);
                case Framework.NetCore2_1:              return _Create(fw, "NetCore2_1",            "netcoreapp2.1",        strNet5AndCore);
                case Framework.NetCore2_2:              return _Create(fw, "NetCore2_2",            "netcoreapp2.2",        strNet5AndCore);
                case Framework.NetCore3_0:              return _Create(fw, "NetCore3_0",            "netcoreapp3.0",        strNet5AndCore);
                case Framework.NetCore3_1:              return _Create(fw, "NetCore3_1",            "netcoreapp3.1",        strNet5AndCore);
                case Framework.DotNet5_0:               return _Create(fw, "DotNet5_0",             "net5.0",               strNet5AndCore);
                case Framework.DotNet5_0_windows:       return _Create(fw, "DotNet5_0_windows",     "net5.0-windows",       strNet5AndCore);
                case Framework.DotNet6_0:               return _Create(fw, "DotNet6_0",             "net6.0",               strNet5AndCore);
                case Framework.DotNet6_0_android:       return _Create(fw, "DotNet6_0_android",     "net6.0-android",       strNet5AndCore);
                case Framework.DotNet6_0_ios:           return _Create(fw, "DotNet6_0_ios",         "net6.0-ios",           strNet5AndCore);
                case Framework.DotNet6_0_maccatalyst:   return _Create(fw, "DotNet6_0_maccatalyst", "net6.0-maccatalyst",   strNet5AndCore);
                case Framework.DotNet6_0_macos:         return _Create(fw, "DotNet6_0_macos",       "net6.0-macos",         strNet5AndCore);
                case Framework.DotNet6_0_tvos:          return _Create(fw, "DotNet6_0_tvos",        "net6.0-tvos",          strNet5AndCore);
                case Framework.DotNet6_0_windows:       return _Create(fw, "DotNet6_0_windows",     "net6.0-windows",       strNet5AndCore);
                case Framework.DotNet7_0:               return _Create(fw, "DotNet7_0",             "net7.0",               strNet5AndCore);
                case Framework.DotNet7_0_android:       return _Create(fw, "DotNet7_0_android",     "net7.0-android",       strNet5AndCore);
                case Framework.DotNet7_0_ios:           return _Create(fw, "DotNet7_0_ios",         "net7.0-ios",           strNet5AndCore);
                case Framework.DotNet7_0_maccatalyst:   return _Create(fw, "DotNet7_0_maccatalyst", "net7.0-maccatalyst",   strNet5AndCore);
                case Framework.DotNet7_0_macos:         return _Create(fw, "DotNet7_0_macos",       "net7.0-macos",         strNet5AndCore);
                case Framework.DotNet7_0_tvos:          return _Create(fw, "DotNet7_0_tvos",        "net7.0-tvos",          strNet5AndCore);
                case Framework.DotNet7_0_windows:       return _Create(fw, "DotNet7_0_windows",     "net7.0-windows",       strNet5AndCore);
                case Framework.DotNet8_0:               return _Create(fw, "DotNet8_0",             "net8.0",               strNet5AndCore);
                case Framework.DotNet8_0_android:       return _Create(fw, "DotNet8_0_android",     "net8.0-android",       strNet5AndCore);
                case Framework.DotNet8_0_browser:       return _Create(fw, "DotNet8_0_browser",     "net8.0-browser",       strNet5AndCore);
                case Framework.DotNet8_0_ios:           return _Create(fw, "DotNet8_0_ios",         "net8.0-ios",           strNet5AndCore);
                case Framework.DotNet8_0_maccatalyst:   return _Create(fw, "DotNet8_0_maccatalyst", "net8.0-maccatalyst",   strNet5AndCore);
                case Framework.DotNet8_0_macos:         return _Create(fw, "DotNet8_0_macos",       "net8.0-macos",         strNet5AndCore);
                case Framework.DotNet8_0_tvos:          return _Create(fw, "DotNet8_0_tvos",        "net8.0-tvos",          strNet5AndCore);
                case Framework.DotNet8_0_windows:       return _Create(fw, "DotNet8_0_windows",     "net8.0-windows",       strNet5AndCore);

                // .NET Standard
                case Framework.NetStandard1_0:          return _Create(fw, "NetStandard1_0",        "netstandard1.0",       strNetStandard);
                case Framework.NetStandard1_1:          return _Create(fw, "NetStandard1_1",        "netstandard1.1",       strNetStandard);
                case Framework.NetStandard1_2:          return _Create(fw, "NetStandard1_2",        "netstandard1.2",       strNetStandard);
                case Framework.NetStandard1_3:          return _Create(fw, "NetStandard1_3",        "netstandard1.3",       strNetStandard);
                case Framework.NetStandard1_4:          return _Create(fw, "NetStandard1_4",        "netstandard1.4",       strNetStandard);
                case Framework.NetStandard1_5:          return _Create(fw, "NetStandard1_5",        "netstandard1.5",       strNetStandard);
                case Framework.NetStandard1_6:          return _Create(fw, "NetStandard1_6",        "netstandard1.6",       strNetStandard);
                case Framework.NetStandard2_0:          return _Create(fw, "NetStandard2_0",        "netstandard2.0",       strNetStandard);
                case Framework.NetStandard2_1:          return _Create(fw, "NetStandard2_1",        "netstandard2.1",       strNetStandard);

                // .NET Framework
                case Framework.NetFramework1_1:         return _Create(fw, "NetFramework1_1",       "net11",                strNetFramework);
                case Framework.NetFramework2_0:         return _Create(fw, "NetFramework2_0",       "net20",                strNetFramework);
                case Framework.NetFramework3_5:         return _Create(fw, "NetFramework3_5",       "net35",                strNetFramework);
                case Framework.NetFramework4_0:         return _Create(fw, "NetFramework4_0",       "net40",                strNetFramework);
                case Framework.NetFramework4_0_3:       return _Create(fw, "NetFramework4_0_3",     "net403",               strNetFramework);
                case Framework.NetFramework4_5:         return _Create(fw, "NetFramework4_5",       "net45",                strNetFramework);
                case Framework.NetFramework4_5_1:       return _Create(fw, "NetFramework4_5_1",     "net451",               strNetFramework);
                case Framework.NetFramework4_5_2:       return _Create(fw, "NetFramework4_5_2",     "net452",               strNetFramework);
                case Framework.NetFramework4_6:         return _Create(fw, "NetFramework4_6",       "net46",                strNetFramework);
                case Framework.NetFramework4_6_1:       return _Create(fw, "NetFramework4_6_1",     "net461",               strNetFramework);
                case Framework.NetFramework4_6_2:       return _Create(fw, "NetFramework4_6_2",     "net462",               strNetFramework);
                case Framework.NetFramework4_7:         return _Create(fw, "NetFramework4_7",       "net47",                strNetFramework);
                case Framework.NetFramework4_7_1:       return _Create(fw, "NetFramework4_7_1",     "net471",               strNetFramework);
                case Framework.NetFramework4_7_2:       return _Create(fw, "NetFramework4_7_2",     "net472",               strNetFramework);
                case Framework.NetFramework4_8:         return _Create(fw, "NetFramework4_8",       "net48",                strNetFramework);

                // Windows Store
                case Framework.WindowsStoreNetCore:     return _Create(fw, "WindowsStoreNetCore",       "netcore",          strWindowsStore);
                case Framework.WindowsStoreNetCore4_5:  return _Create(fw, "WindowsStoreNetCore4_5",    "netcore45",        strWindowsStore);
                case Framework.WindowsStoreNetCore4_5_1:return _Create(fw, "WindowsStoreNetCore4_5_1",  "netcore451",       strWindowsStore);

                // .NET Micro Framework
                case Framework.MicroFramework:          return _Create(fw, "MicroFramework",        "netmf",                strMicroFramework);

                // Silverlight
                case Framework.Silverlight1_4:          return _Create(fw, "Silverlight1_4",        "sl4",                  strSilverlight);
                case Framework.Silverlight1_5:          return _Create(fw, "Silverlight1_5",        "sl5",                  strSilverlight);

                // Windows Phone
                case Framework.WindowsPhone:            return _Create(fw, "WindowsPhone",          "wp",                   strWindowsPhone);
                case Framework.WindowsPhone7:           return _Create(fw, "WindowsPhone7",         "wp7",                  strWindowsPhone);
                case Framework.WindowsPhone7_5:         return _Create(fw, "WindowsPhone7_5",       "wp75",                 strWindowsPhone);
                case Framework.WindowsPhone8:           return _Create(fw, "WindowsPhone8",         "wp8",                  strWindowsPhone);
                case Framework.WindowsPhone8_1:         return _Create(fw, "WindowsPhone8_1",       "wp81",                 strWindowsPhone);
                case Framework.WindowsPhoneA8_1:        return _Create(fw, "WindowsPhoneA8_1",      "wpa81",                strWindowsPhone);

                // Universal Windows Platform
                case Framework.UniversalWinPlatform:    return _Create(fw, "UniversalWinPlatform",  "uap",                  strUniversalWinPlat);
                case Framework.UniversalWinPlatform10:  return _Create(fw, "UniversalWinPlatform10","uap10.0",              strUniversalWinPlat);
                default:                                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.Dotnet.Params
{
    public class FullFrameworkInfo
    {
        public FullFramework Framework { get; set; }
        public string Name { get; set; }
        public string Param { get; set; }
        public string Description { get; set; }

        private static FullFrameworkInfo _Create(FullFramework fw, string name, string param, string description)
        { 
            FullFrameworkInfo finfo =   new FullFrameworkInfo();
            finfo.Framework =       fw;
            finfo.Name =            name;
            finfo.Param =           param;
            finfo.Description =     description;
            return finfo;
        }

        public static FullFrameworkInfo Get(FullFramework framework)
        {
            FullFramework fw = framework;

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
                case FullFramework.Default:                    return _Create(fw, "", "", "");

                // .NET 5+ (and .NET Core)
                case FullFramework.NetCore1_0:              return _Create(fw, "NetCore 1.0",            "netcoreapp1.0",        strNet5AndCore);
                case FullFramework.NetCore1_1:              return _Create(fw, "NetCore 1.1",            "netcoreapp1.1",        strNet5AndCore);
                case FullFramework.NetCore2_0:              return _Create(fw, "NetCore 2.0",            "netcoreapp2.0",        strNet5AndCore);
                case FullFramework.NetCore2_1:              return _Create(fw, "NetCore 2.1",            "netcoreapp2.1",        strNet5AndCore);
                case FullFramework.NetCore2_2:              return _Create(fw, "NetCore 2.2",            "netcoreapp2.2",        strNet5AndCore);
                case FullFramework.NetCore3_0:              return _Create(fw, "NetCore 3.0",            "netcoreapp3.0",        strNet5AndCore);
                case FullFramework.NetCore3_1:              return _Create(fw, "NetCore 3.1",            "netcoreapp3.1",        strNet5AndCore);
                case FullFramework.DotNet5_0:               return _Create(fw, "DotNet 5.0",             "net5.0",               strNet5AndCore);
                case FullFramework.DotNet5_0_windows:       return _Create(fw, "DotNet 5.0 windows",     "net5.0-windows",       strNet5AndCore);
                case FullFramework.DotNet6_0:               return _Create(fw, "DotNet 6.0",             "net6.0",               strNet5AndCore);
                case FullFramework.DotNet6_0_android:       return _Create(fw, "DotNet 6.0 android",     "net6.0-android",       strNet5AndCore);
                case FullFramework.DotNet6_0_ios:           return _Create(fw, "DotNet 6.0 ios",         "net6.0-ios",           strNet5AndCore);
                case FullFramework.DotNet6_0_maccatalyst:   return _Create(fw, "DotNet 6.0 maccatalyst", "net6.0-maccatalyst",   strNet5AndCore);
                case FullFramework.DotNet6_0_macos:         return _Create(fw, "DotNet 6.0 macos",       "net6.0-macos",         strNet5AndCore);
                case FullFramework.DotNet6_0_tvos:          return _Create(fw, "DotNet 6.0 tvos",        "net6.0-tvos",          strNet5AndCore);
                case FullFramework.DotNet6_0_windows:       return _Create(fw, "DotNet 6.0 windows",     "net6.0-windows",       strNet5AndCore);
                case FullFramework.DotNet7_0:               return _Create(fw, "DotNet 7.0",             "net7.0",               strNet5AndCore);
                case FullFramework.DotNet7_0_android:       return _Create(fw, "DotNet 7.0 android",     "net7.0-android",       strNet5AndCore);
                case FullFramework.DotNet7_0_ios:           return _Create(fw, "DotNet 7.0 ios",         "net7.0-ios",           strNet5AndCore);
                case FullFramework.DotNet7_0_maccatalyst:   return _Create(fw, "DotNet 7.0 maccatalyst", "net7.0-maccatalyst",   strNet5AndCore);
                case FullFramework.DotNet7_0_macos:         return _Create(fw, "DotNet 7.0 macos",       "net7.0-macos",         strNet5AndCore);
                case FullFramework.DotNet7_0_tvos:          return _Create(fw, "DotNet 7.0 tvos",        "net7.0-tvos",          strNet5AndCore);
                case FullFramework.DotNet7_0_windows:       return _Create(fw, "DotNet 7.0 windows",     "net7.0-windows",       strNet5AndCore);
                case FullFramework.DotNet8_0:               return _Create(fw, "DotNet 8.0",             "net8.0",               strNet5AndCore);
                case FullFramework.DotNet8_0_android:       return _Create(fw, "DotNet 8.0 android",     "net8.0-android",       strNet5AndCore);
                case FullFramework.DotNet8_0_browser:       return _Create(fw, "DotNet 8.0 browser",     "net8.0-browser",       strNet5AndCore);
                case FullFramework.DotNet8_0_ios:           return _Create(fw, "DotNet 8.0 ios",         "net8.0-ios",           strNet5AndCore);
                case FullFramework.DotNet8_0_maccatalyst:   return _Create(fw, "DotNet 8.0 maccatalyst", "net8.0-maccatalyst",   strNet5AndCore);
                case FullFramework.DotNet8_0_macos:         return _Create(fw, "DotNet 8.0 macos",       "net8.0-macos",         strNet5AndCore);
                case FullFramework.DotNet8_0_tvos:          return _Create(fw, "DotNet 8.0 tvos",        "net8.0-tvos",          strNet5AndCore);
                case FullFramework.DotNet8_0_windows:       return _Create(fw, "DotNet 8.0 windows",     "net8.0-windows",       strNet5AndCore);

                // .NET Standard
                case FullFramework.NetStandard1_0:          return _Create(fw, "NetStandard 1.0",        "netstandard1.0",       strNetStandard);
                case FullFramework.NetStandard1_1:          return _Create(fw, "NetStandard 1.1",        "netstandard1.1",       strNetStandard);
                case FullFramework.NetStandard1_2:          return _Create(fw, "NetStandard 1.2",        "netstandard1.2",       strNetStandard);
                case FullFramework.NetStandard1_3:          return _Create(fw, "NetStandard 1.3",        "netstandard1.3",       strNetStandard);
                case FullFramework.NetStandard1_4:          return _Create(fw, "NetStandard 1.4",        "netstandard1.4",       strNetStandard);
                case FullFramework.NetStandard1_5:          return _Create(fw, "NetStandard 1.5",        "netstandard1.5",       strNetStandard);
                case FullFramework.NetStandard1_6:          return _Create(fw, "NetStandard 1.6",        "netstandard1.6",       strNetStandard);
                case FullFramework.NetStandard2_0:          return _Create(fw, "NetStandard 2.0",        "netstandard2.0",       strNetStandard);
                case FullFramework.NetStandard2_1:          return _Create(fw, "NetStandard 2.1",        "netstandard2.1",       strNetStandard);

                // .NET Framework
                case FullFramework.NetFramework1_1:         return _Create(fw, "NetFramework 1.1",       "net11",                strNetFramework);
                case FullFramework.NetFramework2_0:         return _Create(fw, "NetFramework 2.0",       "net20",                strNetFramework);
                case FullFramework.NetFramework3_5:         return _Create(fw, "NetFramework 3.5",       "net35",                strNetFramework);
                case FullFramework.NetFramework4_0:         return _Create(fw, "NetFramework 4.0",       "net40",                strNetFramework);
                case FullFramework.NetFramework4_0_3:       return _Create(fw, "NetFramework 4.0.3",     "net403",               strNetFramework);
                case FullFramework.NetFramework4_5:         return _Create(fw, "NetFramework 4.5",       "net45",                strNetFramework);
                case FullFramework.NetFramework4_5_1:       return _Create(fw, "NetFramework 4.5.1",     "net451",               strNetFramework);
                case FullFramework.NetFramework4_5_2:       return _Create(fw, "NetFramework 4.5.2",     "net452",               strNetFramework);
                case FullFramework.NetFramework4_6:         return _Create(fw, "NetFramework 4.6",       "net46",                strNetFramework);
                case FullFramework.NetFramework4_6_1:       return _Create(fw, "NetFramework 4.6.1",     "net461",               strNetFramework);
                case FullFramework.NetFramework4_6_2:       return _Create(fw, "NetFramework 4.6.2",     "net462",               strNetFramework);
                case FullFramework.NetFramework4_7:         return _Create(fw, "NetFramework 4.7",       "net47",                strNetFramework);
                case FullFramework.NetFramework4_7_1:       return _Create(fw, "NetFramework 4.7.1",     "net471",               strNetFramework);
                case FullFramework.NetFramework4_7_2:       return _Create(fw, "NetFramework 4.7.2",     "net472",               strNetFramework);
                case FullFramework.NetFramework4_8:         return _Create(fw, "NetFramework 4.8",       "net48",                strNetFramework);

                // Windows Store
                case FullFramework.WindowsStoreNetCore:     return _Create(fw, "WindowsStoreNetCore",       "netcore",          strWindowsStore);
                case FullFramework.WindowsStoreNetCore4_5:  return _Create(fw, "WindowsStoreNetCore 4.5",   "netcore45",        strWindowsStore);
                case FullFramework.WindowsStoreNetCore4_5_1:return _Create(fw, "WindowsStoreNetCore 4.5.1", "netcore451",       strWindowsStore);

                // .NET Micro Framework
                case FullFramework.MicroFramework:          return _Create(fw, "MicroFramework",        "netmf",                strMicroFramework);

                // Silverlight
                case FullFramework.Silverlight1_4:          return _Create(fw, "Silverlight1_4",        "sl4",                  strSilverlight);
                case FullFramework.Silverlight1_5:          return _Create(fw, "Silverlight1_5",        "sl5",                  strSilverlight);

                // Windows Phone
                case FullFramework.WindowsPhone:            return _Create(fw, "WindowsPhone",          "wp",                   strWindowsPhone);
                case FullFramework.WindowsPhone7:           return _Create(fw, "WindowsPhone7",         "wp7",                  strWindowsPhone);
                case FullFramework.WindowsPhone7_5:         return _Create(fw, "WindowsPhone7_5",       "wp75",                 strWindowsPhone);
                case FullFramework.WindowsPhone8:           return _Create(fw, "WindowsPhone8",         "wp8",                  strWindowsPhone);
                case FullFramework.WindowsPhone8_1:         return _Create(fw, "WindowsPhone8_1",       "wp81",                 strWindowsPhone);
                case FullFramework.WindowsPhoneA8_1:        return _Create(fw, "WindowsPhoneA8_1",      "wpa81",                strWindowsPhone);

                // Universal Windows Platform
                case FullFramework.UniversalWinPlatform:    return _Create(fw, "UniversalWinPlatform",  "uap",                  strUniversalWinPlat);
                case FullFramework.UniversalWinPlatform10:  return _Create(fw, "UniversalWinPlatform10","uap10.0",              strUniversalWinPlat);
                default:                                return null;
            }
        }
    }
}

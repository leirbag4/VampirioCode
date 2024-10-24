using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.BuilderSetting.Others
{
    public class IncludeSourcesModeInfo
    {
        public string Name { get; set; } = "";
        public IncludeSourcesMode Mode { get; set; }

        private static bool _init = false;
        private static List<IncludeSourcesModeInfo> includeSourcesModeInfos = new List<IncludeSourcesModeInfo>();

        private static void Initialize()
        {
            if (_init)
                return;

            _Create(IncludeSourcesMode.Default,     "Default");
            _Create(IncludeSourcesMode.Manually,    "Manually");
            _Create(IncludeSourcesMode.Automatic,   "Automatic");

            _init = true;
        }

        public static IncludeSourcesModeInfo Get(IncludeSourcesMode mode)
        {
            Initialize();
            return includeSourcesModeInfos.FirstOrDefault(info => info.Mode == mode);
        }

        public static IncludeSourcesModeInfo GetByName(string name)
        {
            Initialize();
            return includeSourcesModeInfos.FirstOrDefault(info => info.Name == name);
        }

        private static IncludeSourcesModeInfo _Create(IncludeSourcesMode mode, string name)
        {
            IncludeSourcesModeInfo modeInfo = new IncludeSourcesModeInfo();
            modeInfo.Mode = mode;
            modeInfo.Name = name;
            includeSourcesModeInfos.Add(modeInfo);
            return modeInfo;
        }
    }
}

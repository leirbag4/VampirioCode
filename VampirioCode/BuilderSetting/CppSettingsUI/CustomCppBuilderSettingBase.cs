using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.BuilderSetting.CppSettings;
using VampirioCode.BuilderSetting.Others;
using VampirioCode.BuilderSetting.UI;
using VampirioCode.UI.Controls;

namespace VampirioCode.BuilderSetting.CppSettingsUI
{
    public class CustomCppBuilderSettingBase : CustomBuilderSettingBase
    {
        protected IncludeSourcesMode GetIncludeSourceFilesMode(ItemListSources ilist)
        {
            return ilist.GetMode();
        }

        protected List<string> GetSourceFiles(ItemListSources ilist, CppBSettingBase bsetting)
        {
            return ilist.GetSources(bsetting);
        }

        protected void SetSourceFiles(ItemListSources ilist, CppBSettingBase bsetting)
        {
            ilist.LoadAndSetMode(bsetting);
        }
    }
}

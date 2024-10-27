using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.BuilderSetting.CppSettings;
using VampirioCode.BuilderSetting.Others;
using VampirioCode.UI;
using VampirioCode.UI.Controls;

namespace VampirioCode.BuilderSetting.Utils
{
    public class BuilderSettingsUtils
    {

        /*public static void SetupIncludeSourcesMode(ComboBoxAdv comboBox, ItemList list, CppBSettingBase bsetting, Func<IncludeSourcesMode, int> retFunc)
        {
            foreach (IncludeSourcesMode mode in Enum.GetValues(typeof(IncludeSourcesMode)))
            {
                var modeInfo = IncludeSourcesModeInfo.Get(mode);
                if (modeInfo.Name != "")
                    comboBox.Items.Add(modeInfo.Name);
            }

            if (bsetting.IncludeSourcesMode == IncludeSourcesMode.Manually)
            {
                foreach(string src in bsetting.SourceFiles)
                    list.Add(new VampirioCode.UI.Controls.VerticalItemListManagement.SItemBrowsable() { Text = src });
            }

            comboBox.SelectedIndexChanged += (sender, e) =>
            {
                ComboBoxAdv option = sender as ComboBoxAdv;
                if (option != null)
                {
                    IncludeSourcesMode mode = IncludeSourcesModeInfo.GetByName(option.Text).Mode;
                    //bsetting.IncludeSourcesMode = mode;

                    if (mode == IncludeSourcesMode.Default)
                    {
                        list.Enable = false;
                        list.Clear();
                        //bsetting.SourceFiles.Clear();
                    }
                    else if (mode == IncludeSourcesMode.Manually)
                    {
                        list.Enable = true;

                        //foreach(string src in bsetting.SourceFiles)
                        //    list.Add(new VampirioCode.UI.Controls.VerticalItemListManagement.SItemBrowsable() { Text = src });
                    }
                    else if (mode == IncludeSourcesMode.Automatic)
                    {
                        list.Enable = true;
                        list.Clear();
                        //bsetting.SourceFiles.Clear();
                        //list.Add(new VampirioCode.UI.Controls.VerticalItemListManagement.SItemBrowsable() { Text = "capo" });
                        //list.Add(new VampirioCode.UI.Controls.VerticalItemListManagement.SItemBrowsable() { Text = "tester" });
                    }

                    retFunc(mode);

                }
            };

        }*/

    }
}

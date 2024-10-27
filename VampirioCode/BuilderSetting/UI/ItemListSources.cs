using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.Builder.Custom;
using VampirioCode.BuilderSetting.CppSettings;
using VampirioCode.BuilderSetting.Others;
using VampirioCode.Properties;
using VampirioCode.UI;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.VerticalItemListManagement;
using VampirioCode.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static VampirioCode.UI.Controls.VerticalItemListManagement.LItem;

namespace VampirioCode.BuilderSetting.UI
{
    public partial class ItemListSources : UserControl
    {

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Icon")]
        [Browsable(true)]
        public Image Icon { get { return List.Icon; } set { List.Icon = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Title")]
        [Browsable(true)]
        public string Title { get { return List.Title; } set { List.Title = value; } }

        public bool Enable { get { return List.Enable; } set { List.Enable = value; } }


        public ItemList List { get { return itemList; } }

        private string originalBaseDir = "";

        public ItemListSources()
        {
            InitializeComponent();
        }

        public void Setup(string title, string combineRelativePath, string filter, CppBSettingBase bsetting, CustomBuilder builder)
        {
            originalBaseDir = builder.GetOriginalBaseDir();

            List.SetupFileMode(new FileBrowseInfo(title, combineRelativePath, filter));

            // Fill comboBox with IncludeSourcesModes
            foreach (IncludeSourcesMode mode in Enum.GetValues(typeof(IncludeSourcesMode)))
            {
                var modeInfo = IncludeSourcesModeInfo.Get(mode);
                if (modeInfo.Name != "")
                    modesCBox.Items.Add(modeInfo.Name);
            }

            // Add Events
            modesCBox.SelectedIndexChanged += OnModeChanged;
            List.ItemModified += OnItemModified;
            
        }

        private void OnItemModified()
        {
            var mode = GetMode();

            if (mode != IncludeSourcesMode.Manually)
                _SelectMode(IncludeSourcesMode.Manually);
        }

        public void LoadAndSetMode(CppBSettingBase bsetting)
        {
            // Fill the list if previous saved setting was 'Manually'
            if (bsetting.IncludeSourcesMode == IncludeSourcesMode.Manually)
            {
                foreach (string src in bsetting.SourceFiles)
                    List.Add(new VampirioCode.UI.Controls.VerticalItemListManagement.SItemBrowsable() { Text = src });
            }

            // Select mode
            _SelectMode(bsetting.IncludeSourcesMode);
        }

        private void _SelectMode(IncludeSourcesMode mode)
        {
            // Select mode
            modesCBox.SelectedItem = IncludeSourcesModeInfo.Get(mode).Name;
        }

        public IncludeSourcesMode GetMode()
        {
            return IncludeSourcesModeInfo.GetByName(modesCBox.SelectedItem.ToString()).Mode;
        }

        public List<string> GetSources(CppBSettingBase bsetting)
        {
            List<string> sources = new List<string>();

            if (bsetting.IncludeSourcesMode == IncludeSourcesMode.Manually)
            {
                foreach (var item in List.Items)
                    sources.Add(item.Text);
            }

            return sources;
        }

        private void OnModeChanged(object sender, EventArgs e)
        {

            ComboBoxAdv option = sender as ComboBoxAdv;
            if (option != null)
            {
                IncludeSourcesMode mode = IncludeSourcesModeInfo.GetByName(option.Text).Mode;

                if (mode == IncludeSourcesMode.Default)
                {
                    List.Enable = false;
                    List.Clear();
                }
                else if (mode == IncludeSourcesMode.Manually)
                {
                    List.Enable = true;

                }
                else if (mode == IncludeSourcesMode.Automatic)
                {
                    List.Enable = true;
                    List.Clear();

                    var files = FileUtils.GetFilesAdv(originalBaseDir, new string[] { ".cpp", ".h" });

                    foreach (var file in files)
                    {
                        string filePath = file;
                        List.Add(new SItemBrowsable() { Text = filePath });
                    }
                }


            }

        }
    }
}

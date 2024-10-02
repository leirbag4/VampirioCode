using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.BuilderSetting;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.VerticalItemListManagement;

namespace VampirioCode.Tests
{
    public partial class ItemListTester : VampirioForm
    {
        SItemValuePairEditable item;
        public ItemListTester()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            /*itemList2.SetupValuePair(0.35f);
            itemList2.Add(new SItemValuePairEditable() { LeftValue = "test", RightValue = "Loco", LeftEditable = false });

            item = new SItemValuePairEditable();
            item.LeftValue = "Data";
            item.RightValue = "Info";

            itemList.Items.Add(item);*/


            itemList2.SetupValuePairBrowsable(0.35f);
            
            itemList2.Add(new SItemValuePairBrowsable() { LeftValue = "test", RightValue = "Loco", LeftEditable = false });


            SItemValuePairBrowsable item2 = new SItemValuePairBrowsable();
            item2.LeftValue = "Capo";
            item2.RightValue = "tester";
            item2.BrowseInfo = new DirBrowseInfo();
            item2.LeftBrowseInfo = new FileBrowseInfo("Choose .lib files", false, "DLL files (*.dll)|*.dll|LIB files (*.lib)|*.lib");

            itemList.Items.Add(item2);

            //itemList2.SetupDirMode();

            base.OnLoad(e);
        }

        private void OnSliderChanged(object sender, EventArgs e)
        {

            float value = slider.Value / 100f;

            divisionOutp.value = (decimal)value;

            item.Division = value;

        }

    }
}

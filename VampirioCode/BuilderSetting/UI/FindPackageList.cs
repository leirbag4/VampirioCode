using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.VerticalItemListManagement;
using VampirioCode.Utils;

namespace VampirioCode.BuilderSetting.UI
{
    public partial class FindPackageList : VampirioForm
    {
        public string SelectedPackage { get { return _selectedPackage; } }

        private string _selectedPackage = "";

        public FindPackageList()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string[] packages = FileUtils.GetFileNamesAt(AppInfo.PackagesPath, false);

            foreach (string package in packages)
            {
                SItem item = new SItem();
                item.Text = package;
                itemList.Items.Add(item);
            }

            itemList.Items.Add(new SItem() { Text = "none" });

            _SetPackage(_selectedPackage);
        }

        public void SetPackage(string name)
        {
            _selectedPackage = name;
            _SetPackage(_selectedPackage);
        }

        public void _SetPackage(string name)
        {
            name = name.Trim();

            if (name == "")
                name = "none";

            for (int a = 0; a < itemList.Items.Count; a++)
            {
                SItem item = (SItem)itemList.Items[a];

                if (item.Text == name)
                {
                    itemList.SelectedIndex = a;
                    break;
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (itemList.SelectedItem == null)
                _selectedPackage = "";
            else
                _selectedPackage = ((SItem)itemList.SelectedItem).Text;
            
            if (_selectedPackage.Trim().ToLower() == "none")
                _selectedPackage = "";

        }

        private void OnDoubleClickPressed(object sender)
        {
            this.Close();
        }
    }
}

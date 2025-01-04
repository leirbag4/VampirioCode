using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.UI.Controls.VerticalItemListManagement;
using VampirioCode.UI.Controls.VerticalItemListManagement.Components;

namespace VampirioCode.BuilderSetting.UI
{
    public partial class ItemListPackages : UserControl
    {
        // Events
        public event ItemModifiedEvent ItemModified;

        //public string SelectedPackages { get { return input.Text; } set { input.Text = value; } }

        public ItemListPackages()
        {
            InitializeComponent();
        }

        public List<string> GetPackages()
        {
            List<string> packages = new List<string>();

            foreach (var item in list.Items)
            {
                packages.Add(item.Text);
            }

            return packages;
        }

        public void SetPackages(List<string> packages)
        {
            foreach (var package in packages) 
            {
                SItem item = new SItem();
                item.Text = package;
                list.AddItem(item);
            }
        }

        private void OnFindPackagePressed(object sender, EventArgs e)
        {
            FindPackageList findPackage = new FindPackageList();
            findPackage.ShowMe((ContainerControl)this.Parent);
            string packageName = findPackage.SelectedPackage;


            if ((packageName != "") && (packageName != "none"))
            {
                if (ContainsPackage(packageName))
                    return;

                SItem item = new SItem();
                item.Text = findPackage.SelectedPackage;
                list.AddItem(item);
                TriggerItemModifiedEvent();
            }
        }

        private bool ContainsPackage(string packageName)
        {
            foreach (var item in list.Items)
            {
                if (item.Text == packageName)
                    return true;
            }

            return false;
        }

        private void OnRemovePressed(object sender, EventArgs e)
        {
            if (list.SelectedIndex != -1)
            {
                list.Items.RemoveAt(list.SelectedIndex);
                TriggerItemModifiedEvent();
            }
        }

        private void TriggerItemModifiedEvent()
        {
            if (ItemModified != null)
                ItemModified();
        }

        private void OnUpPressed(object sender, EventArgs e)
        {
            if (list.SelectedIndex != -1)
            {
                list.MoveItemUp(list.SelectedIndex);
                TriggerItemModifiedEvent();
            }
        }

        private void OnDownPressed(object sender, EventArgs e)
        {
            if (list.SelectedIndex != -1)
            {
                list.MoveItemDown(list.SelectedIndex);
                TriggerItemModifiedEvent();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.Builder;
using VampirioCode.BuilderSetting.Actions;
using VampirioCode.BuilderSetting.UI;
using VampirioCode.Command.MSVC.Params;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.VerticalItemListManagement;

namespace VampirioCode.BuilderSetting
{
    public partial class CustomBuilderSettingBase : VampirioForm
    {
        public CustomBuilderSettingBase()
        {
            
        }

        public virtual void Open(string projName, BuilderType builderType)
        {
            
        }

        protected void SetItemListSBrowsable(ItemList itemList, List<string> items)
        {
            if (items == null) return;

            foreach (string itemStr in items)
            {
                SItemBrowsable item = new SItemBrowsable() { Text = itemStr };
                itemList.Add(item);
            }
        }

        protected void SetItemListValuePair(ItemList itemList, List<VariableAction> items)
        {
            if (items == null) return;

            foreach (VariableAction itm in items)
            {
                SItemValuePairEditable item = new SItemValuePairEditable() { LeftValue = itm.Name, RightValue = itm.Value };
                itemList.Add(item);
            }
        }

        protected void SetItemListValuePairBrowsable(ItemList itemList, List<CopyAction> items)
        {
            if (items == null) return;

            foreach (CopyAction itm in items)
            {
                SItemValuePairBrowsable item = new SItemValuePairBrowsable() { LeftValue = itm.From, RightValue = itm.To };
                itemList.Add(item);
            }
        }

        protected void SetFindPackage(FindPackageInput findPackageInp, string packageName)
        {
            findPackageInp.SelectedPackage = packageName;
        }

        // ---------------------------------------------------------------
        // ---------------------------------------------------------------
        // ---------------------------------------------------------------

        protected List<string> GetItemListSBrowsable(ItemList itemList)
        {
            List<string> arr = new List<string>();

            foreach (SItemBrowsable itm in itemList.Items)
                arr.Add(itm.Text);

            return arr;
        }

        protected List<VariableAction> GetItemListValuePair(ItemList itemList)
        {
            List<VariableAction> vars = new List<VariableAction>();

            foreach (SItemValuePairEditable itm in itemList.Items)
                vars.Add(new VariableAction() { Name = itm.LeftValue, Value = itm.RightValue });

            return vars;
        }

        protected List<CopyAction> GetItemListValuePairBrowsable(ItemList itemList)
        {
            List<CopyAction> vars = new List<CopyAction>();

            foreach (SItemValuePairBrowsable itm in itemList.Items)
                vars.Add(new CopyAction() { From = itm.LeftValue, To = itm.RightValue, Overwrite = true });

            return vars;
        }

        protected string GetFindPackage(FindPackageInput findPackageInp)
        {
            return findPackageInp.SelectedPackage;
        }

    }
}

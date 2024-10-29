using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VampirioCode.Builder;
using VampirioCode.BuilderSetting.Actions;
using VampirioCode.BuilderSetting.UI;
using VampirioCode.Command.MSVC.Params;
using VampirioCode.UI;
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

        public virtual void RefreshExtraData()
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
        public static void SetComboBoxEnum<TEnum, TInfo>(ComboBox comboBox, TEnum enumValue, string property) where TEnum : Enum
        {
            // Get the 'Get' method from the TInfo class using reflection
            var getMethod = typeof(TInfo).GetMethod("Get", BindingFlags.Public | BindingFlags.Static);

            if (getMethod != null)
            {
                // Invoke the 'Get' method, passing the enumeration value
                var infoInstance = getMethod.Invoke(null, new object[] { enumValue });

                if (infoInstance != null)
                {
                    // Get the 'Param' property from the infoInstance
                    var paramProperty = infoInstance.GetType().GetProperty(property);

                    if (paramProperty != null)
                    {
                        // Retrieve the 'Param' value and set it as the selected item in the ComboBox
                        string paramValue = paramProperty.GetValue(infoInstance) as string;
                        comboBox.SelectedItem = paramValue;
                    }
                }
            }
        }


        public void SetupComboBoxEnums<TEnum, TInfo>(ComboBox comboBox, string property) where TEnum : Enum
        {
            // Get all values of the TEnum enumeration
            foreach (TEnum enumValue in Enum.GetValues(typeof(TEnum)))
            {
                // Get the 'Get' method of the TInfo class using reflection
                var getMethod = typeof(TInfo).GetMethod("Get", BindingFlags.Public | BindingFlags.Static);

                if (getMethod != null)
                {
                    // Invoke the 'Get' method, passing the enumeration value
                    var infoInstance = getMethod.Invoke(null, new object[] { enumValue });

                    // Get the 'Param' property of the returned instance
                    var paramProperty = infoInstance.GetType().GetProperty(property);

                    if (paramProperty != null)
                    {
                        string paramValue = paramProperty.GetValue(infoInstance) as string;

                        // Verify that the parameter is not empty before adding it
                        if (!string.IsNullOrEmpty(paramValue))
                        {
                            comboBox.Items.Add(paramValue);
                        }
                    }
                }
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

        public static TEnum GetComboBoxEnum<TEnum, TInfo>(ComboBox comboBox, string methodName) where TEnum : Enum
        {
            // Get the selected parameter from the ComboBox
            string selectedParam = comboBox.SelectedItem.ToString();

            // Get the 'GetByParam' method of TInfo using reflection
            var getByParamMethod = typeof(TInfo).GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);


            if (getByParamMethod != null)
            {
                // Invoke the 'GetByParam' method, passing the selected parameter
                var infoInstance = getByParamMethod.Invoke(null, new object[] { selectedParam });


                // Get the enumeration value from the instance (assuming it's named like TEnum)
                var enumProperty = infoInstance.GetType().GetProperty(typeof(TEnum).Name);
                //var enumProperty = infoInstance.GetType().GetProperty(property);

                if (enumProperty != null)
                {
                    return (TEnum)enumProperty.GetValue(infoInstance);
                }

            }

            throw new InvalidOperationException("Unable to retrieve enum value.");
        }

        protected string GetFindPackage(FindPackageInput findPackageInp)
        {
            return findPackageInp.SelectedPackage;
        }

    }
}

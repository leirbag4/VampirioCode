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
using VampirioCode.Builder.Custom;
using VampirioCode.BuilderSetting.Actions;
using VampirioCode.BuilderSetting.UI;
using VampirioCode.Command.MSVC.Params;
using VampirioCode.Properties;
using VampirioCode.UI;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.VerticalItemListManagement;

namespace VampirioCode.BuilderSetting
{
    public partial class CustomMsvcCppBuilderSetting : VampirioForm
    {
        private CustomMsvcCppBuilder builder;

        public CustomMsvcCppBuilderSetting()
        {
            InitializeComponent();
        }

        public void Open(string projName, BuilderType builderType)
        {
            builder = (CustomMsvcCppBuilder)CustomBuilders.Get(projName, builderType);

            //XConsole.Alert("t:" + builder.Setting.CopyDirsPre.Count);
            //XConsole.Alert("t -> " + builder.Setting.CopyDirsPre[0].From);
            //XConsole.Alert("t:" + builder.Setting.IncludeDirs.Count);


            ShowDialog();
        }

        protected override void OnLoad(EventArgs e)
        {
            includeDirsList.SetupDirMode();
            libraryDirsList.SetupDirMode();
            libraryFilesList.SetupFileMode(new FileBrowseInfo("Choose .lib files", false, "DLL files (*.dll)|*.dll|LIB files (*.lib)|*.lib"));
            macrosList.SetupValuePair(0.5f, true, true);

            foreach (ExceptionHandlingModel model in Enum.GetValues(typeof(ExceptionHandlingModel)))
            {
                var modelInfo = ExceptionHandlingModelInfo.Get(model);
                if(modelInfo.Param != "")
                    exceptHandlModeCBox.Items.Add(modelInfo.Param);
            }


            OnLoadData();

            base.OnLoad(e);
        }

        protected void OnLoadData()
        {
            var settings = builder.Setting;

            SetItemListSBrowsable(includeDirsList,          settings.IncludeDirs);
            SetItemListSBrowsable(libraryDirsList,          settings.LibraryDirs);
            SetItemListSBrowsable(libraryFilesList,         settings.LibraryFiles);
            SetItemListValuePair(macrosList,                settings.PreprocessorMacros);
            SetFindPackage(findPackageInput,                settings.InstallPackage);

            SetExceptionHandlingMode(exceptHandlModeCBox,   settings.ExceptionHanldingModel);
        }

        private void OnSaveData()
        {
            var settings = builder.Setting;

            settings.IncludeDirs =              GetItemListSBrowsable(includeDirsList);
            settings.LibraryDirs =              GetItemListSBrowsable(libraryDirsList);
            settings.LibraryFiles =             GetItemListSBrowsable(libraryFilesList);
            settings.PreprocessorMacros =       GetItemListValuePair(macrosList);
            settings.InstallPackage =           GetFindPackage(findPackageInput);

            settings.ExceptionHanldingModel =   GetExceptionHandlingMode(exceptHandlModeCBox);

            builder.Save();
        }

        private void SetItemListSBrowsable(ItemList itemList, List<string> items)
        {
            foreach (string itemStr in items)
            {
                SItemBrowsable item = new SItemBrowsable() { Text = itemStr };
                itemList.Add(item);
            }
        }

        private void SetItemListValuePair(ItemList itemList, List<VariableAction> items)
        {
            foreach (VariableAction itm in items)
            {
                SItemValuePairEditable item = new SItemValuePairEditable() { LeftValue = itm.Name, RightValue = itm.Value };
                itemList.Add(item);
            }
        }

        private void SetFindPackage(FindPackageInput findPackageInp, string packageName)
        {
            findPackageInp.SelectedPackage = packageName;
        }

        private void SetExceptionHandlingMode(ComboBoxAdv comboBox, ExceptionHandlingModel model)
        {
            string param = ExceptionHandlingModelInfo.Get(model).Param;
            comboBox.SelectedItem = param;
        }

        // ---------------------------------------------------------------
        // ---------------------------------------------------------------
        // ---------------------------------------------------------------

        private List<string> GetItemListSBrowsable(ItemList itemList)
        {
            List<string> arr = new List<string>();

            foreach (SItemBrowsable itm in itemList.Items)
                arr.Add(itm.Text);

            return arr;
        }

        private List<VariableAction> GetItemListValuePair(ItemList itemList)
        {
            List<VariableAction> vars = new List<VariableAction>();

            foreach (SItemValuePairEditable itm in itemList.Items)
                vars.Add(new VariableAction() { Name = itm.LeftValue, Value = itm.RightValue });

            return vars;
        }

        private string GetFindPackage(FindPackageInput findPackageInp)
        {
            return findPackageInp.SelectedPackage;
        }

        private ExceptionHandlingModel GetExceptionHandlingMode(ComboBoxAdv comboBox)
        {
            string param = comboBox.SelectedItem.ToString();
            return ExceptionHandlingModelInfo.GetByParam(param).ExceptionHandlingModel;
        }

        private void OnOkPressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            OnSaveData();
            this.Close();
        }

        private void OnCancelPressed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}

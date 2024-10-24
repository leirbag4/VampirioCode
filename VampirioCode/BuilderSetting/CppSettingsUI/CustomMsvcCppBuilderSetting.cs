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
using VampirioCode.BuilderSetting.Others;
using VampirioCode.BuilderSetting.UI;
using VampirioCode.BuilderSetting.Utils;
using VampirioCode.Command.MSVC.Params;
using VampirioCode.Properties;
using VampirioCode.UI;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.VerticalItemListManagement;
using VampirioCode.Utils;

namespace VampirioCode.BuilderSetting
{
    public partial class CustomMsvcCppBuilderSetting : CustomBuilderSettingBase
    {
        private CustomMsvcCppBuilder builder;

        public CustomMsvcCppBuilderSetting()
        {
            InitializeComponent();
        }

        public override void Open(string fullFilePath, BuilderType builderType)
        {
            builder = (CustomMsvcCppBuilder)CustomBuilders.GetBuilder(fullFilePath, builderType);

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
            sourceFilesList.SetupFileMode(new FileBrowseInfo("Choose .cpp and .h files", false, "CPP files (*.cpp)|*.cpp|H files (*.h)|*.h"));
            BuilderSettingsUtils.SetupIncludeSourcesMode(sourceFilesIncludeMode, sourceFilesList, builder.Setting, OnSourcesModeChanged);

            postCopyDirsList.SetupValuePairBrowsable(new ValuePairBrowseInfo() { BrowseInfo = new DirBrowseInfo() { Title = "Select a Directory" } });
            postCopyFilesList.SetupValuePairBrowsable(new ValuePairBrowseInfo() { LeftBrowseInfo = new FileBrowseInfo("Select Files", true, "DLL files (*.dll)|*.dll|LIB files (*.lib)|*.lib|All Files (*.*)|*.*"), RightBrowseInfo = new DirBrowseInfo() { Title = "Select a Directory"} });

            foreach (StandardVersion std in Enum.GetValues(typeof(StandardVersion)))
            {
                var stdInfo = StandardVersionInfo.Get(std);
                if (stdInfo.Param != "")
                    standardVersionCBox.Items.Add(stdInfo.Param);
            }

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

            SetItemListSBrowsable(includeDirsList,              settings.IncludeDirs);
            SetItemListSBrowsable(libraryDirsList,              settings.LibraryDirs);
            SetItemListSBrowsable(libraryFilesList,             settings.LibraryFiles);
            SetItemListValuePair(macrosList,                    settings.PreprocessorMacros);
            SetFindPackage(findPackageInput,                    settings.InstallPackage);
            SetItemListValuePairBrowsable(postCopyDirsList,     settings.CopyDirsPost);
            SetItemListValuePairBrowsable(postCopyFilesList,    settings.CopyFilesPost);

            SetStandardVersion(standardVersionCBox,             settings.StandardVersion);
            SetExceptionHandlingMode(exceptHandlModeCBox,       settings.ExceptionHanldingModel);

            RefreshExtraData();
        }

        private void OnSaveData()
        {
            var settings = builder.Setting;

            settings.IncludeDirs =              GetItemListSBrowsable(includeDirsList);
            settings.LibraryDirs =              GetItemListSBrowsable(libraryDirsList);
            settings.LibraryFiles =             GetItemListSBrowsable(libraryFilesList);
            settings.PreprocessorMacros =       GetItemListValuePair(macrosList);
            settings.InstallPackage =           GetFindPackage(findPackageInput);
            settings.CopyDirsPost =             GetItemListValuePairBrowsable(postCopyDirsList);
            settings.CopyFilesPost =            GetItemListValuePairBrowsable(postCopyFilesList);

            settings.StandardVersion =          GetStandardVersion(standardVersionCBox);
            settings.ExceptionHanldingModel =   GetExceptionHandlingMode(exceptHandlModeCBox);

            builder.Save();
        }

        public override void RefreshExtraData()
        {
            //SetupAndFillIncludeSources();
            //XConsole.Alert("entrer");
            //FileUtils.GetFilesAdv(builder.GetOriginalBaseDir());
            //SetupAutoInclude(autoIncludeSourcesCKBox, autoIncludeSourcesList);
        }

        private int OnSourcesModeChanged(IncludeSourcesMode mode)
        {
            if (mode == IncludeSourcesMode.Automatic)
            {
                //XConsole.Alert("ori: " + builder.GetOriginalBaseDir());

                XConsole.LogInfo(builder.ToString());
                
                var files = FileUtils.GetFilesAdv(builder.GetOriginalBaseDir(), new string[] { ".cpp", ".h" });

                XConsole.Detach();
                foreach (var file in files)
                {
                    XConsole.Println(" - > " + file);
                }

                //foreach (var file in files)
                //    sourceFilesList.Add(new SItemBrowsable() { Text = file });
            }

            return 0;
        }

        private void SetStandardVersion(ComboBoxAdv comboBox, StandardVersion std)
        {
            string param = StandardVersionInfo.Get(std).Param;
            comboBox.SelectedItem = param;
        }

        private void SetExceptionHandlingMode(ComboBoxAdv comboBox, ExceptionHandlingModel model)
        {
            string param = ExceptionHandlingModelInfo.Get(model).Param;
            comboBox.SelectedItem = param;
        }

        // ---------------------------------------------------------------
        // ---------------------------------------------------------------
        // ---------------------------------------------------------------

        private StandardVersion GetStandardVersion(ComboBoxAdv comboBox)
        {
            string param = comboBox.SelectedItem.ToString();
            return StandardVersionInfo.GetByParam(param).StandardVersion;
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

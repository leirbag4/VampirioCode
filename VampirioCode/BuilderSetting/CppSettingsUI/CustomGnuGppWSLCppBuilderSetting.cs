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
using VampirioCode.BuilderSetting.CppSettingsUI;
using VampirioCode.BuilderSetting.UI;
using VampirioCode.Command.GnuGppWSL.Params;
using VampirioCode.Hardcode;
using VampirioCode.Properties;
using VampirioCode.UI;
using VampirioCode.UI.Controls;
using VampirioCode.UI.Controls.VerticalItemListManagement;

namespace VampirioCode.BuilderSetting
{
    public partial class CustomGnuGppWSLCppBuilderSetting : CustomCppBuilderSettingBase
    {
        private CustomGnuCppWSLBuilder builder;

        public CustomGnuGppWSLCppBuilderSetting()
        {
            InitializeComponent();
        }

        public override void Open(string fullFilePath, BuilderType builderType)
        {
            builder = (CustomGnuCppWSLBuilder)CustomBuilders.GetBuilder(fullFilePath, builderType);
            builder.Prepare();
            builder.Load();

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
            
            sourceFilesList.Setup("Choose .cpp and .h files", builder.GetOriginalBaseDirPath(), "C++ and Header files (*.cpp, *.h)|*.cpp;*.h|CPP files (*.cpp)|*.cpp|H files (*.h)|*.h", builder.Setting, builder);

            postCopyDirsList.SetupValuePairBrowsable(new ValuePairBrowseInfo() { BrowseInfo = new DirBrowseInfo() { Title = "Select a Directory" } });
            postCopyFilesList.SetupValuePairBrowsable(new ValuePairBrowseInfo() { LeftBrowseInfo = new FileBrowseInfo("Select Files", true, "DLL files (*.dll)|*.dll|LIB files (*.lib)|*.lib|All Files (*.*)|*.*"), RightBrowseInfo = new DirBrowseInfo() { Title = "Select a Directory" } });

            SetupComboBoxEnums<OutputType, OutputTypeInfo>(outputTypeCBox, "Name");
            SetupComboBoxEnums<StandardVersion, StandardVersionInfo>(standardVersionCBox, "Param");

            /*foreach (StandardVersion std in Enum.GetValues(typeof(StandardVersion)))
            {
                var stdInfo = StandardVersionInfo.Get(std);
                if (stdInfo.Param != "")
                    standardVersionCBox.Items.Add(stdInfo.Param);
            }*/




            OnLoadData();

            HARDCODE_FIXER.CPP_SETTINGS_MSVC(includeDirsList, libraryDirsList, libraryFilesList, sourceFilesList, itemListPackages, macrosList, postCopyDirsList, postCopyFilesList);


            base.OnLoad(e);
        }

        protected void OnLoadData()
        {
            var settings = builder.Setting;

            SetItemListSBrowsable(includeDirsList, settings.IncludeDirs);
            SetItemListSBrowsable(libraryDirsList, settings.LibraryDirs);
            SetItemListSBrowsable(libraryFilesList, settings.LibraryFiles);
            SetItemListValuePair(macrosList, settings.PreprocessorMacros);
            //SetFindPackage(findPackageInput, settings.InstallPackage);
            SetFindPackages(itemListPackages, settings.InstallPackages);
            SetItemListValuePairBrowsable(postCopyDirsList, settings.CopyDirsPost);
            SetItemListValuePairBrowsable(postCopyFilesList, settings.CopyFilesPost);
            SetSourceFiles(sourceFilesList, settings);

            SetComboBoxEnum<OutputType, OutputTypeInfo>(outputTypeCBox, settings.OutputType, "Name");
            SetComboBoxEnum<StandardVersion, StandardVersionInfo>(standardVersionCBox, settings.StandardVersion, "Param");


            //SetStandardVersion(standardVersionCBox, settings.StandardVersion);
        }

        private void OnSaveData()
        {
            var settings = builder.Setting;

            settings.IncludeDirs =          GetItemListSBrowsable(includeDirsList);
            settings.LibraryDirs =          GetItemListSBrowsable(libraryDirsList);
            settings.LibraryFiles =         GetItemListSBrowsable(libraryFilesList);
            settings.PreprocessorMacros =   GetItemListValuePair(macrosList);
            //settings.InstallPackage =     GetFindPackage(findPackageInput);
            settings.InstallPackages =      GetFindPackages(itemListPackages);
            settings.CopyDirsPost =         GetItemListValuePairBrowsable(postCopyDirsList);
            settings.CopyFilesPost =        GetItemListValuePairBrowsable(postCopyFilesList);
            settings.IncludeSourcesMode =   GetIncludeSourceFilesMode(sourceFilesList);
            settings.SourceFiles =          GetSourceFiles(sourceFilesList, settings);

            settings.OutputType =           GetComboBoxEnum<Command.GnuGppWSL.Params.OutputType, OutputTypeInfo>(outputTypeCBox, "GetByName");
            settings.StandardVersion =      GetComboBoxEnum<StandardVersion, StandardVersionInfo>(standardVersionCBox, "GetByParam");
            
            //settings.StandardVersion =      GetStandardVersion(standardVersionCBox);


            builder.Save();
        }

        /*private void SetStandardVersion(ComboBoxAdv comboBox, StandardVersion std)
        {
            string param = StandardVersionInfo.Get(std).Param;
            comboBox.SelectedItem = param;
        }

        // ---------------------------------------------------------------
        // ---------------------------------------------------------------
        // ---------------------------------------------------------------

        private StandardVersion GetStandardVersion(ComboBoxAdv comboBox)
        {
            string param = comboBox.SelectedItem.ToString();
            return StandardVersionInfo.GetByParam(param).StandardVersion;
        }*/

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampDocManager;
using VampirioCode.Builder.Custom;
using VampirioCode.BuilderSetting;
using VampirioCode.UI;

namespace VampirioCode.Builder.Utils
{
    public class BuilderUtils
    {
        private static List<BuilderType> _simpleBuilderTypes;
        private static List<BuilderType> _customBuilderTypes;

        public static void Initialize()
        {
            _simpleBuilderTypes = new List<BuilderType>();
            _customBuilderTypes = new List<BuilderType>();

            foreach (BuilderType btype in Enum.GetValues(typeof(BuilderType)))
            {
                if (GetCategory(btype) == BuilderCategory.Simple)
                    _simpleBuilderTypes.Add(btype);
                else if (GetCategory(btype) == BuilderCategory.Custom)
                    _customBuilderTypes.Add(btype);
            }
        }

        public static void ConvertCustomToSimpleBuild(Document document)
        {
            string projName = Path.GetFileNameWithoutExtension(document.FullFilePath);

            if (document.CustomBuild)
            {
                var result = MsgBox.Show("Build Conversion", "Go back to a Simple Build.\n\nAll project settings will be deleted but code conserved.\nDo you want to continue?", DialogButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    CustomBuilder cbuilder = CustomBuilders.GetBuilder(projName, document.BuilderType);
                    cbuilder.Prepare();
                    string buildSettingFile = cbuilder.GetBuildSettingsFile();

                    try
                    {
                        if (File.Exists(buildSettingFile))
                            File.Delete(buildSettingFile);

                        document.CustomBuild = false;
                        document.BuilderType = BuilderUtils.GetEquivalent(document.BuilderType);
                        CustomBuilders.Remove(projName);
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("Conversion Failed", "Can't convert the 'simple build' to a 'custom build'");
                    }
                }

            }
            else
                MsgBox.Show("Doesn't match", "The document must be a 'Custom Build'", DialogButtons.OK, DialogIcon.Warning);
        }

        public static void ConvertSimpleToCustomBuild(Document document)
        {
            string projName = Path.GetFileNameWithoutExtension(document.FullFilePath);

            if (!document.CustomBuild)
            {
                // Check if for example  'BuilderType.SimpleMsvcCpp' has an equivalent.
                // In this case would be 'BuilderType.CustomMsvcCpp'
                if (!HasEquivalent(document.BuilderType))
                {
                    MsgBox.Show("Builder not equivalent", "There is no equivalent builder for this builder type '" + document.BuilderType + "' of project combination.");
                    return;
                }


                var result = MsgBox.Show("Create custom build", "You have a 'simple document' right now.\n\nDo you want to convert it to a 'Custom Editable Project'?", DialogButtons.YesNoCancel, DialogIcon.Question);
 
                if (result == DialogResult.Yes)
                {
                    BuilderType newBuilderType = BuilderType.None;
 
                    if (document.BuilderType == BuilderType.SimpleMsvcCpp)
                    {
                        newBuilderType = GetEquivalent(document.BuilderType);
 
                        document.CustomBuild = true;
                        //Document document = CreateCustomDocument(DocumentType.CPP, BuilderType.CustomMsvcCpp);
                        document.BuilderType = newBuilderType;//BuilderType.CustomMsvcCpp;
                        var builder = CustomBuilders.Create_CPP_MSVC_BASIC(document, null, null);
 
                        CustomMsvcCppBuilderSetting builderSettings = new CustomMsvcCppBuilderSetting();
                        builderSettings.Open(projName, document.BuilderType);
                    }
                    else
                    {
                        MsgBox.Show("Not available", "Conversion is not available for the current custom build type '" + document.BuilderType + "'");
                    }
                }

                //XConsole.Alert("is: " + CurrDocument.CustomBuild);
                //XConsole.Alert("BuilderType: " + CurrDocument.BuilderType);
                //XConsole.Alert("projName: " + projName);
                //builderSettings.ShowDialog();
            }
            else
                MsgBox.Show("Doesn't match", "The document must be a 'Simple Build'", DialogButtons.OK, DialogIcon.Warning);
        }

        public static BuilderCategory GetCategory(BuilderType builderType)
        {
            int btypeFlag =     (int)builderType;
            int btypeNone =     (int)BuilderCategory.None;
            int btypeSimple =   (int)BuilderCategory.Simple;
            int btypeCustom =   (int)BuilderCategory.Custom;

            if (btypeFlag == btypeNone)
                return BuilderCategory.None;
            else if (btypeFlag < btypeCustom)
                return BuilderCategory.Simple;
            else 
                return BuilderCategory.Custom;
            
        }

        public static bool HasEquivalent(BuilderType builderType)
        {
            return (GetEquivalent(builderType) != BuilderType.None);
        }

        public static BuilderType GetEquivalent(BuilderType currBuilderType)
        {
            BuilderCategory currCategory = GetCategory(currBuilderType);

            if (currCategory == BuilderCategory.None)
            {
                return BuilderType.None;
            }
            else if (currCategory == BuilderCategory.Simple)
            {
                int currSimpleBTypeFlag = (int)currBuilderType;

                foreach (BuilderType customBType in _customBuilderTypes)
                {
                    int customBTypeFlag = (((int)customBType) >> 16);
                    if (customBTypeFlag == currSimpleBTypeFlag)
                        return customBType;
                }
            }
            else if (currCategory == BuilderCategory.Custom)
            {
                int currCustomBTypeFlag = (int)currBuilderType;

                foreach (BuilderType simpleBType in _simpleBuilderTypes)
                {
                    int simpleBTypeFlag = (((int)simpleBType) << 16);
                    if (simpleBTypeFlag == currCustomBTypeFlag)
                        return simpleBType;
                }
            }
            
            return BuilderType.None;

            /*// One Way
            if (builderType == BuilderType.SimpleMsvcCpp)
                return BuilderType.CustomMsvcCpp;

            // Revert Way
            else if (builderType == BuilderType.CustomMsvcCpp)
                return BuilderType.SimpleMsvcCpp;

            // No equivalent compatible builder
            else
                return BuilderType.None;*/
        }
    }
}

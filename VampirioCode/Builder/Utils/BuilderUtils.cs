using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampDocManager;
using VampirioCode.Builder.Custom;
using VampirioCode.BuilderSetting;
using VampirioCode.UI;
using VampirioCode.Workspace;

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

        public static void DeleteProject(VampDocManager.Document currDocument)
        {
            if (currDocument.BuilderType == BuilderType.None)
                return;

            if (currDocument.CustomBuild)
            {
                /*CustomBuilder customBuilder = CustomBuilders.GetBuilder(currDocument.FullFilePath, currDocument.BuilderType);
                customBuilder.Prepare();
                customBuilder.DeleteBuild();*/
            }
            else
            {
                Builder builder = Builders.GetBuilder(currDocument.BuilderType);
                builder.Setup(currDocument.FullFilePath, "");
                builder.Prepare();
                builder.DeleteBuild();
            }
        }

        public static void ConvertCustomToSimpleBuild(Document document)
        {
            //string projName = Path.GetFileNameWithoutExtension(document.FullFilePath);

            if (document.CustomBuild)
            {
                var result = MsgBox.Show("Build Conversion", "Go back to a Simple Build.\n\nAll project settings will be deleted but code conserved.\nDo you want to continue?\n\n\n[ " + document.BuilderType + " -> " + BuilderUtils.GetEquivalent(document.BuilderType) + " ]", DialogButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    CustomBuilder cbuilder = CustomBuilders.GetBuilder(document.FullFilePath, document.BuilderType);
                    cbuilder.Prepare();
                    string buildSettingFile = cbuilder.GetBuildSettingsFile();

                    try
                    {
                        if (File.Exists(buildSettingFile))
                            File.Delete(buildSettingFile);

                        document.CustomBuild = false;
                        document.BuilderType = BuilderUtils.GetEquivalent(document.BuilderType);
                        CustomBuilders.Remove(document.FullFilePath);
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
            //string projName = Path.GetFileNameWithoutExtension(document.FullFilePath);

            if (!document.CustomBuild)
            {
                // Check if for example  'BuilderType.SimpleMsvcCpp' has an equivalent.
                // In this case would be 'BuilderType.CustomMsvcCpp'
                if (!HasEquivalent(document.BuilderType))
                {
                    MsgBox.Show("Builder not equivalent", "There is no equivalent builder for this builder type '" + document.BuilderType + "' of project combination.");
                    return;
                }


                var result = MsgBox.Show("Create custom build", "You have a 'simple document' right now.\n\nDo you want to convert it to a 'Custom Editable Project'?\n\n\n[ " + document.BuilderType + " -> " + BuilderUtils.GetEquivalent(document.BuilderType) + " ]", DialogButtons.YesNoCancel, DialogIcon.Question);
 
                if (result == DialogResult.Yes)
                {
                    BuilderType newBuilderType = BuilderType.None;

                    if (HasEquivalent(document.BuilderType) && (GetCategory(document.BuilderType) == BuilderCategory.Simple))
                    {
                        newBuilderType = GetEquivalent(document.BuilderType);
                        document.CustomBuild = true;
                        document.BuilderType = newBuilderType;

                        if (newBuilderType == BuilderType.CustomMsvcCpp)
                        {
                            /*if (document.IsTemporary)
                            {
                                XConsole.Alert("enter: " + document.FullFilePath);
                                document.Move(AppInfo.TemporaryCustomFilesPath + "projReloco");
                                XConsole.Alert("enter2: " + document.FullFilePath);
                            }
                            else
                                XConsole.Alert("no enter");*/
                            
                            var builder = CustomBuilders.Create_CPP_MSVC_BASIC(document, null, null);
                            CustomMsvcCppBuilderSetting builderSettings = new CustomMsvcCppBuilderSetting();
                            builderSettings.Open(document.FullFilePath, document.BuilderType);
                        }
                        else if (newBuilderType == BuilderType.CustomGnuGppWSLCpp)
                        {
                            var builder = CustomBuilders.Create_CPP_GNU_GPP_WSL_BASIC(document, null, null);
                            CustomGnuGppWSLCppBuilderSetting builderSettings = new CustomGnuGppWSLCppBuilderSetting();
                            builderSettings.Open(document.FullFilePath, document.BuilderType);
                        }
                        else
                        { 
                            MsgBox.Show("Not found", "Can't convert the current custom build type '" + document.BuilderType + "'\n\nNew supposed build type '" + newBuilderType + "'");
                        }
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

        public static bool CanCompile(DocumentType docType)
        {
            switch (docType)
            {
                case DocumentType.HTML:
                case DocumentType.OTHER:
                case DocumentType.H:
                case DocumentType.INC:
                    return false;
                default:
                    return true;
            }
        }

        // return empty "" if didn't have or "_vamp" with the full path
        // e.g: "c:\projects\01\_vamp\"
        public static string GetTempDirPath(string anyFileFullPath)
        {
            // Get the directory from the full file path (excluding the file name)
            string directory = Path.GetDirectoryName(anyFileFullPath);

            // Iterate through directories going up until "_vamp" is found or we reach the root
            while (!string.IsNullOrEmpty(directory))
            {
                // Combine the current directory path with "_vamp"
                string vampDirectory = Path.Combine(directory, "_vamp");

                // Check if the "_vamp" directory exists
                if (Directory.Exists(vampDirectory))
                {
                    return vampDirectory; // Return the path if "_vamp" is found
                }

                // Move one level up in the directory tree
                directory = Directory.GetParent(directory)?.FullName;
            }

            // If "_vamp" is not found, return an empty string
            return "";
        }

        public static string GetWorkspaceFullFilePath(string filePath)
        {
            // e.g: "c:\projects\01\_vamp\"
            string tempPath = GetTempDirPath(filePath);

            if (tempPath != "")
            {
                string workspaceFilePath = tempPath + "\\.workspace";

                
                if (File.Exists(workspaceFilePath))
                    return workspaceFilePath;
                else
                    return "";
            }
            else
                return "";
        }

        public static WorkspaceInfo GetWorkspaceInfo(string filePath)
        {

            // e.g: "c:\projects\01\_vamp\"
            string tempPath = GetTempDirPath(filePath);

            if (tempPath != "")
            {
                // c:\projects\01\_vamp\.workspace
                string workspaceFilePath = tempPath + "\\" + AppInfo.WorkspaceFileName;

                // c:\projects\01\_vamp\.workspace],            [c:\projects\01\]
                if (File.Exists(workspaceFilePath))
                    return new WorkspaceInfo(filePath, workspaceFilePath, new DirectoryInfo(tempPath).Parent.FullName);
                else
                    return null;
            }
            else
                return null;
        }

        public static DocumentSettings GetDocSettings(string fullFilePath)
        {
            DocumentSettings settings = new DocumentSettings();
            WorkspaceInfo workspaceInfo = GetWorkspaceInfo(fullFilePath);

            if (workspaceInfo != null)
            {
                WorkspaceBase workspace =           workspaceInfo.GetWorkspaceBase();
                //WorkspaceProject workspaceProject = workspace.DEfa//workspace.GetFirstOrDefaultWorkspaceProject();

                settings.DocType =      Document.GetDocType(fullFilePath);
                settings.Custom =       true;
                settings.BuilderType =  workspace.DefaultBuilderType;//workspaceProject.BuilderType;

                //return settings;
            }
            else
            {
                //return null;

                settings.DocType=       Document.GetDocType(fullFilePath);
                settings.Custom =       false;
                settings.BuilderType =  Builders.GetDefaultTypeFor(settings.DocType);
            }

            return settings;
        }

        public static string GetProjName(string fullFilePath)
        {
            return Path.GetFileNameWithoutExtension(fullFilePath);
        }

        public static string GetProjName(VampDocManager.Document document)
        {
            return GetProjName(document.FullFilePath);
        }

        public static string GetFileNameOnly(string fullFilePath)
        {
            return Path.GetFileName(fullFilePath);
        }
    }
}

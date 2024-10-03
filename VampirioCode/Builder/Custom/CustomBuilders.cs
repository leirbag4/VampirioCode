using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampDocManager;
using VampirioCode.BuilderSetting.Actions;
using VampirioCode.UI;
using VampEditor;
using VampirioCode.BuilderSetting.CppSettings.Settings;

namespace VampirioCode.Builder.Custom
{
    public class CustomBuilders
    {

        private static Dictionary<string, CustomBuilder> builders;

        public static void Initialize()
        {
            builders = new Dictionary<string, CustomBuilder>();
        }

        public static void Remove(string projectName)
        {
            if (builders.ContainsKey(projectName))
                builders.Remove(projectName);
        }

        public static CustomBuilder GetBuilder(string projectName, BuilderType builderType)
        {
            if(builders.ContainsKey(projectName))
                return builders[projectName];


            if (builderType == BuilderType.CustomMsvcCpp)
            { 
                CustomMsvcCppBuilder builder = new CustomMsvcCppBuilder();
                builder.Setup(projectName, "");

                if (builder.Exists())
                {
                    builders.Add(projectName, builder);
                    //XConsole.Alert("exist");
                    builder.Load();
                    return builder;
                    //builders.Add(projectName, builder.Load());
                }
                else
                {
                    XConsole.Alert("Doesn't exist!!!");

                }
            }


            //XConsole.Alert("path: " + projectName + " builderType: " + builderType);
            return null;
        }

        public static CustomMsvcCppBuilder Create_CPP_MSVC_SDL2(Document document, VampirioEditor editor, BuilderTemplateInfo builderTemplateInfo)
        {
            string projName = Path.GetFileNameWithoutExtension(document.FullFilePath);
            CustomMsvcCppBuilder builder = new CustomMsvcCppBuilder();
            builder.Setup(projName, document.Text);
            
            
            MsvcCppBSetting setting = builder.Setting;
            //setting.AddCopyDirPre("magia\\veneno", "tester\\capitan");
            //setting.AddCopyDirPre("code", "info\\code");

            // Includes
            setting.IncludeDirAdd("C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\VC\\Tools\\MSVC\\14.39.33519\\include");
            setting.IncludeDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Include\\10.0.22621.0\\ucrt");
            setting.IncludeDirAdd("${projDir}\\include");

            // Library Directories
            setting.LibraryDirAdd("C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\VC\\Tools\\MSVC\\14.39.33519\\lib\\x64");
            setting.LibraryDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\10.0.22621.0\\um\\x64");
            setting.LibraryDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\10.0.22621.0\\ucrt\\x64");
            setting.LibraryDirAdd("${projDir}\\lib\\x64");

            // Library Files
            setting.LibraryFileAdd("libcpmt.lib");
            setting.LibraryFileAdd("kernel32.lib");
            setting.LibraryFileAdd("libucrt.lib");
            setting.LibraryFileAdd("SDL2main.lib");
            setting.LibraryFileAdd("SDL2.lib");

            setting.PreprocessorMacroAdd("SDL_main", "main");

            setting.CopyFilePostAdd("${projDir}\\SDL2.dll", "${projDir}\\bin", true);

            setting.StandardVersion = Command.MSVC.Params.StandardVersion.StdCpp17;
            setting.ExceptionHanldingModel = Command.MSVC.Params.ExceptionHandlingModel.EHsc;

            setting.InstallPackage = "sdl2_msvc";


            // Save build settings
            builder.Save();

            // Update to the list
            //Get(projName, document.BuilderType);

            //XConsole.Alert("proj: " + projName + "  btype: " + document.BuilderType);

            UpdateCode(editor, builderTemplateInfo);

            return builder;
        }

        public static CustomMsvcCppBuilder Create_CPP_MSVC_BASIC(Document document, VampirioEditor editor, BuilderTemplateInfo builderTemplateInfo)
        {
            string projName = Path.GetFileNameWithoutExtension(document.FullFilePath);
            CustomMsvcCppBuilder builder = new CustomMsvcCppBuilder();
            builder.Setup(projName, document.Text);
            
            
            MsvcCppBSetting setting = builder.Setting;
            //setting.AddCopyDirPre("magia\\veneno", "tester\\capitan");
            //setting.AddCopyDirPre("code", "info\\code");

            // Includes
            setting.IncludeDirAdd("C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\VC\\Tools\\MSVC\\14.39.33519\\include");
            setting.IncludeDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Include\\10.0.22621.0\\ucrt");

            // Library Directories
            setting.LibraryDirAdd("C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\VC\\Tools\\MSVC\\14.39.33519\\lib\\x64");
            setting.LibraryDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\10.0.22621.0\\um\\x64");
            setting.LibraryDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\10.0.22621.0\\ucrt\\x64");

            // Library Files
            setting.LibraryFileAdd("libcpmt.lib");
            setting.LibraryFileAdd("kernel32.lib");
            setting.LibraryFileAdd("libucrt.lib");

            setting.StandardVersion = Command.MSVC.Params.StandardVersion.StdCpp17;
            setting.ExceptionHanldingModel = Command.MSVC.Params.ExceptionHandlingModel.EHsc;

            // Save build settings
            builder.Save();

            // Update to the list
            //Get(projName, document.BuilderType);

            //XConsole.Alert("proj: " + projName + "  btype: " + document.BuilderType);
            UpdateCode(editor, builderTemplateInfo);

            return builder;
        }

        private static void UpdateCode(VampirioEditor editor, BuilderTemplateInfo builderTemplateInfo)
        {
            if (editor != null)
                editor.Text = builderTemplateInfo.Code;
        }

    }
}

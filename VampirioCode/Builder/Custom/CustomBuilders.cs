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
using VampirioCode.SaveData;

namespace VampirioCode.Builder.Custom
{
    public class CustomBuilders
    {

        private static Dictionary<string, CustomBuilder> builders;

        private static readonly Dictionary<BuilderType, Func<CustomBuilder>> builderRegistry = new Dictionary<BuilderType, Func<CustomBuilder>>()
        {
            { BuilderType.CustomMsvcCpp,        () => new CustomMsvcCppBuilder() },
            { BuilderType.CustomGnuGppWSLCpp,   () => new CustomGnuCppWSLBuilder() },
            { BuilderType.CustomClangCpp,       () => new CustomClangBuilder() },
            { BuilderType.CustomEmscriptenCpp,  () => new CustomEmscriptenBuilder() }
        };

        public static void Initialize()
        {
            builders = new Dictionary<string, CustomBuilder>();
        }

        public static void Remove(string fullProjFilePath)
        {
            if (builders.ContainsKey(fullProjFilePath))
                builders.Remove(fullProjFilePath);
        }

        public static CustomBuilder GetBuilder(string fullProjFilePath, BuilderType builderType)
        {
            string builderKey = fullProjFilePath + builderType.ToString();

            if (builders.ContainsKey(builderKey))
                return builders[builderKey];

            // Check if builder is registered
            if (builderRegistry.TryGetValue(builderType, out var builderFactory))
            {
                CustomBuilder builder = builderFactory.Invoke();
                builder.Setup(fullProjFilePath, "");

                if (builder.Exists())
                {
                    builders.Add(builderKey, builder);
                    builder.Load();
                    return builder;
                }
                else
                    return null; // don't delete this line
            }

            return null; // don't delete this line
        }

        /*public static CustomBuilder GetBuilder(string fullProjFilePath, BuilderType builderType)
        {
            string builderKey = fullProjFilePath + builderType.ToString();

            if(builders.ContainsKey(builderKey))
                return builders[builderKey];

            if (builderType == BuilderType.CustomMsvcCpp)
            { 
                CustomMsvcCppBuilder builder = new CustomMsvcCppBuilder();
                builder.Setup(fullProjFilePath, "");

                if (builder.Exists())
                {
                    builders.Add(builderKey, builder);
                    builder.Load();
                    return builder;
                }
                else
                {
                    return null;
                    //throw new Exception("Custom builder doesn't exist!");
                }
            }
            else if (builderType == BuilderType.CustomGnuGppWSLCpp)
            {
                CustomGnuCppWSLBuilder builder = new CustomGnuCppWSLBuilder();
                builder.Setup(fullProjFilePath, "");

                if (builder.Exists())
                {
                    builders.Add(builderKey, builder);
                    builder.Load();
                    return builder;
                }
                else
                {
                    return null;
                    //throw new Exception("Custom builder doesn't exist!");
                }
            }


            //XConsole.Alert("path: " + projectName + " builderType: " + builderType);
            return null;
        }*/

        public static CustomMsvcCppBuilder Create_CPP_MSVC_BASIC(Document document, VampirioEditor editor, BuilderTemplateInfo builderTemplateInfo)
        {
            //string projName = Path.GetFileNameWithoutExtension(document.FullFilePath);
            CustomMsvcCppBuilder builder = new CustomMsvcCppBuilder();
            builder.Setup(document.FullFilePath, document.Text);
            
            
            MsvcCppBSetting setting = builder.Setting;
            //setting.AddCopyDirPre("magia\\veneno", "tester\\capitan");
            //setting.AddCopyDirPre("code", "info\\code");

            // Includes
            /*setting.IncludeDirAdd("C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\VC\\Tools\\MSVC\\14.39.33519\\include");
            setting.IncludeDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Include\\10.0.22621.0\\ucrt");

            // Library Directories
            setting.LibraryDirAdd("C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\VC\\Tools\\MSVC\\14.39.33519\\lib\\x64");
            setting.LibraryDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\10.0.22621.0\\um\\x64");
            setting.LibraryDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\10.0.22621.0\\ucrt\\x64");
            */

            // Includes
            setting.IncludeDirAdd("${stlInclude}");    //setting.IncludeDirAdd(Config.BuildersSettings.Msvc.stl_include);
            setting.IncludeDirAdd("${ucrtInclude}");   //setting.IncludeDirAdd(Config.BuildersSettings.Msvc.ucrt_include);

            // Library Directories
            setting.LibraryDirAdd("${stlLibDir}");    // setting.LibraryDirAdd(Config.BuildersSettings.Msvc.stl_lib_dir);
            setting.LibraryDirAdd("${umLibDir}");     // setting.LibraryDirAdd(Config.BuildersSettings.Msvc.um_lib_dir);
            setting.LibraryDirAdd("${ucrtLibDir}");   // setting.LibraryDirAdd(Config.BuildersSettings.Msvc.ucrt_lib_dir);


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
            if((builderTemplateInfo != null) && !builderTemplateInfo.DontUpdateCode)
                UpdateCode(editor, builderTemplateInfo);

            return builder;
        }

        public static CustomMsvcCppBuilder Create_CPP_MSVC_SDL2(Document document, VampirioEditor editor, BuilderTemplateInfo builderTemplateInfo)
        {
            //string projName = Path.GetFileNameWithoutExtension(document.FullFilePath);
            CustomMsvcCppBuilder builder = new CustomMsvcCppBuilder();
            builder.Setup(document.FullFilePath, document.Text);
            
            
            MsvcCppBSetting setting = builder.Setting;
            //setting.AddCopyDirPre("magia\\veneno", "tester\\capitan");
            //setting.AddCopyDirPre("code", "info\\code");

            /*
            setting.IncludeDirAdd("C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\VC\\Tools\\MSVC\\14.39.33519\\include");
            setting.IncludeDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Include\\10.0.22621.0\\ucrt");
            setting.IncludeDirAdd("${projDir}\\include");

            // Library Directories
            setting.LibraryDirAdd("C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\VC\\Tools\\MSVC\\14.39.33519\\lib\\x64");
            setting.LibraryDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\10.0.22621.0\\um\\x64");
            setting.LibraryDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\10.0.22621.0\\ucrt\\x64");
            setting.LibraryDirAdd("${projDir}\\lib\\x64");
             */

            // Includes
            setting.IncludeDirAdd("${stlInclude}");    //setting.IncludeDirAdd(Config.BuildersSettings.Msvc.stl_include);
            setting.IncludeDirAdd("${ucrtInclude}");   //setting.IncludeDirAdd(Config.BuildersSettings.Msvc.ucrt_include);
            setting.IncludeDirAdd("${projDir}\\include");

            // Library Directories
            setting.LibraryDirAdd("${stlLibDir}");    // setting.LibraryDirAdd(Config.BuildersSettings.Msvc.stl_lib_dir);
            setting.LibraryDirAdd("${umLibDir}");     // setting.LibraryDirAdd(Config.BuildersSettings.Msvc.um_lib_dir);
            setting.LibraryDirAdd("${ucrtLibDir}");   // setting.LibraryDirAdd(Config.BuildersSettings.Msvc.ucrt_lib_dir);
            setting.LibraryDirAdd("${projDir}\\lib\\x64");
            setting.LibraryDirAdd("${projDir}\\lib");
            setting.LibraryDirAdd("${projDir}\\lib\\lib-x64");

            // Library Files
            setting.LibraryFileAdd("libcpmt.lib");
            setting.LibraryFileAdd("kernel32.lib");
            setting.LibraryFileAdd("libucrt.lib");
            setting.LibraryFileAdd("SDL2main.lib");
            setting.LibraryFileAdd("SDL2.lib");
            setting.LibraryFileAdd("SDL2_image.lib");
            setting.LibraryFileAdd("SDL2_ttf.lib");

            setting.PreprocessorMacroAdd("SDL_main", "main");

            setting.CopyFilePostAdd("${projDir}\\SDL2.dll", "${projDir}\\bin", true);
            setting.CopyFilePostAdd("${projDir}\\SDL2_image.dll", "${projDir}\\bin", true);
            setting.CopyFilePostAdd("${projDir}\\SDL2_ttf.dll", "${projDir}\\bin", true);

            setting.StandardVersion = Command.MSVC.Params.StandardVersion.StdCpp17;
            setting.ExceptionHanldingModel = Command.MSVC.Params.ExceptionHandlingModel.EHsc;

            setting.InstallPackage = "sdl2_msvc";
            setting.InstallPackages.Add("sdl2_msvc");


            // Save build settings
            builder.Save();

            // Update to the list
            //Get(projName, document.BuilderType);

            //XConsole.Alert("proj: " + projName + "  btype: " + document.BuilderType);
            if ((builderTemplateInfo != null) && !builderTemplateInfo.DontUpdateCode)
                UpdateCode(editor, builderTemplateInfo);

            return builder;
        }

        public static CustomMsvcCppBuilder Create_CPP_MSVC_VAMP_ENGINE(Document document, VampirioEditor editor, BuilderTemplateInfo builderTemplateInfo)
        {
            //string projName = Path.GetFileNameWithoutExtension(document.FullFilePath);
            CustomMsvcCppBuilder builder = new CustomMsvcCppBuilder();
            builder.Setup(document.FullFilePath, document.Text);


            MsvcCppBSetting setting = builder.Setting;
            //setting.AddCopyDirPre("magia\\veneno", "tester\\capitan");
            //setting.AddCopyDirPre("code", "info\\code");

            /*
            setting.IncludeDirAdd("C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\VC\\Tools\\MSVC\\14.39.33519\\include");
            setting.IncludeDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Include\\10.0.22621.0\\ucrt");
            setting.IncludeDirAdd("${projDir}\\include");

            // Library Directories
            setting.LibraryDirAdd("C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\VC\\Tools\\MSVC\\14.39.33519\\lib\\x64");
            setting.LibraryDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\10.0.22621.0\\um\\x64");
            setting.LibraryDirAdd("C:\\Program Files (x86)\\Windows Kits\\10\\Lib\\10.0.22621.0\\ucrt\\x64");
            setting.LibraryDirAdd("${projDir}\\lib\\x64");
             */

            // Includes
            setting.IncludeDirAdd("${stlInclude}");    //setting.IncludeDirAdd(Config.BuildersSettings.Msvc.stl_include);
            setting.IncludeDirAdd("${ucrtInclude}");   //setting.IncludeDirAdd(Config.BuildersSettings.Msvc.ucrt_include);
            setting.IncludeDirAdd("${projDir}\\include");

            // Library Directories
            setting.LibraryDirAdd("${stlLibDir}");    // setting.LibraryDirAdd(Config.BuildersSettings.Msvc.stl_lib_dir);
            setting.LibraryDirAdd("${umLibDir}");     // setting.LibraryDirAdd(Config.BuildersSettings.Msvc.um_lib_dir);
            setting.LibraryDirAdd("${ucrtLibDir}");   // setting.LibraryDirAdd(Config.BuildersSettings.Msvc.ucrt_lib_dir);

            setting.LibraryDirAdd("${projDir}\\lib\\x64");
            setting.LibraryDirAdd("${projDir}\\lib");
            setting.LibraryDirAdd("${projDir}\\lib\\lib-x64");


            // Library Files
            setting.LibraryFileAdd("libcpmt.lib");
            setting.LibraryFileAdd("kernel32.lib");
            setting.LibraryFileAdd("libucrt.lib");
            setting.LibraryFileAdd("SDL2main.lib");
            setting.LibraryFileAdd("SDL2.lib");
            setting.LibraryFileAdd("SDL2_image.lib");
            setting.LibraryFileAdd("SDL2_ttf.lib");
            setting.LibraryFileAdd("VampEngine.lib");

            setting.PreprocessorMacroAdd("SDL_main", "main");

            setting.CopyFilePostAdd("${projDir}\\SDL2.dll", "${projDir}\\bin", true);
            setting.CopyFilePostAdd("${projDir}\\SDL2_image.dll", "${projDir}\\bin", true);
            setting.CopyFilePostAdd("${projDir}\\SDL2_ttf.dll", "${projDir}\\bin", true);

            setting.StandardVersion = Command.MSVC.Params.StandardVersion.StdCpp17;
            setting.ExceptionHanldingModel = Command.MSVC.Params.ExceptionHandlingModel.EHsc;

            setting.InstallPackage = "sdl2_msvc";
            setting.InstallPackages.Add("sdl2_msvc");
            setting.InstallPackages.Add("vampirio_engine_msvc");


            // Save build settings
            builder.Save();

            // Update to the list
            //Get(projName, document.BuilderType);

            //XConsole.Alert("proj: " + projName + "  btype: " + document.BuilderType);
            if ((builderTemplateInfo != null) && !builderTemplateInfo.DontUpdateCode)
                UpdateCode(editor, builderTemplateInfo);

            return builder;
        }

        public static CustomGnuCppWSLBuilder Create_CPP_GNU_GPP_WSL_BASIC(Document document, VampirioEditor editor, BuilderTemplateInfo builderTemplateInfo)
        {
            //string projName = Path.GetFileNameWithoutExtension(document.FullFilePath);
            CustomGnuCppWSLBuilder builder = new CustomGnuCppWSLBuilder();
            builder.Setup(document.FullFilePath, document.Text);
            
            
            GnuCppBSetting setting = builder.Setting;
            //setting.AddCopyDirPre("magia\\veneno", "tester\\capitan");
            //setting.AddCopyDirPre("code", "info\\code");

            /*// Includes
            setting.IncludeDirAdd("C:\\tests\\ultra_test\\include");
            setting.IncludeDirAdd("C:\\tests\\ultra_test\\other_include");

            // Library Directories
            setting.LibraryDirAdd("C:\\tests\\ultra_test\\lib1");
            setting.LibraryDirAdd("C:\\tests\\ultra_test\\lib2");

            // Library Files
            setting.LibraryFileAdd("libcpmt");
            setting.LibraryFileAdd("kernel32");
            setting.LibraryFileAdd("libucrt");
            */
            setting.StandardVersion = Command.GnuGppWSL.Params.StandardVersion.StdCpp17;

            // Save build settings
            builder.Save();

            // Update to the list
            //Get(projName, document.BuilderType);

            //XConsole.Alert("proj: " + projName + "  btype: " + document.BuilderType);
            if ((builderTemplateInfo != null) && !builderTemplateInfo.DontUpdateCode)
                UpdateCode(editor, builderTemplateInfo);

            return builder;
        }

        public static CustomGnuCppWSLBuilder Create_CPP_GNU_GPP_WSL_SDL2(Document document, VampirioEditor editor, BuilderTemplateInfo builderTemplateInfo)
        {
            //string projName = Path.GetFileNameWithoutExtension(document.FullFilePath);
            CustomGnuCppWSLBuilder builder = new CustomGnuCppWSLBuilder();
            builder.Setup(document.FullFilePath, document.Text);


            GnuCppBSetting setting = builder.Setting;
            //setting.AddCopyDirPre("magia\\veneno", "tester\\capitan");
            //setting.AddCopyDirPre("code", "info\\code");

            /*// Includes
            setting.IncludeDirAdd("C:\\tests\\ultra_test\\include");
            setting.IncludeDirAdd("C:\\tests\\ultra_test\\other_include");

            // Library Directories
            setting.LibraryDirAdd("C:\\tests\\ultra_test\\lib1");
            setting.LibraryDirAdd("C:\\tests\\ultra_test\\lib2");

            // Library Files
            setting.LibraryFileAdd("libcpmt");
            setting.LibraryFileAdd("kernel32");*/
            setting.LibraryFileAdd("SDL2");
            

            setting.StandardVersion = Command.GnuGppWSL.Params.StandardVersion.StdCpp17;

            // Save build settings
            builder.Save();

            // Update to the list
            //Get(projName, document.BuilderType);

            //XConsole.Alert("proj: " + projName + "  btype: " + document.BuilderType);
            if ((builderTemplateInfo != null) && !builderTemplateInfo.DontUpdateCode)
                UpdateCode(editor, builderTemplateInfo);

            return builder;
        }

        public static CustomClangBuilder Create_CPP_CLANG_BASIC(Document document, VampirioEditor editor, BuilderTemplateInfo builderTemplateInfo)
        {
            CustomClangBuilder builder = new CustomClangBuilder();
            builder.Setup(document.FullFilePath, document.Text);

            CLangBSetting setting = builder.Setting;
            setting.StandardVersion = Command.Clang.Params.StandardVersion.StdCpp17;

            // Save build settings
            builder.Save();

            if ((builderTemplateInfo != null) && !builderTemplateInfo.DontUpdateCode)
                UpdateCode(editor, builderTemplateInfo);

            return builder;
        }

        public static CustomEmscriptenBuilder Create_CPP_EMSCRIPTEN_BASIC(Document document, VampirioEditor editor, BuilderTemplateInfo builderTemplateInfo)
        {
            CustomEmscriptenBuilder builder = new CustomEmscriptenBuilder();
            builder.Setup(document.FullFilePath, document.Text);

            EmscriptenBSetting setting = builder.Setting;
            setting.StandardVersion = Command.Emscripten.Emcc.Params.StandardVersion.StdCpp17;

            // Save build settings
            builder.Save();

            if ((builderTemplateInfo != null) && !builderTemplateInfo.DontUpdateCode)
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

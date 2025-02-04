using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Builder.Utils;
using VampirioCode.BuilderSetting;
using VampirioCode.Command.Dotnet.Models;
using VampirioCode.UI;

namespace VampirioCode.Builder
{
    public class BuilderTemplateInfo
    {
        public BuilderTemplate Template { get; set; }
        public BuilderType BuilderType { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Tag { get; set; }
        public Type BuilderSettingUI { get; set; }
        public string Code { get { return CodeDB.GetCode(this.Template); } }
        public bool DontUpdateCode { get; set; } = false;

        //public CustomBuilderSettingBase BuilderSetting { get; set; }
        //public CustomBuilderSettingBase BuilderSetting { get { return new CustomMsvcCppBuilderSetting();/*GetBuilderSetting(this.BuilderType);*/ } }
        public CustomBuilderSettingBase BuilderSetting { get { return (CustomBuilderSettingBase)Activator.CreateInstance(BuilderSettingUI); } }

        private static List<BuilderTemplateInfo> _templatesArray = new List<BuilderTemplateInfo>();
        
        private static Dictionary<string, BuilderTemplateInfo>          _tags =         new Dictionary<string, BuilderTemplateInfo>();
        private static Dictionary<BuilderTemplate, BuilderTemplateInfo> _templates =    new Dictionary<BuilderTemplate, BuilderTemplateInfo>();
        //private static Dictionary<BuilderType, BuilderTemplateInfo>     _types =        new Dictionary<BuilderType, BuilderTemplateInfo>();
        //private static Dictionary<BuilderType, CustomBuilderSettingBase>_settings =     new Dictionary<BuilderType, CustomBuilderSettingBase>();
        

        private static bool _init = false;

        private static CustomBuilderSettingBase GetBuilderSetting(BuilderType type)
        {
            if (type == BuilderType.CustomMsvcCpp)
                return new CustomMsvcCppBuilderSetting();

            return null;
        }

        public static void Initialize()
        {
            if (_init) return;

            // IMPORTANT:
            // IMPORTANT: Always put 'Basic' over others like 'SDL' when 'BuilderType' is the same
            // IMPORTANT: Otherway, GetFromType won't work correctly!
            // IMPORTANT:
            // IMPORTANT: Correct Order:
            // IMPORTANT:       _Create(BuilderTemplate.CppMsvcBasic,   BuilderType.CustomMsvcCpp,
            // IMPORTANT:       _Create(BuilderTemplate.CppMsvcSDL2,    BuilderType.CustomMsvcCpp,

            // MSVC
            _Create(BuilderTemplate.CppMsvcBasic,               BuilderType.CustomMsvcCpp,  "Cpp Msvc Basic",   "C++ Basic Main",   "cpp_msvc_basic",   typeof(CustomMsvcCppBuilderSetting));
            _Create(BuilderTemplate.CppMsvcSDL2,                BuilderType.CustomMsvcCpp,  "Cpp Msvc SDL2",    "C++ SDL2",         "cpp_msvc_sdl2",    typeof(CustomMsvcCppBuilderSetting));
            _Create(BuilderTemplate.CppMsvcVampEngine,          BuilderType.CustomMsvcCpp,  "Cpp Msvc Vamp Engine",    "C++ Vamp Engine",         "cpp_msvc_vamp_engine",           typeof(CustomMsvcCppBuilderSetting));
            _Create(BuilderTemplate.CppMsvcVampEngineComplex,   BuilderType.CustomMsvcCpp,  "Cpp Msvc Vamp Engine",    "C++ Vamp Engine",         "cpp_msvc_vamp_engine_complex",   typeof(CustomMsvcCppBuilderSetting));
            
            // GNU g++ WSL
            _Create(BuilderTemplate.CppGnuGppWSLBasic,  BuilderType.CustomGnuGppWSLCpp, "Cpp Gnu g++ WSL Basic", "C++ Basic Main",  "cpp_gnu_gpp_wsl_basic",    typeof(CustomGnuGppWSLCppBuilderSetting));
            _Create(BuilderTemplate.CppGnuGppSDL2,      BuilderType.CustomGnuGppWSLCpp, "Cpp Gnu g++ WSL SDL2",  "C++ SDL2",        "cpp_gnu_gpp_wsl_sdl2",     typeof(CustomGnuGppWSLCppBuilderSetting));

            // Clang
            _Create(BuilderTemplate.CppClangBasic,      BuilderType.CustomClangCpp, "Cpp CLang Basic", "C++ Basic Main",  "cpp_clang_basic",    typeof(CustomClangCppBuilderSetting));
            
            // Emscripten
            _Create(BuilderTemplate.CppEmscriptenBasic, BuilderType.CustomEmscriptenCpp, "Cpp Emscripten Basic", "C++ Basic Main",  "cpp_emscripten_basic",    typeof(CustomEmscriptenCppBuilderSetting));


            _init = true;
        }

        private static BuilderTemplateInfo _Create(BuilderTemplate template, BuilderType type, string name, string info, string tag, Type builderSettingUI)
        {
            BuilderTemplateInfo binfo = new BuilderTemplateInfo();
            binfo.Template =        template;
            binfo.BuilderType =     type;
            binfo.Name =            name;
            binfo.Info =            info;
            binfo.Tag =             tag;
            binfo.BuilderSettingUI= builderSettingUI;

            if (!_tags.ContainsKey(tag))            _tags.Add(tag, binfo);
            if (!_templates.ContainsKey(template))  _templates.Add(template, binfo);

            _templatesArray.Add(binfo);

            return binfo;
        }

        public static BuilderTemplateInfo Get(BuilderTemplate template)
        {
            Initialize();

            if (_templates.ContainsKey(template))
                return _templates[template];
            else
                return null;
        }

        public static BuilderTemplateInfo GetFromType(BuilderType type)
        {
            Initialize();

            foreach (var btempInfo in _templatesArray)
            {
                if(btempInfo.BuilderType == type)
                    return btempInfo;
            }

            return null;
        }

        public static BuilderTemplateInfo GetFromTag(string tag)
        {
            Initialize();

            if (_tags.ContainsKey(tag))
                return _tags[tag];
            else
                return null;
        }

        public override string ToString()
        {
            return $"Template: {Template}, BuilderType: {BuilderType}, Name: {Name}, Info: {Info}, Tag: {Tag}";
        }

    }
}

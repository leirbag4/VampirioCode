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
        public string Code { get { return CodeDB.GetCode(this.Template); } }
        //public CustomBuilderSettingBase BuilderSetting { get; set; }
        public CustomBuilderSettingBase BuilderSetting { get { return new CustomMsvcCppBuilderSetting();/*GetBuilderSetting(this.BuilderType);*/ } }

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

            _Create(BuilderTemplate.CppMsvcBasic,   BuilderType.CustomMsvcCpp,  "Cpp Msvc Basic",   "C++ Basic Main",   "cpp_msvc_basic");
            _Create(BuilderTemplate.CppMsvcSDL2,    BuilderType.CustomMsvcCpp,  "Cpp Msvc SDL2",    "C++ SDL2",         "cpp_msvc_sdl2");

            _init = true;
        }

        private static BuilderTemplateInfo _Create(BuilderTemplate template, BuilderType type, string name, string info, string tag)
        {
            BuilderTemplateInfo binfo = new BuilderTemplateInfo();
            binfo.Template =    template;
            binfo.BuilderType = type;
            binfo.Name =        name;
            binfo.Info =        info;
            binfo.Tag =         tag;

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

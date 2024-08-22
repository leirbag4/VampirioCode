using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using VampirioCode.BuilderSetting;
using System.Text.Json.Serialization;

namespace VampirioCode.Builder.Custom
{
    public class CustomBuilder : Builder
    {
        //public BuilderSettingBase Setting { get; set; }

        // custom build file -> .bsettings
        protected string BuildSettingsFile { get; set; } = "";

        /*public void Save()
        {
            Prepare();

            string json = JsonSerializer.Serialize(Setting);
            File.WriteAllText(BuildSettingsFile, json);
        }

        public void Load()
        {
            string json =   File.ReadAllText(BuildSettingsFile);
            Setting =       JsonSerializer.Deserialize<BuilderSettingBase>(json);
        }*/

        public bool Exists()
        {
            Prepare();
            return File.Exists(BuildSettingsFile);
        }

        public void Save()
        {
            Prepare();
            CreateProjectStructure();
            OnSave();
        }

        public void Load()
        {
            Prepare();
            OnLoad();
        }

        protected virtual void OnSave()
        { }

        protected virtual void OnLoad()
        { }

        protected void SaveSetting<T>(object setting) where T : BuilderSettingBase
        {
            T settingTyped = (T)setting;
            string json = JsonSerializer.Serialize<T>(settingTyped);
            File.WriteAllText(BuildSettingsFile, json);
        }

        protected T LoadSetting<T>() where T : BuilderSettingBase
        {
            string json = File.ReadAllText(BuildSettingsFile);
            return JsonSerializer.Deserialize<T>(json);
        }

        /*public T LoadSetting<T>(object customBuilder) where T : CustomBuilder
        {
            T builder = (T)customBuilder;
            return JsonSerializer.Deserialize<T>(BuildSettingsFile);
        }*/


        /*protected virtual void LoadSetting<T>() where T : BuilderSettingBase
        {
            string json = File.ReadAllText(BuildSettingsFile);
            T set = JsonSerializer.Deserialize<T>(json);
            OnSettingLoad(set);
        }

        protected virtual void OnSettingLoad(BuilderSettingBase setting)
        { 
        
        }*/

    }
}

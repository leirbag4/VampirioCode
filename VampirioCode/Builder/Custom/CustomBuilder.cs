using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO.Compression;
using VampirioCode.UI;
using VampirioCode.BuilderSetting.Actions;
using VampirioCode.Command;
using VampirioCode.BuilderSetting;

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

        /*public void ImportPackage(string packagePath, string outputPath)
        {
            ZipFile.ExtractToDirectory(packagePath + ".zip", outputPath);
        }*/

        public string GetBuildSettingsFile() { return BuildSettingsFile; }

        public async Task ImportPackage(string packagePath, string outputPath)
        {
            packagePath = AppInfo.BasePath + "\\packages\\" + packagePath;

            await Task.Run(() =>
            {
                try
                {
                    ZipFile.ExtractToDirectory(packagePath + ".zip", outputPath);
                    Console.WriteLine("Package '" + packagePath + "' extracted done.");
                }
                catch (Exception e)
                {
                    XConsole.PrintError("Error importing package: " + e.Message);
                }
            });
            
        }

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

        protected override void CreateProjectStructure()
        {
            if (!Directory.Exists(TempDir))
                Directory.CreateDirectory(TempDir);

            //XConsole.Alert("exist ProjectDir:" + Directory.Exists(ProjectDir));


            if (!Directory.Exists(ProjectDir))
            {
                Directory.CreateDirectory(ProjectDir);
            }
            else // ProjectDir exists
            {
                // If project exists but also contains a 'build settings', it can be
                // from our own project, so its content is copyed before deleting and
                // recreating the project directory
                if (File.Exists(BuildSettingsFile))
                {
                    string bsettingFileContent = File.ReadAllText(BuildSettingsFile);

                    Directory.Delete(ProjectDir, true);
                    Directory.CreateDirectory(ProjectDir);

                    File.WriteAllText(BuildSettingsFile, bsettingFileContent);
                    //XConsole.Alert("text: " + bsettingFileContent);
                }
                else
                {
                    Directory.Delete(ProjectDir, true);
                    Directory.CreateDirectory(ProjectDir);
                }
            }
            
        }

        protected async Task<bool> CopyDirs(List<CopyAction> dirs, BaseCmd cmd)
        {
            if ((dirs != null) && (dirs.Count > 0))
            {
                foreach(var dir in  dirs)
                {
                    string fromPath =   cmd.ReplaceVars(dir.From);
                    string toPath =     cmd.ReplaceVars(dir.To);
                    bool result =       await VampirioCode.Utils.FileUtils.CopyDirectoryAsync(fromPath, toPath, true);

                    if (!result)
                        return false;

                    XConsole.Println($"Copy Dir from \"{fromPath}\" to \"{toPath}\"");
                }
            }

            return true;
        }

        protected async Task<bool> CopyFiles(List<CopyAction> files, BaseCmd cmd)
        {
            if ((files != null) && (files.Count > 0))
            {
                //XConsole.Alert("files.Count: " + files.Count);

                foreach (var file in files)
                {
                    string fromPath =   cmd.ReplaceVars(file.From);
                    string toPath =     cmd.ReplaceVars(file.To);
                    bool result =       await VampirioCode.Utils.FileUtils.CopyFileAsync(fromPath, toPath, true);

                    if (!result)
                        return false;
                    
                    //XConsole.Alert($"Copy File from \"{fromPath}\" to \"{toPath}\"");
                }
            }

            return true;
        }


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

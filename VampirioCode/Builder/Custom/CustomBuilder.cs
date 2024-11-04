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
using VampirioCode.Utils;

namespace VampirioCode.Builder.Custom
{
    public class CustomBuilder : Builder
    {
        //public BuilderSettingBase Setting { get; set; }

        // custom build file -> .bsettings
        protected string BuildSettingsFile { get; set; } = "";


        public string GetBuildSettingsFile() { return BuildSettingsFile; }

        public async Task ImportPackage(string packagePath, string outputPath)
        {
            packagePath = AppInfo.BasePath + "\\packages\\" + packagePath;

            await Task.Run(() =>
            {
                try
                {
                    ZipFile.ExtractToDirectory(packagePath + ".vpkg", outputPath);
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

            // [DELETE]     temporary base dir [dir]  ->    \temp_build\proj_name\something_old\
            // [DELETE]     temporary base dir [file] ->    \temp_build\proj_name\something_old_2.bin
            // [CONSERVE]   temporary project dir ->        \temp_build\proj_name\msvc\
            FileUtils.DeleteFilesAndDirs(BaseProjDir, new[] { ProjectDir });

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

        protected async Task<List<string>> CopySourceFilesAsync(List<string> sources = null, string[] extensions = null, string[] dontIncludeFiles = null)
        {
            List<string> sourceFiles = new List<string>();
            List<string> sfiles = new List<string>();

            // [ AUTOMATIC ]
            if (sources == null)
            {
                sfiles = await FileUtils.GetFilesAdvAsync(originalBaseDir, extensions, dontIncludeFiles, true, false);
            }
            // [MANUAL]
            else
            {
                sfiles = sources;
            }

            foreach (var f in sfiles)
            {
                string fullFilePath =       Path.Combine(originalBaseDir, f);
                string outputFullFilePath = Path.Combine(ProjectDir, f);

                string extension = Path.GetExtension(outputFullFilePath);

                if (extension == ".h")
                { }
                else
                    sourceFiles.Add(outputFullFilePath);

                try
                {
                    if (outputFullFilePath == ProgramFile)
                    {
                        // This is the 'main' program
                        // write all code to '\temp_build\proj_name\msvc\proj.cpp' main program file
                        File.WriteAllText(ProgramFile, code);
                    }
                    else
                    {
                        // Copy all source files to '\temp_build\proj_name\msvc\'
                        await FileUtils.CopyFileWithDirsAsync(fullFilePath, outputFullFilePath);
                    }


                }
                catch (Exception e)
                {
                    XConsole.PrintError("Can't copy file from\n'" + fullFilePath + "'\nto: " + outputFullFilePath + "'");
                }
            }

            return sourceFiles;
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

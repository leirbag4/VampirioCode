using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VampirioCode.SaveData;
using VampirioCode.UI;


namespace VampirioCode.SaveData
{
    public class Config
    {
        // A save data file version for possible future incompatible properties
        public static string Version { get { return config.version; } set { config.version = value; } }

        // The documents from the previous session that were still opened before close
        public static SavedDocument[] LastOpenDocuments { get { return config.last_open_documents; } set { config.last_open_documents = value; } }

        
        private static Config config = null;
        private const string FILENAME = "config.cfg";

        public string version { get; set; } = "";
        public SavedDocument[] last_open_documents { get; set; }


        public static void Initialize()
        {
            bool createNew = false;
            string ver = AppInfo.Version;

            try
            {
                Load();

                if (Version != ver)
                {
                    Version = ver;
                    Save();
                    XConsole.Println("* New App version found. File '" + FILENAME + "' updated");
                }
            }
            catch (Exception e)
            {
                createNew = true;
            }

            if (createNew)
            {
                try
                {
                    CreateNew();
                    Save();
                }
                catch (Exception e)
                {
                    XConsole.Alert("Can't create and write the 'save data'!");
                }
            }
        }

        public static void CreateNew()
        {
            config = new Config();
            config.version =                AppInfo.Version;
            config.last_open_documents =    new SavedDocument[0];
        }

        public static void Load()
        {
            string json =   File.ReadAllText(FILENAME);
            config =        JsonSerializer.Deserialize<Config>(json);
        }
        public static void Save()
        {
            string json = JsonSerializer.Serialize(config);
            File.WriteAllText(FILENAME, json);
        }

    }
}



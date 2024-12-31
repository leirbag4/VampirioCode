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


        // Main window posX, posY, width and height of the last use
        public static int PosX { get { return config.posX; } set { config.posX = value; } }
        public static int PosY { get { return config.posY; } set { config.posY = value; } }
        public static int Width { get { return config.width; } set { config.width = value; } }
        public static int Height { get { return config.height; } set { config.height = value; } }

        // Represent if last time before close, the windows was maximized. Used to restore that state
        public static bool Maximized { get { return config.maximized; } set { config.maximized = value; } }
        public static int SplitterDistance { get { return config.splitter_distance; } set { config.splitter_distance = value; } }

        // The documents from the previous session that were still opened before close
        public static SavedDocument[] LastOpenDocuments {   get { return config.last_open_documents; }      set { config.last_open_documents = value; } }
        public static int LastSelectedTabIndex {            get { return config.last_selected_tab_index; }  set { config.last_selected_tab_index = value; } }
        
        private static Config config = null;
        //private const string FILENAME = "config.cfg";

        public int posX { get; set; } = -1;
        public int posY { get; set; } = -1;
        public int width { get; set; } = 820;
        public int height { get; set; } = 750;
        public bool maximized { get; set; } = false;
        public int splitter_distance { get; set; } = -1;
        public string version { get; set; } = "";
        public SavedDocument[] last_open_documents { get; set; }
        public int last_selected_tab_index { get; set; } = 0;

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
                    XConsole.Println("* New App version found. File '" + AppInfo.ConfigFileName + "' updated");
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

        /*public static void ReplaceLastOpenDocsPath(string oldFilePath, string newFilePath)
        {
            foreach (var lastDoc in LastOpenDocuments)
            {
                if (lastDoc.FullFilePath.Trim() == oldFilePath.Trim())
                {
                    lastDoc.FullFilePath = newFilePath.Trim();
                    return;
                }
            }
        }*/

        public static void CreateNew()
        {
            config = new Config();
            config.version =                AppInfo.Version;
            config.last_open_documents =    new SavedDocument[0];
        }

        public static void Load()
        {
            string json =   File.ReadAllText(AppInfo.ConfigFileName);
            config =        JsonSerializer.Deserialize<Config>(json);
        }
        public static void Save()
        {
            string json = JsonSerializer.Serialize(config);
            File.WriteAllText(AppInfo.ConfigFileName, json);
        }

    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VampirioCode.SaveData
{
    public class Settings
    {
        public static bool Portable { get { return settings.portable; } }
        public static bool Installable { get { return !settings.portable; } }

        private static Settings settings;
        public bool portable { get; set; } = false;

        public static void Initialize()
        {
            Load();
        }

        public static void Load()
        {
            string json =   File.ReadAllText(AppInfo.SettingsFileName);
            settings =      JsonSerializer.Deserialize<Settings>(json);
        }


    }
}

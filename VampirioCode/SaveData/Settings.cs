using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VampirioCode.UI;

namespace VampirioCode.SaveData
{
    public class Settings
    {
        public static bool Portable { get { return settings.portable; } }
        public static bool Installable { get { return !settings.portable; } }

        private static Settings settings;
        public bool portable { get; set; } = false;

        public static bool Initialize()
        {
            return Load();
        }

        public static bool Load()
        {
            try
            {
                string json = File.ReadAllText(AppInfo.SettingsFileName);
                settings = JsonSerializer.Deserialize<Settings>(json);
                return true;
            }
            catch (Exception ex)
            {
                MsgBox.Show("Can't find file: '" + AppInfo.SettingsFileName + "' or it is in use.\nPlease reinstall the software or reboot your computer.");
                return false;
            }
        }


    }
}

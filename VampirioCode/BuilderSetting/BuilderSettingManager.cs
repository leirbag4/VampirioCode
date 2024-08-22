using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace VampirioCode.BuilderSetting
{
    public class BuilderSettingManager
    {
        public static void Create(BuilderSettingBase setting, string outputFilePath)
        {
            string json = JsonSerializer.Serialize(setting);
            File.WriteAllText(outputFilePath, json);
        }

        public static T Load<T>(string inputFilePath) where T : BuilderSettingBase
        { 
            string json = File.ReadAllText(inputFilePath);
            return JsonSerializer.Deserialize<T>(json);
        }
        

    }
}

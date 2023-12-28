using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI;

namespace VampirioCode.Utils
{
    public class HotKeyManager
    {
        private static Dictionary<Keys, Action> hotKeys = new Dictionary<Keys, Action>();

        public static void AddHotKey(Action function, Keys keys)
        {
            var hotKey = keys;
            hotKeys.Add(hotKey, function);
        }

        public static bool ProcessKeys(Keys keys)
        {
            if (hotKeys.TryGetValue(keys, out var action))
            {
                action?.Invoke();
                return true;
            }

            return false;
        }
    }
}

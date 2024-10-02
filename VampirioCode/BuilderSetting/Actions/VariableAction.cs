using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.BuilderSetting.Actions
{
    public class VariableAction
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public static List<String> ToString(List<VariableAction> varActions, string middleSymbol = "")
        {
            List<String> actions = new List<String>();
            foreach (var varAction in varActions)
                actions.Add(varAction.Name + middleSymbol + varAction.Value);

            return actions;
        }
    }
}

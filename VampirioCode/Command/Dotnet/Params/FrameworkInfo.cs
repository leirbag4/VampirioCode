using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Command.Dotnet.Params
{
    public class FrameworkInfo
    {
        public Framework Framework { get; set; }
        public string Name { get; set; }
        public string Param { get; set; }
        public string Description { get; set; }

        private static FrameworkInfo _Create(Framework fw, string name, string param, string description)
        { 
            FrameworkInfo finfo =   new FrameworkInfo();
            finfo.Framework =       fw;
            finfo.Name =            name;
            finfo.Param =           param;
            finfo.Description =     description;
            return finfo;
        }

        public static FrameworkInfo Get(Framework framework)
        {
            Framework fw = framework;

            switch (framework) 
            {
                case Framework.Default:     return _Create(fw, "", "", "");

                case Framework.DotNet6_0:   return _Create(fw, "DotNet 6.0",     "net6.0",   ".Net");
                case Framework.DotNet7_0:   return _Create(fw, "DotNet 7.0",     "net7.0",   ".Net");
                case Framework.DotNet8_0:   return _Create(fw, "DotNet 8.0",     "net8.0",   ".Net");
                default:                    return null;
            }
        }
    }
}

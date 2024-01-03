using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Dotnet.Params;

namespace VampirioCode.Command.Dotnet.Models
{
    public class Template
    {
        public string Name { get; set; } = "";
        public string ShortName { get; set; } = "";
        public Language[] Languages { get; set; }
        public string Type { get; set; } = "";
        public string Author { get; set; } = "";
        public string Tags { get; set; } = "";

        public override string ToString()
        {
            string langs = "";
            foreach (var lang in Languages)
                langs += lang.ToString() + "/";

            langs = langs.TrimEnd('/');

            return "Name: " + Name + ", ShortName: " + ShortName + ", Languages: " + langs + ", Type: " + Type + ", Author: " + Author + ", Tags: " + Tags;
        }

    }
}

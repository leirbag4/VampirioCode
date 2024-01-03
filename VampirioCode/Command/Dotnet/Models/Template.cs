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
        public string[] Languages { get; set; }
        public string Type { get; set; } = "";
        public string Author { get; set; } = "";
        public string Tags { get; set; } = "";


        public Template(string name, string shortName, string[] languages, string type, string author, string tags)
        {
            Name =      name;
            ShortName = shortName;
            Languages = languages;
            Type =      type;
            Author =    author;
            Tags =      tags;
        }

        public override string ToString()
        {
            return "Name: " + Name + ", ShortName: " + ShortName + ", Languages: " + string.Join(",", Languages) + ", Type: " + Type + ", Author: " + Author + ", Tags: " + Tags;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.Command.Dotnet.Params;
using VampirioCode.UI;

namespace VampirioCode.Command.Dotnet.Models
{
    public class STemplate
    {
        //Template Name       Short Name                        Author          Language  Type     Tags      Package Name / Owners     Trusted  Downloads

        public string Name { get; set; } = "";
        public string ShortName { get; set; } = "";
        public string Author { get; set; } = "";
        public string Type { get; set; } = "";
        public string[] Language { get; set; }
        public string Tags { get; set; } = "";
        public string PackageName { get; set; } = "";
        public string Owners { get; set; } = "";
        public bool Trusted { get; set; } = false;
        public string Downloads { get; set; } = "";

        public STemplate(string name, string shortName, string author, string[] language, string type, string tags, string packageNameAndOwners, string trusted, string downloads)
        {
            string[] packArr = packageNameAndOwners.Split('/');

            Name =          name;
            ShortName =     shortName;
            Author =        author;
            Language =      language;
            Type =          type;
            Tags =          tags;
            PackageName =   packArr[0].Trim();
            Owners =        packArr[1].Trim();
            Trusted =       trusted.Trim() != "";
            Downloads =     downloads;
        }

        public override string ToString()
        {
            return $"Name: {Name}, ShortName: {ShortName}, Author: {Author}, Language: {string.Join(",", Language)}, Type:{Type}, Tags: {Tags}, PackageName: {PackageName}, Owners: {Owners}, Trusted: {Trusted}, Downloads: {Downloads}";
        }
    }
}

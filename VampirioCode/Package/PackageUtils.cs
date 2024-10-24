using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Package
{
    public class PackageUtils
    {
        // This method receives the author's name and the package name,
        // replaces spaces with underscores, and joins them with two underscores "__".
        public static string EncodeName(string author, string packageName)
        {
            // Replace spaces in both author and package name with underscores
            string encodedAuthor = author.Replace(" ", "_");
            string encodedPackageName = packageName.Replace(" ", "_");

            // Join them with two underscores "__"
            string codeName = $"{encodedAuthor}__{encodedPackageName}";
            return codeName;
        }

        // This method receives the codeName and splits it into the author name and package name,
        // also replacing underscores with spaces.
        public static (string author, string packageName) DecodeName(string codeName)
        {
            // Split the codeName into two parts using the double underscores "__" as a separator
            string[] parts = codeName.Split(new[] { "__" }, StringSplitOptions.None);

            // Ensure there are exactly two parts (author and package name)
            if (parts.Length != 2)
            {
                throw new ArgumentException("The codeName is not in the expected format.");
            }

            // Replace underscores with spaces in both parts
            string decodedAuthor = parts[0].Replace("_", " ");
            string decodedPackageName = parts[1].Replace("_", " ");

            // Return the author and package name as a tuple
            return (decodedAuthor, decodedPackageName);
        }
    }
}

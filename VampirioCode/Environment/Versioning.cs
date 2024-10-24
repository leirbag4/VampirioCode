using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Environment
{
    public class Versioning
    {
        public Versioning() :this(0, 0, 0)
        { }

        public Versioning(int major, int minor, int patch) 
        { 
            this.Major = major; 
            this.Minor = minor; 
            this.Patch = patch;
        }

        public int Major { get; set; } = 0;
        public int Minor { get; set; } = 0;
        public int Patch { get; set; } = 0;

        public override string ToString()
        {
            return Major + "." + Minor + "." + Patch;
        }
    }
}

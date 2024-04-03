using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Builder
{
    public class SimpleJavaBuilder : Builder
    {

        public SimpleJavaBuilder()
        {
            Name = "Javac";
            Type = BuilderType.SimpleJava;
        }

    }
}

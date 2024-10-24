using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Builder
{
    //
    // C = Custom Build
    // S = Simple Build
    //
    // Flags in hexa: CCCC SSSS
    //
    // Useful to compare equivalents like
    //              SimpleMsvcCpp = 0x00000002 to
    //              CustomMsvcCpp = 0x00020000 by shifting 
    //
    public enum BuilderType
    {
        None =              0x00000000,
        SimpleCSharp =      0x00000001,
        SimpleMsvcCpp =     0x00000002, // equivalent with CustomMsvcCpp = 0x00020000
        SimpleGnuGppCpp =   0x00000004,
        SimpleClangCpp =    0x00000008,
        SimpleWasmCpp =     0x00000010,
        SimpleJs =          0x00000011,
        SimpleJava =        0x00000012,
        SimplePhp =         0x00000014,

        // Customs
        //CustomCSharp =        0x00010000, // guide for future implementation
        CustomMsvcCpp =         0x00020000,
        CustomGnuGppWSLCpp =    0x00040000  // guide for future implementation
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ProjectAssembler
{
    class HighLevelVignetting
    {
        [DllImport(@"C:\tmp\projectAssembler\ProjectAssembler\x64\Release\HighLevelVignetting.dll")]
        unsafe public static extern int* vignetting(int* a, int* b, int lenght);
    }
}

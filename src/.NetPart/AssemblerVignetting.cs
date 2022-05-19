using System.Runtime.InteropServices;

namespace ProjectAssembler
{
    class AssemblerVignetting
    {
        [DllImport(@"C:\tmp\projectAssembler\ProjectAssembler\x64\Release\JaAsm.dll")]

        unsafe public static extern int* vignetting(int* pixelPointer, int* vignettePointer, int numberOfPixels, int* finalDataPointer);
        unsafe public static int* AsmVignetting(int* pixelPointer , int* vignettePointer, int numberOfPixels, int* finalDataPointer)
        {
            vignetting(pixelPointer, vignettePointer, numberOfPixels, finalDataPointer);
            return finalDataPointer;
        }
    }
}

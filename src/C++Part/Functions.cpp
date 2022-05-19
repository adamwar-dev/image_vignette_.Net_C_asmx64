#include <Windows.h>
#define function _declspec(dllexport)
extern "C" {
    /*
    * Wysoko poziomowa DLL
    * --------------------
    * Je¿eli winieta == 0, to pixel jest czarny
    * Je¿eli winieta == 1, to przepisujemy pixel
    * W przeciwnym wypadku wyliczamy jego wartoœæ
    */
    function int* vignetting(int* pixels, int* vignette, int length)
    {
        int* finalPixels = new int[length * 5];
        int j = 0;
        for (int i = 0; i < length; i++) {
            finalPixels[j] = pixels[j];
            finalPixels[j + 1] = pixels[j + 1];
            if (vignette[i] == 0) {
             finalPixels[j + 2] = 0;
             finalPixels[j + 3] = 0;
             finalPixels[j + 4] = 0;
            }
            else if (vignette[i] == 1) {
                finalPixels[j + 2] = pixels[j + 2];
                finalPixels[j + 3] = pixels[j + 3];
                finalPixels[j + 4] = pixels[j + 4];
            }
            else {
                finalPixels[j + 2] = (pixels[j + 2] + pixels[j + 3] + pixels[j + 4]) / vignette[i];
                finalPixels[j + 3] = (pixels[j + 2] + pixels[j + 3] + pixels[j + 4]) / vignette[i];
                finalPixels[j + 4] = (pixels[j + 2] + pixels[j + 3] + pixels[j + 4]) / vignette[i];
            }
            j += 5;
        }
        return finalPixels;
    }
}
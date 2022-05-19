using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ProjectAssembler
{
    public class HighLevelPart
    {
        private readonly int imageWidth;
        private readonly int imageHeight;
        private readonly Bitmap image;

        public HighLevelPart(Image inputImage)
        {
            this.image = (Bitmap)inputImage;
            this.imageWidth = inputImage.Width;
            this.imageHeight = inputImage.Height;
        }

        public int getWidth()
        {
            return this.imageWidth;
        }

        public int getHeight()
        {
            return this.imageHeight;
        }

        /*
         * Zwracanie wszystkich współrzędnych i wartości rgb wszystkich pixeli
         */
        public int[] GetAllPixels()
        {
            int[] allPixels = new int[this.imageHeight * this.imageWidth * 5];
            int counter = 0;
            for (int currentHeight = 0; currentHeight < this.imageHeight; currentHeight++)
            {
                for (int currentWidth = 0; currentWidth < this.imageWidth; currentWidth++)
                {
                    allPixels[counter] = currentWidth;
                    allPixels[counter + 1] = currentHeight;
                    allPixels[counter + 2] = this.image.GetPixel(currentWidth, currentHeight).R;
                    allPixels[counter + 3] = this.image.GetPixel(currentWidth, currentHeight).G;
                    allPixels[counter + 4] = this.image.GetPixel(currentWidth, currentHeight).B;
                    counter += 5;
                }
            }
            return allPixels;
        }

        /*
        * Wyliczanie wyniety dla wszystkich pixeli
        */
        public int[] GetAllPixelsVignette()
        {
            int[] allPixelsVignette = new int[this.imageHeight * this.imageWidth];

            int centerPixelX = this.imageWidth / 2;
            int centerPixelY = this.imageHeight / 2;

            int maxDistance = (int)Math.Sqrt(centerPixelX * centerPixelX + centerPixelY * centerPixelY);

            int radiusOne = (int)(maxDistance * 0.80);
            int radiusTwo = (int)(maxDistance * 0.78);
            int radiusThree = (int)(maxDistance * 0.76);
            int radiusFour = (int)(maxDistance * 0.74);
            int radiusFive = (int)(maxDistance * 0.72);
            int radiusSix = (int)(maxDistance * 0.70);
            int radiusSeven = (int)(maxDistance * 0.68);
            int radiusEight = (int)(maxDistance * 0.66);
            int radiusNine = (int)(maxDistance * 0.64);
            int radiusTen = (int)(maxDistance * 0.62);

            int counter = 0;
            for (int currentHeight = 0; currentHeight < this.imageHeight; currentHeight++)
            {
                for (int currentWidth = 0; currentWidth < this.imageWidth; currentWidth++)
                {
                    int distance = (int)Math.Sqrt((centerPixelX - currentWidth) * (centerPixelX - currentWidth) + (centerPixelY - currentHeight) * (centerPixelY - currentHeight));
                    if (distance >= radiusOne)
                    {
                        allPixelsVignette[counter] = 0;
                    }
                    else if (distance < radiusOne && distance >= radiusTwo)
                    {
                        allPixelsVignette[counter] = 26;
                    }
                    else if (distance < radiusTwo && distance >= radiusThree)
                    {
                        allPixelsVignette[counter] = 24;
                    }
                    else if (distance < radiusThree && distance >= radiusFour)
                    {
                        allPixelsVignette[counter] = 22;
                    }
                    else if (distance < radiusThree && distance >= radiusFour)
                    {
                        allPixelsVignette[counter] = 20;
                    }
                    else if (distance < radiusThree && distance >= radiusFour)
                    {
                        allPixelsVignette[counter] = 18;
                    }
                    else if (distance < radiusFour && distance >= radiusFive)
                    {
                        allPixelsVignette[counter] = 16;
                    }
                    else if (distance < radiusFive && distance >= radiusSix)
                    {
                        allPixelsVignette[counter] = 14;
                    }
                    else if (distance < radiusSix && distance >= radiusSeven)
                    {
                        allPixelsVignette[counter] = 12;
                    }
                    else if (distance < radiusSeven && distance >= radiusEight)
                    {
                        allPixelsVignette[counter] = 10;
                    }
                    else if (distance < radiusEight && distance >= radiusNine)
                    {
                        allPixelsVignette[counter] = 8;
                    }
                    else if (distance < radiusNine && distance >= radiusTen)
                    {
                        allPixelsVignette[counter] = 6;
                    }
                    else
                    {
                        allPixelsVignette[counter] = 1;
                    }
                    counter++;
                }
            }
            return allPixelsVignette;
        }


        /*
        * Tworzenie bitmapy z zwinietowanych pixeli oraz zwrócenie jej
        */
        unsafe public Image getImage(int*[] finalData, int length, int singleDataLength)
        {
            //dodawanie wyników każdego wątku
            List<int> finalPixels = new List<int>();
            for (int j = 0; j < finalData.Length; j++)
            {
                int k = 0;
                int* p = finalData[j];
                while (k < singleDataLength)
                {
                    finalPixels.Add(*p);
                    p++;
                    k++;
                }
            }

            //Logi - znajdują się w bin/x64/release
/*            StreamWriter file = new StreamWriter("pixelLogs.txt");
            int index = 0;
            foreach (int pixelData in finalPixels)
            {
                if (index == 0)
                {
                    file.WriteLine("X: " + pixelData.ToString());
                }
                else if (index == 1)
                {
                    file.WriteLine("Y: " + pixelData.ToString());
                }
                else if (index == 2)
                {
                    file.WriteLine("R: " + pixelData.ToString());
                }
                else if (index == 3)
                {
                    file.WriteLine("G: " + pixelData.ToString());
                }
                else if (index == 4)
                {
                    file.WriteLine("B: " + pixelData.ToString());
                }

                if (index == 4)
                {
                    index = 0;
                } else
                {
                    index++;
                }
            }*/


            //tworzenie bitmapy z listy finalPixels
            Bitmap finalImage = new Bitmap(imageWidth, imageHeight);
            int i = 0;
            for (int currentHeight = 0; currentHeight < this.imageHeight; currentHeight++)
            {
                for (int currentWidth = 0; currentWidth < this.imageWidth; currentWidth++)
                {
                    if (i >= finalPixels.Count)
                    {
                        break;
                    }
                    int pixelWidth = finalPixels[i];
                    int pixelHeight = finalPixels[i + 1];
                    int pixelR = finalPixels[i + 2];
                    int pixelG = finalPixels[i + 3];
                    int pixelB = finalPixels[i + 4];
                    i += 5;
                    finalImage.SetPixel(pixelWidth, pixelHeight, Color.FromArgb(pixelR, pixelG, pixelB));

                }
            }
            return finalImage;
        }
    }
}

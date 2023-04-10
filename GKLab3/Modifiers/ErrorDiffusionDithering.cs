using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastBitmapLib;
using Model;

namespace GKLab3.Modifiers
{
    internal class ErrorDiffusionDithering : IImageModifier
    {
        private Krgb MyKrgb { get; set; }
        private readonly float[,] filter = { { 0, 0, 0 }, { 0, 0, 7f / 16f }, { 3f / 16f, 5f / 16f, 1f / 16f } };
        private const int f_x = 1, f_y = 1;

        public ErrorDiffusionDithering(Krgb krgb)
        {
            MyKrgb = krgb;
        }

        public void PleaseModifyImage(FastBitmap map)
        {
            
            //float[,] filter = { { 0, 0, 7f / 16f }, { 3f / 16f, 5f / 16f, 1f / 16f } };
            //double[][] intervals = PopularityAlgorithm(map);

            map.Lock();
            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    Color c = map.GetPixel(j, i);

                    int newR = Approximate(c.R, MyKrgb.Kr);
                    int newG = Approximate(c.G, MyKrgb.Kg);
                    int newB = Approximate(c.B, MyKrgb.Kb);

                    float errorR = c.R - newR;
                    float errorG = c.G - newG;
                    float errorB = c.B - newB;

                    map.SetPixel(j, i, Color.FromArgb(newR, newG, newB));

                    for (int n = -f_y; n <= f_y; n++)
                    {
                        for (int m = -f_x; m <= f_x; m++)
                        {
                            if (j + m < 0 || j + m >= map.Width || i + n < 0 || i + n >= map.Height) continue;

                            Color setC = map.GetPixel(j + m, i + n);
                            int setR = BigerSmaller((int)Math.Round(setC.R + errorR * filter[f_y + n, f_x + m]));
                            int setG = BigerSmaller((int)Math.Round(setC.G + errorG * filter[f_y + n, f_x + m]));
                            int setB = BigerSmaller((int)Math.Round(setC.B + errorB * filter[f_y + n, f_x + m]));

                            map.SetPixel(j + m, i + n, Color.FromArgb(setR, setG, setB));
                        }
                    }
                }
            }
            map.Unlock();
        }

        private int Approximate(int color, int Ksomething)
        {
            int number_of_levels = Ksomething;
            float step = (255f / (float)number_of_levels);
            float new_color = (255f / (float)(number_of_levels - 1));

            int interval = 0;
            for (float k = 0; k < 255; k += step)
            {
                if (k <= color && color <= (k + step))
                {
                    return (int)Math.Round(new_color * interval);
                }
                interval++;
            }

            return 0;
        }

        private int BigerSmaller(int color)
        {
            if (color > 255) return 255;
            if (color < 0) return 0;

            return color;
        }
    }
}

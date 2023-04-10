using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastBitmapLib;
using Model;

namespace GKLab3.Modifiers
{
    internal class AverageDithering : IImageModifier
    {
        private Krgb MyKrgb { get; set; }


        public AverageDithering(Krgb krgb)
        {
            MyKrgb = krgb;
        }


        public void PleaseModifyImage(FastBitmap map)
        {
            map.Lock();
            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    Color c = map.GetPixel(j, i);
                    int R = SetValue(c.R, MyKrgb.Kr);
                    int G = SetValue(c.G, MyKrgb.Kg);
                    int B = SetValue(c.B, MyKrgb.Kb);

                    map.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            map.Unlock();
        }


        private int SetValue(int color, int K)
        {
            int number_of_levels = K;
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
    }
}

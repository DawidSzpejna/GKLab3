using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastBitmapLib;
using Model;

namespace GKLab3.Modifiers
{
    internal class PopularityAlgorithm : IImageModifier
    {
        private Krgb MyKrgb { get; set; }

        public PopularityAlgorithm(Krgb krgb)
        {
            MyKrgb = krgb;
        }

        public void PleaseModifyImage(FastBitmap map)
        {
            (int R, int G, int B)[] palette = Preprocesing(map, MyKrgb.K);
            ModifyBitmap(map, palette);
        }

        private (int R, int G, int B)[] Preprocesing(FastBitmap pic, int K)
        {
            Dictionary<(int, int, int), int> colors = new Dictionary<(int, int, int), int>();

            pic.Lock();
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    Color c = pic.GetPixel(j, i);

                    (int, int, int) col = (c.R, c.G, c.B);
                    if (colors.ContainsKey(col))
                    {
                        colors[col] += 1;
                    }
                    else
                    {
                        colors.Add(col, 1);
                    }
                }
            }
            pic.Unlock();

            (int R, int G, int B)[] result = new (int R, int G, int B)[K];
            {
                int counter = 0;
                foreach (var c in colors.OrderByDescending(pair => pair.Value))
                {
                    if (counter >= K) break;
                    result[counter] = c.Key;
                    counter++;

                }

            }

            return result;
        }

        private void ModifyBitmap(FastBitmap map, (int R, int G, int B)[] palette)
        {
            map.Lock();
            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    Color c = map.GetPixel(j, i);
                    (int R, int G, int B) newColor = Approximate(palette, c);

                    map.SetPixel(j, i, Color.FromArgb(newColor.R, newColor.G, newColor.B));
                }
            }
            map.Unlock();
        }

        private (int R, int G, int B) Approximate((int R, int G, int B)[] intensities, Color color)
        {
            (int R, int G, int B) result = (0, 0, 0);
            double difference = double.PositiveInfinity;

            foreach ((int R, int G, int B) its in intensities)
            {
                double dif = Math.Sqrt(Math.Pow(its.R - color.R, 2) +
                                        Math.Pow(its.G - color.G, 2) +
                                        Math.Pow(its.B - color.B, 2));
                if (difference > dif)
                {
                    difference = dif;
                    result = its;
                }
            }

            return result;
        }
    }
}

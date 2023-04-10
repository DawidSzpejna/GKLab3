using FastBitmapLib;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace GKLab3
{
    public partial class Form1 : Form
    {
        Bitmap Canvas;
        Bitmap MyImage;
        int Kr = 2, Kg = 4, Kb = 4;

        public Form1()
        {
            InitializeComponent();

            Canvas = new Bitmap(PictureBox.Width, PictureBox.Height);
            MyImage = new Bitmap(Image.FromFile(@"Pictures/Papy.png"));
            PictureBox.Image = Canvas;
            using (Graphics g = Graphics.FromImage(Canvas))
            {
                g.Clear(Color.LightBlue);
                g.DrawImage(MyImage, new Point(0,0));
            }
            PictureBox.Refresh();

            //CountingAverage(new FastBitmap(MyImage));
             //AverageDithering(new FastBitmap(MyImage));
             //ErrorDiffDitheringNew(new FastBitmap(MyImage));
            //AverageDitheringNew(new FastBitmap(MyImage));
            //KMeansClusteringSegmentation(MyImage, 10);
            using (Graphics g = Graphics.FromImage(Canvas))
            {
                g.Clear(Color.LightBlue);
                g.DrawImage(MyImage, new Point(0, 0));
            }
            PictureBox.Refresh();
            //PopularityAlgorithm(new FastBitmap(MyImage));
            //PictureBox.Refresh();
            int z = 0;
        }

        public void AverageDitheringNew(FastBitmap pic)
        {
            //double[][] intervals = CountingAverage(pic);
            //double[][] intervals = PopularityAlgorithmNew(pic);

            pic.Lock();
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    Color c = pic.GetPixel(j, i);
                    int R = SetValueNew(c.R, Kr);
                    int G = SetValueNew(c.G, Kg);
                    int B = SetValueNew(c.B, Kb);

                    pic.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            pic.Unlock();

        }

        public void AverageDithering(FastBitmap pic)
        {
            //double[][] intervals = CountingAverage(pic);
            double[][] intervals = PopularityAlgorithm(pic);

            pic.Lock();
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    Color c = pic.GetPixel(j, i);
                    int R = SetValue(c.R, intervals[0], Kr);
                    int G = SetValue(c.G, intervals[1], Kg);
                    int B = SetValue(c.B, intervals[2], Kb);

                    pic.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            pic.Unlock();

        }

        #region Popularity
        public double[][] PopularityAlgorithm(FastBitmap pic)
        {
            Dictionary<int, int>[] colors = new Dictionary<int, int>[] {
                new Dictionary<int, int>(),
                new Dictionary<int, int>(),
                new Dictionary<int, int>()
            };

            pic.Lock();
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    Color c = pic.GetPixel(j, i);

                    Filler(c.R, colors[0]);
                    Filler(c.G, colors[1]);
                    Filler(c.B, colors[2]);
                }
            }
            pic.Unlock();

            double[] R = SearchInteval(colors[0], Kr);
            double[] G = SearchInteval(colors[1], Kg);
            double[] B = SearchInteval(colors[2], Kb);

            return new double[][] {R, G, B};
        }

        public (int R, int G, int B)[] PopularityAlgorithmNew(FastBitmap pic, int K)
        {
            Dictionary<(int,int,int), int> colors = new Dictionary<(int, int, int), int>();

            pic.Lock();
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    Color c = pic.GetPixel(j, i);

                    //Filler(c.R, colors[0]);
                    //Filler(c.G, colors[1]);
                    //Filler(c.B, colors[2]);
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

            //double[] R = SearchInteval(colors[0], Kr);
            //double[] G = SearchInteval(colors[1], Kg);
            //double[] B = SearchInteval(colors[2], Kb);
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

        public void Filler(int color, Dictionary<int,int> dic)
        {
            if (dic.ContainsKey(color))
            {
                dic[color] += 1;
            }
            else
            {
                dic.Add(color, 1);
            }
        }

        public double[] SearchInteval(Dictionary<int, int> dic, int K)
        {
            //dic.OrderBy(k => k.Value);

            double[] result = new double[K];
            float step = (255f / (float)K);
            int interval = 0;
            for (float start = 0; start < 255; start += step)
            {
                int popularity = 0;
                int color = (int)Math.Round(start);

                foreach (var kok in dic.Keys)
                {
                    if (kok > start + step) break;

                    if (popularity < dic[kok])
                    {
                        color = kok;
                        popularity = dic[kok];
                    }
                }
                result[interval] = color;
                interval++;
            }

            return result;
        }
        #endregion

        #region Kmeans

        public Bitmap KMeansClusteringSegmentation(Bitmap image, int clusters)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];

            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            byte[] result = new byte[bytes];
            int[] means = new int[clusters];
            Random rnd = new Random();

            for (int i = 0; i < clusters; i++)
            {
                int init_mean = rnd.Next(1, 255);
                while (means.Contains((byte)init_mean))
                {
                    init_mean = rnd.Next(1, 255);
                }
                means[i] = (byte)init_mean;
            }

            double error = new double();
            List<byte>[] samples = new List<byte>[clusters];

            while (true)
            {
                for (int i = 0; i < clusters; i++)
                {
                    samples[i] = new List<byte>();
                }

                for (int i = 0; i < bytes; i += 3)
                {
                    double norm = 999;
                    int cluster = 0;

                    for (int j = 0; j < clusters; j++)
                    {
                        double temp = Math.Abs(buffer[i] - means[j]);
                        if (norm > temp)
                        {
                            norm = temp;
                            cluster = j;
                        }
                    }
                    samples[cluster].Add(buffer[i]);

                    for (int c = 0; c < 3; c++)
                    {
                        result[i + c] = (byte)means[cluster];
                    }
                }

                int[] new_means = new int[clusters];

                for (int i = 0; i < clusters; i++)
                {
                    for (int j = 0; j < samples[i].Count(); j++)
                    {
                        new_means[i] += samples[i][j];
                    }

                    new_means[i] /= (samples[i].Count() + 1);
                }

                int new_error = 0;

                for (int i = 0; i < clusters; i++)
                {
                    new_error += Math.Abs(means[i] - new_means[i]);
                    means[i] = new_means[i];
                }

                if (error == new_error)
                {
                    break;
                }
                else
                {
                    error = new_error;
                }
            }

            Bitmap res_img = new Bitmap(w, h);
            BitmapData res_data = res_img.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            Marshal.Copy(result, 0, res_data.Scan0, bytes);
            res_img.UnlockBits(res_data);

            return res_img;
        }


        #endregion

        #region Error Diffusion
        public void ErrorDiffDithering(FastBitmap pic)
        {
            const int f_x = 1, f_y = 1;
            float[,] filter = { { 0, 0, 0 }, { 0, 0, 7f / 16f }, { 3f / 16f, 5f / 16f, 1f / 16f } };
            //float[,] filter = { { 0, 0, 7f / 16f }, { 3f / 16f, 5f / 16f, 1f / 16f } };
            double[][] intervals = PopularityAlgorithm(pic);

            pic.Lock();
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    Color c = pic.GetPixel(j, i);

                    int newR = Approximate(intervals[0], c.R);
                    int newG = Approximate(intervals[1], c.G);
                    int newB = Approximate(intervals[2], c.B);

                    float errorR = c.R - newR;
                    float errorG = c.G - newG;
                    float errorB = c.B - newB;

                    pic.SetPixel(j, i, Color.FromArgb(newR, newG, newB));

                    for (int n = -f_y; n <= f_y; n++)
                    {
                        for (int m = -f_x; m <= f_x; m++)
                        {
                            if (j + m < 0 || j + m >= pic.Width || i + n < 0 || i + n >= pic.Height) continue;

                            Color setC = pic.GetPixel(j + m, i + n);
                            int setR = BigerSmaller((int)Math.Round(setC.R + errorR * filter[f_y + n, f_x + m]));
                            int setG = BigerSmaller((int)Math.Round(setC.G + errorG * filter[f_y + n, f_x + m]));
                            int setB = BigerSmaller((int)Math.Round(setC.B + errorB * filter[f_y + n, f_x + m]));

                            pic.SetPixel(j + m, i + n, Color.FromArgb(setR, setG, setB));
                        }
                    }
                }
            }
            pic.Unlock();

        }

        public void ErrorDiffDitheringNew(FastBitmap pic)
        {
            const int f_x = 1, f_y = 1;
            float[,] filter = { { 0, 0, 0 }, { 0, 0, 7f / 16f }, { 3f / 16f, 5f / 16f, 1f / 16f } };
            //float[,] filter = { { 0, 0, 7f / 16f }, { 3f / 16f, 5f / 16f, 1f / 16f } };
            (int,int,int)[] intervals = PopularityAlgorithmNew(pic, 20);

            pic.Lock();
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    Color c = pic.GetPixel(j, i);

                    (int R, int G, int B) newC = ApproximateNew(intervals, c);

                    float errorR = c.R - newC.R;
                    float errorG = c.G - newC.G;
                    float errorB = c.B - newC.B;

                    pic.SetPixel(j, i, Color.FromArgb(newC.R, newC.G, newC.B));

                    for (int n = -f_y; n <= f_y; n++)
                    {
                        for (int m = -f_x; m <= f_x; m++)
                        {
                            if (j + m < 0 || j + m >= pic.Width || i + n < 0 || i + n >= pic.Height) continue;

                            Color setC = pic.GetPixel(j + m, i + n);
                            int setR = BigerSmaller((int)Math.Round(setC.R + errorR * filter[f_y + n, f_x + m]));
                            int setG = BigerSmaller((int)Math.Round(setC.G + errorG * filter[f_y + n, f_x + m]));
                            int setB = BigerSmaller((int)Math.Round(setC.B + errorB * filter[f_y + n, f_x + m]));

                            pic.SetPixel(j + m, i + n, Color.FromArgb(setR, setG, setB));
                        }
                    }
                }
            }
            pic.Unlock();

        }

        public int BigerSmaller(int color)
        {
            if (color > 255) return 255;
            if (color < 0) return 0;

            return color;
        }

        public int Approximate(double[] intensities, int color)
        {
            double result = 0;
            double difference = double.PositiveInfinity;
            foreach (double intensity in intensities)
            {
                double dif = Math.Abs(intensity - color);
                if (difference > dif)
                {
                    difference = dif;
                    result = intensity;
                }
            }

            return (int)Math.Round(result);
        }

        public (int R, int G, int B) ApproximateNew((int R, int G, int B)[] intensities, Color color)
        {
            (int R, int G, int B) result = (0, 0, 0);
            double difference = double.PositiveInfinity;

            foreach ((int R, int G, int B) its in intensities)
            {
                double dif = Math.Sqrt( Math.Pow(its.R - color.R, 2) + 
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

        #endregion

        #region Ordered

        public void OrderedDithering(FastBitmap pic)
        {
            int[,] D = { { 6, 8, 4 }, { 1, 0, 3 }, { 5, 2, 7 } };
            int n = 3;
            double[][] intervals = PopularityAlgorithm(pic);

            pic.Lock();
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    Color c = pic.GetPixel(j, i);


                    float col = (float)c.R / (float)(n * n);
                    float re = c.R % (n * n);

                    int k = j % n;
                    int l = i % n;

                    if (re > D[k, l]) col++;




                    //pic.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            pic.Unlock();
        }

        #endregion

        #region test
        public double[][] CountingAverage(FastBitmap pic)
        {
            double[][] result = new double[3][];
            result[0] = new double[Kr];
            result[1] = new double[Kg];
            result[2] = new double[Kb];

            double[][] counter = new double[3][];
            counter[0] = new double[Kr];
            counter[1] = new double[Kg];
            counter[2] = new double[Kb];

            pic.Lock();
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    Color c = pic.GetPixel(j, i);

                    CountVal(c.R, result[0], counter[0], Kr);
                    CountVal(c.G, result[1], counter[1], Kg);
                    CountVal(c.B, result[2], counter[2], Kb);
                }
            }
            pic.Unlock();

            //CountMean(result[0], counter[0], Kr);
            //CountMean(result[1], counter[1], Kg);
            //CountMean(result[2], counter[2], Kb);

            CountMeanAnia(result[0], counter[0], Kr);
            CountMeanAnia(result[1], counter[1], Kg);
            CountMeanAnia(result[2], counter[2], Kb);
            return result;
        }

        public void CountVal(int color, double[] result, double[] counter, int K)
        {
            float step = (255f / (float)K);
            int ctr = 0;
            for (float k = 0; k < 255; k += step)
            {
                if (k <= color && color <= (k + step))
                {
                    result[ctr] += color;
                    counter[ctr] += 1;
                    break;
                }
                ctr++;
            }
        }


        public void CountMeanAnia(double[] result, double[] counter, int K)
        {
            float step = (255f / (float)K);
            
            for (int i = 0; i < K; i++)
            {
                result[i] = (i * step + (i + 1) * step) / 2f;
                //result[i] = (int)Math.Round((double)result[i] / (double)counter[i]);

            }
        }

        public void CountMean(double[] result, double[] counter, int K)
        {
            for (int i = 0; i < K; i++)
            {
                result[i] = (int)Math.Round((double)result[i] / (double)counter[i]);
            }
        }

        #endregion

        public int SetValue(int color, double[] intervals, int K)
        {
            float step = (255f / (float)K);
            int interval = 0;
            bool lover = true;
            for (float k = 0; k < 255; k += step)
            {
                if (k <= color && color <= (k + step))
                {
                    if (intervals[interval] < color)
                    {
                        lover = false;
                        break;
                    }
                }
                interval++;
            }

            return (int)Math.Round(interval * step + (lover ? 0 : step));
        }

        public int SetValueNew(int color, int K)
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

            //return (int)Math.Round(interval * step + (lover ? 0 : step));
            return 0;
        }
    }
}
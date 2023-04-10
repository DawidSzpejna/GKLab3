using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using Model;
using GKLab3.Modifiers;
using FastBitmapLib;

namespace GKLab3
{
    internal class Presenter
    {
        #region Properties
        public MainForm MyMainForm { get; private set; }
        public Bitmap MyImage { get; private set; }
        public Bitmap MyModifiedImage { get; private set; }
        public Bitmap GenerateImage { get; private set; }
        public Krgb MyKrgb { get; private set; }
        public IImageModifier MyImageModifier { get; private set; }

        private PopularityAlgorithm ModifierPopularity { get; set; }
        private AverageDithering ModifierAverage { get; set; }
        private OrderedDitheringRandom ModifierDithRandom { get; set; }
        private OrderedDitheringPosition ModifierDithPosition { get; set; }
        private ErrorDiffusionDithering ModifierErrorDiff { get; set; }
        #endregion

        #region Constructors
        public Presenter(MainForm form)
        {
            MyMainForm = form;
            MyImage = new Bitmap(Image.FromFile(@"Pictures/Papy.png"));

            MyMainForm.MyFrefreshImageBt.Click += new System.EventHandler(this.FrefreshImageBt_Click);
            MyMainForm.MyUseModifiedImageBt.Click += new System.EventHandler(this.MyUseModifiedImageBt_Click);
            MyMainForm.MyLoadImageBtn.Click += new System.EventHandler(this.MyLoadImageBtnt_Click);
            MyMainForm.MyGenerateBt.Click += new System.EventHandler(this.MyGenerateBt_Click);
            MyMainForm.MyPopularityAlgBt.Click += new System.EventHandler(this.PopularityAlgBt_Click);
            MyMainForm.MyAverageDithBt.Click += new System.EventHandler(this.MyAverageDithBt_Click);
            MyMainForm.MynumericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            MyMainForm.MynumericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            MyMainForm.MynumericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            MyMainForm.MyPopularityNumber.ValueChanged += new System.EventHandler(this.PopularityNumber_ValueChanged);
            MyMainForm.MyOrderDithRndBt.Click += new System.EventHandler(this.OrderDithRndBt_Click);
            MyMainForm.MyOrderedDithPosBt.Click += new System.EventHandler(this.OrderedDithPosBt_Click);
            MyMainForm.MyErrorDiffDithBt.Click += new System.EventHandler(this.ErrorDiffDithBt_Click);
            MyMainForm.MySliderS.ValueChanged += new System.EventHandler(this.SSlider_ValueChanged);

            MyMainForm.MyBlackWhiteImageRBt.Click += new System.EventHandler(this.MyBlackWhiteImageRBt_Click);
            MyMainForm.MyColorefulImageRBt.Click += new System.EventHandler(this.MyColorefulImageRBt_Click);


            form.ShowPictureOnCurrent(MyImage);
            form.ShowPictureOnModified(MyImage);

            MyKrgb = new Krgb();
            MyKrgb.Kr = MyKrgb.Kg = MyKrgb.Kb = 2;
            MyKrgb.K = 10;
            MyKrgb.IsBlackWhite = false;

            ModifierPopularity = new PopularityAlgorithm(MyKrgb);
            ModifierAverage = new AverageDithering(MyKrgb);
            ModifierDithRandom = new OrderedDitheringRandom(MyKrgb);
            ModifierDithPosition = new OrderedDitheringPosition(MyKrgb);
            ModifierErrorDiff = new ErrorDiffusionDithering(MyKrgb);

            MyImageModifier = ModifierPopularity;
            EnableDisableNumberDownUp(NumberDUMode.PopularityAlg);

            MyModifiedImage = null;
            GenerateImage = null;
            MyMainForm.MySliderS.Value = 50;
        }
        #endregion


        #region Handlers
        private void FrefreshImageBt_Click(object sender, EventArgs e)
        {
            if (MyImage != MyModifiedImage) MyModifiedImage?.Dispose();

            MyModifiedImage = MyImage.Clone() as Bitmap;
            MyImageModifier.PleaseModifyImage(new FastBitmap(MyModifiedImage));
            MyMainForm.ShowPictureOnModified(MyModifiedImage);
        }


        private void MyUseModifiedImageBt_Click(object sender, EventArgs e)
        {
            if (MyModifiedImage != null)
            {
                MyImage.Dispose();
                MyImage = MyModifiedImage;
                MyMainForm.ShowPictureOnCurrent(MyImage);
            }
        }


        private void MyLoadImageBtnt_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + @"\Pictures";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string filePath = openFileDialog.FileName;
                    Bitmap newPic = new Bitmap(Image.FromFile(filePath));

                    MyImage.Dispose();
                    MyModifiedImage?.Dispose();
                    MyImage = newPic;
                    MyMainForm.ShowPictureOnCurrent(MyImage);
                    MyMainForm.ShowPictureOnModified(MyImage);
                }
            }
        }


        #region RadioButtons

        private void SSlider_ValueChanged(object sender, EventArgs e)
        {
            if (GenerateImage != null)
            {
                CreateHSVImage(GenerateImage);
                MyMainForm.ShowPictureOnModified(MyModifiedImage);
            }
        }

        private void CreateHSVImage(Bitmap pic)
        {
            float panding = 300;

            float S = MyMainForm.MySliderS.Value / 100f;

            float R = 250;
            float r = 0.268f * R;

            float x30 = R * 0.866f;
            float y30 = R * 0.5f;

            float x60 = R * 0.5f;
            float y60 = R * 0.866f;


            using (Graphics g = Graphics.FromImage(pic))
            {
                g.Clear(Color.White);
                g.FillEllipse(new SolidBrush(FromHSVtoRGB(0, S)), panding, panding - R, r * 2, r * 2); // 12

                g.FillEllipse(new SolidBrush(FromHSVtoRGB(30, S)), panding + x30, panding - y30, r * 2, r * 2);
                g.FillEllipse(new SolidBrush(FromHSVtoRGB(60, S)), panding + x60, panding - y60, r * 2, r * 2);

                g.FillEllipse(new SolidBrush(FromHSVtoRGB(90, S)), panding + R, panding, r * 2, r * 2); // 3

                g.FillEllipse(new SolidBrush(FromHSVtoRGB(120, S)), panding + x30, panding + y30, r * 2, r * 2);
                g.FillEllipse(new SolidBrush(FromHSVtoRGB(150, S)), panding + x60, panding + y60, r * 2, r * 2);

                g.FillEllipse(new SolidBrush(FromHSVtoRGB(180, S)), panding, panding + R, r * 2, r * 2); // 6
                ;
                g.FillEllipse(new SolidBrush(FromHSVtoRGB(210, S)), panding - x30, panding + y30, r * 2, r * 2);
                g.FillEllipse(new SolidBrush(FromHSVtoRGB(240, S)), panding - x60, panding + y60, r * 2, r * 2);

                g.FillEllipse(new SolidBrush(FromHSVtoRGB(270, S)), panding - R, panding, r * 2, r * 2); // 9

                g.FillEllipse(new SolidBrush(FromHSVtoRGB(300, S)), panding - x30, panding - y30, r * 2, r * 2);
                g.FillEllipse(new SolidBrush(FromHSVtoRGB(330, S)), panding - x60, panding - y60, r * 2, r * 2);
            }
        }

        private void MyGenerateBt_Click(object sender, EventArgs e)
        {
            Bitmap pic = new Bitmap(700, 700);
            CreateHSVImage(pic);

            MyModifiedImage = pic;
            GenerateImage = pic;
            MyMainForm.ShowPictureOnModified(MyModifiedImage);
        }

        private Color FromHSVtoRGB(int H, double S, int V = 1)
        {
            int M = 255 * V, m =(int) (M * (1 - S));
            int z = (int)((M - m) * (1 - Math.Abs(((H / 60d) % 2) - 1)));

            int R = 0;
            int G = 0;
            int B = 0;

            if (H >= 0 && H < 60)
            {
                R = M;
                G = z + m;
                B = m;
            }
            else if (H >= 60 && H < 120)
            {
                R = z + m;
                G = M;
                B = m;
            }
            else if(H >= 120 && H < 180)
            {
                R = m;
                G = M;
                B = z + m;
            }
            else if(H >= 180 && H < 240)
            {
                R = m;
                G = z + m;
                B = M;
            }
            else if(H >= 240 && H < 300)
            {
                R = z + m;
                G = m;
                B = M;
            }
            else
            {
                R = M;
                G = m;
                B = z + m;
            }

            return  Color.FromArgb(R, G, B);
        }

        private void PopularityAlgBt_Click(object sender, EventArgs e)
        {
            RadioButton btm = sender as RadioButton;
            if (btm.Checked)
            {
                EnableDisableNumberDownUp(NumberDUMode.PopularityAlg);
                MyImageModifier = ModifierPopularity;
            } 
        }

        private void MyAverageDithBt_Click(object sender, EventArgs e)
        {
            RadioButton btm = sender as RadioButton;
            if (btm.Checked)
            {
                EnableDisableNumberDownUp(NumberDUMode.Others);
                MyImageModifier = ModifierAverage;
            }
        }

        private void OrderDithRndBt_Click(object sender, EventArgs e)
        {
            RadioButton btm = sender as RadioButton;
            if (btm.Checked)
            {
                EnableDisableNumberDownUp(NumberDUMode.Others);
                MyImageModifier = ModifierDithRandom;
            }
        }

        private void OrderedDithPosBt_Click(object sender, EventArgs e)
        {
            RadioButton btm = sender as RadioButton;
            if (btm.Checked)
            {
                EnableDisableNumberDownUp(NumberDUMode.Others);
                MyImageModifier = ModifierDithPosition;
            }
        }

        private void ErrorDiffDithBt_Click(object sender, EventArgs e)
        {
            RadioButton btm = sender as RadioButton;
            if (btm.Checked)
            {
                EnableDisableNumberDownUp(NumberDUMode.Others);
                MyImageModifier = ModifierErrorDiff;
            }
        }
        #endregion

        #region NumberDownUp
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = sender as NumericUpDown;
            MyKrgb.Kr = (int)num.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = sender as NumericUpDown;
            MyKrgb.Kg = (int)num.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = sender as NumericUpDown;
            MyKrgb.Kb = (int)num.Value;
        }

        private void PopularityNumber_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = sender as NumericUpDown;
            MyKrgb.K = (int)num.Value;
        }

        private void MyBlackWhiteImageRBt_Click(object sender, EventArgs e)
        {
            RadioButton btw = sender as RadioButton;
            MyKrgb.IsBlackWhite = btw.Checked ? true : false;
        }

        private void MyColorefulImageRBt_Click(object sender, EventArgs e)
        {
            RadioButton btw = sender as RadioButton;
            MyKrgb.IsBlackWhite = btw.Checked ? false : true;
        }
        #endregion
        #endregion

        public enum NumberDUMode {PopularityAlg, Others}

        private void EnableDisableNumberDownUp(NumberDUMode mode)
        {
            if (mode == NumberDUMode.PopularityAlg)
            {
                MyMainForm.MynumericUpDown1.Enabled = false;
                MyMainForm.MynumericUpDown2.Enabled = false;
                MyMainForm.MynumericUpDown3.Enabled = false;
                MyMainForm.MyPopularityNumber.Enabled = true;
            }
            else
            {
                MyMainForm.MynumericUpDown1.Enabled = true;
                MyMainForm.MynumericUpDown2.Enabled = true;
                MyMainForm.MynumericUpDown3.Enabled = true;
                MyMainForm.MyPopularityNumber.Enabled = false;
            }
        }
    }

    internal class Krgb
    {
        public int Kr { get; set; }
        public int Kg { get; set; }
        public int Kb { get; set; }
        public int K { get; set; }
        public bool IsBlackWhite { get; set; }
    }
}

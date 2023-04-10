using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class MainForm : Form
    {
        #region Shown Canvas
        public Bitmap CanvasCurrent { get; set; }
        public Bitmap CanvasModified { get; set; }
        #endregion

        #region Controls
        public NumericUpDown MyPopularityNumber => PopularityNumber;
        public RadioButton MyPopularityAlgBt => PopularityAlgBt;
        public RadioButton MyErrorDiffDithBt => ErrorDiffDithBt;
        public RadioButton MyOrderedDithPosBt => OrderedDithPosBt;
        public RadioButton MyOrderDithRndBt => OrderDithRndBt;
        public RadioButton MyAverageDithBt => AverageDithBt;
        public RadioButton MyColorefulImageRBt => ColorefulImageRBt;
        public RadioButton MyBlackWhiteImageRBt => BlackWhiteImageRBt;
        public NumericUpDown MynumericUpDown3 => numericUpDown3;
        public NumericUpDown MynumericUpDown2 => numericUpDown2;
        public NumericUpDown MynumericUpDown1 => numericUpDown1;
        public Button MyFrefreshImageBt => FrefreshImageBt;
        public Button MyUseModifiedImageBt => UseModifiedImageBt;
        public Button MyLoadImageBtn => LoadImageBtn;
        public Button MyGenerateBt => GenerateButton;
        public TrackBar MySliderS => SSlider;
        #endregion

        #region Properties
        private Color DefaultCanvasColor { get; set; }
        #endregion

        #region Constructors
        public MainForm()
        {
            InitializeComponent();
            DefaultCanvasColor = Color.LightGray;

            CanvasCurrent = new Bitmap(PictureBoxCurrent.Width, PictureBoxCurrent.Height);
            PictureBoxCurrent.Image = CanvasCurrent;
            using (Graphics g = Graphics.FromImage(CanvasCurrent))
            {
                g.Clear(DefaultCanvasColor);
            }
            PictureBoxCurrent.Refresh();

            CanvasModified = new Bitmap(PictureBoxModified.Width, PictureBoxModified.Height);
            PictureBoxModified.Image = CanvasModified;
            using (Graphics g = Graphics.FromImage(CanvasModified))
            {
                g.Clear(DefaultCanvasColor);
            }
            PictureBoxModified.Refresh();
        }
        #endregion

        #region Common functions
        public void ShowPictureOnCurrent(Bitmap current)
        {
            (Bitmap tmp, float x, float y, bool doIt) = AdjustPic(current);

            using (Graphics g = Graphics.FromImage(CanvasCurrent))
            {
                g.Clear(DefaultCanvasColor);
                g.DrawImage(tmp, new PointF(x, y));
            }
            PictureBoxCurrent.Refresh();

            if (doIt) tmp.Dispose();
        }

        public void ShowPictureOnModified(Bitmap modified)
        {
            (Bitmap tmp, float x, float y, bool doIt) = AdjustPic(modified);

            using (Graphics g = Graphics.FromImage(CanvasModified))
            {
                g.Clear(DefaultCanvasColor);
                g.DrawImage(tmp, new PointF(x, y));
            }
            PictureBoxModified.Refresh();

            if (doIt) tmp.Dispose();
        }

        private (Bitmap, float, float, bool) AdjustPic(Bitmap map)
        {
            Bitmap tmp = map;
            bool doIt = false;

            // Adjusting Bitmap
            if (map.Width > CanvasCurrent.Width && map.Height > CanvasCurrent.Height)
            {
                tmp = new Bitmap(map, CanvasCurrent.Width, CanvasCurrent.Height);
                doIt = true;
            }
            else if (map.Width > CanvasCurrent.Width)
            {
                tmp = new Bitmap(map, CanvasCurrent.Width, map.Height);
                doIt = true;
            }
            else if (map.Height > CanvasCurrent.Height)
            {
                tmp = new Bitmap(map, map.Width, CanvasCurrent.Height);
                doIt = true;
            }

            // Counting location
            float x = (CanvasCurrent.Width - tmp.Width) / 2f;
            float y = (CanvasCurrent.Height - tmp.Height) / 2f;

            return (tmp, x, y, doIt);
        }

        #endregion
    }
}

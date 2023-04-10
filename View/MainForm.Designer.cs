namespace View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            groupBox4 = new GroupBox();
            PopularityNumber = new NumericUpDown();
            groupBox2 = new GroupBox();
            ErrorDiffDithBt = new RadioButton();
            PopularityAlgBt = new RadioButton();
            OrderedDithPosBt = new RadioButton();
            OrderDithRndBt = new RadioButton();
            AverageDithBt = new RadioButton();
            groupBox3 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            groupBox5 = new GroupBox();
            BlackWhiteImageRBt = new RadioButton();
            ColorefulImageRBt = new RadioButton();
            FrefreshImageBt = new Button();
            UseModifiedImageBt = new Button();
            LoadImageBtn = new Button();
            groupBox6 = new GroupBox();
            SSlider = new TrackBar();
            GenerateButton = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            PictureBoxModified = new PictureBox();
            PictureBoxCurrent = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PopularityNumber).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SSlider).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxModified).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxCurrent).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer1.Size = new Size(1579, 661);
            splitContainer1.SplitterDistance = 192;
            splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox3, 0, 2);
            tableLayoutPanel1.Controls.Add(groupBox5, 0, 3);
            tableLayoutPanel1.Controls.Add(FrefreshImageBt, 0, 7);
            tableLayoutPanel1.Controls.Add(UseModifiedImageBt, 0, 6);
            tableLayoutPanel1.Controls.Add(LoadImageBtn, 0, 5);
            tableLayoutPanel1.Controls.Add(groupBox6, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(192, 661);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(186, 74);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Palette of colors";
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(PopularityNumber);
            groupBox4.Location = new Point(0, 20);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(174, 49);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Params for popularity alg.";
            // 
            // PopularityNumber
            // 
            PopularityNumber.Dock = DockStyle.Fill;
            PopularityNumber.Location = new Point(3, 19);
            PopularityNumber.Maximum = new decimal(new int[] { 4000, 0, 0, 0 });
            PopularityNumber.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            PopularityNumber.Name = "PopularityNumber";
            PopularityNumber.Size = new Size(168, 23);
            PopularityNumber.TabIndex = 2;
            PopularityNumber.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ErrorDiffDithBt);
            groupBox2.Controls.Add(PopularityAlgBt);
            groupBox2.Controls.Add(OrderedDithPosBt);
            groupBox2.Controls.Add(OrderDithRndBt);
            groupBox2.Controls.Add(AverageDithBt);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 83);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(186, 144);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Reducing colors";
            // 
            // ErrorDiffDithBt
            // 
            ErrorDiffDithBt.AutoSize = true;
            ErrorDiffDithBt.Location = new Point(9, 119);
            ErrorDiffDithBt.Name = "ErrorDiffDithBt";
            ErrorDiffDithBt.Size = new Size(151, 19);
            ErrorDiffDithBt.TabIndex = 3;
            ErrorDiffDithBt.TabStop = true;
            ErrorDiffDithBt.Text = "Error diffusion dithering";
            ErrorDiffDithBt.UseVisualStyleBackColor = true;
            // 
            // PopularityAlgBt
            // 
            PopularityAlgBt.AutoSize = true;
            PopularityAlgBt.Checked = true;
            PopularityAlgBt.Location = new Point(9, 19);
            PopularityAlgBt.Name = "PopularityAlgBt";
            PopularityAlgBt.Size = new Size(136, 19);
            PopularityAlgBt.TabIndex = 0;
            PopularityAlgBt.TabStop = true;
            PopularityAlgBt.Text = "Popularity Algorithm";
            PopularityAlgBt.UseVisualStyleBackColor = true;
            // 
            // OrderedDithPosBt
            // 
            OrderedDithPosBt.AutoSize = true;
            OrderedDithPosBt.Location = new Point(9, 94);
            OrderedDithPosBt.Name = "OrderedDithPosBt";
            OrderedDithPosBt.Size = new Size(165, 19);
            OrderedDithPosBt.TabIndex = 2;
            OrderedDithPosBt.TabStop = true;
            OrderedDithPosBt.Text = "Ordered dithering position";
            OrderedDithPosBt.UseVisualStyleBackColor = true;
            // 
            // OrderDithRndBt
            // 
            OrderDithRndBt.AutoSize = true;
            OrderDithRndBt.Location = new Point(9, 69);
            OrderDithRndBt.Name = "OrderDithRndBt";
            OrderDithRndBt.Size = new Size(164, 19);
            OrderDithRndBt.TabIndex = 1;
            OrderDithRndBt.TabStop = true;
            OrderDithRndBt.Text = "Ordered dithering random";
            OrderDithRndBt.UseVisualStyleBackColor = true;
            // 
            // AverageDithBt
            // 
            AverageDithBt.AutoSize = true;
            AverageDithBt.Location = new Point(9, 44);
            AverageDithBt.Name = "AverageDithBt";
            AverageDithBt.Size = new Size(119, 19);
            AverageDithBt.TabIndex = 0;
            AverageDithBt.TabStop = true;
            AverageDithBt.Text = "Average dithering";
            AverageDithBt.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(numericUpDown3);
            groupBox3.Controls.Add(numericUpDown2);
            groupBox3.Controls.Add(numericUpDown1);
            groupBox3.Controls.Add(label1);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 233);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(186, 134);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Factores";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 107);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 5;
            label3.Text = "Kb";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 64);
            label2.Name = "label2";
            label2.Size = new Size(21, 15);
            label2.TabIndex = 4;
            label2.Text = "Kg";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(52, 105);
            numericUpDown3.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDown3.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(120, 23);
            numericUpDown3.TabIndex = 2;
            numericUpDown3.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(52, 64);
            numericUpDown2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 1;
            numericUpDown2.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.None;
            numericUpDown1.Location = new Point(51, 22);
            numericUpDown1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 0;
            numericUpDown1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 22);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 3;
            label1.Text = "Kr";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(BlackWhiteImageRBt);
            groupBox5.Controls.Add(ColorefulImageRBt);
            groupBox5.Location = new Point(3, 373);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(186, 74);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "Image type";
            // 
            // BlackWhiteImageRBt
            // 
            BlackWhiteImageRBt.AutoSize = true;
            BlackWhiteImageRBt.Location = new Point(9, 47);
            BlackWhiteImageRBt.Name = "BlackWhiteImageRBt";
            BlackWhiteImageRBt.Size = new Size(125, 19);
            BlackWhiteImageRBt.TabIndex = 0;
            BlackWhiteImageRBt.Text = "Black-White Image";
            BlackWhiteImageRBt.UseVisualStyleBackColor = true;
            // 
            // ColorefulImageRBt
            // 
            ColorefulImageRBt.AutoSize = true;
            ColorefulImageRBt.Checked = true;
            ColorefulImageRBt.Location = new Point(9, 22);
            ColorefulImageRBt.Name = "ColorefulImageRBt";
            ColorefulImageRBt.Size = new Size(110, 19);
            ColorefulImageRBt.TabIndex = 1;
            ColorefulImageRBt.TabStop = true;
            ColorefulImageRBt.Text = "Coloreful Image";
            ColorefulImageRBt.UseVisualStyleBackColor = true;
            // 
            // FrefreshImageBt
            // 
            FrefreshImageBt.Location = new Point(3, 614);
            FrefreshImageBt.Name = "FrefreshImageBt";
            FrefreshImageBt.Size = new Size(186, 44);
            FrefreshImageBt.TabIndex = 3;
            FrefreshImageBt.Text = "Refresh Image";
            FrefreshImageBt.UseVisualStyleBackColor = true;
            // 
            // UseModifiedImageBt
            // 
            UseModifiedImageBt.Location = new Point(3, 574);
            UseModifiedImageBt.Name = "UseModifiedImageBt";
            UseModifiedImageBt.Size = new Size(186, 34);
            UseModifiedImageBt.TabIndex = 5;
            UseModifiedImageBt.Text = "Use Modified Image";
            UseModifiedImageBt.UseVisualStyleBackColor = true;
            // 
            // LoadImageBtn
            // 
            LoadImageBtn.Location = new Point(3, 534);
            LoadImageBtn.Name = "LoadImageBtn";
            LoadImageBtn.Size = new Size(186, 34);
            LoadImageBtn.TabIndex = 4;
            LoadImageBtn.Text = "Load Image";
            LoadImageBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(SSlider);
            groupBox6.Controls.Add(GenerateButton);
            groupBox6.Location = new Point(3, 452);
            groupBox6.Margin = new Padding(3, 2, 3, 2);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(3, 2, 3, 2);
            groupBox6.Size = new Size(186, 76);
            groupBox6.TabIndex = 7;
            groupBox6.TabStop = false;
            groupBox6.Text = "HSV";
            // 
            // SSlider
            // 
            SSlider.Location = new Point(9, 48);
            SSlider.Margin = new Padding(3, 2, 3, 2);
            SSlider.Maximum = 100;
            SSlider.Minimum = 1;
            SSlider.Name = "SSlider";
            SSlider.Size = new Size(174, 45);
            SSlider.TabIndex = 1;
            SSlider.Value = 1;
            // 
            // GenerateButton
            // 
            GenerateButton.Location = new Point(5, 20);
            GenerateButton.Margin = new Padding(3, 2, 3, 2);
            GenerateButton.Name = "GenerateButton";
            GenerateButton.Size = new Size(178, 22);
            GenerateButton.TabIndex = 0;
            GenerateButton.Text = "Generate";
            GenerateButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(PictureBoxModified, 1, 0);
            tableLayoutPanel2.Controls.Add(PictureBoxCurrent, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1383, 661);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // PictureBoxModified
            // 
            PictureBoxModified.Dock = DockStyle.Fill;
            PictureBoxModified.Location = new Point(694, 3);
            PictureBoxModified.Name = "PictureBoxModified";
            PictureBoxModified.Size = new Size(686, 655);
            PictureBoxModified.TabIndex = 1;
            PictureBoxModified.TabStop = false;
            // 
            // PictureBoxCurrent
            // 
            PictureBoxCurrent.Dock = DockStyle.Fill;
            PictureBoxCurrent.Location = new Point(3, 3);
            PictureBoxCurrent.MinimumSize = new Size(256, 256);
            PictureBoxCurrent.Name = "PictureBoxCurrent";
            PictureBoxCurrent.Size = new Size(685, 655);
            PictureBoxCurrent.TabIndex = 0;
            PictureBoxCurrent.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1579, 661);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(816, 487);
            Name = "MainForm";
            Text = "MainForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PopularityNumber).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SSlider).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureBoxModified).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxCurrent).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private NumericUpDown PopularityNumber;
        private RadioButton PopularityAlgBt;
        private GroupBox groupBox2;
        private RadioButton ErrorDiffDithBt;
        private RadioButton OrderedDithPosBt;
        private RadioButton OrderDithRndBt;
        private RadioButton AverageDithBt;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private Label label3;
        private Label label2;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Button FrefreshImageBt;
        private TableLayoutPanel tableLayoutPanel2;
        private PictureBox PictureBoxCurrent;
        private PictureBox PictureBoxModified;
        private Button LoadImageBtn;
        private Button UseModifiedImageBt;
        private GroupBox groupBox5;
        private RadioButton BlackWhiteImageRBt;
        private RadioButton ColorefulImageRBt;
        private GroupBox groupBox6;
        private Button GenerateButton;
        private TrackBar SSlider;
    }
}
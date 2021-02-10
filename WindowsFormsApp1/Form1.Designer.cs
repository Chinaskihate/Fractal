namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.fractalsBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxFract = new System.Windows.Forms.PictureBox();
            this.trackBarAlpha = new System.Windows.Forms.TrackBar();
            this.labelAlpha = new System.Windows.Forms.Label();
            this.labelDepth = new System.Windows.Forms.Label();
            this.trackBarSteps = new System.Windows.Forms.TrackBar();
            this.labelLength = new System.Windows.Forms.Label();
            this.trackBarLength = new System.Windows.Forms.TrackBar();
            this.trackBarLeftAngle = new System.Windows.Forms.TrackBar();
            this.labelLeftAngle = new System.Windows.Forms.Label();
            this.labelRightAngle = new System.Windows.Forms.Label();
            this.trackBarRightAngle = new System.Windows.Forms.TrackBar();
            this.labelRatio = new System.Windows.Forms.Label();
            this.trackBarRatio = new System.Windows.Forms.TrackBar();
            this.labelZoom = new System.Windows.Forms.Label();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.buttonStartColor = new System.Windows.Forms.Button();
            this.buttonEndColor = new System.Windows.Forms.Button();
            this.buttonBackGroundColor = new System.Windows.Forms.Button();
            this.labelWidth = new System.Windows.Forms.Label();
            this.trackBarWidth = new System.Windows.Forms.TrackBar();
            this.buttonSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSteps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLeftAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRightAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Типы фракталов:";
            // 
            // fractalsBox
            // 
            this.fractalsBox.FormattingEnabled = true;
            this.fractalsBox.ItemHeight = 17;
            this.fractalsBox.Location = new System.Drawing.Point(13, 28);
            this.fractalsBox.Name = "fractalsBox";
            this.fractalsBox.Size = new System.Drawing.Size(234, 106);
            this.fractalsBox.TabIndex = 1;
            this.fractalsBox.SelectedIndexChanged += new System.EventHandler(this.fractalsBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBoxFract);
            this.panel1.Location = new System.Drawing.Point(334, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 1049);
            this.panel1.TabIndex = 2;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // pictureBoxFract
            // 
            this.pictureBoxFract.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFract.Name = "pictureBoxFract";
            this.pictureBoxFract.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxFract.TabIndex = 0;
            this.pictureBoxFract.TabStop = false;
            // 
            // trackBarAlpha
            // 
            this.trackBarAlpha.Location = new System.Drawing.Point(12, 157);
            this.trackBarAlpha.Maximum = 255;
            this.trackBarAlpha.Name = "trackBarAlpha";
            this.trackBarAlpha.Size = new System.Drawing.Size(234, 56);
            this.trackBarAlpha.TabIndex = 3;
            this.trackBarAlpha.Scroll += new System.EventHandler(this.trackBarAlpha_Scroll);
            // 
            // labelAlpha
            // 
            this.labelAlpha.AutoSize = true;
            this.labelAlpha.Location = new System.Drawing.Point(12, 137);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(98, 17);
            this.labelAlpha.TabIndex = 4;
            this.labelAlpha.Text = "Прозрачность:";
            // 
            // labelDepth
            // 
            this.labelDepth.AutoSize = true;
            this.labelDepth.Location = new System.Drawing.Point(13, 185);
            this.labelDepth.Name = "labelDepth";
            this.labelDepth.Size = new System.Drawing.Size(122, 17);
            this.labelDepth.TabIndex = 5;
            this.labelDepth.Text = "Глубина рекурсии:";
            // 
            // trackBarSteps
            // 
            this.trackBarSteps.Location = new System.Drawing.Point(12, 199);
            this.trackBarSteps.Minimum = 1;
            this.trackBarSteps.Name = "trackBarSteps";
            this.trackBarSteps.Size = new System.Drawing.Size(234, 56);
            this.trackBarSteps.TabIndex = 6;
            this.trackBarSteps.Value = 3;
            this.trackBarSteps.Scroll += new System.EventHandler(this.trackBarSteps_Scroll);
            // 
            // labelLength
            // 
            this.labelLength.AutoSize = true;
            this.labelLength.Location = new System.Drawing.Point(13, 227);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(89, 17);
            this.labelLength.TabIndex = 7;
            this.labelLength.Text = "Длина фигур:";
            // 
            // trackBarLength
            // 
            this.trackBarLength.Location = new System.Drawing.Point(11, 247);
            this.trackBarLength.Maximum = 400;
            this.trackBarLength.Minimum = 10;
            this.trackBarLength.Name = "trackBarLength";
            this.trackBarLength.Size = new System.Drawing.Size(235, 56);
            this.trackBarLength.TabIndex = 8;
            this.trackBarLength.Value = 10;
            this.trackBarLength.Scroll += new System.EventHandler(this.trackBarLength_Scroll);
            // 
            // trackBarLeftAngle
            // 
            this.trackBarLeftAngle.Location = new System.Drawing.Point(11, 538);
            this.trackBarLeftAngle.Maximum = 90;
            this.trackBarLeftAngle.Minimum = 10;
            this.trackBarLeftAngle.Name = "trackBarLeftAngle";
            this.trackBarLeftAngle.Size = new System.Drawing.Size(234, 56);
            this.trackBarLeftAngle.TabIndex = 9;
            this.trackBarLeftAngle.Value = 10;
            this.trackBarLeftAngle.Scroll += new System.EventHandler(this.trackBarLeftAngle_Scroll);
            // 
            // labelLeftAngle
            // 
            this.labelLeftAngle.AutoSize = true;
            this.labelLeftAngle.Location = new System.Drawing.Point(13, 518);
            this.labelLeftAngle.Name = "labelLeftAngle";
            this.labelLeftAngle.Size = new System.Drawing.Size(133, 17);
            this.labelLeftAngle.TabIndex = 10;
            this.labelLeftAngle.Text = "Левый угол наклона";
            // 
            // labelRightAngle
            // 
            this.labelRightAngle.AutoSize = true;
            this.labelRightAngle.Location = new System.Drawing.Point(13, 577);
            this.labelRightAngle.Name = "labelRightAngle";
            this.labelRightAngle.Size = new System.Drawing.Size(141, 17);
            this.labelRightAngle.TabIndex = 11;
            this.labelRightAngle.Text = "Правый угол наклона";
            // 
            // trackBarRightAngle
            // 
            this.trackBarRightAngle.Location = new System.Drawing.Point(13, 600);
            this.trackBarRightAngle.Maximum = 90;
            this.trackBarRightAngle.Minimum = 10;
            this.trackBarRightAngle.Name = "trackBarRightAngle";
            this.trackBarRightAngle.Size = new System.Drawing.Size(234, 56);
            this.trackBarRightAngle.TabIndex = 12;
            this.trackBarRightAngle.Value = 10;
            this.trackBarRightAngle.Scroll += new System.EventHandler(this.trackBarRightAngle_Scroll);
            // 
            // labelRatio
            // 
            this.labelRatio.AutoSize = true;
            this.labelRatio.Location = new System.Drawing.Point(13, 275);
            this.labelRatio.Name = "labelRatio";
            this.labelRatio.Size = new System.Drawing.Size(152, 17);
            this.labelRatio.TabIndex = 13;
            this.labelRatio.Text = "Отношение длин фигур";
            // 
            // trackBarRatio
            // 
            this.trackBarRatio.Location = new System.Drawing.Point(13, 295);
            this.trackBarRatio.Maximum = 150;
            this.trackBarRatio.Name = "trackBarRatio";
            this.trackBarRatio.Size = new System.Drawing.Size(234, 56);
            this.trackBarRatio.TabIndex = 14;
            this.trackBarRatio.Scroll += new System.EventHandler(this.trackBarRatio_Scroll);
            // 
            // labelZoom
            // 
            this.labelZoom.AutoSize = true;
            this.labelZoom.Location = new System.Drawing.Point(13, 323);
            this.labelZoom.Name = "labelZoom";
            this.labelZoom.Size = new System.Drawing.Size(33, 17);
            this.labelZoom.TabIndex = 15;
            this.labelZoom.Text = "Зум";
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.Location = new System.Drawing.Point(11, 343);
            this.trackBarZoom.Maximum = 900;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(234, 56);
            this.trackBarZoom.TabIndex = 16;
            this.trackBarZoom.Scroll += new System.EventHandler(this.trackBarZoom_Scroll);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.Location = new System.Drawing.Point(255, 1065);
            this.hScrollBar1.Maximum = 500;
            this.hScrollBar1.Minimum = -500;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(471, 21);
            this.hScrollBar1.TabIndex = 17;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Location = new System.Drawing.Point(703, 12);
            this.vScrollBar1.Maximum = 500;
            this.vScrollBar1.Minimum = -500;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(24, 1049);
            this.vScrollBar1.TabIndex = 18;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // buttonStartColor
            // 
            this.buttonStartColor.Location = new System.Drawing.Point(20, 442);
            this.buttonStartColor.Name = "buttonStartColor";
            this.buttonStartColor.Size = new System.Drawing.Size(90, 28);
            this.buttonStartColor.TabIndex = 19;
            this.buttonStartColor.Text = "StartColor";
            this.buttonStartColor.UseVisualStyleBackColor = true;
            this.buttonStartColor.Click += new System.EventHandler(this.buttonStartColor_Click);
            // 
            // buttonEndColor
            // 
            this.buttonEndColor.Location = new System.Drawing.Point(165, 442);
            this.buttonEndColor.Name = "buttonEndColor";
            this.buttonEndColor.Size = new System.Drawing.Size(80, 28);
            this.buttonEndColor.TabIndex = 20;
            this.buttonEndColor.Text = "EndColor";
            this.buttonEndColor.UseVisualStyleBackColor = true;
            this.buttonEndColor.Click += new System.EventHandler(this.buttonEndColor_Click);
            // 
            // buttonBackGroundColor
            // 
            this.buttonBackGroundColor.Location = new System.Drawing.Point(60, 476);
            this.buttonBackGroundColor.Name = "buttonBackGroundColor";
            this.buttonBackGroundColor.Size = new System.Drawing.Size(158, 29);
            this.buttonBackGroundColor.TabIndex = 21;
            this.buttonBackGroundColor.Text = "BackGroundColor";
            this.buttonBackGroundColor.UseVisualStyleBackColor = true;
            this.buttonBackGroundColor.Click += new System.EventHandler(this.buttonBackGroundColor_Click);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(13, 382);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(102, 17);
            this.labelWidth.TabIndex = 22;
            this.labelWidth.Text = "Толщина фигур";
            // 
            // trackBarWidth
            // 
            this.trackBarWidth.Location = new System.Drawing.Point(20, 402);
            this.trackBarWidth.Minimum = 1;
            this.trackBarWidth.Name = "trackBarWidth";
            this.trackBarWidth.Size = new System.Drawing.Size(232, 56);
            this.trackBarWidth.TabIndex = 23;
            this.trackBarWidth.Value = 1;
            this.trackBarWidth.Scroll += new System.EventHandler(this.trackBarWidth_Scroll);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(253, 33);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 29);
            this.buttonSave.TabIndex = 24;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "*.jpg | *.jpg";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 1095);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.trackBarWidth);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.buttonBackGroundColor);
            this.Controls.Add(this.buttonEndColor);
            this.Controls.Add(this.trackBarRightAngle);
            this.Controls.Add(this.trackBarLeftAngle);
            this.Controls.Add(this.labelRightAngle);
            this.Controls.Add(this.buttonStartColor);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.labelLeftAngle);
            this.Controls.Add(this.trackBarZoom);
            this.Controls.Add(this.labelZoom);
            this.Controls.Add(this.trackBarRatio);
            this.Controls.Add(this.labelRatio);
            this.Controls.Add(this.trackBarLength);
            this.Controls.Add(this.labelLength);
            this.Controls.Add(this.trackBarSteps);
            this.Controls.Add(this.labelDepth);
            this.Controls.Add(this.labelAlpha);
            this.Controls.Add(this.trackBarAlpha);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fractalsBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "Form1";
            this.Text = "Зум";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSteps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLeftAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRightAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox fractalsBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxFract;
        private System.Windows.Forms.TrackBar trackBarAlpha;
        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.Label labelDepth;
        private System.Windows.Forms.TrackBar trackBarSteps;
        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.TrackBar trackBarLength;
        private System.Windows.Forms.TrackBar trackBarLeftAngle;
        private System.Windows.Forms.Label labelLeftAngle;
        private System.Windows.Forms.Label labelRightAngle;
        private System.Windows.Forms.TrackBar trackBarRightAngle;
        private System.Windows.Forms.Label labelRatio;
        private System.Windows.Forms.TrackBar trackBarRatio;
        private System.Windows.Forms.Label labelZoom;
        private System.Windows.Forms.TrackBar trackBarZoom;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button buttonStartColor;
        private System.Windows.Forms.Button buttonEndColor;
        private System.Windows.Forms.Button buttonBackGroundColor;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.TrackBar trackBarWidth;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}


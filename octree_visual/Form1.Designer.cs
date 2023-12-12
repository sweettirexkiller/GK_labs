namespace octree_visual
{
    partial class Form1
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
            this.originalPictureGroupBox = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.originalNumberOfColors = new System.Windows.Forms.Label();
            this.numOfColorsLabel = new System.Windows.Forms.Label();
            this.loadPictureButton = new System.Windows.Forms.Button();
            this.originalPictureBox = new System.Windows.Forms.PictureBox();
            this.reduceButton = new System.Windows.Forms.Button();
            this.reducedPictureGroupBox = new System.Windows.Forms.GroupBox();
            this.reduceNumber = new System.Windows.Forms.NumericUpDown();
            this.reducedNumberOfColors = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reducedPictureBox = new System.Windows.Forms.PictureBox();
            this.octreeGroupBox = new System.Windows.Forms.GroupBox();
            this.octreePictureBox = new System.Windows.Forms.PictureBox();
            this.originalPictureGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
            this.reducedPictureGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reduceNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reducedPictureBox)).BeginInit();
            this.octreeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.octreePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // originalPictureGroupBox
            // 
            this.originalPictureGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.originalPictureGroupBox.Controls.Add(this.button2);
            this.originalPictureGroupBox.Controls.Add(this.button1);
            this.originalPictureGroupBox.Controls.Add(this.originalNumberOfColors);
            this.originalPictureGroupBox.Controls.Add(this.numOfColorsLabel);
            this.originalPictureGroupBox.Controls.Add(this.loadPictureButton);
            this.originalPictureGroupBox.Controls.Add(this.originalPictureBox);
            this.originalPictureGroupBox.Location = new System.Drawing.Point(12, 12);
            this.originalPictureGroupBox.Name = "originalPictureGroupBox";
            this.originalPictureGroupBox.Size = new System.Drawing.Size(671, 494);
            this.originalPictureGroupBox.TabIndex = 0;
            this.originalPictureGroupBox.TabStop = false;
            this.originalPictureGroupBox.Text = "Original Picture";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(420, 362);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "Generate 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "Generate 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // originalNumberOfColors
            // 
            this.originalNumberOfColors.Location = new System.Drawing.Point(214, 437);
            this.originalNumberOfColors.Name = "originalNumberOfColors";
            this.originalNumberOfColors.Size = new System.Drawing.Size(125, 28);
            this.originalNumberOfColors.TabIndex = 3;
            this.originalNumberOfColors.Text = "0";
            // 
            // numOfColorsLabel
            // 
            this.numOfColorsLabel.Location = new System.Drawing.Point(19, 437);
            this.numOfColorsLabel.Name = "numOfColorsLabel";
            this.numOfColorsLabel.Size = new System.Drawing.Size(214, 28);
            this.numOfColorsLabel.TabIndex = 2;
            this.numOfColorsLabel.Text = "Number of colors:";
            // 
            // loadPictureButton
            // 
            this.loadPictureButton.Location = new System.Drawing.Point(6, 358);
            this.loadPictureButton.Name = "loadPictureButton";
            this.loadPictureButton.Size = new System.Drawing.Size(152, 46);
            this.loadPictureButton.TabIndex = 1;
            this.loadPictureButton.Text = "Load Picture";
            this.loadPictureButton.UseVisualStyleBackColor = true;
            this.loadPictureButton.Click += new System.EventHandler(this.loadPictureButton_Click);
            // 
            // originalPictureBox
            // 
            this.originalPictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.originalPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalPictureBox.Location = new System.Drawing.Point(6, 30);
            this.originalPictureBox.Name = "originalPictureBox";
            this.originalPictureBox.Size = new System.Drawing.Size(308, 308);
            this.originalPictureBox.TabIndex = 0;
            this.originalPictureBox.TabStop = false;
            // 
            // reduceButton
            // 
            this.reduceButton.Location = new System.Drawing.Point(312, 20);
            this.reduceButton.Name = "reduceButton";
            this.reduceButton.Size = new System.Drawing.Size(196, 52);
            this.reduceButton.TabIndex = 4;
            this.reduceButton.Text = "Reduce by:";
            this.reduceButton.UseVisualStyleBackColor = true;
            this.reduceButton.Click += new System.EventHandler(this.reduceButton_Click);
            // 
            // reducedPictureGroupBox
            // 
            this.reducedPictureGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.reducedPictureGroupBox.Controls.Add(this.reduceNumber);
            this.reducedPictureGroupBox.Controls.Add(this.reduceButton);
            this.reducedPictureGroupBox.Controls.Add(this.reducedNumberOfColors);
            this.reducedPictureGroupBox.Controls.Add(this.label1);
            this.reducedPictureGroupBox.Controls.Add(this.reducedPictureBox);
            this.reducedPictureGroupBox.Location = new System.Drawing.Point(12, 712);
            this.reducedPictureGroupBox.Name = "reducedPictureGroupBox";
            this.reducedPictureGroupBox.Size = new System.Drawing.Size(677, 669);
            this.reducedPictureGroupBox.TabIndex = 1;
            this.reducedPictureGroupBox.TabStop = false;
            this.reducedPictureGroupBox.Text = "Reduced Picture";
            // 
            // reduceNumber
            // 
            this.reduceNumber.Location = new System.Drawing.Point(514, 32);
            this.reduceNumber.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.reduceNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.reduceNumber.Name = "reduceNumber";
            this.reduceNumber.Size = new System.Drawing.Size(82, 31);
            this.reduceNumber.TabIndex = 7;
            this.reduceNumber.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // reducedNumberOfColors
            // 
            this.reducedNumberOfColors.Location = new System.Drawing.Point(265, 44);
            this.reducedNumberOfColors.Name = "reducedNumberOfColors";
            this.reducedNumberOfColors.Size = new System.Drawing.Size(125, 28);
            this.reducedNumberOfColors.TabIndex = 6;
            this.reducedNumberOfColors.Text = "0";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Current number of colors: ";
            // 
            // reducedPictureBox
            // 
            this.reducedPictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.reducedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reducedPictureBox.Location = new System.Drawing.Point(6, 104);
            this.reducedPictureBox.Name = "reducedPictureBox";
            this.reducedPictureBox.Size = new System.Drawing.Size(585, 538);
            this.reducedPictureBox.TabIndex = 0;
            this.reducedPictureBox.TabStop = false;
            // 
            // octreeGroupBox
            // 
            this.octreeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.octreeGroupBox.Controls.Add(this.octreePictureBox);
            this.octreeGroupBox.Location = new System.Drawing.Point(689, 12);
            this.octreeGroupBox.Name = "octreeGroupBox";
            this.octreeGroupBox.Size = new System.Drawing.Size(847, 1369);
            this.octreeGroupBox.TabIndex = 2;
            this.octreeGroupBox.TabStop = false;
            this.octreeGroupBox.Text = "Octree";
            // 
            // octreePictureBox
            // 
            this.octreePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.octreePictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.octreePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.octreePictureBox.Location = new System.Drawing.Point(6, 30);
            this.octreePictureBox.Name = "octreePictureBox";
            this.octreePictureBox.Size = new System.Drawing.Size(835, 1124);
            this.octreePictureBox.TabIndex = 0;
            this.octreePictureBox.TabStop = false;
            this.octreePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.octreePictureBox_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1548, 1649);
            this.Controls.Add(this.octreeGroupBox);
            this.Controls.Add(this.reducedPictureGroupBox);
            this.Controls.Add(this.originalPictureGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Octree Color Reduction Visualization";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.originalPictureGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
            this.reducedPictureGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reduceNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reducedPictureBox)).EndInit();
            this.octreeGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.octreePictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.NumericUpDown reduceNumber;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label reducedNumberOfColors;

        private System.Windows.Forms.Button reduceButton;

        private System.Windows.Forms.Label numOfColorsLabel;
        private System.Windows.Forms.Label originalNumberOfColors;

        private System.Windows.Forms.PictureBox octreePictureBox;

        private System.Windows.Forms.PictureBox reducedPictureBox;
        private System.Windows.Forms.Button loadPictureButton;

        private System.Windows.Forms.GroupBox octreeGroupBox;
        private System.Windows.Forms.PictureBox originalPictureBox;

        private System.Windows.Forms.GroupBox originalPictureGroupBox;
        private System.Windows.Forms.GroupBox reducedPictureGroupBox;

        #endregion
    }
}
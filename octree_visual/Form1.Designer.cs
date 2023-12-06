﻿namespace octree_visual
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
            this.numberOfColors = new System.Windows.Forms.Label();
            this.numOfColorsLabel = new System.Windows.Forms.Label();
            this.loadPictureButton = new System.Windows.Forms.Button();
            this.originalPictureBox = new System.Windows.Forms.PictureBox();
            this.reducedPictureGroupBox = new System.Windows.Forms.GroupBox();
            this.reducedPictureBox = new System.Windows.Forms.PictureBox();
            this.octreeGroupBox = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGroupBox = new System.Windows.Forms.GroupBox();
            this.originalPictureGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
            this.reducedPictureGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reducedPictureBox)).BeginInit();
            this.octreeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // originalPictureGroupBox
            // 
            this.originalPictureGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.originalPictureGroupBox.Controls.Add(this.numberOfColors);
            this.originalPictureGroupBox.Controls.Add(this.numOfColorsLabel);
            this.originalPictureGroupBox.Controls.Add(this.loadPictureButton);
            this.originalPictureGroupBox.Controls.Add(this.originalPictureBox);
            this.originalPictureGroupBox.Location = new System.Drawing.Point(12, 12);
            this.originalPictureGroupBox.Name = "originalPictureGroupBox";
            this.originalPictureGroupBox.Size = new System.Drawing.Size(724, 399);
            this.originalPictureGroupBox.TabIndex = 0;
            this.originalPictureGroupBox.TabStop = false;
            this.originalPictureGroupBox.Text = "Original Picture";
            // 
            // numberOfColors
            // 
            this.numberOfColors.Location = new System.Drawing.Point(437, 128);
            this.numberOfColors.Name = "numberOfColors";
            this.numberOfColors.Size = new System.Drawing.Size(100, 23);
            this.numberOfColors.TabIndex = 3;
            this.numberOfColors.Text = "0";
            // 
            // numOfColorsLabel
            // 
            this.numOfColorsLabel.Location = new System.Drawing.Point(235, 123);
            this.numOfColorsLabel.Name = "numOfColorsLabel";
            this.numOfColorsLabel.Size = new System.Drawing.Size(214, 28);
            this.numOfColorsLabel.TabIndex = 2;
            this.numOfColorsLabel.Text = "Number of colors:";
            // 
            // loadPictureButton
            // 
            this.loadPictureButton.Location = new System.Drawing.Point(229, 42);
            this.loadPictureButton.Name = "loadPictureButton";
            this.loadPictureButton.Size = new System.Drawing.Size(152, 46);
            this.loadPictureButton.TabIndex = 1;
            this.loadPictureButton.Text = "Load Picture";
            this.loadPictureButton.UseVisualStyleBackColor = true;
            // 
            // originalPictureBox
            // 
            this.originalPictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.originalPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalPictureBox.Location = new System.Drawing.Point(6, 30);
            this.originalPictureBox.Name = "originalPictureBox";
            this.originalPictureBox.Size = new System.Drawing.Size(190, 176);
            this.originalPictureBox.TabIndex = 0;
            this.originalPictureBox.TabStop = false;
            // 
            // reducedPictureGroupBox
            // 
            this.reducedPictureGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.reducedPictureGroupBox.Controls.Add(this.reducedPictureBox);
            this.reducedPictureGroupBox.Location = new System.Drawing.Point(12, 417);
            this.reducedPictureGroupBox.Name = "reducedPictureGroupBox";
            this.reducedPictureGroupBox.Size = new System.Drawing.Size(724, 690);
            this.reducedPictureGroupBox.TabIndex = 1;
            this.reducedPictureGroupBox.TabStop = false;
            this.reducedPictureGroupBox.Text = "Reduced Picture";
            // 
            // reducedPictureBox
            // 
            this.reducedPictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.reducedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reducedPictureBox.Location = new System.Drawing.Point(6, 30);
            this.reducedPictureBox.Name = "reducedPictureBox";
            this.reducedPictureBox.Size = new System.Drawing.Size(202, 199);
            this.reducedPictureBox.TabIndex = 0;
            this.reducedPictureBox.TabStop = false;
            // 
            // octreeGroupBox
            // 
            this.octreeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.octreeGroupBox.Controls.Add(this.pictureBox1);
            this.octreeGroupBox.Location = new System.Drawing.Point(742, 12);
            this.octreeGroupBox.Name = "octreeGroupBox";
            this.octreeGroupBox.Size = new System.Drawing.Size(930, 626);
            this.octreeGroupBox.TabIndex = 2;
            this.octreeGroupBox.TabStop = false;
            this.octreeGroupBox.Text = "Octree";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(6, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(918, 548);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dataGroupBox
            // 
            this.dataGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGroupBox.Location = new System.Drawing.Point(742, 596);
            this.dataGroupBox.Name = "dataGroupBox";
            this.dataGroupBox.Size = new System.Drawing.Size(930, 511);
            this.dataGroupBox.TabIndex = 3;
            this.dataGroupBox.TabStop = false;
            this.dataGroupBox.Text = "Octree Data";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1684, 1119);
            this.Controls.Add(this.dataGroupBox);
            this.Controls.Add(this.octreeGroupBox);
            this.Controls.Add(this.reducedPictureGroupBox);
            this.Controls.Add(this.originalPictureGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Octree Color Reduction Visualization";
            this.originalPictureGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
            this.reducedPictureGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reducedPictureBox)).EndInit();
            this.octreeGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label numOfColorsLabel;
        private System.Windows.Forms.Label numberOfColors;

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox dataGroupBox;

        private System.Windows.Forms.PictureBox reducedPictureBox;
        private System.Windows.Forms.Button loadPictureButton;

        private System.Windows.Forms.GroupBox octreeGroupBox;
        private System.Windows.Forms.PictureBox originalPictureBox;

        private System.Windows.Forms.GroupBox originalPictureGroupBox;
        private System.Windows.Forms.GroupBox reducedPictureGroupBox;

        #endregion
    }
}
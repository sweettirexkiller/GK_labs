using System.ComponentModel;

namespace polygon_editor
{
    partial class LineForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.thicknessBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessBar)).BeginInit();
            this.SuspendLayout();
            // 
            // thicknessBar
            // 
            this.thicknessBar.LargeChange = 2;
            this.thicknessBar.Location = new System.Drawing.Point(123, 95);
            this.thicknessBar.Maximum = 5;
            this.thicknessBar.Name = "thicknessBar";
            this.thicknessBar.Size = new System.Drawing.Size(374, 90);
            this.thicknessBar.TabIndex = 0;
            this.thicknessBar.Scroll += new System.EventHandler(this.thicknessBar_Scroll);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(174, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Line Thickness";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(513, 325);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(207, 67);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // LineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.thicknessBar);
            this.Name = "LineForm";
            this.Text = "LineForm";
            ((System.ComponentModel.ISupportInitialize)(this.thicknessBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TrackBar thicknessBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okBtn;

        #endregion
    }
}
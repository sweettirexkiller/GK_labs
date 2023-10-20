namespace polygon_editor
{
    partial class EditorForm
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
            this.EditorPictureBox = new System.Windows.Forms.PictureBox();
            this.MovingMouseLabel = new System.Windows.Forms.Label();
            this.addPolygonButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EditorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // EditorPictureBox
            // 
            this.EditorPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.EditorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditorPictureBox.Location = new System.Drawing.Point(482, 12);
            this.EditorPictureBox.Name = "EditorPictureBox";
            this.EditorPictureBox.Size = new System.Drawing.Size(1208, 1112);
            this.EditorPictureBox.TabIndex = 4;
            this.EditorPictureBox.TabStop = false;
            this.EditorPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.EditorPictureBox_Paint);
            this.EditorPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseDown);
            this.EditorPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseMove);
            // 
            // MovingMouseLabel
            // 
            this.MovingMouseLabel.Location = new System.Drawing.Point(38, 51);
            this.MovingMouseLabel.Name = "MovingMouseLabel";
            this.MovingMouseLabel.Size = new System.Drawing.Size(317, 23);
            this.MovingMouseLabel.TabIndex = 5;
            this.MovingMouseLabel.Text = "label1";
            // 
            // addPolygonButton
            // 
            this.addPolygonButton.Location = new System.Drawing.Point(38, 94);
            this.addPolygonButton.Name = "addPolygonButton";
            this.addPolygonButton.Size = new System.Drawing.Size(317, 47);
            this.addPolygonButton.TabIndex = 6;
            this.addPolygonButton.Text = "Add Polygon";
            this.addPolygonButton.UseVisualStyleBackColor = true;
            this.addPolygonButton.Click += new System.EventHandler(this.addPolygonButton_Click);
            // 
            // EditorForm
            // 
            this.AccessibleName = "PolygonEditor";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1702, 1159);
            this.Controls.Add(this.addPolygonButton);
            this.Controls.Add(this.MovingMouseLabel);
            this.Controls.Add(this.EditorPictureBox);
            this.Name = "EditorForm";
            this.Text = "PolygonEditor";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EditorPictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button addPolygonButton;

        private System.Windows.Forms.Label MovingMouseLabel;

        private System.Windows.Forms.PictureBox EditorPictureBox;

        #endregion
    }
}
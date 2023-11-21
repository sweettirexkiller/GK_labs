namespace filling_triangles
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
            this.components = new System.ComponentModel.Container();
            this.menuContainer = new System.Windows.Forms.ContainerControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.randomColorCheckbox = new System.Windows.Forms.CheckBox();
            this.chosenColorPanel = new System.Windows.Forms.Panel();
            this.showColorPickerButton = new System.Windows.Forms.Button();
            this.pickedColorCheckbox = new System.Windows.Forms.CheckBox();
            this.triangleMeshGroupBox = new System.Windows.Forms.GroupBox();
            this.triangleMeshVisibilityButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.columnCountY = new System.Windows.Forms.NumericUpDown();
            this.columnCountX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.triangleMeshGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuContainer
            // 
            this.menuContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.menuContainer.BackColor = System.Drawing.SystemColors.Menu;
            this.menuContainer.Controls.Add(this.groupBox1);
            this.menuContainer.Controls.Add(this.triangleMeshGroupBox);
            this.menuContainer.Location = new System.Drawing.Point(1323, 12);
            this.menuContainer.Name = "menuContainer";
            this.menuContainer.Size = new System.Drawing.Size(575, 1513);
            this.menuContainer.TabIndex = 1;
            this.menuContainer.Text = "containerControl2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.randomColorCheckbox);
            this.groupBox1.Controls.Add(this.chosenColorPanel);
            this.groupBox1.Controls.Add(this.showColorPickerButton);
            this.groupBox1.Controls.Add(this.pickedColorCheckbox);
            this.groupBox1.Location = new System.Drawing.Point(3, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 297);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color";
            // 
            // randomColorCheckbox
            // 
            this.randomColorCheckbox.Location = new System.Drawing.Point(50, 170);
            this.randomColorCheckbox.Name = "randomColorCheckbox";
            this.randomColorCheckbox.Size = new System.Drawing.Size(207, 34);
            this.randomColorCheckbox.TabIndex = 3;
            this.randomColorCheckbox.Text = "Random Colors";
            this.randomColorCheckbox.UseVisualStyleBackColor = true;
            // 
            // chosenColorPanel
            // 
            this.chosenColorPanel.BackColor = System.Drawing.SystemColors.Window;
            this.chosenColorPanel.Location = new System.Drawing.Point(299, 83);
            this.chosenColorPanel.Name = "chosenColorPanel";
            this.chosenColorPanel.Size = new System.Drawing.Size(51, 49);
            this.chosenColorPanel.TabIndex = 2;
            // 
            // showColorPickerButton
            // 
            this.showColorPickerButton.Location = new System.Drawing.Point(374, 83);
            this.showColorPickerButton.Name = "showColorPickerButton";
            this.showColorPickerButton.Size = new System.Drawing.Size(121, 43);
            this.showColorPickerButton.TabIndex = 1;
            this.showColorPickerButton.Text = "Pick";
            this.showColorPickerButton.UseVisualStyleBackColor = true;
            this.showColorPickerButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // pickedColorCheckbox
            // 
            this.pickedColorCheckbox.Location = new System.Drawing.Point(46, 72);
            this.pickedColorCheckbox.Name = "pickedColorCheckbox";
            this.pickedColorCheckbox.Size = new System.Drawing.Size(269, 62);
            this.pickedColorCheckbox.TabIndex = 0;
            this.pickedColorCheckbox.Text = "Picked Color";
            this.pickedColorCheckbox.UseVisualStyleBackColor = true;
            // 
            // triangleMeshGroupBox
            // 
            this.triangleMeshGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.triangleMeshGroupBox.Controls.Add(this.triangleMeshVisibilityButton);
            this.triangleMeshGroupBox.Controls.Add(this.label3);
            this.triangleMeshGroupBox.Controls.Add(this.columnCountY);
            this.triangleMeshGroupBox.Controls.Add(this.columnCountX);
            this.triangleMeshGroupBox.Controls.Add(this.label2);
            this.triangleMeshGroupBox.Controls.Add(this.label1);
            this.triangleMeshGroupBox.Location = new System.Drawing.Point(3, 3);
            this.triangleMeshGroupBox.Name = "triangleMeshGroupBox";
            this.triangleMeshGroupBox.Size = new System.Drawing.Size(569, 188);
            this.triangleMeshGroupBox.TabIndex = 0;
            this.triangleMeshGroupBox.TabStop = false;
            this.triangleMeshGroupBox.Text = "Triangle Mesh";
            // 
            // triangleMeshVisibilityButton
            // 
            this.triangleMeshVisibilityButton.Location = new System.Drawing.Point(287, 116);
            this.triangleMeshVisibilityButton.Name = "triangleMeshVisibilityButton";
            this.triangleMeshVisibilityButton.Size = new System.Drawing.Size(113, 37);
            this.triangleMeshVisibilityButton.TabIndex = 7;
            this.triangleMeshVisibilityButton.Text = "Hide";
            this.triangleMeshVisibilityButton.UseVisualStyleBackColor = true;
            this.triangleMeshVisibilityButton.Click += new System.EventHandler(this.triangleMeshVisibilityButton_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(74, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Visibility";
            // 
            // columnCountY
            // 
            this.columnCountY.Location = new System.Drawing.Point(280, 54);
            this.columnCountY.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.columnCountY.Name = "columnCountY";
            this.columnCountY.Size = new System.Drawing.Size(120, 31);
            this.columnCountY.TabIndex = 5;
            this.columnCountY.Value = new decimal(new int[] { 9, 0, 0, 0 });
            this.columnCountY.ValueChanged += new System.EventHandler(this.columnCountY_ValueChanged);
            // 
            // columnCountX
            // 
            this.columnCountX.Location = new System.Drawing.Point(129, 56);
            this.columnCountX.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.columnCountX.Name = "columnCountX";
            this.columnCountX.Size = new System.Drawing.Size(120, 31);
            this.columnCountX.TabIndex = 4;
            this.columnCountX.Value = new decimal(new int[] { 9, 0, 0, 0 });
            this.columnCountX.ValueChanged += new System.EventHandler(this.columnCountX_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(251, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "x";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(50, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Count";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1305, 1513);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1910, 1537);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuContainer);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.menuContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.triangleMeshGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.columnCountY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pictureBox;

        private System.Windows.Forms.CheckBox randomColorCheckbox;

        private System.Windows.Forms.Panel chosenColorPanel;

        private System.Windows.Forms.CheckBox pickedColorCheckbox;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button showColorPickerButton;

        private System.Windows.Forms.Button triangleMeshVisibilityButton;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.NumericUpDown columnCountX;
        private System.Windows.Forms.NumericUpDown columnCountY;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.GroupBox triangleMeshGroupBox;

        private System.Windows.Forms.ImageList imageList1;

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;

        private System.Windows.Forms.ContainerControl menuContainer;

        #endregion
    }
}
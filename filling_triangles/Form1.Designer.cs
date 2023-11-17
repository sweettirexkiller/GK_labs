namespace filling_triangles
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
            this.components = new System.ComponentModel.Container();
            this.menuContainer = new System.Windows.Forms.ContainerControl();
            this.triangleMeshGroupBox = new System.Windows.Forms.GroupBox();
            this.columnCountY = new System.Windows.Forms.NumericUpDown();
            this.columnCountX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.graphicsPanel = new System.Windows.Forms.Panel();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuContainer.SuspendLayout();
            this.triangleMeshGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountX)).BeginInit();
            this.SuspendLayout();
            // 
            // menuContainer
            // 
            this.menuContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.menuContainer.BackColor = System.Drawing.SystemColors.Menu;
            this.menuContainer.Controls.Add(this.triangleMeshGroupBox);
            this.menuContainer.Location = new System.Drawing.Point(1259, 12);
            this.menuContainer.Name = "menuContainer";
            this.menuContainer.Size = new System.Drawing.Size(575, 1321);
            this.menuContainer.TabIndex = 1;
            this.menuContainer.Text = "containerControl2";
            // 
            // triangleMeshGroupBox
            // 
            this.triangleMeshGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.triangleMeshGroupBox.Controls.Add(this.columnCountY);
            this.triangleMeshGroupBox.Controls.Add(this.columnCountX);
            this.triangleMeshGroupBox.Controls.Add(this.label2);
            this.triangleMeshGroupBox.Controls.Add(this.label1);
            this.triangleMeshGroupBox.Location = new System.Drawing.Point(3, 3);
            this.triangleMeshGroupBox.Name = "triangleMeshGroupBox";
            this.triangleMeshGroupBox.Size = new System.Drawing.Size(569, 158);
            this.triangleMeshGroupBox.TabIndex = 0;
            this.triangleMeshGroupBox.TabStop = false;
            this.triangleMeshGroupBox.Text = "Triangle Mesh";
            // 
            // columnCountY
            // 
            this.columnCountY.Location = new System.Drawing.Point(280, 54);
            this.columnCountY.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.columnCountY.Name = "columnCountY";
            this.columnCountY.Size = new System.Drawing.Size(120, 31);
            this.columnCountY.TabIndex = 5;
            this.columnCountY.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.columnCountY.ValueChanged += new System.EventHandler(this.columnCountY_ValueChanged);
            // 
            // columnCountX
            // 
            this.columnCountX.Location = new System.Drawing.Point(129, 56);
            this.columnCountX.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.columnCountX.Name = "columnCountX";
            this.columnCountX.Size = new System.Drawing.Size(120, 31);
            this.columnCountX.TabIndex = 4;
            this.columnCountX.Value = new decimal(new int[] { 1, 0, 0, 0 });
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
            // graphicsPanel
            // 
            this.graphicsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.graphicsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphicsPanel.Location = new System.Drawing.Point(12, 12);
            this.graphicsPanel.Name = "graphicsPanel";
            this.graphicsPanel.Size = new System.Drawing.Size(1232, 1321);
            this.graphicsPanel.TabIndex = 2;
            this.graphicsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicsPanel_Paint);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1846, 1345);
            this.Controls.Add(this.graphicsPanel);
            this.Controls.Add(this.menuContainer);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.menuContainer.ResumeLayout(false);
            this.triangleMeshGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.columnCountY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountX)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.NumericUpDown columnCountX;
        private System.Windows.Forms.NumericUpDown columnCountY;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.GroupBox triangleMeshGroupBox;

        private System.Windows.Forms.ImageList imageList1;

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;

        private System.Windows.Forms.Panel graphicsPanel;

        private System.Windows.Forms.ContainerControl menuContainer;

        #endregion
    }
}
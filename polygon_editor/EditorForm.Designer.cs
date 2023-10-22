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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.EditorPictureBox = new System.Windows.Forms.PictureBox();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.editorTab = new System.Windows.Forms.RibbonTab();
            this.polygonPanel = new System.Windows.Forms.RibbonPanel();
            this.addBtn = new System.Windows.Forms.RibbonButton();
            this.catchBtn = new System.Windows.Forms.RibbonButton();
            this.removeBtn = new System.Windows.Forms.RibbonButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.coordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.EditorPictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditorPictureBox
            // 
            this.EditorPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.EditorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditorPictureBox.Location = new System.Drawing.Point(12, 206);
            this.EditorPictureBox.Name = "EditorPictureBox";
            this.EditorPictureBox.Size = new System.Drawing.Size(1320, 1113);
            this.EditorPictureBox.TabIndex = 4;
            this.EditorPictureBox.TabStop = false;
            this.EditorPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.EditorPictureBox_Paint);
            this.EditorPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseDown);
            this.EditorPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseMove);
            // 
            // ribbon1
            // 
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1344, 200);
            this.ribbon1.TabIndex = 7;
            this.ribbon1.Tabs.Add(this.editorTab);
            this.ribbon1.Text = "ribbon1";
            // 
            // editorTab
            // 
            this.editorTab.Name = "editorTab";
            this.editorTab.Panels.Add(this.polygonPanel);
            this.editorTab.Text = "Editor";
            // 
            // polygonPanel
            // 
            this.polygonPanel.ButtonMoreEnabled = false;
            this.polygonPanel.ButtonMoreVisible = false;
            this.polygonPanel.Image = ((System.Drawing.Image)(resources.GetObject("polygonPanel.Image")));
            this.polygonPanel.Items.Add(this.addBtn);
            this.polygonPanel.Items.Add(this.catchBtn);
            this.polygonPanel.Items.Add(this.removeBtn);
            this.polygonPanel.Name = "polygonPanel";
            this.polygonPanel.Text = "";
            // 
            // addBtn
            // 
            this.addBtn.Image = ((System.Drawing.Image)(resources.GetObject("addBtn.Image")));
            this.addBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("addBtn.LargeImage")));
            this.addBtn.Name = "addBtn";
            this.addBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("addBtn.SmallImage")));
            this.addBtn.Click += new System.EventHandler(this.addPolygonButton_Click);
            // 
            // catchBtn
            // 
            this.catchBtn.Image = ((System.Drawing.Image)(resources.GetObject("catchBtn.Image")));
            this.catchBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("catchBtn.LargeImage")));
            this.catchBtn.Name = "catchBtn";
            this.catchBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("catchBtn.SmallImage")));
            this.catchBtn.Click += new System.EventHandler(this.catchBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Image = ((System.Drawing.Image)(resources.GetObject("removeBtn.Image")));
            this.removeBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("removeBtn.LargeImage")));
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("removeBtn.SmallImage")));
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.coordinate });
            this.statusStrip1.Location = new System.Drawing.Point(0, 1322);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1344, 50);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip";
            // 
            // coordinate
            // 
            this.coordinate.AutoSize = false;
            this.coordinate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.coordinate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.coordinate.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.coordinate.Name = "coordinate";
            this.coordinate.Size = new System.Drawing.Size(300, 45);
            this.coordinate.Text = "0.000 0.000";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.cancelToolStripMenuItem });
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(162, 40);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(161, 36);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // EditorForm
            // 
            this.AccessibleName = "PolygonEditor";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 1372);
            this.ContextMenuStrip = this.menuStrip;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.EditorPictureBox);
            this.KeyPreview = true;
            this.Name = "EditorForm";
            this.Text = "PolygonEditor";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EditorPictureBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;


        private System.Windows.Forms.ToolStripStatusLabel coordinate;

        private System.Windows.Forms.StatusStrip statusStrip1;

        private System.Windows.Forms.RibbonButton removeBtn;

        private System.Windows.Forms.RibbonButton catchBtn;

        private System.Windows.Forms.RibbonButton addBtn;

        private System.Windows.Forms.RibbonPanel polygonPanel;

        private System.Windows.Forms.RibbonTab editorTab;

        private System.Windows.Forms.Ribbon ribbon1;

        private System.Windows.Forms.PictureBox EditorPictureBox;

        #endregion
    }
}
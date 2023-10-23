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
            this.catchPolygonBtn = new System.Windows.Forms.RibbonButton();
            this.restrictionsPanel = new System.Windows.Forms.RibbonPanel();
            this.addHRestrictionBtn = new System.Windows.Forms.RibbonButton();
            this.removeHRestrictionBtn = new System.Windows.Forms.RibbonButton();
            this.addVRestrictionBtn = new System.Windows.Forms.RibbonButton();
            this.removeVRestrictionBtn = new System.Windows.Forms.RibbonButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.coordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonItemGroup1 = new System.Windows.Forms.RibbonItemGroup();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
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
            this.EditorPictureBox.Size = new System.Drawing.Size(1408, 1611);
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
            this.ribbon1.Size = new System.Drawing.Size(1432, 200);
            this.ribbon1.TabIndex = 7;
            this.ribbon1.Tabs.Add(this.editorTab);
            this.ribbon1.Text = "ribbon1";
            // 
            // editorTab
            // 
            this.editorTab.Name = "editorTab";
            this.editorTab.Panels.Add(this.polygonPanel);
            this.editorTab.Panels.Add(this.restrictionsPanel);
            this.editorTab.Text = "Editor";
            // 
            // polygonPanel
            // 
            this.polygonPanel.ButtonMoreEnabled = false;
            this.polygonPanel.ButtonMoreVisible = false;
            this.polygonPanel.Items.Add(this.addBtn);
            this.polygonPanel.Items.Add(this.catchBtn);
            this.polygonPanel.Items.Add(this.removeBtn);
            this.polygonPanel.Items.Add(this.catchPolygonBtn);
            this.polygonPanel.Name = "polygonPanel";
            this.polygonPanel.Text = "Actions";
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
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // catchPolygonBtn
            // 
            this.catchPolygonBtn.Image = ((System.Drawing.Image)(resources.GetObject("catchPolygonBtn.Image")));
            this.catchPolygonBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("catchPolygonBtn.LargeImage")));
            this.catchPolygonBtn.Name = "catchPolygonBtn";
            this.catchPolygonBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("catchPolygonBtn.SmallImage")));
            this.catchPolygonBtn.Text = "Move";
            this.catchPolygonBtn.Click += new System.EventHandler(this.catchPolygonBtn_Click);
            // 
            // restrictionsPanel
            // 
            this.restrictionsPanel.Items.Add(this.addHRestrictionBtn);
            this.restrictionsPanel.Items.Add(this.removeHRestrictionBtn);
            this.restrictionsPanel.Items.Add(this.addVRestrictionBtn);
            this.restrictionsPanel.Items.Add(this.removeVRestrictionBtn);
            this.restrictionsPanel.Name = "restrictionsPanel";
            this.restrictionsPanel.Text = "Line Restricions";
            // 
            // addHRestrictionBtn
            // 
            this.addHRestrictionBtn.Image = ((System.Drawing.Image)(resources.GetObject("addHRestrictionBtn.Image")));
            this.addHRestrictionBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("addHRestrictionBtn.LargeImage")));
            this.addHRestrictionBtn.Name = "addHRestrictionBtn";
            this.addHRestrictionBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("addHRestrictionBtn.SmallImage")));
            this.addHRestrictionBtn.Text = "Add";
            this.addHRestrictionBtn.Click += new System.EventHandler(this.addHRestrictionBtn_Click);
            // 
            // removeHRestrictionBtn
            // 
            this.removeHRestrictionBtn.Image = ((System.Drawing.Image)(resources.GetObject("removeHRestrictionBtn.Image")));
            this.removeHRestrictionBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("removeHRestrictionBtn.LargeImage")));
            this.removeHRestrictionBtn.Name = "removeHRestrictionBtn";
            this.removeHRestrictionBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("removeHRestrictionBtn.SmallImage")));
            this.removeHRestrictionBtn.Text = "Remove";
            this.removeHRestrictionBtn.Click += new System.EventHandler(this.removeHRestrictionBtn_Click);
            // 
            // addVRestrictionBtn
            // 
            this.addVRestrictionBtn.Image = ((System.Drawing.Image)(resources.GetObject("addVRestrictionBtn.Image")));
            this.addVRestrictionBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("addVRestrictionBtn.LargeImage")));
            this.addVRestrictionBtn.Name = "addVRestrictionBtn";
            this.addVRestrictionBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("addVRestrictionBtn.SmallImage")));
            this.addVRestrictionBtn.Text = "Add";
            this.addVRestrictionBtn.Click += new System.EventHandler(this.addVRestrictionBtn_Click);
            // 
            // removeVRestrictionBtn
            // 
            this.removeVRestrictionBtn.Image = ((System.Drawing.Image)(resources.GetObject("removeVRestrictionBtn.Image")));
            this.removeVRestrictionBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("removeVRestrictionBtn.LargeImage")));
            this.removeVRestrictionBtn.Name = "removeVRestrictionBtn";
            this.removeVRestrictionBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("removeVRestrictionBtn.SmallImage")));
            this.removeVRestrictionBtn.Text = "Remove";
            this.removeVRestrictionBtn.Click += new System.EventHandler(this.removeVRestrictionBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.coordinate });
            this.statusStrip1.Location = new System.Drawing.Point(0, 1820);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1432, 50);
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
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.LargeImage")));
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            // 
            // ribbonItemGroup1
            // 
            this.ribbonItemGroup1.Items.Add(this.ribbonButton3);
            this.ribbonItemGroup1.Name = "ribbonItemGroup1";
            this.ribbonItemGroup1.Text = "asdasd";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.Image")));
            this.ribbonButton3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.LargeImage")));
            this.ribbonButton3.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "asdasd";
            // 
            // EditorForm
            // 
            this.AccessibleName = "PolygonEditor";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 1870);
            this.ContextMenuStrip = this.menuStrip;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.EditorPictureBox);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "EditorForm";
            this.Text = "PolygonEditor";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EditorPictureBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.RibbonButton removeVRestrictionBtn;

        private System.Windows.Forms.RibbonButton addVRestrictionBtn;

        private System.Windows.Forms.RibbonButton addHRestrictionBtn;
        private System.Windows.Forms.RibbonButton removeHRestrictionBtn;

        private System.Windows.Forms.RibbonPanel restrictionsPanel;

        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonItemGroup ribbonItemGroup1;
        private System.Windows.Forms.RibbonButton ribbonButton3;

        private System.Windows.Forms.MainMenu mainMenu1;

        private System.Windows.Forms.RibbonPanel ribbonPanel1;

        private System.Windows.Forms.RibbonButton catchPolygonBtn;

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
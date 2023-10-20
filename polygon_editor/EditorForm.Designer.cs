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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.EditorPictureBox = new System.Windows.Forms.PictureBox();
            this.MovingMouseLabel = new System.Windows.Forms.Label();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.editorTab = new System.Windows.Forms.RibbonTab();
            this.polygonPanel = new System.Windows.Forms.RibbonPanel();
            this.addBtn = new System.Windows.Forms.RibbonButton();
            this.catchBtn = new System.Windows.Forms.RibbonButton();
            this.removeBtn = new System.Windows.Forms.RibbonButton();
            ((System.ComponentModel.ISupportInitialize)(this.EditorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // EditorPictureBox
            // 
            this.EditorPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.EditorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditorPictureBox.Location = new System.Drawing.Point(12, 206);
            this.EditorPictureBox.Name = "EditorPictureBox";
            this.EditorPictureBox.Size = new System.Drawing.Size(1232, 858);
            this.EditorPictureBox.TabIndex = 4;
            this.EditorPictureBox.TabStop = false;
            this.EditorPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.EditorPictureBox_Paint);
            this.EditorPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseDown);
            this.EditorPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EditorPictureBox_MouseMove);
            // 
            // MovingMouseLabel
            // 
            this.MovingMouseLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MovingMouseLabel.Location = new System.Drawing.Point(0, 1085);
            this.MovingMouseLabel.Name = "MovingMouseLabel";
            this.MovingMouseLabel.Size = new System.Drawing.Size(1256, 23);
            this.MovingMouseLabel.TabIndex = 5;
            this.MovingMouseLabel.Text = "label1";
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
            this.ribbon1.Size = new System.Drawing.Size(1256, 200);
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
            // 
            // removeBtn
            // 
            this.removeBtn.Image = ((System.Drawing.Image)(resources.GetObject("removeBtn.Image")));
            this.removeBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("removeBtn.LargeImage")));
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("removeBtn.SmallImage")));
            // 
            // EditorForm
            // 
            this.AccessibleName = "PolygonEditor";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 1108);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.MovingMouseLabel);
            this.Controls.Add(this.EditorPictureBox);
            this.KeyPreview = true;
            this.Name = "EditorForm";
            this.Text = "PolygonEditor";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EditorPictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.RibbonButton removeBtn;

        private System.Windows.Forms.RibbonButton catchBtn;

        private System.Windows.Forms.RibbonButton addBtn;

        private System.Windows.Forms.RibbonPanel polygonPanel;

        private System.Windows.Forms.RibbonTab editorTab;

        private System.Windows.Forms.Ribbon ribbon1;

        private System.Windows.Forms.Label MovingMouseLabel;

        private System.Windows.Forms.PictureBox EditorPictureBox;

        #endregion
    }
}
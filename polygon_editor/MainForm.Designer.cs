using System.ComponentModel;

namespace polygon_editor
{
    partial class MainForm
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
            this.mainmenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.exitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.mainmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainmenu
            // 
            this.mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.fileToolStripMenuItem });
            this.mainmenu.Location = new System.Drawing.Point(0, 0);
            this.mainmenu.Name = "mainmenu";
            this.mainmenu.Size = new System.Drawing.Size(1196, 40);
            this.mainmenu.TabIndex = 1;
            this.mainmenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.newBtn, this.exitBtn });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newBtn
            // 
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(138, 36);
            this.newBtn.Text = "New";
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(138, 36);
            this.exitBtn.Text = "Exit";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 1087);
            this.Controls.Add(this.mainmenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainmenu;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainmenu.ResumeLayout(false);
            this.mainmenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem newBtn;
        private System.Windows.Forms.ToolStripMenuItem exitBtn;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

        private System.Windows.Forms.MenuStrip mainmenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;

        #endregion
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;

namespace polygon_editor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private ToolStripMenuItem windowsBtn = new ToolStripMenuItem();
        private EditorForm EditorForm;
        private int counter = 1;
        private void newBtn_Click(object sender, EventArgs e)
        {
            windowsBtn.Name="windowsBtn";
            windowsBtn.Text="Windows";
            windowsBtn.Size = new Size(120, 28);

            var item = mainmenu.Items.IndexOf(windowsBtn);
            if (item == -1)
            {
                mainmenu.Items.Add(windowsBtn);
                mainmenu.MdiWindowListItem = windowsBtn;
            }

            EditorForm = new EditorForm();
            EditorForm.Name=string.Concat("PolygonEditor ", counter.ToString());
            EditorForm.Text = EditorForm.Name;
            EditorForm.MdiParent = this;
            EditorForm.Show();
            EditorForm.WindowState = FormWindowState.Maximized;
            counter++;
        }


        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
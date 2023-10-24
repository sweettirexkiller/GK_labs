using System;
using System.Windows.Forms;

namespace polygon_editor
{
    public partial class LineForm : Form
    {
        public LineForm(ref polygon_editor.Entities.Line line)
        {
            InitializeComponent();
        }

        private polygon_editor.Entities.Line line;

        private void thicknessBar_Scroll(object sender, EventArgs e)
        {
            //set thickness
            this.label1.Text = string.Format("Line Thickness: {0}", thicknessBar.Value);
            line.Thikness = (double)thicknessBar.Value;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
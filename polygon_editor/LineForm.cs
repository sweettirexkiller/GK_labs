using System;
using System.Windows.Forms;

namespace polygon_editor
{
    public partial class LineForm : Form
    {
        public LineForm(polygon_editor.Entities.Line line)
        {
            InitializeComponent();
            _line = line;
        }

        private polygon_editor.Entities.Line _line;

        private void thicknessBar_Scroll(object sender, EventArgs e)
        {
            //set thickness
            this.label1.Text = string.Format("Line Thickness: {0}", thicknessBar.Value);
            _line.Thikness = (double)thicknessBar.Value;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
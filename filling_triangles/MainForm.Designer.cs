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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.mLabel = new System.Windows.Forms.Label();
            this.ksLabel = new System.Windows.Forms.Label();
            this.kdLabel = new System.Windows.Forms.Label();
            this.mTrackBar = new System.Windows.Forms.TrackBar();
            this.ksTrackBar = new System.Windows.Forms.TrackBar();
            this.kdTrackBar = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.animatedLightVectorRadioButton = new System.Windows.Forms.RadioButton();
            this.constantLightVectorRadioButton = new System.Windows.Forms.RadioButton();
            this.lightColorPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.normalVectorGroupBox = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.heightMapFileButton = new System.Windows.Forms.Button();
            this.heightMapFromFileRadioButton = new System.Windows.Forms.RadioButton();
            this.constantVectorRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.interpolatedCheckbox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.imageRadioButton = new System.Windows.Forms.RadioButton();
            this.pickedColorRadioButton = new System.Windows.Forms.RadioButton();
            this.chosenColorPanel = new System.Windows.Forms.Panel();
            this.showColorPickerButton = new System.Windows.Forms.Button();
            this.triangleMeshGroupBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.alfaUpDown = new System.Windows.Forms.Label();
            this.betaUpDown = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.textureFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuContainer.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.normalVectorGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.triangleMeshGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.betaUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuContainer
            // 
            this.menuContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.menuContainer.BackColor = System.Drawing.SystemColors.Menu;
            this.menuContainer.Controls.Add(this.groupBox3);
            this.menuContainer.Controls.Add(this.groupBox2);
            this.menuContainer.Controls.Add(this.normalVectorGroupBox);
            this.menuContainer.Controls.Add(this.groupBox1);
            this.menuContainer.Controls.Add(this.triangleMeshGroupBox);
            this.menuContainer.Location = new System.Drawing.Point(1258, 12);
            this.menuContainer.Name = "menuContainer";
            this.menuContainer.Size = new System.Drawing.Size(575, 1441);
            this.menuContainer.TabIndex = 1;
            this.menuContainer.Text = "containerControl2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mLabel);
            this.groupBox3.Controls.Add(this.ksLabel);
            this.groupBox3.Controls.Add(this.kdLabel);
            this.groupBox3.Controls.Add(this.mTrackBar);
            this.groupBox3.Controls.Add(this.ksTrackBar);
            this.groupBox3.Controls.Add(this.kdTrackBar);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(9, 1072);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(566, 344);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Coefficients";
            // 
            // mLabel
            // 
            this.mLabel.Location = new System.Drawing.Point(493, 261);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(100, 23);
            this.mLabel.TabIndex = 8;
            this.mLabel.Text = "50";
            // 
            // ksLabel
            // 
            this.ksLabel.Location = new System.Drawing.Point(493, 165);
            this.ksLabel.Name = "ksLabel";
            this.ksLabel.Size = new System.Drawing.Size(100, 23);
            this.ksLabel.TabIndex = 7;
            this.ksLabel.Text = "0.5";
            // 
            // kdLabel
            // 
            this.kdLabel.Location = new System.Drawing.Point(493, 67);
            this.kdLabel.Name = "kdLabel";
            this.kdLabel.Size = new System.Drawing.Size(100, 23);
            this.kdLabel.TabIndex = 6;
            this.kdLabel.Text = "0.5";
            // 
            // mTrackBar
            // 
            this.mTrackBar.LargeChange = 20;
            this.mTrackBar.Location = new System.Drawing.Point(71, 261);
            this.mTrackBar.Maximum = 100;
            this.mTrackBar.Minimum = 1;
            this.mTrackBar.Name = "mTrackBar";
            this.mTrackBar.Size = new System.Drawing.Size(399, 90);
            this.mTrackBar.SmallChange = 5;
            this.mTrackBar.TabIndex = 5;
            this.mTrackBar.Value = 1;
            this.mTrackBar.Scroll += new System.EventHandler(this.mTrackBar_Scroll);
            // 
            // ksTrackBar
            // 
            this.ksTrackBar.Location = new System.Drawing.Point(71, 151);
            this.ksTrackBar.Name = "ksTrackBar";
            this.ksTrackBar.Size = new System.Drawing.Size(399, 90);
            this.ksTrackBar.TabIndex = 4;
            this.ksTrackBar.Value = 5;
            this.ksTrackBar.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // kdTrackBar
            // 
            this.kdTrackBar.Location = new System.Drawing.Point(71, 55);
            this.kdTrackBar.Name = "kdTrackBar";
            this.kdTrackBar.Size = new System.Drawing.Size(399, 90);
            this.kdTrackBar.TabIndex = 3;
            this.kdTrackBar.Value = 5;
            this.kdTrackBar.Scroll += new System.EventHandler(this.kdTrackBar_Scroll);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(29, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 2;
            this.label8.Text = "ks";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(36, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "m";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(20, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "kd";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.animatedLightVectorRadioButton);
            this.groupBox2.Controls.Add(this.constantLightVectorRadioButton);
            this.groupBox2.Controls.Add(this.lightColorPanel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(9, 792);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 274);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Light";
            // 
            // animatedLightVectorRadioButton
            // 
            this.animatedLightVectorRadioButton.Location = new System.Drawing.Point(51, 202);
            this.animatedLightVectorRadioButton.Name = "animatedLightVectorRadioButton";
            this.animatedLightVectorRadioButton.Size = new System.Drawing.Size(269, 36);
            this.animatedLightVectorRadioButton.TabIndex = 13;
            this.animatedLightVectorRadioButton.Text = "Circle Animation";
            this.animatedLightVectorRadioButton.UseVisualStyleBackColor = true;
            this.animatedLightVectorRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // constantLightVectorRadioButton
            // 
            this.constantLightVectorRadioButton.Checked = true;
            this.constantLightVectorRadioButton.Location = new System.Drawing.Point(51, 145);
            this.constantLightVectorRadioButton.Name = "constantLightVectorRadioButton";
            this.constantLightVectorRadioButton.Size = new System.Drawing.Size(269, 35);
            this.constantLightVectorRadioButton.TabIndex = 12;
            this.constantLightVectorRadioButton.TabStop = true;
            this.constantLightVectorRadioButton.Text = "Constant Light [0,0,1]";
            this.constantLightVectorRadioButton.UseVisualStyleBackColor = true;
            this.constantLightVectorRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // lightColorPanel
            // 
            this.lightColorPanel.BackColor = System.Drawing.SystemColors.Window;
            this.lightColorPanel.Location = new System.Drawing.Point(296, 63);
            this.lightColorPanel.Name = "lightColorPanel";
            this.lightColorPanel.Size = new System.Drawing.Size(51, 49);
            this.lightColorPanel.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(36, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Color";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(371, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 43);
            this.button2.TabIndex = 9;
            this.button2.Text = "Pick";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // normalVectorGroupBox
            // 
            this.normalVectorGroupBox.Controls.Add(this.panel2);
            this.normalVectorGroupBox.Controls.Add(this.heightMapFileButton);
            this.normalVectorGroupBox.Controls.Add(this.heightMapFromFileRadioButton);
            this.normalVectorGroupBox.Controls.Add(this.constantVectorRadioButton);
            this.normalVectorGroupBox.Location = new System.Drawing.Point(9, 607);
            this.normalVectorGroupBox.Name = "normalVectorGroupBox";
            this.normalVectorGroupBox.Size = new System.Drawing.Size(569, 179);
            this.normalVectorGroupBox.TabIndex = 2;
            this.normalVectorGroupBox.TabStop = false;
            this.normalVectorGroupBox.Text = "Vector N";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Location = new System.Drawing.Point(296, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(51, 49);
            this.panel2.TabIndex = 8;
            // 
            // heightMapFileButton
            // 
            this.heightMapFileButton.Location = new System.Drawing.Point(371, 120);
            this.heightMapFileButton.Name = "heightMapFileButton";
            this.heightMapFileButton.Size = new System.Drawing.Size(133, 41);
            this.heightMapFileButton.TabIndex = 2;
            this.heightMapFileButton.Text = "Choose";
            this.heightMapFileButton.UseVisualStyleBackColor = true;
            this.heightMapFileButton.Click += new System.EventHandler(this.normalMapFileButton_Click);
            // 
            // heightMapFromFileRadioButton
            // 
            this.heightMapFromFileRadioButton.Location = new System.Drawing.Point(29, 112);
            this.heightMapFromFileRadioButton.Name = "heightMapFromFileRadioButton";
            this.heightMapFromFileRadioButton.Size = new System.Drawing.Size(182, 41);
            this.heightMapFromFileRadioButton.TabIndex = 1;
            this.heightMapFromFileRadioButton.Text = "From File";
            this.heightMapFromFileRadioButton.UseVisualStyleBackColor = true;
            this.heightMapFromFileRadioButton.CheckedChanged += new System.EventHandler(this.heightMapFromFileRadioButton_CheckedChanged);
            // 
            // constantVectorRadioButton
            // 
            this.constantVectorRadioButton.Checked = true;
            this.constantVectorRadioButton.Location = new System.Drawing.Point(26, 61);
            this.constantVectorRadioButton.Name = "constantVectorRadioButton";
            this.constantVectorRadioButton.Size = new System.Drawing.Size(160, 36);
            this.constantVectorRadioButton.TabIndex = 0;
            this.constantVectorRadioButton.TabStop = true;
            this.constantVectorRadioButton.Text = " [ 0 , 0  , 1]";
            this.constantVectorRadioButton.UseVisualStyleBackColor = true;
            this.constantVectorRadioButton.CheckedChanged += new System.EventHandler(this.constantVectorRadioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.interpolatedCheckbox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.imageRadioButton);
            this.groupBox1.Controls.Add(this.pickedColorRadioButton);
            this.groupBox1.Controls.Add(this.chosenColorPanel);
            this.groupBox1.Controls.Add(this.showColorPickerButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 305);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Object Color";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(299, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(51, 49);
            this.panel1.TabIndex = 10;
            // 
            // interpolatedCheckbox
            // 
            this.interpolatedCheckbox.Location = new System.Drawing.Point(299, 260);
            this.interpolatedCheckbox.Name = "interpolatedCheckbox";
            this.interpolatedCheckbox.Size = new System.Drawing.Size(245, 43);
            this.interpolatedCheckbox.TabIndex = 7;
            this.interpolatedCheckbox.Text = "Color Interpolated";
            this.interpolatedCheckbox.UseVisualStyleBackColor = true;
            this.interpolatedCheckbox.CheckedChanged += new System.EventHandler(this.interpolatedCheckbox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 49);
            this.button1.TabIndex = 6;
            this.button1.Text = "Choose";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageRadioButton
            // 
            this.imageRadioButton.Location = new System.Drawing.Point(29, 176);
            this.imageRadioButton.Name = "imageRadioButton";
            this.imageRadioButton.Size = new System.Drawing.Size(245, 44);
            this.imageRadioButton.TabIndex = 5;
            this.imageRadioButton.Text = "Image";
            this.imageRadioButton.UseVisualStyleBackColor = true;
            this.imageRadioButton.CheckedChanged += new System.EventHandler(this.imageRadioButton_CheckedChanged);
            // 
            // pickedColorRadioButton
            // 
            this.pickedColorRadioButton.Checked = true;
            this.pickedColorRadioButton.Location = new System.Drawing.Point(32, 83);
            this.pickedColorRadioButton.Name = "pickedColorRadioButton";
            this.pickedColorRadioButton.Size = new System.Drawing.Size(225, 56);
            this.pickedColorRadioButton.TabIndex = 4;
            this.pickedColorRadioButton.TabStop = true;
            this.pickedColorRadioButton.Text = "Constant Color";
            this.pickedColorRadioButton.UseVisualStyleBackColor = true;
            this.pickedColorRadioButton.CheckedChanged += new System.EventHandler(this.pickedColorCheckbox_CheckedChanged);
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
            this.showColorPickerButton.ForeColor = System.Drawing.SystemColors.WindowText;
            this.showColorPickerButton.Location = new System.Drawing.Point(374, 83);
            this.showColorPickerButton.Name = "showColorPickerButton";
            this.showColorPickerButton.Size = new System.Drawing.Size(121, 43);
            this.showColorPickerButton.TabIndex = 1;
            this.showColorPickerButton.Text = "Pick";
            this.showColorPickerButton.UseVisualStyleBackColor = true;
            this.showColorPickerButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // triangleMeshGroupBox
            // 
            this.triangleMeshGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.triangleMeshGroupBox.Controls.Add(this.label10);
            this.triangleMeshGroupBox.Controls.Add(this.alfaUpDown);
            this.triangleMeshGroupBox.Controls.Add(this.betaUpDown);
            this.triangleMeshGroupBox.Controls.Add(this.numericUpDown1);
            this.triangleMeshGroupBox.Controls.Add(this.button3);
            this.triangleMeshGroupBox.Controls.Add(this.checkBox1);
            this.triangleMeshGroupBox.Controls.Add(this.label4);
            this.triangleMeshGroupBox.Controls.Add(this.triangleMeshVisibilityButton);
            this.triangleMeshGroupBox.Controls.Add(this.label3);
            this.triangleMeshGroupBox.Controls.Add(this.columnCountY);
            this.triangleMeshGroupBox.Controls.Add(this.columnCountX);
            this.triangleMeshGroupBox.Controls.Add(this.label2);
            this.triangleMeshGroupBox.Controls.Add(this.label1);
            this.triangleMeshGroupBox.Location = new System.Drawing.Point(9, 3);
            this.triangleMeshGroupBox.Name = "triangleMeshGroupBox";
            this.triangleMeshGroupBox.Size = new System.Drawing.Size(538, 287);
            this.triangleMeshGroupBox.TabIndex = 0;
            this.triangleMeshGroupBox.TabStop = false;
            this.triangleMeshGroupBox.Text = "Triangle Mesh";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(192, 239);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 23);
            this.label10.TabIndex = 14;
            this.label10.Text = "Beta\r\n";
            // 
            // alfaUpDown
            // 
            this.alfaUpDown.Location = new System.Drawing.Point(6, 235);
            this.alfaUpDown.Name = "alfaUpDown";
            this.alfaUpDown.Size = new System.Drawing.Size(54, 31);
            this.alfaUpDown.TabIndex = 13;
            this.alfaUpDown.Text = "Alfa";
            // 
            // betaUpDown
            // 
            this.betaUpDown.Location = new System.Drawing.Point(267, 235);
            this.betaUpDown.Maximum = new decimal(new int[] { 45, 0, 0, 0 });
            this.betaUpDown.Name = "betaUpDown";
            this.betaUpDown.Size = new System.Drawing.Size(120, 31);
            this.betaUpDown.TabIndex = 12;
            this.betaUpDown.ValueChanged += new System.EventHandler(this.betaUpDown_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(66, 235);
            this.numericUpDown1.Maximum = new decimal(new int[] { 45, 0, 0, 0 });
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 31);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(393, 222);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 59);
            this.button3.TabIndex = 10;
            this.button3.Text = "Rotate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(46, 168);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(338, 54);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "z(x,y)=sin(pi/2x+pi/2y)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(46, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Visibility";
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
            this.pictureBox.Size = new System.Drawing.Size(1240, 1441);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // textureFileDialog
            // 
            this.textureFileDialog.FileName = "textureFileDialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1845, 1465);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuContainer);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin_1);
            this.menuContainer.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.normalVectorGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.triangleMeshGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.betaUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label10;

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown betaUpDown;
        private System.Windows.Forms.Label alfaUpDown;

        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.CheckBox checkBox1;

        private System.Windows.Forms.RadioButton constantLightVectorRadioButton;
        private System.Windows.Forms.RadioButton animatedLightVectorRadioButton;

        private System.Windows.Forms.Label kdLabel;
        private System.Windows.Forms.Label ksLabel;
        private System.Windows.Forms.Label mLabel;

        private System.Windows.Forms.TrackBar ksTrackBar;
        private System.Windows.Forms.TrackBar mTrackBar;

        private System.Windows.Forms.TrackBar kdTrackBar;

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel lightColorPanel;

        private System.Windows.Forms.CheckBox interpolatedCheckbox;

        private System.Windows.Forms.GroupBox normalVectorGroupBox;
        private System.Windows.Forms.RadioButton constantVectorRadioButton;
        private System.Windows.Forms.RadioButton heightMapFromFileRadioButton;
        private System.Windows.Forms.Button heightMapFileButton;

        private System.Windows.Forms.RadioButton imageRadioButton;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.OpenFileDialog textureFileDialog;

        private System.Windows.Forms.RadioButton pickedColorRadioButton;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.PictureBox pictureBox;

        private System.Windows.Forms.Panel chosenColorPanel;

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
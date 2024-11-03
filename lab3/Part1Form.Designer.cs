namespace lab3
{
    partial class Part1Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxCanvas;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.Button btnColorLine;
        private System.Windows.Forms.Button btnColorFill;
        private System.Windows.Forms.Label labelLineWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownLineWidth;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBoxFourier;
        private System.Windows.Forms.Label labelHarmonics;
        private System.Windows.Forms.NumericUpDown numericUpDownHarmonics;
        private System.Windows.Forms.RadioButton radioButtonSawtooth;
        private System.Windows.Forms.RadioButton radioButtonTriangle;
        private System.Windows.Forms.RadioButton radioButtonSquare;
        private System.Windows.Forms.Button btnDrawFourier;
        private System.Windows.Forms.Button btnClearCanvas;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label labelFrequency;
        private System.Windows.Forms.NumericUpDown numericUpDownFrequency;
        private System.Windows.Forms.Label labelPhase;
        private System.Windows.Forms.NumericUpDown numericUpDownPhase;
        private System.Windows.Forms.Label labelDashStyle;
        private System.Windows.Forms.RadioButton radioButtonSolid;
        private System.Windows.Forms.RadioButton radioButtonDot;
        private System.Windows.Forms.RadioButton radioButtonDash;
        private System.Windows.Forms.RadioButton radioButtonDashDot;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                originalBitmap?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pictureBoxCanvas = new PictureBox();
            panelTools = new Panel();
            btnReturn = new Button();
            btnClearCanvas = new Button();
            btnDrawFourier = new Button();
            groupBoxFourier = new GroupBox();
            numericUpDownPhase = new NumericUpDown();
            labelPhase = new Label();
            numericUpDownFrequency = new NumericUpDown();
            labelFrequency = new Label();
            radioButtonSawtooth = new RadioButton();
            radioButtonTriangle = new RadioButton();
            radioButtonSquare = new RadioButton();
            labelHarmonics = new Label();
            numericUpDownHarmonics = new NumericUpDown();
            btnSave = new Button();
            btnOpen = new Button();
            radioButtonDashDot = new RadioButton();
            radioButtonDash = new RadioButton();
            radioButtonDot = new RadioButton();
            radioButtonSolid = new RadioButton();
            labelDashStyle = new Label();
            numericUpDownLineWidth = new NumericUpDown();
            labelLineWidth = new Label();
            btnColorFill = new Button();
            btnColorLine = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCanvas).BeginInit();
            panelTools.SuspendLayout();
            groupBoxFourier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPhase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFrequency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHarmonics).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLineWidth).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxCanvas
            // 
            pictureBoxCanvas.BackColor = Color.White;
            pictureBoxCanvas.Dock = DockStyle.Fill;
            pictureBoxCanvas.Location = new Point(217, 0);
            pictureBoxCanvas.Name = "pictureBoxCanvas";
            pictureBoxCanvas.Size = new Size(932, 874);
            pictureBoxCanvas.TabIndex = 0;
            pictureBoxCanvas.TabStop = false;
            pictureBoxCanvas.MouseDown += pictureBoxCanvas_MouseDown;
            pictureBoxCanvas.MouseMove += pictureBoxCanvas_MouseMove;
            pictureBoxCanvas.MouseUp += pictureBoxCanvas_MouseUp;
            // 
            // panelTools
            // 
            panelTools.BackColor = SystemColors.ControlLight;
            panelTools.Controls.Add(btnReturn);
            panelTools.Controls.Add(btnClearCanvas);
            panelTools.Controls.Add(groupBoxFourier);
            panelTools.Controls.Add(btnSave);
            panelTools.Controls.Add(radioButtonDashDot);
            panelTools.Controls.Add(radioButtonDash);
            panelTools.Controls.Add(btnOpen);
            panelTools.Controls.Add(radioButtonDot);
            panelTools.Controls.Add(radioButtonSolid);
            panelTools.Controls.Add(labelDashStyle);
            panelTools.Controls.Add(numericUpDownLineWidth);
            panelTools.Controls.Add(labelLineWidth);
            panelTools.Controls.Add(btnColorFill);
            panelTools.Controls.Add(btnColorLine);
            panelTools.Dock = DockStyle.Left;
            panelTools.Location = new Point(0, 0);
            panelTools.Name = "panelTools";
            panelTools.Size = new Size(217, 874);
            panelTools.TabIndex = 1;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(47, 801);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(112, 30);
            btnReturn.TabIndex = 14;
            btnReturn.Text = "Назад";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnClearCanvas
            // 
            btnClearCanvas.Location = new Point(47, 693);
            btnClearCanvas.Name = "btnClearCanvas";
            btnClearCanvas.Size = new Size(112, 30);
            btnClearCanvas.TabIndex = 13;
            btnClearCanvas.Text = "Очистить";
            btnClearCanvas.UseVisualStyleBackColor = true;
            btnClearCanvas.Click += btnClearCanvas_Click;
            // 
            // btnDrawFourier
            // 
            btnDrawFourier.Location = new Point(37, 317);
            btnDrawFourier.Name = "btnDrawFourier";
            btnDrawFourier.Size = new Size(110, 30);
            btnDrawFourier.TabIndex = 10;
            btnDrawFourier.Text = "Построить";
            btnDrawFourier.UseVisualStyleBackColor = true;
            btnDrawFourier.Click += btnDrawFourier_Click;
            // 
            // groupBoxFourier
            // 
            groupBoxFourier.Controls.Add(numericUpDownPhase);
            groupBoxFourier.Controls.Add(labelPhase);
            groupBoxFourier.Controls.Add(btnDrawFourier);
            groupBoxFourier.Controls.Add(numericUpDownFrequency);
            groupBoxFourier.Controls.Add(labelFrequency);
            groupBoxFourier.Controls.Add(radioButtonSawtooth);
            groupBoxFourier.Controls.Add(radioButtonTriangle);
            groupBoxFourier.Controls.Add(radioButtonSquare);
            groupBoxFourier.Controls.Add(labelHarmonics);
            groupBoxFourier.Controls.Add(numericUpDownHarmonics);
            groupBoxFourier.Location = new Point(10, 307);
            groupBoxFourier.Name = "groupBoxFourier";
            groupBoxFourier.Size = new Size(201, 352);
            groupBoxFourier.TabIndex = 9;
            groupBoxFourier.TabStop = false;
            groupBoxFourier.Text = "Сигнал Фурье";
            groupBoxFourier.Enter += groupBoxFourier_Enter;
            // 
            // numericUpDownPhase
            // 
            numericUpDownPhase.Location = new Point(10, 277);
            numericUpDownPhase.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDownPhase.Minimum = new decimal(new int[] { 360, 0, 0, int.MinValue });
            numericUpDownPhase.Name = "numericUpDownPhase";
            numericUpDownPhase.Size = new Size(160, 31);
            numericUpDownPhase.TabIndex = 12;
            numericUpDownPhase.ValueChanged += numericUpDownPhase_ValueChanged;
            // 
            // labelPhase
            // 
            labelPhase.AutoSize = true;
            labelPhase.Location = new Point(10, 251);
            labelPhase.Name = "labelPhase";
            labelPhase.Size = new Size(137, 25);
            labelPhase.TabIndex = 11;
            labelPhase.Text = "Фаза (градусы):";
            // 
            // numericUpDownFrequency
            // 
            numericUpDownFrequency.DecimalPlaces = 2;
            numericUpDownFrequency.Location = new Point(10, 221);
            numericUpDownFrequency.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownFrequency.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownFrequency.Name = "numericUpDownFrequency";
            numericUpDownFrequency.Size = new Size(160, 31);
            numericUpDownFrequency.TabIndex = 10;
            numericUpDownFrequency.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownFrequency.ValueChanged += numericUpDownFrequency_ValueChanged;
            // 
            // labelFrequency
            // 
            labelFrequency.AutoSize = true;
            labelFrequency.Location = new Point(10, 191);
            labelFrequency.Name = "labelFrequency";
            labelFrequency.Size = new Size(146, 25);
            labelFrequency.TabIndex = 9;
            labelFrequency.Text = "Частота сигнала:";
            // 
            // radioButtonSawtooth
            // 
            radioButtonSawtooth.AutoSize = true;
            radioButtonSawtooth.Location = new Point(10, 86);
            radioButtonSawtooth.Name = "radioButtonSawtooth";
            radioButtonSawtooth.Size = new Size(157, 29);
            radioButtonSawtooth.TabIndex = 6;
            radioButtonSawtooth.TabStop = true;
            radioButtonSawtooth.Text = "Пилообразная";
            radioButtonSawtooth.UseVisualStyleBackColor = true;
            radioButtonSawtooth.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonTriangle
            // 
            radioButtonTriangle.AutoSize = true;
            radioButtonTriangle.Location = new Point(10, 56);
            radioButtonTriangle.Name = "radioButtonTriangle";
            radioButtonTriangle.Size = new Size(139, 29);
            radioButtonTriangle.TabIndex = 5;
            radioButtonTriangle.TabStop = true;
            radioButtonTriangle.Text = "Треугольная";
            radioButtonTriangle.UseVisualStyleBackColor = true;
            radioButtonTriangle.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonSquare
            // 
            radioButtonSquare.AutoSize = true;
            radioButtonSquare.Location = new Point(10, 27);
            radioButtonSquare.Name = "radioButtonSquare";
            radioButtonSquare.Size = new Size(167, 29);
            radioButtonSquare.TabIndex = 4;
            radioButtonSquare.TabStop = true;
            radioButtonSquare.Text = "Прямоугольная";
            radioButtonSquare.UseVisualStyleBackColor = true;
            radioButtonSquare.CheckedChanged += radioButton_CheckedChanged;
            // 
            // labelHarmonics
            // 
            labelHarmonics.AutoSize = true;
            labelHarmonics.Location = new Point(0, 121);
            labelHarmonics.Name = "labelHarmonics";
            labelHarmonics.Size = new Size(196, 25);
            labelHarmonics.TabIndex = 3;
            labelHarmonics.Text = "Количество гармоник:";
            // 
            // numericUpDownHarmonics
            // 
            numericUpDownHarmonics.Location = new Point(10, 154);
            numericUpDownHarmonics.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownHarmonics.Name = "numericUpDownHarmonics";
            numericUpDownHarmonics.Size = new Size(160, 31);
            numericUpDownHarmonics.TabIndex = 2;
            numericUpDownHarmonics.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.Location = new Point(45, 729);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 30);
            btnSave.TabIndex = 8;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(47, 765);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(112, 30);
            btnOpen.TabIndex = 7;
            btnOpen.Text = "Открыть";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // radioButtonDashDot
            // 
            radioButtonDashDot.AutoSize = true;
            radioButtonDashDot.Location = new Point(9, 166);
            radioButtonDashDot.Name = "radioButtonDashDot";
            radioButtonDashDot.Size = new Size(184, 29);
            radioButtonDashDot.TabIndex = 8;
            radioButtonDashDot.TabStop = true;
            radioButtonDashDot.Text = "Штрихпунктирная";
            radioButtonDashDot.UseVisualStyleBackColor = true;
            radioButtonDashDot.CheckedChanged += radioButtonDashStyle_CheckedChanged;
            // 
            // radioButtonDash
            // 
            radioButtonDash.AutoSize = true;
            radioButtonDash.Location = new Point(10, 136);
            radioButtonDash.Name = "radioButtonDash";
            radioButtonDash.Size = new Size(129, 29);
            radioButtonDash.TabIndex = 7;
            radioButtonDash.TabStop = true;
            radioButtonDash.Text = "Штриховая";
            radioButtonDash.UseVisualStyleBackColor = true;
            radioButtonDash.CheckedChanged += radioButtonDashStyle_CheckedChanged;
            // 
            // radioButtonDot
            // 
            radioButtonDot.AutoSize = true;
            radioButtonDot.Location = new Point(10, 106);
            radioButtonDot.Name = "radioButtonDot";
            radioButtonDot.Size = new Size(114, 29);
            radioButtonDot.TabIndex = 6;
            radioButtonDot.TabStop = true;
            radioButtonDot.Text = "Точечная";
            radioButtonDot.UseVisualStyleBackColor = true;
            radioButtonDot.CheckedChanged += radioButtonDashStyle_CheckedChanged;
            // 
            // radioButtonSolid
            // 
            radioButtonSolid.AutoSize = true;
            radioButtonSolid.Location = new Point(10, 75);
            radioButtonSolid.Name = "radioButtonSolid";
            radioButtonSolid.Size = new Size(120, 29);
            radioButtonSolid.TabIndex = 5;
            radioButtonSolid.TabStop = true;
            radioButtonSolid.Text = "Сплошная";
            radioButtonSolid.UseVisualStyleBackColor = true;
            radioButtonSolid.CheckedChanged += radioButtonDashStyle_CheckedChanged;
            // 
            // labelDashStyle
            // 
            labelDashStyle.AutoSize = true;
            labelDashStyle.Location = new Point(10, 46);
            labelDashStyle.Name = "labelDashStyle";
            labelDashStyle.Size = new Size(99, 25);
            labelDashStyle.TabIndex = 4;
            labelDashStyle.Text = "Тип линии:";
            // 
            // numericUpDownLineWidth
            // 
            numericUpDownLineWidth.Location = new Point(10, 268);
            numericUpDownLineWidth.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownLineWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownLineWidth.Name = "numericUpDownLineWidth";
            numericUpDownLineWidth.Size = new Size(180, 31);
            numericUpDownLineWidth.TabIndex = 3;
            numericUpDownLineWidth.Value = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDownLineWidth.ValueChanged += numericUpDownLineWidth_ValueChanged;
            // 
            // labelLineWidth
            // 
            labelLineWidth.AutoSize = true;
            labelLineWidth.Location = new Point(16, 240);
            labelLineWidth.Name = "labelLineWidth";
            labelLineWidth.Size = new Size(137, 25);
            labelLineWidth.TabIndex = 2;
            labelLineWidth.Text = "Ширина линии:";
            // 
            // btnColorFill
            // 
            btnColorFill.Location = new Point(12, 201);
            btnColorFill.Name = "btnColorFill";
            btnColorFill.Size = new Size(180, 30);
            btnColorFill.TabIndex = 1;
            btnColorFill.Text = "Цвет заливки";
            btnColorFill.UseVisualStyleBackColor = true;
            btnColorFill.Click += btnColorFill_Click;
            // 
            // btnColorLine
            // 
            btnColorLine.Location = new Point(10, 10);
            btnColorLine.Name = "btnColorLine";
            btnColorLine.Size = new Size(180, 30);
            btnColorLine.TabIndex = 0;
            btnColorLine.Text = "Цвет линии";
            btnColorLine.UseVisualStyleBackColor = true;
            btnColorLine.Click += btnColorLine_Click;
            // 
            // Part1Form
            // 
            ClientSize = new Size(1149, 874);
            Controls.Add(pictureBoxCanvas);
            Controls.Add(panelTools);
            Name = "Part1Form";
            Text = "Часть 1 - Графический редактор";
            ((System.ComponentModel.ISupportInitialize)pictureBoxCanvas).EndInit();
            panelTools.ResumeLayout(false);
            panelTools.PerformLayout();
            groupBoxFourier.ResumeLayout(false);
            groupBoxFourier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPhase).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFrequency).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHarmonics).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLineWidth).EndInit();
            ResumeLayout(false);
        }
    }
}
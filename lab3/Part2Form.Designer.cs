// Part2Form.Designer.cs
using System.Windows.Forms;

namespace lab3
{
    partial class Part2Form
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbFractalType;
        private Label lblFractalType;
        private NumericUpDown numRecursionDepth;
        private Label lblRecursionDepth;
        private PictureBox pictureBoxFractal;
        private ProgressBar progressBar;
        private Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                cancellationTokenSource?.Cancel();
                cancellationTokenSource?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbFractalType = new System.Windows.Forms.ComboBox();
            this.lblFractalType = new System.Windows.Forms.Label();
            this.numRecursionDepth = new System.Windows.Forms.NumericUpDown();
            this.lblRecursionDepth = new System.Windows.Forms.Label();
            this.pictureBoxFractal = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRecursionDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFractal)).BeginInit();
            this.SuspendLayout();
            this.cmbFractalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFractalType.FormattingEnabled = true;
            this.cmbFractalType.Items.AddRange(new object[] {
            "Дерево Пифагора",
            "Салфетка Серпинского",
            "Треугольник Серпинского"});
            this.cmbFractalType.Location = new System.Drawing.Point(20, 30);
            this.cmbFractalType.Name = "cmbFractalType";
            this.cmbFractalType.Size = new System.Drawing.Size(200, 24);
            this.cmbFractalType.TabIndex = 0;
            this.cmbFractalType.SelectedIndexChanged += new System.EventHandler(this.cmbFractalType_SelectedIndexChanged);
            this.lblFractalType.AutoSize = true;
            this.lblFractalType.Location = new System.Drawing.Point(20, 10);
            this.lblFractalType.Name = "lblFractalType";
            this.lblFractalType.Size = new System.Drawing.Size(111, 17);
            this.lblFractalType.TabIndex = 1;
            this.lblFractalType.Text = "Тип фрактала:";
            this.numRecursionDepth.Location = new System.Drawing.Point(250, 30);
            this.numRecursionDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRecursionDepth.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numRecursionDepth.Name = "numRecursionDepth";
            this.numRecursionDepth.Size = new System.Drawing.Size(60, 22);
            this.numRecursionDepth.TabIndex = 2;
            this.numRecursionDepth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRecursionDepth.ValueChanged += new System.EventHandler(this.numRecursionDepth_ValueChanged);
            this.lblRecursionDepth.AutoSize = true;
            this.lblRecursionDepth.Location = new System.Drawing.Point(250, 10);
            this.lblRecursionDepth.Name = "lblRecursionDepth";
            this.lblRecursionDepth.Size = new System.Drawing.Size(145, 17);
            this.lblRecursionDepth.TabIndex = 3;
            this.lblRecursionDepth.Text = "Глубина рекурсии:";
            this.pictureBoxFractal.BackColor = System.Drawing.Color.White;
            this.pictureBoxFractal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                                                                               | System.Windows.Forms.AnchorStyles.Left) 
                                                                               | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxFractal.Location = new System.Drawing.Point(20, 70);
            this.pictureBoxFractal.Name = "pictureBoxFractal";
            this.pictureBoxFractal.Size = new System.Drawing.Size(760, 480);
            this.pictureBoxFractal.TabIndex = 4;
            this.pictureBoxFractal.TabStop = false;
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                                                                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(20, 570);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(760, 23);
            this.progressBar.TabIndex = 5;
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(700, 25);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pictureBoxFractal);
            this.Controls.Add(this.lblRecursionDepth);
            this.Controls.Add(this.numRecursionDepth);
            this.Controls.Add(this.lblFractalType);
            this.Controls.Add(this.cmbFractalType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "Part2Form";
            this.Text = "Часть 2 - Фракталы и Рекурсия";
            this.Load += new System.EventHandler(this.Part2Form_Load);
            this.Resize += new System.EventHandler(this.Part2Form_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numRecursionDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFractal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

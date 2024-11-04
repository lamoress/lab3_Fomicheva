using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Part1Form : Form
    {
        private Bitmap originalBitmap;
        private bool isDrawing = false;
        private Point previousPoint;
        private Color lineColor = Color.Black;
        private Color fillColor = Color.Transparent;
        private float lineWidth = 2f;
        private DashStyle dashStyle = DashStyle.Solid;
        private string fourierShape = "Пилообразная";
        private int harmonics = 10;
        private double frequency = 1.0;
        private double phaseShift = 0.0;

        private const int leftMargin = 50;
        private const int rightMargin = 50;

        public Part1Form()
        {
            InitializeComponent();
            InitializeCanvas();
            this.Resize += Part1Form_Resize;
            this.FormClosing += Part1Form_FormClosing;
            radioButtonSawtooth.Checked = true;
            radioButtonSolid.Checked = true;
            numericUpDownFrequency.Value = (decimal)frequency;
            numericUpDownPhase.Value = (decimal)(phaseShift * (180.0 / Math.PI));
            numericUpDownHarmonics.Value = harmonics;

            numericUpDownHarmonics.ValueChanged += numericUpDownHarmonics_ValueChanged;
            numericUpDownFrequency.ValueChanged += numericUpDownFrequency_ValueChanged;
            numericUpDownPhase.ValueChanged += numericUpDownPhase_ValueChanged;
            radioButtonSquare.CheckedChanged += radioButton_CheckedChanged;
            radioButtonTriangle.CheckedChanged += radioButton_CheckedChanged;
            radioButtonSawtooth.CheckedChanged += radioButton_CheckedChanged;
        }

        private void InitializeCanvas()
        {
            originalBitmap = new Bitmap(pictureBoxCanvas.Width, pictureBoxCanvas.Height);
            using (Graphics g = Graphics.FromImage(originalBitmap))
            {
                g.Clear(Color.White);
            }
            pictureBoxCanvas.Image = originalBitmap;
            pictureBoxCanvas.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Part1Form_Resize(object sender, EventArgs e)
        {
            pictureBoxCanvas.Invalidate();
        }

        private void Part1Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            originalBitmap?.Dispose();
        }

        private void btnColorLine_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.Color = lineColor;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    lineColor = dlg.Color;
                }
            }
        }

        private void btnColorFill_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.Color = fillColor;
                dlg.FullOpen = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    fillColor = dlg.Color;
                }
            }
        }

        private void numericUpDownLineWidth_ValueChanged(object sender, EventArgs e)
        {
            lineWidth = (float)numericUpDownLineWidth.Value;
        }

        private void radioButtonDashStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSolid.Checked)
            {
                dashStyle = DashStyle.Solid;
            }
            else if (radioButtonDot.Checked)
            {
                dashStyle = DashStyle.Dot;
            }
            else if (radioButtonDash.Checked)
            {
                dashStyle = DashStyle.Dash;
            }
            else if (radioButtonDashDot.Checked)
            {
                dashStyle = DashStyle.DashDot;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Изображения (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        using (Bitmap loadedBitmap = new Bitmap(dlg.FileName))
                        {
                            originalBitmap.Dispose();
                            originalBitmap = new Bitmap(loadedBitmap, pictureBoxCanvas.Width, pictureBoxCanvas.Height);
                            pictureBoxCanvas.Image = originalBitmap;
                        }
                        pictureBoxCanvas.Invalidate();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при открытии изображения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                    dlg.DefaultExt = "png";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        originalBitmap.Save(dlg.FileName);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при сохранении изображения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearCanvas_Click(object sender, EventArgs e)
        {
            try
            {
                using (Graphics g = Graphics.FromImage(originalBitmap))
                {
                    g.Clear(Color.White);
                }
                pictureBoxCanvas.Invalidate();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при очистке холста.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                previousPoint = TranslatePoint(e.Location);
            }
        }

        private void pictureBoxCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point currentPoint = TranslatePoint(e.Location);
                using (Graphics g = Graphics.FromImage(originalBitmap))
                {
                    using (Pen pen = new Pen(lineColor, lineWidth) { DashStyle = dashStyle })
                    {
                        g.DrawLine(pen, previousPoint, currentPoint);
                    }
                }
                previousPoint = currentPoint;
                pictureBoxCanvas.Invalidate();
            }
        }

        private void pictureBoxCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
        }

        private Point TranslatePoint(Point p)
        {
            if (pictureBoxCanvas.Image == null)
                return p;

            float imageWidth = originalBitmap.Width;
            float imageHeight = originalBitmap.Height;
            float pbWidth = pictureBoxCanvas.Width;
            float pbHeight = pictureBoxCanvas.Height;

            float scaleX = imageWidth / pbWidth;
            float scaleY = imageHeight / pbHeight;

            return new Point((int)(p.X * scaleX), (int)(p.Y * scaleY));
        }

        private async void btnDrawFourier_Click(object sender, EventArgs e)
        {
            try
            {
                btnDrawFourier.Enabled = false;
                await Task.Run(() => DrawFourierSignal());
                btnDrawFourier.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при отрисовке сигнала Фурье.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDrawFourier.Enabled = true;
            }
        }

        private void DrawFourierSignal()
        {
            Bitmap tempBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);
            using (Graphics g = Graphics.FromImage(tempBitmap))
            {
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                int width = tempBitmap.Width;
                int height = tempBitmap.Height;

                DrawAxes(g, width, height);

                PointF[] points = new PointF[width];
                for (int x = leftMargin; x < width - rightMargin; x++)
                {
                    double t = 2 * Math.PI * frequency * ((x - leftMargin) / (double)(width - leftMargin - rightMargin)) + phaseShift;
                    double y = ComputeFourierSeriesIterative(t, harmonics);

                    y = Math.Max(-1.0, Math.Min(1.0, y));

                    points[x] = new PointF(x, (float)(height / 2 * (1 - y)));
                }

                if (fillColor != Color.Transparent)
                {
                    PointF[] fillPoints = new PointF[(width - leftMargin - rightMargin) + 2];
                    fillPoints[0] = new PointF(leftMargin, height / 2);
                    for (int x = leftMargin; x < width - rightMargin; x++)
                    {
                        fillPoints[x - leftMargin + 1] = points[x];
                    }
                    fillPoints[(width - leftMargin - rightMargin) + 1] = new PointF(width - rightMargin - 1, height / 2);

                    using (SolidBrush brush = new SolidBrush(fillColor))
                    {
                        g.FillPolygon(brush, fillPoints);
                    }
                }

                using (Pen pen = new Pen(lineColor, lineWidth) { DashStyle = dashStyle })
                {
                    for (int x = leftMargin + 1; x < width - rightMargin; x++)
                    {
                        g.DrawLine(pen, points[x - 1], points[x]);
                    }
                }
            }

            if (pictureBoxCanvas.InvokeRequired)
            {
                pictureBoxCanvas.Invoke(new Action(() =>
                {
                    originalBitmap.Dispose();
                    originalBitmap = new Bitmap(tempBitmap);
                    pictureBoxCanvas.Image = originalBitmap;
                    pictureBoxCanvas.Invalidate();
                }));
            }
            else
            {
                originalBitmap.Dispose();
                originalBitmap = new Bitmap(tempBitmap);
                pictureBoxCanvas.Image = originalBitmap;
                pictureBoxCanvas.Invalidate();
            }

            tempBitmap.Dispose();
        }

        private double ComputeFourierSeriesIterative(double t, int n)
        {
            double y = 0.0;
            for (int i = 1; i <= n; i++)
            {
                double amplitude = GetAmplitude(i);
                y += amplitude * Math.Sin(i * t);
            }
            return y;
        }

        private double GetAmplitude(int n)
        {
            switch (fourierShape)
            {
                case "Прямоугольная":
                    if (n % 2 == 1)
                    {
                        return (4.0 / Math.PI) * (1.0 / n);
                    }
                    else
                    {
                        return 0;
                    }
                case "Треугольная":
                    if (n % 2 == 1)
                    {
                        double sign = ((n % 4) == 1) ? 1 : -1;
                        return sign * (8.0 / (Math.PI * Math.PI)) * (1.0 / (n * n));
                    }
                    else
                    {
                        return 0;
                    }
                case "Пилообразная":
                default:
                    return (2.0 / Math.PI) * (1.0 / n);
            }
        }

        private void DrawAxes(Graphics g, int width, int height)
        {
            using (Pen axisPen = new Pen(Color.Black, 1))
            {
                g.DrawLine(axisPen, leftMargin, height / 2, width - rightMargin, height / 2);
                g.DrawLine(axisPen, leftMargin, 20, leftMargin, height - 20);

                int numXTicks = 10;
                for (int i = 0; i <= numXTicks; i++)
                {
                    int x = leftMargin + i * (width - leftMargin - rightMargin) / numXTicks;
                    int y = height / 2;
                    g.DrawLine(axisPen, x, y - 5, x, y + 5);
                    string label = (i / (double)numXTicks).ToString("0.0");
                    SizeF labelSize = g.MeasureString(label, this.Font);
                    g.DrawString(label, this.Font, Brushes.Black, x - labelSize.Width / 2, y + 5);
                }

                int numYTicks = 4;
                for (int i = -numYTicks; i <= numYTicks; i++)
                {
                    int y = height / 2 - i * (height / 2 - 20) / numYTicks;
                    int x = leftMargin;
                    g.DrawLine(axisPen, x - 5, y, x + 5, y);
                    string label = (i / (double)numYTicks).ToString("0.0");
                    SizeF labelSize = g.MeasureString(label, this.Font);
                    g.DrawString(label, this.Font, Brushes.Black, x - labelSize.Width - 5, y - labelSize.Height / 2);
                }
            }
        }

        private void numericUpDownFrequency_ValueChanged(object sender, EventArgs e)
        {
            frequency = (double)numericUpDownFrequency.Value;
            btnDrawFourier_Click(sender, e);
        }

        private void numericUpDownPhase_ValueChanged(object sender, EventArgs e)
        {
            phaseShift = (double)numericUpDownPhase.Value * Math.PI / 180.0;
            btnDrawFourier_Click(sender, e);
        }

        private void numericUpDownHarmonics_ValueChanged(object sender, EventArgs e)
        {
            harmonics = (int)numericUpDownHarmonics.Value;
            btnDrawFourier_Click(sender, e);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSquare.Checked)
            {
                fourierShape = "Прямоугольная";
            }
            else if (radioButtonTriangle.Checked)
            {
                fourierShape = "Треугольная";
            }
            else if (radioButtonSawtooth.Checked)
            {
                fourierShape = "Пилообразная";
            }
            btnDrawFourier_Click(sender, e);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBoxFourier_Enter(object sender, EventArgs e)
        {
        }
    }
}

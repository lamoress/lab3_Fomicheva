using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Part2Form : Form
    {
        private CancellationTokenSource cancellationTokenSource;

        public Part2Form()
        {
            InitializeComponent();
        }

        private void Part2Form_Load(object sender, EventArgs e)
        {
            cmbFractalType.SelectedIndex = 0; // Выбираем первый фрактал по умолчанию
            DrawFractalAsync();
        }

        private async void DrawFractalAsync()
        {
            try
            {
                cancellationTokenSource?.Cancel();
                cancellationTokenSource = new CancellationTokenSource();
                var token = cancellationTokenSource.Token;

                string fractalType = cmbFractalType.SelectedItem.ToString();
                int depth = (int)numRecursionDepth.Value;

                int width = pictureBoxFractal.Width;
                int height = pictureBoxFractal.Height;

                pictureBoxFractal.Image = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(pictureBoxFractal.Image))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.Clear(Color.White);
                }

                progressBar.Style = ProgressBarStyle.Marquee;
                await Task.Run(() =>
                {
                    using (Graphics g = Graphics.FromImage(pictureBoxFractal.Image))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        if (fractalType == "Дерево Пифагора")
                        {
                            float startX = width / 2;
                            float startY = height - 50;
                            float size = height / 4;
                            double angle = -90;
                            DrawPythagorasTree(g, depth, startX, startY, size, angle, depth);
                        }
                        else if (fractalType == "Салфетка Серпинского")
                        {
                            float startX = width * 0.05f;
                            float startY = height * 0.05f;
                            float size = Math.Min(width, height) * 0.9f;
                            DrawSierpinskiCarpet(g, depth, startX, startY, size, depth);
                        }
                    }
                }, token);
                progressBar.Style = ProgressBarStyle.Blocks;
                pictureBoxFractal.Refresh();
            }
            catch (OperationCanceledException)
            {
                // Операция была отменена, ничего не делаем
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                MessageBox.Show("Произошла ошибка при отрисовке фрактала.");
            }
        }

        private void cmbFractalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawFractalAsync();
        }

        private void numRecursionDepth_ValueChanged(object sender, EventArgs e)
        {
            DrawFractalAsync();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Part2Form_Resize(object sender, EventArgs e)
        {
            DrawFractalAsync();
        }

        #region Фракталы

        private void DrawPythagorasTree(Graphics g, int depth, float x, float y, float size, double angle, int maxDepth)
        {
            if (depth == 0)
                return;

            float xEnd = x + size * (float)Math.Cos(angle * Math.PI / 180);
            float yEnd = y + size * (float)Math.Sin(angle * Math.PI / 180);

            using (Pen pen = new Pen(GetGradientColor(maxDepth - depth, maxDepth), 1)) // Толщина линии установлена в 1
            {
                g.DrawLine(pen, x, y, xEnd, yEnd);
            }

            DrawPythagorasTree(g, depth - 1, xEnd, yEnd, size * 0.7f, angle - 45, maxDepth);
            DrawPythagorasTree(g, depth - 1, xEnd, yEnd, size * 0.7f, angle + 45, maxDepth);
        }

        private void DrawSierpinskiCarpet(Graphics g, int depth, float x, float y, float size, int maxDepth)
        {
            if (depth == 0)
            {
                using (PathGradientBrush brush = new PathGradientBrush(new PointF[]
                {
                    new PointF(x, y),
                    new PointF(x + size, y),
                    new PointF(x + size, y + size),
                    new PointF(x, y + size)
                }))
                {
                    brush.CenterColor = Color.DarkOrchid;
                    brush.SurroundColors = new Color[] { Color.Aqua };
                    g.FillRectangle(brush, x, y, size, size);
                }
                return;
            }

            float newSize = size / 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 1 && j == 1)
                        continue;
                    DrawSierpinskiCarpet(g, depth - 1, x + i * newSize, y + j * newSize, newSize, maxDepth);
                }
            }
        }

        private Color GetGradientColor(int level, int maxDepth)
        {
            Color startColor = Color.DarkOrchid;
            Color endColor = Color.Aqua;

            float ratio = (float)level / maxDepth;
            int r = (int)(startColor.R * (1 - ratio) + endColor.R * ratio);
            int g = (int)(startColor.G * (1 - ratio) + endColor.G * ratio);
            int b = (int)(startColor.B * (1 - ratio) + endColor.B * ratio);

            return Color.FromArgb(r, g, b);
        }

        #endregion
    }
}

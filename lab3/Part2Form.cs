// Part2Form.cs
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
            numRecursionDepth.Maximum = 15;
        }

        private void Part2Form_Load(object sender, EventArgs e)
        {
            try
            {
                cmbFractalType.SelectedIndex = 0;
                _ = DrawFractalAsync();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                MessageBox.Show("Произошла ошибка при загрузке формы. См. лог для деталей.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DrawFractalAsync()
        {
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            try
            {
                string fractalType = cmbFractalType.SelectedItem?.ToString() ?? "Дерево Пифагора";
                int depth = (int)numRecursionDepth.Value;
                int width = pictureBoxFractal.Width;
                int height = pictureBoxFractal.Height;

                using Bitmap fractalBitmap = new Bitmap(width, height);
                using Graphics g = Graphics.FromImage(fractalBitmap);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                progressBar.Style = ProgressBarStyle.Marquee;

                await Task.Run(() =>
                {
                    if (fractalType == "Дерево Пифагора")
                        DrawPythagorasTree(g, depth, width / 2, height - 50, height / 4, -90, depth, token);
                    else if (fractalType == "Салфетка Серпинского")
                        DrawSierpinskiCarpet(g, depth, width * 0.05f, height * 0.05f, Math.Min(width, height) * 0.9f, depth, token);
                    else if (fractalType == "Треугольник Серпинского")
                        DrawSierpinskiTriangle(g, depth,
                            new PointF(width / 2, height * 0.05f),
                            new PointF(width * 0.05f, height * 0.95f),
                            new PointF(width * 0.95f, height * 0.95f),
                            depth, token);
                }, token);

                progressBar.Style = ProgressBarStyle.Blocks;

                if (!token.IsCancellationRequested)
                {
                    pictureBoxFractal.Image?.Dispose();
                    pictureBoxFractal.Image = new Bitmap(fractalBitmap);
                    pictureBoxFractal.Refresh();
                }
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                MessageBox.Show("Произошла ошибка при рисовании фрактала. См. лог для деталей.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar.Style = ProgressBarStyle.Blocks;
            }
        }

        private void cmbFractalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ = DrawFractalAsync();
        }

        private void numRecursionDepth_ValueChanged(object sender, EventArgs e)
        {
            _ = DrawFractalAsync();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Part2Form_Resize(object sender, EventArgs e)
        {
            _ = DrawFractalAsync();
        }

        private void DrawPythagorasTree(Graphics g, int depth, float x, float y, float size, double angle, int maxDepth, CancellationToken token)
        {
            if (depth == 0 || token.IsCancellationRequested) return;

            float xEnd = x + size * (float)Math.Cos(angle * Math.PI / 180);
            float yEnd = y + size * (float)Math.Sin(angle * Math.PI / 180);

            using (Pen pen = new Pen(GetGradientColor(depth, maxDepth), 1))
                g.DrawLine(pen, x, y, xEnd, yEnd);

            DrawPythagorasTree(g, depth - 1, xEnd, yEnd, size * 0.7f, angle - 45, maxDepth, token);
            DrawPythagorasTree(g, depth - 1, xEnd, yEnd, size * 0.7f, angle + 45, maxDepth, token);
        }

        private void DrawSierpinskiCarpet(Graphics g, int depth, float x, float y, float size, int maxDepth, CancellationToken token)
        {
            if (depth == 0 || token.IsCancellationRequested)
            {
                using (Brush brush = new SolidBrush(GetGradientColor(depth, maxDepth)))
                    g.FillRectangle(brush, x, y, size, size);
                return;
            }

            float newSize = size / 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (i != 1 || j != 1)
                        DrawSierpinskiCarpet(g, depth - 1, x + i * newSize, y + j * newSize, newSize, maxDepth, token);
        }

        private void DrawSierpinskiTriangle(Graphics g, int depth, PointF a, PointF b, PointF c, int maxDepth, CancellationToken token)
        {
            if (depth == 0 || token.IsCancellationRequested)
            {
                using (Brush brush = new SolidBrush(GetGradientColor(depth, maxDepth)))
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    PointF[] points = { a, b, c };
                    g.FillPolygon(brush, points);
                    g.DrawPolygon(pen, points);
                }
                return;
            }

            PointF ab = MidPoint(a, b);
            PointF bc = MidPoint(b, c);
            PointF ca = MidPoint(c, a);

            using (Brush brush = new SolidBrush(Color.White))
                g.FillPolygon(brush, new PointF[] { ab, bc, ca });

            DrawSierpinskiTriangle(g, depth - 1, a, ab, ca, maxDepth, token);
            DrawSierpinskiTriangle(g, depth - 1, ab, b, bc, maxDepth, token);
            DrawSierpinskiTriangle(g, depth - 1, ca, bc, c, maxDepth, token);
        }

        private PointF MidPoint(PointF p1, PointF p2) => new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);

        private Color GetGradientColor(int level, int maxDepth)
        {
            Color startColor = Color.DarkOrchid;
            Color endColor = Color.Aqua;
            float ratio = (float)(maxDepth - level) / maxDepth;
            return Color.FromArgb(
                (int)(startColor.R * ratio + endColor.R * (1 - ratio)),
                (int)(startColor.G * ratio + endColor.G * (1 - ratio)),
                (int)(startColor.B * ratio + endColor.B * (1 - ratio)));
        }
    }
}

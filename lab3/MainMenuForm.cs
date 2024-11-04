using System;
using System.Windows.Forms;

namespace lab3
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnPart1_Click(object sender, EventArgs e)
        {
            var part1Form = new Part1Form();
            part1Form.Show();
        }


        private void btnPart2_Click(object sender, EventArgs e)
        {
            var part1Form = new Part2Form();
            part1Form.Show();
        }

        private void btnOpenLog_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad.exe", ExceptionLogger.LogFilePath);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                MessageBox.Show("Не удалось открыть файл лога.");
            }
        }
    }
}
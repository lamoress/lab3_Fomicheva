namespace lab3
{
    partial class MainMenu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnPart1;
        private System.Windows.Forms.Button btnPart2; // Новая кнопка
        private System.Windows.Forms.Button btnOpenLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.btnPart1 = new System.Windows.Forms.Button();
            this.btnPart2 = new System.Windows.Forms.Button(); // Инициализация
            this.btnOpenLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPart1
            // 
            this.btnPart1.Location = new System.Drawing.Point(50, 30);
            this.btnPart1.Name = "btnPart1";
            this.btnPart1.Size = new System.Drawing.Size(200, 50);
            this.btnPart1.TabIndex = 0;
            this.btnPart1.Text = "Часть 1";
            this.btnPart1.UseVisualStyleBackColor = true;
            this.btnPart1.Click += new System.EventHandler(this.btnPart1_Click);
            // 
            // btnPart2
            // 
            this.btnPart2.Location = new System.Drawing.Point(50, 90);
            this.btnPart2.Name = "btnPart2";
            this.btnPart2.Size = new System.Drawing.Size(200, 50);
            this.btnPart2.TabIndex = 1;
            this.btnPart2.Text = "Часть 2";
            this.btnPart2.UseVisualStyleBackColor = true;
            this.btnPart2.Click += new System.EventHandler(this.btnPart2_Click);
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Location = new System.Drawing.Point(50, 150);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(200, 50);
            this.btnOpenLog.TabIndex = 2;
            this.btnOpenLog.Text = "Открыть лог";
            this.btnOpenLog.UseVisualStyleBackColor = true;
            this.btnOpenLog.Click += new System.EventHandler(this.btnOpenLog_Click);
            // 
            // MainMenu
            // 
            this.ClientSize = new System.Drawing.Size(300, 230);
            this.Controls.Add(this.btnOpenLog);
            this.Controls.Add(this.btnPart2);
            this.Controls.Add(this.btnPart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Text = "Главное меню";
            this.ResumeLayout(false);
        }
    }
}

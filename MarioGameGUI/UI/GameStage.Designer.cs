namespace MarioGameGUI
{
    partial class GameStage
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MarioHealth = new System.Windows.Forms.ProgressBar();
            this.M_Health = new System.Windows.Forms.Label();
            this.MarioScore = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 70;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MarioHealth
            // 
            this.MarioHealth.Location = new System.Drawing.Point(1228, 625);
            this.MarioHealth.Name = "MarioHealth";
            this.MarioHealth.Size = new System.Drawing.Size(231, 27);
            this.MarioHealth.TabIndex = 0;
            // 
            // M_Health
            // 
            this.M_Health.AutoSize = true;
            this.M_Health.BackColor = System.Drawing.Color.Transparent;
            this.M_Health.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M_Health.Location = new System.Drawing.Point(1270, 655);
            this.M_Health.Name = "M_Health";
            this.M_Health.Size = new System.Drawing.Size(141, 25);
            this.M_Health.TabIndex = 1;
            this.M_Health.Text = "Mario Health";
            // 
            // MarioScore
            // 
            this.MarioScore.AutoSize = true;
            this.MarioScore.BackColor = System.Drawing.Color.Transparent;
            this.MarioScore.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MarioScore.Location = new System.Drawing.Point(901, 652);
            this.MarioScore.Name = "MarioScore";
            this.MarioScore.Size = new System.Drawing.Size(120, 25);
            this.MarioScore.TabIndex = 2;
            this.MarioScore.Text = "Mario score";
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.BackColor = System.Drawing.Color.Transparent;
            this.Score.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.Location = new System.Drawing.Point(941, 627);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(22, 25);
            this.Score.TabIndex = 3;
            this.Score.Text = "0";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGreen;
            this.button1.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(66, 665);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 52);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start Over";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkGreen;
            this.button2.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(66, 607);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(248, 52);
            this.button2.TabIndex = 7;
            this.button2.Text = "Pause";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkGreen;
            this.button3.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(66, 723);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(243, 52);
            this.button3.TabIndex = 8;
            this.button3.Text = "Menu";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(365, 627);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Turtle Health";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(562, 622);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(231, 27);
            this.progressBar1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MarioGameGUI.Properties.Resources.sky;
            this.ClientSize = new System.Drawing.Size(1558, 818);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.MarioScore);
            this.Controls.Add(this.M_Health);
            this.Controls.Add(this.MarioHealth);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.UseWaitCursor = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar MarioHealth;
        private System.Windows.Forms.Label M_Health;
        private System.Windows.Forms.Label MarioScore;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}


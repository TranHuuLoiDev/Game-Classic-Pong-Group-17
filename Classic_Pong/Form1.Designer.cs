namespace Classic_Pong
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            player1 = new PictureBox();
            player2 = new PictureBox();
            Ball = new PictureBox();
            GameTimer = new System.Windows.Forms.Timer(components);
            startButton = new Button();
            pauseButton = new Button();
            resumeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)player1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Ball).BeginInit();
            SuspendLayout();
            // 
            // player1
            // 
            player1.BackColor = Color.Gainsboro;
            player1.Location = new Point(12, 145);
            player1.Margin = new Padding(3, 2, 3, 2);
            player1.Name = "player1";
            player1.Size = new Size(12, 120);
            player1.SizeMode = PictureBoxSizeMode.StretchImage;
            player1.TabIndex = 0;
            player1.TabStop = false;
            // 
            // player2
            // 
            player2.BackColor = Color.Gainsboro;
            player2.Location = new Point(920, 145);
            player2.Margin = new Padding(3, 2, 3, 2);
            player2.Name = "player2";
            player2.Size = new Size(12, 120);
            player2.SizeMode = PictureBoxSizeMode.StretchImage;
            player2.TabIndex = 1;
            player2.TabStop = false;
            player2.Click += player2_Click;
            // 
            // Ball
            // 
            Ball.BackColor = SystemColors.Control;
            Ball.InitialImage = Properties.Resources.ball;
            Ball.Location = new Point(455, 180);
            Ball.Margin = new Padding(3, 2, 3, 2);
            Ball.Name = "Ball";
            Ball.Size = new Size(18, 18);
            Ball.SizeMode = PictureBoxSizeMode.StretchImage;
            Ball.TabIndex = 2;
            Ball.TabStop = false;
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 20;
            GameTimer.Tick += GameTimerEvent;
            // 
            // startButton
            // 
            startButton.Image = (Image)resources.GetObject("startButton.Image");
            startButton.Location = new Point(272, 111);
            startButton.Name = "startButton";
            startButton.Size = new Size(384, 154);
            startButton.TabIndex = 3;
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.BackgroundImage = (Image)resources.GetObject("pauseButton.BackgroundImage");
            pauseButton.Location = new Point(412, 0);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(108, 38);
            pauseButton.TabIndex = 4;
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // resumeButton
            // 
            resumeButton.BackgroundImage = (Image)resources.GetObject("resumeButton.BackgroundImage");
            resumeButton.Location = new Point(421, 0);
            resumeButton.Name = "resumeButton";
            resumeButton.Size = new Size(88, 29);
            resumeButton.TabIndex = 5;
            resumeButton.UseVisualStyleBackColor = true;
            resumeButton.Click += resumeButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(944, 501);
            Controls.Add(resumeButton);
            Controls.Add(pauseButton);
            Controls.Add(startButton);
            Controls.Add(Ball);
            Controls.Add(player2);
            Controls.Add(player1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Classic Pong";
            Load += Form1_Load;
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)player1).EndInit();
            ((System.ComponentModel.ISupportInitialize)player2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Ball).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox player1;
        private PictureBox player2;
        private PictureBox Ball;
        private System.Windows.Forms.Timer GameTimer;
        private Button startButton;
        private Button pauseButton;
        private Button resumeButton;
    }
}

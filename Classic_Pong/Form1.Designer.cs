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
            ((System.ComponentModel.ISupportInitialize)player1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Ball).BeginInit();
            SuspendLayout();
            // 
            // player1
            // 
            player1.Image = Properties.Resources.player;
            player1.Location = new Point(35, 155);
            player1.Name = "player1";
            player1.Size = new Size(30, 120);
            player1.SizeMode = PictureBoxSizeMode.StretchImage;
            player1.TabIndex = 0;
            player1.TabStop = false;
            // 
            // player2
            // 
            player2.Image = (Image)resources.GetObject("player2.Image");
            player2.Location = new Point(722, 155);
            player2.Name = "player2";
            player2.Size = new Size(30, 120);
            player2.SizeMode = PictureBoxSizeMode.StretchImage;
            player2.TabIndex = 1;
            player2.TabStop = false;
            player2.Click += player2_Click;
            // 
            // Ball
            // 
            Ball.Image = Properties.Resources.ball;
            Ball.InitialImage = Properties.Resources.ball;
            Ball.Location = new Point(381, 198);
            Ball.Name = "Ball";
            Ball.Size = new Size(40, 39);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(800, 451);
            Controls.Add(Ball);
            Controls.Add(player2);
            Controls.Add(player1);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Player1: 0 -- Player2: 0";
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
    }
}

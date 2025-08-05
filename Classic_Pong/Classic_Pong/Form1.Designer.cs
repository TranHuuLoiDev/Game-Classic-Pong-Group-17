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
            player1.Location = new Point(31, 116);
            player1.Margin = new Padding(3, 2, 3, 2);
            player1.Name = "player1";
            player1.Size = new Size(26, 90);
            player1.SizeMode = PictureBoxSizeMode.StretchImage;
            player1.TabIndex = 0;
            player1.TabStop = false;
            // 
            // player2
            // 
            player2.Image = (Image)resources.GetObject("player2.Image");
            player2.Location = new Point(632, 116);
            player2.Margin = new Padding(3, 2, 3, 2);
            player2.Name = "player2";
            player2.Size = new Size(26, 90);
            player2.SizeMode = PictureBoxSizeMode.StretchImage;
            player2.TabIndex = 1;
            player2.TabStop = false;
            player2.Click += player2_Click;
            // 
            // Ball
            // 
            Ball.Image = Properties.Resources.ball;
            Ball.Location = new Point(336, 145);
            Ball.Margin = new Padding(3, 2, 3, 2);
            Ball.Name = "Ball";
            Ball.Size = new Size(26, 22);
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(700, 338);
            Controls.Add(Ball);
            Controls.Add(player2);
            Controls.Add(player1);
            DoubleBuffered = true;
            Margin = new Padding(3, 2, 3, 2);
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

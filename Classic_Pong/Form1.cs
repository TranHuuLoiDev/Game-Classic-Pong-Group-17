namespace Classic_Pong
{
    public partial class Form1 : Form
    {
        int BallXspeed = 4;
        int BallYspeed = 4;
        int player1Score = 0;
        int player2Score = 0;
        int playerSpeed = 8;
        Random rand = new Random();
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down)
            {
                return true; // ép form nhận phím ↑ ↓ như phím thường
            }
            return base.IsInputKey(keyData);
        }
        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Viền ngoài (nét liền, xanh neon)
            using (Pen borderPen = new Pen(Color.FromArgb(0, 255, 0), 3))
            {
                borderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid; // Nét liền
                g.DrawRectangle(borderPen, 0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
            }

            // Vạch giữa sân (nét đứt thưa hơn, xanh neon)
            using (Pen middleLinePen = new Pen(Color.FromArgb(0, 255, 0), 2))
            {
                middleLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                middleLinePen.DashPattern = new float[] { 10, 20 }; // 10 px vẽ, 20 px khoảng trống

                int middleX = this.ClientSize.Width / 2;
                g.DrawLine(middleLinePen, middleX, 0, middleX, this.ClientSize.Height);
            }
            // Bảng điểm số (vàng neon)
            // Bảng điểm số (vàng neon, font vuông)
            string scoreText = $"Player 1: {player1Score}         Player 2: {player2Score}"; // khoảng trắng thay "-"
            using (Font font = new Font("Consolas", 24, FontStyle.Bold)) // font vuông
            using (Brush brush = new SolidBrush(Color.FromArgb(255, 255, 100))) // vàng neon
            {
                SizeF textSize = g.MeasureString(scoreText, font);
                float x = (this.ClientSize.Width - textSize.Width) / 2;
                float y = 10; // cách trên cùng 10px
                g.DrawString(scoreText, font, brush, x, y);
            }

        }




        // Trạng thái phím
        bool goDown, goUp;
        bool p2GoDown, p2GoUp;

        int[] j = { 10, 9, 8, 11, 12 };

        public Form1()
        {
            InitializeComponent();


            // Bật Double Buffer để tránh nhấp nháy
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // Đăng ký sự kiện Paint
            this.Paint += Form1_Paint;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startButton.Visible = true;
            pauseButton.Visible = false;
            resumeButton.Visible = false;

            GameTimer.Stop();
            startButton.BringToFront();

            this.KeyDown += KeyIsDown;
            this.KeyUp += KeyIsUp;
            this.KeyPreview = true;
        }


        private void GameTimerEvent(object sender, EventArgs e)
        {
            Ball.Top -= BallYspeed;
            Ball.Left -= BallXspeed;

            this.Text = "Player 1: " + player1Score + " -- Player 2: " + player2Score;

            // Bóng chạm trên/dưới
            if (Ball.Top < 0 || Ball.Bottom > this.ClientSize.Height)
            {
                BallYspeed = -BallYspeed;
            }

            // Player 2 ghi bàn (bóng ra bên trái)
            if (Ball.Left < -2)
            {
                Ball.Left = 300;
                BallXspeed = -BallXspeed;
                player2Score++;
                this.Invalidate(); // ⚡ vẽ lại bảng neon
            }

            // Player 1 ghi bàn (bóng ra bên phải)
            if (Ball.Right > this.ClientSize.Width + 2)
            {
                Ball.Left = 300;
                BallXspeed = -BallXspeed;
                player1Score++;
                this.Invalidate(); // ⚡ vẽ lại bảng neon
            }

            // Giới hạn player 2 không vượt ra ngoài
            if (player2.Top <= 0)
            {
                player2.Top = 0;
            }
            else if (player2.Bottom >= this.ClientSize.Height)
            {
                player2.Top = this.ClientSize.Height - player2.Height;
            }

            // Player 1 điều khiển
            if (goDown && player1.Top + player1.Height < this.ClientSize.Height)
            {
                player1.Top += playerSpeed;
            }
            if (goUp && player1.Top > 0)
            {
                player1.Top -= playerSpeed;
            }

            // Player 2 điều khiển
            if (p2GoDown && player2.Top + player2.Height < this.ClientSize.Height)
            {
                player2.Top += playerSpeed;
            }
            if (p2GoUp && player2.Top > 0)
            {
                player2.Top -= playerSpeed;
            }

            // Kiểm tra va chạm
            CheckCollision(Ball, player1, player1.Right + 5);
            CheckCollision(Ball, player2, player2.Left - 35);

            // Kết thúc game
            if (player2Score > 5)
            {
                GameOver("Player 2 wins!");
            }
            else if (player1Score > 5)
            {
                GameOver("Player 1 wins!");
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // Player 1 (trái) dùng W/S
            if (e.KeyCode == Keys.W)
                goUp = true;
            if (e.KeyCode == Keys.S)
                goDown = true;

            // Player 2 (phải) dùng ↑/↓
            if (e.KeyCode == Keys.Up)
                p2GoUp = true;
            if (e.KeyCode == Keys.Down)
                p2GoDown = true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            // Player 1 (trái) dùng W/S
            if (e.KeyCode == Keys.W)
                goUp = false;
            if (e.KeyCode == Keys.S)
                goDown = false;

            // Player 2 (phải) dùng ↑/↓
            if (e.KeyCode == Keys.Up)
                p2GoUp = false;
            if (e.KeyCode == Keys.Down)
                p2GoDown = false;
        }

        private void CheckCollision(PictureBox PicOne, PictureBox PicTwo, int offset)
        {
            if (PicOne.Bounds.IntersectsWith(PicTwo.Bounds))
            {
                PicOne.Left = offset;
                int x = j[rand.Next(j.Length)];
                int y = j[rand.Next(j.Length)];

                if (BallXspeed < 0)
                    BallXspeed = x;
                else
                    BallXspeed = -x;

                if (BallYspeed < 0)
                    BallYspeed = -y;
                else
                    BallYspeed = y;
            }
        }

        private void GameOver(string message)
        {
            GameTimer.Stop();
            MessageBox.Show(message, "Game Over");
            player2Score = 0;
            player1Score = 0;
            BallXspeed = BallYspeed = 4;
            Ball.Left = 300;
            Ball.Top = 200;

            startButton.Visible = true;
        }

        private void player2_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Visible = false; // Ẩn nút khi game bắt đầu
            resumeButton.Visible = false;
            pauseButton.Visible = true;   // khi bắt đầu game thì hiện nút Pause

            // Reset điểm
            player1Score = 0;
            player2Score = 0;

            // Reset bóng
            Ball.Left = 300;
            Ball.Top = 200;
            BallXspeed = BallYspeed = 4;

            // Bắt đầu game
            GameTimer.Start();
            this.ActiveControl = null;

        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            GameTimer.Stop();            // ⏸ dừng game
            pauseButton.Visible = false; // ẩn Pause
            resumeButton.Visible = true; // hiện Resume
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            GameTimer.Start();            // ▶ tiếp tục game
            resumeButton.Visible = false; // ẩn Resume
            pauseButton.Visible = true;   // hiện Pause
        }
    }
}
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

        // Trạng thái phím
        bool goDown, goUp;
        bool p2GoDown, p2GoUp;

        int[] j = { 10, 9, 8, 11, 12 };

        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            }

            // Player 1 ghi bàn (bóng ra bên phải)
            if (Ball.Right > this.ClientSize.Width + 2)
            {
                Ball.Left = 300;
                BallXspeed = -BallXspeed;
                player1Score++;
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
            // Player 1
            if (e.KeyCode == Keys.Down)
                goDown = true;
            if (e.KeyCode == Keys.Up)
                goUp = true;

            // Player 2
            if (e.KeyCode == Keys.S)
                p2GoDown = true;
            if (e.KeyCode == Keys.W)
                p2GoUp = true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            // Player 1
            if (e.KeyCode == Keys.Down)
                goDown = false;
            if (e.KeyCode == Keys.Up)
                goUp = false;

            // Player 2
            if (e.KeyCode == Keys.S)
                p2GoDown = false;
            if (e.KeyCode == Keys.W)
                p2GoUp = false;
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
            GameTimer.Start();
        }

        private void player2_Click(object sender, EventArgs e)
        {

        }
    }
}
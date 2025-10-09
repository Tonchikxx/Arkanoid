using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid
{
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        private Paddle? paddle;
        private Ball? ball;
        private List<Block>? blocks;
        private Random? random;
        private int score;
        private bool gameRunning;
        private System.Windows.Forms.Timer? gameTimer;

        /// <summary>
        /// Инициализирует новый экземпляр главной формы игры
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeGame();
        }

        // Инициализирует или перезапускает игровой процесс
        private void InitializeGame()
        {
            DoubleBuffered = true;
            random = new Random();

            paddle = new Paddle();
            ball = new Ball();
            CreateBlocks();

            gameRunning = true;
            score = 0;

            SetupTimer();

            Paint += DrawGame;
            KeyDown += HandleInput;
            KeyPreview = true;
            Focus();
        }

        // Настраивает игровой таймер для обновления состояния игры
        private void SetupTimer()
        {
            if (gameTimer != null)
            {
                gameTimer.Stop();
                gameTimer.Dispose();
            }

            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = Constants.GameTimerInterval;
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
        }

        private void CreateBlocks()
        {
            blocks = new List<Block>();

            for (int row = 0; row < Constants.BlockRows; row++)
            {
                for (int col = 0; col < Constants.BlockCols; col++)
                {
                    var block = new Block(row, col);

                    if (random!.Next(0, 100) < Constants.PowerUpChance)
                    {
                        block.HasPowerUp = true;
                    }

                    blocks.Add(block);
                }
            }
        }

        // Основной игровой цикл, вызываемый таймером
        private void GameLoop(object? sender, EventArgs e)
        {
            if (!gameRunning) return;

            UpdateBall();
            CheckCollisions();
            CheckGameState();

            Invalidate(); 
        }

        private void UpdateBall()
        {
            ball!.Move();

            if (ball.HitLeftWall() || ball.HitRightWall())
                ball.ReverseX();

            if (ball.HitTopWall())
                ball.ReverseY();
        }

        private void CheckCollisions()
        {
            if (ball!.GetBounds().IntersectsWith(paddle!.GetBounds()))
            {
                ball.ReverseY();
                float hitPoint = (ball.X - paddle.X) / paddle.Width;
                ball.SpeedX = 8 * (hitPoint - 0.5f);
            }

            for (int i = blocks!.Count - 1; i >= 0; i--)
            {
                if (ball.GetBounds().IntersectsWith(blocks[i].GetBounds()))
                {
                    blocks[i].TakeDamage(ball.Damage);

                    if (blocks[i].IsDestroyed())
                    {
                        if (blocks[i].HasPowerUp)
                        {
                            ball.IncreaseDamage();
                        }
                        score += blocks[i].GetScoreValue();
                        blocks.RemoveAt(i);
                    }
                    else
                    {
                        ball.ReverseY();
                    }
                    break;
                }
            }
        }

        private void CheckGameState()
        {
            if (ball!.IsOutOfBounds())
            {
                EndGame("Game Over! Final Score: " + score);
                return;
            }
            if (blocks!.Count == 0)
            {
                EndGame("You Win! Final Score: " + score);
                return;
            }
        }

        private void EndGame(string message)
        {
            gameRunning = false;
            gameTimer!.Stop();
            MessageBox.Show(message);
            InitializeGame();
        }

        private void DrawGame(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            DrawPaddle(g);
            DrawBall(g);
            DrawBlocks(g);
            DrawUI(g);
        }

        private void DrawPaddle(Graphics g)
        {
            g.FillRectangle(Brushes.Black, paddle!.GetBounds());
        }

        private void DrawBall(Graphics g)
        {
            g.FillEllipse(Brushes.DarkBlue, ball!.GetBounds());
        }

        private void DrawBlocks(Graphics g)
        {
            foreach (var block in blocks!)
            {
                using (var brush = new SolidBrush(block.Color))
                {
                    g.FillRectangle(brush, block.GetBounds());
                }

                var healthText = block.Health.ToString();
                var textSize = g.MeasureString(healthText, Font);
                g.DrawString(healthText,
                    Font,
                    Brushes.White,
                    block.X + block.Width / 2 - textSize.Width / 2,
                    block.Y + block.Height / 2 - textSize.Height / 2);
            }
        }

        private void DrawUI(Graphics g)
        {
            g.DrawString($"Score: {score}", Font, Brushes.Black, 10, 10);
            g.DrawString($"Damage: {ball!.Damage}", Font, Brushes.Black, 10, 30);
        }

        private void HandleInput(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    paddle!.MoveLeft();
                    break;
                case Keys.Right:
                    paddle!.MoveRight();
                    break;
                case Keys.Space:
                    if (!gameRunning)
                        InitializeGame();
                    break;
                case Keys.R:
                    InitializeGame();
                    break;
            }
        }

    }
}
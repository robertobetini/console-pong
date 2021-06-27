using ConsolePong.Core.Controller;
using ConsolePong.Core.Model;
using ConsolePong.Core.Views;
using System;

namespace ConsolePong.Core
{
    public class Game
    {
        public Difficulty Difficulty { get; set; }

        public const int MaxScore = 5;
        public const char BallChar = 'O';
        public const char ScoreChar = '#';

        public Board board;
        public Ball ball;
        public Paddle humanPaddle;
        public Paddle computerPaddle;
        public BoardView boardView;
        public BallView ballView;
        public PaddleView humanPaddleView;
        public PaddleView computerPaddleView;
        public bool finished = false;
        public Paddle winner;

        private bool _boardIsDisplayed;
        private Random _random;

        public Game(Board board_, Ball ball_, Paddle humanPaddle_, Paddle computerPaddle_, Random random, char paddleChar)
        {
            board = board_;
            ball = ball_;
            humanPaddle = humanPaddle_;
            computerPaddle = computerPaddle_;
            boardView = new BoardView(board_);
            ballView = new BallView(ball, BallChar);
            humanPaddleView = new PaddleView(humanPaddle, paddleChar);
            computerPaddleView = new PaddleView(computerPaddle, paddleChar);
            _random = random;
        }

        public void Update()
        {
            CheckWinner();

            if (!_boardIsDisplayed)
            {
                boardView.Display();
                ballView.Display();
                humanPaddleView.Display();
                computerPaddleView.Display();
                ScoreView.Display(10, Score.Human, ScoreChar);
                ScoreView.Display(board.Width - 15, Score.Computer, ScoreChar);
                _boardIsDisplayed = true;
            }

            if (ball.CollidesWithVerticalWall(board))
            {
                ball.ReflectVertically();

                if (ball.GetPosition()[0] <= 1)
                {
                    Score.Computer++;
                    ScoreView.Display(board.Width - 15, Score.Computer, ScoreChar);
                }
                else
                {
                    Score.Human++;
                    ScoreView.Display(10, Score.Human, ScoreChar);
                }

                RespawnBall();
            }
            else if (ball.CollidesWithHorizontalWall(board))
            {
                ball.ReflectHorizontally();
            }
            else if (board.BallCanMove(ball, ball.velocity))
            {
                if (ball.CollidesWithPaddle(humanPaddle) || ball.CollidesWithPaddle(computerPaddle))
                    ball.ReflectVertically();

                ball.Move();
            }

            if (ball.Moved)
            {
                ballView.Hide();
                ballView.Display();
                ball.Moved = false;
            }

            if (computerPaddle.Moved)
            {
                computerPaddleView.Hide();
                computerPaddleView.Display();
                computerPaddle.Moved = false;
            }

            if (humanPaddle.Moved)
            {
                humanPaddleView.Hide();
                humanPaddleView.Display();
                humanPaddle.Moved = false;
            }

            View.ApplyOffsetY(board.Height);
        }

        private void CheckWinner()
        {
            if (Score.Human >= MaxScore)
            {
                finished = true;
                winner = humanPaddle;
            }
            else if (Score.Computer >= MaxScore)
            {
                finished = true;
                winner = computerPaddle;
            }
        }

        private void RespawnBall()
        {
            int ballX = board.Width / 2;
            int ballY = 1 + _random.Next() % (board.Height - 3);

            var ballPosition = ball.GetPosition();

            ball.SetPosition(new int[2] { ballX, ballY });
            ball.SetOldPosition(ballPosition);
            ball.Moved = true;

            int velX;
            int velY;

            if (_random.NextDouble() < 0.5)
                velX = 1;
            else
                velX = -1;

            if (_random.NextDouble() < 0.5)
                velY = 1;
            else
                velY = -1;

            ball.velocity = new int[2] { velX, velY };
        }
    }
}

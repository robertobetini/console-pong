using ConsolePong.Core.Controller;
using ConsolePong.Core.Model;
using ConsolePong.Core.Views;
using System;

namespace ConsolePong.Core
{
    public class Game
    {
        public Difficulty Difficulty { get; set; }
        public Board board;
        public Ball ball;
        public Paddle humanPaddle;
        public Paddle computerPaddle;
        public BoardView boardView;
        public BallView ballView;
        public PaddleView humanPaddleView;
        public PaddleView computerPaddleView;
        private bool _boardIsDisplayed;

        public Game(Board board_, Ball ball_, Paddle humanPaddle_, Paddle computerPaddle_, char paddleChar)
        {
            board = board_;
            ball = ball_;
            humanPaddle = humanPaddle_;
            computerPaddle = computerPaddle_;
            boardView = new BoardView(board_);
            ballView = new BallView(ball, 'O');
            humanPaddleView = new PaddleView(humanPaddle, paddleChar);
            computerPaddleView = new PaddleView(computerPaddle, paddleChar);
        }

        public void Update()
        {
            if (!_boardIsDisplayed)
            {
                boardView.Display();
                ballView.Display();
                humanPaddleView.Display();
                computerPaddleView.Display();
                _boardIsDisplayed = true;
            }

            if (ball.CollidesWithVerticalWall(board))
            {
                // TODO: When ball collides with vertical wall, it should increase player/computer score, but now it's reflecting just for
                // testing purposes.
                ball.ReflectVertically();
            }
            if (ball.CollidesWithHorizontalWall(board))
            {
                ball.ReflectHorizontally();
            }
            if (board.BallCanMove(ball, ball.velocity))
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

            Console.SetCursorPosition(0, board.Height);
        }
    }
}

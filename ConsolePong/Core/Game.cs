using ConsolePong.Core.Model;
using ConsolePong.Core.Views;
using System;

namespace ConsolePong.Core
{
    public class Game
    {
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
            humanPaddleView = new PaddleView(humanPaddle, paddleChar);
            computerPaddleView = new PaddleView(computerPaddle, paddleChar);
        }

        public void Update()
        {
            if (!_boardIsDisplayed)
            {
                boardView.Display();
                humanPaddleView.Display();
                computerPaddleView.Display();
                _boardIsDisplayed = true;
            }

            if (ball.Moved)
            {
                ballView.Hide();
                ballView.Display();
                ball.Moved = true;
            }

            if (humanPaddle.Moved)
            {
                humanPaddleView.Hide();
                humanPaddleView.Display();
                humanPaddle.Moved = false;
            }

            if (computerPaddle.Moved)
            {
                computerPaddleView.Hide();
                computerPaddleView.Display();
                computerPaddle.Moved = false;
            }

            Console.SetCursorPosition(0, board.Height);
        }
    }
}

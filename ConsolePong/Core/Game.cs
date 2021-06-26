using ConsolePong.Core.Model;
using ConsolePong.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong.Core
{
    public class Game
    {
        public Board board;
        public Ball ball;
        public Paddle humanPaddle;
        public Paddle computerPaddle;
        public BoardView boardView;
        public PaddleView humanPaddleView;
        public PaddleView computerPaddleView;

        public Game(Board board_, Ball ball_, Paddle humanPaddle_, Paddle computerPaddle_)
        {
            board = board_;
            ball = ball_;
            humanPaddle = humanPaddle_;
            computerPaddle = computerPaddle_;
            boardView = new BoardView(board_);
            humanPaddleView = new PaddleView(humanPaddle);
            computerPaddleView = new PaddleView(computerPaddle);
        }

        public void Update()
        {
            humanPaddle.Moved = false;
            computerPaddle.Moved = false;

            boardView.Display();
            humanPaddleView.Display();
            computerPaddleView.Display();
        }
    }
}

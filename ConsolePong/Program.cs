using ConsolePong.Core;
using ConsolePong.Core.Controller;
using ConsolePong.Core.Model;
using System;
using System.Threading;

namespace ConsolePong
{
    class Program
    {
        private const int BoardWidth = 50;
        private const int BoardHeight = 20;
        private const short TickTime = 80;
        private static readonly MoveController _moveController = new MoveController(new Random());
        private static Game _game;

        private static void HandleMovement()
        {
            while (true)
            {
                _moveController.MoveHumanPaddle(_game.humanPaddle, _game.board);
            }
        }

        private static void Update(object state)
        {
            // Lock is needed to draw the game correctly
            lock (_game.boardView)
            {
                _moveController.MoveComputerPaddle(_game.computerPaddle, _game.ball, _game.board, Difficulty.Easy);
                _game.Update();
            }
        }

        static void Main(string[] args)
        {
            // TODO: when ball velocity has a coordinate N greater than 1, apply move the move N times for that direction
            // Initializing the game objects.
            var board = new Board(BoardWidth, BoardHeight);
            var humanPaddle = new Paddle(5, Player.Human);
            var humanInitialPosition = new int[2] { 1, (int)BoardHeight / 2  };
            humanPaddle.SetPosition(humanInitialPosition);

            // Set computer paddle initial position.
            var computerPaddle = new Paddle(5, Player.Computer);
            var computerInitialPosition = new int[2] { board.Width - 2, (int)BoardHeight / 2 };
            computerPaddle.SetPosition(computerInitialPosition);

            // Set Ball initial position and velocity
            var random = new Random();
            int ballX = 17; //2 + random.Next() % (board.Width - 2);
            int ballY = 17; //2 + random.Next() % (board.Height - 2);
            var ballVelocity = new int[2] { 1, 1 };
            var ball = new Ball(ballVelocity, ballX, ballY);
            
            _game = new Game(board, ball, humanPaddle, computerPaddle, 'X');

            // Starting the game.
            Timer timer = new Timer(Update);
            var thread1 = new Thread(new ThreadStart(HandleMovement));
            thread1.Start();

            timer.Change(0, TickTime);
        }
    }
}

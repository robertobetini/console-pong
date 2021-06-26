using ConsolePong.Core;
using ConsolePong.Core.Controller;
using ConsolePong.Core.Model;
using ConsolePong.Core.Views;
using System.Threading;

namespace ConsolePong
{
    class Program
    {
        private const int BoardHeight = 10;
        private const int BoardWidth = 10;
        private const short TickTime = 100;
        private static readonly MoveController _moveController = new MoveController();
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
            lock (_game.boardView)
            {
                _game.Update();
            }
        }

        static void Main(string[] args)
        {
            // Initializing the game objects.
            var board = new Board(100, 20);
            var humanPaddle = new Paddle(3, Player.Human);
            var computerPaddle = new Paddle(3, Player.Computer);

            // Set computer paddle initial position.
            var computerInitialPosition = new int[2] { board.Width - 3, 0 };
            computerPaddle.Move(computerInitialPosition);

            var ballVelocity = new int[2] { 0, 0 };
            var ball = new Ball(ballVelocity);
            _game = new Game(board, ball, humanPaddle, computerPaddle, 'X');

            // Starting the game.
            Timer timer = new Timer(Update);
            var thread1 = new Thread(new ThreadStart(HandleMovement));
            thread1.Start();

            timer.Change(0, TickTime);
        }
    }
}

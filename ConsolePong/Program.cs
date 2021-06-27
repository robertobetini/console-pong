using ConsolePong.Core;
using ConsolePong.Core.Controller;
using ConsolePong.Core.Model;
using ConsolePong.Core.Views;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace ConsolePong
{
    class Program
    {
        private const int BoardWidth = 80;
        private const int BoardHeight = 30;
        private const short TickTime = 50;
        private const int PaddleLength = 7;

        private static Thread movementThread;
        private static Timer timer;
        private static readonly MoveController _moveController = new MoveController(new Random());
        private static Game _game;

        private static void HandleMovement()
        {
            while (true)
            {
                _moveController.MoveHumanPaddle(_game.humanPaddle, _game.board);
                if (_game.finished)
                    break;
            }
        }

        private static void Update(object state)
        {
            // Lock is needed to draw the game properly.
            lock (_game.boardView)
            {
                _moveController.MoveComputerPaddle(_game.computerPaddle, _game.ball, _game.board, _game.Difficulty);
                if (!_game.finished)
                    _game.Update();
                else
                {
                    timer.Dispose();
                    int middleX = BoardWidth / 2;
                    View.ApplyOffset(middleX, BoardHeight + 4);
                    if (_game.winner.Player == Player.Human)
                        Console.WriteLine("YOU WIN!!");
                    else
                        Console.WriteLine("YOU LOSE!!");
                    Console.ReadLine();
                }
            }
        }

        public static void ConfigureInitialSettings()
        {
            var windowWidth = BoardWidth + (2 * View.xOffset) + 2;
            var windowHeight = BoardHeight + (2 * View.yOffset) + 2;

            if (OperatingSystem.IsWindows())
                Console.SetWindowSize(windowWidth, windowHeight);  
        }

        static void Main(string[] args)
        {
            ConfigureInitialSettings();

            // TODO: when ball velocity has a coordinate N greater than 1, apply move the move N times for that direction.
            // Initializing the game objects.
            var board = new Board(BoardWidth, BoardHeight);
            var humanPaddle = new Paddle(PaddleLength, Player.Human);
            var humanInitialPosition = new int[2] { 1, (int)BoardHeight / 2  };
            humanPaddle.SetPosition(humanInitialPosition);

            // Set computer paddle initial position.
            var computerPaddle = new Paddle(PaddleLength, Player.Computer);
            var computerInitialPosition = new int[2] { board.Width - 2, (int)BoardHeight / 2 };
            computerPaddle.SetPosition(computerInitialPosition);

            // Set Ball initial position and velocity
            var random = new Random();
            int ballX = board.Width / 2;
            int ballY = 1 + random.Next() % (board.Height - 3);
            var ballVelocity = new int[2] { -1, 1 };
            var ball = new Ball(ballVelocity, ballX, ballY);
            
            _game = new Game(board, ball, humanPaddle, computerPaddle, random, 'X');

            // TODO: Ask the user for the difficulty.
            Console.Write("Pick a difficulty: \n    1. Easy\n    2. Medium\n    3. Hard\n    4. Impossible\n\nAnswer (number): ");
            do
            {
                var chosenDifficulty = Console.ReadKey(true).KeyChar;
                switch (chosenDifficulty)
                {
                    case '1':
                        _game.Difficulty = Difficulty.Easy;
                        Console.Write('1');
                        break;
                    case '2':
                        _game.Difficulty = Difficulty.Medium;
                        Console.Write('2');
                        break;
                    case '3':
                        _game.Difficulty = Difficulty.Hard;
                        Console.Write('3');
                        break;
                    case '4':
                        _game.Difficulty = Difficulty.Impossible;
                        Console.Write('4');
                        break;
                    default:
                        _game.Difficulty = Difficulty.Random;
                        break;
                }
            } while (_game.Difficulty == Difficulty.Random);

            // Starting the game.
            timer = new Timer(Update);
            movementThread = new Thread(new ThreadStart(HandleMovement));

            movementThread.Start();
            timer.Change(0, TickTime);
        }
    }
}

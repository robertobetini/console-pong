﻿using ConsolePong.Core;
using ConsolePong.Core.Controller;
using ConsolePong.Core.Model;
using System;
using System.Threading;

namespace ConsolePong
{
    class Program
    {
        private const int BoardWidth = 70;
        private const int BoardHeight = 20;
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
            // Lock is needed to draw the game correctly
            lock (_game.boardView)
            {
                _game.Update();
            }
        }

        static void Main(string[] args)
        {
            // Initializing the game objects.
            var board = new Board(BoardWidth, BoardHeight);
            var humanPaddle = new Paddle(3, Player.Human);
            var computerPaddle = new Paddle(3, Player.Computer);

            // Set computer paddle initial position.
            var computerInitialPosition = new int[2] { board.Width - 2, 1 };
            computerPaddle.SetPosition(computerInitialPosition);

            // Set Ball initial position and velocity
            var random = new Random();
            int ballX = 1 + random.Next() % board.Width;
            int ballY = 1 + random.Next() % board.Height;
            var ballVelocity = new int[2] { -1, 0 };
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

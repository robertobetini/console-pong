using ConsolePong.Core.Model;
using System;

namespace ConsolePong.Core.Controller
{
    public class MoveController
    {
        private const char Up = 'w';
        private const char Down = 's';
        private const char AlternativeUp = 'W';
        private const char AlternativeDown = 'S';
        private Random _random;

        public MoveController(Random random)
        {
            _random = random;
        }

        public void MoveHumanPaddle(Paddle humanPaddle, Board board)
        {
            char key = Console.ReadKey(true).KeyChar;
            var direction = GetDirectionByKey(key);

            if (board.PaddleCanMove(humanPaddle, direction) && !humanPaddle.Moved)
            {
                humanPaddle.Move(direction);
                humanPaddle.Moved = true;
            }
        }

        public void MoveComputerPaddle(Paddle computerPaddle, Ball ball, Board board, Difficulty difficulty)
        {
            int [] direction;
            double chance;

            switch (difficulty)
            {
                case Difficulty.Random:
                    direction = GetRandomDirection();
                    break;
                case Difficulty.Easy:
                    chance = 0.5;
                    direction = GetRightDirectionByChance(computerPaddle, ball, chance);
                    break;
                case Difficulty.Medium:
                    chance = 0.65;
                    direction = GetRightDirectionByChance(computerPaddle, ball, chance);
                    break;
                case Difficulty.Hard:
                    chance = 0.85;
                    direction = GetRightDirectionByChance(computerPaddle, ball, chance);
                    break;
                case Difficulty.Impossible:
                    direction = GetRightDirection(computerPaddle, ball);
                    break;
                default:
                    direction = new int[2] { 0, 0 };
                    break;
            }

            if (board.PaddleCanMove(computerPaddle, direction) && !computerPaddle.Moved)
            {
                computerPaddle.Move(direction);
                computerPaddle.Moved = true;
            }
        }

        private int[] GetDirectionByKey(char key)
        {
            switch (key)
            {
                case Up:
                case AlternativeUp:
                    return new int[2] { 0, -1 };
                case Down:
                case AlternativeDown:
                    return new int[2] { 0, 1 };
                default:
                    return new int[2] { 0, 0 };
            }
        }

        private int[] GetRandomDirection()
        {
            int probability = _random.Next() % 3;

            if (probability == 0)
                return new int[2] { 0, 1 };
            else if (probability == 1)
                return new int[2] { 0, -1 };
            else
                return new int[2] { 0, 0 };
        }

        private int[] GetRightDirectionByChance(Paddle paddle, Ball ball, double chance)
        {
            double probability = _random.NextDouble();

            if (probability <= chance)
                return GetRightDirection(paddle, ball);
            
            return GetRandomDirection();
        }

        private int[] GetRightDirection(Paddle paddle, Ball ball)
        {
            var ballPosition = ball.GetPosition();
            var topPaddleY = paddle.GetPosition()[1];
            var bottomPaddleY = paddle.GetPosition()[1] + paddle.Length - 1;

            // We're checking both y values.

            // Paddle ove the ball.
            if (topPaddleY < ballPosition[1])
                return new int[2] { 0, 1 };
            // Paddle under the ball
            if (bottomPaddleY > ballPosition[1])
                return new int[2] { 0, -1 };
            //Paddle on the same layer as the ball.
            else
                return new int[2] { 0, 0 };
        }
    }
}

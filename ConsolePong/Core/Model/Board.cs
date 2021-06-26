using ConsolePong.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong.Core.Model
{
    public class Board
    {
        public static readonly int MaxSize = 200;

        public int Width { get; set; }
        public int Height { get; set; }
        public char[,] matrix;

        public Board(int width, int height)
        {
            if (width > MaxSize || height > MaxSize)
                throw new ConsolePongException($"Boards can't have sizes greater than {MaxSize}.");

            Width = width + 2;
            Height = height + 2;
            
            FillMatrix();
        }

        public bool PositionIsWall(int[] position)
        {
            int x = position[0];
            int y = position[1];

            // Walls on the edges.
            if (x == 0 || y == 0 || x == Width - 1 || y == Height - 1)
                return true;

            return false;
        }

        public bool CanMove(Paddle paddle, int[] direction)
        {
            var currentPosition = paddle.GetPosition();
            int[] topNextPosition = new int[2];
            int[] bottomNextPosition = new int[2];
            for (int i = 0; i < direction.Length; i++)
            {
                topNextPosition[i] = currentPosition[i] + direction[i];
            }
            bottomNextPosition[0] = topNextPosition[0];
            bottomNextPosition[1] = topNextPosition[1] + paddle.Length - 1;

            if (!PositionIsWall(topNextPosition) && !PositionIsWall(bottomNextPosition))
                return true;

            return false;
        }

        private void FillMatrix()
        {
            matrix = new char[Height, Width];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    // Walls on the edges.
                    if ((x == 0 && y == 0) ||
                            (x == 0 && y == Height - 1) ||
                            (x == Width - 1 && y == 0) ||
                            (x == Width - 1 && y == Height - 1))
                        matrix[y, x] = '+';

                    else if (x == 0 || x == Width - 1)
                        matrix[y, x] = '|';

                    else if (y == 0 || y == Height - 1)
                        matrix[y, x] = '-';

                    // Empty space in the middle.
                    else
                        matrix[y, x] = ' ';
                }
            }
        }
    }
}

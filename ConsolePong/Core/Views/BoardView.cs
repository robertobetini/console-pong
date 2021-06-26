using ConsolePong.Core.Model;
using ConsolePong.Core.Views.Interface;
using System;

namespace ConsolePong.Core.Views
{
    public class BoardView : IView
    {
        private readonly Board _board;

        public BoardView(Board board)
        {
            _board = board;
        }

        public void Display()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < _board.Height; y++)
            {
                for (int x = 0; x < _board.Width; x++)
                {
                    Console.Write(_board.matrix[y, x]);
                }
                Console.Write("\n");
            }
        }
    }
}

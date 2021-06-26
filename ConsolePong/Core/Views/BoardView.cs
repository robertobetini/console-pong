using ConsolePong.Core.Model;
using ConsolePong.Core.Views.Interface;
using System;

namespace ConsolePong.Core.Views
{
    public class BoardView : View
    {
        private readonly Board _board;

        public BoardView(Board board)
        {
            _board = board;
        }

        public override void Display()
        {
            //ApplyOffset(0, 0);
            for (int y = 0; y < _board.Height; y++)
            {
                ApplyOffset(0, y);
                for (int x = 0; x < _board.Width; x++)
                {
                    Console.Write(_board.matrix[y, x]);
                }
                Console.Write("\n");
                
            }
        }
    }
}

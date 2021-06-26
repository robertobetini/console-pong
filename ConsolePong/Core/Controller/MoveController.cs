using ConsolePong.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong.Core.Controller
{
    public class MoveController
    {
        private const char Up = 'w';
        private const char Down = 's';
        private const char AlternativeUp = 'W';
        private const char AlternativeDown = 'S';

        public void MoveHumanPaddle(Paddle humanPaddle, Board board)
        {
            char key = Console.ReadKey(true).KeyChar;
            var direction = GetDirectionByKey(key);

            if (board.CanMove(humanPaddle, direction) && !humanPaddle.Moved)
            {
                humanPaddle.Move(direction);
                humanPaddle.Moved = true;
            }
        }

        private int[] GetDirectionByKey(char key)
        {
            switch (key)
            {
                case Up:
                case AlternativeUp:
                    return new int[2] { 0, -1};
                case Down:
                case AlternativeDown:
                    return new int[2] { 0, 1 };
                default:
                    return new int[2] { 0, 0 };
            }
        }
    }
}

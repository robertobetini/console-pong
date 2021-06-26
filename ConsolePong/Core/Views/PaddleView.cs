using ConsolePong.Core.Model;
using ConsolePong.Core.Views.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong.Core.Views
{
    public class PaddleView : IView
    {
        private readonly Paddle _paddle;

        public PaddleView(Paddle paddle)
        {
            _paddle = paddle;
        }

        public void Display()
        {
            var position = _paddle.GetPosition();
            for (int i = 0; i < _paddle.Length; i++)
            {
                Console.SetCursorPosition(position[0], position[1] + i);
                Console.Write('X');
            }
        }
    }
}

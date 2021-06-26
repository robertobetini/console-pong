using ConsolePong.Core.Model;
using ConsolePong.Core.Views.Interface;
using System;

namespace ConsolePong.Core.Views
{
    public class PaddleView : IView
    {
        private readonly Paddle _paddle;
        private char _paddleChar;

        public PaddleView(Paddle paddle, char paddleChar)
        {
            _paddle = paddle;
            _paddleChar = paddleChar;
        }

        public void Display()
        {
            var position = _paddle.GetPosition();
            for (int i = 0; i < _paddle.Length; i++)
            {
                Console.SetCursorPosition(position[0], position[1] + i);
                Console.Write(_paddleChar);
            }
        }

        public void Hide()
        {
            var oldPosition = _paddle.GetOldPosition();
            for (int i = 0; i < _paddle.Length; i++)
            {
                Console.SetCursorPosition(oldPosition[0], oldPosition[1] + i);
                Console.Write(' ');
            }
        }
    }
}

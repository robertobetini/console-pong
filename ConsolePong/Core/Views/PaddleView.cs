using ConsolePong.Core.Model;
using ConsolePong.Core.Views.Interface;
using System;

namespace ConsolePong.Core.Views
{
    public class PaddleView : View
    {
        private readonly Paddle _paddle;
        private char _paddleChar;

        public PaddleView(Paddle paddle, char paddleChar)
        {
            _paddle = paddle;
            _paddleChar = paddleChar;
        }

        public override void Display()
        {
            var position = _paddle.GetPosition();
            for (int i = 0; i < _paddle.Length; i++)
            {
                ApplyOffset(position[0], position[1] + i);
                Console.Write(_paddleChar);
            }
        }

        public void Hide()
        {
            var oldPosition = _paddle.GetOldPosition();
            for (int i = 0; i < _paddle.Length; i++)
            {
                ApplyOffset(oldPosition[0], oldPosition[1] + i);
                Console.Write(' ');
            }
        }
    }
}

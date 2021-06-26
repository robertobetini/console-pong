using ConsolePong.Core.Model;
using ConsolePong.Core.Views.Interface;
using System;

namespace ConsolePong.Core.Views
{
    public class BallView : IView
    {
        private Ball _ball;
        private char _ballChar;

        public BallView(Ball ball, char ballChar)
        {
            _ball = ball;
            _ballChar = ballChar;
        }

        public void Display()
        {
            var position = _ball.GetPosition();
            Console.SetCursorPosition(position[0], position[1]);
            Console.Write(_ballChar);
        }

        public void Hide()
        {
            var oldPosition = _ball.GetOldPosition();
            Console.SetCursorPosition(oldPosition[0], oldPosition[1]);
            Console.Write(' ');
        }
    }
}

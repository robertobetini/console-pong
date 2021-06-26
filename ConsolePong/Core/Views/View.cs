using ConsolePong.Core.Views.Interface;
using System;

namespace ConsolePong.Core.Views
{
    public abstract class View : IView
    {
        public static readonly int xOffset = 25;
        public static readonly int yOffset = 7;

        virtual public void Display()
        {
            throw new NotImplementedException();
        }

        public static void ApplyOffset(int x, int y)
        {
            Console.SetCursorPosition(xOffset + x, yOffset + y);
        }

        public static void ApplyOffsetX(int x)
        {
            Console.SetCursorPosition(xOffset + x, 0);
        }

        public static void ApplyOffsetY(int y)
        {
            Console.SetCursorPosition(0, yOffset + y);
        }
    }
}

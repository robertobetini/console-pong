using ConsolePong.Core.Views.Interface;
using System;

namespace ConsolePong.Core.Views
{
    public abstract class View : IView
    {
        protected readonly int xOffset = 20;
        protected readonly int yOffset = 0;

        virtual public void Display()
        {
            throw new NotImplementedException();
        }

        public void ApplyOffset(int x, int y)
        {
            Console.SetCursorPosition(xOffset + x, yOffset + y);
        }
    }
}

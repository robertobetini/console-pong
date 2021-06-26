using ConsolePong.Core.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong.Core.Model
{
    public class Ball : GameEntity
    {
        public int[] GetPosition()
        {
            return _position;
        }

        public void Move(int direction)
        {

        }
    }
}

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
        int[] _velocity;

        public Ball(int[] velocity)
        {
            _velocity = velocity;
        }

        public override void Move()
        {
            Move(_velocity);
        }
    }
}

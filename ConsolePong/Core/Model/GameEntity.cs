using ConsolePong.Core.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong.Core.Model
{
    public class GameEntity : IGameEntity
    {
        protected int[] _position = new int[2] { 1, 1 };
        protected int[] _oldPosition = new int[2] { 1, 1 };
        public bool Moved { get; set; }

        public void Move(int[] direction)
        {

            for (int i = 0; i < _position.Length; i++)
            {
                _oldPosition[i] = _position[i];
                _position[i] += direction[i];
            }
        }

        virtual public void Move()
        {
            throw new NotImplementedException();
        }

        public int[] GetPosition()
        {
            return _position;
        }

        public int[] GetOldPosition()
        {
            return _oldPosition;
        }
    }
}

using ConsolePong.Core.Model.Interface;
using System;

namespace ConsolePong.Core.Model
{
    public abstract class GameEntity : IGameEntity
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

            Moved = true;
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

        public void SetPosition(int[] position)
        {
            _position = position;
            for (int i = 0; i < _position.Length; i++)
                _oldPosition[i] = _position[i];
        }
    }
}

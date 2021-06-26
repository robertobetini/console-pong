using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong.Core.Model
{
    public class Paddle : GameEntity
    {
        public int Length { get; set; }
        public bool Moved { get; set; }
        public Player Player;

        public Paddle(int length, Player player)
        {
            Length = length;
            Player = player;
        }
    }
}

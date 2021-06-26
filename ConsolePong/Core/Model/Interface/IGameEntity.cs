using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong.Core.Model.Interface
{
    interface IGameEntity
    {
        int[] GetPosition();
        void Move(int[] direction);
    }
}

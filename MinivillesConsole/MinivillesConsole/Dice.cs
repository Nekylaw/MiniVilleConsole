using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinivillesConsole
{
    internal class Dice
    {
        int face;
        private Random random = new();

        public int Throw()
        {
            return face = random.Next(0,7);
        }
    }
}

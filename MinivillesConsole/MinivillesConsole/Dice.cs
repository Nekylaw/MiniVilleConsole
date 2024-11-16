using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinivillesConsole
{
    internal class Dice
    {
        public int face;
        private Random random = new();

        public void Throw()
        {
            face = random.Next(0,7);
        }
    }
}

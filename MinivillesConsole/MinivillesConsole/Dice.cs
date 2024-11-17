using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinivillesConsole
{
    internal class Dice
    {
        private Random random = new();

        public int Throw()
        {
            return random.Next(1,7);
        }
    }
}

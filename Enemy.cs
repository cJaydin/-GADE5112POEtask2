using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE5112POE
{
    abstract class Enemy : Character
    {
        protected Random r = new Random();

        public Enemy(int hp, int damage, int x, int y) : base(hp, damage, hp, x, y) { }

        public override string ToString()
        {
            return ToString() + "at [" + X + "," + Y + "] (" + damage + ")";
        }
    }
}

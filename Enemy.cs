﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE5112POE
{
    abstract class Enemy : Character
    {
        protected Random r = new Random();

        public Enemy(int hp, int damage, int x, int y, char symbol) : base(hp, damage, hp, x, y, symbol) { }

        public override string ToString()
        {
            //return base.ToString() + "at [" + X + "," + Y + "] (" + damage + ")";
            return "at [" + X + "," + Y + "] (" + damage + ")";
        }
    }
}

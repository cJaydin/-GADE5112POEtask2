using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE5112POE
{
    abstract class Character : Tile
    {
        protected int hp;
        protected int maxHp;
        protected int damage;
        protected Tile[,] vision;

        protected int Hp { get => hp; set => hp = value; }
        protected int MaxHp { get => maxHp; set => maxHp = value; }
        protected int Damage { get => damage; set => damage = value; }
        protected Tile[,] Vision { get => vision; set => vision = value; }

        public enum Movement { Idle, Up, Down, Right, Left }

        public Character(int x, int y) : base(x, y) { }
    }
}

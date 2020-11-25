﻿using System;

namespace GADE5112POE
{
    abstract class Character : Tile
    {
        protected int hp;
        protected int maxHp;
        protected int damage;
        protected Tile[,] vision;
        protected char symbol;

        public int Hp { get => hp; set => hp = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public int Damage { get => damage; set => damage = value; }
        public Tile[,] Vision { get => vision; set => vision = value; }
        public char Symbol { get => symbol; set => symbol = value; }

        public enum Movement { Idle, Up, Down, Right, Left }

        public Character(int x, int y, char symbol, Delegate[] delegates) : base(x, y)
        {
            Symbol = symbol;
        }

        public virtual bool CheckRange(Character target)
        {
            int range = DistanceTo(target);

            if (range <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int DistanceTo(Character target)
        {
            return (Math.Abs(X - target.X) + Math.Abs(Y - target.Y));
        }

        public void Move(Movement move)
        {
            switch (move)
            {
                case Movement.Idle: //How to show IDLE position
                    break;
                case Movement.Up:
                    Y++;                    break;
                case Movement.Down:
                    Y--;
                    break;
                case Movement.Right:
                    x++;
                    break;
                case Movement.Left:
                    x--;
                    break;
                default:
                    break;
            }
        }

        public abstract Movement ReturnMove(Movement move = 0);

        public abstract override string ToString();
    }
}
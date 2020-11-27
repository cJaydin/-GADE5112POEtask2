using System;

namespace GADE5112POE
{
    public class Hero : Character
    {
        public Hero(int x, int y, int hp) : base(hp, 2, 10, x, y, 'H') { }
        public override Movement ReturnMove(Movement move = Movement.Idle)
        {
            if (Vision[(int)move].GetType()!=typeof(EmptyTile))
            {
                return Movement.Idle;
            }

            switch (move)
            {
                case (Movement.Up): Y--; break;
                case (Movement.Down): Y++; break;
                case (Movement.Left): X--; break;
                case (Movement.Right): X++; break;
            }

            return move;
        }

        public override string ToString()
        {
            return "Player Stats: " + Environment.NewLine + "HP: " + Hp + "/" + MaxHp + Environment.NewLine + "Damage: " + Damage + Environment.NewLine + "[" + X + "," + Y + "]";
        }
    }
}

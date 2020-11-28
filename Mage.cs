namespace GADE5112POE
{
    class Mage : Enemy
    {

        public Mage(int hp, int damage, int maxHp, int x, int y, int arrayIndex) : base(hp,damage,x,y,'M',arrayIndex)
        {
            this.hp = 5;
            this.damage = 5;
        }

        public override Movement ReturnMove(Movement move = 0)
        {
            return move;
        }

        public override bool CheckRange(Character target)
        {
            if (target.X == X + 1)
            {
                return true;
            }
            else if (target.X == X - 1)
            {
                return true;
            }
            else if (target.Y == Y - 1)
            {
                return true;
            }
            else if (target.Y == Y + 1)
            {
                return true;
            }
            else if (target.X == X + 1 && target.Y == Y + 1)
            {
                return true;
            }
            else if (target.X == X - 1 && target.Y == Y - 1)
            {
                return true;
            }
            else if (target.X == X + 1 && target.Y == Y - 1)
            {
                return true;
            }
            else if (target.X == X - 1 && target.Y == Y + 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;

namespace GADE5112POE
{
    class Goblin : Enemy
    {
        public Goblin(int x, int y) : base(10, 1, x, y) { }

        private Random random = new Random();

        public Movement GetRandomMovement()
        {
            int i = random.Next(1, 4);
            return (Movement)i;
        }

        public override Movement ReturnMove(Movement move = Movement.Idle)
        {
            bool movementIsValid = false;

            Movement movement = GetRandomMovement();
            while (!movementIsValid)
            {
                movement = GetRandomMovement();
                Type targetType = Vision[(int)movement].GetType();
                if (targetType!=typeof(Obstacle)) // && targetType!=typeof(Hero) )
                {
                    movementIsValid = true;
                }
            }

            return movement;
        }
    }
}

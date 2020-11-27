namespace GADE5112POE
{
    public abstract class Tile
    {
        public enum TileType { Hero, Enemy, Gold, Weapon }

        protected int x;
        protected int y;
        protected char symbol;
        public char Symbol { get => symbol; set => symbol = value; }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }


        public Tile(int x, int y, char smbl)
        {
            X = x;
            Y = y;
            symbol = smbl;
        }
    }
}

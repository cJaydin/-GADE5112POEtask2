namespace GADE5112POE
{
    abstract class Tile
    {
        public enum TileType { Hero, Enemy, Gold, Weapon }

        protected int x;
        protected int y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }


        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

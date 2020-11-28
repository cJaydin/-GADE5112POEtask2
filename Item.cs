namespace GADE5112POE
{
    abstract class Item: Tile
    {
        public Item(int x, int y, char symbol) : base(x, y, symbol)
        {

        }

        public abstract override string ToString();
    } 
}

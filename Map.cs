using System;

namespace GADE5112POE
{
    public class Map
    {
        private Tile[,] arrMap;
        private Enemy[] arrEnemy;
        private Hero hero;
        private int mapHeight;
        private int mapWidth;
        private Random r = new Random();

        public int MapHeight { get => mapHeight; set => mapHeight = value; }
        public int MapWidth { get => mapWidth; set => mapWidth = value; }
        public Tile[,] ArrMap { get => arrMap; set => arrMap = value; }
        public Enemy[] ArrEnemy { get => arrEnemy; set => arrEnemy = value; }
        public Hero Hero { get => hero; set => hero = value; }

        internal void ClearPosition(Tile tile)
        {
            ArrMap[tile.X, tile.Y] = new EmptyTile(tile.X, tile.Y);
        }

        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int enemyCount)
        {
            MapHeight = r.Next(minHeight, maxHeight);
            MapWidth = r.Next(minWidth, maxWidth);

            ArrMap = new Tile[MapWidth, MapHeight];
            ArrEnemy = new Enemy[enemyCount];

            // First fill map with empty tiles
            for (int i=0; i < mapWidth; i++)
            {
                for (int j=0; j < mapHeight; j++)
                {
                    ArrMap[i, j] = new EmptyTile(i, j);
                }
            }

            // Walls
            for (int i=0; i < mapWidth; i++)
            {
                Tile topTile = new Wall(i, 0);
                ArrMap[i, 0] = topTile;
                Tile bottomTile = new Wall(i, mapHeight - 1);
                ArrMap[i, mapHeight - 1] = bottomTile;
            }

            for (int i=0; i < MapHeight; i++)
            {
                Tile leftTile = new Wall(0, i);
                ArrMap[0, i] = leftTile;
                Tile rightTile = new Wall(mapWidth-1, i);
                ArrMap[mapWidth - 1, i] = rightTile;
            }

            Hero = (Hero)Create(Tile.TileType.Hero,-1);
            ArrMap[Hero.X, Hero.Y] = Hero;

            for (int i = 0; i < enemyCount; i++)
            {
                arrEnemy[i] = (Enemy)Create(Tile.TileType.Enemy,i);

                arrMap[arrEnemy[i].X, arrEnemy[i].Y] = arrEnemy[i];

                int chance = r.Next(1, 3);
                int x = r.Next(1, mapWidth-2);
                int y = r.Next(1, mapHeight-2);

                if (chance == 1)
                {
                    arrEnemy[i] = new Goblin(x, y, i);
                }
                else
                {
                    arrEnemy[i] = new Goblin(x, y, i);
                }
            }
            new frmMapDebug(this).Show();
            UpdateVision();
        }

        bool MapContainsCharacterAt(int x, int y)
        {
            if (Hero.X==x && Hero.Y==y) { return true; }

            for (int i=0; i < arrEnemy.Length; i++)
            {
                Tile t = arrEnemy[i];
                if (t==null) { return false; }
                if (t.X==x && t.Y==y) { return true; }
            }

            return false;
        }

        private Tile Create(Tile.TileType type, int arrayIndex)
        {
            Random r = new Random();

            if (Hero==null)
            {
                Hero = new Hero(0, 0, 10); // Dummy Hero for MapContainsCharacterAt to work
            }

            int x = 0, y = 0;
            do
            {
                x = r.Next(1, mapWidth - 2);
                y = r.Next(1, mapHeight - 2);
            } while (MapContainsCharacterAt(x, y));

            //if (x >= mapWidth-2) { x -= 2; }
            //if (y >= mapHeight-2) { y-=2; }

            if (type == 0)
            {
                return new Hero(x, y, 10);
            }
            else
            {
                return new Goblin(x, y, arrayIndex); // In order to run place breakpoint here (else only one goblin is generated)
            }
        }

        public void UpdateVision()
        {
            Hero.Vision = new Tile[5];

            Hero.Vision[(int)Hero.Movement.Idle] = null;
            Hero.Vision[(int)Hero.Movement.Up] = arrMap[Hero.X, Hero.Y - 1];
            Hero.Vision[(int)Hero.Movement.Down] = arrMap[Hero.X, Hero.Y + 1];
            Hero.Vision[(int)Hero.Movement.Left] = arrMap[Hero.X-1, Hero.Y];
            Hero.Vision[(int)Hero.Movement.Right] = arrMap[Hero.X+1, Hero.Y];

            for (int i = 0; i < arrEnemy.Length; i++)
            {
                arrEnemy[i].Vision = new Tile[5];

                arrEnemy[i].Vision[(int)Hero.Movement.Idle] = null;
                arrEnemy[i].Vision[(int)Hero.Movement.Up] = ArrMap[arrEnemy[i].X, arrEnemy[i].Y - 1];
                arrEnemy[i].Vision[(int)Hero.Movement.Down] = ArrMap[arrEnemy[i].X, arrEnemy[i].Y + 1];
                arrEnemy[i].Vision[(int)Hero.Movement.Left] = ArrMap[arrEnemy[i].X-1, arrEnemy[i].Y];
                arrEnemy[i].Vision[(int)Hero.Movement.Right] = ArrMap[arrEnemy[i].X+1, arrEnemy[i].Y];
            }

        }
    }
}

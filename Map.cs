using System;

namespace GADE5112POE
{
    class Map
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
            ArrMap[tile.X, tile.Y] = null;
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

            Hero = (Hero)Create(Tile.TileType.Hero);
            ArrMap[Hero.X, Hero.Y] = Hero;

            for (int i = 0; i < enemyCount; i++)
            {
                arrEnemy[i] = (Enemy)Create(Tile.TileType.Enemy);

                arrMap[arrEnemy[i].X, arrEnemy[i].Y] = arrEnemy[i];

                int chance = r.Next(1, 3);
                int x = r.Next(1, mapWidth);
                int y = r.Next(1, mapHeight);

                if (chance == 1)
                {
                    arrEnemy[i] = new Goblin(x, y);
                }
                else
                {
                    //  arrEnemy[i] = new Mage(5, 5, 5, x, y);
                }
            }
            UpdateVision();
        }

        internal void UpdatePositions()
        {
            foreach (Tile tile in ArrMap)
            {
                ArrMap[tile.X, tile.Y] = tile;
            }
        }

        private Tile Create(Tile.TileType type)
        {
            Random r = new Random();

            int x = r.Next(1, mapWidth);
            int y = r.Next(1, mapHeight);

            if (x >= mapWidth-1) { x--; }
            if (y >= mapHeight-1) { y--; }

            if (type == 0)
            {
                return new Hero(x, y, 10);
            }
            else
            {
                return new Goblin(x, y);
            }
        }

        public void UpdateVision()
        {
            Hero.Vision = new Tile[4]{
            arrMap[Hero.X -1, Hero.Y],
            arrMap[Hero.X + 1, Hero.Y],
            arrMap[Hero.X, Hero.Y - 1],
            arrMap[Hero.X, Hero.Y + 1]};

            for (int i = 0; i < arrEnemy.Length; i++)
            {
                arrEnemy[i].Vision = new Tile[4]{
                arrMap[arrEnemy[i].X -1, arrEnemy[i].Y],
                arrMap[arrEnemy[i].X + 1, arrEnemy[i].Y],
                arrMap[arrEnemy[i].X, arrEnemy[i].Y - 1],
                arrMap[arrEnemy[i].X, arrEnemy[i].Y + 1] };
            }

        }
    }
}

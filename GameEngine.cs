namespace GADE5112POE
{
    class GameEngine
    {
        private Map map;
        
        public Map MapCreate { get => map; set => map = value; }

        public GameEngine(int minWidth, int maxWidth, int minHeight, int maxHeight, int enemyCount)
        {
            MapCreate = new Map(minWidth, maxWidth, minHeight, maxHeight, enemyCount);
        }

        public bool MovePlayer(Character.Movement move)
        {
            switch (move)
            {
                case Character.Movement.Idle:
                    break;
                case Character.Movement.Up:
                    MapCreate.ClearPosition(MapCreate.Hero);
                    MapCreate.Hero.Y--;
                    MapCreate.UpdatePositions();
                    MapCreate.UpdateVision();
                    //if (MapCreate.hero.TileVision[1] == null)
                    //{
                    //    MapCreate.hero.Y = MapCreate.hero.Y + 1;
                    //    return true;
                    //}
                    break;
                case Character.Movement.Down:
                    //if (MapCreate.hero.TileVision[2] == null)
                    //{
                    //    MapCreate.hero.Y = MapCreate.hero.Y - 1;
                    //    return true;
                    //}
                    break;
                case Character.Movement.Right:
                    //if (MapCreate.hero.TileVision[3] == null)
                    //{
                    //    MapCreate.hero.X = MapCreate.hero.X + 1;
                    //    return true;
                    //}
                    break;
                case Character.Movement.Left:
                    //if (MapCreate.hero.TileVision[4] == null)
                    //{
                    //    MapCreate.hero.Y = MapCreate.hero.Y - 1;
                    //    return true;
                    //}
                    break;
                default:
                    break;
            }

            return false;
        }
    }
}

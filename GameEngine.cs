using System;
using System.Windows.Forms;

namespace GADE5112POE
{
    class GameEngine
    {
        private Map map;
        private frmMain mainForm;

        public Map MapCreate { get => map; set => map = value; }

        public GameEngine(frmMain form, int minWidth, int maxWidth, int minHeight, int maxHeight, int enemyCount)
        {
            mainForm = form;
            MapCreate = new Map(minWidth, maxWidth, minHeight, maxHeight, enemyCount);
        }

        private void DeleteEnemyFromEnemyArray(Enemy enemy)
        {
            Enemy[] enemies = new Enemy[MapCreate.ArrEnemy.Length - 1];
            int i = 0;
            foreach (Enemy enm in MapCreate.ArrEnemy)
            {
                if (enm.ArrayIndex != enemy.ArrayIndex)
                {
                    enemies[i++] = enm;
                }
            }
            MapCreate.ArrEnemy = enemies;
        }

        public bool MovePlayer(Character.Movement move)
        {
            int x = MapCreate.Hero.X;
            int y = MapCreate.Hero.Y;
            MapCreate.ArrMap[x, y] = new EmptyTile(x, y);

            switch (move)
            {
                case Character.Movement.Idle:
                    break;
                case Character.Movement.Up:
                    if (MapCreate.Hero.Vision[(int)Hero.Movement.Up].GetType() != typeof(EmptyTile)) break;
                    MapCreate.Hero.Button.Location = new System.Drawing.Point(x * 20, (y - 1) * 20);
                    MapCreate.Hero.X = x;
                    MapCreate.Hero.Y = y - 1;
                    break;
                case Character.Movement.Down:
                    if (MapCreate.Hero.Vision[(int)Hero.Movement.Down].GetType() != typeof(EmptyTile)) break;
                    MapCreate.Hero.Button.Location = new System.Drawing.Point(x * 20, (y + 1) * 20);
                    MapCreate.Hero.X = x;
                    MapCreate.Hero.Y = y + 1;
                    MapCreate.ArrMap[x, y + 1] = MapCreate.Hero;
                    break;
                case Character.Movement.Right:
                    if (MapCreate.Hero.Vision[(int)Hero.Movement.Right].GetType() != typeof(EmptyTile)) break;
                    MapCreate.Hero.Button.Location = new System.Drawing.Point((x + 1) * 20, y * 20);
                    MapCreate.Hero.X = x + 1;
                    MapCreate.Hero.Y = y;
                    MapCreate.ArrMap[x + 1, y] = MapCreate.Hero;
                    break;
                case Character.Movement.Left:
                    if (MapCreate.Hero.Vision[(int)Hero.Movement.Left].GetType() != typeof(EmptyTile)) break;
                    MapCreate.Hero.Button.Location = new System.Drawing.Point((x - 1) * 20, y * 20);
                    MapCreate.Hero.X = x - 1;
                    MapCreate.Hero.Y = y;
                    MapCreate.ArrMap[x - 1, y] = MapCreate.Hero;
                    break;
                default:
                    break;
            }
            MapCreate.ArrMap[x, y - 1] = MapCreate.Hero;
            //MapCreate.ClearPosition(MapCreate.Hero);
            MapCreate.UpdateVision();

            return false;
        }

        public void Attack(Enemy enemy)
        {
            mainForm.Output("Hero attacks " + enemy.GetType().Name + " [" + enemy.X + "," + enemy.Y + "]");

            enemy.Hp -= MapCreate.Hero.Damage;

            mainForm.Output("Enemy: " + enemy.Hp + "/" + enemy.MaxHp + " [" + enemy.X + "," + enemy.Y + "]");

            if (enemy.Hp < 1)
            {
                mainForm.Output(enemy.GetType().Name + " has died");
                MapCreate.ArrMap[enemy.X, enemy.Y] = new EmptyTile(enemy.X, enemy.Y);
                DeleteEnemyFromEnemyArray(enemy);
                mainForm.DeleteTile(enemy);
                //frmMain.
            }
        }

        internal void AttackBack(Enemy enemy)
        {
            mainForm.Output(enemy.GetType().Name + " attacks Hero");
            MapCreate.Hero.Hp -= enemy.Damage;
            mainForm.Output("Hero: " + MapCreate.Hero.Hp);

            if (MapCreate.Hero.Hp < 1)
            {
                mainForm.Output("Your hero has died");
                mainForm.ShowEndGame();
            }
        }
    }
}

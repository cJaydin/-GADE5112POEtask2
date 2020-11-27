using System.Drawing;
using System.Windows.Forms;

namespace GADE5112POE
{
    public partial class frmMain : Form
    {
        private GameEngine Game;

        public frmMain()
        {
            InitializeComponent();

            Game = new GameEngine(20,80,20,30,10);
            RenderMap(Game.MapCreate);

            frmPlayerStats frmPlayerStats = new frmPlayerStats(Game.MapCreate.Hero);
            frmPlayerStats.Show();

            this.Focus();
        }

        private void ClearPlayingField()
        {
            this.Controls.Clear();
        }

        private void RenderMap(Map map)
        {
            for (int i=0; i < map.MapWidth; i++) 
            {
                for (int j = 0; j < map.MapHeight; j++)
                {
                    Tile tile = map.ArrMap[i, j];

                    if (tile == null || tile.GetType() == typeof(EmptyTile)) { continue; }

                    Button button = new Button();
                    button.Tag = tile;
                    button.Click += CharacterButton_Click;
                    button.Text = tile.Symbol.ToString();
                    button.Width = 20;
                    button.Height = 20;
                    button.Location = new Point(tile.X * 20, tile.Y * 20);
                    this.Controls.Add(button);
                }
            }
        }

        private void CharacterButton_Click(object sender, System.EventArgs e)
        {
            frmCharacterStats frm = new frmCharacterStats( (Character)(((Button)sender).Tag) );
            frm.Show();
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Up: Game.MovePlayer(Character.Movement.Up);ClearPlayingField();RenderMap(Game.MapCreate); break;
                case (char)Keys.Down: Game.MovePlayer(Character.Movement.Down); ClearPlayingField(); RenderMap(Game.MapCreate); break;
                case (char)Keys.Left: Game.MovePlayer(Character.Movement.Left); ClearPlayingField(); RenderMap(Game.MapCreate); break;
                case (char)Keys.Right: Game.MovePlayer(Character.Movement.Right); ClearPlayingField(); RenderMap(Game.MapCreate); break;
            }
        }
    }
}

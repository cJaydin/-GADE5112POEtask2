using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE5112POE
{
    class Gold : Item
    {
        protected int goldDrop;

        protected int GoldDrop { get => goldDrop; set => goldDrop = value; }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public Gold(int x, int y) : base(x, y, '$')
        {
            Random r = new Random();
            goldDrop = r.Next(1, 6);
        }
    }
}

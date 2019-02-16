using Jypeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongJypeli
{
    class AI : Maila
    {
        private Pallo pallo;

        public AI(double width, double height, Vector position, Pallo pallo) : base(width, height, position)
        {
            this.pallo = pallo;
            this.IsUpdated = true;
        }

        public override void Update(Time time)
        {
            if (pallo.Position.Y > this.Position.Y + 10)
            {
                base.Liikuta(1);
            }
            else if (pallo.Position.Y < this.Position.Y - 10)
            {
                base.Liikuta(-1);
            }
            else
            {
                base.Liikuta(0);
            }
        }
    }
}

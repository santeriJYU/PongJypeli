using Jypeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongJypeli
{
    class Maila : PhysicsObject
    {
        private static double nopeus = 200;

        public Maila(double width, double height) : base(width, height)
        {
            this.Shape = Shape.Rectangle;
            this.MakeStatic();
            this.Restitution = 1.0;
        }

        protected void Liikuta(double ohjausNopeus)
        {
            if (ohjausNopeus > 1)
            {
                ohjausNopeus = 1;
            }
            else if (ohjausNopeus < -1)
            {
                ohjausNopeus = -1;
            }

            this.Velocity = new Vector(0, nopeus * ohjausNopeus);
        }
    }
}

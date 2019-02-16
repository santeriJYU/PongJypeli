using Jypeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongJypeli
{
    class Maila : PhysicsObject
    {
        private static double nopeus = 300;
        private Vector initialPosition;

        public Maila(double width, double height, Vector position) : base(width, height)
        {
            this.Shape = Shape.Rectangle;
            this.MakeStatic();
            this.Restitution = 1.0;
            this.Position = position;
            initialPosition = position;
        }

        public void Liikuta(double ohjausNopeus)
        {
            if (ohjausNopeus > 1)
            {
                ohjausNopeus = 1;
            }
            else if (ohjausNopeus < -1)
            {
                ohjausNopeus = -1;
            }

            if (this.Top < Game.Level.Top && ohjausNopeus > 0 || this.Bottom > Game.Level.Bottom && ohjausNopeus < 0)
            {
                this.Velocity = new Vector(0, nopeus * ohjausNopeus);
            }
            else
            {
                this.Velocity = new Vector(0, 0);
            }
        }

        public void Reset()
        {
            this.Position = initialPosition;
        }

    }
}

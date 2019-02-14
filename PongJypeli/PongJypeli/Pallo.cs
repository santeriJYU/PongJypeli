using Jypeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongJypeli
{
    class Pallo : PhysicsObject
    {
        private static Vector initialSpeed = new Vector(-500, 0);

        public static Vector InitialSpeed
        {
            get => initialSpeed;
        }

        public Pallo(double radius) : base(radius, radius)
        {
            this.Shape = Shape.Circle;
            this.Restitution = 1.0;
        }

    }

}


using Jypeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongJypeli
{
    class Pallo : PhysicsObject
    {
        private static Vector InitialSpeed = new Vector(500, 0);
        private double Speed = Pallo.InitialSpeed.X;

        public Pallo(double radius) : base(radius, radius)
        {
            this.Shape = Shape.Circle;
            this.CanRotate = false;
            this.Restitution = 1.0;
            this.KineticFriction = 0.0;
            this.StaticFriction = 0.0;
            this.Velocity = Pallo.InitialSpeed;
            this.IsUpdated = true;
        }

        public void Reset()
        {
            this.Position = new Vector(0, 0);
            this.Velocity = Pallo.InitialSpeed;
            this.Speed = Pallo.InitialSpeed.X;
        }

        public void OsuMailalla(bool suunta, double kulma)
        {
            this.Hit(new Vector(suunta ? -10 : 10, 5 * kulma));
            this.Speed += 50;
        }
        public override void Update(Time time)
        {
            //if (this.Velocity.X < Pallo.InitialSpeed.X && this.Velocity.X > -Pallo.InitialSpeed.X)
            {
                this.Velocity = new Vector(this.Velocity.X > 0 ? this.Speed : -this.Speed, this.Velocity.Y);
            }
        }

    }

}


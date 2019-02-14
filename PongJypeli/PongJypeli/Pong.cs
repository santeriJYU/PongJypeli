using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

namespace PongJypeli
{
    public class Pong : PhysicsGame
    {
        private static double palloRadius = 40.0;
        private static Vector palloPosition = new Vector(0, 0);

        private static Vector mailaSize = new Vector(20.0, 100.0);

        private void UusiPeli()
        {
            LuoKentta();
            AsetaOhjaimet();
        }

        private void LuoKentta()
        {
            Level.CreateBorders(1.0, false);
            Level.Background.Color = Color.Black;

            Pallo pallo = LuoPallo();
            Maila mailaPelaaja = LuoMaila(new Vector(Level.Left + 20, 0));
            Maila mailaAI = LuoMaila(new Vector(Level.Right + 20, 0));

            pallo.Hit(Pallo.InitialSpeed);

            Camera.ZoomToLevel();
        }

        private Pallo LuoPallo()
        {
            Pallo pallo = new Pallo(palloRadius);
            pallo.Position = palloPosition;
            Add(pallo);
            return pallo;
        }

        private Maila LuoMaila(Vector position)
        {
            Maila maila = new Maila(mailaSize.X, mailaSize.Y);
            maila.Position = position;
            Add(maila);
            return maila;
        }

        private void AsetaOhjaimet()
        {
            PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
            Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        }

        public override void Begin()
        {
            UusiPeli();
        }
    }
}
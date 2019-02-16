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

        private Pallo pallo;

        private Maila pelaaja;
        private AI ai;

        private Laskuri pelaajaLaskuri;
        private Laskuri aiLaskuri;

        private void UusiPeli()
        {
            LuoKentta();
            LuoLaskurit();
            AsetaOhjaimet(pelaaja);
        }

        private void LuoKentta()
        {
            Level.CreateBorders(1.0, false);
            Level.Background.Color = Color.Black;

            pallo = LuoPallo();

            pelaaja = new Maila(mailaSize.X, mailaSize.Y, new Vector(Level.Left + 20, 0));
            Add(pelaaja);

            ai = new AI(mailaSize.X, mailaSize.Y, new Vector(Level.Right - 20, 0), pallo);
            Add(ai);

            Camera.ZoomToLevel();
        }

        private Pallo LuoPallo()
        {
            Pallo pallo = new Pallo(palloRadius);
            pallo.Position = palloPosition;
            Add(pallo);
            AddCollisionHandler(pallo, KasittelePallonTormays);
            return pallo;
        }

        private void KasittelePallonTormays(PhysicsObject pPallo, PhysicsObject kohde)
        {
            Pallo pallo = pPallo as Pallo;

            if (pallo.Left <= Level.Left)
            {
                aiLaskuri.Kasvata(ResetGame);
            }
            else if (pallo.Right >= Level.Right)
            {
                pelaajaLaskuri.Kasvata(ResetGame);
            }
            else if (kohde is Maila)
            {
                pallo.OsuMailalla(kohde is AI, kohde.Y - pallo.Y);
            }
        }

        private void ResetGame()
        {
            pallo.Reset();
            pelaaja.Reset();
            ai.Reset();
        }

        private void LuoLaskurit()
        {
            pelaajaLaskuri = LuoLaskuri(new Vector(Level.Left + 100, Level.Top - 100));
            aiLaskuri = LuoLaskuri(new Vector(Level.Right - 100, Level.Top - 100));
        }

        private Laskuri LuoLaskuri(Vector position)
        {
            Laskuri laskuri = new Laskuri(position);
            Add(laskuri.Naytto);
            return laskuri;
        }

        private void AsetaOhjaimet(Maila pelaaja)
        {
            PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
            Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");

            Keyboard.Listen(Key.Up, ButtonState.Down, delegate () { pelaaja.Liikuta(1); }, "Liikuta mailaa ylös");
            Keyboard.Listen(Key.Up, ButtonState.Released, delegate () { pelaaja.Liikuta(0); }, "Pysäytä maila");

            Keyboard.Listen(Key.Down, ButtonState.Down, delegate () { pelaaja.Liikuta(-1); }, "Liikuta mailaa alas");
            Keyboard.Listen(Key.Down, ButtonState.Released, delegate () { pelaaja.Liikuta(0); }, "Pysäytä maila");
        }

        public override void Begin()
        {
            UusiPeli();
        }
    }
}
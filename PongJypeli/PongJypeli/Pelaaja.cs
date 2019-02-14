using Jypeli;
using Jypeli.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongJypeli
{
    class Pelaaja : Maila
    {
        public Pelaaja(double width, double height) : base(width, height)
        {
            this.AsetaOhjaimet();
        }

        public void AsetaOhjaimet()
        {
            //Delegate l = new Delegate({ base.Liikuta(1) });

            Keyboard.Listen(Key.A, ButtonState.Down, delegate() { base.Liikuta(1); }, "Liikuta mailaa ylös");
            //Keyboard.Listen(Key.A, ButtonState.Released, PysaytaMaila1, null);
        }
    }


}

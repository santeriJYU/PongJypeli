using Jypeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongJypeli
{
    class Laskuri : IntMeter
    {
        public Label Naytto { get; private set; }

        public Laskuri(Vector position) : base(0)
        {
            LisaaNaytto(position);
        }

        private Label LisaaNaytto(Vector position)
        {
            Naytto = new Label();
            Naytto.BindTo(this);
            Naytto.X = position.X;
            Naytto.Y = position.Y;
            Naytto.TextColor = Color.White;
            return Naytto;
        }

        public void Kasvata(Action reset)
        {
            this.Value++;
            reset();
        }

    }
}

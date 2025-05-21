using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helsinki1952
{
    public class Versenyzo
    {
        public Versenyzo(string sor)
        {
            string[] temp = sor.Split(' ');

            Helyezes = int.Parse(temp[0]);
            VersenyzokSzama = int.Parse(temp[1]);
            Sportag = temp[2];
            Versenyszam = temp[3];
        }

        public int Helyezes { get; private set; }
        public int VersenyzokSzama { get; private set; }
        public string Sportag { get; private set; }
        public string Versenyszam { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calabozo
{
    internal class Monstruo//Clase Mounstro
    {
        //Seters y geters
        public int X { get; set; }
        public int Y { get; set; }
        public int Vida { get; set; }
        private Random random = new Random();


        public Monstruo(int x, int y, int vida)
        {
            X = x;
            Y = y;
            Vida = vida;
        }

        public void RecibirDanio(int dano)
        {

            Vida -= dano;


        }

    }
}

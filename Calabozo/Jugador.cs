using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calabozo
{
    internal class Jugador//Clase Jugador
    {
        //seters y geters
        public int X { get; set; }
        public int Y { get; set; }

        private static int vida = 100;
        public static int Vida
        {
            get => vida;
            set => vida = value;
        }

        private Random random = new Random();

        public Jugador(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int Atacar(Monstruo monstruo)//obtenemos al mounstro al que atacamos
        {
            return random.Next(5, 15);
        }

        public void RecibirDanio()
        {
            int danoRecibido = random.Next(3, 8);
            Vida -= danoRecibido;

            if (Vida <= 0)
            {
                MessageBox.Show("¡Has sido derrotado!");
                Application.Exit(); 
            }
        }
    }
}

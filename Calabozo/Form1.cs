using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calabozo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Calabozo.jpg");//Cargamos la imagen para el fondo del juego
            this.BackgroundImage = img;//la asignamos como background
            this.BackgroundImageLayout = ImageLayout.Stretch;//le asignamos su respectivo layout
            this.StartPosition = FormStartPosition.CenterScreen;//sentramos el marco de la aplicacion
            lectura("Nivel_1.txt");

        }
        //Variables Globales
        private List<string> mapa = new List<string>();//lista para el mapa
        private List<Monstruo> monstruos = new List<Monstruo>();//lista de los mounstros
        Random random = new Random();
        Jugador jugador;// declaramos al jugador 
        int contador = 1;//este numero hara referencia al mapa actual


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        void lectura(string ruta)
        {
            try
            {
                mapa.Clear();
                StreamReader reader = new StreamReader(ruta, Encoding.Default);
                int row = 0;

                while (!reader.EndOfStream)
                {
                    string linea = reader.ReadLine();
                    mapa.Add(linea);

                    if (linea.Contains("!"))
                    {
                        int x = row;
                        int y = linea.IndexOf("!");

                        jugador = new Jugador(x, y);
                        //leemos el mapa y si contiene este signo obtenemos la posocion de ese seigno y se la asignamos al jugador inicializando lo 
                    }
                    row++;


                }
                generar_Mounstros();
                
                if (jugador == null)
                {
                    throw new Exception("No se encontró la posición del jugador en el mapa.");
                }
                posicion_mounstros();
                actualizarMapa();
                ActualizarVidaJugador();
                reader.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error en la lectura: " + e.Message);
            }
        }

        private void turno(string seleccion)
        {
            //esta clase nos ayudara a ir pasando los turnos segun que obtenga por parametros
            if (seleccion == "u")
            {
                mover_jugador(-1, 0);
                moverMonstruos();

            }
            else if (seleccion == "d")
            {
                mover_jugador(1, 0);
                moverMonstruos();

            }
            else if (seleccion == "l")
            {
                mover_jugador(0, -1);
                moverMonstruos();
            }
            else if (seleccion == "r")
            {
                mover_jugador(0, 1);
                moverMonstruos();
            }
            else if (seleccion == "s")
            {
                moverMonstruos();
            }
            
            posicion_mounstros();
            ActualizarVidaJugador();
            actualizarMapa();
            cambiar_Nivel();
        }

        private void mover_jugador(int dx, int dy)
        {
            //recibimos por parametros hacia donde se desea mover el jugador para sumarle a la posocion actual la posicion que se desea
            int nuevaX = jugador.X + dx;
            int nuevaY = jugador.Y + dy;

            if (nuevaX >= 0 && nuevaX < mapa.Count &&
                nuevaY >= 0 && nuevaY < mapa[nuevaX].Length &&
                mapa[nuevaX][nuevaY] == '-')
            {
                //verificamos que la posicion a la que se desea mover el jugador sea una posiciona valida
                mapa[jugador.X] = mapa[jugador.X].Remove(jugador.Y, 1).Insert(jugador.Y, "-");
                jugador.X = nuevaX;
                jugador.Y = nuevaY;
                mapa[jugador.X] = mapa[jugador.X].Remove(jugador.Y, 1).Insert(jugador.Y, "!");
                actualizarMapa();//movemos al jugador y actualizamos el mapa 
            }

            
            int[] dxArray = { -1, 1, 0, 0 }; 
            int[] dyArray = { 0, 0, -1, 1 }; 

            for (int i = 0; i < 4; i++)
            {
                int adyacenteX = jugador.X + dxArray[i];
                int adyacenteY = jugador.Y + dyArray[i];

                // verificar las posiciones adyacentes al jugador con arreglos 

                if (adyacenteX >= 0 && adyacenteX < mapa.Count &&
                    adyacenteY >= 0 && adyacenteY < mapa[adyacenteX].Length)//si las posicionas adyasentes al jugador son validas
                {
                    if (mapa[adyacenteX][adyacenteY] == 'm')// si encontramos una mounstro en las posiciones adyasentes al jugador
                    {
                        Monstruo monstruo = null;// creamos un mounstro vcio que posteror mete asignaremos al mounstro que encontro adyasente
                        foreach (var m in monstruos)// recorremos la lista de mounstros
                        {
                            if (m.X == adyacenteX && m.Y == adyacenteY) //si la posicion en la que se encuentra el mounstro resulto ser adyasente al jugador entonces este es el mpunstro que estams buscando
                            {
                                monstruo = m; //asignamos mousntro al mounstro vacio de el principio para poder usarlo en el ataque 
                                break; 
                            }
                        }

                        if (monstruo != null)//si resulta que encontro al mounstro y por lo tanto la variable mounstro no esta vacia
                        {
                            int dano = jugador.Atacar(monstruo);//atacamos al mounstro
                            monstruo.RecibirDanio(dano);//el mounstro recive el dano

                            MessageBox.Show("¡El jugador ataca al monstruo! Daño: " + dano + ". Vida del monstruo: " + monstruo.Vida);

                            if (monstruo.Vida <= 0)//si la vida del mounstro es negativa
                            {
                                monstruos.Remove(monstruo);//removemos por completo al mounstro
                                mapa[adyacenteX] = mapa[adyacenteX].Remove(adyacenteY, 1).Insert(adyacenteY, "-");//asignamoos un signigo "-" en su lugar
                                actualizarMapa();//actualizamos el mapa
                            }
                        }
                    }
                }
            }
        }
        private void generar_Mounstros()
        {
            monstruos.Clear();//vaciamos la lista de mounstros
            txt_info.Clear();//limpiamos el txt de las posiciones
            for (int i = 0; i < 3; i++)
            {
                int x, y;

                do
                {
                    //verifico la longitud del mapa tanto en x como en y 
                    x = random.Next(mapa.Count);
                    y = random.Next(mapa[x].Length);
                }
                
                while (mapa[x][y] != '-'); //mientar la posicion donde quiero asigbar un mounstro sea valida

                int vida = random.Next(15, 30); //asignamos la vida al mounstro
                //mostramos la informacion de cada mousntro inicial
                if (i == 0) txt_info.Text += "m1: " + vida + "hp\n\r\n";
                else if (i == 1) txt_info.Text += "m2: " + vida + "hp\n\r\n";
                else if (i == 2) txt_info.Text += "m3: " + vida + "hp\n\r\n";
                // metemos los mounstros en sus posiciones aleatorias 
                mapa[x] = mapa[x].Remove(y, 1).Insert(y, "m"); 

                monstruos.Add(new Monstruo(x, y, vida)); //creamos a los mounstros en sus respectivas clases y los metemos al arreglo 
                
            }
        }
        private void moverMonstruos()
        {
            foreach (var monstruo in monstruos)// recorro el areglo de mousntros
            {
                int[] dx = { -1, 1, 0, 0 };
                int[] dy = { 0, 0, -1, 1 };

                bool atacado = false; 

                for (int i = 0; i < 4; i++)
                {
                    //los mounstros se mueven aleatoriamente
                    int adyacenteX = monstruo.X + dx[i]; 
                    int adyacenteY = monstruo.Y + dy[i];

                    if (adyacenteX >= 0 && adyacenteX < mapa.Count &&
                        adyacenteY >= 0 && adyacenteY < mapa[adyacenteX].Length &&
                        mapa[adyacenteX][adyacenteY] == '!')
                    {
                        //si algun mounstro se encuentra adyasente al jugador que el jugador reciva dano

                        jugador.RecibirDanio();

                        MessageBox.Show("¡El monstruo ataca al jugador!");

                        atacado = true;
                        break; 
                    }
                }

                
                if (!atacado)//si el mounstro no esta atacando 
                {
                    //recostamos la distancia entre el jugaddor y el mounstro para saver que tan serca se encuentran uno del otro
                    int distanciaX = monstruo.X - jugador.X;
                    int distanciaY = monstruo.Y - jugador.Y;

                    
                    if (distanciaX <= 4 && distanciaY <= 4)//si el mousntro se encuentra proximo al jugador a una distancia de 4
                    {
                        //asignamos estas variables que seran la posicion a donde se acercara el mounstro al jugador 
                        int direccionX = 0;
                        int direccionY = 0;

                        
                        if (monstruo.X < jugador.X) direccionX = 1; // si la posicion en x del mousntro es menor que la de el jugador entonces el mousntro se tiene que mover a la derecha
                        else if (monstruo.X > jugador.X) direccionX = -1;// si el mountro se encuentra a la derecha del jugador entonces nos movemos a la hizquierda

                        if (monstruo.Y < jugador.Y) direccionY = 1; // si el mounstro se encuentra abajo del jugador entonces nos movemos hacia arriba
                        else if (monstruo.Y > jugador.Y) direccionY = -1; // si el mounounstro esta ariba del jugador nos movemos hacia abajo

                        //asignamos la posicion que se acerca al jugador 
                        int nuevaX = monstruo.X + direccionX;
                        int nuevaY = monstruo.Y + direccionY;

                        if (nuevaX >= 0 && nuevaX < mapa.Count &&
                            nuevaY >= 0 && nuevaY < mapa[nuevaX].Length &&
                            mapa[nuevaX][nuevaY] == '-')
                        {// si la poscicion a la que nos queremos mover es valida
                            
                            // asignamos la posicion y remplazamos la - y m
                            mapa[monstruo.X] = mapa[monstruo.X].Remove(monstruo.Y, 1).Insert(monstruo.Y, "-");
                            monstruo.X = nuevaX;
                            monstruo.Y = nuevaY;
                            mapa[monstruo.X] = mapa[monstruo.X].Remove(monstruo.Y, 1).Insert(monstruo.Y, "m");
                        }
                    }
                    else
                    {
                        // si no nos encontramos serca del jugador nos movemos en posiciones aleatorisas pero validas
                        int direccion = random.Next(4);
                        int nuevaX = monstruo.X + dx[direccion];
                        int nuevaY = monstruo.Y + dy[direccion];

                        if (nuevaX >= 0 && nuevaX < mapa.Count &&
                            nuevaY >= 0 && nuevaY < mapa[nuevaX].Length &&
                            mapa[nuevaX][nuevaY] == '-')
                        {
                            
                            mapa[monstruo.X] = mapa[monstruo.X].Remove(monstruo.Y, 1).Insert(monstruo.Y, "-");
                            monstruo.X = nuevaX;
                            monstruo.Y = nuevaY;
                            mapa[monstruo.X] = mapa[monstruo.X].Remove(monstruo.Y, 1).Insert(monstruo.Y, "m");
                        }
                    }
                }
            }
        }




        private void cambiar_Nivel()
        {
            bool cerca = Escaleras();// si nos enontranmos proximos a una escaera cambiamos el nivel 
            String ruta = "";
            if (cerca)
            {
                contador++;

                if (contador == 2)
                {
                    ruta = "Nivel_2.txt";
                    lectura(ruta);
                    actualizarMapa();
                }
                else
                {
                    ruta = "Nivel_3.txt";
                    lectura(ruta);
                    actualizarMapa();
                }
                

            }
            
        }
        private bool Escaleras()
        {
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 }; 

            for (int i = 0; i < 4; i++)
            {
                int nuevaX = jugador.X + dx[i];
                int nuevaY = jugador.Y + dy[i];

                if (nuevaX >= 0 && nuevaX < mapa.Count &&
                    nuevaY >= 0 && nuevaY < mapa[nuevaX].Length)
                {
                    if (mapa[nuevaX][nuevaY] == '+')
                    {
                        return true; 
                    }
                    else if (mapa[nuevaX][nuevaY] == '/')
                    {

                        MessageBox.Show("Felizidades has Salido del calavozo");
                        Application.Exit();
                        return false;

                    }
                }
            }
            return false;
        }
        public void ActualizarVidaJugador()
        {
            txt_vidaP.Clear();
            txt_vidaP.Text += "Vida Jugador: " + Jugador.Vida.ToString() + "\n\r\r";
        }
        private void posicion_mounstros()
        {
            txt_info.Clear();
            txt_posiciones.Clear();

            for (int i = 0; i < monstruos.Count; i++)
            {
                if (i == 0)
                {
                    txt_info.Text += "m1: " + monstruos[i].Vida + "hp\r\n";
                    txt_posiciones.Text += "m1: (" + monstruos[i].X + "," + monstruos[i].Y + ")\r\n";
                }
                else if (i == 1)
                {
                    txt_info.Text += "m2: " + monstruos[i].Vida + "hp\r\n";
                    txt_posiciones.Text += "m2: (" + monstruos[i].X + "," + monstruos[i].Y + ")\r\n";
                }
                else if (i == 2)
                {
                    txt_info.Text += "m3: " + monstruos[i].Vida + "hp\r\n";
                    txt_posiciones.Text += "m3: (" + monstruos[i].X + "," + monstruos[i].Y + ")\r\n";
                }
            }
        }



        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            string seleccion = "";
            if (e.KeyCode == Keys.Up)
            {
                seleccion = "u";

            }
            else if (e.KeyCode == Keys.Down)
            {
                seleccion = "d";

            }
            else if (e.KeyCode == Keys.Left)
            {
                seleccion = "l";

            }
            else if (e.KeyCode == Keys.Right)
            {
                seleccion = "r";

            }
            else if (e.KeyCode == Keys.Space)
            {

                seleccion = "s";
            }
            turno(seleccion);
        }
        private void actualizarMapa()
        {
            txt_mapa.Text = string.Join(Environment.NewLine, mapa);
            txt_mapa.Refresh();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace space_invader
{
    public class Alien : PictureBox // Declaramos esta herencia para hacer que herede metodos relacionados al picturebox.
    {

        //private int puntos;
        //public int Puntos
        //{
        //    get
        //    {
        //        return puntos;
        //    }
        //    set
        //    {
        //        puntos = value;
        //    }
        //}
        private int velocidad; // Declaramos esta variable de modo privada porque es un atributo que queremos mantener durante el juego.
        public int Velocidad // Este metodo nos permite acceder a  la variable privada y tambien cambiarla usando el nombre el mismo nombre del metodo.
        {
            get // Buscar
            {
                return velocidad; //Devolver el valor que tenga la variable.
            }

            set // Asigna 
            {
                velocidad = value;// asignale  ese valor a la variable
            }
        }
        private bool ultimo;// es un propiedad (aun no implementada)
        public bool Ultimo// como acceder esa variable
        {
            get
            {
                return ultimo;
            }

            set
            {
                ultimo = value;
            }
        }
        private int vida;// propiedad de los Alien por lo que va en privado
        public int Vida// Metodo para acceder al valor
        {
            get
            {
                return vida;
            }

            set
            {
                vida = value;
            }
        }
        private bool direccion;// variable creada para los disparos 


        public Alien() // Metodo constructor
        {
            //puntos = 0;
            velocidad = 5;
            ultimo = false; // Esto es para el berseker 
            vida = 0;
            direccion = false;// Esto lo usamos mas adelante para decirle al programa que dispare esto hacia abajo (false)
            //picturebox
            Location = new Point(0, -30);
            Size = new Size(50, 50);
            Image = Properties.Resources.Alien1;
            SizeMode = PictureBoxSizeMode.Zoom;
            BackColor = Color.Transparent;
//            BorderStyle = BorderStyle.Fixed3D;
        }

        //public Alien(int velocidadInicial)
        //{
        //    velocidad = velocidadInicial;
        //    ultimo = false;
        //    vida = 0;
        //    direccion = false;
        //    //picturebox
        //    Location = new Point(0, 0);
        //    Size = new Size(50, 50);
        //    Image = Properties.Resources.Alien1;
        //    SizeMode = PictureBoxSizeMode.Zoom;
        //    BackColor = Color.Transparent;
        //    //            BorderStyle = BorderStyle.Fixed3D;
        //}
        
        // 
        public void Mover(int ancho)//Esta funcion representa el movimiento del alien
        {
            if (Bounds.Right + 20 >= ancho)//Aqui controla el limite derecho
            {
                direccion = false;
                Location = new Point(Location.X, Location.Y + 50);
            }

            
            if (Location.X <= 0)//Aqui controla el limite izquierdo
            {
                direccion = true;
                Location = new Point(Location.X, Location.Y + 50);
            }


            if (direccion)
            {
                Location = new Point(Location.X + velocidad, Location.Y);

            }
            else
            {
                Location = new Point(Location.X - velocidad, Location.Y);
            }
        }

        public void Berzerker()
        {
            Image = Properties.Resources.boss;
        }

        public void disparar(ControlCollection controlesDelFormulario)
        {
            Disparo dis = new Disparo(new Point(Width / 2 + Location.X, Location.Y), false);
            controlesDelFormulario.Add(dis);
           
        }

        public bool colisionar(ControlCollection controldecoliciones)
        {
            bool colision = false;
            foreach (Control a in controldecoliciones)
            {
                if (a.GetType() == typeof(Disparo))
                {
                    Disparo d = (Disparo)a;
                    
                    if (Bounds.IntersectsWith(a.Bounds) && d.Direccion == true)
                    {
                        //ganarpuntos();
                        
                       
                        colision = true;
                        
                        controldecoliciones.Remove(a);
                        controldecoliciones.Remove(this);
                        //Puntos = Puntos + contador;
                                                                       
                    }                    
                }
            }
            return colision;
        }
        public void transformacion()
        {
            if (ultimo == true)
            {
                Berzerker();
            }
        }
        public void Ganar(Panel gana, int puntos)
        {
               if (puntos == 50)
            {
                //MessageBox.Show(gana.Visible.ToString());
                gana.Visible = true;
                //MessageBox.Show(gana.Visible.ToString());
                Thread.Sleep(2000);
                Form1.ActiveForm.Close();
                Form2 mostrar = new Form2();
                mostrar.Show();
            }
        }
    }
}
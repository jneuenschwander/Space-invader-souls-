using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace space_invader
{
    public class Disparo : PictureBox // heredamos metodos de picturebox 
    {
        private int velocidad;//propiedad de disparo
        public int Velocidad// metodo para acceder a la velocidad
        {
            get
            {
                return velocidad;
            }

            set
            {
                velocidad = value;
            }
        }
        private bool direccion; // propiedad del disparo dado por el personaje
        public bool Direccion // metodo para pasarle el valor que tenga el personaje
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }

        }
        public Disparo(Point puntoInicial, bool direccion)// Y esto amigos mios es lo que no estaba matando 
        { // este constructor funciona con los parametros de punto inicial y la direccion sea true o false
            velocidad = 6;
            this.direccion = direccion; // esto se lo pasamos al usarla en las clases alien y nave
            Size = new Size(10, 20);
            Image = Properties.Resources.shot;// De donde sacamos la imagen
            SizeMode = PictureBoxSizeMode.Zoom;
            BackColor = Color.Transparent;
            if(direccion == true)// aqui decimos si es true  sumale restale en y para que vaya hacia arriba
            {
                Location = new Point(puntoInicial.X - Width / 2, puntoInicial.Y - Height);
            }
            else // si es false entonces que vaya hacia abajo 
            {
                Location = new Point(puntoInicial.X - Width / 2, puntoInicial.Y + Height + 50);
            }
        }
        public void Disparar(ControlCollection ControlesForm) //aqui hacemos el movimiento de la Bala
        {
            if (direccion == true)
            {
                
                Location = new Point(Location.X, Location.Y - 20); // que suba

            }
            else
            {
                Location = new Point(Location.X, Location.Y + 20);// que baje

            }
            if (this.Location.Y > 582 || this.Location.Y <0)
            {
                ControlesForm.Remove(this);
            }
        }
        
    }
   
}
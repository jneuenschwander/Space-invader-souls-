using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace space_invader 
{
    public class Nave : PictureBox // con esto heredamos metodos de la clase picturebox

    {

        public Teclas teclas;// creamos una variable de tipo teclas (mas adelante la usamos
        private int vida;// propiedad de nave
        public int Vida// metodo para acceder a la vida *nota nos falta implementar las vidas*
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
        private int velocidad; //propiedad de nave
        public int Velocidad// Como acceder a la variable velocidad
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
        private int daño;// propiedad de la Nave.
        public int Daño// metodo para modificar el daño.
        {
            get
            {
                return daño;
            }

            set
            {
                daño = value;
            }
        }
        private bool direccion = true;// Con esto indicamos que dispare hacia arriba(true).
        public Nave(int ancho)// a este metodo le hemos colocado un parametro que es ancho que luego referenciaremos con wigth
        {

            vida = 3;
            velocidad = 5;
            daño = 0;
            Location = new Point(ancho / 2, 500);
            Size = new Size(50, 50);
            Image = Properties.Resources.nave2;
            SizeMode = PictureBoxSizeMode.Zoom;
            BackColor = Color.Transparent;
            //BorderStyle = BorderStyle.Fixed3D; // esto es para ver el tamaño real de la imagen

        }

        public void mover(Teclas teclas, int maximoHorizontal) // he aqui el metodo contructor de nave, le pasamos las teclas de nuestra enumeracion y la variable maximo horizontal para controlar limites
        {
            switch (teclas) // switch para los eventos del teclado
            {
                case Teclas.derecha:// aqui le decimos que pasara si oprime derecha
                    if (Location.X < maximoHorizontal - Width) // si la localización en x es menor al maximoHorizontal menos el ancho de la nave...
                        Location = Location = new Point(Location.X + 10, Location.Y); // Que nos sume en la cordenada x + 10
                    break;
                case Teclas.izquierda: //aqui le decimos que pasara si oprime izquierda
                    if (Location.X > 0) // si la cordenada en x es mayor que 0. 
                    {
                        Location = new Point(Location.X - 10, Location.Y); // Entonces se movera 10
                    }
                    break;
                default:
                    break;
            }
        }
        public void disparar(ControlCollection controlesDelFormulario) //En este metodo para disparar le pasamos ControlColletion para tener los controles de formulario para la bala
        {
            Disparo dis = new Disparo(new Point(Width / 2 + Location.X, Location.Y), direccion);// aqui instanciamos un objeto disparo (y le pasamos los parametros de localizacion X y Y junto con el valor booleano de direccion)
            controlesDelFormulario.Add(dis); // y la agregamos al formulario NOTA: no llamamos a Controls porque el parametro del constructor "controlesDelFormulario" nos facilita esto. 
            if (this.Location.Y == 0)//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            {
                Controls.Remove(this);
            }
        }
        public void colisionar(ControlCollection controldecoliciones, Panel game) //metodo para eliminar la nave y el disparo
        {
            foreach (Control a in controldecoliciones) // si encuentra un objeto a
            {
                if (a.GetType() == typeof(Disparo))// busque que tipo es?
                {
                    if (Bounds.IntersectsWith(a.Bounds)) //si intersecta con un objeto a 
                    {
                        Corazon vidas = new Corazon();
                        controldecoliciones.Remove(a);
                        vida -= 1;
                        
                        if (vida == 0)
                        {
                            
                            controldecoliciones.Remove(a); // remueve el objeto 
                            controldecoliciones.Remove(this);// remueve la bala
                            Gameover(game);
                        } 
                    }
                }
            }
        }

        public void Gameover(Panel game)
        {
            Alien puntaje = new Alien();
            game.Visible = true;

            //MessageBox.Show("Has perdido  " + puntaje.Puntos);
            Thread.Sleep(2000); 
            //Form1 cerrar = new Form1();
            Form1.ActiveForm.Close();
            Form2 mostrar = new Form2();
            mostrar.Show();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace space_invader
{

    public partial class Form1 : Form
    {
        int puntos = 0;
        Nivel obj; // instanciamos afuera para tener mas acceso 
        Nave star;        
        Corazon vida1;
        Corazon vida2;
        Corazon vida3;
        Roca rock0;
        Roca rock1;
        Roca rock2;
        Roca rock3;
        Roca rock4;
        private int count = 0; // contador *no implementado aun*
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SoundPlayer pay = new SoundPlayer(Properties.Resources.FML);           
            //pay.Play();
            vida1 = new Corazon(new Point(995, 2));
            vida2 = new Corazon(new Point(1070, 2));
            vida3 = new Corazon(new Point(1135, 2));
            obj = new Nivel();
            star = new Nave(Width); //nave toma un parametro ancho por lo que colocamos width
            rock0 = new Roca(new Point(0,440));
            rock1 = new Roca(new Point(Width /4,440));
            rock2 = new Roca(new Point(Width /2, 440));
            rock3 = new Roca(new Point(Width*3/ 4, 440));
            rock4 = new Roca(new Point(Width-65, 440));
            timerspawnenemigos.Enabled = true;
            Controls.Add(star);
            Controls.Add(rock0);
            Controls.Add(rock1);
            Controls.Add(rock2);
            Controls.Add(rock3);
            Controls.Add(rock4);
            Controls.Add(vida1);
            Controls.Add(vida2);
            Controls.Add(vida3);
            


            
        }


        private void timerdelmovimiento_Tick(object sender, EventArgs e)// usamos este timer para los aliens
        {
            star.colisionar(Controls, gameover); // metodo de colicionar de la nave
            
            foreach (Control a in Controls)
            {

                if (a.GetType() == typeof(Alien))
                {
                    Alien encontrado = (Alien) a; // casteo para usar el objeto alien
                    encontrado.Mover(Width);// para moverlo pasamos tambien un ancho
                    if (encontrado.colisionar(Controls) == true) {
                        puntos += 1;
                        encontrado.Ganar(ganaste, puntos);

                    }// para colisionar pasamos controls que es de controlcolletion
                    Random r = new Random();// un numero random la probabilidad del disparo
                    if (r.Next(0, 100) > 96) // probabilidad de disparo
                    {
                        encontrado.disparar(Controls);// llamamos al metodo disparar de la clase alien
                    }
                }

               if (a.GetType() == typeof(Disparo))// esto lo usamos paro poder hacer que la bala se mueva
                {
                    Disparo disparoEncontrado = (Disparo)a; // casteamos ahora el objeto a
                    disparoEncontrado.Disparar(Controls);// efectuamos metodo
                }
               if(a.GetType()== typeof(Roca))
                {
                    Roca rocaencontrada = (Roca)a;
                    rocaencontrada.Desaparecer(Controls);
                }                
            }
        }
        
        

        private void timerspawnenemigos_Tick(object sender, EventArgs e) // timer para la orda de enemigos
        {
            Alien enemigo1 = new Alien(); // instanceamos alien
            if (count < obj.CantOrda ) // esto es para el metodo berseker 
            {
                
                Controls.Add(enemigo1); // agregar enemigo
                obj.CantOrda--;// y restar a cantidad de orda

                if (obj.CantOrda <= 0) // con esto le decimos que pare cuando ya no hayan mas
                {
                    timerspawnenemigos.Enabled = false;
                }
            }

            //count += 1; 
        }

        /*private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)// aqui programamos finalmente que hara cada boton a partir de las contantes propuestas antes en enum
            {
                case Keys.Right:// al presionar derecha
                    star.mover(Teclas.derecha, Width);// pasamos el ancho de este form1 y la funcion de la tecla como ya habiamos definido en nave
                    break;
                case Keys.Left:
                    star.mover(Teclas.izquierda, Width);// pasamos el ancho de este form1 y la funcion de la tecla como ya habiamos definido en nave
                    break;
            }
        }*/

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)// aqui programamos finalmente que hara cada boton a partir de las contantes propuestas antes en enum
            {
                
                case Keys.Space:
                    star.disparar(Controls); //pasamos el parametro controls por controlcolletion
                    break;
                case Keys.Home:
                    MessageBox.Show(Controls.Count.ToString());// esto es para saber cuantos elementos se han creado * no borrar hasta solucionar*
                    break;
            }
        }

        //private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    SoundPlayer ds = new SoundPlayer();
        //    ds.Stop();
        //}

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)// aqui programamos finalmente que hara cada boton a partir de las contantes propuestas antes en enum
            {
                case Keys.Right:// al presionar derecha
                    star.mover(Teclas.derecha, Width);// pasamos el ancho de este form1 y la funcion de la tecla como ya habiamos definido en nave
                    break;
                case Keys.Left:
                    star.mover(Teclas.izquierda, Width);// pasamos el ancho de este form1 y la funcion de la tecla como ya habiamos definido en nave
                    break;
            }
        }

        int Aliens = 1;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (star.Vida == 2)
            {
                Controls.Remove(vida1);
            }
            if (star.Vida == 1)
            {
                Controls.Remove(vida2);
            }
            if (star.Vida == 0)
            {
                Controls.Remove(vida3);
            }

            

            //foreach (Control c in Controls) {
            //    if (c is Alien) {
            //        Aliens += 1;
            //    }
            //}
            //if (Aliens <= 0)
            //{
            //    ganaste.Visible = true;
            //    MessageBox.Show("Ganastes");
            //}
            //Aliens = 0;
        }
    }
}

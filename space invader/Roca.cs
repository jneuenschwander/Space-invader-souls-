using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace space_invader
{
    public class Roca : PictureBox
    {
        private int vida;
        public int Vida
        {
            get
            {
                return Vida;
            }

            set
            {
                vida = value;
            }
        }
        public Roca(Point punto)
        {
            vida = 20;
            Image = Properties.Resources.space_invaders_escudo;
            Size = new Size(50, 50);
            Location = punto;
        }
        public void Desaparecer(ControlCollection controldecoliciones)
        {
            foreach (Control a in controldecoliciones) // si encuentra un objeto a
            {
                if (a.GetType() == typeof(Disparo))// busque que tipo es?
                {
                    if (Bounds.IntersectsWith(a.Bounds)) //si intersecta con un objeto a 
                    {
                        vida -= 2;
                        if (vida == 16)
                        {
                            controldecoliciones.Remove(a);
                            Image = Properties.Resources.muro_con_un_golpe;
                        }
                        if (vida == 12)
                        {
                            controldecoliciones.Remove(a);
                            Image = Properties.Resources.muro_despues_de_varios_golpes;
                        }
                        if (vida == 8)
                        {
                            controldecoliciones.Remove(a);
                            Image = Properties.Resources.muro_al_borde_de_la_muerte;
                        }
                        if (vida == 4)
                        {
                            controldecoliciones.Remove(a);
                            Image = Properties.Resources.muro_destruido;
                        }
                        if (vida == 0)
                        {
                            controldecoliciones.Remove(a);
                            controldecoliciones.Remove(this);
                        }
                        //controldecoliciones.Remove(a); // remueve el bala
                        //controldecoliciones.Remove(this);// remueve la objeto
                    }
                }

            }
        }
    }
}
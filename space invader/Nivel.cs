using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace space_invader
{
    public class Nivel// clase creada para poder interactuar o controlar a los aliens
    {
        private bool enOrda; 
        public bool EnOrda
        {
            get
            {
                return enOrda;
            }

            set
            {
                enOrda = value;
            }
        }

        private int cantOrda;
        public int CantOrda
        {
            get
            {
                return cantOrda;
            }

            set
            {
                cantOrda = value;
            }
        }
        public Nivel()
        {
             enOrda = false;
             cantOrda = 50;
        }
    }
}
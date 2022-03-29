using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace space_invader
{
    public class Corazon :PictureBox
    {
        public Corazon(Point punto)
        {

            Image = Properties.Resources.nave2;
            SizeMode = PictureBoxSizeMode.Zoom;
            Size = new Size(52, 26);
            Location = punto;
        }
        public Corazon()
        {

            Image = Properties.Resources.nave2;
            SizeMode = PictureBoxSizeMode.Zoom;
            Size = new Size(52, 26);
            
        }
        public void desaparecer()
        {
            

        }
    }
}
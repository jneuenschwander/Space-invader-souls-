using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace space_invader
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void inicio_Click(object sender, EventArgs e) // Aqui programamos el boton de comenzar juego (nota hay que ver como hacer que no apararezcan 2 ventanas sino una).

        {
            //Form1.ActiveForm.Close();
            Form1 mostrar = new Form1();//  Aqui instanciamos un objeto de la clase form1 donde esta el contenido del juego.
            this.Hide();
            mostrar.Show();// Aqui le pedimos que nos muestre este formulario.
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Metodo para cerrar la aplicación.
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

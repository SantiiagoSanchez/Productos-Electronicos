using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormCarrito : Form
    {
        public FormCarrito(Form1.Dato info)
        {
            InitializeComponent();

            lblProducto.Text = info.Nombre.ToString();
            lblTotal.Text =  Convert.ToString(info.Precio);            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int entero = Convert.ToInt32(lblTotal.Text);

            decimal valornumericoupdown = numericUpDown1.Value;

            decimal resultado = entero * valornumericoupdown;

            lblTotal.Text =  resultado.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡Muchas gracias por su compra!");
            button2.Text = "Cerrar";
            button1.Visible = false;
            lblTotal.Text = "";
            lblProducto.Text = "";
            label2.Text = "";
            label3.Text = "";
            numericUpDown1.Visible = false;
        }
    }
}

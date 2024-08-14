using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormLogin : Form
    {
        NegUsuarios objNegUsuario = new NegUsuarios();
        Usuario objEntUsuario= new Usuario();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Boton "Continuar sin cuenta"
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtContrasena.PasswordChar = '\0';
            }
            else 
            {
                txtContrasena.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Link registrar
        {
            FormRegister formRegister = new FormRegister();
            formRegister.Show();
            this.Hide();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string dniUser = txtDocumento.Text;
            string Contrasena = txtContrasena.Text;
            

            List<Usuario> listauser = objNegUsuario.CargarUsuario();

            bool ValidarDni = listauser.Any(i => i.IdUsuario == dniUser && i.Contrasena == Contrasena);

            if (ValidarDni == true) 
            {
                MessageBox.Show("Bienvenido/a", "Login");
                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }
            else
            {
                MessageBox.Show("Error al iniciar Sesion. Datos incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);               
                return;
            }

        }
    }
}

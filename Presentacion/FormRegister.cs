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
    public partial class FormRegister : Form
    {
        public Usuario objEntUser = new Usuario();
        public NegUsuarios objNegUser = new NegUsuarios();
        public FormRegister()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBox1.Checked)
                {
                    txtPassword.PasswordChar = '\0';
                }
                else
                {
                    txtPassword.PasswordChar = '*';
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (txtNombre.Text == "") 
            {
                MessageBox.Show("El nombre es OBLIGATORIO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtDireccion.Text == "") 
            {
                MessageBox.Show("La direccion es OBLIGATORIA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtDocumento.Text == "") 
            {
                MessageBox.Show("El documento es OBLIGATORIO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == "") 
            {
                MessageBox.Show("La contraseña es OBLIGATORIA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {

                int nGrab = -1;
                TxtBox_a_Obj();
                nGrab = objNegUser.AddUsuario("add", objEntUser);
                if (nGrab == -1) 
                {
                    MessageBox.Show("Error al registrarse");
                }
                else 
                {
                    FormLogin form = new FormLogin();
                    DialogResult res = MessageBox.Show("¡Genial, ya puedes iniciar sesión!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    switch (res)
                    {
                        case DialogResult.OK: this.Close(); form.Show(); break;
                    }
                }

            }
        }

        private void limpiar() 
        {
            txtNombre.Text = "";
            txtDocumento.Text = "";
            txtDireccion.Text = "";
            txtPassword.Text = "";
        }

        private void TxtBox_a_Obj()
        {
            objEntUser.Nombre = txtNombre.Text;
            objEntUser.IdUsuario = txtDocumento.Text;
            objEntUser.Direccion = txtDireccion.Text;
            objEntUser.Contrasena = txtPassword.Text;
        }
    }
}

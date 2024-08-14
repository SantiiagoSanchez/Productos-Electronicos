using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        
        public Producto objEntProd = new Producto();
        public NegProductos objNegProd = new NegProductos();
        DataTable lista = new DataTable();
        public Form1()
        {
            InitializeComponent();
            DGVProducts.ColumnCount = 6;
            DGVProducts.Columns[0].HeaderText = "Id";
            DGVProducts.Columns[1].HeaderText = "Nombre";
            DGVProducts.Columns[2].HeaderText = "Marca";
            DGVProducts.Columns[3].HeaderText = "Categoria";
            DGVProducts.Columns[4].HeaderText = "Precio";
            DGVProducts.Columns[5].HeaderText = "Stock";
            DataGridViewButtonColumn btnAdd = new DataGridViewButtonColumn();
            btnAdd.HeaderText = "";
            btnAdd.Name = "Add";
            btnAdd.Text = "+";
            btnAdd.UseColumnTextForButtonValue = true;
            btnAdd.Width = 40;
            DGVProducts.Columns.Add(btnAdd);
            //---------------------------------------------------
            DGVProducts.Columns[0].Width = 50;
            DGVProducts.Columns[1].Width = 100;
            DGVProducts.Columns[2].Width = 100;
            DGVProducts.Columns[3].Width = 100;
            DGVProducts.Columns[4].Width = 50;
            DGVProducts.Columns[5].Width = 50;
            LlenarDGV();
        }

        private void LlenarDGV() 
        {
            DGVProducts.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegProd.listaProductos("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows) 
                {
                    DGVProducts.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                }
            }
            else 
            {
                lblMensaje.Text = "No hay productos cargados en el sistema";
            }
        }
    

        private void TxtBox_a_Obj() 
        {
            objEntProd.IdProd = int.Parse(txtId.Text);
            objEntProd.Nombre = txtNombre.Text;
            objEntProd.Marca = txtMarca.Text;
            objEntProd.Categoria = txtCategoria.Text;
            objEntProd.Precio = decimal.Parse(txtPrecio.Text);
            objEntProd.Cantstock = int.Parse(txtStock.Text);
        }

        private void Limpiar() 
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtCategoria.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            int nGrabados = -1;
            TxtBox_a_Obj();
            nGrabados = objNegProd.abmProductos("Alta", objEntProd);

            if (nGrabados == -1) 
            {
                lblMensaje.Text = "No se pudo grabar productos en el sistema";
            }
            else 
            {
                lblMensaje.Text = "El producto se grabo con exito";
                LlenarDGV();
                Limpiar();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int nElim = -1;
            TxtBox_a_Obj();
            nElim = objNegProd.abmProductos("Baja", objEntProd);
            if (nElim == -1) 
            {
                lblMensaje.Text = "No se pudo eliminar el producto";
            }
            else 
            {
                lblMensaje.Text = "El producto se elimino con exito";
                LlenarDGV();
            }
        }

        private void DGVProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataSet ds = new DataSet();
            objEntProd.IdProd = Convert.ToInt32(DGVProducts.CurrentRow.Cells[0].Value);
            ds = objNegProd.listaProductos(objEntProd.IdProd.ToString());
            if (ds.Tables[0].Rows.Count > 0) 
            {
                Ds_a_TxtBox(ds);
                //btnAnadir.Visible = false;
                lblMensaje.Text = string.Empty;
            }
        }
        private void Ds_a_TxtBox(DataSet ds) 
        {
            txtId.Text = ds.Tables[0].Rows[0]["IdProd"].ToString();
            txtNombre.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
            txtMarca.Text = ds.Tables[0].Rows[0]["Marca"].ToString();
            txtCategoria.Text = ds.Tables[0].Rows[0]["Categoria"].ToString();
            txtPrecio.Text = ds.Tables[0].Rows[0]["Precio"].ToString();
            txtStock.Text = ds.Tables[0].Rows[0]["Stock"].ToString();
            txtId.Enabled = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int nResult = -1;
            TxtBox_a_Obj();
            nResult = objNegProd.abmProductos("Modificar", objEntProd);
            if (nResult != -1)
            {
                lblMensaje.Text = "El producto se modifico con exito";
                Limpiar();
                LlenarDGV();
                txtId.Enabled = true;
            }
            else 
            {
                lblMensaje.Text = "No se pudo modificar el producto";
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DGVProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.DGVProducts.Columns[e.ColumnIndex].Name == "Add")
            {
                //Dato info = new Dato();
                //info.Nombre = txtNombre.Text;
                //info.Precio = Convert.ToInt32(txtPrecio.Text);
                //FormCarrito obj = new FormCarrito(info);
                MessageBox.Show("Se añadio el producto al carrito", "Add");
            }
        }

        private void btnAñadirAlCarrito_Click(object sender, EventArgs e)
        {
            Dato info = new Dato();
            if (string.IsNullOrWhiteSpace(txtNombre.Text) && string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("No selecciono ningun producto para agregar", "None");
                return;
            }
            info.Nombre = txtNombre.Text;
            info.Precio = Convert.ToInt32(txtPrecio.Text);
            FormCarrito formCarrito = new FormCarrito(info);
            Limpiar();
            formCarrito.Show();

        }

        public struct Dato 
        {
            public string Nombre;
            public int Precio;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        #region ATRIBUTOS
        public string dni;
        public string nombre;
        public string direccion;
        private string contrasena;
        //private int carrito;
        #endregion

        #region CONSTRUCTOR
        public Usuario()
        {
            dni = string.Empty;
            nombre = string.Empty;
            direccion = string.Empty;
            contrasena = string.Empty;
            //carrito = 0;
        }
        #endregion

        #region PROPIEDADES

        public string IdUsuario
        {
            get { return dni; }
            set { dni = value; }
        }
        public string Nombre 
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Direccion 
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Contrasena 
        {
            get { return contrasena; }
            set { contrasena = value; }
        }


        #endregion
    }
}

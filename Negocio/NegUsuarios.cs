using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegUsuarios
    {
        private DatosUsuarios objDatosUsuarios = new DatosUsuarios();

        public NegUsuarios() 
        {
            Usuario objUser = new Usuario();
        }
        
        public List<Usuario> CargarUsuario() 
        {
            return objDatosUsuarios.CargarUsuario();
        } 

        public int AddUsuario(string accion, Usuario objUser) 
        {
            return objDatosUsuarios.AddUsuario(accion, objUser);
        }
    }
}

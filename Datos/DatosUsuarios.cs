using Entidades;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosUsuarios : DatosConexion
    {
        private DatosConexion _conexion;

        public DatosUsuarios() 
        {
            _conexion = new DatosConexion();
        }

        public List<Usuario> CargarUsuario() 
        {
            try
            {
                _conexion.AbrirConexion();
                string Cons = "Select IdUsuario, Contrasena from Usuario";
                OleDbCommand comand = new OleDbCommand(Cons, _conexion.conexion);
                OleDbDataReader lector = comand.ExecuteReader();

                List<Usuario> listaUser = new List<Usuario>();

                while (lector.Read())
                {
                    Usuario user = new Usuario();

                    user.IdUsuario = lector["IdUsuario"].ToString();
                    user.Contrasena = lector["Contrasena"].ToString();

                    listaUser.Add(user);
                }

                return listaUser;
            }
            catch (Exception e)
            {
                throw new Exception("Error al cargar usuario", e);
            }
            finally 
            {
                _conexion.CerrarConexion();
            }
        }

        public int AddUsuario(string accion, Usuario objUser) 
        {
            int resultado = -1;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conexion;
            try
            {
                AbrirConexion();

                if (accion == "add")
                {
                    cmd.CommandText = "Insert into Usuario values (@IdUsuario, @Nombre, @Direccion, @Contrasena)";
                    cmd.Parameters.AddWithValue("@IdUsuario", objUser.IdUsuario);
                    cmd.Parameters.AddWithValue("@Nombre", objUser.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", objUser.Direccion);
                    cmd.Parameters.AddWithValue("@Contrasena", objUser.Contrasena);
                }
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo registrar", e);
            }
            finally 
            {
                CerrarConexion();
                cmd.Dispose();
            }
            return resultado;
        }
    }
}

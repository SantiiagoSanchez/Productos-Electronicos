using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data;

namespace Negocio
{
    public class NegProductos
    {
        DatosProductos objDatosProd = new DatosProductos();

        public int abmProductos (string accion, Producto objProducto) 
        {
            return objDatosProd.abmProductos(accion, objProducto);
        }
        public DataSet listaProductos(string cual) 
        {
            return objDatosProd.listaProductos(cual);
        }
    }
}

using Datos.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class VentaRequest
    {
        Guid idCliente;
        Guid idUsuario;
        Guid idproducto;
        int cantidad;

        public Guid IdCliente { get => idCliente; set => idCliente = value; }
        public Guid IdUsuario { get => idUsuario; set => idUsuario = value; }
        public Guid IdProducto { get => idproducto; set => idproducto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}

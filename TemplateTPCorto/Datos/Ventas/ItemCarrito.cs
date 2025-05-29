using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ventas
{
    public class ItemCarrito
    {
       public Producto Producto { get; set; }
       public int Cantidad { get; set; }
       public decimal Subtotal => Producto.Precio * Cantidad;

        public ItemCarrito(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }

    }
}

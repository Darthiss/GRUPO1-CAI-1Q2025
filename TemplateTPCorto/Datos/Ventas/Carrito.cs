using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ventas
{
   public class Carrito
   {
        
       public List<ItemCarrito> _itemsCarrito = new List<ItemCarrito>();
       public decimal _subtotal;
       public decimal _total;

        public List<ItemCarrito> itemsCarrito { get => _itemsCarrito; set => _itemsCarrito = value; }
        public decimal subtotal { get => _subtotal; set => _subtotal = value; }

        public decimal total { get => _total; set => _total = value; }

        public void AgregarProducto(Producto producto, int cantidad)
        {
            ItemCarrito item = new ItemCarrito(producto,cantidad);
            itemsCarrito.Add(item);
        }
        public void EliminarProducto (Producto producto, int cantidad)
        {
            ItemCarrito itemBuscado = itemsCarrito.Find(item => item.Producto.Id == producto.Id);
            itemBuscado.Cantidad -= cantidad;
            if(itemBuscado.Cantidad <= 0)
            {
                itemsCarrito.Remove(itemBuscado);
            }
        }

   }
   
}

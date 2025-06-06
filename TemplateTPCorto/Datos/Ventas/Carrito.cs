using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ventas
{
   public class Carrito
   {
        
       public BindingList<ItemCarrito> _itemsCarrito = new BindingList<ItemCarrito>();
       public decimal _subtotal;
       public decimal _total;

        public BindingList<ItemCarrito> itemsCarrito { get => _itemsCarrito; set => _itemsCarrito = value; }
        public decimal subtotal { get => _subtotal; set => _subtotal = value; }

        public decimal total { get => _total; set => _total = value; }

        public void AgregarProducto(Producto producto, int cantidad)
        {
            ItemCarrito itemBuscado = itemsCarrito.FirstOrDefault(item => item.Producto.Id == producto.Id);
            if(itemBuscado == null)
            {
                ItemCarrito itemNuevo = new ItemCarrito(producto,cantidad);
                itemsCarrito.Add(itemNuevo);
                return;
            }

            itemBuscado.Cantidad += cantidad;

            
        }
        public void EliminarProducto (Producto producto, int cantidad)
        {
            ItemCarrito itemBuscado = itemsCarrito.FirstOrDefault(item => item.Producto.Id == producto.Id);
            itemBuscado.Cantidad -= cantidad;
            if(itemBuscado.Cantidad <= 0)
            {
                itemsCarrito.Remove(itemBuscado);
            }
        }
        public void CalcularSubtotales()
        {
            decimal subtotal = 0;
            foreach (ItemCarrito item in itemsCarrito)
            {
                subtotal += item.Subtotal;
            }
            this.subtotal = subtotal;  
          
        }

    }
   
}

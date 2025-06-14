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

 
        public ItemCarrito BuscarItem (Producto producto)
        {
            return itemsCarrito.FirstOrDefault(item => item.Producto.Id == producto.Id);
        }

        private bool HayStockDisponible(Producto producto, int cantidadAAgregar)
        {
            ItemCarrito item = BuscarItem(producto);
            int cantidadEnCarrito = item?.Cantidad ?? 0;

            return (cantidadEnCarrito + cantidadAAgregar <= producto.Stock);
        }

        public bool AgregarProducto(Producto producto, int cantidad)
        {
            if (!HayStockDisponible(producto, cantidad))
                return false;

            ItemCarrito item = BuscarItem(producto);

            if (item == null)
                itemsCarrito.Add(new ItemCarrito(producto, cantidad));
            else
                item.Cantidad += cantidad;

            return true;
        }

        public void EliminarProducto (Producto producto, int cantidad)
        {
            ItemCarrito itemBuscado = itemsCarrito.FirstOrDefault(item => item.Producto.Id == producto.Id);
            itemBuscado.Cantidad -= cantidad;

            if (itemBuscado.Cantidad <= 0)
            {
                RemoverProducto(producto);
            }
        }

        public void RemoverProducto(Producto producto)
        {
            ItemCarrito itemBuscado = itemsCarrito.FirstOrDefault(item => item.Producto.Id == producto.Id);
            if (itemBuscado != null)
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
        public void CalcularTotal()
        {
            decimal total = 0;
            foreach(ItemCarrito item in itemsCarrito)
            {
                total += item.Subtotal;
            }  
            this.total = total;
            AplicarDescuento();
        }
        public void AplicarDescuento()
        {
            if(this.total > 1000000)
            {
                decimal montoDescuento = this.subtotal * 0.15m;
                this.total -= montoDescuento;
            }
        }
    }
   
}

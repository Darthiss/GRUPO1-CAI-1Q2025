﻿using Datos.Ventas;
using Newtonsoft.Json;
using Persistencia.WebService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class VentaPersistencia
    {
        private Guid idUsuario = new Guid("784c07f2-2b26-4973-9235-4064e94832b5");

       
        public bool CargarVenta(Guid idcliente, Carrito carrito)
        {
                       
            foreach (ItemCarrito item in carrito.itemsCarrito)
            {
              
                VentaRequest venta = new VentaRequest
                {
                    IdCliente = idcliente,
                    IdProducto = item.Producto.Id,
                    Cantidad = item.Cantidad,
                    IdUsuario = idUsuario
                };
                var jsonRequest = JsonConvert.SerializeObject(venta);

                HttpResponseMessage response = WebHelper.Post("/api/Venta/AgregarVenta", jsonRequest);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                
            }

            return true;
        }
        
      
    }
    
}

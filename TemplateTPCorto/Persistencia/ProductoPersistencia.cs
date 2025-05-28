using Datos.Ventas;
using Newtonsoft.Json;
using Persistencia.WebService.Utils;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Persistencia
{
    public class ProductoPersistencia
    {
        public List<Producto> obtenerProductosPorCategoria(string categoria)
        {
            List<Producto> listaProductos = new List<Producto>();

            HttpResponseMessage response = WebHelper.Get("/api/Producto/TraerProductosPorCategoria?catnum=" + categoria);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var contentStream = response.Content.ReadAsStringAsync().Result;
                listaProductos = JsonConvert.DeserializeObject<List<Producto>>(contentStream);
            }

            return listaProductos;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Operacion
    {
        public Operacion(string idOperacion, string tipoOperacion, string estado, string legajoSolicitante, DateTime fechaSolicitud, string legajoAutorizador, DateTime? fechaAutorizacion)
        {
            IdOperacion = idOperacion;
            TipoOperacion = tipoOperacion;
            Estado = estado;
            LegajoSolicitante = legajoSolicitante;
            FechaSolicitud = fechaSolicitud;
            LegajoAutorizador = legajoAutorizador;
            FechaAutorizacion = fechaAutorizacion;
        }

        public Operacion(string linea)
        {
            var datos = linea.Split(';');
            IdOperacion = datos[0];
            TipoOperacion = datos[1];
            Estado = datos[2];
            LegajoSolicitante = datos[3];
            FechaSolicitud = DateTime.ParseExact(datos[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            // Manejo nulos para legajo autorizador y fecha
            LegajoAutorizador = string.IsNullOrEmpty(datos[5]) ? null : datos[5];

            if (string.IsNullOrEmpty(datos[6]))
                FechaAutorizacion = null;
            else
                FechaAutorizacion = DateTime.ParseExact(datos[6], "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public string IdOperacion { get; set; }
        public string TipoOperacion { get; set; } // "ModificarPersona", "CambioCredencial"
        public string Estado { get; set; } // "Pendiente", "Autorizada", "Rechazada"
        public string LegajoSolicitante { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string LegajoAutorizador { get; set; } // puede ser null
        public DateTime? FechaAutorizacion { get; set; } // puede ser null
        public override string ToString()
        {
            string fechaAutorizacionStr = FechaAutorizacion.HasValue ? FechaAutorizacion.Value.ToString("dd/MM/yyyy") : "";
            string legajoAutorizadorStr = LegajoAutorizador ?? "";

            return $"\n{IdOperacion};{TipoOperacion};{Estado};{LegajoSolicitante};{FechaSolicitud:dd/MM/yyyy};{legajoAutorizadorStr};{fechaAutorizacionStr}";
        }
    }

}

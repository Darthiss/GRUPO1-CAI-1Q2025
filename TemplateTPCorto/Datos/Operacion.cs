using System;
using System.Collections.Generic;
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

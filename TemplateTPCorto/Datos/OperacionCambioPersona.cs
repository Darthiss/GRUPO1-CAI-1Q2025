using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class OperacionCambioPersona
    {
        public string IdOperacion { get; set; }
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime FechaIngreso { get; set; }

        public override string ToString()
        {
            return $"{IdOperacion};{Legajo};{Nombre};{Apellido};{Dni};{FechaIngreso:dd/MM/yyyy}";
        }
    }
}

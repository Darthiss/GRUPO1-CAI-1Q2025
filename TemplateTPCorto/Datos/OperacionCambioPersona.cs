using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class OperacionCambioPersona
    {
        public OperacionCambioPersona(string idOperacion, string legajo, string nombre, string apellido, string dni, DateTime fechaIngreso)
        {
            IdOperacion = idOperacion;
            Legajo = legajo;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            FechaIngreso = fechaIngreso;
        }

        public string IdOperacion { get; set; }
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime FechaIngreso { get; set; }

        public override string ToString()
        {
            return $"\n{IdOperacion};{Legajo};{Nombre};{Apellido};{Dni};{FechaIngreso:dd/MM/yyyy}";
        }
    }
}

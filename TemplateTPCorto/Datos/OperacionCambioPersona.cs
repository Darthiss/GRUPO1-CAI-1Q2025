using System;
using System.Collections.Generic;
using System.Globalization;
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

        public OperacionCambioPersona(string registro)
        {
            var datos = registro.Split(';');
            IdOperacion = datos[0];
            Legajo = datos[1];
            Nombre = datos[2];
            Apellido = datos[3];
            Dni = datos[4];
            FechaIngreso = DateTime.ParseExact(datos[5], "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

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

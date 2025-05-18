using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class OperacionCambioCredencial
    {
        public string IdOperacion { get; set; }
        public string Legajo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string IdPerfil { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaUltimoLogin { get; set; }

        public override string ToString()
        {
            return $"{IdOperacion};{Legajo};{NombreUsuario};{Contrasena};{IdPerfil};{FechaAlta:dd/MM/yyyy};{FechaUltimoLogin:dd/MM/yyyy}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class OperacionCambioCredencial
    {
        public OperacionCambioCredencial(string idOperacion, string legajo, string nombreUsuario, string contrasena, string idPerfil, DateTime fechaAlta, DateTime fechaUltimoLogin)
        {
            IdOperacion = idOperacion;
            Legajo = legajo;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            IdPerfil = idPerfil;
            FechaAlta = fechaAlta;
            FechaUltimoLogin = fechaUltimoLogin;
        }

        public string IdOperacion { get; set; }
        public string Legajo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string IdPerfil { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaUltimoLogin { get; set; }

        public override string ToString()
        {
            string fechaUltimoLoginStr = FechaUltimoLogin.HasValue ? FechaUltimoLogin.Value.ToString("dd/MM/yyyy") : "";
            return $"\n{IdOperacion};{Legajo};{NombreUsuario};{Contrasena};{IdPerfil};{FechaAlta:dd/MM/yyyy};{fechaUltimoLoginStr}";
        }
    }
}

using Datos;
using Datos.Login;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestionUsuariosNegocio
    {
        private readonly UsuarioPersistencia usuarioPersistencia;
        public GestionUsuariosNegocio()
        {
            this.usuarioPersistencia = new UsuarioPersistencia();
        }
        public Credencial BuscarCredencial(string legajo)
        { 
           return usuarioPersistencia.BuscarCredencial(legajo);            
        }
        public Persona BuscarPersona(string legajo)
        {
            return usuarioPersistencia.BuscarPersona(legajo);
        }

        public void SolicitarModificarPersona(string legajo, string nombre, string apellido,string  dni,DateTime fechaIngreso, string legajoSolicitante)
        {
            string idOperacion = "" + legajoSolicitante + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string tipoOperacion = "ModificarPersona";
            string estado = "Pendiente";
            DateTime fechaSolicitud = DateTime.Now;

            Operacion operacion= new Operacion(idOperacion, tipoOperacion, estado, legajoSolicitante, fechaSolicitud, null, null);
            OperacionCambioPersona operacionCambioPersona = new OperacionCambioPersona(idOperacion, legajo, nombre, apellido, dni, fechaIngreso);

            usuarioPersistencia.SolicitarModificarPersona(operacion, operacionCambioPersona);


        }
    }
}

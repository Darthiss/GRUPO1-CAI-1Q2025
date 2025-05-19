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

        public void SolicitarModificarCredencial(string legajo, string nombreUsuario, string contrasena, string idPerfil, DateTime fechaAlta, DateTime fechaUltimoLogin , string legajoSolicitante)
        {
            string idOperacion = "" + legajoSolicitante + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string tipoOperacion = "ModificarCredencial";
            string estado = "Pendiente";
            DateTime fechaSolicitud = DateTime.Now;

            Operacion operacion = new Operacion(idOperacion, tipoOperacion, estado, legajoSolicitante, fechaSolicitud, null, null);
            OperacionCambioCredencial operacionCambioCredencial = new OperacionCambioCredencial(idOperacion, legajo, nombreUsuario, contrasena, idPerfil, fechaAlta, fechaUltimoLogin);

            usuarioPersistencia.SolicitarModificarCredencial(operacion, operacionCambioCredencial);
        }

        public string BuscarPerfil(string legajo)
        {
            return usuarioPersistencia.BuscarPerfil(legajo);
        }


        public List<Operacion> ObtenerOperacionesPendientes()
        {
            return usuarioPersistencia.ObtenerOperacionesPendientes();
        }

        public OperacionCambioCredencial ObtenerOperacionCambioCredencial(string idOperacion)
        {
            return usuarioPersistencia.ObtenerOperacionCambioCredencial(idOperacion);
        }

        public OperacionCambioPersona ObtenerOperacionCambioPersona(string idOperacion)
        {
            return usuarioPersistencia.ObtenerOperacionCambioPersona(idOperacion);
        }

        public void AutorizarOperacion(string idOperacion, string tipoOperacion, string legajoAutorizador)
        {
            usuarioPersistencia.ActualizarEstadoOperacion(idOperacion, "Autorizada", legajoAutorizador);

            if (tipoOperacion == "ModificarPersona")
            {
                usuarioPersistencia.AplicarOperacionCambioPersona(idOperacion);
            }
            else if (tipoOperacion == "ModificarCredencial")
            {
                usuarioPersistencia.AplicarOperacionCambioCredencial(idOperacion);
              
            }
        }

        public void RechazarOperacion(string idOperacion, string legajoAutorizador)
        {
            usuarioPersistencia.ActualizarEstadoOperacion(idOperacion, "Rechazada", legajoAutorizador);
        }

    }
}

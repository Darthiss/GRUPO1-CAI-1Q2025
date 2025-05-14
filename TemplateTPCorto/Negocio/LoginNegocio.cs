using Datos;
using Persistencia;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{

    //Capa encargada de aplicar la lógica de negocio. Se comunica con la capa de Presentación y Persistencia
    public class LoginNegocio
    {
        private readonly UsuarioPersistencia usuarioPersistencia;
        public LoginNegocio()
        {
            this.usuarioPersistencia = new UsuarioPersistencia();
        }
        public ResultadoLogin login(String usuario, String password)
        {
            ResultadoLogin resultado = new ResultadoLogin();

            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();

            Credencial credencial = usuarioPersistencia.login(usuario);
            resultado.Credencial = credencial;
            if (credencial == null)
            {
                resultado.Estado = EstadoLogin.errorcredenciales;
                return resultado;
            }
            string legajo = credencial.Legajo;
         

            if (LegajoEstaBloqueado(legajo))
            {
                resultado.Estado = EstadoLogin.usuariobloqueado;
                // Si el usuario está bloqueado, no se puede loguear, da error
                return resultado;
            }

            if (credencial.Contrasena.Equals(password))
            {
                usuarioPersistencia.BorrarIntentosFallidos(legajo);
                if (ValidarContraseniaExpirada(credencial.FechaUltimoLogin))
                {
                    resultado.Estado = EstadoLogin.contraseñavencida;
                    return resultado;
                }
                if (ValidarPrimerIngreso(credencial.FechaUltimoLogin))
                {
                    resultado.Estado = EstadoLogin.primerlogin;
                    return resultado;
                }
                resultado.Estado = EstadoLogin.exitoso;
                return resultado;
            }
            resultado.Estado = EstadoLogin.errorcredenciales;
           

            usuarioPersistencia.anotarIntentoFallido(legajo);

            usuarioPersistencia.ValidarBloqueoUsuario(legajo);
            return resultado;
        }
       
        public bool ValidarContraseniaExpirada(DateTime FechaUltimoLogin)
        {
            return (FechaUltimoLogin.AddDays(30) > DateTime.Now);
            
        }
        public bool LegajoEstaBloqueado(string legajo)
        {
            List<string> usuarios = usuarioPersistencia.obtenerLegajosBloqueados();

            return usuarios.Contains(legajo);
        }
        public bool ValidarPrimerIngreso(DateTime FechaUltimoLogin)
        {
            return (FechaUltimoLogin == null);
        }
            
       
    }
}

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

            Credencial credencial = usuarioPersistencia.login(usuario);
            resultado.Credencial = credencial;
            if (credencial == null)
            {
                resultado.Estado = EstadoLogin.errorcredenciales;
                resultado.Mensaje = "Error en las credenciales.";
                return resultado;
            }
            string legajo = credencial.Legajo;
         

            if (LegajoEstaBloqueado(legajo))
            {
                resultado.Estado = EstadoLogin.usuariobloqueado;
                resultado.Mensaje = "El usuario se encuentra bloqueado. Contacte a su Supervisor";
                return resultado;
            }

            if (credencial.Contrasena.Equals(password))
            {
                usuarioPersistencia.BorrarIntentosFallidos(legajo);

                if (ValidarPrimerIngreso(credencial.FechaUltimoLogin))
                {
                    resultado.Estado = EstadoLogin.primerlogin;
                    resultado.Mensaje = "Debe cambiar su contraseña";
                    return resultado;
                }

                if (ValidarContraseniaExpirada(credencial.FechaUltimoLogin))
                {
                    resultado.Estado = EstadoLogin.contraseñavencida;
                    resultado.Mensaje = "La contraseña ha vencido, debe cambiarla.";
                    return resultado;
                }
                
                resultado.Estado = EstadoLogin.exitoso;
                resultado.Mensaje = "Bienvenido";
                usuarioPersistencia.GuardarFechaLogin(usuario);
                return resultado;
            }
            resultado.Estado = EstadoLogin.errorcredenciales;
            resultado.Mensaje = "Error en las credenciales.";
           

            usuarioPersistencia.anotarIntentoFallido(legajo);

            usuarioPersistencia.ValidarBloqueoUsuario(legajo);
            return resultado;
        }
       
        //Devuelve True si la contraseña esta expirada
        public bool ValidarContraseniaExpirada(DateTime? FechaUltimoLogin)
        {
            if (FechaUltimoLogin == null)
            {
                return true; // Si no hay fecha de último login, consideramos que la contraseña está expirada
            }

            DateTime fecha = FechaUltimoLogin.Value;
            return fecha.AddDays(30) < DateTime.Now;
            
        }
        public bool LegajoEstaBloqueado(string legajo)
        {
            List<string> usuarios = usuarioPersistencia.obtenerLegajosBloqueados();

            return usuarios.Contains(legajo);
        }
        public bool ValidarPrimerIngreso(DateTime? FechaUltimoLogin)
        {
            return (FechaUltimoLogin == null);
        }

        public string BuscarPerfil(string legajo)
        { 
            return usuarioPersistencia.BuscarPerfil(legajo);            
        }
       
    }
}

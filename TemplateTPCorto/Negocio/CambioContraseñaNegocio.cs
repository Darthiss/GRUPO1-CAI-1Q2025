using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CambioContraseñaNegocio
    {
        private readonly UsuarioPersistencia usuarioPersistencia;

        public CambioContraseñaNegocio()
        {
            this.usuarioPersistencia = new UsuarioPersistencia();
        }

        
        public ResultadoCambioContraseña CambiarContraseña(string usuario, string contraseñaActual, string contraseñaNueva)
        {
            LoginNegocio loginNegocio = new LoginNegocio();
            ResultadoLogin resultadoLogin = loginNegocio.login(usuario, contraseñaActual);

            ResultadoCambioContraseña resultado = new ResultadoCambioContraseña();

            switch (resultadoLogin.Estado)
            {
                case EstadoLogin.exitoso:
                case EstadoLogin.contraseñavencida:
                case EstadoLogin.primerlogin:
                    if (resultadoLogin.Credencial.Contrasena == contraseñaNueva)
                    {
                        resultado.Estado = EstadoCambioContraseña.ContraseñaIgualALaAnterior;
                        resultado.Mensaje = "La nueva contraseña no debe ser igual a la anterior.";
                        return resultado;
                    }

                    usuarioPersistencia.CambiarContraseña(usuario, contraseñaNueva);
                    resultado.Estado = EstadoCambioContraseña.Exito;
                    resultado.Mensaje = "Contraseña cambiada correctamente.";
                    usuarioPersistencia.GuardarFechaLogin(usuario);
                    return resultado;

                case EstadoLogin.errorcredenciales:
                    resultado.Estado = EstadoCambioContraseña.CredencialesInvalidas;
                    resultado.Mensaje = "Error en las credenciales.";
                    return resultado;

                case EstadoLogin.usuariobloqueado:
                    resultado.Estado = EstadoCambioContraseña.UsuarioBloqueado;
                    resultado.Mensaje = "El usuario se encuentra bloqueado.";
                    return resultado;

                default:
                    resultado.Estado = EstadoCambioContraseña.ErrorInterno;
                    resultado.Mensaje = "Error inesperado.";
                    return resultado;

            }
        


        }
    }
}

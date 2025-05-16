using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class CambioContraseñaNegocio
    {
        private readonly UsuarioPersistencia usuarioPersistencia;

        public CambioContraseñaNegocio()
        {
            this.usuarioPersistencia = new UsuarioPersistencia();
        }

        
        public void CambiarContraseña(string usuario, string contraseñaActual, string contraseñaNueva)
        {
            LoginNegocio loginNegocio = new LoginNegocio();
            ResultadoLogin resultadoLogin = loginNegocio.login(usuario, contraseñaActual);
            switch (resultadoLogin.Estado)
            {
                case EstadoLogin.exitoso:
                    UsuarioPersistencia.CambiarContraseña(usuario, contraseñaNueva);
                    MessageBox.Show("Contraseña cambiada correctamente");
                    break;
                case EstadoLogin.contraseñavencida:
                    MessageBox.Show("Contraseña cambiada correctamente");
                    break;
                case EstadoLogin.errorcredenciales:
                    MessageBox.Show("Error en las credenciales");
                    break;
                case EstadoLogin.usuariobloqueado:
                    MessageBox.Show("El usuario se ha bloqueado");
                    break;

            }


        }
    }
}

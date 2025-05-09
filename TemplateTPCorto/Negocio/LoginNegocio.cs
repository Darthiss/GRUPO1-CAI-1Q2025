using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{

    //Capa encargada de aplicar la lógica de negocio. Se comunica con la capa de Presentación y Persistencia
    public class LoginNegocio
    {
        public Credencial login(String usuario, String password)
        {
            // PREGUNTAR: Esto tiene que ir aca, o en formlogin?
            //Validar que los campos no esten vacios
            if (String.IsNullOrEmpty(usuario) || String.IsNullOrEmpty(password))
            {
                return null;
            }

            //Validar si tienen el formato correcto
            if (password.Length < 8) { return null; }
            if (! usuario.Contains(".") ) { return null; }


            //Hasta aca, lo ingresado parece valido. Vamos a buscar el usuario en la base de datos

            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();


            Credencial credencial = usuarioPersistencia.login(usuario);

            //Si credencial es null, no existe el usuario. Si existe, en este paso tenemos una credencial valida :)

            //Validar que no este bloqueado el usuario. Preguntar si esto va aca?

            string legajo_usuario = credencial.Legajo;
            //tengo que ir al archivo de usuarios bloqueados, y ver si ese legajo está ahi?

            if (usuarioPersistencia.usuarioEstaBloqueado(legajo_usuario))
            {
                // Si el usuario está bloqueado, no se puede loguear, da error
                return null;
            }

            if (credencial.Contrasena.Equals(password))
            {
                return credencial;
                // ver tema contraseñas vencidas
            }

            //Si estamos aca parados, es porque la contraseña esta mal:

            usuarioPersistencia.anotarIntentoFallido(legajo_usuario);

            return null;
        }
    }
}

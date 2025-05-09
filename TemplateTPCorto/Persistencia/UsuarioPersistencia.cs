using Datos;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{

    //Capa encargada de acceder a las distintas formas de persistencia que tenga el proyecto. Se comunica con la capa de Negocio

    public class UsuarioPersistencia
    {
        public Credencial login(String username)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> registros = dataBaseUtils.BuscarRegistro("credenciales.csv");

            foreach (String linea in registros)
            {
                String[] datos = linea.Split(';');
                if (datos[1].Equals(username))
                {

                    Credencial credencial = new Credencial(linea);
                    return credencial;

                }
                
            }

            return null;

        }


        //Este metodo valida si el usuario esta bloqueado. Devuelve true si el usuario esta bloqueado
        public bool usuarioEstaBloqueado(String legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            List<String> usuarios = dataBaseUtils.BuscarRegistro("usuario_bloqueado.csv");

            foreach(String usuario in usuarios)
            {
                if(usuario.Equals(legajo))
                {
                    return true;
                }
            }

            return false;
        }


        //Este metodo anota un intento fallido de login.
        public void anotarIntentoFallido(String legajo)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            String linea = "";
            String archivo = "login_intentos.csv";

            String fecha = DateTime.Now.ToString("d/M/yyyy");

            linea = "\n"+legajo + ";" + fecha;

            Console.WriteLine("Intento fallido de login: " + linea);
            dataBaseUtils.AgregarRegistro(archivo, linea);

        }
    }
}

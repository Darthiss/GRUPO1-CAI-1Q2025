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

        private readonly DataBaseUtils dataBaseUtils;

        public UsuarioPersistencia()
        {
            this.dataBaseUtils = new DataBaseUtils();
        }


        public Credencial login(String username)
        {
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

        //Este metodo devuelve la lista de legajos bloqueados.
        public List <string> obtenerLegajosBloqueados()
        {
            List<String> usuarios = dataBaseUtils.BuscarRegistro("usuario_bloqueado.csv");

            return usuarios;
        }

    //Este metodo anota un intento fallido de login.
        public void anotarIntentoFallido(String legajo)
        {
            String linea = "";
            String archivo = "login_intentos.csv";

            String fecha = DateTime.Now.ToString("d/M/yyyy");

            linea = "\n"+legajo + ";" + fecha;

            Console.WriteLine("Intento fallido de login: " + linea);
            dataBaseUtils.AgregarRegistro(archivo, linea);

        }
        public void BorrarIntentosFallidos(string legajo)
        {
            dataBaseUtils.BorrarRegistro(legajo, "login_intentos.csv");
        }

        public int ContarIntentosFallidos(string legajo)

        {
            int contador = 0;
            List<String> intentos = dataBaseUtils.BuscarRegistro("login_intentos.csv");
            for (int i = 0; i < intentos.Count; i++)
            {
                string[] datos = intentos[i].Split(';');
                if (legajo.Equals(datos[0]))
                {
                    contador++;
                }
            }
            return contador;
        }
        public void ValidarBloqueoUsuario(string legajo)
        {
            if (ContarIntentosFallidos(legajo) >= 3)
            {
                BloquearUsuario(legajo);

            }
        }
        public void BloquearUsuario(string legajo)
        {
            dataBaseUtils.AgregarRegistro("usuario_bloqueado.csv", legajo + "\n");
        }
       
    }
}

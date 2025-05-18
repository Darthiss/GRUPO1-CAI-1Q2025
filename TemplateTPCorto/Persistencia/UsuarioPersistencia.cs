using Datos;
using Datos.Login;
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
        public Credencial BuscarCredencial(String legajo)
        {
            List<String> registros = dataBaseUtils.BuscarRegistro("credenciales.csv");

            foreach (String linea in registros)
            {
                String[] datos = linea.Split(';');
                if (datos[0].Equals(legajo))
                {

                    Credencial credencial = new Credencial(linea);
                    return credencial;

                }

            }
            return null;

        }
        public Persona BuscarPersona(String legajo)
        {
            List<String> registros = dataBaseUtils.BuscarRegistro("persona.csv");

            foreach (String linea in registros)
            {
                String[] datos = linea.Split(';');
                if (datos[0].Equals(legajo))
                {

                    Persona persona = new Persona(linea);
                    return persona;

                }

            }
            return null;

        }

        //Devuelve la lista de legajos bloqueados.
        public List <string> obtenerLegajosBloqueados()
        {
            List<String> usuarios = dataBaseUtils.BuscarRegistro("usuario_bloqueado.csv");

            return usuarios;
        }

        //Anota un intento fallido de login.
        public void anotarIntentoFallido(String legajo)
        {
            String linea = "";
            String archivo = "login_intentos.csv";

            String fecha = DateTime.Now.ToString("d/M/yyyy");

            linea = "\n"+legajo + ";" + fecha;

            Console.WriteLine("Intento fallido de login: " + linea);
            dataBaseUtils.AgregarRegistro(archivo, linea);

        }

        //Borra todos los intentos fallidos de login de un legajo.
        public void BorrarIntentosFallidos(string legajo)
        {
            dataBaseUtils.BorrarRegistro(legajo, "login_intentos.csv");
        }

        //Cuenta la cantidad de intentos fallidos de login de un legajo.
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

        //Valida si el usuario tiene 3 intentos fallidos de login y lo bloquea.
        public void ValidarBloqueoUsuario(string legajo)
        {
            if (ContarIntentosFallidos(legajo) >= 3)
            {
                BloquearUsuario(legajo);

            }
        }

        //Bloquea un usuario.
        public void BloquearUsuario(string legajo)
        {
            dataBaseUtils.AgregarRegistro("usuario_bloqueado.csv", legajo + "\n");
        }

        //Cambia la contraseña de un usuario.
        public void CambiarContraseña(string usuario, string contraseñaNueva)
        {
            Credencial credencial = login(usuario);
            string legajo = credencial.Legajo;
            credencial.Contrasena = contraseñaNueva;

            dataBaseUtils.BorrarRegistro(legajo, "credenciales.csv");

            dataBaseUtils.AgregarRegistro("credenciales.csv", credencial.ToString());

            BorrarIntentosFallidos(legajo);

        }

        public void GuardarFechaLogin(string usuario)
        {

            Credencial credencial = login(usuario);
            string legajo = credencial.Legajo;
            credencial.FechaUltimoLogin = DateTime.Now;

            dataBaseUtils.BorrarRegistro(legajo, "credenciales.csv");

            dataBaseUtils.AgregarRegistro("credenciales.csv", credencial.ToString());

            BorrarIntentosFallidos(legajo);

        }

        public string BuscarPerfil(string legajo)
        {
            List<string> perfiles = dataBaseUtils.BuscarRegistro("usuario_perfil.csv");
            foreach (string perfil in perfiles)
            { 
                string[] datos = perfil.Split(';');
                if (datos[0]==legajo)
                {
                    return datos[1];  
                }
            }
            return null;
        }
    }
}

using Datos;
using Datos.Login;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Globalization;
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

    
        public List <string> obtenerLegajosBloqueados()
        {
            List<String> usuarios = dataBaseUtils.BuscarRegistro("usuario_bloqueado.csv");

            return usuarios;
        }

        public void anotarIntentoFallido(String legajo)
        {
            String linea = "";
            String archivo = "login_intentos.csv";

            String fecha = DateTime.Now.ToString("d/M/yyyy");

            linea = legajo + ";" + fecha;

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
            dataBaseUtils.AgregarRegistro("usuario_bloqueado.csv", legajo);
        }

        public void DesbloquearUsuario(string legajo)
        {
            dataBaseUtils.BorrarRegistro(legajo, "usuario_bloqueado.csv");
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


        public void SolicitarModificarPersona(Operacion operacion,OperacionCambioPersona operacionCambioPersona)
        {
            dataBaseUtils.AgregarRegistro("autorizacion.csv", operacion.ToString());
            dataBaseUtils.AgregarRegistro("operacion_cambio_persona.csv", operacionCambioPersona.ToString());
        }

        public void SolicitarModificarCredencial(Operacion operacion, OperacionCambioCredencial operacionCambioCredencial)
        {
            dataBaseUtils.AgregarRegistro("autorizacion.csv", operacion.ToString());
            dataBaseUtils.AgregarRegistro("operacion_cambio_credencial.csv", operacionCambioCredencial.ToString());
        }

        public List<Operacion> ObtenerOperacionesPendientes()
        {
            List<Operacion> lista = new List<Operacion>();
            List<string> registros = dataBaseUtils.BuscarRegistro("autorizacion.csv");

            foreach (string linea in registros)
            {
                string[] datos = linea.Split(';');
                {
                        
                    if (datos[0] == "idOperacion")
                        continue;

                    string id = datos[0];
                    string tipo = datos[1];
                    string estado = datos[2];
                    string legajo = datos[3];

                    DateTime fecha = DateTime.ParseExact(datos[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    string autorizador = string.IsNullOrWhiteSpace(datos[5]) ? null : datos[5];

                    DateTime? fechaAut = string.IsNullOrWhiteSpace(datos[6]) ? (DateTime?)null : DateTime.ParseExact(datos[6], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    lista.Add(new Operacion(id, tipo, estado, legajo, fecha, autorizador, fechaAut));

                }
            }

            return lista.Where(o => o.Estado == "Pendiente").ToList();
        }

        public OperacionCambioPersona ObtenerOperacionCambioPersona(string idOperacion)
        {
            List<string> registros = dataBaseUtils.BuscarRegistro("operacion_cambio_persona.csv");

            foreach (string linea in registros)
            {
                string[] datos = linea.Split(';');
                if (datos[0] == idOperacion)
                {
                    return new OperacionCambioPersona(linea);
                }
            }
            return null;
        }   

        public OperacionCambioCredencial ObtenerOperacionCambioCredencial(string idOperacion)
        {
            List<string> registros = dataBaseUtils.BuscarRegistro("operacion_cambio_credencial.csv");

            foreach (string linea in registros)
            {
                string[] datos = linea.Split(';');
                if (datos[0] == idOperacion)
                {
                    return new OperacionCambioCredencial(linea);
                }
            }
            return null;

        }

        public Operacion ObtenerOperacion(string idOperacion)
        {
            List<string> registros = dataBaseUtils.BuscarRegistro("autorizacion.csv");

            foreach (string linea in registros)
            {
                string[] datos = linea.Split(';');
                if (datos[0] == idOperacion)
                {
                    return new Operacion(linea);
                }
            }
            return null;
        }

        public void ActualizarEstadoOperacion(string idOperacion, string estado, string legajoAutorizador)
        {

            Operacion operacion = ObtenerOperacion(idOperacion);

            operacion.Estado = estado;
            operacion.LegajoAutorizador = legajoAutorizador;
            operacion.FechaAutorizacion = DateTime.Now;

            dataBaseUtils.BorrarRegistro(idOperacion, "autorizacion.csv");
            dataBaseUtils.AgregarRegistro("autorizacion.csv", operacion.ToString());

        }

        public void AplicarOperacionCambioPersona(string idOperacion) {
        
            OperacionCambioPersona operacion = ObtenerOperacionCambioPersona(idOperacion);
            Persona persona = BuscarPersona(operacion.Legajo);

            if (persona != null)
            {
                persona.Nombre = operacion.Nombre;
                persona.Apellido = operacion.Apellido;
                persona.DNI = operacion.Dni;
                persona.FechaIngreso = operacion.FechaIngreso;

                dataBaseUtils.BorrarRegistro(operacion.Legajo, "persona.csv");
                dataBaseUtils.AgregarRegistro("persona.csv", persona.ToString());
            }
        
        }

        public void AplicarOperacionCambioCredencial(string idOperacion) {
        
            OperacionCambioCredencial operacion = ObtenerOperacionCambioCredencial(idOperacion);
            Credencial credencial = BuscarCredencial(operacion.Legajo);

            if (credencial != null)
            
                credencial.NombreUsuario = operacion.NombreUsuario;
                credencial.Contrasena = operacion.Contrasena;
                credencial.FechaAlta = operacion.FechaAlta;
                credencial.FechaUltimoLogin = null;

                dataBaseUtils.BorrarRegistro(operacion.Legajo, "credenciales.csv");
                dataBaseUtils.AgregarRegistro("credenciales.csv", credencial.ToString());

                DesbloquearUsuario(operacion.Legajo);

            }
        
        
        }

}

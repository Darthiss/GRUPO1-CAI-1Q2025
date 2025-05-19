using Negocio;
using Datos;
using Datos.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;
using System.Net;

namespace TemplateTPCorto
{
    public partial class FormSupervisor : Form
    {

        private string legajoSupervisor;

        public FormSupervisor(string legajoSupervisor)
        {
            InitializeComponent();
            this.legajoSupervisor = legajoSupervisor;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajo.Text;
            if (string.IsNullOrEmpty(legajo))
            {
                MessageBox.Show("Debe ingresar un legajo.");
                return;
            }
            GestionUsuariosNegocio gestionUsuariosNegocio = new GestionUsuariosNegocio();
            Credencial credencial = gestionUsuariosNegocio.BuscarCredencial(legajo);
            if (credencial == null)
            {
                MessageBox.Show("No se encontró el legajo.");
                return;
            }
            Persona persona = gestionUsuariosNegocio.BuscarPersona(legajo);

            txtNUsuario.Text = credencial.NombreUsuario;
            txtContraseña.Text = credencial.Contrasena;
            txtIDperfil.Text = gestionUsuariosNegocio.BuscarPerfil(legajo);
            txtFAlta.Text = credencial.FechaAlta.ToString("dd/MM/yyyy");
            txtFUltimoLogin.Text = credencial.FechaUltimoLogin.ToString("dd/MM/yyyy");

            txtNombre.Text = persona.Nombre;
            txtApellido.Text = persona.Apellido;
            txtDNI.Text = persona.DNI;
            txtFIngreso.Text = persona.FechaIngreso.ToString("dd/MM/yyyy");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnModificarPersona_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajo.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string dni = txtDNI.Text;
            string fechaIngreso = txtFIngreso.Text;

            if(string.IsNullOrEmpty(legajo) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(fechaIngreso))
            {
                MessageBox.Show("Debe completar todos los campos de la persona.");
                return;
            }
            DateTime SalidaFechaIngreso;
            if (!ValidarFechaIngreso(fechaIngreso, out SalidaFechaIngreso))
            {
                // Ya se mostró el mensaje de error en el método, simplemente cortamos
                return;
            }
            
            GestionUsuariosNegocio gestionUsuariosNegocio = new GestionUsuariosNegocio();
            gestionUsuariosNegocio.SolicitarModificarPersona(legajo, nombre, apellido, dni, SalidaFechaIngreso, legajoSupervisor);

            MessageBox.Show("Solicitud de modificación de Persona enviada.");
        }
        private bool ValidarFechaIngreso(string fechaTexto, out DateTime fechaIngreso)
        {
            fechaIngreso = DateTime.MinValue;
            bool fechaValida = DateTime.TryParseExact(
                fechaTexto,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out fechaIngreso
            );

            if (!fechaValida)
            {
                MessageBox.Show("La fecha ingresada no es válida. Usá el formato dd/MM/yyyy.");
                return false;
            }

            if (fechaIngreso > DateTime.Today)
            {
                MessageBox.Show("La fecha de ingreso no puede estar en el futuro.");
                return false;
            }

            if (fechaIngreso < new DateTime(1900, 1, 1))
            {
                MessageBox.Show("La fecha es demasiado antigua.");
                return false;
            }
            return true;
        }

        private void btnDesbloquearCredencial_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajo.Text;
            string nombreUsuario = txtNUsuario.Text;
            string contraseña = txtContraseña.Text;
            string idPerfil = txtIDperfil.Text;
            string fechaDeAlta = txtFAlta.Text;
            string fechaUiltimoLogin = txtFUltimoLogin.Text;


            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(idPerfil) || string.IsNullOrEmpty(fechaDeAlta) || string.IsNullOrEmpty(fechaUiltimoLogin))
            {
                MessageBox.Show("Debe completar todos los campos de la persona.");
                return;
            }
            
            DateTime SalidaFechaAlta;
            if (!ValidarFechaIngreso(fechaDeAlta, out SalidaFechaAlta))
            {
                return;
            }

            DateTime SalidaFechaUltimoLogin;
            if (!ValidarFechaIngreso(fechaDeAlta, out SalidaFechaUltimoLogin))
            {
                return;
            }

            GestionUsuariosNegocio gestionUsuariosNegocio = new GestionUsuariosNegocio();
            gestionUsuariosNegocio.SolicitarModificarCredencial(legajo, nombreUsuario, contraseña, idPerfil, SalidaFechaAlta, SalidaFechaUltimoLogin, legajoSupervisor);

            MessageBox.Show("Solicitud de modificación de Credencial enviada.");
        }
    }
}

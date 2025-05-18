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

namespace TemplateTPCorto
{
    public partial class FormSupervisor : Form
    {
        public FormSupervisor()
        {
            InitializeComponent();
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
            //aca va perfil
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
    }
}

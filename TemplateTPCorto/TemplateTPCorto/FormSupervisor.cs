using Negocio;
using Datos;
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
            txtNUsuario.Text = credencial.NombreUsuario;
            txtContraseña.Text = credencial.Contrasena;
            //aca va perfil
            txtFAlta.Text = credencial.FechaAlta.ToString();
            txtFUltimoLogin.Text = credencial.FechaUltimoLogin.ToString();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using Negocio;
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
    public partial class FormCambioContraseña : Form
    {
        public FormCambioContraseña()
        {
            InitializeComponent();
        }

        public FormCambioContraseña(string usuario)
        {
            InitializeComponent();
            txtUsuario.Text = usuario;
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseñaActual = txtContraseñaActual.Text;
            string contraseñaNueva = txtConstraseñaNueva.Text;
            string contraseñaNueva2 = txtContraseñaNueva2.Text;


            if (String.IsNullOrEmpty(usuario) || String.IsNullOrEmpty(contraseñaActual) || String.IsNullOrEmpty(contraseñaNueva) || String.IsNullOrEmpty(contraseñaNueva2))
            {
                MessageBox.Show("Debe completar todos los campos");
                return;
            }


            if (contraseñaNueva.Length < 8)
            {
                MessageBox.Show("La nueva contraseña debe tener 8 caracteres.");
                return;
            }

            if (contraseñaNueva != contraseñaNueva2)
            {
                MessageBox.Show("La nueva contraseña debe coincidir.");
                return;
            }

            if (contraseñaNueva == contraseñaActual)
            {
                MessageBox.Show("La nueva contraseña no debe ser igual a la actual.");
                return;
            }

            // Ejecuta la lógica de negocio
            CambioContraseñaNegocio cambioContraseñaNegocio = new CambioContraseñaNegocio();
            ResultadoCambioContraseña resultado = cambioContraseñaNegocio.CambiarContraseña(usuario, contraseñaActual, contraseñaNueva);

            // Mostramos el mensaje y tomamos alguna decisión según el estado
            MessageBox.Show(resultado.Mensaje);

            if (resultado.Estado == EstadoCambioContraseña.Exito)
            {
                this.Close(); 
                FormLogin formLogin = new FormLogin();
                formLogin.Show();

            }

        }

    }
}

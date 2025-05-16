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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       public void CambiarContraseña()
        {
            string NuevaContraseña = txtContraseñaActual.ToString();
            string ViejaContraseña = txtUsuario.ToString();

            do
            {

            } while (NuevaContraseña.Length < 8 || NuevaContraseña != ViejaContraseña);

            
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
            LoginNegocio loginNegocio = new LoginNegocio();
            ResultadoLogin resultadoLogin = loginNegocio.login(usuario, contraseñaActual);
            switch (resultadoLogin.Estado)
            {
                case EstadoLogin.exitoso:
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

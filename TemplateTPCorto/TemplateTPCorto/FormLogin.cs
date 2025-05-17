using Datos;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
          
    private void btnIngresar_Click(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String password = txtPassword.Text;
           
            //Validar que los campos no esten vacios
            if (String.IsNullOrEmpty(usuario) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debe ingresar un usuario y contraseña");
                return;
            }

            //Validar si tienen el formato correcto
            if (password.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener 8 caracteres.");
                return;
            }
            if (!usuario.Contains(".")) 
            {
                MessageBox.Show("Usuario inválido.");
                return;
            }

            LoginNegocio loginNegocio = new LoginNegocio();
            ResultadoLogin resultadoLogin= loginNegocio.login(usuario, password);

            MessageBox.Show(resultadoLogin.Mensaje);

            if (resultadoLogin.Estado == EstadoLogin.exitoso)
            {
                this.Close(); // redirigimos a otro form
            }

            if ( resultadoLogin.Estado == EstadoLogin.contraseñavencida)
            {
                this.Hide();
                FormCambioContraseña formCambioContraseña = new FormCambioContraseña();
                formCambioContraseña.ShowDialog();
            }

        }
    }
}

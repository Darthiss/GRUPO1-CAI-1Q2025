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
                string perfil = loginNegocio.BuscarPerfil(resultadoLogin.Credencial.Legajo);
                if (perfil == "1")
                { 
                    this.Hide();
                    // aca va a ir la Fase 2 
                }
                if (perfil == "2")
                {
                    this.Hide();
                    FormSupervisor formSupervisor = new FormSupervisor(resultadoLogin.Credencial.Legajo);
                    formSupervisor.ShowDialog();
                }
                if (perfil == "3")
                {
                    this.Hide();
                    FormAdministrador formAdministrador = new FormAdministrador(resultadoLogin.Credencial.Legajo);
                    formAdministrador.ShowDialog();
                }
            }

            if ( resultadoLogin.Estado == EstadoLogin.contraseñavencida || resultadoLogin.Estado == EstadoLogin.primerlogin)
            {
                this.Hide();
                FormCambioContraseña formCambioContraseña = new FormCambioContraseña(resultadoLogin.Credencial.NombreUsuario);
                formCambioContraseña.ShowDialog();
            }


        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

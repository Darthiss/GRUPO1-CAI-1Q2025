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
    public partial class FormAdministrador : Form
    {

        private string legajoAdministrador;
        private readonly GestionUsuariosNegocio gestionUsuariosNegocio = new GestionUsuariosNegocio();

        public FormAdministrador(string legajoAdministrador)
        {
            InitializeComponent();
            this.legajoAdministrador = legajoAdministrador;
        }

        private void btnCargarPendientes_Click(object sender, EventArgs e)
        {
            dgvOperaciones.Rows.Clear();

            List<Operacion> operaciones = gestionUsuariosNegocio.ObtenerOperacionesPendientes();

            foreach (Operacion op in operaciones)
            {
                
                dgvOperaciones.Rows.Add(op.IdOperacion, op.TipoOperacion, op.Estado, op.LegajoSolicitante, op.FechaSolicitud.ToString("dd/MM/yyyy"), "Ver", "Autorizar", "Rechazar");
                
            }

        }

        private void dgvOperaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOperaciones.Columns[e.ColumnIndex].Name == "VerDetalle")
            {
                string idOperacion = dgvOperaciones.Rows[e.RowIndex].Cells["IdOperacion"].Value.ToString();
                string tipoOperacion = dgvOperaciones.Rows[e.RowIndex].Cells["TipoOperacion"].Value.ToString();

                GestionUsuariosNegocio negocio = new GestionUsuariosNegocio();

                if (tipoOperacion == "ModificarPersona")
                {

                    OperacionCambioPersona operacion_persona = negocio.ObtenerOperacionCambioPersona(idOperacion);

                    string detalle = $"🧍 MODIFICAR PERSONA\n\n" +
                     $"Legajo: {operacion_persona.Legajo}\n" +
                     $"Nombre: {operacion_persona.Nombre}\n" +
                     $"Apellido: {operacion_persona.Apellido}\n" +
                     $"DNI: {operacion_persona.Dni}\n" +
                     $"Fecha de ingreso: {operacion_persona.FechaIngreso:dd/MM/yyyy}";

                    MessageBox.Show(detalle, "Detalle de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else if (tipoOperacion == "ModificarCredencial")
                {
                    OperacionCambioCredencial operacion_credencial = negocio.ObtenerOperacionCambioCredencial(idOperacion);

                    string detalle = $"🔐 CAMBIO CREDENCIAL\n\n" +
                    $"Legajo: {operacion_credencial.Legajo}\n" +
                    $"Usuario: {operacion_credencial.NombreUsuario}\n" +
                    $"Contraseña: {operacion_credencial.Contrasena}\n" +
                    $"ID Perfil: {operacion_credencial.IdPerfil}\n" +
                    $"Fecha de alta: {operacion_credencial.FechaAlta:dd/MM/yyyy}\n" +
                    $"Último login: {operacion_credencial.FechaUltimoLogin:dd/MM/yyyy}";

                    MessageBox.Show(detalle, "Detalle de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            else if (dgvOperaciones.Columns[e.ColumnIndex].Name == "Autorizar") {

                string idOperacion = dgvOperaciones.Rows[e.RowIndex].Cells["IdOperacion"].Value.ToString();
                string tipoOperacion = dgvOperaciones.Rows[e.RowIndex].Cells["TipoOperacion"].Value.ToString();

                var confirm = MessageBox.Show("¿Está seguro que desea autorizar esta operación?", "Confirmar autorización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    gestionUsuariosNegocio.AutorizarOperacion(idOperacion, tipoOperacion, legajoAdministrador);
                    MessageBox.Show("Operación autorizada y aplicada.");
                    btnCargarPendientes_Click(null, null);
                }
            }

            else if (dgvOperaciones.Columns[e.ColumnIndex].Name == "Rechazar") {

                string idOperacion = dgvOperaciones.Rows[e.RowIndex].Cells["IdOperacion"].Value.ToString();
                string tipoOperacion = dgvOperaciones.Rows[e.RowIndex].Cells["TipoOperacion"].Value.ToString();

                var confirm = MessageBox.Show("¿Está seguro que desea rechazar esta operación?", "Confirmar rechazo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    gestionUsuariosNegocio.RechazarOperacion(idOperacion, legajoAdministrador);
                    MessageBox.Show("Operación rechazada");
                    btnCargarPendientes_Click(null, null);
                }
            }
        }
    }
}

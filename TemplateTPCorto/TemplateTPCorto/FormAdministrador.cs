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
    public partial class btnCargarPendientes : Form
    {
        public btnCargarPendientes()
        {
            InitializeComponent();
        }

        private void btnCargarPendientes_Click(object sender, EventArgs e)
        {
            dgvOperaciones.Rows.Clear();

            GestionUsuariosNegocio gestionUsuariosNegocio = new GestionUsuariosNegocio();
            List<Operacion> operaciones = gestionUsuariosNegocio.ObtenerOperacionesPendientes();

            foreach (Operacion op in operaciones)
            {
                
                dgvOperaciones.Rows.Add(op.IdOperacion, op.TipoOperacion, op.Estado, op.LegajoSolicitante, op.FechaSolicitud.ToString("dd/MM/yyyy"), "Ver", "Autorizar", "Rechazar");
                
            }

        }
    }
}

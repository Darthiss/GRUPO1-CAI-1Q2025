namespace TemplateTPCorto
{
    partial class btnCargarPendientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvOperaciones = new System.Windows.Forms.DataGridView();
            this.IdOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LegajoSolicitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerDetalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Autorizar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Rechazar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOperaciones
            // 
            this.dgvOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdOperacion,
            this.TipoOperacion,
            this.Estado,
            this.LegajoSolicitante,
            this.FechaSolicitud,
            this.VerDetalle,
            this.Autorizar,
            this.Rechazar});
            this.dgvOperaciones.Location = new System.Drawing.Point(33, 83);
            this.dgvOperaciones.Name = "dgvOperaciones";
            this.dgvOperaciones.Size = new System.Drawing.Size(756, 323);
            this.dgvOperaciones.TabIndex = 0;
            // 
            // IdOperacion
            // 
            this.IdOperacion.HeaderText = "IdOperacion";
            this.IdOperacion.Name = "IdOperacion";
            this.IdOperacion.Visible = false;
            // 
            // TipoOperacion
            // 
            this.TipoOperacion.HeaderText = "Tipo Operacion";
            this.TipoOperacion.Name = "TipoOperacion";
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            // 
            // LegajoSolicitante
            // 
            this.LegajoSolicitante.HeaderText = "Legajo Solicitante";
            this.LegajoSolicitante.Name = "LegajoSolicitante";
            // 
            // FechaSolicitud
            // 
            this.FechaSolicitud.HeaderText = "Fecha Solicitud";
            this.FechaSolicitud.Name = "FechaSolicitud";
            // 
            // VerDetalle
            // 
            this.VerDetalle.HeaderText = "Ver Detalle\t";
            this.VerDetalle.Name = "VerDetalle";
            // 
            // Autorizar
            // 
            this.Autorizar.HeaderText = "Autorizar";
            this.Autorizar.Name = "Autorizar";
            // 
            // Rechazar
            // 
            this.Rechazar.HeaderText = "Rechazar";
            this.Rechazar.Name = "Rechazar";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cargar Solicitudes Pendientes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCargarPendientes_Click);
            // 
            // btnCargarPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 488);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvOperaciones);
            this.Name = "btnCargarPendientes";
            this.Text = "FormAdministrador";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOperaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn LegajoSolicitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaSolicitud;
        private System.Windows.Forms.DataGridViewButtonColumn VerDetalle;
        private System.Windows.Forms.DataGridViewButtonColumn Autorizar;
        private System.Windows.Forms.DataGridViewButtonColumn Rechazar;
        private System.Windows.Forms.Button button1;
    }
}
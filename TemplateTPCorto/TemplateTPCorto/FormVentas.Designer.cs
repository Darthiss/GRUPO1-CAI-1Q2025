namespace TemplateTPCorto
{
    partial class FormVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCategoriaProductos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lablSubTotal = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnListarProductos = new System.Windows.Forms.Button();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.lbl1 = new System.Windows.Forms.Label();
            this.labelDscto = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(212, 61);
            this.cmbClientes.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(238, 28);
            this.cmbClientes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Categoria Productos";
            // 
            // cboCategoriaProductos
            // 
            this.cboCategoriaProductos.FormattingEnabled = true;
            this.cboCategoriaProductos.Location = new System.Drawing.Point(212, 126);
            this.cboCategoriaProductos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboCategoriaProductos.Name = "cboCategoriaProductos";
            this.cboCategoriaProductos.Size = new System.Drawing.Size(136, 28);
            this.cboCategoriaProductos.TabIndex = 3;
            this.cboCategoriaProductos.SelectedIndexChanged += new System.EventHandler(this.cboCategoriaProductos_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 726);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "SubTotal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 800);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(189, 800);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(53, 20);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "$ 0,00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 560);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(138, 554);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(112, 26);
            this.txtCantidad.TabIndex = 11;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(306, 555);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(246, 29);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar a carrito";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lablSubTotal
            // 
            this.lablSubTotal.AutoSize = true;
            this.lablSubTotal.Location = new System.Drawing.Point(189, 726);
            this.lablSubTotal.Name = "lablSubTotal";
            this.lablSubTotal.Size = new System.Drawing.Size(53, 20);
            this.lablSubTotal.TabIndex = 13;
            this.lablSubTotal.Text = "$ 0,00";
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(51, 825);
            this.btnCargar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(501, 29);
            this.btnCargar.TabIndex = 16;
            this.btnCargar.Text = "Cargar Venta";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnListarProductos
            // 
            this.btnListarProductos.Location = new System.Drawing.Point(393, 126);
            this.btnListarProductos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnListarProductos.Name = "btnListarProductos";
            this.btnListarProductos.Size = new System.Drawing.Size(127, 29);
            this.btnListarProductos.TabIndex = 17;
            this.btnListarProductos.Text = "Listar productos";
            this.btnListarProductos.UseVisualStyleBackColor = true;
            this.btnListarProductos.Click += new System.EventHandler(this.btnListarProductos_Click);
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Location = new System.Drawing.Point(648, 201);
            this.dgvCarrito.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.RowHeadersWidth = 51;
            this.dgvCarrito.Size = new System.Drawing.Size(1052, 326);
            this.dgvCarrito.TabIndex = 18;
            this.dgvCarrito.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarrito_CellContentClick);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(47, 764);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(87, 20);
            this.lbl1.TabIndex = 19;
            this.lbl1.Text = "Descuento";
            // 
            // labelDscto
            // 
            this.labelDscto.AutoSize = true;
            this.labelDscto.Location = new System.Drawing.Point(189, 764);
            this.labelDscto.Name = "labelDscto";
            this.labelDscto.Size = new System.Drawing.Size(0, 20);
            this.labelDscto.TabIndex = 20;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(189, 764);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(53, 20);
            this.lblDescuento.TabIndex = 21;
            this.lblDescuento.Text = "$ 0,00";
            this.lblDescuento.Click += new System.EventHandler(this.label6_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Precio,
            this.Stock});
            this.dgvProductos.Location = new System.Drawing.Point(12, 201);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 62;
            this.dgvProductos.RowTemplate.Height = 28;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(629, 293);
            this.dgvProductos.TabIndex = 22;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 8;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 150;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Precio.DefaultCellStyle = dataGridViewCellStyle3;
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 8;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 150;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 8;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 150;
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1851, 994);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.labelDscto);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.btnListarProductos);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.lablSubTotal);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCategoriaProductos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbClientes);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FormVentas";
            this.Text = "FormVentas";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCategoriaProductos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lablSubTotal;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnListarProductos;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label labelDscto;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
    }
}
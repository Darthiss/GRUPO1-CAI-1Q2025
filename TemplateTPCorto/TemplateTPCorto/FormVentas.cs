using Datos;
using Datos.Ventas;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormVentas : Form
    {
        private Carrito carrito;

        public FormVentas()
        {
            InitializeComponent();
            this.carrito = new Carrito();
            CargarCarrito();
            dgvCarrito.DataSource = carrito.itemsCarrito;

        }

        private void FormVentas_Load(object sender, EventArgs e)
        {

            CargarClientes();
            CargarCategoriasProductos();
            IniciarTotales();
        }

        private void IniciarTotales()
        {
            lablSubTotal.Text = "0.00";
            lblTotal.Text = "0.00";
        }

        private void CargarCategoriasProductos()
        {

            VentasNegocio ventasNegocio = new VentasNegocio();

            List<CategoriaProductos> categoriaProductos = ventasNegocio.obtenerCategoriaProductos();

            foreach (CategoriaProductos categoriaProducto in categoriaProductos)
            {
                cboCategoriaProductos.Items.Add(categoriaProducto);
            }
        }

        private void CargarClientes()
        {
            VentasNegocio ventasNegocio = new VentasNegocio();

            List<Cliente> listadoClientes = ventasNegocio.obtenerClientes();

            foreach (Cliente cliente in listadoClientes)
            {
                cmbClientes.Items.Add(cliente);
            }
        }

        private void btnListarProductos_Click(object sender, EventArgs e)
        {

            if(cboCategoriaProductos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una categoría de productos");
                return;
            }

            VentasNegocio ventasNegocio = new VentasNegocio();
            CategoriaProductos categoria = cboCategoriaProductos.SelectedItem as CategoriaProductos;

            List<Producto> Productos = ventasNegocio.obtenerProductosPorCategoria(categoria.Id);
            Productos = FiltrarProducto(Productos);
            lstProducto.DataSource = Productos;
        }

        private void cboCategoriaProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public List<Producto> FiltrarProducto(List<Producto> Productos)
        {
            List<Producto> ProductosFiltrados = new List<Producto>();
            foreach (Producto producto in Productos)
            {
                if (producto.Stock > 0 && producto.FechaBaja == null)
                {
                    ProductosFiltrados.Add(producto);
                }
            }
            return ProductosFiltrados;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lstProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un producto");
                return;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Debe ingresar una cantidad");
                return;
            }
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad < 0)
            {
                MessageBox.Show("La cantidad debe ser númerica y positiva");
                return;
            }


            Producto productoSeleccionado = lstProducto.SelectedItem as Producto;

            carrito.AgregarProducto(productoSeleccionado, cantidad);

            dgvCarrito.Refresh();
            ActualizarTotales();

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvCarrito.Columns[e.ColumnIndex].Name == "Incremento")
            {

                ItemCarrito itemSeleccionado = dgvCarrito.Rows[e.RowIndex].DataBoundItem as ItemCarrito;
                carrito.AgregarProducto(itemSeleccionado.Producto, 1);
                dgvCarrito.Refresh();
                ActualizarTotales();

            }

            if (dgvCarrito.Columns[e.ColumnIndex].Name == "Decremento")
            {
                ItemCarrito itemSeleccionado = dgvCarrito.Rows[e.RowIndex].DataBoundItem as ItemCarrito;
                carrito.EliminarProducto(itemSeleccionado.Producto, 1);
                dgvCarrito.Refresh();
                ActualizarTotales();
            }

            if (dgvCarrito.Columns[e.ColumnIndex].Name == "Quitar")
            {
                ItemCarrito itemSeleccionado = dgvCarrito.Rows[e.RowIndex].DataBoundItem as ItemCarrito;
                carrito.RemoverProducto(itemSeleccionado.Producto);
                dgvCarrito.Refresh();
                ActualizarTotales();
            }
        }

        public void CargarCarrito()
        {
            dgvCarrito.AutoGenerateColumns = false;
            dgvCarrito.Columns.Clear();

            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Producto",
                DataPropertyName = "Producto", // llama a ToString() del Producto
                ReadOnly = true
            });

            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad",
                ReadOnly = true
            });

            dgvCarrito.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Subtotal",
                DataPropertyName = "Subtotal",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C" },
                ReadOnly = true
            });

            dgvCarrito.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Incremento",
                HeaderText = "Incremento",
                Text = "+1",
                UseColumnTextForButtonValue = true
            });

            dgvCarrito.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Decremento",
                HeaderText = "Decremento",
                Text = "-1",
                UseColumnTextForButtonValue = true
            });

            dgvCarrito.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Quitar",
                HeaderText = "Quitar",
                Text = "Quitar",
                UseColumnTextForButtonValue = true
            });

            dgvCarrito.DataSource = carrito.itemsCarrito;
        }

        public void ActualizarTotales()
        {
            carrito.CalcularSubtotales();
            lablSubTotal.Text = carrito.subtotal.ToString("C");
            lblTotal.Text = carrito.total.ToString("C");
        }
    }

}


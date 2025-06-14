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

            List<Producto> productos = ventasNegocio.obtenerProductosPorCategoria(categoria.Id);
            productos = FiltrarProductos(productos);
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DataSource = productos;
        }

        private void cboCategoriaProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public List<Producto> FiltrarProductos(List<Producto> Productos)
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
            if (dgvProductos.SelectedRows.Count == 0)
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


            Producto productoSeleccionado = dgvProductos.SelectedRows[0].DataBoundItem as Producto;

            if (cantidad > productoSeleccionado.Stock)
            {
                MessageBox.Show("No hay stock suficiente");
                return;
            }

            bool respuesta = carrito.AgregarProducto(productoSeleccionado, cantidad);

            if (respuesta == false)
            {
                MessageBox.Show("No hay stock suficiente");
                return;

            }

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
                bool respuesta = carrito.AgregarProducto(itemSeleccionado.Producto, 1);

                if (respuesta == false)
                {
                    MessageBox.Show("No hay stock suficiente");
                    return;

                }
                
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
                DataPropertyName = "Producto", 
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
            carrito.CalcularTotal();
            lablSubTotal.Text = carrito.subtotal.ToString("C");
            lblDescuento.Text = ((carrito.subtotal - carrito.total)* -1).ToString("C");
            lblTotal.Text = carrito.total.ToString("C");
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }
            if (carrito.itemsCarrito.Count == 0)
            {
                MessageBox.Show("Debe agregar productos al carrito");
                return;
            }
            Cliente clienteSeleccionado = cmbClientes.SelectedItem as Cliente;
            VentasNegocio ventasNegocio = new VentasNegocio();
            bool respuesta = ventasNegocio.CargarVenta(clienteSeleccionado.Id, carrito);

            if (respuesta == true)
            {
                MessageBox.Show("Venta cargada correctamente");
                carrito = new Carrito();
                CargarCarrito();
                dgvCarrito.DataSource = carrito.itemsCarrito;
                ActualizarTotales();
                btnListarProductos_Click(null,null);
            }
            else
            {
                MessageBox.Show("Error al cargar la venta");

            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}


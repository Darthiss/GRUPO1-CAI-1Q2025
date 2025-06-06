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
            lstCarrito.DataSource = carrito.itemsCarrito;
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
            VentasNegocio ventasNegocio = new VentasNegocio();
            CategoriaProductos categoria = cboCategoriaProductos.SelectedItem as CategoriaProductos;

            List<Producto> Productos = ventasNegocio.obtenerProductosPorCategoria(categoria.Id);
            Productos = FiltrarProducto(Productos);
            lstProducto.DataSource = Productos;
        }

        private void cboCategoriaProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public List <Producto> FiltrarProducto(List<Producto> Productos)
        {
            List<Producto> ProductosFiltrados = new List<Producto>(); 
            foreach (Producto producto in Productos)
            {
                if(producto.Stock > 0 && producto.FechaBaja == null)
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
            if(string.IsNullOrEmpty(txtCantidad.Text))
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

            carrito.CalcularSubtotales();

            lblSubTotal.Text = carrito.subtotal.ToString("C");



        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

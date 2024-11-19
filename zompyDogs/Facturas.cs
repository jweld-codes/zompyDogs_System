using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zompyDogs.CRUD.REGISTROS;
using ZompyDogsDAO;

namespace zompyDogs
{
    public partial class Facturas : Form
    {
        public BienvenidaAdmin FormPrincipal { get; set; }
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }

        private int usuarioIDActual;
        private int rolIDActual;

        private string pedidoCodigoEmpleadoVal;
        private string pedidoEmpleadoVal;
        private string pedidoCodigoPedidoVal;
        private int pedidoTotalDelPedido;

        private string pedidoEstado = "Completado";
        private DateTime pedidoFechaVal;

        private decimal pedidoTotal;
        private decimal pedidoSubtotal;
        private decimal pedidoISV;

        private PedidosDAO _pedidosDAO;
        public Facturas(int usuarioIDActual, int rolIDActual)
        {
            InitializeComponent();
            this.rolIDActual = rolIDActual;
            this.usuarioIDActual = usuarioIDActual;
            //MessageBox.Show("idEmpleado: " + usuarioIDActual + "RolIdActual: " + rolIDActual);

            if (rolIDActual == 1)
            {
                // btnPuntoVenta.Enabled = false;
                // btnPuntoVenta.Visible = false;
                // btnPuntoVenta.Hide();
            }

            _pedidosDAO = new PedidosDAO();

            CargarFacturas();
        }
        private void CargarFacturas()
        {
            DataTable facturas = PedidosDAO.ObtenerDetalllesPedidos_DGV();
            dgvHistorialPedidos.DataSource = facturas;

            dgvHistorialPedidos.Columns["Codigo_Pedido"].HeaderText = "Código del Pedido";
            dgvHistorialPedidos.Columns["Codigo_Empleado"].HeaderText = "Código de Empleado";
            dgvHistorialPedidos.Columns["Empleado"].HeaderText = "Nombre del Empleado";

            dgvHistorialPedidos.Columns["Total_a_Pagar"].HeaderText = "Total a Pagar";
            dgvHistorialPedidos.Columns["Fecha_Del_Pedido"].HeaderText = "Fecha del Pédido";

            // dgvHistorialPedidos.Columns["Total_De_Productos"].HeaderText = "Total de platillos en la orden";

            dgvHistorialPedidos.EnableHeadersVisualStyles = false;
            dgvHistorialPedidos.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvHistorialPedidos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvHistorialPedidos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
        }

        private void CambiarColorBoton(Button botonActivo)
        {
            foreach (Control ctrl in topBarMenu.Controls)
            {
                if (ctrl is Button)
                {
                    Button boton = (Button)ctrl;
                    boton.BackColor = Color.Transparent;
                    boton.ForeColor = Color.White;
                }
            }

            botonActivo.BackColor = Color.White;
            botonActivo.ForeColor = Color.Black;
        }

        private void btnPuntoVenta_Click(object sender, EventArgs e)
        {

        }

        private void btnVisualizarRegistro_Click(object sender, EventArgs e)
        {
            var facturaView = new FacturaView();

            // Deshabilitar todos los elementos del formulario
            foreach (Control control in facturaView.Controls)
            {
                control.Enabled = false;
            }
            facturaView.btnCancelar.Enabled = true;
            facturaView.Show();

            DataTable facturaViewEmpleado = PedidosDAO.ObtenerDetalllesDeFacturaFinalizadaPorPlatillo(pedidoCodigoPedidoVal);

            if (facturaViewEmpleado.Rows.Count > 0)
            {
                DataRow fila = facturaViewEmpleado.Rows[0];

                facturaView.txtCodigoGenerado.Text = fila["Codigo_Pedido"].ToString();
                facturaView.lblCodigoEmpleado.Text = pedidoCodigoEmpleadoVal.ToString();
                facturaView.txtEmpleado.Text = pedidoEmpleadoVal.ToString();
                facturaView.dtpFechaRegistro.Text = pedidoFechaVal.ToString();
                facturaView.lblTotal.Text = pedidoTotal.ToString();
                facturaView.lblSubtotal.Text = pedidoSubtotal.ToString();

                facturaView.lblISV.Text = fila["ISV"].ToString();

                facturaView.txtEstado.Text = pedidoEstado.ToString();
                // facturaView.lblTotalProductos.Text = pedidoTotalDelPedido.ToString();

                DataTable detalleProductosTable = new DataTable();
                detalleProductosTable.Columns.Add("Platillo", typeof(string));
                detalleProductosTable.Columns.Add("Cantidad", typeof(int));
                detalleProductosTable.Columns.Add("Precio Unitario", typeof(decimal));

                foreach (DataRow platillo in facturaViewEmpleado.Rows)
                {
                    string nombrePlatillo = platillo["Nombre_Platillo"].ToString();
                    int cantidad = Convert.ToInt32(platillo["Cantidad"]);
                    decimal precioUnitario = Convert.ToDecimal(platillo["Precio_Unitario"]);

                    Console.WriteLine($"Platillo: {nombrePlatillo}, Cantidad: {cantidad}, Precio: {precioUnitario}");

                    detalleProductosTable.Rows.Add(nombrePlatillo, cantidad, precioUnitario);
                }


                facturaView.dgvTotalPedido.DataSource = detalleProductosTable;
                facturaView.dgvTotalPedido.Refresh();

            }
            else
            {
                MessageBox.Show("No se encontraron detalles para el pedido especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHistorialPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBuscarUsuario.PlaceholderText = "Buscar Empleado";
            if (e.RowIndex >= 0) // Asegúrate de que la fila seleccionada es válida.
            {
                DataGridViewRow filaSeleccionada = dgvHistorialPedidos.Rows[e.RowIndex];
                pedidoCodigoEmpleadoVal = filaSeleccionada.Cells["Codigo_Empleado"].Value.ToString();
                pedidoCodigoPedidoVal = filaSeleccionada.Cells["Codigo_Pedido"].Value.ToString();
                pedidoEmpleadoVal = filaSeleccionada.Cells["Empleado"].Value.ToString();
                pedidoFechaVal = Convert.ToDateTime(filaSeleccionada.Cells["Fecha_Del_Pedido"].Value.ToString());


                // pedidoTotalDelPedido = Convert.ToInt32(filaSeleccionada.Cells["Total_De_Productos"].Value.ToString());
                pedidoSubtotal = Convert.ToDecimal(filaSeleccionada.Cells["Subtotal"].Value.ToString());
                pedidoTotal = Convert.ToDecimal(filaSeleccionada.Cells["Total_a_Pagar"].Value.ToString());
                pedidoISV = Convert.ToDecimal(filaSeleccionada.Cells["ISV"].Value.ToString());
            }
        }

        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            string valorBusqueda = txtBuscarUsuario.Text;
            DataTable resultados = PedidosDAO.BuscadorDeFacturas(valorBusqueda);
            dgvHistorialPedidos.DataSource = resultados;
        }

        private void dtpFechaPedido_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnFechaPedido_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFechaPedido.Value.Date;
            DataTable resultadosFecha = PedidosDAO.BuscadorDeFacturasPorFecha(fechaSeleccionada);

            dgvHistorialPedidos.DataSource = resultadosFecha;

        }

        private void btnRefreshDG_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void Facturas_Load(object sender, EventArgs e)
        {

        }
    }
}

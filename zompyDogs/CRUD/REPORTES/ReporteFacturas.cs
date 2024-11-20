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
using Microsoft.Reporting.WinForms;
using ClosedXML.Excel;
using System.IO;


namespace zompyDogs.CRUD.REPORTES
{
    public partial class ReporteFacturas : Form
    {
        public BienvenidaAdmin FormPrincipal { get; set; }
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }

        private int usuarioIDActual;
        private int rolIDActual;

        private string pedidoCodigoEmpleadoVal;
        private string pedidoEmpleadoVal;
        private string pedidoCodigoPedidoVal;
        private int pedidoTotalDelPedido;

        private string pedidoEstado = "Pagado";
        private DateTime pedidoFechaVal;

        private decimal pedidoTotal;
        private decimal pedidoSubtotal;
        private decimal pedidoISV;

        public ReporteFacturas()
        {
            InitializeComponent();

            CargarFacturas();
            txtEmpleado.Enabled = false;
            txtEstado.Enabled = false;
            dtpFechaRegistro.Enabled = false;

            dgvPedidoSelect.ClearSelection();
            dgvPedidoSelect.CurrentCell = null;


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

            dgvHistorialPedidos.EnableHeadersVisualStyles = false;
            dgvHistorialPedidos.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvHistorialPedidos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvHistorialPedidos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
        }

        private void dgvHistorialPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
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

                txtCodigoGenerado.Text = pedidoCodigoPedidoVal;
                txtEmpleado.Text = pedidoEmpleadoVal;
                txtEstado.Text = pedidoEstado;
                lblCodigoEmpleado.Text = pedidoCodigoEmpleadoVal;
                lblSubtotal.Text = pedidoSubtotal.ToString();
                lblISV.Text = pedidoISV.ToString();
                lblTotalPago.Text = pedidoTotal.ToString();
                dtpFechaRegistro.Text = pedidoFechaVal.ToString();

                DataTable facturaViewEmpleado = PedidosDAO.ObtenerDetalllesDeFacturaFinalizadaPorPlatillo(pedidoCodigoPedidoVal);

                DataTable detalleProductosTable = new DataTable();
                detalleProductosTable.Columns.Add("Platillo", typeof(string));
                detalleProductosTable.Columns.Add("Cantidad", typeof(int));
                detalleProductosTable.Columns.Add("Precio Unitario", typeof(decimal));

                foreach (DataRow platillo in facturaViewEmpleado.Rows)
                {
                    string nombrePlatillo = platillo["Nombre_Platillo"].ToString();
                    int cantidad = Convert.ToInt32(platillo["Cantidad"]);
                    decimal precioUnitario = Convert.ToDecimal(platillo["Precio_Unitario"]);

                    detalleProductosTable.Rows.Add(nombrePlatillo, cantidad, precioUnitario);
                }


                dgvPedidoSelect.DataSource = detalleProductosTable;
                dgvPedidoSelect.Refresh();

            }
        }

        private void dtpFechaPedido_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFechaPedido.Value.Date;
            DataTable resultadosFecha = PedidosDAO.BuscadorDeFacturasPorFecha(fechaSeleccionada);

            dgvHistorialPedidos.DataSource = resultadosFecha;
        }

        private void btnRefreshDG_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable facturaViewPedido = PedidosDAO.ObtenerDetalllesDeFacturaFinalizadaPorPlatillo(pedidoCodigoPedidoVal);
            DataTable facturaPedidoTrans = new DataTable();
            facturaPedidoTrans.Columns.Add("Platillo", typeof(string));
            facturaPedidoTrans.Columns.Add("Cantidad", typeof(int));
            facturaPedidoTrans.Columns.Add("Precio Unitario", typeof(decimal));

            foreach (DataRow platillo in facturaViewPedido.Rows)
            {
                string nombrePlatillo = platillo["Nombre_Platillo"].ToString();
                int cantidad = Convert.ToInt32(platillo["Cantidad"]);
                decimal precioUnitario = Convert.ToDecimal(platillo["Precio_Unitario"]);
                
                facturaPedidoTrans.Rows.Add(nombrePlatillo, cantidad, precioUnitario);
            }

            ImprimirFactura frmImprimirFactura = new ImprimirFactura(pedidoCodigoPedidoVal, facturaPedidoTrans);

            

            frmImprimirFactura.lblEmpleadoNombre.Text = txtEmpleado.Text;
            frmImprimirFactura.lblNumFac.Text = txtCodigoGenerado.Text;
            frmImprimirFactura.lblFechaPedido.Text = dtpFechaRegistro.Text;
            frmImprimirFactura.lblTotal.Text = lblTotalPago.Text;
            frmImprimirFactura.lblSubtotal.Text = lblSubtotal.Text;
            frmImprimirFactura.lblISV.Text = lblISV.Text;
            frmImprimirFactura.lblCodigoEmpleado.Text = lblCodigoEmpleado.Text;


            frmImprimirFactura.Show();
        }
        private void ExportarAExcel()
        {
            var wb = new XLWorkbook();

            // Hoja de Todas las facturas
            var wsDiarios = wb.Worksheets.Add("Todas las facturas");
            wsDiarios.Cell(1, 1).Value = "Código del pedido";
            wsDiarios.Cell(1, 2).Value = "Código del empleado";
            wsDiarios.Cell(1, 3).Value = "Nombre del Empleado";
            wsDiarios.Cell(1, 4).Value = "Subtotal";
            wsDiarios.Cell(1, 5).Value = "ISV";
            wsDiarios.Cell(1, 6).Value = "Total a Pagar";
            wsDiarios.Cell(1, 7).Value = "Fecha del ´Pedido";

            wsDiarios.Cell(2, 1).Value = pedidoCodigoPedidoVal;
            wsDiarios.Cell(2, 2).Value = pedidoCodigoEmpleadoVal;
            wsDiarios.Cell(2, 3).Value = pedidoEmpleadoVal;
            wsDiarios.Cell(2, 4).Value = pedidoSubtotal;
            wsDiarios.Cell(2, 5).Value = pedidoISV;
            wsDiarios.Cell(2, 6).Value = pedidoTotal;
            wsDiarios.Cell(2, 7).Value = pedidoFechaVal;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}

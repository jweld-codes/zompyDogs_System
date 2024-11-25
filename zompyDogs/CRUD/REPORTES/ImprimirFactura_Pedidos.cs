using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZompyDogsDAO;
using static ZompyDogsLib.Pedidos;

namespace zompyDogs.CRUD.REPORTES
{
    public partial class ImprimirFactura_Pedidos : Form
    {
        private string PedidoCodigoValor { get; set; }

        private List<DetalleDePedido> listaPlatillos;
        /// Data Access Object (DAO) para manejar las operaciones relacionadas con pedidos.
        private PedidosDAO _pedidosDAO;
        /// Fuente de enlace para la lista de platillos en el DataGridView.
        public BindingSource _bndsrcPedido;
        public ImprimirFactura_Pedidos(List<DetalleDePedido> platillos)
        {
            InitializeComponent();

            // Asignar la lista al BindingSource para enlazarla al DataGridView
            _bndsrcPedido = new BindingSource();
            _bndsrcPedido.DataSource = platillos;

            // Asignar el BindingSource al DataGridView
            dgvPlatillos.DataSource = _bndsrcPedido;

            // También puedes agregar la columna Total si no la tienes
            MostrarDatosFactura(platillos);

            DeactivateCell();
            btnAceptar.Show();
        }

        private void MostrarDatosFactura(List<DetalleDePedido> platillos)
        {
            // Agregar los datos al DataGridView
            foreach (var pedido in platillos)
            {
                dgvPlatillos.Rows.Add(pedido.PlatilloNombre, pedido.Cantidad, pedido.Precio_Unitario);
            }
        }

        private void DeactivateCell()
        {
            dgvPlatillos.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvPlatillos.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void printFactura_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int pageWidth = e.PageBounds.Width;
            int pageHeight = e.PageBounds.Height;

            float scaleWidth = (float)pageWidth / bitmap.Width;
            float scaleHeight = (float)pageHeight / bitmap.Height;
            float scale = Math.Min(scaleWidth, scaleHeight);

            int scaledWidth = (int)(bitmap.Width * scale);
            int scaledHeight = (int)(bitmap.Height * scale);

            int offsetX = (pageWidth - scaledWidth) / 2;
            int offsetY = (pageHeight - scaledHeight) / 2;

            e.Graphics.DrawImage(bitmap, offsetX, offsetY, scaledWidth, scaledHeight);
        }

        Bitmap bitmap;
        private void ImprimirFac()
        {
            btnImprimir.Hide();
            btnAceptar.Hide();
            Graphics graphics = CreateGraphics();
            Size size = this.ClientSize;

            bitmap = new Bitmap(size.Width, size.Height, graphics);
            graphics = Graphics.FromImage(bitmap);

            Point point = PointToScreen(new Point(0, 0));
            graphics.CopyFromScreen(point.X, point.Y, 0, 0, size);

        }
        private bool esImpresionReal = false;
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (bitmap == null)
            {
                ImprimirFac();
            }

            esImpresionReal = true;
            printFactura.Print();
        }

        private void printFactura_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            MessageBox.Show("El documento se guardó exitosamente como PDF.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

    }
}

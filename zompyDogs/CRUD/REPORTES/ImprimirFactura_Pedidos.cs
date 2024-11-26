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

        private DataTable datosFactura;
        public ImprimirFactura_Pedidos(DataTable datosplatillos)
        {
            InitializeComponent();

            // Ajustar todas las columnas automáticamente
            dgvPlatillos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Asignar el BindingSource al DataGridView
            dgvPlatillos.DataSource = _bndsrcPedido;

            this.datosFactura = datosplatillos;

            // También puedes agregar la columna Total si no la tienes

            DeactivateCell();
            btnAceptar.Show();
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

        private void ImprimirFactura_Pedidos_Load(object sender, EventArgs e)
        {
            dgvPlatillos.DataSource = datosFactura;

            // Ocultar las columnas no deseadas (por ejemplo, si quieres mostrar solo 'cantidad', 'platillo' y 'precio unitario')
            foreach (DataGridViewColumn column in dgvPlatillos.Columns)
            {
                // Suponiendo que las columnas se llaman "Cantidad", "Platillo" y "PrecioUnitario"
                if (column.HeaderText != "Cantidad" && column.HeaderText != "Platillo" && column.HeaderText != "Precio")
                {
                    column.Visible = false;
                }
            }


        }
    }
}

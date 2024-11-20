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

namespace zompyDogs.CRUD.REPORTES
{
    public partial class ImprimirFactura : Form
    {
        private string PedidoCodigoValor { get; set; }
        public ImprimirFactura(string pedidoCodigo, DataTable detallesPlatillos)
        {
            InitializeComponent();

            PedidoCodigoValor = pedidoCodigo;

            CargarFactura(pedidoCodigo, detallesPlatillos);
            DeactivateCell();
            btnAceptar.Hide();
            //printFactura.EndPrint += printFactura_EndPrint;
        }

        private void DeactivateCell()
        {
            dgvPlatillos.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvPlatillos.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void CargarFactura(string pedidoCodigo, DataTable detallesPlatillos)
        {
            lblNumFac.Text = pedidoCodigo;
            dgvPlatillos.DataSource = detallesPlatillos;
            dgvPlatillos.Refresh();
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
            btnAceptar.Hide();
            ImprimirFac();

            esImpresionReal = false;
            printPreviewFactura.Document = printFactura;
            printPreviewFactura.ShowDialog(); 
            btnAceptar.Show();
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

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

namespace zompyDogs
{
    public partial class Inventario : Form
    {
        public BienvenidaAdmin FormPrincipal { get; set; }
        public Inventario()
        {
            InitializeComponent();
            CargarProductos();
        }
        private void CargarProductos()
        {
            DataTable productos = ProductosDAO.ObtenerDetalllesProductos();
            dgvProductos.DataSource = productos;
        }
        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario frmInventario = new Inventario();
            frmInventario.Show();
            this.Hide();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            //Factura frmPedidos = new Factura();
            //frmPedidos.Show();
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zompyDogs.CRUD.REPORTES;

namespace zompyDogs
{
    public partial class PanelReportes : Form
    {
        public BienvenidaAdmin FormPrincipal { get; set; }
        public PanelReportes()
        {
            InitializeComponent();
        }

        // Abre el formulario de reportes de Ventas
        private void repoVentas_Click(object sender, EventArgs e)
        {
            ReporteVentas frmReporteVentas = new ReporteVentas();
            frmReporteVentas.Show();
        }

        // Abre el formulario de reportes de Facturas
        private void button1_Click(object sender, EventArgs e)
        {
            ReporteFacturas frmReporteFacturas = new ReporteFacturas();
            frmReporteFacturas.Show();
        }
    }
}

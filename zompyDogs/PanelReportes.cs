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

        private void repoVentas_Click(object sender, EventArgs e)
        {
            ReporteVentas frmReporteVentas = new ReporteVentas();
            frmReporteVentas.Show();
        }

        private void repoGanacias_Click(object sender, EventArgs e)
        {
            ReporteGanancias frmReporteGanancias = new ReporteGanancias();
            frmReporteGanancias.Show();
        }
    }
}

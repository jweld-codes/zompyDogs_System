using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace zompyDogs.CRUD.REPORTES
{
    public partial class ReporteVentas : Form
    {
        public static readonly string con_string = "Data Source=MACARENA\\SQLEXPRESS;Initial Catalog=DB_ZompyDogs;Integrated Security=True;Encrypt=False";
        public static SqlConnection conn = new SqlConnection(con_string);

        public ReporteVentas()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {

        }
    }
}

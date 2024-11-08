using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZompyDogsDAO;

namespace zompyDogs
{
    public partial class PanelEmpleado : Form
    {
        public static readonly string con_string = "Data Source=MACARENA\\SQLEXPRESS;Initial Catalog=DB_ZompyDogs;Integrated Security=True;Encrypt=False";
        public static SqlConnection conn = new SqlConnection(con_string);

        public int IDEmpleado { get; set; }
        public string NombreUsuarioEmpleado { get => lblNombreUser.Text; set => lblNombreUser.Text = value; }

        public PanelEmpleado()
        {
            InitializeComponent();
            CargarPedidosRecientes();
        }

        public void InicializarEmpleado(int idEmpleado)
        {
            IDEmpleado = idEmpleado;
            //CargarPedidosPorEmpleado(IDEmpleado);
        }


        private void CargarPedidosRecientes()
        {
            DataTable pedidos = PedidosDAO.ObtenerDetallesdePedidoPorEmpleado(IDEmpleado);
            dtgHistorialPedidos.DataSource = pedidos;
        }

        private void btnLogOutPanel_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("¿Está seguro de cerrar sessión?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {

                Login frmLogin = new Login();
                frmLogin.Show();

                EmpleadoBienvenida frmEmpleado = new EmpleadoBienvenida();
                frmEmpleado.Close();
            }
        }

        private void PanelEmpleado_Load(object sender, EventArgs e)
        {
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblFechaActual.Text = fechaActual;
        }

       /* private void CargarPedidosPorEmpleado(int idEmpleado)
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = @"
                SELECT Cantidad_Pedidos
                FROM v_PedidosxEmpleado
                WHERE IDEmpleado = @idEmpleado";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                try
                {
                    conn.Open();
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != DBNull.Value && resultado != null)
                    {
                        lblPedidosEmp.Text = $"{resultado}";
                    }
                    else
                    {
                        lblPedidosEmp.Text = "00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los pedidos por empleado: {ex.Message}");
                }
            }
        } */





    }
}

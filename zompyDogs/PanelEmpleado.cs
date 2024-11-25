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

        public PanelEmpleado(int idEmpleado)
        {
            InitializeComponent();
            IDEmpleado = idEmpleado;

            CargarPedidosRecientes();
            CargarPedidosSemanal();
            CargarPedidosTotales();

            lblTotalPedidosSem.Text = "00";
        }

        //Carga en datagrid los pedidos recientes realizados por el empleado
        private void CargarPedidosRecientes()
        {
            DataTable pedidos = PedidosDAO.ObtenerDetallesdePedidoPorEmpleado(IDEmpleado);
            dtgHistorialPedidos.DataSource = pedidos;

            dtgHistorialPedidos.Columns["Codigo_Pedido"].HeaderText = "Código del Pedido";
            dtgHistorialPedidos.Columns["Total_De_Productos"].HeaderText = "Cantidad de Orden";
            dtgHistorialPedidos.Columns["Total_a_Pagar"].HeaderText = "Total";

            dtgHistorialPedidos.EnableHeadersVisualStyles = false;
            dtgHistorialPedidos.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dtgHistorialPedidos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dtgHistorialPedidos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        //Muestra el total de pedidos realizados de la semana por el empleado 
        private void CargarPedidosSemanal()
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = @"
                SELECT TotalPedidosSemana FROM v_Pedidos_Semana_Empleado WHERE IDEmpleado = @idEmpleado";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idEmpleado", IDEmpleado);

                try
                {
                    conn.Open();
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != DBNull.Value)
                    {
                        lblTotalPedidosSem.Text = $"{resultado}";
                    }
                    else
                    {
                        lblTotalPedidosSem.Text = "00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los pedidos semanal: {ex.Message}");
                }
            }
        }

        //Muestra el total de pedidos realizados por el empleado 
        private void CargarPedidosTotales()
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = @"
                SELECT Cantidad_Pedidos
                FROM v_Total_PedidosxEmpleado WHERE IDEmpleado = @idEmpleado";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idEmpleado", IDEmpleado);

                try
                {
                    conn.Open();
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != DBNull.Value)
                    {
                        lblTotalPedidas.Text = $"{resultado}";
                    }
                    else
                    {
                        lblTotalPedidas.Text = "00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los pedidos semanal: {ex.Message}");
                }
            }
        }

        //Permite al empleado cerrar sessión
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



    }
}

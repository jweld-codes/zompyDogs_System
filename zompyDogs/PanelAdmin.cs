using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ZompyDogsDAO;
using static ZompyDogsDAO.PeticionesValidaciones;
using System.Windows.Forms.VisualStyles;

namespace zompyDogs
{
    public partial class PanelAdmin : Form
    {
        public static readonly string con_string = "Data Source=MACARENA\\SQLEXPRESS;Initial Catalog=DB_ZompyDogs;Integrated Security=True;Encrypt=False";
        public static SqlConnection conn = new SqlConnection(con_string);

        public BienvenidaAdmin FormPrincipal { get; set; }
        private int indiceActual = 0;

        public int IDEmpleado { get; set; }
        public string NombreUsuario { get => lblNombreUsuario_Panel.Text; set => lblNombreUsuario_Panel.Text = value; }

        public PanelAdmin()
        {
            FormPrincipal = new BienvenidaAdmin();
            InitializeComponent();
            lblNombreUsuario_Panel.Text = $"{NombreUsuario}";

            CargarGananciaSemanal();
            CargarPedidosSemanal();
            CargarPedidosRecientes();
            CargarPeticionesEnDataGrid();

            // CargarGastoSemanal();
        }
        public void InicializarAdmin()
        {
            BienvenidaAdmin frmBienvenidaForm = new BienvenidaAdmin();
            string userLabel = frmBienvenidaForm.lblNombreSideBar.Text;
        }
        private void btnLogOutPanel_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("¿Está seguro de cerrar sessión?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Login frmLogin = new Login();
                frmLogin.Show();
            }
        }
        private void CargarGananciaSemanal()
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = @"
                SELECT SUM(TotalGanancias) AS GananciaSemanal
                FROM v_gananciastotales
                WHERE Año = YEAR(GETDATE()) AND Semana = DATEPART(WEEK, GETDATE());";

                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != DBNull.Value)
                    {
                        lblGananciaSemanal.Text = $"{Convert.ToDecimal(resultado):C}";
                    }
                    else
                    {
                        lblGananciaSemanal.Text = "L. 0.00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la ganancia semanal: {ex.Message}");
                }
            }


        }
        /*  private void CargarGastoSemanal()
          {
              using (SqlConnection conn = new SqlConnection(con_string))
              {
                  string query = @"
                  SELECT SUM(TotalGastoSemanal) AS GastoSemanal
                  FROM v_gastossemanales
                  WHERE Año = YEAR(GETDATE()) AND Semana = DATEPART(WEEK, GETDATE());";

                  SqlCommand cmd = new SqlCommand(query, conn);

                  try
                  {
                      conn.Open();
                      object resultado = cmd.ExecuteScalar();

                      if (resultado != DBNull.Value)
                      {
                          lblPerdidas.Text = $"{Convert.ToDecimal(resultado):C}"; 
                      }
                      else
                      {
                          lblPerdidas.Text = "L. 0.00";
                      }
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show($"Error al cargar el gasto semanal: {ex.Message}");
                  }
              }
          }*/
        private void CargarPedidosSemanal()
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = @"
                SELECT SUM(TotalPedidos) AS PedidosSemanal
                FROM v_PedidosTotalesSemanal
                WHERE Año = YEAR(GETDATE()) AND Semana = DATEPART(WEEK, GETDATE());";

                SqlCommand cmd = new SqlCommand(query, conn);

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
                    MessageBox.Show($"Error al cargar el gasto semanal: {ex.Message}");
                }
            }
        }

        private void CargarPedidosRecientes()
        {
            DataTable pedidos = PedidosDAO.ObtenerPedidosRecientes();
            dgvPedidosPanel.DataSource = pedidos;
            dgvPedidosPanel.Columns["Codigo_Pedido"].HeaderText = "Codigo del Pedido";
            dgvPedidosPanel.Columns["Total_a_Pagar"].HeaderText = "Total";
        }

        public void CargarPeticionesEnDataGrid()
        {
            dgvPeticionesPendientes.DataSource = PeticionesValidaciones.ObtenerPeticionesParaPanel();
            dgvPeticionesPendientes.Columns["Fecha_De_Envio"].HeaderText = "Fecha de Envío";

        }
    }
}

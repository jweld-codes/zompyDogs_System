﻿using System;
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
using static ZompyDogsDAO.PeticionesDAO;
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

        }
        public void InicializarAdmin()
        {
            BienvenidaAdmin frmBienvenidaForm = new BienvenidaAdmin();
            string userLabel = frmBienvenidaForm.lblNombreSideBar.Text;
        }

        //Permite al usuario cerrar sessión
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
        
        // Muestra las ganancias semanal
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
        
        // Carga los datos del total de los pedidos semanal
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

        // Muuestra los pedidos recientes.
        private void CargarPedidosRecientes()
        {
            DataTable pedidos = PedidosDAO.ObtenerPedidosRecientes();
            dgvPedidosPanel.DataSource = pedidos;
            dgvPedidosPanel.Columns["Codigo_Pedido"].HeaderText = "Código del Pedido";
            dgvPedidosPanel.Columns["Total_a_Pagar"].HeaderText = "Total";
        }

        //Muestra las Peticiones Recientes
        public void CargarPeticionesEnDataGrid()
        {
            dgvPeticionesPendientes.DataSource = PeticionesDAO.ObtenerPeticionesParaPanel();

            dgvPeticionesPendientes.Columns["Peticion"].HeaderText = "Petición";
            dgvPeticionesPendientes.Columns["Fecha_De_Envio"].HeaderText = "Fecha de Envío";

        }
    }
}

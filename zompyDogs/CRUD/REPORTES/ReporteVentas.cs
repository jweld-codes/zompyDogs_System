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
using ClosedXML.Excel;
using System.IO;

namespace zompyDogs.CRUD.REPORTES
{
    public partial class ReporteVentas : Form
    {
        public static readonly string con_string = "Data Source=MACARENA\\SQLEXPRESS;Initial Catalog=DB_ZompyDogs;Integrated Security=True;Encrypt=False";
        public static SqlConnection conn = new SqlConnection(con_string);

        public ReporteVentas()
        {
            InitializeComponent();
            CargarTotalPedidosDiarios();
            CargarTotalPedidosAnual();
            CargarTotalPedidosMensual();
            CargarEmpleadoConMayorVentas();
            CargarPlatillosMasVendidos();
        }

        private void CargarTotalPedidosDiarios()
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = @"
                SELECT TotalPedidos, CantidadPedidos
                FROM v_TotalPedidosDiarios
                WHERE Fecha = CAST(GETDATE() AS DATE);";

                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblVentaD.Text = $"{Convert.ToInt32(reader["CantidadPedidos"]):N0}";
                        lblVentaDiarios.Text = $"{Convert.ToDecimal(reader["TotalPedidos"]):C}";
                    }
                    else
                    {
                        lblVentaD.Text = "00";
                        lblVentaDiarios.Text = "L. 0.00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarTotalPedidosMensual()
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = @"
                SELECT TotalPedidosMensual, CantidadPedidos
                FROM v_TotalPedidosMensuales
                WHERE Anio = YEAR(GETDATE()) AND Mes = MONTH(GETDATE()); ";

                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblVentaM.Text = $"{Convert.ToInt32(reader["CantidadPedidos"]):N0}";
                        lblVentaMensual.Text = $"{Convert.ToDecimal(reader["TotalPedidosMensual"]):C}";
                    }
                    else
                    {
                        lblVentaM.Text = "00";
                        lblVentaMensual.Text = "L. 0.00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarTotalPedidosAnual()
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = @"
                SELECT TotalPedidosAnual, CantidadPedidos
                FROM v_TotalPedidosAnuales
                WHERE Anio = YEAR(GETDATE());";

                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblVentaA.Text = $"{Convert.ToInt32(reader["CantidadPedidos"]):N0}";
                        lblVentaAnual.Text = $"{Convert.ToDecimal(reader["TotalPedidosAnual"]):C}";
                    }
                    else
                    {
                        lblVentaA.Text = "00";
                        lblVentaAnual.Text = "L. 0.00";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarEmpleadoConMayorVentas()
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = @"
                SELECT Nombre_Completo, TotalPedidos
                FROM v_EmpleadoMayorPedidos;";

                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblNombreUser.Text = reader["Nombre_Completo"].ToString();
                        lblTotalPedidoUser.Text = $"{Convert.ToDecimal(reader["TotalPedidos"]):N0}";
                    }
                    else
                    {
                        lblNombreUser.Text = "--";
                        lblTotalPedidoUser.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el empleado con más ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarPlatillosMasVendidos()
        {
            flpPlatillos.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = @"
                SELECT TOP 5
                    IDPlatillo,
                    Platillo,
                    CantidadVendida
                FROM v_PlatillosMasVendidos;";

                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Panel platilloPanel = new Panel
                        {
                            Size = new Size(250, 49),
                            BorderStyle = BorderStyle.FixedSingle,
                            Margin = new Padding(5)
                        };

                        Label lblPlatillo = new Label
                        {
                            Text = reader["Platillo"].ToString(),
                            AutoSize = true,
                            Font = new Font("Arial", 8, FontStyle.Bold),
                            Dock = DockStyle.Top
                        };

                        Label lblCantidadVendida = new Label
                        {
                            Text = $" x{reader["CantidadVendida"]}",
                            Font = new Font("Arial", 8, FontStyle.Regular),
                            AutoSize = true,
                            Dock = DockStyle.Bottom
                        };

                        platilloPanel.Controls.Add(lblPlatillo);
                        platilloPanel.Controls.Add(lblCantidadVendida);

                        flpPlatillos.Controls.Add(platilloPanel);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los platillos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ExportarReporteCompleto()
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Reporte Ventas");

            // 1. **Totales Diarios**
            ws.Cell(1, 1).Value = "Ventas Diarias";
            ws.Cell(2, 1).Value = "Total de Pedidos";
            ws.Cell(2, 2).Value = lblVentaDiarios.Text; 
            ws.Cell(3, 1).Value = "Cantidad de Pedidos";
            ws.Cell(3, 2).Value = lblVentaD.Text;       

            ws.Cell(5, 1).Value = "-------------------------------";

            // 2. **Totales Mensuales**
            ws.Cell(6, 1).Value = "Ventas Mensuales";
            ws.Cell(7, 1).Value = "Total de Pedidos";
            ws.Cell(7, 2).Value = lblVentaMensual.Text;  
            ws.Cell(8, 1).Value = "Cantidad de Pedidos";
            ws.Cell(8, 2).Value = lblVentaM.Text;      

            ws.Cell(10, 1).Value = "-------------------------------";

            // 3. **Totales Anuales**
            ws.Cell(11, 1).Value = "Ventas Anuales";
            ws.Cell(12, 1).Value = "Total de Pedidos";
            ws.Cell(12, 2).Value = lblVentaAnual.Text;  
            ws.Cell(13, 1).Value = "Cantidad de Pedidos";
            ws.Cell(13, 2).Value = lblVentaA.Text;     

            ws.Cell(15, 1).Value = "-------------------------------";

            // 4. **Empleado con Mayor Número de Ventas**
            ws.Cell(16, 1).Value = "Empleado con Mayor Número de Ventas";
            ws.Cell(17, 1).Value = "Nombre Completo";
            ws.Cell(17, 2).Value = lblNombreUser.Text; 
            ws.Cell(18, 1).Value = "Total de Ventas";
            ws.Cell(18, 2).Value = lblTotalPedidoUser.Text;

            ws.Cell(20, 1).Value = "-------------------------------";

            // 5. **Platillos Más Vendidos**
            ws.Cell(21, 1).Value = "Platillos Más Vendidos";

            ws.Cell(22, 1).Value = "ID Del Platillo";
            ws.Cell(22, 2).Value = "Platillo";
            ws.Cell(22, 3).Value = "Cantidad Vendida";

            // Consulta para obtener los 5 platillos más vendidos
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = @"
                SELECT TOP 5
                    IDPlatillo,
                    Platillo,
                    CantidadVendida
                FROM v_PlatillosMasVendidos;";

                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int row = 23;  // Comienza en la fila 23 para los platillos

                    while (reader.Read())
                    {
                        ws.Cell(row, 1).Value = Convert.ToInt32(reader["IDPlatillo"]);  // Asegurarse que sea un entero
                        ws.Cell(row, 2).Value = reader["Platillo"].ToString();           // Convertir a String
                        ws.Cell(row, 3).Value = Convert.ToInt32(reader["CantidadVendida"]); // Asegurarse que sea un entero

                        row++;
                    }

                    // Ajustar columnas a su contenido
                    ws.Columns().AdjustToContents();

                    // Guardar el archivo Excel
                    string filePath = @"C:\Users\jenni\Documents\GitHub\zompyDogs\zompyDogs\CRUD\REPORTES\ReportesExcel\ReporteCompleto.xlsx"; // Cambia esta ruta si es necesario
                    wb.SaveAs(filePath);

                    MessageBox.Show("Exportación a Excel completada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ReporteVentas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportarReporteCompleto();
        }
    }
}

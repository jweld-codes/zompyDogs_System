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

        public string AdminId { get; set; }
        public ReporteVentas(string adminName)
        {

            InitializeComponent();

            lblNombreAdmin.Text = adminName;

            lblNombreAdmin.Hide();
            dtpFechaReporte.Hide();

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
            var ws = wb.Worksheets.Add("Reporte de Ventas y Ganancias");

            var ws2 = wb.Worksheets.Add("Platillos Más Vendidos");

            wb.SaveAs("ReporteCompleto.xlsx");


            //    Filas, Col
            ws.Cell(3, 5).Value = "REPORTES DE VENTAS";
            ws.Cell(3, 5).Style.Font.Bold = true;
            ws.Range("E3:M3").Merge();
            ws.Range("E3:M3").Style.Fill.BackgroundColor = XLColor.LightGray;
            ws.Cell(3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell(3, 5).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            ws.Range("E3:M3").Style.Border.TopBorder = XLBorderStyleValues.Thin;  // Borde superior
            ws.Range("E3:M3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;  // Borde inferior
            ws.Range("E3:M3").Style.Border.RightBorder = XLBorderStyleValues.Thin;  // Borde izquierdo

            ws.Range("B3:D3").Merge();
            ws.Range("B3:D3").Style.Fill.BackgroundColor = XLColor.LightGray;
            ws.Range("B3:D3").Style.Border.TopBorder = XLBorderStyleValues.Thin;  // Borde superior
            ws.Range("B3:D3").Style.Border.BottomBorder = XLBorderStyleValues.Thin;  // Borde inferior
            ws.Range("B3:D3").Style.Border.LeftBorder = XLBorderStyleValues.Thin;  // Borde derecho

            ws.Range("B4:D4").Merge();
            ws.Range("B4:D4").Style.Border.RightBorder = XLBorderStyleValues.Thin;  
            ws.Range("B4:D4").Style.Border.LeftBorder = XLBorderStyleValues.Thin;  

            ws.Range("B5:D5").Merge();
            ws.Range("B5:D5").Style.Border.RightBorder = XLBorderStyleValues.Thin;  
            ws.Range("B5:D5").Style.Border.LeftBorder = XLBorderStyleValues.Thin;  

            ws.Range("B6:D6").Merge();
            ws.Range("B6:D6").Style.Border.RightBorder = XLBorderStyleValues.Thin;  
            ws.Range("B6:D6").Style.Border.LeftBorder = XLBorderStyleValues.Thin;  
            ws.Range("B6:D6").Style.Border.BottomBorder = XLBorderStyleValues.Thin;

            ws.Cell(7, 2).Value = "GANANCIAS DE PEDIDOS";
            ws.Cell(7, 2).Style.Font.Bold = true;
            ws.Cell(7, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Range("B7:D7").Merge();
            ws.Range("B7:D7").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("B7:D7").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Range("B7:D7").Style.Border.BottomBorder = XLBorderStyleValues.Thin;

            ws.Cell(8, 2).Value = "CANTIDAD DE PEDIDOS";
            ws.Cell(8, 2).Style.Font.Bold = true;
            ws.Cell(8, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Range("B8:D8").Merge();
            ws.Range("B8:D8").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("B8:D8").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Range("B8:D8").Style.Border.BottomBorder = XLBorderStyleValues.Thin;

            ws.Range("B9:D9").Merge();
            ws.Range("B9:D9").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.Range("B9:D9").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Range("B9:D9").Style.Fill.BackgroundColor = XLColor.LightGray;

            ws.Range("E9:M9").Merge();
            ws.Range("E9:M9").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("E9:M9").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("E9:M9").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Range("E9:M9").Style.Fill.BackgroundColor = XLColor.LightGray;

            ws.Range("E5:M5").Style.Border.TopBorder = XLBorderStyleValues.Thin; 
            ws.Range("E5:M5").Style.Border.BottomBorder = XLBorderStyleValues.Thin;

            ws.Cell(4, 5).Value = "FECHA DEL REPORTE:";
            ws.Cell(4, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Range("E4:G4").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("E4:G4").Merge();
            ws.Cell(4, 5).Style.Font.Bold = true;

            ws.Range("H4:J4").Merge();
            ws.Cell(4, 8).Value = dtpFechaReporte.Value.ToString("dd/MM/yyyy");
            ws.Cell(4, 7).Style.Font.Bold = true;

            ws.Cell(5, 7).Value = lblNombreUser.Text;
            ws.Range("H5:I5").Merge();
            ws.Cell(5, 7).Style.Font.Bold = true;

            ws.Range("L4:M4").Merge();
            ws.Range("L4:M4").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Range("L5:M5").Merge();
            ws.Range("L5:M5").Style.Border.RightBorder = XLBorderStyleValues.Thin;


            ws.Cell(5, 5).Value = "ADMINISTRADOR";
            ws.Cell(5, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Range("E5:G5").Merge();
            ws.Range("E5:G5").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell(5, 5).Style.Font.Bold = true;

            ws.Cell(5, 8).Value = lblNombreAdmin.Text;
            ws.Cell(5, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            ws.Cell(5, 8).Style.Font.Bold = true;

            ws.Cell(6, 5).Value = "VENTAS DIARIAS";
            ws.Range("E6:G6").Merge();
            ws.Cell(6, 5).Style.Font.Bold = true;
            ws.Range("E6:G6").Style.Fill.BackgroundColor = XLColor.LightGray;
            ws.Cell(6, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Range("E6:G6").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("E6:G6").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Range("E6:G6").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell(7, 5).Value = lblVentaDiarios.Text;
            ws.Range("E7:G7").Merge();
            ws.Range("E7:G7").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell(7, 5).Style.Font.Bold = true;
            ws.Cell(7, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell(8, 5).Value = lblVentaD.Text;
            ws.Range("E8:G8").Merge();
            ws.Range("E8:G8").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("E8:G8").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell(8, 5).Style.Font.Bold = true;
            ws.Cell(8, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


            ws.Cell(6, 8).Value = "VENTAS MENSUALES";
            ws.Range("H6:J6").Merge();
            ws.Cell(6, 8).Style.Font.Bold = true;
            ws.Range("H6:J6").Style.Fill.BackgroundColor = XLColor.LightGray;
            ws.Cell(6, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Range("H6:J6").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("H6:J6").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Range("H6:J6").Style.Border.RightBorder = XLBorderStyleValues.Thin;

            ws.Cell(7, 8).Value = lblVentaMensual.Text;
            ws.Range("H7:J7").Merge();
            ws.Range("H8:J8").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("H8:J8").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell(7, 8).Style.Font.Bold = true;
            ws.Cell(7, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell(8, 8).Value = lblVentaM.Text;
            ws.Range("H8:J8").Merge();
            ws.Range("H8:J8").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("H8:J8").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell(8, 8).Style.Font.Bold = true;
            ws.Cell(8, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            
            ws.Cell(6, 11).Value = "VENTAS ANUALES";
            ws.Range("K6:M6").Merge();
            ws.Cell(6, 11).Style.Font.Bold = true;
            ws.Range("K6:M6").Style.Fill.BackgroundColor = XLColor.LightGray;
            ws.Cell(6, 11).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Range("K6:M6").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("K6:M6").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Range("K6:M6").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Range("K6:M6").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

            ws.Cell(7, 11).Value = lblVentaAnual.Text;
            ws.Range("K7:M7").Merge();
            ws.Range("K7:M7").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("K7:M7").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell(7, 11).Style.Font.Bold = true;
            ws.Cell(7, 11).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell(8, 11).Value = lblVentaA.Text;
            ws.Range("K8:M8").Merge();
            ws.Range("K8:M8").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.Range("K8:M8").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell(8, 11).Style.Font.Bold = true;
            ws.Cell(8, 11).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws2.Cell(4, 2).Value = "5 PLATILLOS MÁS VENDIDOS";
            ws2.Range("B4:F4").Merge();
            ws2.Range("B4:F4").Style.Fill.BackgroundColor = XLColor.LightGray;
            ws2.Range("B4:F4").Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws2.Range("B4:F4").Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws2.Range("B4:F4").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws2.Range("B4:F4").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws2.Cell(4, 2).Style.Font.Bold = true;
            ws2.Cell(4, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws2.Cell(5, 2).Value = "ID del Platillo";
            ws2.Cell(5, 2).Style.Fill.BackgroundColor = XLColor.LightGray;
            ws2.Cell(5, 2).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws2.Cell(5, 2).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws2.Cell(5, 2).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws2.Cell(5, 2).Style.Font.Bold = true;
            ws2.Cell(5, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws2.Cell(5, 3).Value = "Nombre del Platillo";
            ws2.Range("C5:D5").Merge();
            ws2.Range("C5:D5").Style.Fill.BackgroundColor = XLColor.LightGray;
            ws2.Cell(5, 3).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws2.Cell(5, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws2.Cell(5, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws2.Cell(5, 3).Style.Font.Bold = true;
            ws2.Cell(5, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws2.Cell(5, 5).Value = "Veces vendidas";
            ws2.Range("E5:F5").Merge();
            ws2.Range("E5:F5").Style.Fill.BackgroundColor = XLColor.LightGray;
            ws2.Cell(5, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws2.Cell(5, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws2.Cell(5, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws2.Cell(5, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws2.Cell(5, 5).Style.Font.Bold = true;
            ws2.Cell(5, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

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
                    int row = 6;

                    while (reader.Read())
                    {
                        ws2.Cell(row, 2).Value = Convert.ToInt32(reader["IDPlatillo"]);
                        ws2.Cell(row, 4).Value = reader["Platillo"].ToString();
                        ws2.Cell(row, 6).Value = Convert.ToInt32(reader["CantidadVendida"]);

                        // Aplicar bordes a cada celda
                        ws2.Range($"B{row}:F{row}").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        ws2.Range($"D{row}:E{row}").Merge();

                        row++;
                    }

                    // Ajustar columnas en ambas hojas
                    ws.Columns().AdjustToContents();
                    ws2.Columns().AdjustToContents();

                    // Mostrar el cuadro de diálogo para que el usuario elija dónde guardar el archivo
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"; // Filtro para archivos .xlsx
                        saveFileDialog.Title = "Guardar Reporte Excel"; // Título del cuadro de diálogo

                        // Mostrar el cuadro de diálogo y verificar si el usuario ha seleccionado un archivo
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Guardar el archivo en la ruta seleccionada por el usuario
                            string filePath = saveFileDialog.FileName;

                            // Ajustar columnas a su contenido
                            ws.Columns().AdjustToContents();

                            // Guardar el archivo Excel en la ubicación seleccionada
                            wb.SaveAs(filePath);

                            MessageBox.Show("Exportación a Excel completada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
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

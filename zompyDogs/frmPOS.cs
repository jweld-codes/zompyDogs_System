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
using zompyDogs.CRUD.REGISTROS;
using ZompyDogsDAO;
using ZompyDogsLib.Controladores;

namespace zompyDogs
{
    public partial class frmPOS : Form
    {

        public static readonly string con_string = "Data Source=MACARENA\\SQLEXPRESS;Initial Catalog=DB_ZompyDogs;Integrated Security=True;Encrypt=False";
        public static SqlConnection conn = new SqlConnection(con_string);

        public BienvenidaAdmin FormPrincipal { get; set; }
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }

        private PedidosDAO _pedidosDAO;
        public BindingSource _bndsrcPedido;
        private ControladorGeneradoresDeCodigo _controladorGeneradorCodigoPedido;

        private string nuevoCodigoPedido;
        private int usuarioIDActual;
        private int rolIDActual;

        public string pedidoPlatilo;
        public string pedidoCodigo;
        public int pedidoCantidad;
        public decimal pedidoPrecioUnitario;

        public decimal subtotalPago;
        public decimal totalaPago;
        public int cantidadPedido;
        public int cantidadPlatillo = 1;
        public int menuID;

        public frmPOS(int usuarioIDActual, int rolIDActual)
        {
            InitializeComponent();
            this.usuarioIDActual = usuarioIDActual;
            this.rolIDActual = rolIDActual;
           // MessageBox.Show("idEmpleado: " + usuarioIDActual + "RolIdActual: " + rolIDActual);
            
            if (rolIDActual > 1)
            {
                btnHistorial.Enabled = false;
                btnHistorial.Visible = false;
                btnHistorial.Hide();
            }

            CargarMenu("Entrada");
            AddCategoria();

            _controladorGeneradorCodigoPedido = new ControladorGeneradoresDeCodigo();
            GeneradordeCodigoPedidoFromForm();

            _pedidosDAO = new PedidosDAO();

            _bndsrcPedido = new BindingSource();

            _bndsrcPedido.DataSource = _pedidosDAO.platillosLista;
            dgvPedido.DataSource = _bndsrcPedido;

            txtPlatilloOrden.Enabled = false;

            _bndsrcPedido.DataSource = _pedidosDAO.platillosLista;
            dgvPedido.DataSource = _bndsrcPedido;

            dgvPedido.Columns["PlatilloNombre"].HeaderText = "Platillo";
            dgvPedido.Columns["PlatilloNombre"].DataPropertyName = "PlatilloNombre";

            dgvPedido.Columns["Precio_Unitario"].HeaderText = "Precio";
            dgvPedido.Columns["Precio_Unitario"].DataPropertyName = "Precio_Unitario";

            dgvPedido.Columns["Subtotal"].Visible = false;
            dgvPedido.Columns["Categoria"].Visible = false;
            dgvPedido.Columns["id_Menu"].Visible = false;
            dgvPedido.Columns["id_pedido"].Visible = false;
            dgvPedido.Columns["Descripcion"].Visible = false;
            dgvPedido.Columns["ImagenPlatillo"].Visible = false;
        }
        private void GeneradordeCodigoPedidoFromForm()
        {
            nuevoCodigoPedido = _controladorGeneradorCodigoPedido.GeneradordeCodigoPedidos();
            txtCodigoGenerado.Text = nuevoCodigoPedido;
        }
        private void CambiarColorBoton(Button botonActivo)
        {
            foreach (Control ctrl in topBarMenu.Controls)
            {
                if (ctrl is Button)
                {
                    Button boton = (Button)ctrl;
                    boton.BackColor = Color.Transparent;
                    boton.ForeColor = Color.White;
                }
            }

            botonActivo.BackColor = Color.White;
            botonActivo.ForeColor = Color.Black;
        }

        private void AddCategoria()
        {
            string qry = "SELECT * FROM Categoria";
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            try
            {
                conn.Open();
                da.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las categorías: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            categoryPanel.Controls.Clear();
            categoryPanel.AutoScroll = true;

            int buttonHeight = 80;
            int buttonWidth = 150;
            int yOffset = -2;

            foreach (DataRow row in dataTable.Rows)
            {
                Button btnCategory = new Button();
                btnCategory.Cursor = Cursors.Hand;
                btnCategory.BackColor = Color.Green;
                btnCategory.ForeColor = Color.White;
                btnCategory.Size = new Size(buttonWidth, buttonHeight);
                btnCategory.Text = row["Categoria"].ToString();

                btnCategory.Location = new Point(-2, categoryPanel.Controls.Count * (buttonHeight + yOffset));

                btnCategory.Click += (sender, e) =>
                {
                    CargarMenu(btnCategory.Text);
                };

                categoryPanel.Controls.Add(btnCategory);
            }
        }

        private void CargarMenu(string categoria)
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = "SELECT ID_Menu, Codigo, Platillo, Descripcion, Precio, Imagen FROM v_DetallesMenu WHERE Categoria = @Categoria";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Categoria", categoria);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                flpPOSPanel.Controls.Clear();
                bool hasResults = false;

                while (reader.Read())
                {
                    hasResults = true;

                    // Crear panel contenedor para cada platillo
                    Panel panelPlatillo = new Panel();
                    panelPlatillo.BorderStyle = BorderStyle.FixedSingle;

                    Panel panelNombrePlatillo = new Panel();
                    panelNombrePlatillo.Size = new Size(204, 51);
                    panelNombrePlatillo.Dock = DockStyle.Top;

                    Panel panelPrecio = new Panel();
                    panelPrecio.Size = new Size(339, 215);
                    panelPrecio.Dock = DockStyle.Bottom;

                    PictureBox pbxPlatillo = new PictureBox();
                    pbxPlatillo.Size = new Size(155, 154);
                    pbxPlatillo.Location = new Point(30, 10);
                    pbxPlatillo.SizeMode = PictureBoxSizeMode.Zoom;
                    if (reader["Imagen"] != DBNull.Value)
                    {
                        string imageFileName = reader["Imagen"].ToString();
                        string projectPath = "C:\\Users\\jenni\\Documents\\GitHub\\zompyDogs\\zompyDogs\\Imagenes";
                        string imagePath = Path.Combine(projectPath, "Platillos", imageFileName);

                        if (File.Exists(imagePath))
                        {
                            pbxPlatillo.Image = Image.FromFile(imagePath);
                        }
                        else
                        {
                            MessageBox.Show($"La imagen no se encontró en la ruta: {imagePath}");
                        }
                    }

                    Label lblPlatillo = new Label();
                    lblPlatillo.Text = reader["Platillo"].ToString();
                    lblPlatillo.Location = new Point(3, 14);
                    lblPlatillo.AutoSize = true;
                    lblPlatillo.Font = new Font("Arial", 12, FontStyle.Bold);

                    Label lblCodigoPlatillo = new Label();
                    lblCodigoPlatillo.Text = reader["Codigo"].ToString();
                    lblCodigoPlatillo.Location = new Point(8, 8);
                    lblCodigoPlatillo.AutoSize = true;
                    lblCodigoPlatillo.Font = new Font("Arial", 4, FontStyle.Regular);

                    Label lblId_Menu = new Label();
                    lblId_Menu.Text = reader["ID_Menu"].ToString();
                    lblId_Menu.Hide();

                    Label lblPrecio = new Label();
                    lblPrecio.Text = $"L.{reader["Precio"].ToString()}";
                    lblPrecio.Location = new Point(20, 5);
                    lblPrecio.AutoSize = true;
                    lblPrecio.Font = new Font("Arial", 10, FontStyle.Bold);

                    TextBox txtDescripcion = new TextBox();
                    if (reader["Descripcion"] != DBNull.Value)
                    {
                        txtDescripcion.Text = reader["Descripcion"].ToString();
                        txtDescripcion.Size = new Size(196, 92);
                        txtDescripcion.Location = new Point(8, 28);
                        txtDescripcion.Multiline = true;
                        txtDescripcion.ReadOnly = true;
                        txtDescripcion.ScrollBars = ScrollBars.Vertical;
                    }
                    else
                    {
                        txtDescripcion.Hide();
                        txtDescripcion.Size = new Size(0, 3);
                    }

                    Button btnAgregarPlatillo = new Button();
                    btnAgregarPlatillo.Text = "Agregar";
                    btnAgregarPlatillo.Location = new Point(4, 128);
                    btnAgregarPlatillo.AutoSize = true;
                    btnAgregarPlatillo.Size = new Size(176, 42);
                    btnAgregarPlatillo.BackColor = Color.ForestGreen;
                    btnAgregarPlatillo.ForeColor = Color.White;

                    btnAgregarPlatillo.Click += (sender, e) =>
                    {
                        ZompyDogsDAO.PedidosDAO.DetalleDePedido nuevoPlatillo = new ZompyDogsDAO.PedidosDAO.DetalleDePedido
                        {
                            PlatilloNombre = lblPlatillo.Text,
                            Precio_Unitario = decimal.Parse(lblPrecio.Text.Replace("L.", "").Trim()),
                            Cantidad = cantidadPlatillo,
                        };
                        cantidadPedido++;

                        _pedidosDAO.platillosLista.Add(nuevoPlatillo);
                        menuID = Convert.ToInt32(lblId_Menu.Text);
                        pedidoPrecioUnitario = decimal.Parse(lblPrecio.Text.Replace("L.", "").Trim());

                        _bndsrcPedido.ResetBindings(false);
                        CalcularTotal();

                    };

                    panelPlatillo.Controls.Add(panelNombrePlatillo);
                    panelPlatillo.Controls.Add(panelPrecio);
                    panelPlatillo.Controls.Add(pbxPlatillo);

                    panelNombrePlatillo.Controls.Add(lblPlatillo);

                    panelPrecio.Controls.Add(lblPrecio);
                    panelPrecio.Controls.Add(txtDescripcion);
                    panelPrecio.Controls.Add(btnAgregarPlatillo);

                    int totalHeight = panelNombrePlatillo.Height + panelPrecio.Height + pbxPlatillo.Height;
                    int maxWidth = Math.Max(panelNombrePlatillo.Width, Math.Max(panelPrecio.Width, pbxPlatillo.Width));

                    panelPlatillo.Size = new Size(maxWidth, totalHeight);

                    // Agregar el panel al FlowLayoutPanel
                    flpPOSPanel.Controls.Add(panelPlatillo);
                }

                if (!hasResults)
                {
                    Label lblFLP = new Label();
                    lblFLP.Text = "No se encontraron platillos en esta categoría.";
                    lblFLP.Location = new Point(20, 5);
                    lblFLP.AutoSize = true;
                    lblFLP.Font = new Font("Arial", 14, FontStyle.Bold);
                    flpPOSPanel.Controls.Add(lblFLP);
                }

                reader.Close();
            }
        }
        private void dgvPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvPedido.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                pedidoPlatilo = filaSeleccionada.Cells["PlatilloNombre"].Value.ToString();
                pedidoCantidad = Convert.ToInt32(filaSeleccionada.Cells["Cantidad"].Value);
                pedidoPrecioUnitario = Convert.ToInt32(filaSeleccionada.Cells["Precio_Unitario"].Value);

                txtPlatilloOrden.Text = pedidoPlatilo;
            }
        }
        private void btnEliminarOrden_Click(object sender, EventArgs e)
        {
            if (dgvPedido.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvPedido.SelectedRows[0];

                string namePlatillo = filaSeleccionada.Cells["PlatilloNombre"].Value.ToString();

                var platilloAEliminar = _pedidosDAO.platillosLista.FirstOrDefault(p => p.PlatilloNombre == namePlatillo);

                if (platilloAEliminar != null)
                {
                    _pedidosDAO.platillosLista.Remove(platilloAEliminar);
                    cantidadPedido--;
                    _bndsrcPedido.ResetBindings(false);

                    MessageBox.Show("Platillo eliminado de la orden. Cantidad Reducida: " + cantidadPedido);
                    CalcularTotal();
                }
                else
                {
                    MessageBox.Show("No se encontró el platillo en la lista.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un platillo para eliminar.");
            }
        }
        private void CalcularTotal()
        {
            subtotalPago = 0; // Reiniciar el subtotal en cada cálculo
            foreach (var pedido in _pedidosDAO.platillosLista)
            {
                decimal precio = pedido.Precio_Unitario;
                int cantidad = pedido.Cantidad;

                subtotalPago += precio * cantidad;
            }

            decimal isv = subtotalPago * 0.15m;
            totalaPago = subtotalPago + isv;

            lblTotalAPagar.Text = $"{totalaPago}";
            lblSubtotal.Text = $"{subtotalPago}";
        }

        private void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            GuardarPedido();
        }

        private void GuardarPedido()
        {
            string codigoPedido = txtCodigoGenerado.Text;
            decimal totalPago = subtotalPago;

            try
            {
                using (SqlConnection conn = new SqlConnection(con_string))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    string queryPedido = @"INSERT INTO Pedido(codigoPedido, Fk_Usuario, FechaPedido, estado)
                                   VALUES (@CodigoPedido, @CodigoEmpleado, GETDATE(), 'COMPLETADO');
                                   SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdPedido = new SqlCommand(queryPedido, conn, transaction);
                    cmdPedido.Parameters.AddWithValue("@CodigoPedido", codigoPedido);
                    cmdPedido.Parameters.AddWithValue("@CodigoEmpleado", usuarioIDActual);

                    int pedidoID = Convert.ToInt32(cmdPedido.ExecuteScalar());

                    foreach (var platillo in _pedidosDAO.platillosLista)
                    {
                        string queryDetalle = @"INSERT INTO Detalle_Pedido(idPedido, Fk_Menu, Cantidad, precioUnitario, subtotal,total)
                                        VALUES (@CodigoPedido, @CodigoPlatillo, @Cantidad, @PrecioUnitario, @subTotal, @TotalAPagar)";

                        SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conn, transaction);
                        cmdDetalle.Parameters.AddWithValue("@CodigoPedido", pedidoID);
                        cmdDetalle.Parameters.AddWithValue("@CodigoPlatillo", menuID);
                        cmdDetalle.Parameters.AddWithValue("@Cantidad", cantidadPlatillo);
                        cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", pedidoPrecioUnitario);
                        cmdDetalle.Parameters.AddWithValue("@subTotal", subtotalPago);
                        cmdDetalle.Parameters.AddWithValue("@TotalAPagar", totalaPago);


                        cmdDetalle.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    VerFacturaFinalizada();
                    //MessageBox.Show($"Pedido: {codigoPedido} guardado exitosamente.");

                    CargarMenu("Entrada");
                    _pedidosDAO.platillosLista.Clear();
                    _bndsrcPedido.ResetBindings(false);
                    subtotalPago = 0;
                    lblSubtotal.Text = "0.00";
                    lblTotalAPagar.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar el pedido: " + ex.Message);
                Console.WriteLine("Ocurrió un error al guardar el pedido: " + ex.Message);
            }
        }

        private void VerFacturaFinalizada()
        {
            var facturaView = new FacturaView();

            // Deshabilitar todos los elementos del formulario
            foreach (Control control in facturaView.Controls)
            {
                control.Enabled = false;
            }
            facturaView.btnCancelar.Enabled = true;
            facturaView.dgvTotalPedido.Enabled = true;
            facturaView.btnCancelar.Text = "ACEPTAR";
            facturaView.btnCancelar.BackColor = Color.Blue;
            facturaView.Show();

            DataTable facturaDatosView = PedidosDAO.ObtenerDetalllesDeFacturaFinalizada(nuevoCodigoPedido);

            if (facturaDatosView.Rows.Count > 0)
            {
                DataRow fila = facturaDatosView.Rows[0];

                facturaView.txtCodigoGenerado.Text = fila["Codigo_Pedido"].ToString();
                facturaView.lblCodigoEmpleado.Text = fila["Codigo_Empleado"].ToString();
                facturaView.txtEmpleado.Text = fila["Empleado"].ToString();
                facturaView.dtpFechaRegistro.Text = fila["Fecha_Del_Pedido"].ToString();
                facturaView.lblTotal.Text = fila["Total_a_Pagar"].ToString();
                facturaView.lblSubtotal.Text = fila["Subtotal"].ToString();
                facturaView.lblISV.Text = fila["ISV"].ToString();
                facturaView.lblTotalProductos.Text = fila["Total_De_Productos"].ToString();
                facturaView.txtEstado.Text = fila["Estado"].ToString();

                DataTable detalleProductosTable = new DataTable();
                detalleProductosTable.Columns.Add("Platillo", typeof(string));
                detalleProductosTable.Columns.Add("Cantidad", typeof(int));
                detalleProductosTable.Columns.Add("Precio Unitario", typeof(decimal));

                foreach (var platillo in _pedidosDAO.platillosLista)
                {
                    detalleProductosTable.Rows.Add(
                        platillo.PlatilloNombre,
                        platillo.Cantidad,  
                        platillo.Precio_Unitario
                    );
                }
                facturaView.dgvTotalPedido.DataSource = detalleProductosTable;
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarMenu("Entrada");
            lblSubtotal.Text = "00";
            lblTotalAPagar.Text = "00";
            txtPlatilloOrden.Text = "";
            _pedidosDAO.platillosLista.Clear();
            _bndsrcPedido.ResetBindings(false);
        }
    }
}

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
using zompyDogs.CRUD.REPORTES;
using ZompyDogsDAO;
using ZompyDogsLib;
using ZompyDogsLib.Controladores;
using static ZompyDogsLib.Pedidos;

namespace zompyDogs
{
    /// <summary>
    /// Formulario principal para el módulo de Punto de Venta (POS) del sistema ZompyDogs.
    /// </summary>
    public partial class frmPOS : Form
    {

        public static readonly string con_string = "Data Source=MACARENA\\SQLEXPRESS;Initial Catalog=DB_ZompyDogs;Integrated Security=True;Encrypt=False";
        public static SqlConnection conn = new SqlConnection(con_string);

        /// Referencia al formulario principal de administración.
        public BienvenidaAdmin FormPrincipal { get; set; }

        /// Referencia al formulario principal de empleado.
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }

        /// Data Access Object (DAO) para manejar las operaciones relacionadas con pedidos.
        private PedidosDAO _pedidosDAO;
        /// Fuente de enlace para la lista de platillos en el DataGridView.
        public BindingSource _bndsrcPedido;
        /// Controlador para generar códigos de pedido únicos.
        private ControladorGeneradoresDeCodigo _controladorGeneradorCodigoPedido;

        // Código generado automáticamente para un nuevo pedido.
        private string nuevoCodigoPedido;

        private int usuarioIDActual;/// Identificador del usuario actualmente autenticado.
        private int rolIDActual; /// Identificador del rol del usuario actualmente autenticado

        // Variables relacionadas con los detalles del pedido
        public string pedidoPlatilo;
        public string codigoPedido;

        public int pedidoCantidad;
        public decimal pedidoPrecioUnitario;

        public string pedidoCodigoEmpleado;
        public string pedidoEmpleado;

        public decimal subtotalPago;
        public decimal totalaPago;
        public decimal pedidoISV;
        public int cantidadPedido;
        public int cantidadPlatillo = 1;
        public int menuID;
        public bool itsInvoice = false;
        public string pedidioInvoice;

        /// <summary>
        /// Constructor del formulario POS.
        /// Inicializa los componentes, carga los datos iniciales y configura el entorno del formulario.
        /// </summary>
        /// <param name="usuarioIDActual">ID del usuario autenticado.</param>
        /// <param name="rolIDActual">ID del rol del usuario autenticado.</param>
        public frmPOS(int usuarioIDActual, int rolIDActual)
        {
            InitializeComponent();
            this.usuarioIDActual = usuarioIDActual;
            this.rolIDActual = rolIDActual;

            // Inicialización de componentes y datos
            _controladorGeneradorCodigoPedido = new ControladorGeneradoresDeCodigo();

            CargarMenu("Almuerzos");
            GeneradorBotonesCategoria();

            GeneradordeCodigoPedidoFromForm();
            InicializarDataGridViewPlatillos();
            BuscarUsuarioAccedido();

            itsInvoice = false;
        }

        private void BuscarUsuarioAccedido()
        {
            // Llama al método ObtenerNombreUsuarioPorID para obtener el nombre y código del usuario basado en el ID
            var resultado = UsuarioDAO.ObtenerNombreUsuarioPorID(usuarioIDActual);
            pedidoEmpleado = resultado.nombreUsuario;
            pedidoCodigoEmpleado = resultado.codigoEmpleado;

            // Asigna el nombre del empleado a un Label o haz lo que necesites con la variable 'pedidoEmpleado'.
            lblEmpleadoNombre.Text = pedidoEmpleado;
        }

        /// <summary>
        /// Configura las propiedades iniciales del DataGridView para mostrar los platillos del pedido.
        /// </summary>
        private void InicializarDataGridViewPlatillos()
        {
            _pedidosDAO = new PedidosDAO();

            _bndsrcPedido = new BindingSource();

            _bndsrcPedido.DataSource = _pedidosDAO.platillosLista;
            dgvPedido.DataSource = _bndsrcPedido;

            txtPlatilloOrden.Enabled = false;

            _bndsrcPedido.DataSource = _pedidosDAO.platillosLista;
            dgvPedido.DataSource = _bndsrcPedido;

            // Configuración de columnas del DataGridView
            dgvPedido.Columns["PlatilloNombre"].HeaderText = "Platillo";
            dgvPedido.Columns["PlatilloNombre"].DataPropertyName = "PlatilloNombre";

            dgvPedido.Columns["Precio_Unitario"].HeaderText = "Precio";
            dgvPedido.Columns["Precio_Unitario"].DataPropertyName = "Precio_Unitario";

            // Ocultar columnas no relevantes
            dgvPedido.Columns["Subtotal"].Visible = false;
            dgvPedido.Columns["Categoria"].Visible = false;
            dgvPedido.Columns["id_Menu"].Visible = false;
            dgvPedido.Columns["id_pedido"].Visible = false;
            dgvPedido.Columns["Descripcion"].Visible = false;
            dgvPedido.Columns["ImagenPlatillo"].Visible = false;

        }

        /// <summary>
        /// Genera un nuevo código de pedido y lo asigna al campo correspondiente.
        /// </summary>
        private void GeneradordeCodigoPedidoFromForm()
        {
            nuevoCodigoPedido = _controladorGeneradorCodigoPedido.GeneradordeCodigoPedidos();
            txtCodigoGenerado.Text = nuevoCodigoPedido;
        }

        /// <summary>
        /// Cambia el color del botón activo en la barra superior del menú.
        /// </summary>
        /// <param name="botonActivo">Botón actualmente activo.</param>
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

        /// <summary>
        /// Genera dinámicamente los botones de categoría en el panel correspondiente.
        /// </summary>
        private void GeneradorBotonesCategoria()
        {
            PuntoDeVentaDAO puntoDeVentaDAO = new PuntoDeVentaDAO();
            DataTable dataTable;

            try
            {
                dataTable = puntoDeVentaDAO.ObtenerCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las categorías: " + ex.Message);
                return;
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

        /// <summary>
        /// Carga el menú de platillos según la categoría seleccionada.
        /// </summary>
        /// <param name="categoria">Nombre de la categoría.</param>
        private void CargarMenu(string categoria)
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = "SELECT ID_Menu, Codigo, Platillo, Descripcion, Precio, Imagen FROM v_DetallesMenu WHERE Categoria = @Categoria AND Estado = 'Activo'";

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
                        string basePath = AppDomain.CurrentDomain.BaseDirectory; // Obtiene el directorio base de la aplicación
                        string imagePath = Path.Combine(basePath, "Imagenes", "Platillos", imageFileName);

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
                        ZompyDogsLib.Pedidos.DetalleDePedido nuevoPlatillo = new ZompyDogsLib.Pedidos.DetalleDePedido
                        {
                            PlatilloNombre = lblPlatillo.Text,
                            Precio_Unitario = decimal.Parse(lblPrecio.Text.Replace("L.", "").Trim()),
                            Cantidad = cantidadPlatillo,
                            id_Menu = Convert.ToInt32(lblId_Menu.Text),
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

        /// <summary>
        /// Maneja el evento de clic en una celda del DataGridView de pedidos.
        /// Muestra los datos del platillo seleccionado en un TextBox.
        /// </summary>
        private void dgvPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvPedido.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                // Asigna valores de la fila seleccionada a las variables correspondientes.
                pedidoPlatilo = filaSeleccionada.Cells["PlatilloNombre"].Value.ToString();
                pedidoCantidad = Convert.ToInt32(filaSeleccionada.Cells["Cantidad"].Value);
                pedidoPrecioUnitario = Convert.ToInt32(filaSeleccionada.Cells["Precio_Unitario"].Value);

                txtPlatilloOrden.Text = pedidoPlatilo;
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón para eliminar un platillo de la orden.
        /// Actualiza la lista de pedidos y recalcula el total.
        /// </summary>
        private void btnEliminarOrden_Click(object sender, EventArgs e)
        {
            if (dgvPedido.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvPedido.SelectedRows[0];

                // Obtiene el nombre del platillo de la fila seleccionada.
                string namePlatillo = filaSeleccionada.Cells["PlatilloNombre"].Value.ToString();

                // Busca el platillo en la lista de pedidos.
                var platilloAEliminar = _pedidosDAO.platillosLista.FirstOrDefault(p => p.PlatilloNombre == namePlatillo);

                if (platilloAEliminar != null)
                {
                    // Elimina el platillo de la lista y actualiza la cantidad de pedidos.
                    _pedidosDAO.platillosLista.Remove(platilloAEliminar);
                    cantidadPedido--;

                    // Actualiza el DataGridView.
                    _bndsrcPedido.ResetBindings(false);

                    // Recalcula el total después de eliminar el platillo.
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

        /// Calcula el subtotal y el total a pagar de la orden actual, incluyendo el ISV.
        /// Actualiza los valores en las etiquetas del formulario.
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
            pedidoISV = isv;

            totalaPago = subtotalPago + pedidoISV;

            lblTotalAPagar.Text = totalaPago.ToString("F2");  // Total a pagar con 2 decimales
            lblSubtotal.Text = subtotalPago.ToString("F2");  // Subtotal con 2 decimales
        }

        private void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            GuardarPedido();

            ImprimirFacturaPedido();
        }

        /// <summary>
        /// Guarda un nuevo pedido en la base de datos, incluyendo el pedido y sus detalles.
        /// </summary>
        private void GuardarPedido()
        {
            // Obtiene el código generado para el pedido y el total a pagar.
            codigoPedido = txtCodigoGenerado.Text;
            decimal totalPago = subtotalPago;

            try
            {
                // Establece una conexión a la base de datos y comienza una transacción.
                using (SqlConnection conn = new SqlConnection(con_string))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    string queryPedido = @"INSERT INTO Pedido(codigoPedido, Fk_Usuario, FechaPedido, estado, TotalPedido)
                                   VALUES (@CodigoPedido, @CodigoEmpleado, GETDATE(), 'PAGADO', @totalPedido);
                                   SELECT SCOPE_IDENTITY();";

                    // Comando para ejecutar la consulta de inserción en la tabla 'Pedido'.
                    SqlCommand cmdPedido = new SqlCommand(queryPedido, conn, transaction);
                    cmdPedido.Parameters.AddWithValue("@CodigoPedido", codigoPedido);
                    cmdPedido.Parameters.AddWithValue("@CodigoEmpleado", usuarioIDActual);
                    cmdPedido.Parameters.AddWithValue("@totalPedido", totalaPago);

                    // Ejecuta la consulta y obtiene el ID del nuevo pedido insertado.
                    int pedidoID = Convert.ToInt32(cmdPedido.ExecuteScalar());

                    // Itera sobre la lista de platillos y guarda cada uno en la tabla 'Detalle_Pedido'.
                    foreach (var platillo in _pedidosDAO.platillosLista)
                    {
                        string queryDetalle = @"INSERT INTO Detalle_Pedido(idPedido, Fk_Menu, Cantidad, precioUnitario, subtotal)
                                        VALUES (@CodigoPedido, @CodigoPlatillo, @Cantidad, @PrecioUnitario, @subTotal)";

                        // Comando para insertar los detalles del pedido en la tabla 'Detalle_Pedido'.
                        SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conn, transaction);
                        cmdDetalle.Parameters.AddWithValue("@CodigoPedido", pedidoID);
                        cmdDetalle.Parameters.AddWithValue("@CodigoPlatillo", platillo.id_Menu);
                        cmdDetalle.Parameters.AddWithValue("@Cantidad", cantidadPlatillo);
                        cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", pedidoPrecioUnitario);
                        cmdDetalle.Parameters.AddWithValue("@subTotal", subtotalPago);

                        // Ejecuta la consulta para insertar el detalle del platillo.
                        cmdDetalle.ExecuteNonQuery();
                    }
                    // Si todo es exitoso, confirma la transacción.
                    transaction.Commit();


                    CargarMenu("Almuerzos");
                    _pedidosDAO.platillosLista.Clear();
                    _bndsrcPedido.ResetBindings(false);
                    GeneradordeCodigoPedidoFromForm();
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

        public void VerFacturaFinalizada()
        {
            if (itsInvoice == false)
            {
                var facturaView = new FacturaView();

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
            else
            {
                var facturaView = new FacturaView();

                foreach (Control control in facturaView.Controls)
                {
                    control.Enabled = false;
                }
                facturaView.btnCancelar.Enabled = true;
                facturaView.dgvTotalPedido.Enabled = true;
                facturaView.btnCancelar.Text = "ACEPTAR";
                facturaView.btnCancelar.BackColor = Color.Blue;
                facturaView.Show();

                DataTable facturaDatosView = PedidosDAO.ObtenerDetalllesDeFacturaFinalizada(pedidioInvoice);

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
            
        }

        private void ImprimirFacturaPedido()
        {
            // Obtiene los detalles de la factura desde el DAO.
            DataTable facturaViewPedido = PedidosDAO.ObtenerDetalllesDeFacturaFinalizadaPorPlatillo(codigoPedido);

            // Crea una tabla temporal para la factura que se pasará al formulario de impresión.
            DataTable facturaPedidoTrans = new DataTable();
            facturaPedidoTrans.Columns.Add("Platillo", typeof(string));
            facturaPedidoTrans.Columns.Add("Cantidad", typeof(int));
            facturaPedidoTrans.Columns.Add("Precio Unitario", typeof(decimal));

            List<DetalleDePedido> listaPlatillos = _pedidosDAO.platillosLista.ToList();

            // Crea una nueva instancia del formulario ImprimirFactura, pasándole los datos necesarios.
            ImprimirFactura_Pedidos frmImprimirFactura = new ImprimirFactura_Pedidos(listaPlatillos);


            // Asignar los valores correspondientes a los controles en el formulario 'ImprimirFactura'
            frmImprimirFactura.lblEmpleadoNombre.Text = pedidoEmpleado; 
            frmImprimirFactura.lblNumFac.Text = codigoPedido;  
            frmImprimirFactura.lblFechaPedido.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");  // Fecha y hora del pedido
            frmImprimirFactura.lblTotal.Text = totalaPago.ToString("C2");  // Total a pagar, con formato de moneda
            frmImprimirFactura.lblSubtotal.Text = subtotalPago.ToString("C2");  // Subtotal, con formato de moneda
            frmImprimirFactura.lblISV.Text = pedidoISV.ToString("C2");  // ISV, con formato de moneda
            frmImprimirFactura.lblCodigoEmpleado.Text = pedidoCodigoEmpleado;  // Código del empleado

            
            // Muestra el formulario de impresión
            frmImprimirFactura.Show();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarMenu("Almuerzos");
            lblSubtotal.Text = "00";
            lblTotalAPagar.Text = "00";
            txtPlatilloOrden.Text = "";
            _pedidosDAO.platillosLista.Clear();
            _bndsrcPedido.ResetBindings(false);
        }
    }
}

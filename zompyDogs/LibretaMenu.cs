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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ExplorerBar;

namespace zompyDogs
{
    public partial class LibretaMenu : Form
    {
        public static readonly string con_string = "Data Source=MACARENA\\SQLEXPRESS;Initial Catalog=DB_ZompyDogs;Integrated Security=True;Encrypt=False";
        public static SqlConnection conn = new SqlConnection(con_string);

        // Referencia al formulario principal (BienvenidaAdmin)
        public BienvenidaAdmin FormPrincipal { get; set; }
        // Referencia al formulario principal para empleados (EmpleadoBienvenida)
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }
        public LibretaMenu()
        {
            InitializeComponent();
            // Carga inicial de la categoría "Almuerzos"
            CargarMenu("Almuerzos");
            // Carga las categorías disponibles
            AddCategoria();
        }

        // Método para cargar el menú según la categoría seleccionada
        private void CargarMenu(string categoria)
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                // Consulta SQL para obtener los platillos de la categoría seleccionada
                string query = "SELECT Codigo, Platillo, Descripcion, Precio, Imagen FROM v_DetallesMenu WHERE Categoria = @Categoria AND Estado = 'Activo'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Categoria", categoria);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Limpiar el FlowLayoutPanel antes de agregar nuevos controles
                flpLibreta.Controls.Clear();
                bool hasResults = false;

                // Leer los datos de la consulta y generar los controles dinámicamente
                while (reader.Read())
                {
                    hasResults = true;

                    // Crear panel contenedor para cada platillo
                    Panel panelPlatillo = new Panel();
                    panelPlatillo.Size = new Size(339, 343);
                    panelPlatillo.BorderStyle = BorderStyle.FixedSingle;

                    // Subpanel para el nombre del platillo
                    Panel panelNombrePlatillo = new Panel();
                    panelNombrePlatillo.Size = new Size(339, 52);
                    panelNombrePlatillo.Dock = DockStyle.Top;

                    // Subpanel para el precio y descripcion del platillo
                    Panel panelPrecio = new Panel();
                    panelPrecio.Size = new Size(339, 115);
                    panelPrecio.Dock = DockStyle.Bottom;

                    // PictureBox para mostrar la imagen del platillo
                    PictureBox pbxPlatillo = new PictureBox();
                    pbxPlatillo.Size = new Size(255, 224);
                    pbxPlatillo.Location = new Point(50, 20);
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

                    // Etiqueta para el nombre del platillo
                    Label lblPlatillo = new Label();
                    lblPlatillo.Text = reader["Platillo"].ToString();
                    lblPlatillo.Location = new Point(20, 5);
                    lblPlatillo.AutoSize = true;
                    lblPlatillo.Font = new Font("Arial", 14, FontStyle.Bold);

                    // Etiqueta para el precio del platillo
                    Label lblPrecio = new Label();
                    lblPrecio.Text = $"L.{reader["Precio"].ToString()}";
                    lblPrecio.Location = new Point(41, 5);
                    lblPrecio.AutoSize = true;
                    lblPrecio.Font = new Font("Arial", 10, FontStyle.Bold);

                    // TextBox para la descripción (solo lectura)
                    TextBox txtDescripcion = new TextBox();
                    if (reader["Descripcion"] != DBNull.Value)
                    {
                        txtDescripcion.Text = reader["Descripcion"].ToString();
                        txtDescripcion.Size = new Size(304, 68);
                        txtDescripcion.Location = new Point(20, 31);
                        txtDescripcion.Multiline = true;
                        txtDescripcion.ReadOnly = true;
                        txtDescripcion.Enabled = false;
                    }
                    else
                    {
                        txtDescripcion.Hide();
                    }

                    // Agregar controles al panel del platillo
                    panelPlatillo.Controls.Add(panelNombrePlatillo);
                    panelPlatillo.Controls.Add(panelPrecio);
                    panelPlatillo.Controls.Add(pbxPlatillo);

                    panelNombrePlatillo.Controls.Add(lblPlatillo);

                    panelPrecio.Controls.Add(lblPrecio);
                    panelPrecio.Controls.Add(txtDescripcion);



                    // Agregar el panel al FlowLayoutPanel
                    flpLibreta.Controls.Add(panelPlatillo);
                }
                // Mostrar mensaje si no hay resultados
                if (!hasResults)
                {
                    Label lblFLP = new Label();
                    lblFLP.Text = "No se encontraron platillos en esta categoría.";
                    lblFLP.Location = new Point(20, 5);
                    lblFLP.AutoSize = true;
                    lblFLP.Font = new Font("Arial", 14, FontStyle.Bold);
                    flpLibreta.Controls.Add(lblFLP);
                }

                reader.Close();
            }
        }

        // Método para cargar las categorías en un panel dinámico
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

            // Limpiar los controles existentes
            categoryPanelIN.Controls.Clear();
            categoryPanelIN.AutoScroll = true;

            // Configuración de botones dinámicos
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

                // Asignar la posición de los botones
                btnCategory.Location = new Point(-2, categoryPanelIN.Controls.Count * (buttonHeight + yOffset));

                // Evento de clic para cargar platillos según la categoría seleccionada
                btnCategory.Click += (sender, e) =>
                {
                    // Llama al método para cargar platillos según la categoría seleccionada
                    CargarMenu(btnCategory.Text);
                };

                categoryPanelIN.Controls.Add(btnCategory);
            }
        }

        //Cambia al panel de Menu 
        private void btnUsuarioPanel_Click(object sender, EventArgs e)
        {
            if (FormPrincipal != null )
            {
                FormPrincipal.AbrirFormsHija(new Menu { FormPrincipal = FormPrincipal });
            }
            else if (EmpleadoFormPrincipal != null)
            {
                EmpleadoFormPrincipal.AbrirFormsHijaEmpleado(new Menu { EmpleadoFormPrincipal = EmpleadoFormPrincipal });
            }
            else
            {
                MessageBox.Show("FormPrincipal es nulo");
            }
        }
        
    }
}

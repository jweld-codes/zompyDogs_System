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

        public BienvenidaAdmin FormPrincipal { get; set; }
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }
        public LibretaMenu()
        {
            InitializeComponent();
            CargarMenu("Entrada");
            AddCategoria();
        }

        private void CargarMenu(string categoria)
        {
            using (SqlConnection conn = new SqlConnection(con_string))
            {
                string query = "SELECT Codigo, Platillo, Descripcion, Precio, Imagen FROM v_DetallesMenu WHERE Categoria = @Categoria";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Categoria", categoria);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                flpLibreta.Controls.Clear();
                bool hasResults = false;

                while (reader.Read())
                {
                    hasResults = true;

                    // Crear panel contenedor para cada platillo
                    Panel panelPlatillo = new Panel();
                    panelPlatillo.Size = new Size(339, 343);
                    panelPlatillo.BorderStyle = BorderStyle.FixedSingle;

                    Panel panelNombrePlatillo = new Panel();
                    panelNombrePlatillo.Size = new Size(339, 52);
                    panelNombrePlatillo.Dock = DockStyle.Top;

                    Panel panelPrecio = new Panel();
                    panelPrecio.Size = new Size(339, 115);
                    panelPrecio.Dock = DockStyle.Bottom;

                    PictureBox pbxPlatillo = new PictureBox();
                    pbxPlatillo.Size = new Size(255, 224);
                    pbxPlatillo.Location = new Point(50, 20);
                    pbxPlatillo.SizeMode = PictureBoxSizeMode.Zoom;
                    if (reader["Imagen"] != DBNull.Value)
                    {
                        string imageFileName = reader["Imagen"].ToString();
                        string projectPath = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
                        string imagePath = Path.Combine(projectPath, "Imagenes", imageFileName);

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
                    lblPlatillo.Location = new Point(20, 5);
                    lblPlatillo.AutoSize = true;
                    lblPlatillo.Font = new Font("Arial", 14, FontStyle.Bold);

                    Label lblPrecio = new Label();
                    lblPrecio.Text = $"L.{reader["Precio"].ToString()}";
                    lblPrecio.Location = new Point(41, 5);
                    lblPrecio.AutoSize = true;
                    lblPrecio.Font = new Font("Arial", 10, FontStyle.Bold);

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

                // Asignar la ubicación
                btnCategory.Location = new Point(-2, categoryPanelIN.Controls.Count * (buttonHeight + yOffset));

                // Agregar evento de clic
                btnCategory.Click += (sender, e) =>
                {
                    // Llama al método para cargar platillos según la categoría seleccionada
                    CargarMenu(btnCategory.Text);
                };

                categoryPanelIN.Controls.Add(btnCategory);
            }
        }

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

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
           
        }

        
    }
}

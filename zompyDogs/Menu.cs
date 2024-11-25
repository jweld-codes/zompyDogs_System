using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZompyDogsDAO;
using zompyDogs.CRUD.REGISTROS;
using Microsoft.VisualBasic.ApplicationServices;

namespace zompyDogs
{
    /// <summary>
    /// Formulario principal para la gestión del menú en el sistema ZompyDogs. Permite visualizar, agregar, editar, eliminar y buscar platillos.
    /// </summary>
    public partial class Menu : Form
    {
        // Propiedades para referencia a otros formularios
        public BienvenidaAdmin FormPrincipal { get; set; }
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }
        public int RolID { get; set; }

        // Variable privada para almacenar el código del platillo seleccionado
        private string menuCodigoVal;

        // Indicador de si se está editando un platillo
        public bool isEditar;

        /// <summary>
        /// Constructor de la clase. Inicializa los componentes y carga los platillos del menú.
        /// </summary>
        public Menu()
        {
            InitializeComponent();

            CargarPlatillosdeMenu();
            btnEliminarMenu.Hide();
        }

        /// <summary>
        /// Carga los platillos del menú desde la base de datos y los muestra en el DataGridView.
        /// </summary>
        private void CargarPlatillosdeMenu()
        {
            DataTable menu = MenuDAO.ObtenerDetallesdeMenu();
            dgvMenu.DataSource = menu;

            // Personaliza el estilo del encabezado del DataGridView
            dgvMenu.EnableHeadersVisualStyles = false;
            dgvMenu.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvMenu.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvMenu.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);

            dgvMenu.Columns["Codigo"].HeaderText = "Código";
            dgvMenu.Columns["Categoria"].HeaderText = "Categoría";
        }

        /// <summary>
        /// Abre el formulario de LibretaMenu cuando se hace clic en el botón correspondiente.
        /// </summary>
        private void btnLibretaMenu_Click(object sender, EventArgs e)
        {
            if (FormPrincipal != null)
            {
                FormPrincipal.AbrirFormsHija(new LibretaMenu { FormPrincipal = FormPrincipal });
            }
            else if (EmpleadoFormPrincipal != null)
            {
                EmpleadoFormPrincipal.AbrirFormsHijaEmpleado(new LibretaMenu { EmpleadoFormPrincipal = EmpleadoFormPrincipal });
            }
            else
            {
                MessageBox.Show("FormPrincipal es nulo");
            }
        }

        /// <summary>
        /// Abre el formulario para agregar un nuevo platillo al menú.
        /// </summary>
        private void btnAgregarNuevoUsuario_Click(object sender, EventArgs e)
        {
            isEditar = false;
            MenuRegistro fmMenuRegistro = new MenuRegistro(isEditar);
            fmMenuRegistro.Show();
        }

        /// <summary>
        /// Abre el formulario de edición de un platillo existente.
        /// </summary>
        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            isEditar = true;
            MenuRegistro fmMenuRegistro = new MenuRegistro(isEditar);

            // Obtiene los detalles del platillo a editar
            DataTable menuEditar = MenuDAO.ObtenerDetalllesMenuParaEditar(menuCodigoVal);

            if (menuEditar.Rows.Count > 0)
            {
                DataRow fila = menuEditar.Rows[0];

                // Rellena el formulario con los datos del platillo
                fmMenuRegistro.txtCodigoGenerado.Text = menuCodigoVal;
                fmMenuRegistro.txtCodigoGenerado.Enabled = false;

                fmMenuRegistro.txtNombrePlatillo.Text = fila["Platillo"].ToString();
                fmMenuRegistro.txtDescripcion.Text = fila["Descripcion"].ToString();
                fmMenuRegistro.txtPrecioUnitario.Text = fila["Precio"].ToString();

                fmMenuRegistro.txtImagenName.Text = fila["Imagen"].ToString();
                fmMenuRegistro.txtImagenName.Enabled = false;

                // Carga la imagen del platillo si está disponible
                if (fila["Imagen"] != DBNull.Value)
                {
                    string imageFileName = fila["Imagen"].ToString();
                    string projectPath = "C:\\Users\\jenni\\Documents\\GitHub\\zompyDogs\\zompyDogs\\Imagenes";
                    string imagePath = Path.Combine(projectPath, "Platillos", imageFileName);

                    if (File.Exists(imagePath))
                    {
                        fmMenuRegistro.pbxImagenSeleccionada.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        MessageBox.Show($"La imagen no se encontró en la ruta: {imagePath}");
                    }
                }

                fmMenuRegistro.cbxCategorias.Text = fila["Categoria"].ToString();
                fmMenuRegistro.cbxEstado.Text = fila["Estado"].ToString();

            }
            fmMenuRegistro.Show();
        }

        /// <summary>
        /// Maneja el evento de clic en una celda del DataGridView, almacenando el código del platillo seleccionado.
        /// </summary>
        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvMenu.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                menuCodigoVal = filaSeleccionada.Cells["Codigo"].Value.ToString();
            }
        }

        /// <summary>
        /// Refresca el DataGridView para cargar los platillos del menú nuevamente.
        /// </summary>
        private void btnRefreshDG_Click(object sender, EventArgs e)
        {
            CargarPlatillosdeMenu();
        }

        /// <summary>
        /// Filtra los platillos del menú según el texto ingresado en el cuadro de búsqueda.
        /// </summary>
        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            string valorBusqueda = txtBuscarUsuario.Text;
            DataTable resultados = MenuDAO.BuscadorDePlatillos(valorBusqueda);
            dgvMenu.DataSource = resultados;
        }

        /// <summary>
        /// Elimina un platillo seleccionado del menú después de confirmación.
        /// </summary>
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Código del platillo a eliminar: " + menuCodigoVal);

            if (string.IsNullOrEmpty(menuCodigoVal))
            {
                MessageBox.Show("Por favor, selecciona un platillo para eliminar.");
                return;
            }

            DialogResult check = MessageBox.Show("¿Está seguro de eliminar el platillo?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                bool eliminado = MenuDAO.EliminarPlatillo(menuCodigoVal);

                if (eliminado)
                {
                    MessageBox.Show("Platillo eliminado con éxito.");
                    CargarPlatillosdeMenu();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el platillo.");
                }
            }
        }

        /// <summary>
        /// Visualiza los detalles de un platillo seleccionado en modo solo lectura.
        /// </summary>
        private void btnVisualizarRegistro_Click(object sender, EventArgs e)
        {
            var menuView = new MenuRegistro(false);

            // Deshabilitar todos los elementos del formulario
            foreach (Control control in menuView.Controls)
            {
                control.Enabled = false;
            }
            menuView.btnCancelar.Enabled = true;
            menuView.Show();

            // Carga los detalles del platillo para visualizar
            DataTable menuEditar = MenuDAO.ObtenerDetalllesMenuParaEditar(menuCodigoVal);

            if (menuEditar.Rows.Count > 0)
            {
                DataRow fila = menuEditar.Rows[0];

                menuView.txtCodigoGenerado.Text = menuCodigoVal;
                menuView.txtCodigoGenerado.Enabled = false;

                menuView.txtNombrePlatillo.Text = fila["Platillo"].ToString();
                menuView.txtDescripcion.Text = fila["Descripcion"].ToString();
                menuView.txtPrecioUnitario.Text = fila["Precio"].ToString();

                menuView.cbxEstado.Enabled = false;
                menuView.cbxEstado.Text = fila["Estado"].ToString();

                menuView.txtImagenName.Text = fila["Imagen"].ToString();
                menuView.txtImagenName.Enabled = false;
                if (fila["Imagen"] != DBNull.Value)
                {
                    string imageFileName = fila["Imagen"].ToString();
                    string projectPath = "C:\\Users\\jenni\\Documents\\GitHub\\zompyDogs\\zompyDogs\\Imagenes";
                    string imagePath = Path.Combine(projectPath, "Platillos", imageFileName);

                    if (File.Exists(imagePath))
                    {
                        menuView.pbxImagenSeleccionada.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        MessageBox.Show($"La imagen no se encontró en la ruta: {imagePath}");
                    }
                }

                menuView.cbxCategorias.Text = fila["Categoria"].ToString();
            }
            menuView.Show();

        }
    }
}

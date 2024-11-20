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
    public partial class Menu : Form
    {
        public BienvenidaAdmin FormPrincipal { get; set; }
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }
        public int RolID { get; set; }
        private string menuCodigoVal;
        public bool isEditar;
        public Menu()
        {
            InitializeComponent();
            CargarPlatillosdeMenu();
            btnEliminarUsuario.Show();
            
        }

        private void CargarPlatillosdeMenu()
        {
            DataTable menu = MenuDAO.ObtenerDetallesdeMenu();
            dgvMenu.DataSource = menu;

            dgvMenu.EnableHeadersVisualStyles = false;
            dgvMenu.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvMenu.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvMenu.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);

            dgvMenu.Columns["Codigo"].HeaderText = "Código";
            dgvMenu.Columns["Descripcion"].HeaderText = "Descripción";
            dgvMenu.Columns["Categoria"].HeaderText = "Categoría";
        }

        private void btnLibretaMenu_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
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

        private void btnAgregarNuevoUsuario_Click(object sender, EventArgs e)
        {
            isEditar = false;
            MenuRegistro fmMenuRegistro = new MenuRegistro(isEditar);
            fmMenuRegistro.Show();
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            isEditar = true;
            MenuRegistro fmMenuRegistro = new MenuRegistro(isEditar);

            DataTable menuEditar = MenuDAO.ObtenerDetalllesMenuParaEditar(menuCodigoVal);

            if (menuEditar.Rows.Count > 0)
            {
                DataRow fila = menuEditar.Rows[0];

                fmMenuRegistro.txtCodigoGenerado.Text = menuCodigoVal;
                fmMenuRegistro.txtCodigoGenerado.Enabled = false;

                fmMenuRegistro.txtNombrePlatillo.Text = fila["Platillo"].ToString();
                fmMenuRegistro.txtDescripcion.Text = fila["Descripcion"].ToString();
                fmMenuRegistro.txtSalario.Text = fila["Precio"].ToString();

                fmMenuRegistro.txtImagenName.Text = fila["Imagen"].ToString();
                fmMenuRegistro.txtImagenName.Enabled = false;
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

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvMenu.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                menuCodigoVal = filaSeleccionada.Cells["Codigo"].Value.ToString();
            }
        }

        private void btnRefreshDG_Click(object sender, EventArgs e)
        {
            CargarPlatillosdeMenu();
        }

        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            string valorBusqueda = txtBuscarUsuario.Text;
            DataTable resultados = MenuDAO.BuscadorDePlatillos(valorBusqueda);
            dgvMenu.DataSource = resultados;
        }

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

            DataTable menuEditar = MenuDAO.ObtenerDetalllesMenuParaEditar(menuCodigoVal);

            if (menuEditar.Rows.Count > 0)
            {
                DataRow fila = menuEditar.Rows[0];

                menuView.txtCodigoGenerado.Text = menuCodigoVal;
                menuView.txtCodigoGenerado.Enabled = false;

                menuView.txtNombrePlatillo.Text = fila["Platillo"].ToString();
                menuView.txtDescripcion.Text = fila["Descripcion"].ToString();
                menuView.txtSalario.Text = fila["Precio"].ToString();

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

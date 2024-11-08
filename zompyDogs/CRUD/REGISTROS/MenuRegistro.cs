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
using ZompyDogsLib.Controladores;
using static ZompyDogsDAO.MenuDAO;
using static ZompyDogsDAO.UsuarioDAO;

namespace zompyDogs.CRUD.REGISTROS
{
    public partial class MenuRegistro : Form
    {
        private string nuevoCodigoMenu;
        private ControladorGeneradoresDeCodigo _controladorGeneradorCodigo;
        private string puestCodigoVal;

        public bool isEdition;
        private Menu _menuRegistroFrm;
        public MenuRegistro(bool isEdition)
        {
            InitializeComponent();
            this.isEdition = isEdition;

            _controladorGeneradorCodigo = new ControladorGeneradoresDeCodigo();
            GeneradordeCodigoMenuFromForm();
            CargarRolesComboBox();

            txtImagenName.Enabled = false;

            _menuRegistroFrm = new Menu();
           // MessageBox.Show("isEdition: " + isEdition);

        }

        private void GeneradordeCodigoMenuFromForm()
        {
            nuevoCodigoMenu = _controladorGeneradorCodigo.GeneradordeCodigoMenu();
            txtCodigoGenerado.Text = nuevoCodigoMenu;
        }
        private void CargarRolesComboBox()
        {
            DataTable dtCategoria = MenuDAO.ObtenerCategoriaParaComboBox();

            cbxCategorias.DataSource = dtCategoria;
            cbxCategorias.DisplayMember = "Categoria";
            cbxCategorias.ValueMember = "IdCategoria";
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            string projectPath = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;

            OpenFileDialog ofdSeleccionarImagen = new OpenFileDialog();
            ofdSeleccionarImagen.Filter = "Imagenes|*.jpg; *.png; *.jpeg";
            ofdSeleccionarImagen.InitialDirectory = "C:\\Users\\jenni\\Documents\\GitHub\\zompyDogs\\zompyDogs\\Imagenes\\Platillos";
            ofdSeleccionarImagen.Title = "Seleccionar Imagen";

            if (ofdSeleccionarImagen.ShowDialog() == DialogResult.OK)
            {
                pbxImagenSeleccionada.Image = Image.FromFile(ofdSeleccionarImagen.FileName);
                txtImagenName.Text = ofdSeleccionarImagen.SafeFileName;
                pbxImagenSeleccionada.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnGuardarMenu_Click(object sender, EventArgs e)
        {
            if (isEdition == true)
            {
                btnGuardarMenu.Text = "Editar";
                lblTitulo.Text = "Editar Platillo";

                if (string.IsNullOrWhiteSpace(txtCodigoGenerado.Text) ||
                        string.IsNullOrWhiteSpace(txtNombrePlatillo.Text) ||
                        string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                        string.IsNullOrWhiteSpace(txtImagenName.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos requeridos.");
                    return;
                }

                if (!decimal.TryParse(txtSalario.Text, out decimal precioUnitario))
                {
                    MessageBox.Show("El valor del precio no es válido.");
                    return;
                }

                RegistroMenuPlatillo menuToUpdate = new RegistroMenuPlatillo
                {
                    CodigoMenu = txtCodigoGenerado.Text,
                    PlatilloName = txtNombrePlatillo.Text,
                    Descripcion = txtDescripcion.Text,
                    PrecioUnitario = Convert.ToDecimal(txtSalario.Text),
                    ImagenPlatillo = txtImagenName.Text,
                    CodigoCategoria = Convert.ToInt32(cbxCategorias.SelectedValue)
                };
                

                try
                {
                    MenuDAO.ActualizarMenu(menuToUpdate);

                    MessageBox.Show("Platillo actualizado con éxito.");
                    CargarPlatillosdeMenu();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al actualizar el puesto: " + ex.Message);
                }

            }
            else
            {
                btnGuardarMenu.Text = "Guardar";
                RegistroMenuPlatillo nuevoMenu = new RegistroMenuPlatillo
                {
                    CodigoMenu = txtCodigoGenerado.Text,
                    PlatilloName = txtNombrePlatillo.Text,
                    Descripcion = txtDescripcion.Text,
                    PrecioUnitario = Convert.ToDecimal(txtSalario.Text),
                    ImagenPlatillo = txtImagenName.Text,
                    CodigoCategoria = cbxCategorias.SelectedValue != null && int.TryParse(cbxCategorias.SelectedValue.ToString(), out int codigoCateg) ? codigoCateg : 1,
                };
                try
                {
                    if (string.IsNullOrWhiteSpace(nuevoMenu.CodigoMenu) ||
                        string.IsNullOrWhiteSpace(nuevoMenu.PlatilloName) ||
                        string.IsNullOrWhiteSpace(nuevoMenu.Descripcion) ||
                        string.IsNullOrWhiteSpace(nuevoMenu.ImagenPlatillo))
                    {
                        MessageBox.Show("Por favor, complete todos los campos requeridos.");
                        return;
                    }
                    // Guardar DetalleUsuario
                    MenuDAO.GuardarMenu(nuevoMenu);

                    MessageBox.Show("Platillo Registrado con Éxito.");
                    ObtenerDetallesdeMenu();

                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Error al registrar el Puesto.");

                }
            }
        }

        private void CargarPlatillosdeMenu()
        {
            _menuRegistroFrm.dgvMenu.DataSource = MenuDAO.ObtenerDetallesdeMenu(); ;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
            errorProviderMenu.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            txtImagenName.Enabled = false;

            _menuRegistroFrm = new Menu();
            // MessageBox.Show("isEdition: " + isEdition);

        }

        public bool ValidarCampos()
        {
            bool okError = true;

            List<TextBox> textBoxes = new List<TextBox> { txtNombrePlatillo, txtSalario, txtImagenName };

            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    okError = false;
                    errorProviderMenu.SetError(textBox, $"Ingrese un valor en el campo.");
                    textBox.BackColor = Color.OldLace;
                }
                else
                {
                    errorProviderMenu.SetError(textBox, "");
                    textBox.BackColor = SystemColors.Window;
                }
            }

            if (txtSalario.Text.Length < 0 || !txtSalario.Text.All(char.IsDigit) || txtSalario.Text == "0")
            {
                okError = false;
                errorProviderMenu.SetError(txtSalario, "El precio no puede ser cero.");
                txtSalario.BackColor = Color.OldLace;
            }
            else
            {
                errorProviderMenu.SetError(txtSalario, "");
                txtSalario.BackColor = SystemColors.Window;
            }

            if (txtNombrePlatillo.Text.Length < 3)
            {
                okError = false;
                errorProviderMenu.SetError(txtNombrePlatillo, "El nombre del platillo debe tener al menos 3 caracteres.");
                txtNombrePlatillo.BackColor = Color.OldLace;
            }

            if (txtNombrePlatillo.Text.Length > 50)
            {
                okError = false;
                errorProviderMenu.SetError(txtNombrePlatillo, "El nombre del platillo no puede excederse a 50 caracteres.");
                txtNombrePlatillo.BackColor = Color.OldLace;
            }


            return okError;
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
                if (ValidarCampos() == false)
                {

                    ValidarCampos();
                }
                else
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
                        CodigoCategoria = Convert.ToInt32(cbxCategorias.SelectedValue),
                        Estado = cbxEstado.Text
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

            }
            else
            {
                if (ValidarCampos() == false)
                {

                    ValidarCampos();
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
                        Estado = cbxEstado.Text
                    };
                    try
                    {
                        if (string.IsNullOrWhiteSpace(nuevoMenu.CodigoMenu) ||
                            string.IsNullOrWhiteSpace(nuevoMenu.PlatilloName) ||
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
        }
        private void txtNombrePlatillo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txtSalario.Text.Contains("."))
            {
                e.Handled = true;
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

        private void txtSalario_TextChanged(object sender, EventArgs e)
        {
            txtSalario.BackColor = Color.White;

            if (!string.IsNullOrWhiteSpace(txtSalario.Text) && txtSalario.Text.All(char.IsDigit))
            {
                errorProviderMenu.SetError(txtSalario, "El precio no puede quedar vacío.");

                if (txtSalario.Text.Length > 0)
                {
                    errorProviderMenu.SetError(txtSalario, string.Empty);

                    if (txtSalario.Text == "0")
                    {
                        errorProviderMenu.SetError(txtSalario, "El precio no puede ser cero.");
                        txtSalario.BackColor = Color.LightYellow;
                    }
                }
                else
                {
                    errorProviderMenu.SetError(txtSalario, "El precio no puede quedar en cero.");
                    txtSalario.BackColor = Color.LightYellow;
                }
            }
            else
            {
                errorProviderMenu.SetError(txtSalario, "El precio debe contener solo números.");
                txtSalario.BackColor = Color.LightPink;
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

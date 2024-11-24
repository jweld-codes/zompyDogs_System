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
using System.Text.RegularExpressions;

namespace zompyDogs.CRUD.REGISTROS
{
    public partial class MenuRegistro : Form
    {
        private string nuevoCodigoMenu;
        private ControladorGeneradoresDeCodigo _controladorGeneradorCodigo;
        private string puestCodigoVal;

        public bool isEdition;
        private Menu _menuRegistroFrm;
        
        /// <summary>
        /// Constructor de la clase MenuRegistro.
        /// Inicializa los componentes del formulario, configura el generador de códigos y carga los roles y límites de los campos.
        /// </summary>
        /// <param name="isEdition">Indica si el formulario es para edición o creación de un nuevo platillo.</param>
        /// 

        public MenuRegistro(bool isEdition)
        {
            InitializeComponent();
            this.isEdition = isEdition;

            // Inicializa el controlador que genera el código para los menús.
            _controladorGeneradorCodigo = new ControladorGeneradoresDeCodigo();
            GeneradordeCodigoMenuFromForm();

            // Carga las categorías del menú en un ComboBox.
            CargarCategoriasComboBox();

            // Configura la propiedad de error para el formulario
            errorProviderMenu.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // Deshabilita el campo para ingresar el nombre de la imagen.
            txtImagenName.Enabled = false;

            // Inicializa el objeto Menu.
            _menuRegistroFrm = new Menu();

            // Configura los límites de los campos de texto.
            LimitesTextboxes();

        }

        /// <summary>
        /// Establece los límites máximos de caracteres para los campos de texto.
        /// </summary>
        private void LimitesTextboxes()
        {
            txtNombrePlatillo.MaxLength = 50;
            txtDescripcion.MaxLength = 200;
            txtPrecioUnitario.MaxLength = 10;
        }


        /// <summary>
        /// Valida que los campos del formulario estén correctamente llenados.
        /// </summary>
        /// <returns>Devuelve true si todos los campos son válidos, de lo contrario false.</returns>
        public bool ValidarCampos()
        {
            bool okError = true;

            List<TextBox> textBoxes = new List<TextBox> { txtNombrePlatillo, txtPrecioUnitario, txtImagenName }; // crea una lista de los textbox existentes en el formulario.

            // Valida si los campos no están vacíos.
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

            // Valida el precio unitario.
            if (string.IsNullOrWhiteSpace(txtPrecioUnitario.Text) ||
                !decimal.TryParse(txtPrecioUnitario.Text, out decimal precio) ||
                precio <= 0)
            {
                okError = false;
                errorProviderMenu.SetError(txtPrecioUnitario, "El precio debe ser un número mayor a cero.");
                txtPrecioUnitario.BackColor = Color.OldLace;
            }
            else
            {
                errorProviderMenu.SetError(txtPrecioUnitario, string.Empty);
                txtPrecioUnitario.BackColor = SystemColors.Window;
            }

            // Valida el nombre del platillo (debe tener entre 3 y 50 caracteres).
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

            // Valida que no haya espacios consecutivos o al principio o final del nombre del platillo.
            if (Regex.IsMatch(txtNombrePlatillo.Text, @"\s{2,}"))
            {
                okError = false;
                errorProviderMenu.SetError(txtNombrePlatillo, "El texto no puede contener múltiples espacios consecutivos.");
                txtNombrePlatillo.BackColor = Color.LightPink;
            }

            if (txtNombrePlatillo.Text.StartsWith(" ") || txtNombrePlatillo.Text.EndsWith(" "))
            {
                okError = false;
                errorProviderMenu.SetError(txtNombrePlatillo, "El texto no puede comenzar ni terminar con espacios.");
                txtNombrePlatillo.BackColor = Color.LightPink;
            }

            if (Regex.IsMatch(txtDescripcion.Text, @"\s{2,}"))
            {
                okError = false;
                errorProviderMenu.SetError(txtDescripcion, "El texto no puede contener múltiples espacios consecutivos.");
                txtDescripcion.BackColor = Color.LightPink;
            }

            if (txtDescripcion.Text.StartsWith(" ") || txtDescripcion.Text.EndsWith(" "))
            {
                okError = false;
                errorProviderMenu.SetError(txtDescripcion, "El texto no puede comenzar ni terminar con espacios.");
                txtDescripcion.BackColor = Color.LightPink;
            }

            return okError;
        }

        /// <summary>
        /// Genera un nuevo código de menú utilizando el controlador de generación de código y lo muestra en el formulario.
        /// </summary>
        private void GeneradordeCodigoMenuFromForm()
        {
            nuevoCodigoMenu = _controladorGeneradorCodigo.GeneradordeCodigoMenu();
            txtCodigoGenerado.Text = nuevoCodigoMenu;
        }

        /// <summary>
        /// Carga las categorías de los menús en el ComboBox para que el usuario las seleccione.
        /// </summary>
        private void CargarCategoriasComboBox()
        {
            DataTable dtCategoria = MenuDAO.ObtenerCategoriaParaComboBox();

            cbxCategorias.DataSource = dtCategoria;
            cbxCategorias.DisplayMember = "Categoria";
            cbxCategorias.ValueMember = "IdCategoria";
        }

        /// <summary>
        /// Abre un cuadro de diálogo para seleccionar una imagen y la asigna al PictureBox y al TextBox correspondiente.
        /// </summary>
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

        /// <summary>
        /// Guarda o actualiza el platillo en la base de datos, dependiendo de si se está editando o creando un nuevo platillo.
        /// </summary
        private void btnGuardarMenu_Click(object sender, EventArgs e)
        {
            if (isEdition == true) // Valida si es modo edición o nuevo registro.
            {
                // Validar campos y proceder con la actualización del platillo.
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

                    if (!decimal.TryParse(txtPrecioUnitario.Text, out decimal precioUnitario))
                    {
                        MessageBox.Show("El valor del precio no es válido.");
                        return;
                    }

                    ZompyDogsLib.Menu.RegistroMenuPlatillo menuToUpdate = new ZompyDogsLib.Menu.RegistroMenuPlatillo
                    {
                        CodigoMenu = txtCodigoGenerado.Text,
                        PlatilloName = txtNombrePlatillo.Text,
                        Descripcion = txtDescripcion.Text,
                        PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text),
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
                    ZompyDogsLib.Menu.RegistroMenuPlatillo nuevoMenu = new ZompyDogsLib.Menu.RegistroMenuPlatillo
                    {
                        CodigoMenu = txtCodigoGenerado.Text,
                        PlatilloName = txtNombrePlatillo.Text,
                        Descripcion = txtDescripcion.Text,
                        PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text),
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
        
        /// <summary>
        /// Carga todos los platillos de menú para mostrar en una lista o tabla.
        /// </summary>
        private void CargarPlatillosdeMenu()
        {
            _menuRegistroFrm.dgvMenu.DataSource = MenuDAO.ObtenerDetallesdeMenu(); ;
        }

        /// <summary>
        /// Cierra el formulario de registro de menú.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Valida que solo se ingresen letras o espacios en el campo de texto para el nombre del platillo,
        /// y que no se exceda la longitud máxima permitida.
        /// </summary>
        private void txtNombrePlatillo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras, espacios y controles como backspace.
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }

            // Valida si se excede la longitud máxima.
            if (txtNombrePlatillo.Text.Length >= txtNombrePlatillo.MaxLength && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProviderMenu.SetError(txtNombrePlatillo, "No puede exceder los 50 caracteres.");
            }
            else
            {
                errorProviderMenu.SetError(txtNombrePlatillo, string.Empty);
            }
        }

        /// <summary>
        /// Permite solo números y el carácter punto (.) para el campo de precio unitario.
        /// Además, valida que no se introduzca más de un punto decimal.
        /// </summary>
        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo números, puntos y controles como backspace.
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Evita que se agreguen más de un punto decimal.
            if (e.KeyChar == '.' && txtPrecioUnitario.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Realiza validaciones en tiempo real mientras se escribe en el campo de texto para el nombre del platillo.
        /// Verifica que el nombre tenga al menos 3 caracteres y que solo contenga letras.
        /// </summary>
        private void txtNombrePlatillo_TextChanged(object sender, EventArgs e)
        {
            // Establece el color de fondo del TextBox a blanco por defecto.
            txtNombrePlatillo.BackColor = Color.White;

            // Valida que el texto contenga solo letras y tenga al menos 3 caracteres.
            if (!string.IsNullOrWhiteSpace(txtNombrePlatillo.Text) && txtNombrePlatillo.Text.All(char.IsLetter))
            {
                if (txtNombrePlatillo.Text.Length > 2)
                {
                    errorProviderMenu.SetError(txtNombrePlatillo, string.Empty);
                }
                else
                {
                    errorProviderMenu.SetError(txtNombrePlatillo, "El nombre del platillo debe tener al menos 3 caracteres.");
                    txtNombrePlatillo.BackColor = Color.LightYellow;
                }
            }
            else
            {
                errorProviderMenu.SetError(txtNombrePlatillo, "El nombre del platillo debe contener solo letras y no puede estar vacío.");
                txtNombrePlatillo.BackColor = Color.LightPink;
            }

            // Valida que no se exceda el límite máximo de caracteres.
            if (txtNombrePlatillo.Text.Length >= txtNombrePlatillo.MaxLength)
            {
                errorProviderMenu.SetError(txtNombrePlatillo, "Se alcanzó el límite máximo de caracteres.");
            }
            else
            {
                errorProviderMenu.SetError(txtNombrePlatillo, string.Empty);
            }
        }

        /// <summary>
        /// Realiza validaciones en tiempo real mientras se escribe en el campo de precio unitario.
        /// Verifica que el precio sea un número mayor que cero y que solo contenga números.
        /// </summary>
        private void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            // Establece el color de fondo del TextBox a blanco por defecto.
            txtPrecioUnitario.BackColor = Color.White;

            // Valida que el precio no esté vacío y que contenga solo números.
            if (!string.IsNullOrWhiteSpace(txtPrecioUnitario.Text) && txtPrecioUnitario.Text.All(char.IsDigit))
            {
                errorProviderMenu.SetError(txtPrecioUnitario, "El precio no puede quedar vacío.");

                // Verifica que el precio no sea cero.
                if (txtPrecioUnitario.Text.Length > 0)
                {
                    errorProviderMenu.SetError(txtPrecioUnitario, string.Empty);

                    if (txtPrecioUnitario.Text == "0")
                    {
                        errorProviderMenu.SetError(txtPrecioUnitario, "El precio no puede ser cero.");
                        txtPrecioUnitario.BackColor = Color.LightYellow;
                    }
                }
                else
                {
                    errorProviderMenu.SetError(txtPrecioUnitario, "El precio no puede quedar en cero.");
                    txtPrecioUnitario.BackColor = Color.LightYellow;
                }
            }
            else
            {
                errorProviderMenu.SetError(txtPrecioUnitario, "El precio debe contener solo números.");
                txtPrecioUnitario.BackColor = Color.LightPink;
            }
        }
    }
}

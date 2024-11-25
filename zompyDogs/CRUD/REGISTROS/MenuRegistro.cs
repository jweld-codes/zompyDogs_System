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

            List<TextBox> NoMore2Spaces = new List<TextBox> { txtNombrePlatillo, txtDescripcion }; // crea una lista de los textbox existentes en el formulario.

            List<TextBox> NotNullsNeverNulls = new List<TextBox> { txtNombrePlatillo, txtPrecioUnitario, txtImagenName };

            foreach(TextBox noNulos in NotNullsNeverNulls)
            {
                if (string.IsNullOrWhiteSpace(noNulos.Text))
                {
                    okError = false;
                    errorProviderMenu.SetError(noNulos, $"Ingrese un valor en el campo.");
                    noNulos.BackColor = Color.OldLace;
                }
                else
                {
                    // Si pasa todas las validaciones, elimina los errores y restablece el fondo
                    errorProviderMenu.SetError(noNulos, string.Empty);
                    noNulos.BackColor = Color.White;
                }
            }
            // Valida si los campos no están vacíos.
            foreach (TextBox soloUnoEspacio in NoMore2Spaces)
            {
                if (Regex.IsMatch(soloUnoEspacio.Text, @"\s{2,}"))
                {
                    okError = false;
                    errorProviderMenu.SetError(soloUnoEspacio, "El texto no puede contener múltiples espacios consecutivos.");
                    soloUnoEspacio.BackColor = Color.LightPink;
                }
                else if (soloUnoEspacio.Text.StartsWith(" ") || soloUnoEspacio.Text.EndsWith(" "))
                {
                    okError = false;
                    errorProviderMenu.SetError(soloUnoEspacio, "El texto no puede comenzar ni terminar con espacios.");
                    soloUnoEspacio.BackColor = Color.LightPink;
                }
                else
                {
                    // Si pasa todas las validaciones, elimina los errores y restablece el fondo
                    errorProviderMenu.SetError(soloUnoEspacio, string.Empty);
                    soloUnoEspacio.BackColor = Color.White;
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
            string basePath = AppDomain.CurrentDomain.BaseDirectory; // Obtiene el directorio base de la aplicación
            string imagePath = Path.Combine(basePath, "Imagenes", "Platillos");

            OpenFileDialog ofdSeleccionarImagen = new OpenFileDialog();
            ofdSeleccionarImagen.Filter = "Imagenes|*.jpg; *.png; *.jpeg";
            ofdSeleccionarImagen.InitialDirectory = $"{imagePath}";
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

            // Valida que el texto no contenga múltiples espacios consecutivos.
            if (Regex.IsMatch(txtNombrePlatillo.Text, @"\s{2,}"))
            {
                errorProviderMenu.SetError(txtNombrePlatillo, "El texto no puede contener múltiples espacios consecutivos.");
                txtNombrePlatillo.BackColor = Color.LightPink;
                return;
            }

            // Valida que no comience ni termine con espacio.
            if (txtNombrePlatillo.Text.StartsWith(" ") || txtNombrePlatillo.Text.EndsWith(" "))
            {
                errorProviderMenu.SetError(txtNombrePlatillo, "El texto no puede comenzar ni terminar con espacios.");
                txtNombrePlatillo.BackColor = Color.LightPink;
                return;
            }

            // Valida que el texto solo contenga letras y espacios (para permitir palabras separadas por espacios).
            if (!string.IsNullOrWhiteSpace(txtNombrePlatillo.Text) && Regex.IsMatch(txtNombrePlatillo.Text, @"^[a-zA-Z\s]+$"))
            {
                // Valida que tenga al menos 3 caracteres
                if (txtNombrePlatillo.Text.Length >= 3)
                {
                    errorProviderMenu.SetError(txtNombrePlatillo, string.Empty);
                    txtNombrePlatillo.BackColor = Color.White;
                }
                else
                {
                    errorProviderMenu.SetError(txtNombrePlatillo, "El nombre del platillo debe tener al menos 3 caracteres.");
                    txtNombrePlatillo.BackColor = Color.LightYellow;
                }
            }
            else
            {
                errorProviderMenu.SetError(txtNombrePlatillo, "El nombre del platillo debe contener solo letras y espacios.");
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

            // Intenta parsear el texto a un número decimal.
            if (decimal.TryParse(txtPrecioUnitario.Text, out decimal precio))
            {
                // Verifica que el precio no sea cero.
                if (precio == 0)
                {
                    errorProviderMenu.SetError(txtPrecioUnitario, "El precio no puede ser cero.");
                    txtPrecioUnitario.BackColor = Color.LightYellow;
                }
                else
                {
                    // El precio es válido, borra cualquier error previo.
                    errorProviderMenu.SetError(txtPrecioUnitario, string.Empty);
                }
            }
            else
            {
                // Si no se puede parsear, muestra un error.
                errorProviderMenu.SetError(txtPrecioUnitario, "El precio debe contener un número válido (puede incluir un punto decimal).");
                txtPrecioUnitario.BackColor = Color.LightPink;
            }
        }
    }
}

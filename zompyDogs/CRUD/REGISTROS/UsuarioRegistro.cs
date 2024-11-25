using Azure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using zompyDogs.CRUD.REGISTROS;
using ZompyDogsDAO;
using ZompyDogsLib.Controladores;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;
using ClosedXML.Report.Utils;

namespace zompyDogs
{
    /// <summary>
    /// Clase que representa el formulario de registro de usuarios.
    /// Permite gestionar el registro de nuevos usuarios, validando entradas,
    /// generando códigos de usuario, y configurando roles mediante un ComboBox.
    /// </summary>
    public partial class UsuarioRegistro : Form
    {
        private ControladorGeneradoresDeCodigo _controladorGeneradorCodigo; // Generador de códigos para los usuarios.
        private string nuevoCodigoUsuario; // Código de usuario generado.
        private bool isTheUsername = false; // Indicador del nombre del usuario para el generador del usuario y la clave.
        private int contUser; // Contador auxiliar para gestionar usuarios.
        public bool okError = true; // Indicador del estado del formulario (error o éxito).

        /// <summary>
        /// Constructor del formulario UsuarioRegistro.
        /// Inicializa los componentes del formulario y configura eventos, validaciones,
        /// y comportamientos predeterminados.
        /// </summary>
        public UsuarioRegistro()
        {
            InitializeComponent();
            // Inicialización del controlador para generar códigos.
            _controladorGeneradorCodigo = new ControladorGeneradoresDeCodigo();

            // Genera un código de usuario basado en los datos del formulario.
            GeneradordeCodigoUsuarioFromForm();

            // Carga los roles en el ComboBox correspondiente.
            CargarRolesComboBox();

            // Configura el ErrorProvider para que no parpadee.
            errorProviderUsuario.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // Establece límites de longitud máxima en los campos de texto.
            LimitesTextboxes();

            // Configura los eventos KeyPress para campos específicos.
            txtCedula.KeyPress += new KeyPressEventHandler(txtCedulae_KeyPress);
            txtTelefono.KeyPress += new KeyPressEventHandler(txtTelefono_KeyPress);

            // Obtiene y muestra el siguiente ID disponible para un nuevo usuario.
            int siguienteID = UsuarioDAO.ObtenerSiguienteID();
            lblidDetalleUsuario.Text = siguienteID.ToString();

            // Desactiva los campos de texto de nombre de usuario y contraseña por defecto.
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;

            // Configura un evento para detectar cambios en la selección del ComboBox de roles.
            cbxRol.SelectedIndexChanged += cbxRol_SelectedIndexChanged;
        }

        /// <summary>
        /// Establece límites de longitud máxima para los campos de texto del formulario.
        /// Evita que el usuario exceda el número de caracteres permitidos.
        /// </summary>
        private void LimitesTextboxes()
        {
            txtCedula.MaxLength = 13;
            txtTelefono.MaxLength = 8;

            txtPrimNombre.MaxLength = 20;
            txtPrimApellido.MaxLength = 20;

            txtSegNombre.MaxLength = 20;
            txtSegApellido.MaxLength = 20;

            txtDireccion.MaxLength = 200;
        }
       
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        /// <summary>
        /// Método encargado de validar los campos del formulario de registro de usuario.
        /// Verifica que los campos de texto no estén vacíos, que los campos de selección tengan una opción válida,
        /// que los valores ingresados en los campos de correo, cédula y teléfono sean correctos y que no contengan errores comunes como espacios consecutivos o al inicio/final.
        /// </summary>
        /// <returns>Devuelve true si no hay errores en los campos, false si hay algún error.</returns>
        public bool ValidarCampos()
        {
            okError = true;

            // Lista de los campos obligatorios (que no aceptan nulos ni vacíos, pero no tienen validaciones especiales)
            List<System.Windows.Forms.TextBox> generalMandatoryFields = new List<System.Windows.Forms.TextBox>
            {
                txtPassword, txtUsername, txtDireccion, txtTelefono, txtCedula
            };

            // Lista de los campos obligatorios con validaciones adicionales (no aceptan espacios ni vacíos)
            List<System.Windows.Forms.TextBox> nameMandatoryFields = new List<System.Windows.Forms.TextBox>
            {
                txtPrimNombre, txtPrimApellido
            };

            // Lista de los campos opcionales (permiten nulos o vacíos, pero verifican espacios si tienen texto)
            List<System.Windows.Forms.TextBox> optionalFields = new List<System.Windows.Forms.TextBox>
            {
                txtSegNombre, txtSegApellido
            };

            // Lista de campos ComboBox para validar
            List<System.Windows.Forms.ComboBox> comboBoxList = new List<System.Windows.Forms.ComboBox> { cbxEsatdoCivil, cbxRol };

            // Validación para los campos obligatorios
            // Validación para los campos obligatorios generales
            foreach (System.Windows.Forms.TextBox textBox in generalMandatoryFields)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text)) // Campo vacío
                {
                    okError = false;
                    errorProviderUsuario.SetError(textBox, "El campo no puede estar vacío.");
                    textBox.BackColor = Color.LightPink;
                }
                else if (Regex.IsMatch(textBox.Text, @"\s{2,}")) // Espacios consecutivos
                {
                    okError = false;
                    errorProviderUsuario.SetError(textBox, "El texto no puede contener espacios consecutivos.");
                    textBox.BackColor = Color.LightPink;
                }
                else if (textBox.Text.StartsWith(" ") || textBox.Text.EndsWith(" ")) // Espacios al inicio o final
                {
                    okError = false;
                    errorProviderUsuario.SetError(textBox, "El texto no puede comenzar ni terminar con espacios.");
                    textBox.BackColor = Color.LightPink;
                }
                else
                {
                    // Si pasa la validación, elimina los errores y restablece el fondo
                    errorProviderUsuario.SetError(textBox, string.Empty);
                    textBox.BackColor = Color.White;
                }
            }


            // Validación para los nombres obligatorios (sin espacios)
            foreach (System.Windows.Forms.TextBox textBox in nameMandatoryFields)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text)) // Campo vacío
                {
                    okError = false;
                    errorProviderUsuario.SetError(textBox, "El campo no puede estar vacío.");
                    textBox.BackColor = Color.LightPink;
                }
                else if (Regex.IsMatch(textBox.Text, @"\s{1,}")) // Verifica espacios consecutivos
                {
                    okError = false;
                    errorProviderUsuario.SetError(textBox, "El texto no puede contener espacios.");
                    textBox.BackColor = Color.LightPink;
                }
                else if (textBox.Text.StartsWith(" ") || textBox.Text.EndsWith(" ")) // Espacios al inicio o final
                {
                    okError = false;
                    errorProviderUsuario.SetError(textBox, "El texto no puede comenzar ni terminar con espacios.");
                    textBox.BackColor = Color.LightPink;
                }
                else
                {
                    // Si pasa la validación, elimina los errores y restablece el fondo
                    errorProviderUsuario.SetError(textBox, string.Empty);
                    textBox.BackColor = Color.White;
                }
            }

            // Validación para los campos opcionales
            foreach (System.Windows.Forms.TextBox textBox in optionalFields)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text)) // Solo valida si tiene texto
                {
                    if (Regex.IsMatch(textBox.Text, @"\s{1,}")) // Espacios consecutivos
                    {
                        okError = false;
                        errorProviderUsuario.SetError(textBox, "El texto no puede contener espacios consecutivos.");
                        textBox.BackColor = Color.LightPink;
                    }
                    else if (textBox.Text.StartsWith(" ") || textBox.Text.EndsWith(" ")) // Espacios al inicio o final
                    {
                        okError = false;
                        errorProviderUsuario.SetError(textBox, "El texto no puede comenzar ni terminar con espacios.");
                        textBox.BackColor = Color.LightPink;
                    }
                    else
                    {
                        // Si pasa todas las validaciones, elimina los errores y restablece el fondo
                        errorProviderUsuario.SetError(textBox, string.Empty);
                        textBox.BackColor = Color.White;
                    }
                }
                else
                {
                    // Si el campo está vacío, elimina cualquier error y deja el fondo blanco
                    errorProviderUsuario.SetError(textBox, string.Empty);
                    textBox.BackColor = Color.White;
                }
            }

            // Validación de los campos ComboBox
            foreach (System.Windows.Forms.ComboBox comboBoxListValid in comboBoxList)
            {
                // Verifica si no se ha seleccionado una opción válida
                if (comboBoxListValid.SelectedIndex == -1)
                {
                    okError = false;
                    errorProviderUsuario.SetError(comboBoxListValid, "Seleccione una opción.");
                    comboBoxListValid.BackColor = Color.OldLace;
                }
                else
                {
                    // Elimina el error y restablece el fondo a blanco
                    errorProviderUsuario.SetError(comboBoxListValid, "");
                    comboBoxListValid.BackColor = SystemColors.Window;
                }
            }

            // Validación de correo electrónico utilizando una función externa
            string correoIngresado = txtEmail.Text;
            if (!ValidarCorreo(correoIngresado))
            {
                okError = false;
                errorProviderUsuario.SetError(txtEmail, "Ingrese un correo válido.");
                txtEmail.BackColor = Color.OldLace;
            }
            else
            {
                errorProviderUsuario.SetError(txtEmail, "");
                txtEmail.BackColor = SystemColors.Window;
            }

            // Validación de cédula (debe tener exactamente 13 dígitos numéricos)
            if (txtCedula.Text.Length != 13 || !txtCedula.Text.All(char.IsDigit))
            {
                okError = false;
                errorProviderUsuario.SetError(txtCedula, "La cédula debe tener 13 dígitos.");
                txtCedula.BackColor = Color.OldLace;
            }
            else
            {
                errorProviderUsuario.SetError(txtCedula, "");
                txtCedula.BackColor = SystemColors.Window;
            }

            // Validación de teléfono (debe tener exactamente 8 dígitos numéricos)
            if (txtTelefono.Text.Length != 8 || !txtTelefono.Text.All(char.IsDigit))
            {
                okError = false;
                errorProviderUsuario.SetError(txtTelefono, "El teléfono debe tener 8 dígitos.");
                txtTelefono.BackColor = Color.OldLace;
            }
            else
            {
                errorProviderUsuario.SetError(txtTelefono, "");
                txtTelefono.BackColor = SystemColors.Window;
            }

            // Validación de longitud mínima para el primer nombre y apellido
            if (txtPrimNombre.Text.Length < 3)
            {
                okError = false;
                errorProviderUsuario.SetError(txtPrimNombre, "El primer nombre debe tener más de 3 caracteres.");
                txtPrimNombre.BackColor = Color.OldLace;
            }

            if (txtPrimApellido.Text.Length < 3)
            {
                okError = false;
                errorProviderUsuario.SetError(txtPrimApellido, "El primer apellido debe tener más de 3 caracteres.");
                txtPrimApellido.BackColor = Color.OldLace;
            }

            return okError;
        }

        /// <summary>
        /// Valida si un correo electrónico cumple con un formato correcto.
        /// Utiliza una expresión regular para verificar que el correo sea válido.
        /// </summary>
        /// <param name="correo">El correo electrónico que se desea validar.</param>
        /// <returns>
        /// <c>true</c> si el correo tiene un formato válido; 
        /// <c>false</c> en caso contrario.
        /// </returns>
        public bool ValidarCorreo(string correo)
        {
            // Expresión regular para validar el formato de un correo electrónico.
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Retorna true si el correo coincide con el patrón, false en caso contrario.
            return Regex.IsMatch(correo, patronCorreo);
        }

        /// <summary>
        /// Maneja el evento de cambio de selección en el ComboBox de roles.
        /// Carga los puestos correspondientes dependiendo del rol seleccionado
        /// (Administrador o Empleado).
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void cbxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRol.SelectedValue is DataRowView dataRowView)
            {
                int codigoRolSeleccionado = Convert.ToInt32(dataRowView["Id_Rol"]);

                if (codigoRolSeleccionado == 1) // 1 para Administrador
                {
                    CargarPuestosAdminsComboBox();
                }
                else if (codigoRolSeleccionado == 2) // 2 para Empleado
                {
                    CargarPuestosEmpleadosComboBox();
                }
            }
            else if (cbxRol.SelectedValue != null)
            {
                int codigoRolSeleccionado = Convert.ToInt32(cbxRol.SelectedValue);

                if (codigoRolSeleccionado == 1)
                {
                    CargarPuestosAdminsComboBox();
                }
                else if (codigoRolSeleccionado == 2)
                {
                    CargarPuestosEmpleadosComboBox();
                }
                
            }
        }

        /// <summary>
        /// Carga los puestos disponibles para administradores en el ComboBox de puestos.
        /// También habilita y muestra los controles necesarios para ingresar usuario y clave.
        /// </summary>
        public void CargarPuestosEmpleadosComboBox()
        {
            DataTable dtPuestos = UsuarioDAO.ObtenerPuestosDeEmpleadosParaComboBox();

            lblUser.Show();
            lblClave.Show();

            txtUsername.Show();
            txtPassword.Show();
            btnGeneradorUsername.Show();
            btnGeneradorPassword.Show();

            btnGeneradorPassword.Enabled = true;
            btnGeneradorUsername.Enabled = true;

            cbPuesto.DataSource = dtPuestos;
            cbPuesto.DisplayMember = "puesto";
            cbPuesto.ValueMember = "IdPuesto";
        }

        /// <summary>
        /// Carga los puestos disponibles para empleados en el ComboBox de puestos.
        /// También habilita y muestra los controles necesarios para ingresar usuario y clave.
        /// </summary>
        public void CargarPuestosAdminsComboBox()
        {
            DataTable dtPuestos = UsuarioDAO.ObtenerPuestosDeAdminsParaComboBox();
            lblUser.Show();
            lblClave.Show();

            txtUsername.Show();
            txtPassword.Show();
            btnGeneradorUsername.Show();
            btnGeneradorPassword.Show();

            btnGeneradorPassword.Enabled = true;
            btnGeneradorUsername.Enabled = true;

            cbPuesto.DataSource = dtPuestos;
            cbPuesto.DisplayMember = "puesto";
            cbPuesto.ValueMember = "IdPuesto";
        }

        /// <summary>
        /// Carga los roles disponibles en el ComboBox de roles desde la base de datos.
        /// </summary>
        private void CargarRolesComboBox()
        {
            DataTable dtRoles = UsuarioDAO.ObtenerRolesParaComboBox();

            cbxRol.DataSource = dtRoles;
            cbxRol.DisplayMember = "Rol";
            cbxRol.ValueMember = "Id_Rol";
        }

        /// <summary>
        /// Genera un nuevo código de usuario utilizando el controlador de generación de códigos.
        /// Actualiza el campo de texto correspondiente con el código generado.
        /// </summary>
        private void GeneradordeCodigoUsuarioFromForm()
        {
            nuevoCodigoUsuario = _controladorGeneradorCodigo.GeneradordeCodigoUsuario();
            txtCodigoGenerado.Text = nuevoCodigoUsuario;
        }

        /// <summary>
        /// Genera un nombre de usuario o contraseña basados en el primer nombre,
        /// primer apellido y un número aleatorio.
        /// </summary>
        /// <returns>
        /// El código generado (nombre de usuario o contraseña, dependiendo de la opción seleccionada).
        /// </returns>
        public string GeneradordeNombreDeUsuarioYClave()
        {
            // Obtener datos base para generar el nombre de usuario o contraseña.
            string nombreUser = txtPrimNombre.Text;
            string apellUser = txtPrimApellido.Text;
            string username = nombreUser + "." + apellUser;

            // Generar un número aleatorio para agregar al nombre.
            string numeroAleatorio = new Random().Next(1000, 9999).ToString();
            string codigoGeneradoUsername = $"{username}-{numeroAleatorio}";
            string codigoGeneradoPassword = $"{nombreUser}-{numeroAleatorio}";

            // Determinar si se genera un usuario o una contraseña.
            if (isTheUsername == true)
            {
                txtUsername.Text = codigoGeneradoUsername;
                return codigoGeneradoUsername;
            }
            else
            {
                txtPassword.Text = codigoGeneradoPassword;
                return codigoGeneradoPassword;
            }
        }

        /// <summary>
        /// Genera un nombre de usuario basado en el nombre y apellido ingresados.
        /// Actualiza el campo de texto de usuario con el valor generado.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnGeneradorUsername_Click(object sender, EventArgs e)
        {
            isTheUsername = true;
            GeneradordeNombreDeUsuarioYClave();
        }

        /// <summary>
        /// Genera una contraseña basada en el nombre ingresado y un número aleatorio.
        /// Actualiza el campo de texto de contraseña con el valor generado.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnGeneradorPassword_Click(object sender, EventArgs e)
        {
            isTheUsername = false;
            GeneradordeNombreDeUsuarioYClave();
        }

        /// <summary>
        /// Maneja el evento del botón "Cancelar".
        /// Cierra el formulario actual.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Maneja el evento del botón "Agregar Puesto".
        /// Abre el formulario de registro de puestos y cierra el formulario actual.
        /// </summary>
        private void btnAddPuesto_Click(object sender, EventArgs e)
        {
            PuestosRegistro frmPuestoRegistro = new PuestosRegistro();
            frmPuestoRegistro.Show();
            this.Close();
        }

        /// <summary>
        /// Maneja el evento TextChanged del campo de cédula.
        /// Valida que la cédula tenga exactamente 13 dígitos y muestra un error si no se cumple.
        /// Cambia el color de fondo del campo según la validez de la entrada.
        /// </summary>
        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            txtCedula.BackColor = Color.White;
            if (!string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                if (txtCedula.Text.Length == 13)
                {
                    errorProviderUsuario.SetError(txtCedula, string.Empty);
                    txtCedula.BackColor = Color.White;
                }
                else
                {
                    errorProviderUsuario.SetError(txtCedula, "La cédula debe contener exactamente 13 dígitos.");
                    txtCedula.BackColor = Color.LightYellow;
                }
            }
            else
            {
                errorProviderUsuario.SetError(txtCedula, "La cédula no puede estar vacía.");
                txtCedula.BackColor = Color.LightPink;
            }
        }

        /// <summary>
        /// Maneja el evento TextChanged del campo de primer nombre.
        /// Valida que el campo contenga al menos 3 caracteres, solo letras, y no esté vacío.
        /// Cambia el color de fondo del campo según la validez de la entrada.
        /// </summary>
        private void txtPrimNombre_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPrimNombre.Text) && txtPrimNombre.Text.All(char.IsLetter))
            {
                if (txtPrimNombre.Text.Length > 2)
                {
                    errorProviderUsuario.SetError(txtPrimNombre, string.Empty);
                    txtPrimNombre.BackColor = Color.White;
                }
                else
                {
                    errorProviderUsuario.SetError(txtPrimNombre, "El primer nombre debe tener al menos 3 caracteres.");
                    txtPrimNombre.BackColor = Color.LightYellow;
                }
            }
            else
            {
                errorProviderUsuario.SetError(txtPrimNombre, "El primer nombre debe contener solo letras y no puede estar vacío.");
                txtPrimNombre.BackColor = Color.LightPink;
            }
        }

        /// <summary>
        /// Maneja el evento TextChanged del campo de primer apellido.
        /// Valida que el campo contenga al menos 3 caracteres, solo letras, y no esté vacío.
        /// Cambia el color de fondo del campo según la validez de la entrada.
        /// </summary>
        private void txtPrimApellido_TextChanged(object sender, EventArgs e)
        {
            txtPrimApellido.BackColor = Color.White;

            if (!string.IsNullOrWhiteSpace(txtPrimApellido.Text) && txtPrimApellido.Text.All(char.IsLetter))
            {
                if (txtPrimApellido.Text.Length > 2)
                {
                    errorProviderUsuario.SetError(txtPrimApellido, string.Empty);
                }
                else
                {
                    errorProviderUsuario.SetError(txtPrimApellido, "El primer apellido debe tener al menos 3 caracteres.");
                    txtPrimApellido.BackColor = Color.LightYellow;
                }
            }
            else
            {
                errorProviderUsuario.SetError(txtPrimApellido, "El primer apellido debe contener solo letras y no puede estar vacío.");
                txtPrimApellido.BackColor = Color.LightPink;
            }
        }

        /// <summary>
        /// Maneja el evento TextChanged del campo de dirección.
        /// Valida que el campo no esté vacío y muestra un error en caso contrario.
        /// Cambia el color de fondo del campo según la validez de la entrada.
        /// </summary>
        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            txtDireccion.BackColor = Color.White;
            if (!string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                errorProviderUsuario.SetError(txtDireccion, string.Empty);
            }
            else
            {
                errorProviderUsuario.SetError(txtDireccion, "La dirección no puede estar vacía.");
                txtDireccion.BackColor = Color.LightPink;
            }
        }

        /// <summary>
        /// Maneja el evento TextChanged del campo de teléfono.
        /// Valida que el campo contenga exactamente 8 dígitos numéricos y no esté vacío.
        /// Cambia el color de fondo del campo según la validez de la entrada.
        /// </summary>
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            txtTelefono.BackColor = Color.White;

            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) && txtTelefono.Text.All(char.IsDigit))
            {
                if (txtTelefono.Text.Length == 8)
                {
                    errorProviderUsuario.SetError(txtTelefono, string.Empty);
                }
                else
                {
                    errorProviderUsuario.SetError(txtTelefono, "El teléfono debe contener exactamente 8 dígitos.");
                    txtTelefono.BackColor = Color.LightYellow;
                }
            }
            else
            {
                errorProviderUsuario.SetError(txtTelefono, "El teléfono debe contener solo números y no puede estar vacío.");
                txtTelefono.BackColor = Color.LightPink;
            }
        }

        /// <summary>
        /// Maneja el evento SelectedIndexChanged del combo box de estado civil.
        /// Valida que se haya seleccionado un estado civil y muestra un error si no.
        /// Cambia el color de fondo del campo según la validez de la entrada.
        /// </summary>
        private void cbxEsatdoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxEsatdoCivil.BackColor = Color.White;
            if (cbxEsatdoCivil.SelectedItem != null)
            {
                errorProviderUsuario.SetError(cbxEsatdoCivil, string.Empty);
            }
            else
            {
                errorProviderUsuario.SetError(cbxEsatdoCivil, "Debe seleccionar un estado civil.");
                cbxEsatdoCivil.BackColor = Color.LightPink;
            }
        }

        /// <summary>
        /// Maneja el evento TextChanged del campo de correo electrónico.
        /// Implementar validación para asegurar que el correo sea válido.
        /// Cambia el color de fondo del campo según la validez de la entrada.
        /// </summary>
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.White;
            
        }

        /// <summary>
        /// Maneja el evento TextChanged del campo de nombre de usuario.
        /// Valida que el nombre de usuario no esté vacío, y que contenga solo letras, dígitos o el carácter '.'.
        /// Limpia el error si la entrada es válida, de lo contrario muestra el mensaje de error.
        /// </summary>
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.White;
            if (!string.IsNullOrWhiteSpace(txtUsername.Text) && txtUsername.Text.All(c => char.IsLetterOrDigit(c) || c == '.'))
            {
                errorProviderUsuario.SetError(txtUsername, string.Empty);
            }
        }

        /// <summary>
        /// Maneja el evento TextChanged del campo de contraseña.
        /// Valida que la contraseña tenga al menos 8 caracteres.
        /// Si la contraseña es válida, limpia el mensaje de error, de lo contrario muestra un mensaje de error.
        /// </summary>
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            if (!string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text.Length >= 8)
            {
                errorProviderUsuario.SetError(txtPassword, string.Empty);
            }
            else
            {
                errorProviderUsuario.SetError(txtPassword, "La contraseña debe tener al menos 8 caracteres.");
            }

        }
        // Método para validar el primer nombre (solo letras y espacios)
        private void txtPrimNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si el carácter no es una letra, espacio o tecla de control, se bloquea
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        // Método para validar el segundo nombre (solo letras y espacios)
        private void txtSegNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Bloquea cualquier carácter que no sea una letra, espacio o tecla de control
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea el carácter
            }
        }
        // Método para validar el primer apellido (solo letras y espacios)
        private void txtPrimApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Bloquea cualquier carácter que no sea una letra, espacio o tecla de control
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        // Método para validar el segundo apellido (solo letras y espacios)
        private void txtSegApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Bloquea cualquier carácter que no sea una letra, espacio o tecla de control
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea el carácter
            }
        }
        // Método para validar la cédula (solo números)
        private void txtCedulae_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si el carácter no es un número o tecla de control, se bloquea
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        // Método para validar el nombre de usuario (solo letras, números, espacios, puntos y guiones)
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Bloquea cualquier carácter que no sea letra, número, espacio, punto o guion
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true; // Bloquea el carácter
            }
        }
        // Método para validar la contraseña (letras, números, guiones y guion bajo)
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Bloquea cualquier carácter que no sea letra, número, tecla de control, guion o guion bajo
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '_')
            {
                e.Handled = true; // Bloquea el carácter
            }
        }


    }
}

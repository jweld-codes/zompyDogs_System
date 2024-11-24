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
    public partial class UsuarioRegistro : Form
    {
        private ControladorGeneradoresDeCodigo _controladorGeneradorCodigo;

        private string nuevoCodigoUsuario;
        private bool isTheUsername = false;
        private int contUser;
        public bool okError = true;

        public UsuarioRegistro()
        {
            InitializeComponent();

            _controladorGeneradorCodigo = new ControladorGeneradoresDeCodigo();

            GeneradordeCodigoUsuarioFromForm();
            CargarRolesComboBox();

            errorProviderUsuario.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            txtCedula.MaxLength = 13;
            txtTelefono.MaxLength = 8;

            txtCedula.KeyPress += new KeyPressEventHandler(txtCedulae_KeyPress);
            txtTelefono.KeyPress += new KeyPressEventHandler(txtTelefono_KeyPress);

            int siguienteID = UsuarioDAO.ObtenerSiguienteID();
            lblidDetalleUsuario.Text = siguienteID.ToString();
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            cbxRol.SelectedIndexChanged += cbxRol_SelectedIndexChanged;

            LimitesTextboxes();

        }

        private void LimitesTextboxes()
        {
            txtPrimNombre.MaxLength = 20;
            txtPrimApellido.MaxLength = 20;

            txtSegNombre.MaxLength = 20;
            txtSegApellido.MaxLength = 20;

            txtDireccion.MaxLength = 200;
        }
        private void txtCedulae_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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
            // Variable para indicar si existen errores en los campos.
            okError = true;

            // Lista de los campos de texto a validar (excluyendo los nombres y apellidos)
            List<System.Windows.Forms.TextBox> textBoxes = new List<System.Windows.Forms.TextBox> { txtPrimNombre, txtPrimApellido, txtPassword, txtUsername, txtDireccion, txtTelefono, txtCedula };

            // Lista de campos de texto que corresponden a nombres y apellidos
            List<System.Windows.Forms.TextBox> textBoxesNames = new List<System.Windows.Forms.TextBox> { txtPrimNombre, txtPrimApellido, txtSegNombre, txtSegApellido };

            // Lista de campos ComboBox para validar
            List<System.Windows.Forms.ComboBox> comboBoxList = new List<System.Windows.Forms.ComboBox> { cbxEsatdoCivil, cbxRol };

            // Validación de los campos de texto generales
            foreach (System.Windows.Forms.TextBox textBox in textBoxes)
            {
                // Verifica si el campo está vacío o solo contiene espacios
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    okError = false;
                    errorProviderUsuario.SetError(textBox, $"Ingrese un valor en el campo.");
                    textBox.BackColor = Color.OldLace;  // Cambia el fondo a color amarillo para indicar error
                }
                else
                {
                    // Elimina cualquier error previo y restablece el fondo a blanco
                    errorProviderUsuario.SetError(textBox, "");
                    textBox.BackColor = SystemColors.Window;
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
                    comboBoxListValid.BackColor = Color.OldLace;  // Cambia el fondo a color amarillo para indicar error
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
                errorProviderUsuario.SetError(txtPrimNombre, "El primer nombre debe tener no más de 20 caracteres.");
                txtPrimNombre.BackColor = Color.OldLace;
            }
            if (txtPrimNombre.Text.Length > 20)
            {
                okError = false;
                errorProviderUsuario.SetError(txtPrimNombre, "El primer nombre debe tener no más de 20 caracteres.");
                txtPrimNombre.BackColor = Color.OldLace;
            }

            if (txtSegApellido.Text.Length > 20)
            {
                okError = false;
                errorProviderUsuario.SetError(txtPrimApellido, "El primer apellido debe tener no más de 20 caracteres.");
                txtPrimApellido.BackColor = Color.OldLace;
            }
            if (txtSegNombre.Text.Length > 20)
            {
                okError = false;
                errorProviderUsuario.SetError(txtPrimNombre, "El primer apellido debe tener no más de 20 caracteres.");
                txtPrimNombre.BackColor = Color.OldLace;
            }


            // Validación de espacios en blanco
            foreach (System.Windows.Forms.TextBox textBoxSpace in textBoxes)
            {
                // Verifica si el texto contiene múltiples espacios consecutivos
                if (Regex.IsMatch(textBoxSpace.Text, @"\s{2,}"))
                {
                    okError = false;
                    errorProviderUsuario.SetError(textBoxSpace, "El texto no puede contener múltiples espacios consecutivos.");
                    textBoxSpace.BackColor = Color.LightPink;
                }

                // Verifica si el texto comienza o termina con espacios
                if (textBoxSpace.Text.StartsWith(" ") || textBoxSpace.Text.EndsWith(" "))
                {
                    okError = false;
                    errorProviderUsuario.SetError(textBoxSpace, "El texto no puede comenzar ni terminar con espacios.");
                    textBoxSpace.BackColor = Color.LightPink;
                }
            }

            // Validación de espacios en los campos de nombres y apellidos
            foreach (System.Windows.Forms.TextBox textBoxSpaceName in textBoxesNames)
            {
                // Verifica que los campos de nombres y apellidos no contengan espacios adicionales entre palabras
                if (textBoxSpaceName.Name == "txtPrimNombre" || textBoxSpaceName.Name == "txtPrimApellido")
                {
                    if (Regex.IsMatch(textBoxSpaceName.Text, @"\s{2,}"))
                    {
                        okError = false;
                        errorProviderUsuario.SetError(textBoxSpaceName, "El texto no puede contener espacios adicionales entre las palabras.");
                        textBoxSpaceName.BackColor = Color.LightPink;
                    }
                    else
                    {
                        // Si no hay espacios consecutivos, elimina el error
                        errorProviderUsuario.SetError(textBoxSpaceName, string.Empty);
                        textBoxSpaceName.BackColor = Color.White;
                    }
                }
            }

            // Devuelve 'true' si no hubo errores, 'false' si hubo algún error
            return okError;
        }

        public bool ValidarCorreo(string correo)
        {
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patronCorreo);
        }

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
                else if (codigoRolSeleccionado == 4) // 4 para Usuario
                {
                    CargarPuestosUsuariosComboBox();


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
                else if (codigoRolSeleccionado == 4)
                {
                    CargarPuestosUsuariosComboBox();
                }
            }
        }

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
        public void CargarPuestosUsuariosComboBox()
        {
            txtUsername.Text = "------";
            txtPassword.Text = "---" + contUser + "---";

            lblUser.Hide();
            lblClave.Hide();

            txtUsername.Hide();
            txtPassword.Hide();
            btnGeneradorUsername.Hide();
            btnGeneradorPassword.Hide();

            btnGeneradorPassword.Enabled = false;
            btnGeneradorUsername.Enabled = false;
            DataTable dtPuestos = UsuarioDAO.ObtenerPuestosDeUsuariosParaComboBox();

            cbPuesto.DataSource = dtPuestos;
            cbPuesto.DisplayMember = "puesto";
            cbPuesto.ValueMember = "IdPuesto";
        }
        private void CargarRolesComboBox()
        {
            DataTable dtRoles = UsuarioDAO.ObtenerRolesParaComboBox();

            cbxRol.DataSource = dtRoles;
            cbxRol.DisplayMember = "Rol";
            cbxRol.ValueMember = "Id_Rol";
        }
        private void GeneradordeCodigoUsuarioFromForm()
        {
            nuevoCodigoUsuario = _controladorGeneradorCodigo.GeneradordeCodigoUsuario();
            txtCodigoGenerado.Text = nuevoCodigoUsuario;
        }

        private void btnGeneradorUsername_Click(object sender, EventArgs e)
        {
            isTheUsername = true;
            GeneradordeNombreDeUsuarioYClave();
        }

        public string GeneradordeNombreDeUsuarioYClave()
        {
            string nombreUser = txtPrimNombre.Text;
            string apellUser = txtPrimApellido.Text;
            string username = nombreUser + "." + apellUser;

            string numeroAleatorio = new Random().Next(1000, 9999).ToString();
            string codigoGeneradoUsername = $"{username}-{numeroAleatorio}";
            string codigoGeneradoPassword = $"{nombreUser}-{numeroAleatorio}";

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

        private void btnGeneradorPassword_Click(object sender, EventArgs e)
        {
            isTheUsername = false;
            GeneradordeNombreDeUsuarioYClave();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAddPuesto_Click(object sender, EventArgs e)
        {
            PuestosRegistro frmPuestoRegistro = new PuestosRegistro();
            frmPuestoRegistro.Show();
            this.Close();
        }

        private void btnGuardarUser_Click(object sender, EventArgs e)
        {
        }

        private void btnGuardarUser_Click_1(object sender, EventArgs e)
        {

        }

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

        private void txtPrimNombre_TextChanged(object sender, EventArgs e)
        {
            txtPrimNombre.BackColor = Color.White;

            if (!string.IsNullOrWhiteSpace(txtPrimNombre.Text) && txtPrimNombre.Text.All(char.IsLetter))
            {
                if (txtPrimNombre.Text.Length > 2)
                {
                    errorProviderUsuario.SetError(txtPrimNombre, string.Empty);
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

        private void txtSegNombre_TextChanged(object sender, EventArgs e)
        {
          txtSegNombre.BackColor = Color.White;

            if (!string.IsNullOrWhiteSpace(txtSegNombre.Text) && txtSegNombre.Text.All(char.IsLetter))
            {

            }
        }

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

        private void txtSegApellido_TextChanged(object sender, EventArgs e)
        {
          /*  txtSegApellido.BackColor = Color.White;

            if (!string.IsNullOrWhiteSpace(txtSegApellido.Text) && txtSegApellido.Text.All(char.IsLetter))
            {
                if (txtSegApellido.Text.Length >= 15)
                {
                    errorProviderUsuario.SetError(txtSegApellido, string.Empty);
                }
                else
                {
                    errorProviderUsuario.SetError(txtSegApellido, "El segundo apellido debe tener al menos 15 caracteres.");
                    txtSegApellido.BackColor = Color.LightYellow;
                }
            }
            else
            {
                errorProviderUsuario.SetError(txtSegApellido, "El segundo apellido debe contener solo letras y no puede estar vacío.");
                txtSegApellido.BackColor = Color.LightPink;
            } */
        }

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
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.White;
            
        }

        private void txtPrimNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void txtSegNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtPrimApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }

        }
        private void txtSegApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.White;
            if (!string.IsNullOrWhiteSpace(txtUsername.Text) && txtUsername.Text.All(c => char.IsLetterOrDigit(c) || c == '.'))
            {
                errorProviderUsuario.SetError(txtUsername, string.Empty);
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '_')
            {
                e.Handled = true;
            }

        }

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
    }
}

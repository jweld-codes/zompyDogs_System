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
using static ZompyDogsDAO.PeticionesValidaciones;
using static ZompyDogsDAO.UsuarioDAO;

namespace zompyDogs
{
    public partial class AjustesCuenta : Form
    {
        public BienvenidaAdmin FormPrincipal { get; set; }
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }

        private int usuarioIDActual;
        public int IdEmpleado { get; set; }
        public string NombreUsuarioAjuste { get => lblTituloRegistroPanel.Text; set => lblTituloRegistroPanel.Text = value; }

        public string PeticionAccionVal;
        public string PeticionCodigoVal;
        public string PeticionVal;
        public DateTime PeticionFecha_De_EnvioVal;
        public string PeticionDescripcionVal;
        public string PeticionEstadoVal;
        public string PeticionUsuarioVal;
        public string PeticionUsuarioGuardar;
        public int PeticionUsuarioID;
        public bool isError;
        public AjustesCuenta(int usuarioID, string usuarioNombre)
        {
            InitializeComponent();

            IdEmpleado = usuarioID;
            NombreUsuarioAjuste = usuarioNombre;

            CargarPeticiones();

            errorProviderPeticion.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            txtTelefono.MaxLength = 8;

            gbxDatosPersonales.Hide();
            gbxDatosUsuarios.Hide();
            gbxPeticionesBtn.Show();
            gbxPeticiones.Show();

            btnConfirmarPer.Hide();
            btnCancelarPer.Hide();
            btnConfirmarUs.Hide();
            btnCancelarUs.Hide();

            btnDatosPersonales.Hide();
            btnDatosUsuarios.Hide();

            rectanglePanel1.Hide();
            rectanglePanel2.Hide();
            rectanglePanel3.Show();

            //CheckBox Changed
            chbxLunes.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxMartes.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxMiercoles.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxJueves.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxViernes.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxSabado.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            // chbxDomingo.CheckedChanged += (s, e) => ActualizarDiasLaborales();

            DatosUsuario();
            DatosDelUsuario();
        }
        public void InicializarAdmin()
        {
            BienvenidaAdmin frmBienvenidaForm = new BienvenidaAdmin();
            NombreUsuarioAjuste = frmBienvenidaForm.lblNombreSideBar.Text;
        }
        public void CargarPeticiones()
        {
            DataTable peticiones = PeticionesValidaciones.ObtenerPeticionesCompletasAjustes(IdEmpleado);
            dgvPeticiones.DataSource = peticiones;

            dgvPeticiones.Columns["Codigo"].HeaderText = "Código";
            dgvPeticiones.Columns["Accion"].HeaderText = "Acción";
            dgvPeticiones.Columns["Peticion"].HeaderText = "Petición";
            dgvPeticiones.Columns["Fecha_De_Envio"].HeaderText = "Fecha de Envío";
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioRegistro addNuevoRegistro = new UsuarioRegistro();
            addNuevoRegistro.lblTituloRegistro.Text = "Editar Cuenta";
            addNuevoRegistro.btnGuardarUser.Text = "EDITAR";
            addNuevoRegistro.Show();
        }

        private void btnDatosPersonales_Click(object sender, EventArgs e)
        {
            gbxDatosPersonales.Show();
            gbxDatosUsuarios.Hide();
            gbxPeticiones.Hide();
            gbxPeticionesBtn.Hide();

            rectanglePanel1.Show();
            rectanglePanel2.Hide();
            rectanglePanel3.Hide();
        }

        private void btnDatosUsuarios_Click(object sender, EventArgs e)
        {
            gbxDatosPersonales.Hide();
            gbxDatosUsuarios.Show();

            gbxPeticiones.Hide();
            gbxPeticionesBtn.Hide();

            rectanglePanel1.Hide();
            rectanglePanel2.Show();
            rectanglePanel3.Hide();
        }

        private void btnUsuarioPanel_Click(object sender, EventArgs e)
        {
            gbxDatosPersonales.Show();
            gbxDatosUsuarios.Hide();

            rectanglePanel1.Show();
            rectanglePanel2.Hide();
        }

        private void btnPeticiones_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            if (FormPrincipal != null)
            {
                FormPrincipal.AbrirFormsHija(new PeticionUsuario { FormPrincipal = FormPrincipal });
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

        private void AjustesCuenta_Load(object sender, EventArgs e)
        {

        }
        private void ActualizarDiasLaborales()
        {
            List<string> diasSeleccionados = new List<string>();

            if (chbxLunes.Checked) diasSeleccionados.Add("Lunes");
            if (chbxMartes.Checked) diasSeleccionados.Add("Martes");
            if (chbxMiercoles.Checked) diasSeleccionados.Add("Miércoles");
            if (chbxJueves.Checked) diasSeleccionados.Add("Jueves");
            if (chbxViernes.Checked) diasSeleccionados.Add("Viernes");
            if (chbxSabado.Checked) diasSeleccionados.Add("Sábado");
            // if (//chbxDomingo.Checked) diasSeleccionados.Add("Domingo");

            txtDiasLaborales.Text = string.Join(",", diasSeleccionados);
        }

        public void DatosUsuario()
        {
            txtPrimerNombre.Enabled = false;
            txtSegNombre.Enabled = false;
            txtPrimApe.Enabled = false;
            txtSegApe.Enabled = false;

            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            cbxEstadoCivil.Enabled = false;
            dtpFechaNacimiento.Enabled = false;


            DataTable ajusteCuentaView = UsuarioDAO.ObtenerDetalllesDeUsuariosParaEditarPorID(IdEmpleado);

            if (ajusteCuentaView.Rows.Count > 0)
            {
                DataRow fila = ajusteCuentaView.Rows[0];

                txtCodigoGenerado.Text = fila["Codigo"].ToString();
                txtCedula.Text = fila["ID_Cedula"].ToString();

                txtPrimerNombre.Text = fila["Nombre_Usuario"].ToString();
                txtSegNombre.Text = fila["Segundo_Nombre"].ToString();
                txtPrimApe.Text = fila["Apellido_Usuario"].ToString();
                txtSegApe.Text = fila["Segundo_Apellido"].ToString();

                txtTelefono.Text = fila["Telefono"].ToString();
                txtDireccion.Text = fila["Direccion"].ToString();
                dtpFechaNacimiento.Text = fila["Fecha_De_Nacimiento"].ToString();
                cbxEstadoCivil.Text = fila["Estado_Civil"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontraron detalles para el pedido especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DatosDelUsuario()
        {
            seeIcon.Enabled = false;
            seeCloseIcon.Enabled = false;
            txtRol.Enabled = false;
            txtSalario.Enabled = false;
            txtPuesto.Enabled = false;
            txtHoras.Enabled = false;

            gbxDias.Enabled = false;

            DataTable ajusteCuentaView = UsuarioDAO.ObtenerDetalllesDeUsuariosParaEditarPorID(IdEmpleado);
            string diasLaboralesSeleccionadas = txtDiasLaborales.Text;

            if (ajusteCuentaView != null && ajusteCuentaView.Rows.Count > 0)
            {
                DataRow fila = ajusteCuentaView.Rows[0];

                txtCodigoGeneradoUser.Text = fila["Codigo"].ToString();
                txtUser.Text = fila["Usuario"].ToString();
                txtEmail.Text = fila["Correo"].ToString();
                txtClave.Text = fila["Clave"].ToString();

                txtRol.Text = fila["RolUsuario"].ToString();

                txtPuesto.Text = fila["Puesto"].ToString();
                txtSalario.Text = fila["Salario"].ToString();
                txtHoras.Text = fila["HorasLaborales"].ToString();



                string diasLaborales = fila["DiasLaborales"].ToString();
                chbxLunes.Checked = diasLaborales.Contains("Lunes");
                chbxMartes.Checked = diasLaborales.Contains("Martes");
                chbxMiercoles.Checked = diasLaborales.Contains("Miércoles");
                chbxJueves.Checked = diasLaborales.Contains("Jueves");
                chbxViernes.Checked = diasLaborales.Contains("Viernes");
                chbxSabado.Checked = diasLaborales.Contains("Sábado");
                //chbxDomingo.Checked = diasLaborales.Contains("Domingo");
            }
            else
            {
                MessageBox.Show("No se encontraron detalles para el usuario especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPeticionesUser_Click(object sender, EventArgs e)
        {
            gbxDatosPersonales.Hide();
            gbxDatosUsuarios.Hide();

            gbxPeticiones.Show();
            gbxPeticionesBtn.Show();

            rectanglePanel1.Hide();
            rectanglePanel2.Hide();
            rectanglePanel3.Show();
        }

        private void btnAgregarRegistro_Click(object sender, EventArgs e)
        {

            var peticionesRegistro = new PeticionesRegisro(IdEmpleado);
            peticionesRegistro.lblTituloRegistro.Text = "Guardar Nueva Petición";
            peticionesRegistro.Show();
            peticionesRegistro.txtUsuarioName.Hide();
            peticionesRegistro.label3.Hide();
            peticionesRegistro.btnGuardarUser.Text = "GUARDAR";
            peticionesRegistro.btnCancelar.Text = "CANCELAR";

            //metodo para guardar
            peticionesRegistro.btnGuardarUser.Click += (s, args) =>
            {
                peticionesRegistro.ValidarCampos();

                bool itsValid;
                itsValid = peticionesRegistro.okError;

                if (itsValid == false)
                {
                    peticionesRegistro.ValidarCampos();
                }
                else
                {
                    PeticionRegistro nuevaPeticion = new PeticionRegistro
                    {
                        CodigPeticion = peticionesRegistro.txtCodigoGenerado.Text,
                        AccionPeticion = peticionesRegistro.cbxPeticion.SelectedItem?.ToString() ?? string.Empty,
                        Descripcion = peticionesRegistro.txtDescripcion.Text,
                        FechaEnviada = DateTime.Now,
                        FechaRealizada = DateTime.Now,
                        CodigoUsuario = peticionesRegistro.IdEmpleado,
                        Estado = peticionesRegistro.cbxEstadoCuenta.SelectedItem?.ToString() ?? "Activo"
                    };
                    try
                    {
                        PeticionesValidaciones.GuardarPeticion(nuevaPeticion);

                        MessageBox.Show("Petición Registrada con Éxito.");
                        CargarPeticiones();
                    }
                    catch
                    {
                        MessageBox.Show("Error al actualizar la petición.");

                    }
                }

            };
        }
        private void dgvPeticiones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvPeticiones.Rows[e.RowIndex];

                PeticionCodigoVal = filaSeleccionada.Cells["Codigo"].Value.ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            PeticionesRegisro frmpeticionesRegistro = new PeticionesRegisro(2);
            frmpeticionesRegistro.btnGuardarUser.Text = "CONFIRMAR";
            frmpeticionesRegistro.btnCancelar.Text = "CANCELAR";
            frmpeticionesRegistro.lblTituloRegistro.Text = "Editar Petición";

            frmpeticionesRegistro.txtUsuarioName.Enabled = false;
            frmpeticionesRegistro.cbxEstadoCuenta.Enabled = true;

            frmpeticionesRegistro.btnCancelar.Show();

            DataTable peticionEditar = PeticionesValidaciones.ObtenerPeticionesUsuarioParaEditar(PeticionCodigoVal);

            if (peticionEditar.Rows.Count > 0)
            {
                DataRow fila = peticionEditar.Rows[0];

                frmpeticionesRegistro.txtCodigoGenerado.Text = PeticionCodigoVal;
                frmpeticionesRegistro.txtCodigoGenerado.Enabled = false;

                frmpeticionesRegistro.cbxPeticion.Text = fila["Accion"].ToString();
                frmpeticionesRegistro.txtDescripcion.Text = fila["Peticion"].ToString();
                frmpeticionesRegistro.txtUsuarioName.Text = fila["Usuario"].ToString();

                frmpeticionesRegistro.dtpFechaEnviada.Text = fila["Fecha_De_Envio"].ToString();
                frmpeticionesRegistro.dtpFechaEnviada.Enabled = false;

                frmpeticionesRegistro.cbxEstadoCuenta.Text = fila["Estado"].ToString();
            }
            frmpeticionesRegistro.Show();

            frmpeticionesRegistro.btnGuardarUser.Click += (s, args) =>
            {
                frmpeticionesRegistro.ValidarCampos();

                bool itsValid;
                itsValid = frmpeticionesRegistro.okError;

                if (itsValid == false)
                {
                    frmpeticionesRegistro.ValidarCampos();
                }
                else
                {
                    PeticionRegistro peticionActualizada = new PeticionRegistro
                    {
                        CodigPeticion = frmpeticionesRegistro.txtCodigoGenerado.Text,
                        AccionPeticion = frmpeticionesRegistro.cbxPeticion.Text,
                        Descripcion = frmpeticionesRegistro.txtDescripcion.Text,
                        FechaEnviada = frmpeticionesRegistro.dtpFechaEnviada.Value,
                        FechaRealizada = DateTime.Now,
                        CodigoUsuario = IdEmpleado,
                        Estado = frmpeticionesRegistro.cbxEstadoCuenta.Text
                    };
                    bool resultado = PeticionesValidaciones.ActualizarPeticion(peticionActualizada);

                    if (resultado)
                    {
                        CargarPeticiones();
                        frmpeticionesRegistro.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar la petición.");
                    }
                }

            };

        }

        private void btnVisualizarRegistro_Click(object sender, EventArgs e)
        {

            PeticionesRegisro frmpeticionesRegistro = new PeticionesRegisro(2);
            frmpeticionesRegistro.lblTituloRegistro.Text = "Ver Petición";

            // Deshabilitar todos los elementos del formulario
            foreach (Control control in frmpeticionesRegistro.Controls)
            {
                control.Enabled = false;
            }
            frmpeticionesRegistro.btnGuardarUser.Hide();
            frmpeticionesRegistro.btnCancelar.Text = "Salir";
            frmpeticionesRegistro.btnCancelar.Enabled = true;

            DataTable peticionEditar = PeticionesValidaciones.ObtenerPeticionesUsuarioParaEditar(PeticionCodigoVal);

            if (peticionEditar.Rows.Count > 0)
            {
                DataRow fila = peticionEditar.Rows[0];

                frmpeticionesRegistro.txtCodigoGenerado.Text = PeticionCodigoVal;
                frmpeticionesRegistro.txtCodigoGenerado.Enabled = false;

                frmpeticionesRegistro.cbxPeticion.Text = fila["Accion"].ToString();
                frmpeticionesRegistro.txtDescripcion.Text = fila["Peticion"].ToString();
                frmpeticionesRegistro.txtUsuarioName.Text = fila["Usuario"].ToString();

                frmpeticionesRegistro.dtpFechaEnviada.Text = fila["Fecha_De_Envio"].ToString();
                frmpeticionesRegistro.dtpFechaEnviada.Enabled = false;

                frmpeticionesRegistro.cbxEstadoCuenta.Text = fila["Estado"].ToString();
            }
            frmpeticionesRegistro.Show();

        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PeticionCodigoVal))
            {
                MessageBox.Show("Por favor, selecciona una petición para eliminar.");
                return;
            }

            DialogResult check = MessageBox.Show("¿Está seguro de eliminar su petición?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                bool eliminado = PeticionesValidaciones.EliminarPeticion(PeticionCodigoVal);

                if (eliminado)
                {
                    MessageBox.Show("Petición eliminada con éxito.");
                    CargarPeticiones();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la petición.");
                }
            }
        }

        private void btnEditarDatosPersonales_Click(object sender, EventArgs e)
        {
            txtPrimerNombre.Enabled = false;
            txtSegNombre.Enabled = false;
            txtPrimApe.Enabled = false;
            txtSegApe.Enabled = false;

            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            cbxEstadoCivil.Enabled = true;
            dtpFechaNacimiento.Enabled = false;

            btnEditarDatosPersonales.Hide();
            btnConfirmarPer.Show();
            btnCancelarPer.Show();
        }

        public bool ValidarCorreo(string correo)
        {
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patronCorreo);
        }
        public bool ValidarCamposUsuarios()
        {
            bool okError = true;

            List<TextBox> textBoxes = new List<TextBox> { txtTelefono, txtDireccion };
            List<System.Windows.Forms.ComboBox> comboBoxList = new List<System.Windows.Forms.ComboBox> { cbxEstadoCivil };

            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    okError = false;
                    errorProviderPeticion.SetError(textBox, $"Ingrese un valor en el campo.");
                    textBox.BackColor = Color.OldLace;
                }
                else
                {
                    errorProviderPeticion.SetError(textBox, "");
                    textBox.BackColor = SystemColors.Window;
                }
            }
            foreach (System.Windows.Forms.ComboBox comboBoxListValid in comboBoxList)
            {
                if (comboBoxListValid.SelectedIndex == -1)
                {
                    okError = false;
                    errorProviderPeticion.SetError(comboBoxListValid, "Seleccione una opción.");
                    comboBoxListValid.BackColor = Color.OldLace;
                }
                else
                {
                    errorProviderPeticion.SetError(comboBoxListValid, "");
                    comboBoxListValid.BackColor = SystemColors.Window;
                }
            }
            if (txtTelefono.Text.Length != 8 || !txtTelefono.Text.All(char.IsDigit))
            {
                okError = false;
                errorProviderPeticion.SetError(txtTelefono, "El teléfono debe tener 8 dígitos.");
                txtTelefono.BackColor = Color.OldLace;
            }
            else
            {
                errorProviderPeticion.SetError(txtTelefono, "");
                txtTelefono.BackColor = SystemColors.Window;
            }

            if (txtDireccion.Text.Length < 10)
            {
                okError = false;
                errorProviderPeticion.SetError(txtDireccion, "La dirección debe ser más de 10 carácteres.");
                txtDireccion.BackColor = Color.OldLace;
            }
            else
            {
                errorProviderPeticion.SetError(txtDireccion, "");
                txtDireccion.BackColor = SystemColors.Window;
            }

            return okError;
        }

        public bool ValidarCamposDatosUsuarios()
        {
            bool okError = true;

            List<TextBox> textBoxes = new List<TextBox> { txtUser, txtClave };

            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    okError = false;
                    errorProviderPeticion.SetError(textBox, $"Ingrese un valor en el campo.");
                    textBox.BackColor = Color.OldLace;
                }
                else
                {
                    errorProviderPeticion.SetError(textBox, "");
                    textBox.BackColor = SystemColors.Window;
                }
            }
            string correoIngresado = txtEmail.Text;
            if (!ValidarCorreo(correoIngresado))
            {
                okError = false;
                errorProviderPeticion.SetError(txtEmail, "Ingrese un correo válido.");
                txtEmail.BackColor = Color.OldLace;
            }
            else
            {
                errorProviderPeticion.SetError(txtEmail, "");
                txtEmail.BackColor = SystemColors.Window;
            }
            return okError;
        }


        private void btnConfirmarPer_Click(object sender, EventArgs e)
        {
            if (ValidarCamposUsuarios() == false)
            {
                ValidarCamposUsuarios();
            }
            else
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtCodigoGenerado.Text))
                    {
                        MessageBox.Show("Código de usuario no válido.");
                        return;
                    }

                    DetalleUsuario detalleUsuarioActualizado = new DetalleUsuario
                    {
                        primerNombre = txtPrimerNombre.Text,
                        segundoNombre = txtSegNombre.Text,
                        primerApellido = txtPrimApe.Text,
                        segundoApellido = txtSegApe.Text,
                        codigoCedula = txtCedula.Text,
                        fechaNacimiento = dtpFechaNacimiento.Value,
                        estadoCivil = cbxEstadoCivil.Text,
                        telefono = txtTelefono.Text,
                        direccion = txtDireccion.Text,
                        codigoUsuario = txtCodigoGenerado.Text
                    };

                    bool resultadoDetalle = UsuarioDAO.AjusteDetalleUsuario(detalleUsuarioActualizado);

                    if (resultadoDetalle)
                    {

                        DatosUsuario();
                        btnConfirmarPer.Hide();
                        btnCancelarPer.Hide();
                        btnEditarDatosPersonales.Show();

                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el usuario.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el usuario: " + ex.Message);
                    Console.WriteLine("Detalles de la excepción: " + ex.ToString());
                }
            }

        }

        private void btnEditarUsuario_Click_1(object sender, EventArgs e)
        {
            DatosUsuario();
            DatosDelUsuario();

            txtUser.Enabled = true;
            txtClave.Enabled = true;
            txtEmail.Enabled = true;

            btnConfirmarUs.Show();
            btnCancelarUs.Show();
            btnEditarUsuario.Hide();
            seeIcon.Enabled = true;
            seeCloseIcon.Enabled = true;
            seeCloseIcon.Show();
        }

        private void seeIcon_Click(object sender, EventArgs e)
        {
            txtClave.PasswordChar = '\0';
            seeIcon.Hide();
            seeCloseIcon.Visible = true;
        }

        private void seeCloseIcon_Click(object sender, EventArgs e)
        {
            txtClave.PasswordChar = '*';
            seeIcon.Show();
            seeCloseIcon.Hide();
        }
        private void btnConfirmarUs_Click(object sender, EventArgs e)
        {
            if (ValidarCamposDatosUsuarios() == false)
            {
                ValidarCamposDatosUsuarios();
            }
            else
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtCodigoGenerado.Text))
                    {
                        MessageBox.Show("Código de usuario no válido.");
                        return;
                    }

                    UsuarioCrear datosUsuarioUpdate = new UsuarioCrear
                    {
                        UserName = txtUser.Text,
                        PassWord = txtClave.Text,
                        Email = txtEmail.Text,
                        IDUser = IdEmpleado
                    };
                    bool resultadoDetalle = UsuarioDAO.AjusteDatosDeUsuario(datosUsuarioUpdate);

                    if (resultadoDetalle)
                    {
                        txtClave.PasswordChar = '*';

                        btnConfirmarUs.Hide();
                        btnCancelarUs.Hide();
                        btnEditarUsuario.Show();

                        txtUser.Enabled = false;
                        txtClave.Enabled = false;
                        txtEmail.Enabled = false;

                        seeIcon.Enabled = false;

                        seeCloseIcon.Hide();
                        seeIcon.Show();

                        DatosUsuario();
                        DatosDelUsuario();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el usuario.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el usuario: " + ex.Message);
                    Console.WriteLine("Detalles de la excepción: " + ex.ToString());
                }
            }

        }

        private void btnCancelarUs_Click(object sender, EventArgs e)
        {
            DatosDelUsuario();

            txtUser.Enabled = false;
            txtClave.Enabled = false;
            txtEmail.Enabled = false;

            btnConfirmarUs.Hide();
            btnCancelarUs.Hide();
            btnEditarUsuario.Show();

            seeIcon.Enabled = false;

            seeCloseIcon.Hide();
            seeIcon.Show();

        }

        private void btnCancelarPer_Click(object sender, EventArgs e)
        {
            DatosUsuario();
            txtPrimerNombre.Enabled = false;
            txtSegNombre.Enabled = false;
            txtPrimApe.Enabled = false;
            txtSegApe.Enabled = false;

            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            cbxEstadoCivil.Enabled = false;
            dtpFechaNacimiento.Enabled = false;

            btnEditarDatosPersonales.Show();
            btnConfirmarPer.Hide();
            btnCancelarPer.Hide();
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPrimApe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtSegApe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
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

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void gbxDatosUsuarios_Enter(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            txtTelefono.BackColor = Color.White;

            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) && txtTelefono.Text.All(char.IsDigit))
            {
                if (txtTelefono.Text.Length == 8)
                {
                    errorProviderPeticion.SetError(txtTelefono, string.Empty);
                }
                else
                {
                    errorProviderPeticion.SetError(txtTelefono, "El teléfono debe contener exactamente 8 dígitos.");
                    txtTelefono.BackColor = Color.LightYellow;
                }
            }
            else
            {
                errorProviderPeticion.SetError(txtTelefono, "El teléfono debe contener solo números y no puede estar vacío.");
                txtTelefono.BackColor = Color.LightPink;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FormPrincipal != null)
            {
                FormPrincipal.AbrirFormsHija(new Peticiones(IdEmpleado, NombreUsuarioAjuste) { FormPrincipal = FormPrincipal });
            }
            else
            {
                MessageBox.Show("FormPrincipal es nulo");
            }
        }
    }
}

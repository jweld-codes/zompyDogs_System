using Azure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zompyDogs.CRUD.AGREGAR;
using zompyDogs.CRUD.REGISTROS;
using ZompyDogsDAO;
using ZompyDogsLib;
using ZompyDogsLib.Controladores;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ExplorerBar;
using static ZompyDogsDAO.PeticionesDAO;
using static ZompyDogsDAO.UsuarioDAO;

namespace zompyDogs
{
    public partial class Usuarios : Form
    {
        // Propiedad para acceder al formulario principal (BienvenidaAdmin)
        public BienvenidaAdmin FormPrincipal { get; set; }

        // Bandera que indica si es un usuario al que se guardará o un proveedor
        private bool isUser = false;

        // Variables para el generador de código y la gestión de registros de usuarios
        private string nuevoCodigoUsuario;
        private ControladorGeneradoresDeCodigo _controladorGeneradorCodigo;

        // Instancia del formulario de registro de usuario
        private UsuarioRegistro _usuarioRegistroForm;

        // Variables para almacenar detalles del usuario
        public string detalleUsuarioRol;
        public int detalleUsuarioID;
        public string detalleUsuariocodigoUsuarioVal;
        public string proveedorcodigoUsuarioVal;

        // Constructor que inicializa los componentes y carga los datos de los usuarios
        public Usuarios()
        {
            InitializeComponent();
            isUser = true;

            // Cargar los diferentes tipos de usuarios (todos, administradores, empleados, proveedores)
            CargarUsuarios();
            CargarUsuariosAdministradores();
            CargarUsuariosEmpleados();
            CargarProveedores();

            // Esconder los DataGridView y botones de eliminar/editar
            dgvEmpleados.Hide();
            dgvAdminis.Hide();
            dgvProveedor.Hide();
            btnEliminarUsuario.Hide();
            btnEditarUsuario.Hide();

            // Inicializar el controlador de generación de códigos y el formulario de registro
            _controladorGeneradorCodigo = new ControladorGeneradoresDeCodigo();
            _usuarioRegistroForm = new UsuarioRegistro();
        }

        // Método para generar el código único para un usuario nuevo y asignarlo al campo en el formulario de registro
        private void GeneradordeCodigoUsuarioFromForm()
        {
            // Obtener un nuevo código de usuario
            nuevoCodigoUsuario = _controladorGeneradorCodigo.GeneradordeCodigoUsuario();
            // Asignar el código generado al TextBox del formulario de registro
            _usuarioRegistroForm.txtCodigoGenerado.Text = nuevoCodigoUsuario;
        }

        /********** Cargadores de Datos ********/
        // Método para cargar todos los usuarios en el DataGridView de usuarios generales
        private void CargarUsuarios()
        {
            // Obtener los detalles de los usuarios desde la base de datos
            DataTable usuarios = UsuarioDAO.ObtenerDetalllesDeUsuarios();
            dgvUsuarios.DataSource = usuarios;

            // Personalizar las columnas del DataGridView
            dgvUsuarios.Columns["Codigo"].HeaderText = "Código";
            dgvUsuarios.Columns["Telefono"].HeaderText = "Teléfono";
            dgvUsuarios.Columns["Nombre_Completo"].HeaderText = "Nombre del Empleado";
            dgvUsuarios.Columns["RolUsuario"].HeaderText = "Rol";

            // Personalizar el estilo de los encabezados de columna
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        // Método para cargar los usuarios empleados en el DataGridView correspondiente
        private void CargarUsuariosEmpleados()
        {
            // Obtener los detalles de los usuarios empleados desde la base de datos
            DataTable usuariosEmp = UsuarioDAO.ObtenerDetalllesDeUsuariosEmpleados();
            dgvEmpleados.DataSource = usuariosEmp;

            // Personalizar las columnas del DataGridView
            dgvEmpleados.Columns["Codigo"].HeaderText = "Código";
            dgvEmpleados.Columns["Telefono"].HeaderText = "Teléfono";
            dgvEmpleados.Columns["Nombre_Completo"].HeaderText = "Nombre del Empleado";
            dgvEmpleados.Columns["RolUsuario"].HeaderText = "Rol";

            // Personalizar el estilo de los encabezados de columna
            dgvEmpleados.EnableHeadersVisualStyles = false;
            dgvEmpleados.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvEmpleados.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        // Método para cargar los usuarios administradores en el DataGridView correspondiente
        private void CargarUsuariosAdministradores()
        {
            // Obtener los detalles de los usuarios administradores desde la base de datos
            DataTable usuariosAdmin = UsuarioDAO.ObtenerDetalllesDeUsuariosAdmin();
            dgvAdminis.DataSource = usuariosAdmin;

            // Personalizar las columnas del DataGridView
            dgvAdminis.Columns["Codigo"].HeaderText = "Código";
            dgvAdminis.Columns["Telefono"].HeaderText = "Teléfono";
            dgvAdminis.Columns["Nombre_Completo"].HeaderText = "Nombre del Empleado";
            dgvAdminis.Columns["RolUsuario"].HeaderText = "Rol";

            // Personalizar el estilo de los encabezados de columna
            dgvAdminis.EnableHeadersVisualStyles = false;
            dgvAdminis.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvAdminis.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvAdminis.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        // Método para cargar los proveedores en el DataGridView correspondiente
        private void CargarProveedores()
        {
            // Obtener los detalles de los proveedores desde la base de datos
            DataTable usuariosAdmin = UsuarioDAO.ObtenerDetalllesProveedores();
            dgvProveedor.DataSource = usuariosAdmin;

            // Personalizar las columnas del DataGridView
            dgvProveedor.Columns["Codigo"].HeaderText = "Código";
            dgvProveedor.Columns["Telefono"].HeaderText = "Teléfono";
            dgvProveedor.Columns["Nombre_Completo"].HeaderText = "Nombre del Empleado";

            // Personalizar el estilo de los encabezados de columna
            dgvProveedor.EnableHeadersVisualStyles = false;
            dgvProveedor.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvProveedor.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvProveedor.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        

        /********** CRUD Para Usuarios ********/

        // Maneja la acción del botón para agregar un nuevo usuario o proveedor
        private void btnAgregarNuevoUsuario_Click(object sender, EventArgs e)
        {
            // Verifica si es un usuario normal (no un proveedor)
            if (isUser == true)
            {
                // Muestra el formulario para registrar un nuevo usuario
                var usuarioGuardar = new UsuarioRegistro();
                usuarioGuardar.Show();
                usuarioGuardar.lblTituloRegistro.Text = "Agregar Nuevo Registro";
                usuarioGuardar.btnGuardarUser.Text = "GUARDAR";

                // Deshabilita la fecha de registro (no debe ser modificada por el usuario)
                usuarioGuardar.dtpFechaRegistro.Enabled = false;

                // Asocia un evento al botón de guardar del formulario
                usuarioGuardar.btnGuardarUser.Click += (s, args) =>
                {
                    // Valida los campos del formulario
                    usuarioGuardar.ValidarCampos();

                    // Verifica si los campos son válidos
                    bool itsValid;
                    itsValid = usuarioGuardar.okError;

                    // Si no es válido, valida nuevamente
                    if (itsValid == false)
                    {
                        usuarioGuardar.ValidarCampos();
                    }
                    else
                    {
                        // Obtiene el siguiente ID para el nuevo usuario
                        int siguienteID = UsuarioDAO.ObtenerSiguienteID();

                        // Capitaliza la primera letra de los nombres y apellidos
                        string primerNombre = CapitalizarPrimeraLetra(usuarioGuardar.txtPrimNombre.Text);
                        string segundoNombre = CapitalizarPrimeraLetra(usuarioGuardar.txtSegNombre.Text);
                        string primerApellido = CapitalizarPrimeraLetra(usuarioGuardar.txtPrimApellido.Text);
                        string segundoApellido = CapitalizarPrimeraLetra(usuarioGuardar.txtSegApellido.Text);

                        // Crea un nuevo detalle de usuario con la información proporcionada
                        ZompyDogsLib.Usuarios.DetalleUsuario nuevoDetalleUsuario = new ZompyDogsLib.Usuarios.DetalleUsuario
                        {
                            primerNombre = primerNombre,
                            segundoNombre = segundoNombre,
                            primerApellido = primerApellido,
                            segundoApellido = segundoApellido,
                            codigoCedula = usuarioGuardar.txtCedula.Text,
                            fechaNacimiento = usuarioGuardar.dtpFechaNacimiento.Value,
                            estadoCivil = usuarioGuardar.cbxEsatdoCivil.SelectedItem?.ToString() ?? string.Empty,
                            telefono = usuarioGuardar.txtTelefono.Text,
                            direccion = usuarioGuardar.txtDireccion.Text,
                            codigoPuesto = usuarioGuardar.cbPuesto.SelectedValue != null ? Convert.ToInt32(usuarioGuardar.cbPuesto.SelectedValue) : 1,
                            codigoUsuario = usuarioGuardar.txtCodigoGenerado.Text,

                        };
                        try
                        {
                            // Intenta guardar el nuevo detalle de usuario en la base de datos
                            UsuarioDAO.GuardarDetalleUsuario(nuevoDetalleUsuario);

                            // Crea el registro del nuevo usuario
                            ZompyDogsLib.Usuarios.UsuarioCrear nuevoUsuarioRegistro = new ZompyDogsLib.Usuarios.UsuarioCrear
                            {
                                UserName = usuarioGuardar.txtUsername.Text,
                                PassWord = usuarioGuardar.txtPassword.Text,
                                FechaRegistro = usuarioGuardar.dtpFechaRegistro.Value.Date,
                                CodigoRol = usuarioGuardar.cbxRol.SelectedValue != null ? Convert.ToInt32(usuarioGuardar.cbxRol.SelectedValue) : 1,
                                CodigoDetalleUsuario = siguienteID,
                                Email = usuarioGuardar.txtEmail.Text,
                            };

                            // Intenta guardar el nuevo usuario en la base de datos
                            UsuarioDAO.GuardarUsuario(nuevoUsuarioRegistro);

                            // Obtiene la información del nuevo usuario para mostrarla
                            string userNameName = usuarioGuardar.txtPrimNombre.Text + " " + usuarioGuardar.txtPrimApellido.Text;
                            string newUsername = usuarioGuardar.txtUsername.Text;
                            string newPassWord = usuarioGuardar.txtPassword.Text;
                            string newEmail = usuarioGuardar.txtEmail.Text;

                            // Verifica si el rol es 'Usuario'
                            if (usuarioGuardar.cbxRol.Text == "Usuario")
                            {
                                MessageBox.Show("Usuario Registrado con Éxito.");

                                // Recarga las listas de usuarios
                                CargarUsuarios();
                                CargarUsuariosAdministradores();
                                CargarUsuariosEmpleados();
                            }
                            else
                            {
                                MessageBox.Show($"{userNameName} Registrado con Éxito.");

                                // Recarga las listas de usuarios
                                CargarUsuarios();
                                CargarUsuariosAdministradores();
                                CargarUsuariosEmpleados();
                                try
                                {
                                    // Intenta enviar un correo de bienvenida al nuevo usuario
                                    MailMessage mail = new MailMessage();
                                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                                    mail.From = new MailAddress("zusiurec@gmail.com");
                                    mail.To.Add($"{usuarioGuardar.txtEmail.Text}");

                                    mail.Subject = "Creación de Nueva Cuenta.";
                                    mail.Body = $"¡Bienvenido {primerNombre} {primerApellido} a la familia ZOMPYDOGS! \nTus credenciales para acceder al sistema son las siguientes.\n Usuario: {newUsername}\n Clave: {newPassWord}";

                                    smtpClient.Port = 587;
                                    smtpClient.Credentials = new System.Net.NetworkCredential("zusiurec@gmail.com", "cdkaqkabbrmbmdss");
                                    smtpClient.EnableSsl = true;

                                    smtpClient.Send(mail);
                                }
                                catch (SmtpException smtpEx)
                                {
                                    MessageBox.Show($"Error al enviar el correo: {smtpEx.Message}");
                                    Console.WriteLine(smtpEx.ToString());
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                                    Console.WriteLine(ex.ToString());
                                }
                            }
                            
                            
                        }
                        catch
                        {
                            MessageBox.Show("Error al actualizar el Usuario.");

                        }
                    }
                   
                };
            }
            else
            {
                // Si no es un usuario, entonces es un proveedor
                var proveedorGuardar = new ProveedorRegistro();
                proveedorGuardar.Show();
                proveedorGuardar.lblTituloRegistro.Text = "Agregar Nuevo Proveedor";
                proveedorGuardar.btnGuardarProv.Text = "GUARDAR";

                // Deshabilita la fecha de registro (no debe ser modificada por el proveedor)
                proveedorGuardar.dtpFechaRegistro.Enabled = false;

                // Asocia un evento al botón de guardar del formulario para proveedores
                proveedorGuardar.btnGuardarProv.Click += (s, args) =>
                {
                    // Valida los campos del formulario
                    proveedorGuardar.ValidarCampos();

                    // Verifica si los campos son válidos
                    bool itsValid;
                    itsValid = proveedorGuardar.okError;

                    // Si no es válido, valida nuevamente
                    if (itsValid == false)
                    {
                        proveedorGuardar.ValidarCampos();
                    }
                    else
                    {
                        // Crea un nuevo proveedor con la información proporcionada
                        ZompyDogsLib.Usuarios.ProveedorCrear nuevoProveedor = new ZompyDogsLib.Usuarios.ProveedorCrear
                        {
                            CodigoProv = proveedorGuardar.txtCodigoGenerado.Text,
                            NombreProv = proveedorGuardar.txtNombreProv.Text,
                            FechaRegistroProv = proveedorGuardar.dtpFechaRegistro.Value.Date,
                            ContactoProv = proveedorGuardar.txtPrimNombre.Text,
                            ApellidoContactoProv = proveedorGuardar.txtSegNombre.Text,
                            TelefonoProv = proveedorGuardar.txtTelefono.Text,
                            EmailProv = proveedorGuardar.txtEmail.Text,
                            EstadoProv = proveedorGuardar.cbxEstado.Text
                        };

                        try
                        {
                            // Intenta guardar el nuevo proveedor en la base de datos
                            UsuarioDAO.GuardarProveedor(nuevoProveedor);

                            MessageBox.Show("Proveedor Registrado con Éxito.");
                            // Recarga la lista de proveedores
                            CargarProveedores();
                        }
                        catch
                        {
                            MessageBox.Show("Error al actualizar el proveedor.");
                        }
                    }
                };

            }
        }

        // Método que maneja la visualización de los detalles de un usuario o proveedor en modo solo lectura
        private void btnVisualizarRegistro_Click(object sender, EventArgs e)
        {
            // Si estamos visualizando un usuario (isUser == true)
            if (isUser == true)
            {
                // Crear una nueva instancia del formulario de visualización de usuario
                var usuarioView = new UsuarioRegistro();
                usuarioView.lblTituloRegistro.Text = "Ver Registro";
                usuarioView.btnGuardarUser.Hide();

                // Deshabilitar todos los controles para solo lectura
                foreach (Control control in usuarioView.Controls)
                {
                    control.Enabled = false;
                }
                usuarioView.btnCancelar.Text = "SALIR";
                usuarioView.btnCancelar.Enabled = true;
                usuarioView.Show();

                // Obtener los detalles del usuario desde la base de datos
                DataTable usuarioDatosEditar = UsuarioDAO.ObtenerDetalllesDeUsuariosParaEditar(detalleUsuariocodigoUsuarioVal);

                if (usuarioDatosEditar.Rows.Count > 0)
                {
                    DataRow fila = usuarioDatosEditar.Rows[0];

                    // Llenar el formulario con los datos del usuario
                    usuarioView.txtCodigoGenerado.Text = fila["Codigo"].ToString();
                    usuarioView.lblidDetalleUsuario.Text = fila["ID_DetalleUsuario"].ToString();
                    usuarioView.txtCedula.Text = fila["ID_Cedula"].ToString();
                    usuarioView.txtPrimNombre.Text = fila["Nombre_Usuario"].ToString();
                    usuarioView.txtSegNombre.Text = fila["Segundo_Nombre"].ToString();
                    usuarioView.txtPrimApellido.Text = fila["Apellido_Usuario"].ToString();
                    usuarioView.txtSegApellido.Text = fila["Segundo_Apellido"].ToString();
                    usuarioView.txtDireccion.Text = fila["Direccion"].ToString();
                    usuarioView.txtTelefono.Text = fila["Telefono"].ToString();
                    usuarioView.cbxEsatdoCivil.Text = fila["Estado_Civil"].ToString();
                    usuarioView.txtEmail.Text = fila["Correo"].ToString();

                    usuarioView.cbPuesto.Text = fila["Puesto"].ToString();
                    usuarioView.txtPassword.Text = fila["Clave"].ToString();

                    DateTime fechaNacimiento;
                    if (DateTime.TryParse(fila["Fecha_De_Nacimiento"].ToString(), out fechaNacimiento) &&
                        fechaNacimiento >= usuarioView.dtpFechaNacimiento.MinDate &&
                        fechaNacimiento <= usuarioView.dtpFechaNacimiento.MaxDate)
                    {
                        usuarioView.dtpFechaNacimiento.Value = fechaNacimiento;
                    }
                    else
                    {
                        usuarioView.dtpFechaNacimiento.Value = usuarioView.dtpFechaNacimiento.MinDate;
                    }

                    usuarioView.txtUsername.Text = fila["Usuario"].ToString();
                    usuarioView.cbxRol.Text = fila["RolUsuario"].ToString();
                }
            }
            else
            {
                // Crear una nueva instancia del formulario de visualización de proveedor
                var frmProveedorRegistro = new ProveedorRegistro();
                frmProveedorRegistro.lblTituloRegistro.Text = "Ver Proveedor";
                frmProveedorRegistro.Show();

                // Obtener los detalles del proveedor desde la base de datos
                DataTable proveedoresDatos = UsuarioDAO.ObtenerDetalllesDeProveedoresParaEditar(proveedorcodigoUsuarioVal);

                if (proveedoresDatos.Rows.Count > 0)
                {
                    DataRow fila = proveedoresDatos.Rows[0];

                    // Llenar el formulario con los datos del proveedor
                    frmProveedorRegistro.dtpFechaRegistro.Enabled = false;

                    frmProveedorRegistro.txtCodigoGenerado.Text = fila["Codigo"].ToString();
                    frmProveedorRegistro.txtCodigoGenerado.Enabled = false;

                    frmProveedorRegistro.txtNombreProv.Text = fila["Proveedor"].ToString();
                    frmProveedorRegistro.txtNombreProv.Enabled = false;

                    frmProveedorRegistro.txtPrimNombre.Text = fila["Nombre"].ToString();
                    frmProveedorRegistro.txtPrimNombre.Enabled = false;

                    frmProveedorRegistro.txtSegNombre.Text = fila["Apellido"].ToString();
                    frmProveedorRegistro.txtSegNombre.Enabled = false;

                    frmProveedorRegistro.txtTelefono.Text = fila["Telefono"].ToString();
                    frmProveedorRegistro.txtTelefono.Enabled = false;

                    frmProveedorRegistro.txtEmail.Text = fila["Correo"].ToString();
                    frmProveedorRegistro.txtEmail.Enabled = false;

                    frmProveedorRegistro.cbxEstado.Text = fila["Estado"].ToString();
                    frmProveedorRegistro.cbxEstado.Enabled = false;

                    frmProveedorRegistro.btnGuardarProv.Hide();
                    frmProveedorRegistro.btnCancelar.Text = "Salir";
                }

            }
        }
        
        //No es necesario por los momentos
        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            btnEditarUsuario.Hide();
            if (isUser)
            {
                var usuarioEditar = new UsuarioRegistro();
                usuarioEditar.lblTituloRegistro.Text = "Editar Registro";
                usuarioEditar.btnGuardarUser.Text = "EDITAR";

                usuarioEditar.Show();

                DataTable usuarioDatosEditar = UsuarioDAO.ObtenerDetalllesDeUsuariosParaEditar(detalleUsuariocodigoUsuarioVal);

                if (usuarioDatosEditar.Rows.Count > 0)
                {
                    DataRow fila = usuarioDatosEditar.Rows[0];

                    usuarioEditar.lblidDetalleUsuario.Text = fila["ID_DetalleUsuario"].ToString();
                    usuarioEditar.txtCodigoGenerado.Text = fila["Codigo"].ToString();
                    usuarioEditar.txtCodigoGenerado.Enabled = false;

                    usuarioEditar.txtCedula.Text = fila["ID_Cedula"].ToString();
                    usuarioEditar.txtCedula.Enabled = false;

                    usuarioEditar.txtPrimNombre.Text = fila["Nombre_Usuario"].ToString();
                    usuarioEditar.txtPrimNombre.Enabled = false;

                    usuarioEditar.txtSegNombre.Text = fila["Segundo_Nombre"].ToString();
                    usuarioEditar.txtSegNombre.Enabled = false;

                    usuarioEditar.txtPrimApellido.Text = fila["Apellido_Usuario"].ToString();
                    usuarioEditar.txtPrimApellido.Enabled = false;

                    usuarioEditar.txtSegApellido.Text = fila["Segundo_Apellido"].ToString();
                    usuarioEditar.txtSegApellido.Enabled = false;

                    usuarioEditar.txtDireccion.Text = fila["Direccion"].ToString();

                    usuarioEditar.txtTelefono.Text = fila["Telefono"].ToString();

                    usuarioEditar.cbxEsatdoCivil.Text = fila["Estado_Civil"].ToString();
                    usuarioEditar.cbPuesto.Text = fila["Puesto"].ToString();

                    usuarioEditar.txtPassword.Text = fila["Clave"].ToString();
                    usuarioEditar.txtUsername.Text = fila["Usuario"].ToString();
                    usuarioEditar.cbxRol.Text = fila["RolUsuario"].ToString();
                    usuarioEditar.txtEmail.Text = fila["Correo"].ToString();

                    DateTime fechaNacimiento;
                    if (DateTime.TryParse(fila["Fecha_De_Nacimiento"].ToString(), out fechaNacimiento) &&
                        fechaNacimiento >= usuarioEditar.dtpFechaNacimiento.MinDate &&
                        fechaNacimiento <= usuarioEditar.dtpFechaNacimiento.MaxDate)
                    {
                        usuarioEditar.dtpFechaNacimiento.Value = fechaNacimiento;
                    }
                    else
                    {
                        usuarioEditar.dtpFechaNacimiento.Value = usuarioEditar.dtpFechaNacimiento.MinDate;
                    }
                    usuarioEditar.dtpFechaRegistro.Enabled = false;
                    usuarioEditar.dtpFechaNacimiento.Enabled = false;

                    usuarioEditar.txtPassword.Enabled = false;
                    usuarioEditar.txtUsername.Enabled = false;
                    usuarioEditar.btnGeneradorUsername.Enabled = false;
                    usuarioEditar.btnGeneradorPassword.Enabled = false;
                    usuarioEditar.txtCedula.Enabled = false;
                    usuarioEditar.cbxRol.Enabled = false;

                    usuarioEditar.btnGuardarUser.Click += (s, args) =>
                    {
                        bool itsValid;
                        itsValid = usuarioEditar.okError;

                        MessageBox.Show("itsValid: "+ itsValid);

                        if (itsValid == false)
                        {
                            usuarioEditar.ValidarCampos();
                        }
                        else
                        {
                            try
                            {
                                if (string.IsNullOrWhiteSpace(usuarioEditar.txtCodigoGenerado.Text))
                                {
                                    MessageBox.Show("Código de usuario no válido.");
                                    return;
                                }

                                ZompyDogsLib.Usuarios.DetalleUsuario detalleUsuarioActualizado = new ZompyDogsLib.Usuarios.DetalleUsuario
                                {
                                    primerNombre = usuarioEditar.txtPrimNombre.Text,
                                    segundoNombre = usuarioEditar.txtSegNombre.Text,
                                    primerApellido = usuarioEditar.txtPrimApellido.Text,
                                    segundoApellido = usuarioEditar.txtSegApellido.Text,
                                    codigoCedula = usuarioEditar.txtCedula.Text,
                                    fechaNacimiento = usuarioEditar.dtpFechaNacimiento.Value,
                                    estadoCivil = usuarioEditar.cbxEsatdoCivil.Text,
                                    telefono = usuarioEditar.txtTelefono.Text,
                                    direccion = usuarioEditar.txtDireccion.Text,
                                    codigoPuesto = usuarioEditar.cbPuesto.SelectedValue != null ? Convert.ToInt32(usuarioEditar.cbPuesto.SelectedValue) : 1,
                                    codigoUsuario = detalleUsuariocodigoUsuarioVal
                                };

                                if (usuarioEditar.cbPuesto.SelectedValue == null)
                                {
                                    MessageBox.Show("Por favor selecciona un puesto válido.");
                                    return;
                                }

                                bool resultadoDetalle = UsuarioDAO.ActualizarDetalleUsuario(detalleUsuarioActualizado);

                                if (resultadoDetalle)
                                {
                                    MessageBox.Show("Usuario actualizado con éxito.");
                                    CargarUsuarios();
                                    //this.Close();
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
                        
                    };
                }
                else
                {
                    MessageBox.Show("No se encontraron datos del usuario para editar.");
                }
            }
            else
            {
                var frmProveedorRegistro = new ProveedorRegistro();
                frmProveedorRegistro.lblTituloRegistro.Text = "Editar Proveedor";
                frmProveedorRegistro.btnGuardarProv.Text = "EDITAR";
                frmProveedorRegistro.cbxEstado.Enabled = true;
                frmProveedorRegistro.txtNombreProv.Enabled = false;
                btnEditarUsuario.Enabled = true;

                frmProveedorRegistro.Show();

                DataTable proveedoresDatosEditar = UsuarioDAO.ObtenerDetalllesDeProveedoresParaEditar(proveedorcodigoUsuarioVal);

                if (proveedoresDatosEditar.Rows.Count > 0)
                {

                    DataRow fila = proveedoresDatosEditar.Rows[0];

                    frmProveedorRegistro.txtCodigoGenerado.Text = fila["Codigo"].ToString();
                    frmProveedorRegistro.txtCodigoGenerado.Enabled = false;

                    frmProveedorRegistro.txtNombreProv.Text = fila["Proveedor"].ToString();
                    frmProveedorRegistro.txtPrimNombre.Text = fila["Nombre"].ToString();
                    frmProveedorRegistro.txtSegNombre.Text = fila["Apellido"].ToString();
                    frmProveedorRegistro.txtTelefono.Text = fila["Telefono"].ToString();
                    frmProveedorRegistro.txtEmail.Text = fila["Correo"].ToString();
                    frmProveedorRegistro.cbxEstado.Text = fila["Estado"].ToString();
                    frmProveedorRegistro.dtpFechaRegistro.Enabled = false;
                    
                    frmProveedorRegistro.btnGuardarProv.Click += (s, args) =>
                    {
                       
                        try
                        {
                            if (string.IsNullOrWhiteSpace(frmProveedorRegistro.txtCodigoGenerado.Text))
                            {
                                MessageBox.Show("Código de proveedor no válido.");
                                return;
                            }

                            ZompyDogsLib.Usuarios.ProveedorCrear proveedorActualizador = new ZompyDogsLib.Usuarios.ProveedorCrear
                            {
                                NombreProv = frmProveedorRegistro.txtNombreProv.Text,
                                ContactoProv = frmProveedorRegistro.txtPrimNombre.Text,
                                TelefonoProv = frmProveedorRegistro.txtTelefono.Text,
                                EmailProv = frmProveedorRegistro.txtEmail.Text,
                                EstadoProv = frmProveedorRegistro.cbxEstado.Text,
                                ApellidoContactoProv = frmProveedorRegistro.txtSegNombre.Text,
                                CodigoProv = proveedorcodigoUsuarioVal
                            };

                            bool resultado = UsuarioDAO.ActualizarProveedotes(proveedorActualizador);

                            if (resultado)
                            {
                                MessageBox.Show("Proveedor actualizado con éxito.");
                                CargarProveedores();
                                btnEditarUsuario.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el proveedor.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al actualizar el proveedot: " + ex.Message);
                            Console.WriteLine("Detalles de la excepción: " + ex.ToString());
                        }
                    };


                }
            }
        }
        
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            DataTable usuarioTabla = UsuarioDAO.ObtenerDetalllesDeUsuariosParaEditar(detalleUsuariocodigoUsuarioVal);
            var usuariosRegistroForm = new UsuarioRegistro();
            if (usuarioTabla.Rows.Count > 0)
            {
                DataRow fila = usuarioTabla.Rows[0];
                usuariosRegistroForm.lblidDetalleUsuario.Text = fila["ID_DetalleUsuario"].ToString();
            }

            detalleUsuarioID = Convert.ToInt32(usuariosRegistroForm.lblidDetalleUsuario.Text);

            DialogResult check = MessageBox.Show("¿Está seguro de eliminar este usuario?",
            "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                bool eliminadoUsuario = UsuarioDAO.EliminarUsuario(detalleUsuarioID);
                bool eliminadoDetalle = UsuarioDAO.EliminarUsuarioPorDetalle(detalleUsuariocodigoUsuarioVal);

                if (eliminadoUsuario)
                {
                    MessageBox.Show("Usuario eliminado con éxito.");
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario.");
                }
            }
        }


        /******** Top Menu Navegador ***********/
        private void btnUsuarioPanel_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            isUser = true;
            CargarUsuarios();
            lblTituloRegistroPanel.Text = "Registros de Usuarios";
            dgvUsuarios.Show();
            dgvProveedor.Hide();
            lblBreadCrumbUser.Text = "USUARIOS";
            dgvEmpleados.Hide();
            dgvAdminis.Hide();
            btnEditarUsuario.Hide();

            txtBuscarUsuario.TextChanged += (s, args) =>
            {
                string valorBusqueda = txtBuscarUsuario.Text;
                DataTable resultados = UsuarioDAO.BuscadorDeUsuarios(valorBusqueda);
                dgvEmpleados.DataSource = resultados;
            };
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            isUser = true;
            CargarUsuariosAdministradores();
            lblTituloRegistroPanel.Text = "Registros de Administradores";
            dgvUsuarios.Hide();
            dgvEmpleados.Hide();
            dgvProveedor.Hide();
            dgvAdminis.Show();
            btnEditarUsuario.Hide();
            lblBreadCrumbUser.Text = "ADMINISTRADORES";

            txtBuscarUsuario.TextChanged += (s, args) =>
            {
                string valorBusqueda = txtBuscarUsuario.Text;
                DataTable resultados = UsuarioDAO.BuscadorDeUsuariosAdmins(valorBusqueda);
                dgvAdminis.DataSource = resultados;
            };
        }

        private void btnEmpleadoPanel_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            isUser = true;
            CargarUsuariosEmpleados();
            lblTituloRegistroPanel.Text = "Registros de Empleados";
            dgvUsuarios.Hide();
            dgvProveedor.Hide();
            dgvEmpleados.Show();
            lblBreadCrumbUser.Text = "EMPLEADOS";
            dgvAdminis.Hide();
            btnEditarUsuario.Hide();
            //cbxFiltro.Hide();

            txtBuscarUsuario.TextChanged += (s, args) =>
            {
                string valorBusqueda = txtBuscarUsuario.Text;
                DataTable resultados = UsuarioDAO.BuscadorDeUsuariosEmps(valorBusqueda);
                dgvEmpleados.DataSource = resultados;
            };
        }

        private void btnPrveedores_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            isUser = false;
            CargarProveedores();
            lblTituloRegistroPanel.Text = "Registros de Proveedores";
            dgvUsuarios.Hide();
            dgvEmpleados.Hide();
            dgvAdminis.Hide();
            dgvProveedor.Show();
            btnEditarUsuario.Show();

            btnRefreshDG.Show();

            lblBreadCrumbUser.Text = "PROVEEDORES";

            txtBuscarUsuario.TextChanged += (s, args) =>
            {
                string valorBusqueda = txtBuscarUsuario.Text;
                DataTable resultados = UsuarioDAO.BuscadorDeProveedores(valorBusqueda);
                dgvProveedor.DataSource = resultados;
            };

            btnEliminarUsuario.Click += (s, args) =>
            {
                DialogResult check = MessageBox.Show("¿Está seguro de eliminar este proveedor?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (check == DialogResult.Yes)
                {
                    bool eliminarProveedor = UsuarioDAO.EliminarProveedor(proveedorcodigoUsuarioVal);

                    if (eliminarProveedor)
                    {
                        MessageBox.Show("Proveedor eliminado con éxito.");
                        CargarProveedores();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el proveedor.");
                    }
                }
            };
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

        /****** Seleccionadores de Datos en DataGrid ************/
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvUsuarios.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                detalleUsuariocodigoUsuarioVal = filaSeleccionada.Cells["Codigo"].Value.ToString();
                detalleUsuarioRol = filaSeleccionada.Cells["RolUsuario"].Value.ToString();
            }
        }
        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvProveedor.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                proveedorcodigoUsuarioVal = filaSeleccionada.Cells["Codigo"].Value.ToString();
            }
        }
        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvEmpleados.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                detalleUsuariocodigoUsuarioVal = filaSeleccionada.Cells["Codigo"].Value.ToString();
                detalleUsuarioRol = filaSeleccionada.Cells["RolUsuario"].Value.ToString();
            }
        }
        private void dgvAdminis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvAdminis.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                detalleUsuariocodigoUsuarioVal = filaSeleccionada.Cells["Codigo"].Value.ToString();
                detalleUsuarioRol = filaSeleccionada.Cells["RolUsuario"].Value.ToString();
            }
        }

        /********* Extras *************/

        public string CapitalizarPrimeraLetra(string texto)
        {
            // Verifica si el texto está vacío o es nulo o contiene solo espacios en blanco
            if (string.IsNullOrWhiteSpace(texto))
            {
                // Si es así, retorna el texto tal cual (nulo, vacío o espacios)
                return texto;
            }

            // Toma la primera letra del texto, la convierte a mayúsculas y luego concatena el resto del texto en minúsculas
            // Se utiliza Substring para obtener el texto desde el segundo carácter en adelante
            return char.ToUpper(texto[0]) + texto.Substring(1).ToLower();
        }

        private void btnRefreshDG_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarUsuariosAdministradores();
            CargarUsuariosEmpleados();
            CargarProveedores();
        }

        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            string valorBusqueda = txtBuscarUsuario.Text;
            DataTable resultados = UsuarioDAO.BuscadorDeUsuarios(valorBusqueda);
            dgvUsuarios.DataSource = resultados;
            dgvEmpleados.DataSource = resultados;
            dgvAdminis.DataSource = resultados;
        }

    }
}

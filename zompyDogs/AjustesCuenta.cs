using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public AjustesCuenta(int usuarioID, string usuarioNombre)
        {
            InitializeComponent();

            IdEmpleado = usuarioID;
            NombreUsuarioAjuste = usuarioNombre;

            CargarPeticiones();

            gbxDatosPersonales.Show();
            gbxDatosUsuarios.Hide();
            gbxPeticionesBtn.Hide();
            gbxPeticiones.Hide();

            btnConfirmarPer.Hide();
            btnCancelarPer.Hide();
            btnConfirmarUs.Hide();
            btnCancelarUs.Hide();

            rectanglePanel1.Show();
            rectanglePanel2.Hide();
            rectanglePanel3.Hide();

            //CheckBox Changed
            chbxLunes.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxMartes.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxMiercoles.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxJueves.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxViernes.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxSabado.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxDomingo.CheckedChanged += (s, e) => ActualizarDiasLaborales();

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
            if (chbxDomingo.Checked) diasSeleccionados.Add("Domingo");

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
            seeIcon.Enabled=false;
            seeCloseIcon.Enabled=false;
            txtRol.Enabled = false;
            txtSalario.Enabled = false;
            txtPuesto.Enabled = false;
            txtHoras.Enabled = false;

            gbxDias.Enabled = false;

            DataTable ajusteCuentaView = UsuarioDAO.ObtenerDetalllesDeUsuariosParaEditarPorID(IdEmpleado);
            string diasLaboralesSeleccionadas = txtDiasLaborales.Text;

            if (ajusteCuentaView.Rows.Count > 0)
            {
                DataRow fila = ajusteCuentaView.Rows[0];

                txtCodigoGeneradoUser.Text = fila["Codigo"].ToString();
                txtUser.Text = fila["Usuario"].ToString();
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
                chbxDomingo.Checked = diasLaborales.Contains("Domingo");
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
                }
                else
                {
                    MessageBox.Show("Error al actualizar la petición.");
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
            txtPrimerNombre.Enabled = true;
            txtSegNombre.Enabled = true;
            txtPrimApe.Enabled = true;
            txtSegApe.Enabled = true;

            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            cbxEstadoCivil.Enabled = true;
            dtpFechaNacimiento.Enabled = true;

            btnEditarDatosPersonales.Hide();
            btnConfirmarPer.Show();
            btnCancelarPer.Show();
        }

        private void btnConfirmarPer_Click(object sender, EventArgs e)
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
                    //codigoPuesto = cbPuesto.SelectedValue != null ? Convert.ToInt32(cbPuesto.SelectedValue) : 1,
                    codigoUsuario = txtCodigoGenerado.Text
                };

                /*if (cbPuesto.SelectedValue == null)
                {
                    MessageBox.Show("Por favor selecciona un puesto válido.");
                    return;
                }*/

                bool resultadoDetalle = UsuarioDAO.AjusteDetalleUsuario(detalleUsuarioActualizado);

                if (resultadoDetalle)
                {
                    MessageBox.Show("Usuario actualizado con éxito.");
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

        private void btnEditarUsuario_Click_1(object sender, EventArgs e)
        {
            DatosUsuario();
            DatosDelUsuario();

            txtUser.Enabled = true;
            txtClave.Enabled = true;

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
                    IDUser = IdEmpleado
                };
                bool resultadoDetalle = UsuarioDAO.AjusteDatosDeUsuario(datosUsuarioUpdate);

                if (resultadoDetalle)
                {
                    MessageBox.Show("Usuario actualizado con éxito.");
                    txtClave.PasswordChar = '*';

                    btnConfirmarUs.Hide();
                    btnCancelarUs.Hide();
                    btnEditarUsuario.Show();

                    txtUser.Enabled = false;
                    txtClave.Enabled = false;
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

        private void btnCancelarUs_Click(object sender, EventArgs e)
        {
            DatosDelUsuario();

            txtUser.Enabled = false;
            txtClave.Enabled = false;

            btnConfirmarUs.Hide();
            btnCancelarUs.Hide();
            btnEditarUsuario.Show();

            seeIcon.Enabled = false;

            seeCloseIcon.Hide();
            seeIcon.Show();

        }
    }
}

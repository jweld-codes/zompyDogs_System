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
using static ZompyDogsDAO.PeticionesDAO;

namespace zompyDogs
{
    public partial class Peticiones : Form
    {
        // Propiedades públicas para manejar formularios y datos de usuario
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }
        public BienvenidaAdmin FormPrincipal { get; set; }
        public string NombreUsuarioAjuste { get; set; }

        // Instancia de otros formularios y variables privadas
        PeticionRecuperacionDeContraseña frmSolicitudDeRecuperacionCuenta;
        public PeticionesRegisro frmPeticionesRegisro;
        int idAdmin;
        public int IdEmpleado { get; set; }

        // Variables para almacenar detalles de las peticiones
        public string PeticionAccionVal;
        public string PeticionCodigoVal;
        public string PeticionVal;
        public DateTime PeticionFecha_De_EnvioVal;
        public string PeticionDescripcionVal;
        public string PeticionEstadoVal;
        public string PeticionUsuarioVal;
        public string PeticionUsuarioGuardar;
        public string PeticionEmailVal;
        public int PeticionUsuarioID;

        // Constructor del formulario Peticiones
        public Peticiones(int idEmpledo, string usuarioNombre)
        {
            // Inicializa el formulario y configura las propiedades
            InitializeComponent();
            IdEmpleado = idEmpledo;
            NombreUsuarioAjuste = usuarioNombre;

            // Se suscriben los eventos de clic en las celdas de los DataGridViews
            dgvPeticionesCompletadas.CellClick += dgvPeticiones_CellClick;
            dgvPeticionesPendientes.CellClick += dgvPeticionesPendientes_CellClick;

            // Cargar las peticiones en los DataGridViews
            CargarPeticiones();

            // Ocultar botones innecesarios
            btnActualizar.Hide();
            btnEliminarUsuario.Hide();

        }

        // Método que carga las peticiones en los DataGridViews
        public void CargarPeticiones()
        {
            // Obtener las peticiones pendientes y completadas
            dgvPeticionesPendientes.DataSource = PeticionesDAO.ObtenerPeticionesPendientes();
            dgvPeticionesCompletadas.DataSource = PeticionesDAO.ObtenerPeticionesCompletadas();

            // Desmarcar cualquier celda seleccionada
            dgvPeticionesPendientes.CurrentCell = null;
            dgvPeticionesCompletadas.CurrentCell = null;

            // Configurar la apariencia de los DataGridViews
            EdicionDeDatagrid();
        }

        // Método que personaliza la visualización de las columnas en los DataGridViews
        private void EdicionDeDatagrid()
        {
            dgvPeticionesPendientes.Columns["Correo"].Visible = false;

            dgvPeticionesCompletadas.Columns["Codigo"].HeaderText = "Código";
            dgvPeticionesCompletadas.Columns["Accion"].HeaderText = "Acción";
            dgvPeticionesCompletadas.Columns["Peticion"].HeaderText = "Petición";
            dgvPeticionesCompletadas.Columns["Fecha_De_Envio"].HeaderText = "Fecha de Envío";

            dgvPeticionesPendientes.Columns["Codigo"].HeaderText = "Código";
            dgvPeticionesPendientes.Columns["Accion"].HeaderText = "Acción";
            dgvPeticionesPendientes.Columns["Peticion"].HeaderText = "Petición";
            dgvPeticionesPendientes.Columns["Fecha_De_Envio"].HeaderText = "Fecha de Envío";

            dgvPeticionesPendientes.EnableHeadersVisualStyles = false;
            dgvPeticionesPendientes.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvPeticionesPendientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvPeticionesPendientes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            dgvPeticionesCompletadas.EnableHeadersVisualStyles = false;
            dgvPeticionesCompletadas.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvPeticionesCompletadas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvPeticionesCompletadas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        // Método que se ejecuta cuando el usuario hace clic en el botón para agregar una nueva petición
        private void btnAgregarRegistro_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del formulario de registro de peticiones
            var peticionesRegistro = new PeticionesRegisro(IdEmpleado);
            peticionesRegistro.lblTituloRegistro.Text = "Guardar Nueva Petición";
            peticionesRegistro.Show();

            // Obtener las peticiones previas del usuario para pre-llenar datos si es necesario
            DataTable peticionGuardarUser = PeticionesDAO.BuscarPeticionesPorIDUsuario(IdEmpleado);
            if (peticionGuardarUser.Rows.Count > 0)
            {
                DataRow fila = peticionGuardarUser.Rows[0];
                PeticionUsuarioGuardar = fila["Usuario"].ToString();
            }

            // Pre-llenar el campo de nombre de usuario en el formulario de registro
            peticionesRegistro.txtUsuarioName.Text = PeticionUsuarioGuardar;

            // Ocultar y configurar otros controles en el formulario de registro
            peticionesRegistro.label3.Hide();
            peticionesRegistro.btnGuardarUser.Text = "GUARDAR";
            peticionesRegistro.btnCancelar.Text = "CANCELAR";
            peticionesRegistro.txtUsuarioName.Enabled = false;

            // Método para guardar la nueva petición cuando el usuario haga clic en "GUARDAR"
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
                    // Crear un objeto para representar la nueva petición
                    ZompyDogsLib.Peticiones.PeticionRegistro nuevaPeticion = new ZompyDogsLib.Peticiones.PeticionRegistro
                    {
                        CodigPeticion = peticionesRegistro.txtCodigoGenerado.Text,
                        AccionPeticion = peticionesRegistro.cbxPeticion.SelectedItem?.ToString() ?? string.Empty,
                        Descripcion = peticionesRegistro.txtDescripcion.Text,
                        FechaEnviada = peticionesRegistro.dtpFechaEnviada.Value,
                        FechaRealizada = DateTime.Now,
                        CodigoUsuario = peticionesRegistro.IdEmpleado,
                        Estado = peticionesRegistro.cbxEstadoCuenta.SelectedItem?.ToString() ?? "Activo"
                    };
                    try
                    {
                        // Intentar guardar la nueva petición en la base de datos
                        PeticionesDAO.GuardarPeticion(nuevaPeticion);

                        // Mostrar un mensaje de éxito y recargar las peticiones
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

        /// <summary>
        /// Maneja el evento de clic en una celda dentro del DataGridView 'dgvPeticionesCompletadas'.
        /// Este evento se dispara cuando el usuario hace clic en cualquier fila de la tabla de peticiones completadas.
        /// Al hacer clic en una fila, el método extrae los datos de las celdas de esa fila y los almacena en las variables correspondientes.
        /// </summary>
        private void dgvPeticiones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si la fila seleccionada es válida (RowIndex >= 0)
            if (e.RowIndex >= 0)
            {
                // Obtiene la fila seleccionada de 'dgvPeticionesCompletadas'
                DataGridViewRow filaSeleccionada = dgvPeticionesCompletadas.Rows[e.RowIndex];

                // Asigna los valores de las celdas de la fila seleccionada a las variables correspondientes
                PeticionCodigoVal = filaSeleccionada.Cells["Codigo"].Value.ToString();
                PeticionAccionVal = filaSeleccionada.Cells["Accion"].Value.ToString();
                PeticionFecha_De_EnvioVal = Convert.ToDateTime(dgvPeticionesCompletadas.Rows[e.RowIndex].Cells["Fecha_De_Envio"].Value);
                PeticionDescripcionVal = filaSeleccionada.Cells["Peticion"].Value.ToString();
                PeticionUsuarioVal = filaSeleccionada.Cells["Usuario"].Value.ToString();
                PeticionEstadoVal = filaSeleccionada.Cells["Estado"].Value.ToString();

            }
        }

        private void btnRefreshDG_Click(object sender, EventArgs e)
        {
            CargarPeticiones();
        }

        private void btnVisualizarRegistro_Click(object sender, EventArgs e)
        {
            var peticionView = new PeticionesRegisro(IdEmpleado);
            peticionView.lblTituloRegistro.Text = "Ver Petición";

            peticionView.txtCodigoGenerado.Text = PeticionCodigoVal;
            peticionView.txtCodigoGenerado.Enabled = false;

            peticionView.cbxPeticion.Text = PeticionAccionVal;
            peticionView.cbxPeticion.Enabled = false;

            peticionView.txtDescripcion.Text = PeticionDescripcionVal;
            peticionView.txtDescripcion.Enabled = false;

            peticionView.txtUsuarioName.Text = PeticionUsuarioVal;
            peticionView.txtUsuarioName.Enabled = false;

            peticionView.dtpFechaEnviada.Value = PeticionFecha_De_EnvioVal;
            peticionView.dtpFechaEnviada.Enabled = false;

            peticionView.cbxEstadoCuenta.Text = PeticionEstadoVal;
            peticionView.cbxEstadoCuenta.Enabled = false;

            peticionView.btnCancelar.Text = "Salir";
            peticionView.btnGuardarUser.Hide();

            peticionView.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (PeticionEstadoVal == "Completado")
            {
                MessageBox.Show("La petición ya está completada.");
            }
            else if (PeticionAccionVal == "Recuperación de contraseña")
            {
                var peticionesRecuperacion = new PeticionRecuperacionDeContraseña();
                peticionesRecuperacion.lblTituloRegistro.Text = "Recuperación de contraseña";

                peticionesRecuperacion.txtCodigoGenerado.Text = PeticionCodigoVal;
                peticionesRecuperacion.txtCodigoGenerado.Enabled = false;

                peticionesRecuperacion.txtEmail.Text = PeticionEmailVal;
                peticionesRecuperacion.txtEmail.Enabled = false;

                peticionesRecuperacion.txtAccionPeticion.Text = PeticionAccionVal;
                peticionesRecuperacion.txtAccionPeticion.Enabled = false;

                peticionesRecuperacion.txtDescripcion.Text = PeticionDescripcionVal;
                peticionesRecuperacion.txtDescripcion.Enabled = false;

                peticionesRecuperacion.dtpFechaEnviada.Value = PeticionFecha_De_EnvioVal;
                peticionesRecuperacion.dtpFechaEnviada.Enabled = false;

                peticionesRecuperacion.txtUsername.Text = PeticionUsuarioVal;
                peticionesRecuperacion.txtUsername.Enabled = false;

                peticionesRecuperacion.txtEstado.Text = PeticionEstadoVal;
                peticionesRecuperacion.txtEstado.Enabled = false;

                peticionesRecuperacion.txtNuevaClave.Enabled = false;

                peticionesRecuperacion.btnRecuperacion.Text = "CONFIRMAR";
                peticionesRecuperacion.btnCancelar.Text = "CANCELAR";

                peticionesRecuperacion.Show();

                PeticionesRegisro frmpeticionesRegistro = new PeticionesRegisro(2);
            }
            else
            {
                /*  var peticionEditar = new PeticionesRegisro(IdEmpleado);
                  peticionEditar.lblTituloRegistro.Text = "Editar Petición";

                  peticionEditar.txtCodigoGenerado.Text = PeticionCodigoVal;
                  peticionEditar.txtCodigoGenerado.Enabled = false;

                  peticionEditar.cbxPeticion.Text = PeticionAccionVal;
                  peticionEditar.cbxPeticion.Enabled = false;

                  peticionEditar.txtDescripcion.Text = PeticionDescripcionVal;
                  peticionEditar.txtDescripcion.Enabled = false;

                  peticionEditar.txtUsuarioName.Text = PeticionUsuarioVal;
                  peticionEditar.txtUsuarioName.Enabled = false;

                  peticionEditar.dtpFechaEnviada.Value = PeticionFecha_De_EnvioVal;
                  peticionEditar.dtpFechaEnviada.Enabled = false;

                  peticionEditar.cbxEstadoCuenta.Text = PeticionEstadoVal;
                  peticionEditar.cbxEstadoCuenta.Enabled = true;

                  peticionEditar.btnGuardarUser.Text = "CONFIRMAR";
                  peticionEditar.btnCancelar.Text = "CANCELAR";
                  peticionEditar.btnCancelar.Hide();

                  peticionEditar.Show();

                  peticionEditar.btnGuardarUser.Click += (s, args) =>
                  {
                      PeticionRegistro peticionActualizada = new PeticionRegistro
                      {
                          CodigPeticion = peticionEditar.txtCodigoGenerado.Text,
                          AccionPeticion = peticionEditar.cbxPeticion.Text,
                          Descripcion = peticionEditar.txtDescripcion.Text,
                          FechaEnviada = peticionEditar.dtpFechaEnviada.Value,
                          FechaRealizada = DateTime.Now,
                          CodigoUsuario = IdEmpleado,
                          Estado = peticionEditar.cbxEstadoCuenta.Text
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
                  };*/
            }

        }

        private void btnEliminarUsuario_Click_1(object sender, EventArgs e)
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
                bool eliminado = PeticionesDAO.EliminarPeticion(PeticionCodigoVal);

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

        /// <summary>
        /// Maneja el evento de clic en una celda dentro del DataGridView 'dgvPeticionesPendientes'.
        /// Este evento se dispara cuando el usuario hace clic en cualquier fila de la tabla de peticiones pendientes.
        /// Al hacer clic en una fila, el método extrae los datos de las celdas de esa fila y los almacena en las variables correspondientes.
        /// Además, muestra u oculta el botón de actualización dependiendo de la acción de la petición.
        /// </summary>
        private void dgvPeticionesPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvPeticionesPendientes.Rows[e.RowIndex];

                // Asigna los valores de la petición pendiente
                PeticionCodigoVal = filaSeleccionada.Cells["Codigo"].Value.ToString();
                PeticionAccionVal = filaSeleccionada.Cells["Accion"].Value.ToString();
                PeticionFecha_De_EnvioVal = Convert.ToDateTime(filaSeleccionada.Cells["Fecha_De_Envio"].Value);
                PeticionDescripcionVal = filaSeleccionada.Cells["Peticion"].Value.ToString();
                PeticionUsuarioVal = filaSeleccionada.Cells["Usuario"].Value.ToString();
                PeticionEmailVal = filaSeleccionada.Cells["Correo"].Value.ToString();
                PeticionEstadoVal = filaSeleccionada.Cells["Estado"].Value.ToString();

                if (PeticionAccionVal == "Recuperación de contraseña")
                {
                    btnActualizar.Show();
                    btnActualizar.Enabled = true;
                }
                else
                {
                    btnActualizar.Hide();
                    btnActualizar.Enabled = false;
                }
            }
        }

        private void btnUsuarioPanel_Click(object sender, EventArgs e)
        {
            if (FormPrincipal != null)
            {
               FormPrincipal.AbrirFormsHija(new PeticionesUser(IdEmpleado, NombreUsuarioAjuste) { FormPrincipal = FormPrincipal });
            }
            else
            {
                MessageBox.Show("FormPrincipal es nulo");
            }
        }
    }
}

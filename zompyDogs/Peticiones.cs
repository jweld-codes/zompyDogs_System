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

namespace zompyDogs
{
    public partial class Peticiones : Form
    {
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }
        public BienvenidaAdmin FormPrincipal { get; set; }
        public string NombreUsuarioAjuste { get; set; }

        PeticionRecuperacionDeContraseña frmSolicitudDeRecuperacionCuenta;
        public PeticionesRegisro frmPeticionesRegisro;
        int idAdmin;
        public int IdEmpleado { get; set; }

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

        public Peticiones(int idEmpledo, string usuarioNombre)
        {

            InitializeComponent();
            IdEmpleado = idEmpledo;
            NombreUsuarioAjuste = usuarioNombre;

            dgvPeticionesCompletadas.CellClick += dgvPeticiones_CellClick;
            dgvPeticionesPendientes.CellClick += dgvPeticionesPendientes_CellClick;

            CargarPeticiones();
            btnActualizar.Hide();
            btnEliminarUsuario.Hide();

        }

        public void CargarPeticiones()
        {
            dgvPeticionesPendientes.DataSource = PeticionesValidaciones.ObtenerPeticionesPendientes();
            dgvPeticionesCompletadas.DataSource = PeticionesValidaciones.ObtenerPeticionesCompletadas();

            dgvPeticionesPendientes.CurrentCell = null;
            dgvPeticionesCompletadas.CurrentCell = null;

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

        private void btnAgregarRegistro_Click(object sender, EventArgs e)
        {
            var peticionesRegistro = new PeticionesRegisro(IdEmpleado);
            peticionesRegistro.lblTituloRegistro.Text = "Guardar Nueva Petición";
            peticionesRegistro.Show();

            DataTable peticionGuardarUser = PeticionesValidaciones.BuscarPeticionesPorIDUsuario(IdEmpleado);
            if (peticionGuardarUser.Rows.Count > 0)
            {
                DataRow fila = peticionGuardarUser.Rows[0];

                PeticionUsuarioGuardar = fila["Usuario"].ToString();
            }

            peticionesRegistro.txtUsuarioName.Text = PeticionUsuarioGuardar;

            peticionesRegistro.label3.Hide();
            peticionesRegistro.btnGuardarUser.Text = "GUARDAR";
            peticionesRegistro.btnCancelar.Text = "CANCELAR";
            peticionesRegistro.txtUsuarioName.Enabled = false;

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
                    CargarPeticiones(); // Refresca el DataGridView
                }
                else
                {
                    MessageBox.Show("Error al eliminar la petición.");
                }
            }
        }

        private void dgvPeticiones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvPeticionesCompletadas.Rows[e.RowIndex];

                PeticionCodigoVal = filaSeleccionada.Cells["Codigo"].Value.ToString();
                PeticionAccionVal = filaSeleccionada.Cells["Accion"].Value.ToString();
                PeticionFecha_De_EnvioVal = Convert.ToDateTime(dgvPeticionesCompletadas.Rows[e.RowIndex].Cells["Fecha_De_Envio"].Value);
                PeticionDescripcionVal = filaSeleccionada.Cells["Peticion"].Value.ToString();
                PeticionUsuarioVal = filaSeleccionada.Cells["Usuario"].Value.ToString();
                PeticionEstadoVal = filaSeleccionada.Cells["Estado"].Value.ToString();

            }
        }

        /*private void cbxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFiltro.SelectedItem != null)
            {
                string estadoSeleccionado = cbxFiltro.SelectedItem.ToString();

                if (estadoSeleccionado == "Pendiente")
                {
                    DataTable peticionesEstado = PeticionesValidaciones.FiltroPendienteCompletado("Pendiente");
                    dgvPeticionesCompletadas.DataSource = peticionesEstado;
                }
                else if (estadoSeleccionado == "Completado")
                {
                    DataTable peticionesCompletadas = PeticionesValidaciones.FiltroPendienteCompletado("Completado");
                    dgvPeticionesCompletadas.DataSource = peticionesCompletadas;
                }
                else if (estadoSeleccionado == "Activo")
                {
                    DataTable peticionesCompletadas = PeticionesValidaciones.FiltroPendienteCompletado("ACTIVO");
                    dgvPeticionesCompletadas.DataSource = peticionesCompletadas;
                }
                else if (estadoSeleccionado == "Inactivo")
                {
                    DataTable peticionesCompletadas = PeticionesValidaciones.FiltroPendienteCompletado("INACTIVO");
                    dgvPeticionesCompletadas.DataSource = peticionesCompletadas;
                }
                else if (estadoSeleccionado == "Todos")
                {
                    CargarPeticiones();
                }
                else
                {
                    CargarPeticiones();
                }
            }
        }*/

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

    }
}

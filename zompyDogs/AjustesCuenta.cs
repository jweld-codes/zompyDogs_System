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

            MessageBox.Show("IdEmpleado: " + IdEmpleado);
            MessageBox.Show("NombreUsuario: " + NombreUsuarioAjuste);

            CargarPeticiones();

            gbxDatosPersonales.Show();
            gbxDatosUsuarios.Hide();
            gbxPeticionesBtn.Hide();
            gbxPeticiones.Hide();

            rectanglePanel1.Show();
            rectanglePanel2.Hide();
            rectanglePanel3.Hide();
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
                    this.Close();
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
    }
}

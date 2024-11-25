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
using static ZompyDogsDAO.PeticionesDAO;
using static ZompyDogsDAO.UsuarioDAO;

namespace zompyDogs
{
    public partial class PeticionesUser : Form
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
        public PeticionesUser(int usuarioID, string usuarioNombre)
        {
            InitializeComponent();

            IdEmpleado = usuarioID;
            NombreUsuarioAjuste = usuarioNombre;

            CargarPeticiones();

            gbxPeticionesBtn.Show();
            gbxPeticiones.Show();
            btnPeticionesUser.Show();
            panel1.Show();
        }
        public void InicializarAdmin()
        {
            BienvenidaAdmin frmBienvenidaForm = new BienvenidaAdmin();
            NombreUsuarioAjuste = frmBienvenidaForm.lblNombreSideBar.Text;
        }
        public void CargarPeticiones()
        {
            DataTable peticiones = PeticionesDAO.ObtenerPeticionesCompletasAjustes(IdEmpleado);
            dgvPeticiones.DataSource = peticiones;

            dgvPeticiones.Columns["Codigo"].HeaderText = "Código";
            dgvPeticiones.Columns["Accion"].HeaderText = "Acción";
            dgvPeticiones.Columns["Peticion"].HeaderText = "Petición";
            dgvPeticiones.Columns["Fecha_De_Envio"].HeaderText = "Fecha de Envío";
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

        private void btnPeticionesUser_Click(object sender, EventArgs e)
        {
            gbxPeticiones.Show();
            gbxPeticionesBtn.Show();
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
                    ZompyDogsLib.Peticiones.PeticionRegistro nuevaPeticion = new ZompyDogsLib.Peticiones.PeticionRegistro
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
                        PeticionesDAO.GuardarPeticion(nuevaPeticion);

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

            DataTable peticionEditar = PeticionesDAO.ObtenerPeticionesUsuarioParaEditar(PeticionCodigoVal);

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
                    ZompyDogsLib.Peticiones.PeticionRegistro peticionActualizada = new ZompyDogsLib.Peticiones.PeticionRegistro
                    {
                        CodigPeticion = frmpeticionesRegistro.txtCodigoGenerado.Text,
                        AccionPeticion = frmpeticionesRegistro.cbxPeticion.Text,
                        Descripcion = frmpeticionesRegistro.txtDescripcion.Text,
                        FechaEnviada = frmpeticionesRegistro.dtpFechaEnviada.Value,
                        FechaRealizada = DateTime.Now,
                        CodigoUsuario = IdEmpleado,
                        Estado = frmpeticionesRegistro.cbxEstadoCuenta.Text
                    };
                    bool resultado = PeticionesDAO.ActualizarPeticion(peticionActualizada);

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

            DataTable peticionEditar = PeticionesDAO.ObtenerPeticionesUsuarioParaEditar(PeticionCodigoVal);

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

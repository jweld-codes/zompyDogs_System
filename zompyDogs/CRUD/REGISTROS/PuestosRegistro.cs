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
using static ZompyDogsDAO.UsuarioDAO;

namespace zompyDogs.CRUD.REGISTROS
{
    public partial class PuestosRegistro : Form
    {
        private string nuevoCodigoPuesto;
        private ControladorGeneradoresDeCodigo _controladorGeneradorCodigo;
        private string puestCodigoVal;
        private bool isEdition;
        private bool okError;
        public PuestosRegistro()
        {
            InitializeComponent();

            CargarPuestos();
            _controladorGeneradorCodigo = new ControladorGeneradoresDeCodigo();
            GeneradordeCodigoPuestoFromForm();
            CargarRolesComboBox();

            errorProviderPuesto.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            cbxEstado.Text = "Elegir...";
            cbxRoles.Text = "Elegir...";
            txtDiasLaborales.Hide();

            isEdition = false;

            //CheckBox Changed
            chbxLunes.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxMartes.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxMiercoles.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxJueves.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxViernes.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxSabado.CheckedChanged += (s, e) => ActualizarDiasLaborales();
            chbxDomingo.CheckedChanged += (s, e) => ActualizarDiasLaborales();
        }

        private void CargarPuestos()
        {
            DataTable puestos = UsuarioDAO.ObtenerDetalllesPuestos();
            dgvPuestos.DataSource = puestos;
            dgvPuestos.ClearSelection();
        }
        private void GeneradordeCodigoPuestoFromForm()
        {
            nuevoCodigoPuesto = _controladorGeneradorCodigo.GeneradordeCodigoPuesto();
            txtCodigoGeneradoPuesto.Text = nuevoCodigoPuesto;
        }
        private void CargarRolesComboBox()
        {
            DataTable dtRoles = UsuarioDAO.ObtenerRolesParaComboBox();

            cbxRoles.DataSource = dtRoles;
            cbxRoles.DisplayMember = "Rol";
            cbxRoles.ValueMember = "Id_Rol";
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
           // if (chbxDomingo.Checked) diasSeleccionados.Add("Domingo");

            txtDiasLaborales.Text = string.Join(",", diasSeleccionados);
        }
        public bool ValidarCampos()
        {
            okError = true;

            List<TextBox> textBoxes = new List<TextBox> { txtNombrePuesto, txtSalario, txtDescripcion, txtDiasLaborales };
            List<System.Windows.Forms.CheckBox> checkBoxes = new List<System.Windows.Forms.CheckBox> { chbxLunes, chbxMartes, chbxMiercoles, chbxJueves, chbxViernes, chbxSabado };

            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    okError = false;
                    errorProviderPuesto.SetError(textBox, $"Ingrese un valor en el campo.");
                    textBox.BackColor = Color.OldLace;
                }
                else
                {
                    errorProviderPuesto.SetError(textBox, "");
                    textBox.BackColor = SystemColors.Window;
                }
            }
            foreach (System.Windows.Forms.CheckBox checkBox in checkBoxes)
            {
                if (!checkBox.Checked)
                {
                    okError = false;
                    errorProviderPuesto.SetError(checkBox, "Debe marcar esta opción.");
                }
                else
                {
                    errorProviderPuesto.SetError(checkBox, "");
                }
            }
            return okError;
        }

        private void btnGuardarPuesto_Click(object sender, EventArgs e)
        {

            if (isEdition)
            {
                if (okError == false)
                {
                    ValidarCampos();
                }
                else
                {
                    btnGuardarPuesto.Text = "Editar";

                    if (string.IsNullOrWhiteSpace(txtNombrePuesto.Text) ||
                        string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                        string.IsNullOrWhiteSpace(txtSalario.Text) ||
                        string.IsNullOrWhiteSpace(txtDiasLaborales.Text) ||
                        string.IsNullOrWhiteSpace(txtCodigoGeneradoPuesto.Text) ||
                        string.IsNullOrWhiteSpace(cbxEstado.Text) ||
                        cbxRoles.SelectedIndex == -1)
                    {
                        MessageBox.Show("Por favor, complete todos los campos requeridos.");
                        return;
                    }

                    string diasLaboralesSeleccionadas = txtDiasLaborales.Text;

                    TimeSpan horaInicio = new TimeSpan(tmBegin.Value.Hour, tmBegin.Value.Minute, 0);
                    TimeSpan horaFin = new TimeSpan(tmEnd.Value.Hour, tmEnd.Value.Minute, 0);

                    ZompyDogsLib.Usuarios.PuestoREF puestoActualizar = new ZompyDogsLib.Usuarios.PuestoREF
                    {
                        CodigoPuesto = txtCodigoGeneradoPuesto.Text,
                        Puesto = txtNombrePuesto.Text,
                        Descripcion = txtDescripcion.Text,
                        Salario = Convert.ToDecimal(txtSalario.Text),
                        DiasLaborales = diasLaboralesSeleccionadas,
                        CodigoRol = Convert.ToInt32(cbxRoles.SelectedValue),
                        Estado = cbxEstado.Text,
                        HoralaboralInicio = horaInicio,
                        HoraLaboralTermina = horaFin
                    };

                    try
                    {
                        bool puestoActualizado = UsuarioDAO.ActualizarPuesto(puestoActualizar);

                        if (puestoActualizado)
                        {
                            MessageBox.Show("Puesto actualizado con éxito.");
                            CargarPuestos();

                            chbxLunes.Checked = false;
                            chbxMartes.Checked = false;
                            chbxMiercoles.Checked = false;
                            chbxJueves.Checked = false;
                            chbxViernes.Checked = false;
                            chbxSabado.Checked = false;
                            chbxDomingo.Checked = false;

                            cbxRoles.Text = "Elegir...";
                            cbxEstado.Text = "Elegir...";
                            txtDescripcion.Text = string.Empty;
                            txtSalario.Text = string.Empty;
                            txtDiasLaborales.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar el puesto.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al actualizar el puesto: " + ex.Message);
                    }
                }
            }
            else
            {
                ValidarCampos();
                if (okError == false)
                {
                    ValidarCampos();
                }
                else
                {
                    btnGuardarPuesto.Text = "Guardar";
                    ZompyDogsLib.Usuarios.PuestoREF nuevoPuesto = new ZompyDogsLib.Usuarios.PuestoREF
                    {
                        Puesto = txtNombrePuesto.Text,
                        Descripcion = txtDescripcion.Text,
                        Salario = Convert.ToInt32(txtSalario.Text),
                        DiasLaborales = txtDiasLaborales.Text,
                        CodigoPuesto = txtCodigoGeneradoPuesto.Text,
                        CodigoRol = cbxRoles.SelectedValue != null && int.TryParse(cbxRoles.SelectedValue.ToString(), out int codigoRol)
                    ? codigoRol
                    : 1,
                        Estado = cbxEstado.Text,

                        HoralaboralInicio = new TimeSpan(tmBegin.Value.Hour, tmBegin.Value.Minute, 0),
                        HoraLaboralTermina = new TimeSpan(tmEnd.Value.Hour, tmEnd.Value.Minute, 0)
                    };
                    try
                    {
                        if (string.IsNullOrWhiteSpace(nuevoPuesto.Puesto) ||
                            string.IsNullOrWhiteSpace(nuevoPuesto.Descripcion) ||
                            string.IsNullOrWhiteSpace(nuevoPuesto.DiasLaborales) ||
                            string.IsNullOrWhiteSpace(nuevoPuesto.CodigoPuesto) ||
                            string.IsNullOrWhiteSpace(nuevoPuesto.Estado))
                        {
                            MessageBox.Show("Por favor, complete todos los campos requeridos.");
                            return;
                        }
                        // Guardar DetalleUsuario
                        UsuarioDAO.GuardarPuesto(nuevoPuesto);

                        MessageBox.Show("Puesto Registrado con Éxito.");
                        CargarPuestos();
                        GeneradordeCodigoPuestoFromForm();

                        chbxLunes.Checked = false;
                        chbxMartes.Checked = false;
                        chbxMiercoles.Checked = false;
                        chbxJueves.Checked = false;
                        chbxViernes.Checked = false;
                        chbxSabado.Checked = false;
                        chbxDomingo.Checked = false;

                        txtNombrePuesto.Text = string.Empty;
                        txtDescripcion.Text = string.Empty;
                        txtSalario.Text = string.Empty;
                        txtDiasLaborales.Text = string.Empty;
                    }
                    catch
                    {
                        MessageBox.Show("Error al registrar el Puesto.");

                    }
                }

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPuestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvPuestos.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                puestCodigoVal = filaSeleccionada.Cells["Codigo"].Value.ToString();
            }
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("¿Está seguro de eliminar este puesto?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                bool eliminarPuesto = UsuarioDAO.EliminarPuesto(puestCodigoVal);

                if (eliminarPuesto)
                {
                    MessageBox.Show("Puesto eliminado con éxito.");
                    CargarPuestos();
                    txtCodigoGeneradoPuesto.Text = string.Empty;
                    txtNombrePuesto.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    txtSalario.Text = string.Empty;
                    txtDiasLaborales.Text = string.Empty;

                    chbxLunes.Checked = false;
                    chbxMartes.Checked = false;
                    chbxMiercoles.Checked = false;
                    chbxJueves.Checked = false;
                    chbxViernes.Checked = false;
                    chbxSabado.Checked = false;
                    chbxDomingo.Checked = false;

                    cbxRoles.Text = "Elegir...";
                    cbxEstado.Text = "Elegir...";
                    txtDescripcion.Text = string.Empty;
                    txtSalario.Text = string.Empty;
                    txtDiasLaborales.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error al eliminar el Puesto.");
                }
            }
        }

        private void btnAgregarNuevoPuesto_Click(object sender, EventArgs e)
        {
            isEdition = false;
            btnGuardarPuesto.Text = "Guardar";

            txtNombrePuesto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtSalario.Text = string.Empty;
            txtDiasLaborales.Text = string.Empty;

            GeneradordeCodigoPuestoFromForm();

            cbxEstado.Text = "Elegir...";
            cbxRoles.Text = "Elegir...";
            tmBegin.Text = "07:00:00";
            tmEnd.Text = "15:00:00";

            chbxLunes.Checked = false;
            chbxMartes.Checked = false;
            chbxMiercoles.Checked = false;
            chbxJueves.Checked = false;
            chbxViernes.Checked = false;
            chbxSabado.Checked = false;
            chbxDomingo.Checked = false;
        }

        private void btnEditarPuesto_Click(object sender, EventArgs e)
        {
            isEdition = true;
            btnGuardarPuesto.Text = "Editar";
            cbxEstado.Enabled = true;

            DataTable puestosEditar = UsuarioDAO.ObtenerDetalllesPuestosParaEditar(puestCodigoVal);

            if (puestosEditar.Rows.Count > 0)
            {
                DataRow fila = puestosEditar.Rows[0];

                txtCodigoGeneradoPuesto.Text = fila["Codigo"].ToString();
                txtCodigoGeneradoPuesto.Enabled = false;

                txtNombrePuesto.Text = fila["Puesto"].ToString();
                txtDescripcion.Text = fila["Descripcion"].ToString();
                txtSalario.Text = fila["Salario"].ToString();
                txtDiasLaborales.Text = fila["DiasLaboral"].ToString();
                tmBegin.Text = fila["Hora_De_Inicio"].ToString();
                tmEnd.Text = fila["Hora_De_Fin"].ToString();

                cbxRoles.Text = fila["RolAsignado"].ToString();
                cbxEstado.Text = fila["Estado"].ToString();

                string diasLaborales = fila["DiasLaboral"].ToString();
                chbxLunes.Checked = diasLaborales.Contains("Lunes");
                chbxMartes.Checked = diasLaborales.Contains("Martes");
                chbxMiercoles.Checked = diasLaborales.Contains("Miércoles");
                chbxJueves.Checked = diasLaborales.Contains("Jueves");
                chbxViernes.Checked = diasLaborales.Contains("Viernes");
                chbxSabado.Checked = diasLaborales.Contains("Sábado");
                chbxDomingo.Checked = diasLaborales.Contains("Domingo");

            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtNombrePuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        





    }
}

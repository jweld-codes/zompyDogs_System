using Azure.Core;
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
using ZompyDogsLib.Controladores;

namespace zompyDogs
{
    public partial class UsuarioRegistro : Form
    {
        private ControladorGeneradoresDeCodigo _controladorGeneradorCodigo;

        private string nuevoCodigoUsuario;
        private bool isTheUsername = false;

        public UsuarioRegistro()
        {
            InitializeComponent();

            _controladorGeneradorCodigo = new ControladorGeneradoresDeCodigo();

            GeneradordeCodigoUsuarioFromForm();
            CargarRolesComboBox();

            int siguienteID = UsuarioDAO.ObtenerSiguienteID();
            lblidDetalleUsuario.Text = siguienteID.ToString();

            cbxRol.SelectedIndexChanged += cbxRol_SelectedIndexChanged;

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
                else if (codigoRolSeleccionado == 4) // 2 para Usuario
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

            cbPuesto.DataSource = dtPuestos;
            cbPuesto.DisplayMember = "puesto";
            cbPuesto.ValueMember = "IdPuesto";
        }
        public void CargarPuestosAdminsComboBox()
        {
            DataTable dtPuestos = UsuarioDAO.ObtenerPuestosDeAdminsParaComboBox();

            cbPuesto.DataSource = dtPuestos;
            cbPuesto.DisplayMember = "puesto";
            cbPuesto.ValueMember = "IdPuesto";
        }
        public void CargarPuestosUsuariosComboBox()
        {
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
    }
}

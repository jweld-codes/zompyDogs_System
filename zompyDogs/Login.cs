using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ZompyDogsDAO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using zompyDogs.CRUD.REGISTROS;

namespace zompyDogs
{
    public partial class Login : Form
    {
        private Peticiones frmPeticionesAdmin;
        public static int UsuarioIdActual { get; private set; }
        public static int RolIdActual { get; private set; }

        public Login()
        {
            InitializeComponent();
            seeCloseIcon.Visible = false;

        }

        private void btnIniciarSession_Click(object sender, EventArgs e)
        {
            var (isValid, isAdmin, nombreUser, apeUser, username, idEmpleado, idRol) = UsuarioValidaciones.IsValidUser(txtUser.Text, txtPassword.Text);

            string validUser = txtUser.Text;
            string validpassword = txtPassword.Text;

            if (!isValid)
            {
                MessageBox.Show("Usuario o Clave Incorrecto. Intentar Nuevamente");
                txtPassword.Text = "";
                txtUser.Text = "";
            }
            else
            {
                UsuarioIdActual = idEmpleado;
                RolIdActual = idRol;

                MessageBox.Show("idEmpleado: "+ UsuarioIdActual + "RolIdActual: "+ RolIdActual);

                if (isAdmin)
                {
                    BienvenidaAdmin frmBienvenidaAdmin = new BienvenidaAdmin();
                    frmBienvenidaAdmin.IdEmpleado = idEmpleado;
                    frmBienvenidaAdmin.RolID = idRol;
                    frmBienvenidaAdmin.lblNombreSideBar.Text = $"{nombreUser} {apeUser}";

                    PanelAdmin frmPanelAdmin = new PanelAdmin();
                    frmPanelAdmin.NombreUsuario = $"{nombreUser} {apeUser}";

                    PeticionesRegisro frmPeticionesRegistro = new PeticionesRegisro(idEmpleado);
                    frmPeticionesRegistro.IdEmpleado = idEmpleado;

                    Peticiones frmPeticiones = new Peticiones(idEmpleado);
                    frmPeticiones.IdEmpleado = idEmpleado;

                    frmBienvenidaAdmin.AbrirFormsHija(frmPanelAdmin);
                    frmBienvenidaAdmin.Show();
                    this.Hide();
                }
                else
                {

                    EmpleadoBienvenida frmBienvenidaUsuario = new EmpleadoBienvenida();
                    frmBienvenidaUsuario.IdEmpleado = idEmpleado;
                    frmBienvenidaUsuario.RolID = idRol;
                    frmBienvenidaUsuario.lblNombreSideBar.Text = $"{nombreUser} {apeUser}";

                    PanelEmpleado frmPanelEmpleado = new PanelEmpleado();
                    frmPanelEmpleado.NombreUsuarioEmpleado = $"{nombreUser} {apeUser}";
                    frmPanelEmpleado.InicializarEmpleado(idEmpleado);

                    frmBienvenidaUsuario.AbrirFormsHijaEmpleado(frmPanelEmpleado);
                    frmBienvenidaUsuario.Show();

                    this.Hide();
                }

                this.Hide();
            }

        }

        private void lblAnClaveOlv_Click(object sender, EventArgs e)
        {
            ClaveOlvidada frmClaveOlvidada = new ClaveOlvidada();
            frmClaveOlvidada.Show();
            this.Hide();
        }

        private void lblAnClaveOlv_MouseEnter(object sender, EventArgs e)
        {
            lblAnClaveOlv.ForeColor = Color.Silver;
        }

        private void lblAnClaveOlv_MouseLeave(object sender, EventArgs e)
        {
            lblAnClaveOlv.ForeColor = Color.White;
        }

        private void seeIcon_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
            seeIcon.Hide();
            seeCloseIcon.Visible = true;
        }

        private void seeCloseIcon_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            seeIcon.Show();
            seeCloseIcon.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciarSession_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIniciarSession_Click(sender, e);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}

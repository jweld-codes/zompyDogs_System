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
        // Referencia al formulario de peticiones para administradores.
        private Peticiones frmPeticionesAdmin;

        // Propiedades estáticas para almacenar información del usuario actual.
        public static int UsuarioIdActual { get; private set; } // ID del usuario logueado.
        public static int RolIdActual { get; private set; }     // ID del rol del usuario logueado.
        public static string UsuarioName { get; private set; }  // Nombre del usuario logueado.


        public Login()
        {
            InitializeComponent();
            seeCloseIcon.Visible = false; // Oculta el icono de cerrar al iniciar la aplicación.

        }
        private void btnIniciarSession_Click(object sender, EventArgs e)
        {
            // Valida las credenciales del usuario.
            var (isValid, isAdmin, nombreUser, apeUser, username, idEmpleado, idRol) = LoginValidacion.IsValidUser(txtUser.Text, txtPassword.Text);

            // Variables locales para manejar los datos ingresados.
            string validUser = txtUser.Text;
            string validpassword = txtPassword.Text;

            // Asigna los valores obtenidos de la validación a las propiedades estáticas.
            UsuarioIdActual = idEmpleado;
            RolIdActual = idRol;
            UsuarioName = $"{nombreUser} {apeUser}"; // Combina el nombre y apellido del usuario.

            // Si las credenciales no son válidas, muestra un mensaje de error.
            if (!isValid)
            {
                MessageBox.Show("Usuario o Clave Incorrecto. Intentar Nuevamente");
                txtUser.Focus();
                txtPassword.Text = "";
                txtUser.Text = "";
            }
            else
            {
                // Si el usuario es administrador, abre el panel de administrador.
                if (isAdmin)
                {
                    // Crea una instancia del formulario de bienvenida para administradores.
                    BienvenidaAdmin frmBienvenidaAdmin = new BienvenidaAdmin();
                    frmBienvenidaAdmin.IdEmpleado = idEmpleado; // Asigna el ID del empleado.
                    frmBienvenidaAdmin.RolID = idRol; // Asigna el ID del rol
                    frmBienvenidaAdmin.UsuarioNombreAdmin = UsuarioName; // Asigna el nombre completo del administrador
                    frmBienvenidaAdmin.lblNombreSideBar.Text = $"{UsuarioName}"; // Actualiza la etiqueta con el nombre del usuario.

                    // Crea e inicializa el panel de administración.
                    PanelAdmin frmPanelAdmin = new PanelAdmin();
                    frmPanelAdmin.NombreUsuario = $"{UsuarioName}";

                    // Crea e inicializa los formularios relacionados con peticiones.
                    PeticionesRegisro frmPeticionesRegistro = new PeticionesRegisro(idEmpleado);
                    frmPeticionesRegistro.IdEmpleado = idEmpleado; // Asigna el ID del empleado al formulario de peticiones.

                    Peticiones frmPeticiones = new Peticiones(idEmpleado, UsuarioName);
                    frmPeticiones.IdEmpleado = idEmpleado; // Asigna el ID del empleado al formulario de peticiones.

                    // Abre el panel de administración dentro del formulario de bienvenida.
                    frmBienvenidaAdmin.AbrirFormsHija(frmPanelAdmin);

                    // Muestra el formulario de bienvenida del administrador.
                    frmBienvenidaAdmin.Show();
                    this.Hide();
                }
                else
                {
                    // Si el usuario es un empleado, abre el formulario de bienvenida para empleados.
                    EmpleadoBienvenida frmBienvenidaUsuario = new EmpleadoBienvenida();
                    frmBienvenidaUsuario.IdEmpleado = idEmpleado;
                    frmBienvenidaUsuario.RolID = idRol;
                    frmBienvenidaUsuario.lblNombreSideBar.Text = $"{nombreUser} {apeUser}";

                    // Crea e inicializa el panel de empleados.
                    PanelEmpleado frmPanelEmpleado = new PanelEmpleado(idEmpleado);
                    frmPanelEmpleado.NombreUsuarioEmpleado = $"{nombreUser} {apeUser}";

                    // Abre el panel de empleado dentro del formulario de bienvenida.
                    frmBienvenidaUsuario.AbrirFormsHijaEmpleado(frmPanelEmpleado);
                    frmBienvenidaUsuario.Show();

                    this.Hide();
                }
                this.Hide();
            }
        }

        // Lleva al usuario al formulario de ClaveOlvidada para solicitar una recuperación de contraseña
        private void lblAnClaveOlv_Click(object sender, EventArgs e)
        {
            ClaveOlvidada frmClaveOlvidada = new ClaveOlvidada();
            frmClaveOlvidada.Show();
            this.Hide();
        }
        
        /* ******** Efecto Hover en el label Clave Olvidada *******  */
        private void lblAnClaveOlv_MouseEnter(object sender, EventArgs e)
        {
            lblAnClaveOlv.ForeColor = Color.Silver;
        }

        private void lblAnClaveOlv_MouseLeave(object sender, EventArgs e)
        {
            lblAnClaveOlv.ForeColor = Color.White;
        }

        
        // Icono de mostrat u ocultar la clave introducida.
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

        //  Al dar en la tecla enter, pueda iniciar sessión sin darle clic en el botón Entrar
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

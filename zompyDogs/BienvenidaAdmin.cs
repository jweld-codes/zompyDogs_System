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
using ZompyDogsLib;

namespace zompyDogs
{
    public partial class BienvenidaAdmin : Form
    {
        public int IdEmpleado { get; set; }
        public int RolID { get; set; }
        public string UsuarioNombreAdmin { get; set; }
        public BienvenidaAdmin()
        {
            InitializeComponent();
        }

        public void AbrirFormsHija(Form formHija)
        {
            // Limpiar el panel antes de agregar un nuevo formulario
            while (panelContenedor.Controls.Count > 0)
            {
                panelContenedor.Controls.RemoveAt(0);
            }

            // Configurar el formulario hijo
            formHija.TopLevel = false;
            formHija.FormBorderStyle = FormBorderStyle.None;
            formHija.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formHija);  // Agrega el formulario al panel
            panelContenedor.Tag = formHija;
            formHija.Show();
        }

        private void lblCerrarSession_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("¿Está seguro de cerrar sessión?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                this.Hide();
                Login frmLogin = new Login();
                frmLogin.Show();
            }
        }
        private void lblCerrarSession_MouseEnter(object sender, EventArgs e)
        {
            lblCerrarSession.ForeColor = Color.Silver;
        }

        private void lblCerrarSession_MouseLeave(object sender, EventArgs e)
        {
            lblCerrarSession.ForeColor = Color.White;
        }

        private void btnAjustesCuenta_Click(object sender, EventArgs e)
        {
            AbrirFormsHija(new AjustesCuenta(IdEmpleado, UsuarioNombreAdmin));
            CambiarColorBoton((Button)sender);
        }

        private void btnPeticiones_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);

            Peticiones PeticionesForm = new Peticiones(IdEmpleado)
            {
                FormPrincipal = this
            };
            AbrirFormsHija(PeticionesForm);

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            Inventario fmInventario = new Inventario
            {
                FormPrincipal = this
            };
            AbrirFormsHija(fmInventario);

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            Usuarios usuariosForm = new Usuarios
            {
                FormPrincipal = this
            };
            AbrirFormsHija(usuariosForm);
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            Facturas fmFactura = new Facturas(IdEmpleado, RolID)
            {
                FormPrincipal = this
            };
            AbrirFormsHija(fmFactura);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            Menu MenuForm = new Menu
            {
                FormPrincipal = this
            };
            AbrirFormsHija(MenuForm);
        }

        private void btnPedidos_Click_1(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            //AbrirFormsHija(new Reportes());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);

            PanelAdmin fmPanelAdmin = new PanelAdmin();
            fmPanelAdmin.lblNombreUsuario_Panel.Text = lblNombreSideBar.Text;
            AbrirFormsHija(fmPanelAdmin);

        }

        private void CambiarColorBoton(Button botonActivo)
        {
            foreach (Control ctrl in sidebarMenu.Controls)
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

        private void BienvenidaAdmin_Load(object sender, EventArgs e)
        {
            
        }

    }
}

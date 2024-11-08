using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zompyDogs
{
    public partial class EmpleadoBienvenida : Form
    {
        public int IdEmpleado { get; set; }
        public int RolID { get; set; }
        public EmpleadoBienvenida()
        {
            InitializeComponent();
            
        }

        public void AbrirFormsHijaEmpleado(Form formHija)
        {
            while (panelContenedor.Controls.Count > 0)
            {
                panelContenedor.Controls.RemoveAt(0);
            }
            Form formHijo = formHija;
            formHija.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formHijo);
            formHijo.Show();

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

            botonActivo.BackColor = Color.FromArgb(255, 255, 192);
            botonActivo.ForeColor = Color.Black;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            PanelEmpleado frmPanelEmpleado = new PanelEmpleado();
            frmPanelEmpleado.lblNombreUser.Text = lblNombreSideBar.Text;
            AbrirFormsHijaEmpleado(frmPanelEmpleado);
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            //AbrirFormsHijaEmpleado(new Factura());
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            frmPOS fmPuntoDeVenta = new frmPOS(IdEmpleado, RolID)
            {
                EmpleadoFormPrincipal = this
            };
            AbrirFormsHijaEmpleado(fmPuntoDeVenta);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            LibretaMenu LibretaMenuForm = new LibretaMenu
            {
                EmpleadoFormPrincipal = this
            };
            LibretaMenuForm.btnUsuarioPanel.Hide();
            LibretaMenuForm.btnUsuarioPanel.Enabled = false;
            AbrirFormsHijaEmpleado(LibretaMenuForm);


        }

        private void lblCerrarSession_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("¿Está seguro de cerrar sessión?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Login frmLogin = new Login();
                frmLogin.Show();
                this.Hide();
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

    }
}

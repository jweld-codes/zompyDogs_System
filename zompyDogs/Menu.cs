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
using zompyDogs.CRUD.REGISTROS;

namespace zompyDogs
{
    public partial class Menu : Form
    {
        public BienvenidaAdmin FormPrincipal { get; set; }
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }
        public int RolID { get; set; }
        public Menu()
        {
            InitializeComponent();
            CargarPlatillosdeMenu();
        }

        private void CargarPlatillosdeMenu()
        {
            DataTable menu = MenuDAO.ObtenerDetallesdeMenu();
            dgvMenu.DataSource = menu;
        }

        private void btnLibretaMenu_Click(object sender, EventArgs e)
        {
            CambiarColorBoton((Button)sender);
            if (FormPrincipal != null)
            {
                FormPrincipal.AbrirFormsHija(new LibretaMenu { FormPrincipal = FormPrincipal });
            }
            else if (EmpleadoFormPrincipal != null)
            {
                EmpleadoFormPrincipal.AbrirFormsHijaEmpleado(new LibretaMenu { EmpleadoFormPrincipal = EmpleadoFormPrincipal });
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

        private void btnAgregarNuevoUsuario_Click(object sender, EventArgs e)
        {
            MenuRegistro fmMenuRegistro = new MenuRegistro();
            fmMenuRegistro.Show();
        }
    }
}

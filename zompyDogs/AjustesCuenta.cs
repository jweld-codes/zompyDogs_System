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
    public partial class AjustesCuenta : Form
    {
        public AjustesCuenta()
        {
            InitializeComponent();

            gbxDatosPersonales.Show();
            gbxDatosUsuarios.Hide();

            rectanglePanel1.Show();
            rectanglePanel2.Hide();
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

            rectanglePanel1.Show();
            rectanglePanel2.Hide();
        }

        private void btnDatosUsuarios_Click(object sender, EventArgs e)
        {
            gbxDatosPersonales.Hide();
            gbxDatosUsuarios.Show();

            rectanglePanel1.Hide();
            rectanglePanel2.Show();
        }

        private void btnEmpleadoPanel_Click(object sender, EventArgs e)
        {
            gbxDatosPersonales.Hide();
            gbxDatosUsuarios.Hide();

            rectanglePanel1.Hide();
            rectanglePanel2.Hide();

            btnDatosUsuarios.Hide();
            btnDatosPersonales.Hide();
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
            gbxDatosPersonales.Hide();
            gbxDatosUsuarios.Hide();

            rectanglePanel1.Hide();
            rectanglePanel2.Hide();

            btnDatosUsuarios.Hide();
            btnDatosPersonales.Hide();
        }
    }
}

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
    public partial class PeticionUsuario : Form
    {
        public BienvenidaAdmin FormPrincipal { get; set; }
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }
        public PeticionUsuario()
        {
            InitializeComponent();
        }

        private void btnAgregarRegistro_Click(object sender, EventArgs e)
        {

        }

        private void btnUsuarioPanel_Click(object sender, EventArgs e)
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



    }
}

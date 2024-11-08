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
using static ZompyDogsDAO.PeticionesValidaciones;

namespace zompyDogs.CRUD.REGISTROS
{
    public partial class PeticionRecuperacionDeContraseña : Form
    {
        Peticiones frmPeticiones;
        private ControladorGeneradoresDeCodigo _controladorGeneradorCodigo;

        private string nuevoCodigoPeticion;
        public PeticionRecuperacionDeContraseña()
        {
            InitializeComponent();
            _controladorGeneradorCodigo = new ControladorGeneradoresDeCodigo();

           // GeneradordeCodigoPeticionFromForm();
        }
           /* private void GeneradordeCodigoPeticionFromForm()
            {
                nuevoCodigoPeticion = _controladorGeneradorCodigo.GeneradordeCodigoPeticion();
                txtCodigoRealizacion.Text = nuevoCodigoPeticion;
            } */


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecuperacion_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsername.Text;
            string nuevaClave = txtNuevaClave.Text;

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(nuevaClave))
            {
                MessageBox.Show("Por favor, ingrese el nombre de usuario y la nueva clave.");
                return;
            }

            bool exito = UsuarioDAO.ActualizarClaveUsuario(nombreUsuario, nuevaClave);

            if (exito)
            {
                MessageBox.Show("Clave actualizada exitosamente.");

            }
            else
            {
                MessageBox.Show("Hubo un error al actualizar la clave.");
            }

        }





    }
}

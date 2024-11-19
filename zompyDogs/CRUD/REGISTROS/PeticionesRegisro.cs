using Microsoft.Identity.Client;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ZompyDogsDAO.PeticionesValidaciones;

namespace zompyDogs.CRUD.REGISTROS
{
    public partial class PeticionesRegisro : Form
    {
        private ControladorGeneradoresDeCodigo _controladorGeneradorCodigo;

        private string nuevoCodigoPeticion;
        public int Guardar = 0;
        public int Editar = 0;
        private int idAdmin;
        private int idObtenido;
        public bool okError = true;


        public int IdEmpleado { get; set; }
        public BienvenidaAdmin FormPrincipal { get; set; }

        Peticiones frmPeticiones;
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }
        public PeticionesRegisro(int idEmpleado)
        {
            InitializeComponent();

            IdEmpleado = idEmpleado;
            _controladorGeneradorCodigo = new ControladorGeneradoresDeCodigo();
            errorProviderDescripcion.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            GeneradordeCodigoPeticionFromForm();
        }

        private void GeneradordeCodigoPeticionFromForm()
        {
            nuevoCodigoPeticion = _controladorGeneradorCodigo.GeneradordeCodigoPeticion();
            txtCodigoGenerado.Text = nuevoCodigoPeticion;
        }

        public bool ValidarCampos()
        {
            okError = true;
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                okError = false;

                errorProviderDescripcion.SetError(txtDescripcion, "Ingrese una descripción de la petición.");
                txtDescripcion.BackColor = Color.OldLace;

            }

            if (txtDescripcion.Text.Length < 5)
            {
                okError = false;
                errorProviderDescripcion.SetError(txtDescripcion, "La descripción debe tener más de 5 caracteres.");
                txtDescripcion.BackColor = Color.OldLace;
            }

            return okError;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnGuardarUser_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            txtDescripcion.BackColor = Color.White;
            
        }
    }
}

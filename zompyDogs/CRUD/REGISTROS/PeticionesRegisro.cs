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

        public int IdEmpleado { get; set; }
        public BienvenidaAdmin FormPrincipal { get; set; }

        Peticiones frmPeticiones;
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }
        public PeticionesRegisro(int idEmpleado)
        {
            InitializeComponent();

            IdEmpleado = idEmpleado;
            _controladorGeneradorCodigo = new ControladorGeneradoresDeCodigo();
            GeneradordeCodigoPeticionFromForm();
        }

        private void GeneradordeCodigoPeticionFromForm()
        {
            nuevoCodigoPeticion = _controladorGeneradorCodigo.GeneradordeCodigoPeticion();
            txtCodigoGenerado.Text = nuevoCodigoPeticion;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

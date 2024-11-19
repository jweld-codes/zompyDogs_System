using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZompyDogsLib.Controladores;
using ZompyDogsDAO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions;


namespace zompyDogs.CRUD.AGREGAR
{
    public partial class ProveedorRegistro : Form
    {
        private ControladorGeneradoresDeCodigo _controladorGeneradorCodigo;

        private string nuevoCodigoProveedor;
        public bool okError;
        public ProveedorRegistro()
        {
            InitializeComponent();
            _controladorGeneradorCodigo = new ControladorGeneradoresDeCodigo();

            errorProviderProveedor.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            txtTelefono.MaxLength = 8;

            GeneradordeCodigoProveedorFromForm();
        }

    public bool ValidarCorreo(string correo)
    {
        string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(correo, patronCorreo);
    }

    private void GeneradordeCodigoProveedorFromForm()
        {
            nuevoCodigoProveedor = _controladorGeneradorCodigo.GeneradordeCodigoProveedor();
            txtCodigoGenerado.Text = nuevoCodigoProveedor;
        }

        public bool ValidarCampos()
        {
            okError = true;

            List<TextBox> textBoxes = new List<TextBox> { txtPrimNombre, txtSegNombre, txtNombreProv, txtTelefono };

            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    okError = false;
                    errorProviderProveedor.SetError(textBox, $"Ingrese un valor en el campo.");
                    textBox.BackColor = Color.OldLace;
                }
                else
                {
                    errorProviderProveedor.SetError(textBox, "");
                    textBox.BackColor = SystemColors.Window;
                }
            }
            string correoIngresado = txtEmail.Text;
            if (!ValidarCorreo(correoIngresado))
            {
                okError = false;
                errorProviderProveedor.SetError(txtEmail, "Ingrese un correo válido.");
                txtEmail.BackColor = Color.OldLace;
            }
            else
            {
                errorProviderProveedor.SetError(txtEmail, "");
                txtEmail.BackColor = SystemColors.Window;
            }
            return okError;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarProv_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreProv_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

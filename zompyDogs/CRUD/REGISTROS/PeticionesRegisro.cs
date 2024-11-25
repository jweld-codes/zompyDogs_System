using DocumentFormat.OpenXml.Vml;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZompyDogsDAO;
using ZompyDogsLib.Controladores;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ZompyDogsDAO.PeticionesDAO;

namespace zompyDogs.CRUD.REGISTROS
{
    /// <summary>
    /// Formulario que representa el registro de peticiones.
    /// Permite al usuario crear y validar nuevas peticiones dentro del sistema.
    /// </summary>
    public partial class PeticionesRegisro : Form
    {
        // Controlador encargado de generar códigos para las peticiones
        private ControladorGeneradoresDeCodigo _controladorGeneradorCodigo;

        // Variable para almacenar el nuevo código de la petición generado
        private string nuevoCodigoPeticion;

        // Variables de control para guardar o editar
        public int Guardar = 0;
        public int Editar = 0;

        // Identificador del administrador y de la petición
        private int idAdmin;
        private int idObtenido;

        // Bandera para verificar si no hubo errores en la validación de los campos
        public bool okError = true;

        // Propiedad para almacenar el Id del empleado
        public int IdEmpleado { get; set; }

        // Propiedad para referenciar el formulario principal de BienvenidaAdmin
        public BienvenidaAdmin FormPrincipal { get; set; }

        // Formulario de peticiones al que se regresa
        Peticiones frmPeticiones;

        // Propiedad para referenciar el formulario de EmpleadoBienvenida
        public EmpleadoBienvenida EmpleadoFormPrincipal { get; set; }


        /// <summary>
        /// Constructor que inicializa el formulario de registro de peticiones
        /// y recibe el ID del empleado para asociarlo con la petición.
        /// </summary>
        /// <param name="idEmpleado">ID del empleado asociado a la petición.</param>
        public PeticionesRegisro(int idEmpleado)
        {
            InitializeComponent();

            IdEmpleado = idEmpleado;
            _controladorGeneradorCodigo = new ControladorGeneradoresDeCodigo();
            errorProviderDescripcion.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            GeneradordeCodigoPeticionFromForm();
        }

        /// <summary>
        /// Genera un código único para la nueva petición y lo muestra en el campo de texto correspondiente.
        /// </summary>
        private void GeneradordeCodigoPeticionFromForm()
        {
            nuevoCodigoPeticion = _controladorGeneradorCodigo.GeneradordeCodigoPeticion();
            txtCodigoGenerado.Text = nuevoCodigoPeticion;
        }

        /// <summary>
        /// Valida los campos del formulario para asegurarse de que la descripción no esté vacía,
        /// no tenga espacios consecutivos, ni espacios al inicio o final, y que tenga al menos 5 caracteres.
        /// </summary>
        /// <returns>True si la validación es exitosa, false si hay algún error.</returns>
        public bool ValidarCampos()
        {
            okError = true;

            // Valida si el campo de descripción está vacío
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                okError = false;

                // Muestra el mensaje de error si está vacío
                errorProviderDescripcion.SetError(txtDescripcion, "Ingrese una descripción de la petición.");
                txtDescripcion.BackColor = Color.OldLace;

            }

            // Valida si hay espacios consecutivos en el texto
            if (Regex.IsMatch(txtDescripcion.Text, @"\s{2,}")) // Espacios consecutivos
            {
                okError = false;
                errorProviderDescripcion.SetError(txtDescripcion, "El texto no puede contener espacios consecutivos.");
                txtDescripcion.BackColor = Color.LightPink;
            }
            // Valida si el texto tiene espacios al inicio o al final
            else if (txtDescripcion.Text.StartsWith(" ") || txtDescripcion.Text.EndsWith(" ")) // Espacios al inicio o final
            {
                okError = false;
                errorProviderDescripcion.SetError(txtDescripcion, "El texto no puede comenzar ni terminar con espacios.");
                txtDescripcion.BackColor = Color.LightPink;
            }
            // Valida que la descripción tenga al menos 5 caracteres
            if (txtDescripcion.Text.Length < 5)
            {
                okError = false;
                errorProviderDescripcion.SetError(txtDescripcion, "La descripción debe tener más de 5 caracteres.");
                txtDescripcion.BackColor = Color.OldLace;
            }

            return okError;
        }

        /// <summary>
        /// Evento que se dispara cuando se hace clic en el botón Cancelar,
        /// lo que cierra el formulario sin guardar cambios.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que se dispara cada vez que el texto en el campo de descripción cambia.
        /// Restaura el color de fondo del campo a blanco cuando se modifica el texto.
        /// </summary>
        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            txtDescripcion.BackColor = Color.White;
            
        }
    }
}

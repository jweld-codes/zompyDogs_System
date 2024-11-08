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

namespace zompyDogs
{
    public partial class ClaveOlvidada : Form
    {
        private string nuevoCodigoPeticion;
        private ControladorGeneradoresDeCodigo _controladorGeneradorCodigo;
        public string userForgetCodigo;
        public ClaveOlvidada()
        {
            InitializeComponent();
            _controladorGeneradorCodigo = new ControladorGeneradoresDeCodigo();

            GeneradordeCodigoPeticionFromForm();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
         //   Login frmLogin = new Login();
           // frmLogin.Show();
            this.Close();
        }

        private void btnRegresar_MouseEnter(object sender, EventArgs e)
        {
            btnRegresar.ForeColor = Color.Black;
        }

        private void btnRegresar_MouseLeave(object sender, EventArgs e)
        {
            btnRegresar.ForeColor = Color.White;
        }

        private void GeneradordeCodigoPeticionFromForm()
        {
            nuevoCodigoPeticion = _controladorGeneradorCodigo.GeneradordeCodigoPeticion();
            userForgetCodigo = nuevoCodigoPeticion;
        }
            private void btnEnviarSolicitud_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUserForget.Text;

            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                MessageBox.Show("Por favor, ingrese su nombre de usuario o correo electrónico.");
                return;
            }

            int? idUsuario = UsuarioDAO.ObtenerIDPorNombreUsuario(nombreUsuario);

            if (idUsuario == null)
            {
                MessageBox.Show("El usuario ingresado no existe.");
                return;
            }

            // Crear la petición
            PeticionRegistro nuevaPeticion = new PeticionRegistro
            {
                CodigPeticion = userForgetCodigo,
                AccionPeticion = "Recuperación de contraseña",
                Descripcion = $"Solicitud de recuperación de contraseña para el usuario {nombreUsuario}",
                FechaEnviada = DateTime.Now,
                FechaRealizada = DateTime.Now,
                Estado = "Pendiente",
                CodigoUsuario = idUsuario.HasValue ? idUsuario.Value : 0
            };

            try
            {
                PeticionesValidaciones.GuardarPeticion(nuevaPeticion);
                /* MessageBox.Show("Message”, "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                 */
                MessageBox.Show($"Solicitud enviada correctamente.\n Un administrador revisará su petición.\n\n Código de solicitud: {userForgetCodigo}","Solicitud de Recuperación de contraseña.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login frmLogin = new Login();
                this.Hide();
                frmLogin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar la solicitud: {ex.Message}");
            }
        }
    }
}

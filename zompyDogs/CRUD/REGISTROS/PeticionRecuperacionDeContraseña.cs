using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
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
        public string GeneradordeClaveNueva()
        {
            string nombreUser = txtUsername.Text;

            string numeroAleatorio = new Random().Next(1000, 9999).ToString();
            string codigoGeneradoUsername = $"{nombreUser}-{numeroAleatorio}";

            txtNuevaClave.Text = codigoGeneradoUsername;
            return codigoGeneradoUsername;
        }
        private void btnRecuperacion_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsername.Text;
            string nuevaClave = txtNuevaClave.Text;
            string correoUser = txtNuevaClave.Text;

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(nuevaClave) || string.IsNullOrEmpty(correoUser))
            {
                MessageBox.Show("Por favor, ingrese el nombre de usuario y la nueva clave.");
                return;
            }

            bool exito = UsuarioDAO.ActualizarClaveUsuario(nombreUsuario, nuevaClave, correoUser);

            if (exito)
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("zusiurec@gmail.com");
                    mail.To.Add("zusiurec@gmail.com");

                    mail.Subject = "Recuperación de contraseña.";
                    mail.Body = $"Se ha cambiado tu contraseña exitosamente.\n Usuario: {nombreUsuario}\n Nueva Clave: {nuevaClave}";

                    smtpClient.Port = 587;
                    smtpClient.Credentials = new System.Net.NetworkCredential("zusiurec@gmail.com", "cdkaqkabbrmbmdss");
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(mail);
                }
                catch (SmtpException smtpEx)
                {
                    MessageBox.Show($"Error al enviar el correo: {smtpEx.Message}");
                    Console.WriteLine(smtpEx.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                    Console.WriteLine(ex.ToString());
                }

                MessageBox.Show("Clave actualizada exitosamente.");

            }
            else
            {
                MessageBox.Show("Hubo un error al actualizar la clave.");
            }

        }

        private void btnGeneradorPassword_Click(object sender, EventArgs e)
        {
            GeneradordeClaveNueva();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

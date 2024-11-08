using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zompyDogs.CRUD.REGISTROS
{
    public partial class MenuRegistro : Form
    {
        public MenuRegistro()
        {
            InitializeComponent();
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            string projectPath = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;

            OpenFileDialog ofdSeleccionarImagen = new OpenFileDialog();
            ofdSeleccionarImagen.Filter = "Imagenes|*.jpg; *.png";
            ofdSeleccionarImagen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionarImagen.Title = "Seleccionar Imagen";
            

            if (ofdSeleccionarImagen.ShowDialog() == DialogResult.OK)
            {
                pbxImagenSeleccionada.Image = Image.FromFile(ofdSeleccionarImagen.FileName);
                txtImagenName.Text = ofdSeleccionarImagen.SafeFileName;
                pbxImagenSeleccionada.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}

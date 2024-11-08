namespace zompyDogs.CRUD.REGISTROS
{
    partial class MenuRegistro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSeleccionarImagen = new Button();
            txtImagenName = new TextBox();
            pbxImagenSeleccionada = new PictureBox();
            ofdSeleccionarImagen = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pbxImagenSeleccionada).BeginInit();
            SuspendLayout();
            // 
            // btnSeleccionarImagen
            // 
            btnSeleccionarImagen.Location = new Point(26, 224);
            btnSeleccionarImagen.Name = "btnSeleccionarImagen";
            btnSeleccionarImagen.Size = new Size(191, 41);
            btnSeleccionarImagen.TabIndex = 0;
            btnSeleccionarImagen.Text = "Seleccionar Imagen";
            btnSeleccionarImagen.UseVisualStyleBackColor = true;
            btnSeleccionarImagen.Click += btnSeleccionarImagen_Click;
            // 
            // txtImagenName
            // 
            txtImagenName.Location = new Point(26, 191);
            txtImagenName.Name = "txtImagenName";
            txtImagenName.Size = new Size(191, 27);
            txtImagenName.TabIndex = 1;
            // 
            // pbxImagenSeleccionada
            // 
            pbxImagenSeleccionada.Location = new Point(26, 31);
            pbxImagenSeleccionada.Name = "pbxImagenSeleccionada";
            pbxImagenSeleccionada.Size = new Size(191, 155);
            pbxImagenSeleccionada.TabIndex = 2;
            pbxImagenSeleccionada.TabStop = false;
            // 
            // ofdSeleccionarImagen
            // 
            ofdSeleccionarImagen.FileName = "openFileDialog1";
            // 
            // MenuRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pbxImagenSeleccionada);
            Controls.Add(txtImagenName);
            Controls.Add(btnSeleccionarImagen);
            Name = "MenuRegistro";
            Text = "MenuRegistro";
            ((System.ComponentModel.ISupportInitialize)pbxImagenSeleccionada).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSeleccionarImagen;
        private TextBox txtImagenName;
        private PictureBox pbxImagenSeleccionada;
        private OpenFileDialog ofdSeleccionarImagen;
    }
}
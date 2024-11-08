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
            groupBox2 = new GroupBox();
            cbxCategorias = new ComboBox();
            label4 = new Label();
            txtDescripcion = new TextBox();
            label2 = new Label();
            txtNombrePlatillo = new TextBox();
            label1 = new Label();
            txtSalario = new TextBox();
            label13 = new Label();
            lblTitulo = new Label();
            pictureBox1 = new PictureBox();
            txtCodigoGenerado = new TextBox();
            btnCancelar = new Button();
            btnGuardarMenu = new Button();
            ((System.ComponentModel.ISupportInitialize)pbxImagenSeleccionada).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnSeleccionarImagen
            // 
            btnSeleccionarImagen.Location = new Point(479, 305);
            btnSeleccionarImagen.Name = "btnSeleccionarImagen";
            btnSeleccionarImagen.Size = new Size(191, 41);
            btnSeleccionarImagen.TabIndex = 0;
            btnSeleccionarImagen.Text = "Seleccionar Imagen";
            btnSeleccionarImagen.UseVisualStyleBackColor = true;
            btnSeleccionarImagen.Click += btnSeleccionarImagen_Click;
            // 
            // txtImagenName
            // 
            txtImagenName.Location = new Point(479, 272);
            txtImagenName.Name = "txtImagenName";
            txtImagenName.Size = new Size(191, 27);
            txtImagenName.TabIndex = 1;
            // 
            // pbxImagenSeleccionada
            // 
            pbxImagenSeleccionada.BorderStyle = BorderStyle.FixedSingle;
            pbxImagenSeleccionada.Image = Properties.Resources.no_photo_available;
            pbxImagenSeleccionada.Location = new Point(479, 112);
            pbxImagenSeleccionada.Name = "pbxImagenSeleccionada";
            pbxImagenSeleccionada.Size = new Size(191, 155);
            pbxImagenSeleccionada.SizeMode = PictureBoxSizeMode.Zoom;
            pbxImagenSeleccionada.TabIndex = 2;
            pbxImagenSeleccionada.TabStop = false;
            // 
            // ofdSeleccionarImagen
            // 
            ofdSeleccionarImagen.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbxCategorias);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtDescripcion);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtNombrePlatillo);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtSalario);
            groupBox2.Controls.Add(label13);
            groupBox2.Location = new Point(12, 113);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(448, 233);
            groupBox2.TabIndex = 102;
            groupBox2.TabStop = false;
            groupBox2.Text = "Registro de Puesto";
            // 
            // cbxCategorias
            // 
            cbxCategorias.FormattingEnabled = true;
            cbxCategorias.ItemHeight = 20;
            cbxCategorias.Items.AddRange(new object[] { "7:00 AM - 5:00 PM", "5:00 PM - 11:00 PM", "8:00 AM - 3:00 PM", "6:00 AM - 12:00 PM" });
            cbxCategorias.Location = new Point(216, 172);
            cbxCategorias.Name = "cbxCategorias";
            cbxCategorias.Size = new Size(180, 28);
            cbxCategorias.TabIndex = 137;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(216, 147);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 136;
            label4.Text = "Categoria";
            // 
            // txtDescripcion
            // 
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Location = new Point(18, 138);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(180, 62);
            txtDescripcion.TabIndex = 132;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 115);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 133;
            label2.Text = "Descripción";
            // 
            // txtNombrePlatillo
            // 
            txtNombrePlatillo.BorderStyle = BorderStyle.FixedSingle;
            txtNombrePlatillo.Location = new Point(18, 60);
            txtNombrePlatillo.Multiline = true;
            txtNombrePlatillo.Name = "txtNombrePlatillo";
            txtNombrePlatillo.Size = new Size(180, 37);
            txtNombrePlatillo.TabIndex = 130;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 37);
            label1.Name = "label1";
            label1.Size = new Size(139, 20);
            label1.TabIndex = 131;
            label1.Text = "Nombre del Platillo";
            // 
            // txtSalario
            // 
            txtSalario.BorderStyle = BorderStyle.FixedSingle;
            txtSalario.Location = new Point(216, 60);
            txtSalario.Multiline = true;
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(180, 37);
            txtSalario.TabIndex = 115;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(216, 37);
            label13.Name = "label13";
            label13.Size = new Size(107, 20);
            label13.TabIndex = 120;
            label13.Text = "Precio Unitario";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(140, 23);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(287, 41);
            lblTitulo.TabIndex = 127;
            lblTitulo.Text = "Registro de Platillo";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Enabled = false;
            pictureBox1.Image = Properties.Resources._588ae854_f3a0_4ffc_8412_725243b013fb_removebg_preview;
            pictureBox1.Location = new Point(13, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(104, 102);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 126;
            pictureBox1.TabStop = false;
            // 
            // txtCodigoGenerado
            // 
            txtCodigoGenerado.BorderStyle = BorderStyle.FixedSingle;
            txtCodigoGenerado.Enabled = false;
            txtCodigoGenerado.Location = new Point(140, 67);
            txtCodigoGenerado.Name = "txtCodigoGenerado";
            txtCodigoGenerado.ReadOnly = true;
            txtCodigoGenerado.Size = new Size(241, 27);
            txtCodigoGenerado.TabIndex = 125;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(255, 49, 54);
            btnCancelar.ForeColor = SystemColors.ControlLightLight;
            btnCancelar.Location = new Point(245, 360);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(148, 45);
            btnCancelar.TabIndex = 129;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardarMenu
            // 
            btnGuardarMenu.BackColor = Color.FromArgb(251, 147, 32);
            btnGuardarMenu.ForeColor = SystemColors.ControlLightLight;
            btnGuardarMenu.Location = new Point(92, 360);
            btnGuardarMenu.Name = "btnGuardarMenu";
            btnGuardarMenu.Size = new Size(148, 45);
            btnGuardarMenu.TabIndex = 128;
            btnGuardarMenu.Text = "Guardar";
            btnGuardarMenu.UseVisualStyleBackColor = false;
            btnGuardarMenu.Click += btnGuardarMenu_Click;
            // 
            // MenuRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(716, 429);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardarMenu);
            Controls.Add(lblTitulo);
            Controls.Add(pictureBox1);
            Controls.Add(txtCodigoGenerado);
            Controls.Add(groupBox2);
            Controls.Add(pbxImagenSeleccionada);
            Controls.Add(txtImagenName);
            Controls.Add(btnSeleccionarImagen);
            Name = "MenuRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)pbxImagenSeleccionada).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSeleccionarImagen;
        private OpenFileDialog ofdSeleccionarImagen;
        private GroupBox groupBox2;
        public ComboBox cbxCategorias;
        private Label label4;
        public TextBox txtDescripcion;
        private Label label2;
        public TextBox txtNombrePlatillo;
        private Label label1;
        public TextBox txtSalario;
        private Label label13;
        private Label label3;
        private PictureBox pictureBox1;
        public TextBox txtCodigoGenerado;
        public Button btnCancelar;
        public Button btnGuardarMenu;
        public TextBox txtImagenName;
        public PictureBox pbxImagenSeleccionada;
        public Label lblTitulo;
    }
}
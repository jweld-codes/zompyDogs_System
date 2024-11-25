namespace zompyDogs
{
    partial class UsuarioRegistro
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
            components = new System.ComponentModel.Container();
            lblTituloRegistro = new Label();
            txtCodigoGenerado = new TextBox();
            label3 = new Label();
            txtPrimNombre = new TextBox();
            groupBox1 = new GroupBox();
            label10 = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            cbxEsatdoCivil = new ComboBox();
            label9 = new Label();
            txtTelefono = new TextBox();
            label8 = new Label();
            txtCedula = new TextBox();
            label7 = new Label();
            txtDireccion = new TextBox();
            label6 = new Label();
            txtSegApellido = new TextBox();
            label5 = new Label();
            txtPrimApellido = new TextBox();
            label4 = new Label();
            txtSegNombre = new TextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            txtEmail = new TextBox();
            label13 = new Label();
            dtpFechaRegistro = new DateTimePicker();
            btnGeneradorPassword = new Button();
            btnGeneradorUsername = new Button();
            txtPassword = new TextBox();
            lblClave = new Label();
            txtUsername = new TextBox();
            lblUser = new Label();
            btnAddPuesto = new Button();
            cbPuesto = new ComboBox();
            label12 = new Label();
            cbxRol = new ComboBox();
            label11 = new Label();
            btnGuardarUser = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            lblidDetalleUsuario = new Label();
            errorProviderUsuario = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProviderUsuario).BeginInit();
            SuspendLayout();
            // 
            // lblTituloRegistro
            // 
            lblTituloRegistro.AutoSize = true;
            lblTituloRegistro.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloRegistro.Location = new Point(12, 24);
            lblTituloRegistro.Name = "lblTituloRegistro";
            lblTituloRegistro.Size = new Size(413, 41);
            lblTituloRegistro.TabIndex = 0;
            lblTituloRegistro.Text = "AGREGAR NUEVO USUARIO";
            // 
            // txtCodigoGenerado
            // 
            txtCodigoGenerado.BorderStyle = BorderStyle.FixedSingle;
            txtCodigoGenerado.Enabled = false;
            txtCodigoGenerado.Location = new Point(574, 33);
            txtCodigoGenerado.Name = "txtCodigoGenerado";
            txtCodigoGenerado.ReadOnly = true;
            txtCodigoGenerado.Size = new Size(352, 27);
            txtCodigoGenerado.TabIndex = 96;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 125);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 97;
            label3.Text = "Primer Nombre";
            // 
            // txtPrimNombre
            // 
            txtPrimNombre.BorderStyle = BorderStyle.FixedSingle;
            txtPrimNombre.Location = new Point(19, 148);
            txtPrimNombre.MaxLength = 20;
            txtPrimNombre.Multiline = true;
            txtPrimNombre.Name = "txtPrimNombre";
            txtPrimNombre.Size = new Size(180, 37);
            txtPrimNombre.TabIndex = 98;
            txtPrimNombre.TextChanged += txtPrimNombre_TextChanged;
            txtPrimNombre.KeyPress += txtPrimNombre_KeyPress;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(dtpFechaNacimiento);
            groupBox1.Controls.Add(cbxEsatdoCivil);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtCedula);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtDireccion);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtSegApellido);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtPrimApellido);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtSegNombre);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtPrimNombre);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 77);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(439, 457);
            groupBox1.TabIndex = 99;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Personales";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(222, 37);
            label10.Name = "label10";
            label10.Size = new Size(149, 20);
            label10.TabIndex = 114;
            label10.Text = "Fecha de Nacimiento";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(222, 60);
            dtpFechaNacimiento.MaxDate = new DateTime(2005, 1, 1, 0, 0, 0, 0);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(180, 27);
            dtpFechaNacimiento.TabIndex = 113;
            dtpFechaNacimiento.Value = new DateTime(2005, 1, 1, 0, 0, 0, 0);
            // 
            // cbxEsatdoCivil
            // 
            cbxEsatdoCivil.FormattingEnabled = true;
            cbxEsatdoCivil.ItemHeight = 20;
            cbxEsatdoCivil.Items.AddRange(new object[] { "SOLTERO", "CASADO", "DIVORCIADO", "VIUDO" });
            cbxEsatdoCivil.Location = new Point(222, 396);
            cbxEsatdoCivil.Name = "cbxEsatdoCivil";
            cbxEsatdoCivil.Size = new Size(180, 28);
            cbxEsatdoCivil.TabIndex = 112;
            cbxEsatdoCivil.Text = "SOLTERO";
            cbxEsatdoCivil.SelectedIndexChanged += cbxEsatdoCivil_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(222, 371);
            label9.Name = "label9";
            label9.Size = new Size(86, 20);
            label9.TabIndex = 111;
            label9.Text = "Estado Civil";
            // 
            // txtTelefono
            // 
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Location = new Point(222, 315);
            txtTelefono.Multiline = true;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(180, 37);
            txtTelefono.TabIndex = 110;
            txtTelefono.TextChanged += txtTelefono_TextChanged;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(222, 292);
            label8.Name = "label8";
            label8.Size = new Size(67, 20);
            label8.TabIndex = 109;
            label8.Text = "Telefono";
            // 
            // txtCedula
            // 
            txtCedula.BorderStyle = BorderStyle.FixedSingle;
            txtCedula.Location = new Point(19, 60);
            txtCedula.Multiline = true;
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(180, 37);
            txtCedula.TabIndex = 108;
            txtCedula.TextChanged += txtCedula_TextChanged;
            txtCedula.KeyPress += txtCedulae_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 37);
            label7.Name = "label7";
            label7.Size = new Size(134, 20);
            label7.TabIndex = 107;
            label7.Text = "Número de Cédula";
            // 
            // txtDireccion
            // 
            txtDireccion.BorderStyle = BorderStyle.FixedSingle;
            txtDireccion.Location = new Point(19, 315);
            txtDireccion.MaxLength = 200;
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(180, 109);
            txtDireccion.TabIndex = 106;
            txtDireccion.TextChanged += txtDireccion_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 292);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 105;
            label6.Text = "Dirección";
            // 
            // txtSegApellido
            // 
            txtSegApellido.BorderStyle = BorderStyle.FixedSingle;
            txtSegApellido.Location = new Point(222, 231);
            txtSegApellido.MaxLength = 20;
            txtSegApellido.Multiline = true;
            txtSegApellido.Name = "txtSegApellido";
            txtSegApellido.Size = new Size(180, 37);
            txtSegApellido.TabIndex = 104;
            txtSegApellido.KeyPress += txtSegApellido_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(222, 208);
            label5.Name = "label5";
            label5.Size = new Size(129, 20);
            label5.TabIndex = 103;
            label5.Text = "Segundo Apellido";
            // 
            // txtPrimApellido
            // 
            txtPrimApellido.BorderStyle = BorderStyle.FixedSingle;
            txtPrimApellido.Location = new Point(19, 231);
            txtPrimApellido.MaxLength = 20;
            txtPrimApellido.Multiline = true;
            txtPrimApellido.Name = "txtPrimApellido";
            txtPrimApellido.Size = new Size(180, 37);
            txtPrimApellido.TabIndex = 102;
            txtPrimApellido.TextChanged += txtPrimApellido_TextChanged;
            txtPrimApellido.KeyPress += txtPrimApellido_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 208);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 101;
            label4.Text = "Primer Apellido";
            // 
            // txtSegNombre
            // 
            txtSegNombre.BackColor = Color.White;
            txtSegNombre.BorderStyle = BorderStyle.FixedSingle;
            txtSegNombre.Location = new Point(222, 148);
            txtSegNombre.MaxLength = 20;
            txtSegNombre.Multiline = true;
            txtSegNombre.Name = "txtSegNombre";
            txtSegNombre.Size = new Size(180, 37);
            txtSegNombre.TabIndex = 100;
            txtSegNombre.KeyPress += txtSegNombre_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(222, 125);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 99;
            label2.Text = "Segundo Nombre";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(dtpFechaRegistro);
            groupBox2.Controls.Add(btnGeneradorPassword);
            groupBox2.Controls.Add(btnGeneradorUsername);
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Controls.Add(lblClave);
            groupBox2.Controls.Add(txtUsername);
            groupBox2.Controls.Add(lblUser);
            groupBox2.Controls.Add(btnAddPuesto);
            groupBox2.Controls.Add(cbPuesto);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(cbxRol);
            groupBox2.Controls.Add(label11);
            groupBox2.Location = new Point(478, 77);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(448, 297);
            groupBox2.TabIndex = 100;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos de Usuario";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(15, 148);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(410, 29);
            txtEmail.TabIndex = 120;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(15, 125);
            label13.Name = "label13";
            label13.Size = new Size(132, 20);
            label13.TabIndex = 119;
            label13.Text = "Correo Electrónico";
            // 
            // dtpFechaRegistro
            // 
            dtpFechaRegistro.Format = DateTimePickerFormat.Short;
            dtpFechaRegistro.Location = new Point(308, 0);
            dtpFechaRegistro.Name = "dtpFechaRegistro";
            dtpFechaRegistro.Size = new Size(125, 27);
            dtpFechaRegistro.TabIndex = 115;
            // 
            // btnGeneradorPassword
            // 
            btnGeneradorPassword.Location = new Point(213, 250);
            btnGeneradorPassword.Name = "btnGeneradorPassword";
            btnGeneradorPassword.Size = new Size(111, 29);
            btnGeneradorPassword.TabIndex = 129;
            btnGeneradorPassword.Text = "Generar Clave";
            btnGeneradorPassword.UseVisualStyleBackColor = true;
            btnGeneradorPassword.Click += btnGeneradorPassword_Click;
            // 
            // btnGeneradorUsername
            // 
            btnGeneradorUsername.Location = new Point(15, 250);
            btnGeneradorUsername.Name = "btnGeneradorUsername";
            btnGeneradorUsername.Size = new Size(124, 29);
            btnGeneradorUsername.TabIndex = 128;
            btnGeneradorUsername.Text = "Generar Usuario";
            btnGeneradorUsername.UseVisualStyleBackColor = true;
            btnGeneradorUsername.Click += btnGeneradorUsername_Click;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.CharacterCasing = CharacterCasing.Lower;
            txtPassword.Location = new Point(214, 217);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(180, 29);
            txtPassword.TabIndex = 126;
            txtPassword.TextChanged += txtPassword_TextChanged;
            txtPassword.KeyPress += txtPassword_KeyPress;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Location = new Point(217, 194);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(45, 20);
            lblClave.TabIndex = 127;
            lblClave.Text = "Clave";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.CharacterCasing = CharacterCasing.Lower;
            txtUsername.Location = new Point(16, 217);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(180, 29);
            txtUsername.TabIndex = 124;
            txtUsername.TextChanged += txtUsername_TextChanged;
            txtUsername.KeyPress += txtUsername_KeyPress;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(19, 194);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(59, 20);
            lblUser.TabIndex = 125;
            lblUser.Text = "Usuario";
            // 
            // btnAddPuesto
            // 
            btnAddPuesto.Image = Properties.Resources.add_button;
            btnAddPuesto.Location = new Point(395, 69);
            btnAddPuesto.Name = "btnAddPuesto";
            btnAddPuesto.Size = new Size(30, 28);
            btnAddPuesto.TabIndex = 119;
            btnAddPuesto.UseVisualStyleBackColor = true;
            btnAddPuesto.Click += btnAddPuesto_Click;
            // 
            // cbPuesto
            // 
            cbPuesto.FormattingEnabled = true;
            cbPuesto.ItemHeight = 20;
            cbPuesto.Items.AddRange(new object[] { "1", "2", "3" });
            cbPuesto.Location = new Point(213, 69);
            cbPuesto.Name = "cbPuesto";
            cbPuesto.Size = new Size(180, 28);
            cbPuesto.TabIndex = 118;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(213, 44);
            label12.Name = "label12";
            label12.Size = new Size(53, 20);
            label12.TabIndex = 117;
            label12.Text = "Puesto";
            // 
            // cbxRol
            // 
            cbxRol.FormattingEnabled = true;
            cbxRol.ItemHeight = 20;
            cbxRol.Items.AddRange(new object[] { "Administrador", "Empleado" });
            cbxRol.Location = new Point(15, 69);
            cbxRol.Name = "cbxRol";
            cbxRol.Size = new Size(180, 28);
            cbxRol.TabIndex = 116;
            cbxRol.SelectedIndexChanged += cbxRol_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(15, 44);
            label11.Name = "label11";
            label11.Size = new Size(31, 20);
            label11.TabIndex = 115;
            label11.Text = "Rol";
            // 
            // btnGuardarUser
            // 
            btnGuardarUser.BackColor = Color.FromArgb(251, 147, 32);
            btnGuardarUser.ForeColor = SystemColors.ControlLightLight;
            btnGuardarUser.Location = new Point(526, 387);
            btnGuardarUser.Name = "btnGuardarUser";
            btnGuardarUser.Size = new Size(150, 42);
            btnGuardarUser.TabIndex = 101;
            btnGuardarUser.Text = "GUARDAR";
            btnGuardarUser.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(255, 49, 54);
            btnCancelar.ForeColor = SystemColors.ControlLightLight;
            btnCancelar.Location = new Point(692, 387);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 42);
            btnCancelar.TabIndex = 102;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(574, 10);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 115;
            label1.Text = "ID DetalleUsuario:";
            // 
            // lblidDetalleUsuario
            // 
            lblidDetalleUsuario.AutoSize = true;
            lblidDetalleUsuario.Location = new Point(697, 11);
            lblidDetalleUsuario.Name = "lblidDetalleUsuario";
            lblidDetalleUsuario.Size = new Size(17, 20);
            lblidDetalleUsuario.TabIndex = 116;
            lblidDetalleUsuario.Text = "0";
            // 
            // errorProviderUsuario
            // 
            errorProviderUsuario.ContainerControl = this;
            // 
            // UsuarioRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(955, 545);
            Controls.Add(lblidDetalleUsuario);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardarUser);
            Controls.Add(groupBox2);
            Controls.Add(txtCodigoGenerado);
            Controls.Add(groupBox1);
            Controls.Add(lblTituloRegistro);
            Name = "UsuarioRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProviderUsuario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblTituloRegistro;
        public TextBox txtCodigoGenerado;
        private Label label3;
        public TextBox txtPrimNombre;
        private GroupBox groupBox1;
        public TextBox txtCedula;
        private Label label7;
        public TextBox txtDireccion;
        private Label label6;
        public TextBox txtSegApellido;
        private Label label5;
        public TextBox txtPrimApellido;
        private Label label4;
        public TextBox txtSegNombre;
        private Label label2;
        private Label label10;
        public DateTimePicker dtpFechaNacimiento;
        private Label label9;
        public TextBox txtTelefono;
        private Label label8;
        private GroupBox groupBox2;
        public ComboBox cbxRol;
        private Label label11;
        private Button btnAddPuesto;
        private Label label12;
        public TextBox txtPassword;
        private Label lblClave;
        public TextBox txtUsername;
        private Label lblUser;
        public Button btnGeneradorPassword;
        public Button btnGeneradorUsername;
        public Button btnGuardarUser;
        public Button btnCancelar;
        public ComboBox cbxEsatdoCivil;
        public ComboBox cbPuesto;
        private Label label1;
        public Label lblidDetalleUsuario;
        public DateTimePicker dtpFechaRegistro;
        private ErrorProvider errorProviderUsuario;
        public TextBox txtEmail;
        private Label label13;
    }
}
namespace zompyDogs.CRUD.REGISTROS
{
    partial class PeticionActualizarDatosPersonales
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
            btnCancelar = new Button();
            btnGuardarUser = new Button();
            groupBox1 = new GroupBox();
            cbxPeticion = new ComboBox();
            label10 = new Label();
            txtCodigoGenerado = new TextBox();
            dtpFechaEnviada = new DateTimePicker();
            cbxEstadoCuenta = new ComboBox();
            label9 = new Label();
            label7 = new Label();
            txtDescripcion = new TextBox();
            label4 = new Label();
            txtUsername = new TextBox();
            label3 = new Label();
            lblTituloRegistro = new Label();
            groupBox2 = new GroupBox();
            label1 = new Label();
            textBox2 = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            cbxEsatdoCivil = new ComboBox();
            label2 = new Label();
            txtTelefono = new TextBox();
            label8 = new Label();
            txtCedula = new TextBox();
            label5 = new Label();
            txtDireccion = new TextBox();
            label6 = new Label();
            txtSegApellido = new TextBox();
            label11 = new Label();
            txtPrimApellido = new TextBox();
            label12 = new Label();
            txtSegNombre = new TextBox();
            label13 = new Label();
            txtPrimNombre = new TextBox();
            label14 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(255, 49, 54);
            btnCancelar.ForeColor = SystemColors.ControlLightLight;
            btnCancelar.Location = new Point(246, 439);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(177, 64);
            btnCancelar.TabIndex = 114;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardarUser
            // 
            btnGuardarUser.BackColor = Color.FromArgb(251, 147, 32);
            btnGuardarUser.ForeColor = SystemColors.ControlLightLight;
            btnGuardarUser.Location = new Point(49, 439);
            btnGuardarUser.Name = "btnGuardarUser";
            btnGuardarUser.Size = new Size(177, 64);
            btnGuardarUser.TabIndex = 113;
            btnGuardarUser.Text = "GUARDAR";
            btnGuardarUser.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbxPeticion);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtCodigoGenerado);
            groupBox1.Controls.Add(dtpFechaEnviada);
            groupBox1.Controls.Add(cbxEstadoCuenta);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(26, 99);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(439, 313);
            groupBox1.TabIndex = 112;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de Petición";
            // 
            // cbxPeticion
            // 
            cbxPeticion.FormattingEnabled = true;
            cbxPeticion.ItemHeight = 20;
            cbxPeticion.Items.AddRange(new object[] { "Actualizar", "Eliminar" });
            cbxPeticion.Location = new Point(19, 69);
            cbxPeticion.Name = "cbxPeticion";
            cbxPeticion.Size = new Size(180, 28);
            cbxPeticion.TabIndex = 115;
            cbxPeticion.Text = "ACTUALIZAR";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(222, 46);
            label10.Name = "label10";
            label10.Size = new Size(124, 20);
            label10.TabIndex = 114;
            label10.Text = "Fecha de Peticion";
            // 
            // txtCodigoGenerado
            // 
            txtCodigoGenerado.BorderStyle = BorderStyle.FixedSingle;
            txtCodigoGenerado.Enabled = false;
            txtCodigoGenerado.Location = new Point(184, 0);
            txtCodigoGenerado.Name = "txtCodigoGenerado";
            txtCodigoGenerado.ReadOnly = true;
            txtCodigoGenerado.Size = new Size(239, 27);
            txtCodigoGenerado.TabIndex = 105;
            // 
            // dtpFechaEnviada
            // 
            dtpFechaEnviada.Enabled = false;
            dtpFechaEnviada.Format = DateTimePickerFormat.Short;
            dtpFechaEnviada.Location = new Point(222, 69);
            dtpFechaEnviada.Name = "dtpFechaEnviada";
            dtpFechaEnviada.Size = new Size(180, 27);
            dtpFechaEnviada.TabIndex = 113;
            // 
            // cbxEstadoCuenta
            // 
            cbxEstadoCuenta.Enabled = false;
            cbxEstadoCuenta.FormattingEnabled = true;
            cbxEstadoCuenta.ItemHeight = 20;
            cbxEstadoCuenta.Items.AddRange(new object[] { "ACTIVO", "INACTIVO" });
            cbxEstadoCuenta.Location = new Point(222, 259);
            cbxEstadoCuenta.Name = "cbxEstadoCuenta";
            cbxEstadoCuenta.Size = new Size(180, 28);
            cbxEstadoCuenta.TabIndex = 112;
            cbxEstadoCuenta.Text = "ACTIVO";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(222, 234);
            label9.Name = "label9";
            label9.Size = new Size(54, 20);
            label9.TabIndex = 111;
            label9.Text = "Estado";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 46);
            label7.Name = "label7";
            label7.Size = new Size(61, 20);
            label7.TabIndex = 107;
            label7.Text = "Petición";
            // 
            // txtDescripcion
            // 
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Location = new Point(19, 128);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(383, 86);
            txtDescripcion.TabIndex = 102;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 105);
            label4.Name = "label4";
            label4.Size = new Size(164, 20);
            label4.TabIndex = 101;
            label4.Text = "Descripción de Petición";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(19, 250);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(180, 37);
            txtUsername.TabIndex = 98;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 227);
            label3.Name = "label3";
            label3.Size = new Size(143, 20);
            label3.TabIndex = 97;
            label3.Text = "Nombre del Usuario";
            // 
            // lblTituloRegistro
            // 
            lblTituloRegistro.AutoSize = true;
            lblTituloRegistro.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloRegistro.Location = new Point(12, 9);
            lblTituloRegistro.Name = "lblTituloRegistro";
            lblTituloRegistro.Size = new Size(42, 41);
            lblTituloRegistro.TabIndex = 111;
            lblTituloRegistro.Text = "...";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(dtpFechaNacimiento);
            groupBox2.Controls.Add(cbxEsatdoCivil);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtTelefono);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtCedula);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtDireccion);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtSegApellido);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(txtPrimApellido);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(txtSegNombre);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(txtPrimNombre);
            groupBox2.Controls.Add(label14);
            groupBox2.Location = new Point(480, 62);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(439, 457);
            groupBox2.TabIndex = 115;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos Personales";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(222, 37);
            label1.Name = "label1";
            label1.Size = new Size(149, 20);
            label1.TabIndex = 114;
            label1.Text = "Fecha de Nacimiento";
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Enabled = false;
            textBox2.Location = new Point(155, 0);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(263, 27);
            textBox2.TabIndex = 116;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(222, 60);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(180, 27);
            dtpFechaNacimiento.TabIndex = 113;
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
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(222, 371);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 111;
            label2.Text = "Estado Civil";
            // 
            // txtTelefono
            // 
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Location = new Point(222, 315);
            txtTelefono.Multiline = true;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(180, 37);
            txtTelefono.TabIndex = 110;
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
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 37);
            label5.Name = "label5";
            label5.Size = new Size(134, 20);
            label5.TabIndex = 107;
            label5.Text = "Número de Cédula";
            // 
            // txtDireccion
            // 
            txtDireccion.BorderStyle = BorderStyle.FixedSingle;
            txtDireccion.Location = new Point(19, 315);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(180, 109);
            txtDireccion.TabIndex = 106;
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
            txtSegApellido.Multiline = true;
            txtSegApellido.Name = "txtSegApellido";
            txtSegApellido.Size = new Size(180, 37);
            txtSegApellido.TabIndex = 104;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(222, 208);
            label11.Name = "label11";
            label11.Size = new Size(129, 20);
            label11.TabIndex = 103;
            label11.Text = "Segundo Apellido";
            // 
            // txtPrimApellido
            // 
            txtPrimApellido.BorderStyle = BorderStyle.FixedSingle;
            txtPrimApellido.Location = new Point(19, 231);
            txtPrimApellido.Multiline = true;
            txtPrimApellido.Name = "txtPrimApellido";
            txtPrimApellido.Size = new Size(180, 37);
            txtPrimApellido.TabIndex = 102;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(19, 208);
            label12.Name = "label12";
            label12.Size = new Size(113, 20);
            label12.TabIndex = 101;
            label12.Text = "Primer Apellido";
            // 
            // txtSegNombre
            // 
            txtSegNombre.BorderStyle = BorderStyle.FixedSingle;
            txtSegNombre.Location = new Point(222, 148);
            txtSegNombre.Multiline = true;
            txtSegNombre.Name = "txtSegNombre";
            txtSegNombre.Size = new Size(180, 37);
            txtSegNombre.TabIndex = 100;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(222, 125);
            label13.Name = "label13";
            label13.Size = new Size(127, 20);
            label13.TabIndex = 99;
            label13.Text = "Segundo Nombre";
            // 
            // txtPrimNombre
            // 
            txtPrimNombre.BorderStyle = BorderStyle.FixedSingle;
            txtPrimNombre.Location = new Point(19, 148);
            txtPrimNombre.Multiline = true;
            txtPrimNombre.Name = "txtPrimNombre";
            txtPrimNombre.Size = new Size(180, 37);
            txtPrimNombre.TabIndex = 98;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(19, 125);
            label14.Name = "label14";
            label14.Size = new Size(111, 20);
            label14.TabIndex = 97;
            label14.Text = "Primer Nombre";
            // 
            // PeticionActualizarDatosPersonales
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 585);
            Controls.Add(groupBox2);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardarUser);
            Controls.Add(groupBox1);
            Controls.Add(lblTituloRegistro);
            Name = "PeticionActualizarDatosPersonales";
            Text = "PeticionActualizar";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button btnCancelar;
        public Button btnGuardarUser;
        private GroupBox groupBox1;
        private ComboBox cbxPeticion;
        private Label label10;
        private TextBox txtCodigoGenerado;
        public DateTimePicker dtpFechaEnviada;
        private ComboBox cbxEstadoCuenta;
        private Label label9;
        private Label label7;
        public TextBox txtDescripcion;
        private Label label4;
        public TextBox txtUsername;
        private Label label3;
        public Label lblTituloRegistro;
        private GroupBox groupBox2;
        private Label label1;
        public DateTimePicker dtpFechaNacimiento;
        private ComboBox cbxEsatdoCivil;
        private Label label2;
        public TextBox txtTelefono;
        private Label label8;
        public TextBox txtCedula;
        private Label label5;
        public TextBox txtDireccion;
        private Label label6;
        public TextBox txtSegApellido;
        private Label label11;
        public TextBox txtPrimApellido;
        private Label label12;
        public TextBox txtSegNombre;
        private Label label13;
        public TextBox txtPrimNombre;
        private Label label14;
        private TextBox textBox2;
    }
}
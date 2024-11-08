namespace zompyDogs.CRUD.REGISTROS
{
    partial class PeticionRecuperacionDeContraseña
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
            groupBox1 = new GroupBox();
            txtEstado = new TextBox();
            txtAccionPeticion = new TextBox();
            label10 = new Label();
            txtCodigoGenerado = new TextBox();
            dtpFechaEnviada = new DateTimePicker();
            label9 = new Label();
            label7 = new Label();
            txtDescripcion = new TextBox();
            label4 = new Label();
            txtUsername = new TextBox();
            label3 = new Label();
            lblTituloRegistro = new Label();
            btnCancelar = new Button();
            btnRecuperacion = new Button();
            groupBox2 = new GroupBox();
            btnGeneradorPassword = new Button();
            txtCodigoRealizacion = new TextBox();
            cbPeticionRealizado = new ComboBox();
            label1 = new Label();
            dtpFechaRealizacion = new DateTimePicker();
            cbEstadoRealizado = new ComboBox();
            label2 = new Label();
            label5 = new Label();
            txtNuevaClave = new TextBox();
            label8 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtEstado);
            groupBox1.Controls.Add(txtAccionPeticion);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtCodigoGenerado);
            groupBox1.Controls.Add(dtpFechaEnviada);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 58);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(439, 313);
            groupBox1.TabIndex = 112;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de Petición";
            // 
            // txtEstado
            // 
            txtEstado.BorderStyle = BorderStyle.FixedSingle;
            txtEstado.Location = new Point(222, 250);
            txtEstado.Multiline = true;
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(180, 27);
            txtEstado.TabIndex = 116;
            // 
            // txtAccionPeticion
            // 
            txtAccionPeticion.BorderStyle = BorderStyle.FixedSingle;
            txtAccionPeticion.Location = new Point(19, 69);
            txtAccionPeticion.Multiline = true;
            txtAccionPeticion.Name = "txtAccionPeticion";
            txtAccionPeticion.Size = new Size(236, 27);
            txtAccionPeticion.TabIndex = 115;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(261, 46);
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
            dtpFechaEnviada.Location = new Point(261, 69);
            dtpFechaEnviada.Name = "dtpFechaEnviada";
            dtpFechaEnviada.Size = new Size(141, 27);
            dtpFechaEnviada.TabIndex = 113;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(225, 230);
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
            lblTituloRegistro.Location = new Point(12, 5);
            lblTituloRegistro.Name = "lblTituloRegistro";
            lblTituloRegistro.Size = new Size(42, 41);
            lblTituloRegistro.TabIndex = 111;
            lblTituloRegistro.Text = "...";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(255, 49, 54);
            btnCancelar.ForeColor = SystemColors.ControlLightLight;
            btnCancelar.Location = new Point(712, 298);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(177, 64);
            btnCancelar.TabIndex = 118;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnRecuperacion
            // 
            btnRecuperacion.BackColor = Color.FromArgb(251, 147, 32);
            btnRecuperacion.ForeColor = SystemColors.ControlLightLight;
            btnRecuperacion.Location = new Point(515, 298);
            btnRecuperacion.Name = "btnRecuperacion";
            btnRecuperacion.Size = new Size(177, 64);
            btnRecuperacion.TabIndex = 117;
            btnRecuperacion.Text = "GUARDAR";
            btnRecuperacion.UseVisualStyleBackColor = false;
            btnRecuperacion.Click += btnRecuperacion_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnGeneradorPassword);
            groupBox2.Controls.Add(txtCodigoRealizacion);
            groupBox2.Controls.Add(cbPeticionRealizado);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(dtpFechaRealizacion);
            groupBox2.Controls.Add(cbEstadoRealizado);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtNuevaClave);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(478, 58);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(439, 224);
            groupBox2.TabIndex = 116;
            groupBox2.TabStop = false;
            // 
            // btnGeneradorPassword
            // 
            btnGeneradorPassword.Location = new Point(16, 173);
            btnGeneradorPassword.Name = "btnGeneradorPassword";
            btnGeneradorPassword.Size = new Size(111, 29);
            btnGeneradorPassword.TabIndex = 130;
            btnGeneradorPassword.Text = "Generar Clave";
            btnGeneradorPassword.UseVisualStyleBackColor = true;
            btnGeneradorPassword.Click += btnGeneradorPassword_Click;
            // 
            // txtCodigoRealizacion
            // 
            txtCodigoRealizacion.BorderStyle = BorderStyle.FixedSingle;
            txtCodigoRealizacion.Enabled = false;
            txtCodigoRealizacion.Location = new Point(184, 0);
            txtCodigoRealizacion.Name = "txtCodigoRealizacion";
            txtCodigoRealizacion.ReadOnly = true;
            txtCodigoRealizacion.Size = new Size(239, 27);
            txtCodigoRealizacion.TabIndex = 116;
            // 
            // cbPeticionRealizado
            // 
            cbPeticionRealizado.Enabled = false;
            cbPeticionRealizado.FormattingEnabled = true;
            cbPeticionRealizado.ItemHeight = 20;
            cbPeticionRealizado.Items.AddRange(new object[] { "Actualizar", "Eliminar" });
            cbPeticionRealizado.Location = new Point(19, 69);
            cbPeticionRealizado.Name = "cbPeticionRealizado";
            cbPeticionRealizado.Size = new Size(180, 28);
            cbPeticionRealizado.TabIndex = 115;
            cbPeticionRealizado.Text = "ACTUALIZAR";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(222, 46);
            label1.Name = "label1";
            label1.Size = new Size(148, 20);
            label1.TabIndex = 114;
            label1.Text = "Fecha de Realizacion";
            // 
            // dtpFechaRealizacion
            // 
            dtpFechaRealizacion.Enabled = false;
            dtpFechaRealizacion.Format = DateTimePickerFormat.Short;
            dtpFechaRealizacion.Location = new Point(222, 69);
            dtpFechaRealizacion.Name = "dtpFechaRealizacion";
            dtpFechaRealizacion.Size = new Size(180, 27);
            dtpFechaRealizacion.TabIndex = 113;
            // 
            // cbEstadoRealizado
            // 
            cbEstadoRealizado.Enabled = false;
            cbEstadoRealizado.FormattingEnabled = true;
            cbEstadoRealizado.ItemHeight = 20;
            cbEstadoRealizado.Items.AddRange(new object[] { "Completado", "Incompleto", "En Espera" });
            cbEstadoRealizado.Location = new Point(222, 139);
            cbEstadoRealizado.Name = "cbEstadoRealizado";
            cbEstadoRealizado.Size = new Size(180, 28);
            cbEstadoRealizado.TabIndex = 112;
            cbEstadoRealizado.Text = "Completado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(222, 114);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 111;
            label2.Text = "Estado";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 46);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 107;
            label5.Text = "Petición";
            // 
            // txtNuevaClave
            // 
            txtNuevaClave.BorderStyle = BorderStyle.FixedSingle;
            txtNuevaClave.Location = new Point(19, 139);
            txtNuevaClave.Multiline = true;
            txtNuevaClave.Name = "txtNuevaClave";
            txtNuevaClave.PasswordChar = '*';
            txtNuevaClave.Size = new Size(183, 28);
            txtNuevaClave.TabIndex = 98;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 116);
            label8.Name = "label8";
            label8.Size = new Size(129, 20);
            label8.TabIndex = 97;
            label8.Text = "Nueva Contraseña";
            // 
            // PeticionRecuperacionDeContraseña
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(943, 398);
            Controls.Add(btnCancelar);
            Controls.Add(btnRecuperacion);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblTituloRegistro);
            Name = "PeticionRecuperacionDeContraseña";
            StartPosition = FormStartPosition.CenterScreen;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private Label label10;
        public TextBox txtCodigoGenerado;
        public DateTimePicker dtpFechaEnviada;
        private Label label9;
        private Label label7;
        public TextBox txtDescripcion;
        private Label label4;
        public TextBox txtUsername;
        private Label label3;
        public Label lblTituloRegistro;
        public Button btnCancelar;
        public Button btnRecuperacion;
        private GroupBox groupBox2;
        public ComboBox cbPeticionRealizado;
        private Label label1;
        public DateTimePicker dtpFechaRealizacion;
        public ComboBox cbEstadoRealizado;
        private Label label2;
        private Label label5;
        public TextBox txtNuevaClave;
        private Label label8;
        public TextBox txtCodigoRealizacion;
        public TextBox txtAccionPeticion;
        public TextBox txtEstado;
        public Button btnGeneradorPassword;
    }
}
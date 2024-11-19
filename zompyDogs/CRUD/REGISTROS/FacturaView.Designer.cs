namespace zompyDogs.CRUD.REGISTROS
{
    partial class FacturaView
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnCancelar = new Button();
            txtCodigoGenerado = new TextBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            label3 = new Label();
            label5 = new Label();
            txtEstado = new TextBox();
            lblTotal = new Label();
            label13 = new Label();
            lblISV = new Label();
            label11 = new Label();
            label9 = new Label();
            lblSubtotal = new Label();
            label4 = new Label();
            lblCodigoEmpleado = new Label();
            dgvTotalPedido = new DataGridView();
            dtpFechaRegistro = new DateTimePicker();
            txtEmpleado = new TextBox();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTotalPedido).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(255, 49, 54);
            btnCancelar.ForeColor = SystemColors.ControlLightLight;
            btnCancelar.Location = new Point(425, 521);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 42);
            btnCancelar.TabIndex = 122;
            btnCancelar.Text = "SALIR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtCodigoGenerado
            // 
            txtCodigoGenerado.BorderStyle = BorderStyle.FixedSingle;
            txtCodigoGenerado.Enabled = false;
            txtCodigoGenerado.Location = new Point(160, 87);
            txtCodigoGenerado.Name = "txtCodigoGenerado";
            txtCodigoGenerado.ReadOnly = true;
            txtCodigoGenerado.Size = new Size(241, 27);
            txtCodigoGenerado.TabIndex = 118;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtEstado);
            groupBox1.Controls.Add(lblTotal);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(lblISV);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(lblSubtotal);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lblCodigoEmpleado);
            groupBox1.Controls.Add(dgvTotalPedido);
            groupBox1.Controls.Add(dtpFechaRegistro);
            groupBox1.Controls.Add(txtEmpleado);
            groupBox1.Controls.Add(label7);
            groupBox1.Location = new Point(15, 145);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(560, 370);
            groupBox1.TabIndex = 119;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pedido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(453, 282);
            label1.Name = "label1";
            label1.Size = new Size(27, 28);
            label1.TabIndex = 126;
            label1.Text = "L.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(453, 249);
            label3.Name = "label3";
            label3.Size = new Size(27, 28);
            label3.TabIndex = 125;
            label3.Text = "L.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(453, 217);
            label5.Name = "label5";
            label5.Size = new Size(27, 28);
            label5.TabIndex = 124;
            label5.Text = "L.";
            // 
            // txtEstado
            // 
            txtEstado.BorderStyle = BorderStyle.FixedSingle;
            txtEstado.Location = new Point(332, 151);
            txtEstado.Multiline = true;
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(201, 29);
            txtEstado.TabIndex = 123;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(474, 282);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(65, 28);
            lblTotal.TabIndex = 122;
            lblTotal.Text = "00.00";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(344, 289);
            label13.Name = "label13";
            label13.Size = new Size(103, 20);
            label13.TabIndex = 121;
            label13.Text = "Total de Pago:";
            // 
            // lblISV
            // 
            lblISV.AutoSize = true;
            lblISV.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblISV.Location = new Point(474, 249);
            lblISV.Name = "lblISV";
            lblISV.Size = new Size(65, 28);
            lblISV.TabIndex = 120;
            lblISV.Text = "00.00";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(385, 224);
            label11.Name = "label11";
            label11.Size = new Size(68, 20);
            label11.TabIndex = 119;
            label11.Text = "Subtotal:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(314, 128);
            label9.Name = "label9";
            label9.Size = new Size(54, 20);
            label9.TabIndex = 111;
            label9.Text = "Estado";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtotal.Location = new Point(474, 217);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(65, 28);
            lblSubtotal.TabIndex = 118;
            lblSubtotal.Text = "00.00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(375, 256);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 117;
            label4.Text = "ISV (15%):";
            // 
            // lblCodigoEmpleado
            // 
            lblCodigoEmpleado.AutoSize = true;
            lblCodigoEmpleado.Location = new Point(397, 59);
            lblCodigoEmpleado.Name = "lblCodigoEmpleado";
            lblCodigoEmpleado.Size = new Size(25, 20);
            lblCodigoEmpleado.TabIndex = 116;
            lblCodigoEmpleado.Text = "00";
            // 
            // dgvTotalPedido
            // 
            dgvTotalPedido.AllowUserToAddRows = false;
            dgvTotalPedido.AllowUserToOrderColumns = true;
            dgvTotalPedido.AllowUserToResizeColumns = false;
            dgvTotalPedido.AllowUserToResizeRows = false;
            dgvTotalPedido.BackgroundColor = SystemColors.Control;
            dgvTotalPedido.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            dgvTotalPedido.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTotalPedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTotalPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTotalPedido.GridColor = SystemColors.ScrollBar;
            dgvTotalPedido.Location = new Point(6, 26);
            dgvTotalPedido.Name = "dgvTotalPedido";
            dgvTotalPedido.RowHeadersVisible = false;
            dgvTotalPedido.RowHeadersWidth = 51;
            dgvTotalPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTotalPedido.Size = new Size(295, 284);
            dgvTotalPedido.TabIndex = 114;
            // 
            // dtpFechaRegistro
            // 
            dtpFechaRegistro.Format = DateTimePickerFormat.Short;
            dtpFechaRegistro.Location = new Point(359, 0);
            dtpFechaRegistro.Name = "dtpFechaRegistro";
            dtpFechaRegistro.Size = new Size(180, 27);
            dtpFechaRegistro.TabIndex = 113;
            // 
            // txtEmpleado
            // 
            txtEmpleado.BorderStyle = BorderStyle.FixedSingle;
            txtEmpleado.Location = new Point(332, 82);
            txtEmpleado.Multiline = true;
            txtEmpleado.Name = "txtEmpleado";
            txtEmpleado.Size = new Size(201, 29);
            txtEmpleado.TabIndex = 108;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(314, 59);
            label7.Name = "label7";
            label7.Size = new Size(77, 20);
            label7.TabIndex = 107;
            label7.Text = "Empleado";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Enabled = false;
            pictureBox1.Image = Properties.Resources._588ae854_f3a0_4ffc_8412_725243b013fb_removebg_preview;
            pictureBox1.Location = new Point(23, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(104, 102);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 123;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(160, 43);
            label2.Name = "label2";
            label2.Size = new Size(246, 41);
            label2.TabIndex = 124;
            label2.Text = "Vista del Pedido";
            // 
            // FacturaView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(617, 573);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(btnCancelar);
            Controls.Add(txtCodigoGenerado);
            Controls.Add(groupBox1);
            Name = "FacturaView";
            StartPosition = FormStartPosition.CenterScreen;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTotalPedido).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button btnCancelar;
        public TextBox txtCodigoGenerado;
        private GroupBox groupBox1;
        public DateTimePicker dtpFechaRegistro;
        private Label label9;
        public TextBox txtEmpleado;
        private Label label7;
        private PictureBox pictureBox1;
        public DataGridView dgvTotalPedido;
        private Label label13;
        private Label label11;
        private Label label4;
        public TextBox txtEstado;
        private Label label2;
        public Label lblCodigoEmpleado;
        public Label lblTotal;
        public Label lblISV;
        public Label lblSubtotal;
        public Label label1;
        public Label label3;
        public Label label5;
    }
}
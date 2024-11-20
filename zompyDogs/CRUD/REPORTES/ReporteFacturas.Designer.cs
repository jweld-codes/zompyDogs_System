namespace zompyDogs.CRUD.REPORTES
{
    partial class ReporteFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteFacturas));
            dgvHistorialPedidos = new DataGridView();
            label1 = new Label();
            panel1 = new Panel();
            btnImprimir = new Button();
            dgvPedidoSelect = new DataGridView();
            dtpFechaRegistro = new DateTimePicker();
            label6 = new Label();
            label8 = new Label();
            label10 = new Label();
            txtEstado = new TextBox();
            lblTotalPago = new Label();
            label14 = new Label();
            lblISV = new Label();
            label16 = new Label();
            label17 = new Label();
            lblSubtotal = new Label();
            label19 = new Label();
            lblCodigoEmpleado = new Label();
            txtEmpleado = new TextBox();
            label21 = new Label();
            txtCodigoGenerado = new TextBox();
            groupBox2 = new GroupBox();
            label2 = new Label();
            btnRefreshDG = new Button();
            btnFechaPedido = new Button();
            dtpFechaPedido = new DateTimePicker();
            reportFactura = new FastReport.Report();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialPedidos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedidoSelect).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)reportFactura).BeginInit();
            SuspendLayout();
            // 
            // dgvHistorialPedidos
            // 
            dgvHistorialPedidos.BackgroundColor = Color.WhiteSmoke;
            dgvHistorialPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorialPedidos.Location = new Point(12, 129);
            dgvHistorialPedidos.Name = "dgvHistorialPedidos";
            dgvHistorialPedidos.RowHeadersWidth = 51;
            dgvHistorialPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialPedidos.Size = new Size(776, 188);
            dgvHistorialPedidos.TabIndex = 3;
            dgvHistorialPedidos.CellClick += dgvHistorialPedidos_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(298, 41);
            label1.TabIndex = 4;
            label1.Text = "Reporte de Facturas";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 637);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 29);
            panel1.TabIndex = 5;
            // 
            // btnImprimir
            // 
            btnImprimir.Image = Properties.Resources.printer;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(254, 218);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(161, 29);
            btnImprimir.TabIndex = 8;
            btnImprimir.Text = "Imprimir Factura";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // dgvPedidoSelect
            // 
            dgvPedidoSelect.BackgroundColor = Color.WhiteSmoke;
            dgvPedidoSelect.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidoSelect.Location = new Point(16, 59);
            dgvPedidoSelect.Name = "dgvPedidoSelect";
            dgvPedidoSelect.RowHeadersWidth = 51;
            dgvPedidoSelect.Size = new Size(215, 188);
            dgvPedidoSelect.TabIndex = 6;
            // 
            // dtpFechaRegistro
            // 
            dtpFechaRegistro.Enabled = false;
            dtpFechaRegistro.Format = DateTimePickerFormat.Short;
            dtpFechaRegistro.Location = new Point(535, 58);
            dtpFechaRegistro.Name = "dtpFechaRegistro";
            dtpFechaRegistro.Size = new Size(201, 27);
            dtpFechaRegistro.TabIndex = 113;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(603, 185);
            label6.Name = "label6";
            label6.Size = new Size(27, 28);
            label6.TabIndex = 140;
            label6.Text = "L.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(603, 152);
            label8.Name = "label8";
            label8.Size = new Size(27, 28);
            label8.TabIndex = 139;
            label8.Text = "L.";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(603, 120);
            label10.Name = "label10";
            label10.Size = new Size(27, 28);
            label10.TabIndex = 138;
            label10.Text = "L.";
            // 
            // txtEstado
            // 
            txtEstado.BorderStyle = BorderStyle.FixedSingle;
            txtEstado.Enabled = false;
            txtEstado.Location = new Point(254, 139);
            txtEstado.Multiline = true;
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(201, 29);
            txtEstado.TabIndex = 137;
            // 
            // lblTotalPago
            // 
            lblTotalPago.AutoSize = true;
            lblTotalPago.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPago.Location = new Point(624, 185);
            lblTotalPago.Name = "lblTotalPago";
            lblTotalPago.Size = new Size(65, 28);
            lblTotalPago.TabIndex = 136;
            lblTotalPago.Text = "00.00";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(494, 192);
            label14.Name = "label14";
            label14.Size = new Size(103, 20);
            label14.TabIndex = 135;
            label14.Text = "Total de Pago:";
            // 
            // lblISV
            // 
            lblISV.AutoSize = true;
            lblISV.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblISV.Location = new Point(624, 152);
            lblISV.Name = "lblISV";
            lblISV.Size = new Size(65, 28);
            lblISV.TabIndex = 134;
            lblISV.Text = "00.00";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(535, 127);
            label16.Name = "label16";
            label16.Size = new Size(68, 20);
            label16.TabIndex = 133;
            label16.Text = "Subtotal:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(254, 116);
            label17.Name = "label17";
            label17.Size = new Size(54, 20);
            label17.TabIndex = 129;
            label17.Text = "Estado";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtotal.Location = new Point(624, 120);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(65, 28);
            lblSubtotal.TabIndex = 132;
            lblSubtotal.Text = "00.00";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(525, 159);
            label19.Name = "label19";
            label19.Size = new Size(75, 20);
            label19.TabIndex = 131;
            label19.Text = "ISV (15%):";
            // 
            // lblCodigoEmpleado
            // 
            lblCodigoEmpleado.AutoSize = true;
            lblCodigoEmpleado.Location = new Point(351, 36);
            lblCodigoEmpleado.Name = "lblCodigoEmpleado";
            lblCodigoEmpleado.Size = new Size(25, 20);
            lblCodigoEmpleado.TabIndex = 130;
            lblCodigoEmpleado.Text = "00";
            // 
            // txtEmpleado
            // 
            txtEmpleado.BorderStyle = BorderStyle.FixedSingle;
            txtEmpleado.Enabled = false;
            txtEmpleado.Location = new Point(254, 61);
            txtEmpleado.Multiline = true;
            txtEmpleado.Name = "txtEmpleado";
            txtEmpleado.Size = new Size(201, 29);
            txtEmpleado.TabIndex = 128;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(254, 38);
            label21.Name = "label21";
            label21.Size = new Size(77, 20);
            label21.TabIndex = 127;
            label21.Text = "Empleado";
            // 
            // txtCodigoGenerado
            // 
            txtCodigoGenerado.BorderStyle = BorderStyle.FixedSingle;
            txtCodigoGenerado.Enabled = false;
            txtCodigoGenerado.Location = new Point(16, 26);
            txtCodigoGenerado.Name = "txtCodigoGenerado";
            txtCodigoGenerado.ReadOnly = true;
            txtCodigoGenerado.Size = new Size(215, 27);
            txtCodigoGenerado.TabIndex = 141;
            // 
            // groupBox2
            // 
            groupBox2.CausesValidation = false;
            groupBox2.Controls.Add(btnImprimir);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtCodigoGenerado);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(dgvPedidoSelect);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label21);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(dtpFechaRegistro);
            groupBox2.Controls.Add(lblTotalPago);
            groupBox2.Controls.Add(txtEmpleado);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(txtEstado);
            groupBox2.Controls.Add(lblISV);
            groupBox2.Controls.Add(lblCodigoEmpleado);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(lblSubtotal);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(label19);
            groupBox2.Location = new Point(12, 378);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(776, 253);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pedido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(535, 35);
            label2.Name = "label2";
            label2.Size = new Size(122, 20);
            label2.TabIndex = 142;
            label2.Text = "Fecha del Pedido";
            // 
            // btnRefreshDG
            // 
            btnRefreshDG.FlatAppearance.BorderSize = 0;
            btnRefreshDG.FlatStyle = FlatStyle.Flat;
            btnRefreshDG.Image = Properties.Resources.refresh;
            btnRefreshDG.Location = new Point(306, 32);
            btnRefreshDG.Name = "btnRefreshDG";
            btnRefreshDG.Size = new Size(29, 29);
            btnRefreshDG.TabIndex = 139;
            btnRefreshDG.UseVisualStyleBackColor = true;
            btnRefreshDG.Click += btnRefreshDG_Click;
            // 
            // btnFechaPedido
            // 
            btnFechaPedido.FlatStyle = FlatStyle.Flat;
            btnFechaPedido.Image = Properties.Resources.search;
            btnFechaPedido.Location = new Point(503, 96);
            btnFechaPedido.Name = "btnFechaPedido";
            btnFechaPedido.Size = new Size(30, 27);
            btnFechaPedido.TabIndex = 138;
            btnFechaPedido.UseVisualStyleBackColor = true;
            // 
            // dtpFechaPedido
            // 
            dtpFechaPedido.Location = new Point(536, 96);
            dtpFechaPedido.Name = "dtpFechaPedido";
            dtpFechaPedido.Size = new Size(250, 27);
            dtpFechaPedido.TabIndex = 137;
            dtpFechaPedido.ValueChanged += dtpFechaPedido_ValueChanged;
            // 
            // reportFactura
            // 
            reportFactura.NeedRefresh = false;
            reportFactura.ReportResourceString = resources.GetString("reportFactura.ReportResourceString");
            reportFactura.Tag = null;
            // 
            // ReporteFacturas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 666);
            Controls.Add(btnRefreshDG);
            Controls.Add(btnFechaPedido);
            Controls.Add(dtpFechaPedido);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(dgvHistorialPedidos);
            Name = "ReporteFacturas";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dgvHistorialPedidos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedidoSelect).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)reportFactura).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvHistorialPedidos;
        private Label label1;
        private Panel panel1;
        private Button btnImprimir;
        private DataGridView dgvPedidoSelect;
        public DateTimePicker dtpFechaRegistro;
        public Label label6;
        public Label label8;
        public Label label10;
        public TextBox txtEstado;
        public Label lblTotalPago;
        private Label label14;
        public Label lblISV;
        private Label label16;
        private Label label17;
        public Label lblSubtotal;
        private Label label19;
        public Label lblCodigoEmpleado;
        public TextBox txtEmpleado;
        private Label label21;
        public TextBox txtCodigoGenerado;
        private GroupBox groupBox2;
        private Label label2;
        public Button btnRefreshDG;
        private Button btnFechaPedido;
        private DateTimePicker dtpFechaPedido;
        private FastReport.Report reportFactura;
    }
}
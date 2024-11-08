namespace zompyDogs
{
    partial class Facturas
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
            button1 = new Button();
            btnVisualizarRegistro = new Button();
            lblTituloRegistroPanel = new Label();
            txtBuscarUsuario = new TextBox();
            groupBox1 = new GroupBox();
            dgvHistorialPedidos = new DataGridView();
            topBarMenu = new Panel();
            btnHistorial = new Button();
            pictureBox2 = new PictureBox();
            btnPuntoVenta = new Button();
            lblTITULO = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialPedidos).BeginInit();
            topBarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.search;
            button1.Location = new Point(320, 72);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(26, 20);
            button1.TabIndex = 132;
            button1.UseVisualStyleBackColor = true;
            // 
            // btnVisualizarRegistro
            // 
            btnVisualizarRegistro.Image = Properties.Resources.file__1_;
            btnVisualizarRegistro.Location = new Point(18, 154);
            btnVisualizarRegistro.Margin = new Padding(3, 2, 3, 2);
            btnVisualizarRegistro.Name = "btnVisualizarRegistro";
            btnVisualizarRegistro.Size = new Size(63, 54);
            btnVisualizarRegistro.TabIndex = 129;
            btnVisualizarRegistro.UseVisualStyleBackColor = true;
            btnVisualizarRegistro.Click += btnVisualizarRegistro_Click;
            // 
            // lblTituloRegistroPanel
            // 
            lblTituloRegistroPanel.AutoSize = true;
            lblTituloRegistroPanel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloRegistroPanel.Location = new Point(18, 113);
            lblTituloRegistroPanel.Name = "lblTituloRegistroPanel";
            lblTituloRegistroPanel.Size = new Size(243, 32);
            lblTituloRegistroPanel.TabIndex = 123;
            lblTituloRegistroPanel.Text = "Historial de Pedidos";
            // 
            // txtBuscarUsuario
            // 
            txtBuscarUsuario.Location = new Point(347, 72);
            txtBuscarUsuario.Margin = new Padding(3, 2, 3, 2);
            txtBuscarUsuario.Multiline = true;
            txtBuscarUsuario.Name = "txtBuscarUsuario";
            txtBuscarUsuario.PlaceholderText = "Buscar Empleado";
            txtBuscarUsuario.Size = new Size(479, 27);
            txtBuscarUsuario.PlaceholderText = "Buscar Num Factura";
            txtBuscarUsuario.Size = new Size(420, 21);
            txtBuscarUsuario.TabIndex = 120;
            txtBuscarUsuario.TextChanged += txtBuscarUsuario_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvHistorialPedidos);
            groupBox1.Location = new Point(18, 224);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(732, 304);
            groupBox1.TabIndex = 121;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pedidos";
            // 
            // dgvHistorialPedidos
            // 
            dgvHistorialPedidos.AllowUserToAddRows = false;
            dgvHistorialPedidos.AllowUserToDeleteRows = false;
            dgvHistorialPedidos.AllowUserToOrderColumns = true;
            dgvHistorialPedidos.AllowUserToResizeColumns = false;
            dgvHistorialPedidos.AllowUserToResizeRows = false;
            dgvHistorialPedidos.BackgroundColor = SystemColors.Window;
            dgvHistorialPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorialPedidos.Location = new Point(13, 20);
            dgvHistorialPedidos.Margin = new Padding(3, 2, 3, 2);
            dgvHistorialPedidos.Name = "dgvHistorialPedidos";
            dgvHistorialPedidos.ReadOnly = true;
            dgvHistorialPedidos.RowHeadersWidth = 51;
            dgvHistorialPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialPedidos.Size = new Size(700, 254);
            dgvHistorialPedidos.TabIndex = 72;
            dgvHistorialPedidos.CellClick += dgvHistorialPedidos_CellClick;
            // 
            // topBarMenu
            // 
            topBarMenu.BackColor = Color.FromArgb(31, 19, 10);
            topBarMenu.Controls.Add(btnHistorial);
            topBarMenu.Controls.Add(pictureBox2);
            topBarMenu.Controls.Add(btnPuntoVenta);
            topBarMenu.Controls.Add(lblTITULO);
            topBarMenu.Dock = DockStyle.Top;
            topBarMenu.Location = new Point(0, 0);
            topBarMenu.Margin = new Padding(3, 2, 3, 2);
            topBarMenu.Name = "topBarMenu";
            topBarMenu.Size = new Size(788, 61);
            topBarMenu.TabIndex = 133;
            // 
            // btnHistorial
            // 
            btnHistorial.BackColor = Color.White;
            btnHistorial.FlatAppearance.BorderSize = 0;
            btnHistorial.FlatStyle = FlatStyle.Flat;
            btnHistorial.ForeColor = SystemColors.ActiveCaptionText;
            btnHistorial.Location = new Point(628, 34);
            btnHistorial.Margin = new Padding(3, 2, 3, 2);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(133, 27);
            btnHistorial.TabIndex = 99;
            btnHistorial.Text = "HISTORIAL";
            btnHistorial.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.invoice;
            pictureBox2.Location = new Point(32, 22);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(59, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 97;
            pictureBox2.TabStop = false;
            // 
            // btnPuntoVenta
            // 
            btnPuntoVenta.BackColor = Color.Transparent;
            btnPuntoVenta.FlatAppearance.BorderSize = 0;
            btnPuntoVenta.FlatStyle = FlatStyle.Flat;
            btnPuntoVenta.ForeColor = SystemColors.ButtonHighlight;
            btnPuntoVenta.Location = new Point(488, 34);
            btnPuntoVenta.Margin = new Padding(3, 2, 3, 2);
            btnPuntoVenta.Name = "btnPuntoVenta";
            btnPuntoVenta.Size = new Size(133, 27);
            btnPuntoVenta.TabIndex = 98;
            btnPuntoVenta.Text = "PUNTO DE VENTA";
            btnPuntoVenta.UseVisualStyleBackColor = false;
            btnPuntoVenta.Click += btnPuntoVenta_Click;
            // 
            // lblTITULO
            // 
            lblTITULO.AutoSize = true;
            lblTITULO.BackColor = Color.Transparent;
            lblTITULO.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTITULO.ForeColor = Color.Transparent;
            lblTITULO.Location = new Point(95, 26);
            lblTITULO.Name = "lblTITULO";
            lblTITULO.Size = new Size(109, 25);
            lblTITULO.TabIndex = 3;
            lblTITULO.Text = "HISTORIAL";
            lblTITULO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Facturas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(788, 544);
            Controls.Add(topBarMenu);
            Controls.Add(button1);
            Controls.Add(btnVisualizarRegistro);
            Controls.Add(lblTituloRegistroPanel);
            Controls.Add(txtBuscarUsuario);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Facturas";
            Text = "Facturas";
//            Load += Facturas_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorialPedidos).EndInit();
            topBarMenu.ResumeLayout(false);
            topBarMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button btnVisualizarRegistro;
        private Label lblTituloRegistroPanel;
        private TextBox txtBuscarUsuario;
        private GroupBox groupBox1;
        public DataGridView dgvUsuarios;
        private DataGridView dgvProveedor;
        public DataGridView dgvEmpleados;
        public DataGridView dgvHistorialPedidos;
        private Panel topBarMenu;
        public Button btnHistorial;
        private PictureBox pictureBox2;
        public Button btnPuntoVenta;
        private Label lblTITULO;
    }
}
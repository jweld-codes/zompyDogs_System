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
            lblTITULO = new Label();
            dtpFechaPedido = new DateTimePicker();
            btnFechaPedido = new Button();
            btnRefreshDG = new Button();
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
            button1.Location = new Point(366, 96);
            button1.Name = "button1";
            button1.Size = new Size(30, 27);
            button1.TabIndex = 132;
            button1.UseVisualStyleBackColor = true;
            // 
            // btnVisualizarRegistro
            // 
            btnVisualizarRegistro.Image = Properties.Resources.file__1_;
            btnVisualizarRegistro.Location = new Point(21, 205);
            btnVisualizarRegistro.Name = "btnVisualizarRegistro";
            btnVisualizarRegistro.Size = new Size(72, 72);
            btnVisualizarRegistro.TabIndex = 129;
            btnVisualizarRegistro.UseVisualStyleBackColor = true;
            btnVisualizarRegistro.Click += btnVisualizarRegistro_Click;
            // 
            // lblTituloRegistroPanel
            // 
            lblTituloRegistroPanel.AutoSize = true;
            lblTituloRegistroPanel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloRegistroPanel.Location = new Point(21, 151);
            lblTituloRegistroPanel.Name = "lblTituloRegistroPanel";
            lblTituloRegistroPanel.Size = new Size(301, 41);
            lblTituloRegistroPanel.TabIndex = 123;
            lblTituloRegistroPanel.Text = "Historial de Pedidos";
            // 
            // txtBuscarUsuario
            // 
            txtBuscarUsuario.Location = new Point(397, 96);
            txtBuscarUsuario.Multiline = true;
            txtBuscarUsuario.Name = "txtBuscarUsuario";
            txtBuscarUsuario.PlaceholderText = "Buscador";
            txtBuscarUsuario.Size = new Size(479, 27);
            txtBuscarUsuario.TabIndex = 120;
            txtBuscarUsuario.TextChanged += txtBuscarUsuario_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvHistorialPedidos);
            groupBox1.Location = new Point(21, 299);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(837, 405);
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
            dgvHistorialPedidos.Location = new Point(15, 27);
            dgvHistorialPedidos.Name = "dgvHistorialPedidos";
            dgvHistorialPedidos.ReadOnly = true;
            dgvHistorialPedidos.RowHeadersWidth = 51;
            dgvHistorialPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialPedidos.Size = new Size(800, 339);
            dgvHistorialPedidos.TabIndex = 72;
            dgvHistorialPedidos.CellClick += dgvHistorialPedidos_CellClick;
            // 
            // topBarMenu
            // 
            topBarMenu.BackColor = Color.FromArgb(31, 19, 10);
            topBarMenu.Controls.Add(btnHistorial);
            topBarMenu.Controls.Add(pictureBox2);
            topBarMenu.Controls.Add(lblTITULO);
            topBarMenu.Dock = DockStyle.Top;
            topBarMenu.Location = new Point(0, 0);
            topBarMenu.Name = "topBarMenu";
            topBarMenu.Size = new Size(901, 81);
            topBarMenu.TabIndex = 133;
            // 
            // btnHistorial
            // 
            btnHistorial.BackColor = Color.White;
            btnHistorial.FlatAppearance.BorderSize = 0;
            btnHistorial.FlatStyle = FlatStyle.Flat;
            btnHistorial.ForeColor = SystemColors.ActiveCaptionText;
            btnHistorial.Location = new Point(718, 45);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(152, 36);
            btnHistorial.TabIndex = 99;
            btnHistorial.Text = "HISTORIAL";
            btnHistorial.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.invoice;
            pictureBox2.Location = new Point(37, 29);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(67, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 97;
            pictureBox2.TabStop = false;
            // 
            // lblTITULO
            // 
            lblTITULO.AutoSize = true;
            lblTITULO.BackColor = Color.Transparent;
            lblTITULO.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTITULO.ForeColor = Color.Transparent;
            lblTITULO.Location = new Point(109, 35);
            lblTITULO.Name = "lblTITULO";
            lblTITULO.Size = new Size(131, 31);
            lblTITULO.TabIndex = 3;
            lblTITULO.Text = "HISTORIAL";
            lblTITULO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtpFechaPedido
            // 
            dtpFechaPedido.Location = new Point(537, 266);
            dtpFechaPedido.Name = "dtpFechaPedido";
            dtpFechaPedido.Size = new Size(250, 27);
            dtpFechaPedido.TabIndex = 134;
            dtpFechaPedido.ValueChanged += dtpFechaPedido_ValueChanged;
            // 
            // btnFechaPedido
            // 
            btnFechaPedido.FlatStyle = FlatStyle.Flat;
            btnFechaPedido.Image = Properties.Resources.search;
            btnFechaPedido.Location = new Point(504, 266);
            btnFechaPedido.Name = "btnFechaPedido";
            btnFechaPedido.Size = new Size(30, 27);
            btnFechaPedido.TabIndex = 135;
            btnFechaPedido.UseVisualStyleBackColor = true;
            btnFechaPedido.Click += btnFechaPedido_Click;
            // 
            // btnRefreshDG
            // 
            btnRefreshDG.FlatAppearance.BorderSize = 0;
            btnRefreshDG.FlatStyle = FlatStyle.Flat;
            btnRefreshDG.Image = Properties.Resources.refresh;
            btnRefreshDG.Location = new Point(795, 264);
            btnRefreshDG.Name = "btnRefreshDG";
            btnRefreshDG.Size = new Size(29, 29);
            btnRefreshDG.TabIndex = 136;
            btnRefreshDG.UseVisualStyleBackColor = true;
            btnRefreshDG.Click += btnRefreshDG_Click;
            // 
            // Facturas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(901, 725);
            Controls.Add(btnRefreshDG);
            Controls.Add(btnFechaPedido);
            Controls.Add(dtpFechaPedido);
            Controls.Add(topBarMenu);
            Controls.Add(button1);
            Controls.Add(btnVisualizarRegistro);
            Controls.Add(lblTituloRegistroPanel);
            Controls.Add(txtBuscarUsuario);
            Controls.Add(groupBox1);
            Name = "Facturas";
            Text = "Facturas";
            Load += Facturas_Load;
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
        private Label lblTITULO;
        private DateTimePicker dtpFechaPedido;
        private Button btnFechaPedido;
        public Button btnRefreshDG;
    }
}
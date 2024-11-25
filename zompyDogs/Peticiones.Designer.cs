namespace zompyDogs
{
    partial class Peticiones
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
            topBarMenu = new Panel();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            btnUsuarioPanel = new Button();
            lblTITULO = new Label();
            lblBreadCrumbUser = new Label();
            groupBox1 = new GroupBox();
            dgvPeticionesCompletadas = new DataGridView();
            label1 = new Label();
            btnAgregarRegistro = new Button();
            lblTituloRegistroPanel = new Label();
            btnActualizar = new Button();
            btnRefreshDG = new Button();
            btnVisualizarRegistro = new Button();
            groupBox2 = new GroupBox();
            dgvPeticionesPendientes = new DataGridView();
            btnEliminarUsuario = new Button();
            errorProviderEmptyStrings = new ErrorProvider(components);
            topBarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeticionesCompletadas).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeticionesPendientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderEmptyStrings).BeginInit();
            SuspendLayout();
            // 
            // topBarMenu
            // 
            topBarMenu.BackColor = Color.FromArgb(31, 19, 10);
            topBarMenu.Controls.Add(button1);
            topBarMenu.Controls.Add(pictureBox2);
            topBarMenu.Controls.Add(btnUsuarioPanel);
            topBarMenu.Controls.Add(lblTITULO);
            topBarMenu.Dock = DockStyle.Top;
            topBarMenu.Location = new Point(0, 0);
            topBarMenu.Name = "topBarMenu";
            topBarMenu.Size = new Size(901, 81);
            topBarMenu.TabIndex = 106;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(570, 45);
            button1.Name = "button1";
            button1.Size = new Size(152, 36);
            button1.TabIndex = 99;
            button1.Text = "Peticiones";
            button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.petition1;
            pictureBox2.Location = new Point(36, 29);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(67, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 97;
            pictureBox2.TabStop = false;
            // 
            // btnUsuarioPanel
            // 
            btnUsuarioPanel.BackColor = Color.Transparent;
            btnUsuarioPanel.FlatAppearance.BorderSize = 0;
            btnUsuarioPanel.FlatStyle = FlatStyle.Flat;
            btnUsuarioPanel.ForeColor = SystemColors.Control;
            btnUsuarioPanel.Location = new Point(728, 45);
            btnUsuarioPanel.Name = "btnUsuarioPanel";
            btnUsuarioPanel.Size = new Size(152, 36);
            btnUsuarioPanel.TabIndex = 98;
            btnUsuarioPanel.Text = "Mis Peticiones";
            btnUsuarioPanel.UseVisualStyleBackColor = false;
            btnUsuarioPanel.Click += btnUsuarioPanel_Click;
            // 
            // lblTITULO
            // 
            lblTITULO.AutoSize = true;
            lblTITULO.BackColor = Color.Transparent;
            lblTITULO.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTITULO.ForeColor = Color.Transparent;
            lblTITULO.Location = new Point(108, 34);
            lblTITULO.Name = "lblTITULO";
            lblTITULO.Size = new Size(141, 31);
            lblTITULO.TabIndex = 3;
            lblTITULO.Text = "PETICIONES";
            lblTITULO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBreadCrumbUser
            // 
            lblBreadCrumbUser.AutoSize = true;
            lblBreadCrumbUser.BackColor = Color.Transparent;
            lblBreadCrumbUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBreadCrumbUser.ForeColor = Color.LimeGreen;
            lblBreadCrumbUser.Location = new Point(141, 99);
            lblBreadCrumbUser.Name = "lblBreadCrumbUser";
            lblBreadCrumbUser.Size = new Size(93, 20);
            lblBreadCrumbUser.TabIndex = 108;
            lblBreadCrumbUser.Text = "PETICIONES";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvPeticionesCompletadas);
            groupBox1.Location = new Point(21, 279);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(420, 405);
            groupBox1.TabIndex = 103;
            groupBox1.TabStop = false;
            groupBox1.Text = "Peticiones Completadas";
            // 
            // dgvPeticionesCompletadas
            // 
            dgvPeticionesCompletadas.AllowUserToAddRows = false;
            dgvPeticionesCompletadas.AllowUserToDeleteRows = false;
            dgvPeticionesCompletadas.AllowUserToOrderColumns = true;
            dgvPeticionesCompletadas.AllowUserToResizeColumns = false;
            dgvPeticionesCompletadas.AllowUserToResizeRows = false;
            dgvPeticionesCompletadas.BackgroundColor = SystemColors.Window;
            dgvPeticionesCompletadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeticionesCompletadas.Location = new Point(6, 26);
            dgvPeticionesCompletadas.Name = "dgvPeticionesCompletadas";
            dgvPeticionesCompletadas.ReadOnly = true;
            dgvPeticionesCompletadas.RowHeadersWidth = 51;
            dgvPeticionesCompletadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeticionesCompletadas.Size = new Size(408, 353);
            dgvPeticionesCompletadas.TabIndex = 69;
            dgvPeticionesCompletadas.CellClick += dgvPeticiones_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 98);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 107;
            label1.Text = "PETICIONES /";
            // 
            // btnAgregarRegistro
            // 
            btnAgregarRegistro.Image = Properties.Resources.plus;
            btnAgregarRegistro.Location = new Point(36, 189);
            btnAgregarRegistro.Name = "btnAgregarRegistro";
            btnAgregarRegistro.Size = new Size(72, 72);
            btnAgregarRegistro.TabIndex = 104;
            btnAgregarRegistro.UseVisualStyleBackColor = true;
            btnAgregarRegistro.Click += btnAgregarRegistro_Click;
            // 
            // lblTituloRegistroPanel
            // 
            lblTituloRegistroPanel.AutoSize = true;
            lblTituloRegistroPanel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloRegistroPanel.Location = new Point(36, 141);
            lblTituloRegistroPanel.Name = "lblTituloRegistroPanel";
            lblTituloRegistroPanel.Size = new Size(342, 41);
            lblTituloRegistroPanel.TabIndex = 105;
            lblTituloRegistroPanel.Text = "Registros de Peticiones";
            // 
            // btnActualizar
            // 
            btnActualizar.Image = Properties.Resources.pen__1_;
            btnActualizar.Location = new Point(192, 189);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(72, 72);
            btnActualizar.TabIndex = 111;
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnRefreshDG
            // 
            btnRefreshDG.FlatAppearance.BorderSize = 0;
            btnRefreshDG.FlatStyle = FlatStyle.Flat;
            btnRefreshDG.Image = Properties.Resources.refresh;
            btnRefreshDG.Location = new Point(374, 151);
            btnRefreshDG.Name = "btnRefreshDG";
            btnRefreshDG.Size = new Size(29, 29);
            btnRefreshDG.TabIndex = 112;
            btnRefreshDG.UseVisualStyleBackColor = true;
            btnRefreshDG.Click += btnRefreshDG_Click;
            // 
            // btnVisualizarRegistro
            // 
            btnVisualizarRegistro.Image = Properties.Resources.file__1_;
            btnVisualizarRegistro.Location = new Point(114, 189);
            btnVisualizarRegistro.Name = "btnVisualizarRegistro";
            btnVisualizarRegistro.Size = new Size(72, 72);
            btnVisualizarRegistro.TabIndex = 114;
            btnVisualizarRegistro.UseVisualStyleBackColor = true;
            btnVisualizarRegistro.Click += btnVisualizarRegistro_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvPeticionesPendientes);
            groupBox2.Location = new Point(447, 279);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(433, 405);
            groupBox2.TabIndex = 104;
            groupBox2.TabStop = false;
            groupBox2.Text = "Peticiones Pendientes";
            // 
            // dgvPeticionesPendientes
            // 
            dgvPeticionesPendientes.AllowUserToAddRows = false;
            dgvPeticionesPendientes.AllowUserToDeleteRows = false;
            dgvPeticionesPendientes.AllowUserToOrderColumns = true;
            dgvPeticionesPendientes.AllowUserToResizeColumns = false;
            dgvPeticionesPendientes.AllowUserToResizeRows = false;
            dgvPeticionesPendientes.BackgroundColor = SystemColors.Window;
            dgvPeticionesPendientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeticionesPendientes.Location = new Point(15, 26);
            dgvPeticionesPendientes.Name = "dgvPeticionesPendientes";
            dgvPeticionesPendientes.ReadOnly = true;
            dgvPeticionesPendientes.RowHeadersWidth = 51;
            dgvPeticionesPendientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeticionesPendientes.Size = new Size(387, 353);
            dgvPeticionesPendientes.TabIndex = 69;
            dgvPeticionesPendientes.CellClick += dgvPeticionesPendientes_CellClick;
            // 
            // btnEliminarUsuario
            // 
            btnEliminarUsuario.Image = Properties.Resources.bin;
            btnEliminarUsuario.Location = new Point(270, 189);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Size = new Size(72, 72);
            btnEliminarUsuario.TabIndex = 130;
            btnEliminarUsuario.UseVisualStyleBackColor = true;
            btnEliminarUsuario.Click += btnEliminarUsuario_Click_1;
            // 
            // errorProviderEmptyStrings
            // 
            errorProviderEmptyStrings.ContainerControl = this;
            // 
            // Peticiones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(901, 725);
            Controls.Add(btnEliminarUsuario);
            Controls.Add(groupBox2);
            Controls.Add(btnVisualizarRegistro);
            Controls.Add(btnRefreshDG);
            Controls.Add(btnActualizar);
            Controls.Add(topBarMenu);
            Controls.Add(lblBreadCrumbUser);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(btnAgregarRegistro);
            Controls.Add(lblTituloRegistroPanel);
            Name = "Peticiones";
            Text = "Peticiones";
            topBarMenu.ResumeLayout(false);
            topBarMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPeticionesCompletadas).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPeticionesPendientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderEmptyStrings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel topBarMenu;
        private PictureBox pictureBox2;
        private Button btnUsuarioPanel;
        private Label lblTITULO;
        public Label lblBreadCrumbUser;
        private GroupBox groupBox1;
        public DataGridView dgvPeticionesCompletadas;
        private Label label1;
        public Button btnAgregarRegistro;
        private Label lblTituloRegistroPanel;
        public Button btnActualizar;
        public Button btnRefreshDG;
        private Button btnVisualizarRegistro;
        private GroupBox groupBox2;
        public DataGridView dgvPeticionesPendientes;
        public Button btnEliminarUsuario;
        private ErrorProvider errorProviderEmptyStrings;
        private Button button1;
    }
}
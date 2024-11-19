namespace zompyDogs
{
    partial class Menu
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
            btnEditarUsuario = new Button();
            btnEliminarUsuario = new Button();
            topBarMenu = new Panel();
            btnLibretaMenu = new Button();
            pictureBox2 = new PictureBox();
            btnMenuPanel = new Button();
            lblTITULO = new Label();
            lblBreadCrumbUser = new Label();
            groupBox1 = new GroupBox();
            dgvMenu = new DataGridView();
            dgvEmpleados = new DataGridView();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dgvAdminis = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dgvUsuarios = new DataGridView();
            colCedula = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btnAgregarNuevoUsuario = new Button();
            lblTituloRegistroPanel = new Label();
            btnVisualizarRegistro = new Button();
            btnRefreshDG = new Button();
            button1 = new Button();
            txtBuscarUsuario = new TextBox();
            topBarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdminis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.FlatAppearance.BorderSize = 0;
            btnEditarUsuario.Image = Properties.Resources.pen__1_;
            btnEditarUsuario.Location = new Point(187, 214);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(72, 72);
            btnEditarUsuario.TabIndex = 120;
            btnEditarUsuario.UseVisualStyleBackColor = true;
            btnEditarUsuario.Click += btnEditarUsuario_Click;
            // 
            // btnEliminarUsuario
            // 
            btnEliminarUsuario.FlatAppearance.BorderSize = 0;
            btnEliminarUsuario.Image = Properties.Resources.bin;
            btnEliminarUsuario.Location = new Point(265, 214);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Size = new Size(72, 72);
            btnEliminarUsuario.TabIndex = 119;
            btnEliminarUsuario.UseVisualStyleBackColor = true;
            btnEliminarUsuario.Click += btnEliminarUsuario_Click;
            // 
            // topBarMenu
            // 
            topBarMenu.BackColor = Color.FromArgb(31, 19, 10);
            topBarMenu.Controls.Add(btnLibretaMenu);
            topBarMenu.Controls.Add(pictureBox2);
            topBarMenu.Controls.Add(btnMenuPanel);
            topBarMenu.Controls.Add(lblTITULO);
            topBarMenu.Dock = DockStyle.Top;
            topBarMenu.Location = new Point(0, 0);
            topBarMenu.Name = "topBarMenu";
            topBarMenu.Size = new Size(901, 81);
            topBarMenu.TabIndex = 116;
            // 
            // btnLibretaMenu
            // 
            btnLibretaMenu.FlatAppearance.BorderSize = 0;
            btnLibretaMenu.FlatStyle = FlatStyle.Flat;
            btnLibretaMenu.ForeColor = SystemColors.ControlLightLight;
            btnLibretaMenu.Location = new Point(706, 45);
            btnLibretaMenu.Name = "btnLibretaMenu";
            btnLibretaMenu.Size = new Size(152, 36);
            btnLibretaMenu.TabIndex = 99;
            btnLibretaMenu.Text = "Libreta";
            btnLibretaMenu.UseVisualStyleBackColor = true;
            btnLibretaMenu.Click += btnLibretaMenu_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.dinner;
            pictureBox2.Location = new Point(36, 29);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(67, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 97;
            pictureBox2.TabStop = false;
            // 
            // btnMenuPanel
            // 
            btnMenuPanel.BackColor = Color.White;
            btnMenuPanel.FlatAppearance.BorderSize = 0;
            btnMenuPanel.FlatStyle = FlatStyle.Flat;
            btnMenuPanel.ForeColor = SystemColors.ActiveCaptionText;
            btnMenuPanel.Location = new Point(547, 45);
            btnMenuPanel.Name = "btnMenuPanel";
            btnMenuPanel.Size = new Size(152, 36);
            btnMenuPanel.TabIndex = 98;
            btnMenuPanel.Text = "MENÚ";
            btnMenuPanel.UseVisualStyleBackColor = false;
            // 
            // lblTITULO
            // 
            lblTITULO.AutoSize = true;
            lblTITULO.BackColor = Color.Transparent;
            lblTITULO.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTITULO.ForeColor = Color.Transparent;
            lblTITULO.Location = new Point(109, 34);
            lblTITULO.Name = "lblTITULO";
            lblTITULO.Size = new Size(83, 31);
            lblTITULO.TabIndex = 3;
            lblTITULO.Text = "MENÚ";
            lblTITULO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBreadCrumbUser
            // 
            lblBreadCrumbUser.AutoSize = true;
            lblBreadCrumbUser.BackColor = Color.Transparent;
            lblBreadCrumbUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBreadCrumbUser.ForeColor = Color.LimeGreen;
            lblBreadCrumbUser.Location = new Point(109, 108);
            lblBreadCrumbUser.Name = "lblBreadCrumbUser";
            lblBreadCrumbUser.Size = new Size(54, 20);
            lblBreadCrumbUser.TabIndex = 118;
            lblBreadCrumbUser.Text = "MENÚ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvMenu);
            groupBox1.Controls.Add(dgvEmpleados);
            groupBox1.Controls.Add(dgvAdminis);
            groupBox1.Controls.Add(dgvUsuarios);
            groupBox1.Location = new Point(21, 309);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(837, 405);
            groupBox1.TabIndex = 113;
            groupBox1.TabStop = false;
            groupBox1.Text = "MENU";
            // 
            // dgvMenu
            // 
            dgvMenu.AllowUserToAddRows = false;
            dgvMenu.AllowUserToDeleteRows = false;
            dgvMenu.AllowUserToOrderColumns = true;
            dgvMenu.AllowUserToResizeColumns = false;
            dgvMenu.AllowUserToResizeRows = false;
            dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMenu.BackgroundColor = SystemColors.Window;
            dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMenu.Location = new Point(15, 26);
            dgvMenu.Name = "dgvMenu";
            dgvMenu.ReadOnly = true;
            dgvMenu.RowHeadersWidth = 51;
            dgvMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMenu.Size = new Size(800, 338);
            dgvMenu.TabIndex = 74;
            dgvMenu.CellClick += dgvMenu_CellClick;
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.AllowUserToDeleteRows = false;
            dgvEmpleados.AllowUserToOrderColumns = true;
            dgvEmpleados.AllowUserToResizeColumns = false;
            dgvEmpleados.AllowUserToResizeRows = false;
            dgvEmpleados.BackgroundColor = SystemColors.Window;
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dgvEmpleados.Location = new Point(15, 26);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.RowHeadersWidth = 51;
            dgvEmpleados.Size = new Size(800, 338);
            dgvEmpleados.TabIndex = 73;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "IDCedula";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Nombre";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Empleado";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dgvAdminis
            // 
            dgvAdminis.AllowUserToAddRows = false;
            dgvAdminis.AllowUserToDeleteRows = false;
            dgvAdminis.AllowUserToOrderColumns = true;
            dgvAdminis.AllowUserToResizeColumns = false;
            dgvAdminis.AllowUserToResizeRows = false;
            dgvAdminis.BackgroundColor = SystemColors.Window;
            dgvAdminis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdminis.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dgvAdminis.Location = new Point(15, 26);
            dgvAdminis.Name = "dgvAdminis";
            dgvAdminis.ReadOnly = true;
            dgvAdminis.RowHeadersWidth = 51;
            dgvAdminis.Size = new Size(800, 338);
            dgvAdminis.TabIndex = 72;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "IDCedula";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Administrador";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToOrderColumns = true;
            dgvUsuarios.AllowUserToResizeColumns = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.BackgroundColor = SystemColors.Window;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { colCedula, colNombre, Column1 });
            dgvUsuarios.Location = new Point(15, 26);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(800, 338);
            dgvUsuarios.TabIndex = 69;
            // 
            // colCedula
            // 
            colCedula.HeaderText = "IDCedula";
            colCedula.MinimumWidth = 6;
            colCedula.Name = "colCedula";
            colCedula.ReadOnly = true;
            colCedula.Width = 125;
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            colNombre.Width = 125;
            // 
            // Column1
            // 
            Column1.HeaderText = "Editar";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 108);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 117;
            label1.Text = "MENÚ /";
            // 
            // btnAgregarNuevoUsuario
            // 
            btnAgregarNuevoUsuario.FlatAppearance.BorderSize = 0;
            btnAgregarNuevoUsuario.Image = Properties.Resources.plus;
            btnAgregarNuevoUsuario.Location = new Point(36, 214);
            btnAgregarNuevoUsuario.Name = "btnAgregarNuevoUsuario";
            btnAgregarNuevoUsuario.Size = new Size(72, 72);
            btnAgregarNuevoUsuario.TabIndex = 114;
            btnAgregarNuevoUsuario.UseVisualStyleBackColor = true;
            btnAgregarNuevoUsuario.Click += btnAgregarNuevoUsuario_Click;
            // 
            // lblTituloRegistroPanel
            // 
            lblTituloRegistroPanel.AutoSize = true;
            lblTituloRegistroPanel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloRegistroPanel.Location = new Point(36, 166);
            lblTituloRegistroPanel.Name = "lblTituloRegistroPanel";
            lblTituloRegistroPanel.Size = new Size(290, 41);
            lblTituloRegistroPanel.TabIndex = 115;
            lblTituloRegistroPanel.Text = "Registros del Menú";
            // 
            // btnVisualizarRegistro
            // 
            btnVisualizarRegistro.Image = Properties.Resources.file__1_;
            btnVisualizarRegistro.Location = new Point(109, 214);
            btnVisualizarRegistro.Name = "btnVisualizarRegistro";
            btnVisualizarRegistro.Size = new Size(72, 72);
            btnVisualizarRegistro.TabIndex = 121;
            btnVisualizarRegistro.UseVisualStyleBackColor = true;
            btnVisualizarRegistro.Click += btnVisualizarRegistro_Click;
            // 
            // btnRefreshDG
            // 
            btnRefreshDG.FlatAppearance.BorderSize = 0;
            btnRefreshDG.FlatStyle = FlatStyle.Flat;
            btnRefreshDG.Image = Properties.Resources.refresh;
            btnRefreshDG.Location = new Point(807, 284);
            btnRefreshDG.Name = "btnRefreshDG";
            btnRefreshDG.Size = new Size(29, 29);
            btnRefreshDG.TabIndex = 122;
            btnRefreshDG.UseVisualStyleBackColor = true;
            btnRefreshDG.Click += btnRefreshDG_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.search;
            button1.Location = new Point(348, 101);
            button1.Name = "button1";
            button1.Size = new Size(30, 27);
            button1.TabIndex = 124;
            button1.UseVisualStyleBackColor = true;
            // 
            // txtBuscarUsuario
            // 
            txtBuscarUsuario.Location = new Point(379, 101);
            txtBuscarUsuario.Multiline = true;
            txtBuscarUsuario.Name = "txtBuscarUsuario";
            txtBuscarUsuario.PlaceholderText = "Buscar Platillo";
            txtBuscarUsuario.Size = new Size(479, 27);
            txtBuscarUsuario.TabIndex = 123;
            txtBuscarUsuario.TextChanged += txtBuscarUsuario_TextChanged;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(901, 725);
            Controls.Add(button1);
            Controls.Add(txtBuscarUsuario);
            Controls.Add(btnRefreshDG);
            Controls.Add(btnVisualizarRegistro);
            Controls.Add(btnEditarUsuario);
            Controls.Add(btnEliminarUsuario);
            Controls.Add(topBarMenu);
            Controls.Add(lblBreadCrumbUser);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(btnAgregarNuevoUsuario);
            Controls.Add(lblTituloRegistroPanel);
            Name = "Menu";
            Text = "Menu";
            topBarMenu.ResumeLayout(false);
            topBarMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdminis).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEditarUsuario;
        private Button btnEliminarUsuario;
        private Panel topBarMenu;
        public Button btnLibretaMenu;
        private PictureBox pictureBox2;
        public Button btnMenuPanel;
        private Label lblTITULO;
        private Label lblBreadCrumbUser;
        private GroupBox groupBox1;
        private DataGridView dgvEmpleados;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridView dgvAdminis;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridView dgvUsuarios;
        private DataGridViewTextBoxColumn colCedula;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn Column1;
        private Label label1;
        private Button btnAgregarNuevoUsuario;
        private Label lblTituloRegistroPanel;
        private Button btnVisualizarRegistro;
        public DataGridView dgvMenu;
        public Button btnRefreshDG;
        private Button button1;
        private TextBox txtBuscarUsuario;
    }
}
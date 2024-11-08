namespace zompyDogs
{
    partial class PeticionUsuario
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
            btnRefreshDG = new Button();
            btnActualizar = new Button();
            cbxFiltro = new ComboBox();
            btnEliminarUsuario = new Button();
            topBarMenu = new Panel();
            pictureBox2 = new PictureBox();
            lblTITULO = new Label();
            lblBreadCrumbUser = new Label();
            groupBox1 = new GroupBox();
            dgvPeticiones = new DataGridView();
            label1 = new Label();
            btnAgregarRegistro = new Button();
            lblTituloRegistroPanel = new Label();
            txtBuscarUsuario = new TextBox();
            btnPeticiones = new Button();
            btnUsuarioPanel = new Button();
            topBarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeticiones).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.search;
            button1.Location = new Point(352, 94);
            button1.Name = "button1";
            button1.Size = new Size(30, 27);
            button1.TabIndex = 128;
            button1.UseVisualStyleBackColor = true;
            // 
            // btnVisualizarRegistro
            // 
            btnVisualizarRegistro.Image = Properties.Resources.file__1_;
            btnVisualizarRegistro.Location = new Point(114, 209);
            btnVisualizarRegistro.Name = "btnVisualizarRegistro";
            btnVisualizarRegistro.Size = new Size(72, 72);
            btnVisualizarRegistro.TabIndex = 127;
            btnVisualizarRegistro.UseVisualStyleBackColor = true;
            // 
            // btnRefreshDG
            // 
            btnRefreshDG.FlatAppearance.BorderSize = 0;
            btnRefreshDG.FlatStyle = FlatStyle.Flat;
            btnRefreshDG.Image = Properties.Resources.refresh;
            btnRefreshDG.Location = new Point(803, 274);
            btnRefreshDG.Name = "btnRefreshDG";
            btnRefreshDG.Size = new Size(29, 29);
            btnRefreshDG.TabIndex = 126;
            btnRefreshDG.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Image = Properties.Resources.pen__1_;
            btnActualizar.Location = new Point(270, 209);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(72, 72);
            btnActualizar.TabIndex = 125;
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // cbxFiltro
            // 
            cbxFiltro.FormattingEnabled = true;
            cbxFiltro.Location = new Point(665, 275);
            cbxFiltro.Margin = new Padding(3, 3, 6, 3);
            cbxFiltro.Name = "cbxFiltro";
            cbxFiltro.RightToLeft = RightToLeft.Yes;
            cbxFiltro.Size = new Size(138, 28);
            cbxFiltro.Sorted = true;
            cbxFiltro.TabIndex = 124;
            cbxFiltro.Text = "Filtro";
            // 
            // btnEliminarUsuario
            // 
            btnEliminarUsuario.Image = Properties.Resources.bin;
            btnEliminarUsuario.Location = new Point(192, 209);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Size = new Size(72, 72);
            btnEliminarUsuario.TabIndex = 123;
            btnEliminarUsuario.UseVisualStyleBackColor = true;
            // 
            // topBarMenu
            // 
            topBarMenu.BackColor = Color.FromArgb(31, 19, 10);
            topBarMenu.Controls.Add(btnPeticiones);
            topBarMenu.Controls.Add(btnUsuarioPanel);
            topBarMenu.Controls.Add(pictureBox2);
            topBarMenu.Controls.Add(lblTITULO);
            topBarMenu.Dock = DockStyle.Top;
            topBarMenu.Location = new Point(0, 0);
            topBarMenu.Name = "topBarMenu";
            topBarMenu.Size = new Size(901, 81);
            topBarMenu.TabIndex = 120;
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
            lblBreadCrumbUser.Location = new Point(117, 98);
            lblBreadCrumbUser.Name = "lblBreadCrumbUser";
            lblBreadCrumbUser.Size = new Size(56, 20);
            lblBreadCrumbUser.TabIndex = 122;
            lblBreadCrumbUser.Text = "INICIO";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvPeticiones);
            groupBox1.Location = new Point(21, 299);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(837, 405);
            groupBox1.TabIndex = 117;
            groupBox1.TabStop = false;
            groupBox1.Text = "Peticiones";
            // 
            // dgvPeticiones
            // 
            dgvPeticiones.AllowUserToAddRows = false;
            dgvPeticiones.AllowUserToDeleteRows = false;
            dgvPeticiones.AllowUserToOrderColumns = true;
            dgvPeticiones.AllowUserToResizeColumns = false;
            dgvPeticiones.AllowUserToResizeRows = false;
            dgvPeticiones.BackgroundColor = SystemColors.Window;
            dgvPeticiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeticiones.Location = new Point(15, 26);
            dgvPeticiones.Name = "dgvPeticiones";
            dgvPeticiones.ReadOnly = true;
            dgvPeticiones.RowHeadersWidth = 51;
            dgvPeticiones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeticiones.Size = new Size(800, 338);
            dgvPeticiones.TabIndex = 69;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 98);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 121;
            label1.Text = "CUENTA /";
            // 
            // btnAgregarRegistro
            // 
            btnAgregarRegistro.Image = Properties.Resources.plus;
            btnAgregarRegistro.Location = new Point(36, 209);
            btnAgregarRegistro.Name = "btnAgregarRegistro";
            btnAgregarRegistro.Size = new Size(72, 72);
            btnAgregarRegistro.TabIndex = 118;
            btnAgregarRegistro.UseVisualStyleBackColor = true;
            btnAgregarRegistro.Click += btnAgregarRegistro_Click;
            // 
            // lblTituloRegistroPanel
            // 
            lblTituloRegistroPanel.AutoSize = true;
            lblTituloRegistroPanel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloRegistroPanel.Location = new Point(36, 161);
            lblTituloRegistroPanel.Name = "lblTituloRegistroPanel";
            lblTituloRegistroPanel.Size = new Size(342, 41);
            lblTituloRegistroPanel.TabIndex = 119;
            lblTituloRegistroPanel.Text = "Registros de Peticiones";
            // 
            // txtBuscarUsuario
            // 
            txtBuscarUsuario.Location = new Point(382, 93);
            txtBuscarUsuario.Multiline = true;
            txtBuscarUsuario.Name = "txtBuscarUsuario";
            txtBuscarUsuario.PlaceholderText = "Buscar Por Usuario";
            txtBuscarUsuario.Size = new Size(479, 27);
            txtBuscarUsuario.TabIndex = 116;
            // 
            // btnPeticiones
            // 
            btnPeticiones.BackColor = Color.White;
            btnPeticiones.FlatAppearance.BorderSize = 0;
            btnPeticiones.FlatStyle = FlatStyle.Flat;
            btnPeticiones.ForeColor = SystemColors.ActiveCaptionText;
            btnPeticiones.Location = new Point(765, 45);
            btnPeticiones.Name = "btnPeticiones";
            btnPeticiones.Size = new Size(123, 36);
            btnPeticiones.TabIndex = 103;
            btnPeticiones.Text = "Peticiones";
            btnPeticiones.UseVisualStyleBackColor = false;
            // 
            // btnUsuarioPanel
            // 
            btnUsuarioPanel.BackColor = Color.Transparent;
            btnUsuarioPanel.FlatAppearance.BorderSize = 0;
            btnUsuarioPanel.FlatStyle = FlatStyle.Flat;
            btnUsuarioPanel.ForeColor = SystemColors.Control;
            btnUsuarioPanel.Location = new Point(607, 45);
            btnUsuarioPanel.Name = "btnUsuarioPanel";
            btnUsuarioPanel.Size = new Size(152, 36);
            btnUsuarioPanel.TabIndex = 102;
            btnUsuarioPanel.Text = "Inicio";
            btnUsuarioPanel.UseVisualStyleBackColor = false;
            btnUsuarioPanel.Click += btnUsuarioPanel_Click;
            // 
            // PeticionUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(901, 725);
            Controls.Add(button1);
            Controls.Add(btnVisualizarRegistro);
            Controls.Add(btnRefreshDG);
            Controls.Add(btnActualizar);
            Controls.Add(cbxFiltro);
            Controls.Add(btnEliminarUsuario);
            Controls.Add(topBarMenu);
            Controls.Add(lblBreadCrumbUser);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(btnAgregarRegistro);
            Controls.Add(lblTituloRegistroPanel);
            Controls.Add(txtBuscarUsuario);
            Name = "PeticionUsuario";
            topBarMenu.ResumeLayout(false);
            topBarMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPeticiones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button btnVisualizarRegistro;
        public Button btnRefreshDG;
        public Button btnActualizar;
        public ComboBox cbxFiltro;
        public Button btnEliminarUsuario;
        private Panel topBarMenu;
        private PictureBox pictureBox2;
        private Label lblTITULO;
        public Label lblBreadCrumbUser;
        private GroupBox groupBox1;
        public DataGridView dgvPeticiones;
        private Label label1;
        public Button btnAgregarRegistro;
        private Label lblTituloRegistroPanel;
        private TextBox txtBuscarUsuario;
        private Button btnPeticiones;
        private Button btnUsuarioPanel;
    }
}
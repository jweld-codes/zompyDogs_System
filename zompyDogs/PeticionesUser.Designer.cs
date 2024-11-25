namespace zompyDogs
{
    partial class PeticionesUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeticionesUser));
            topBarMenu = new Panel();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            btnUsuarioPanel = new Button();
            lblTITULO = new Label();
            lblTituloRegistroPanel = new Label();
            label1 = new Label();
            lblBreadCrumbUser = new Label();
            panel1 = new Panel();
            gbxPeticionesBtn = new GroupBox();
            btnVisualizarRegistro = new Button();
            btnAgregarRegistro = new Button();
            btnEliminarUsuario = new Button();
            btnActualizar = new Button();
            gbxPeticiones = new GroupBox();
            dgvPeticiones = new DataGridView();
            btnPeticionesUser = new Button();
            errorProviderPeticion = new ErrorProvider(components);
            topBarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            gbxPeticionesBtn.SuspendLayout();
            gbxPeticiones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeticiones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderPeticion).BeginInit();
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
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(567, 45);
            button1.Name = "button1";
            button1.Size = new Size(152, 36);
            button1.TabIndex = 99;
            button1.Text = "Peticiones";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(36, 29);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(67, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 97;
            pictureBox2.TabStop = false;
            // 
            // btnUsuarioPanel
            // 
            btnUsuarioPanel.BackColor = Color.White;
            btnUsuarioPanel.FlatAppearance.BorderSize = 0;
            btnUsuarioPanel.FlatStyle = FlatStyle.Flat;
            btnUsuarioPanel.ForeColor = SystemColors.ActiveCaptionText;
            btnUsuarioPanel.Location = new Point(725, 45);
            btnUsuarioPanel.Name = "btnUsuarioPanel";
            btnUsuarioPanel.Size = new Size(152, 36);
            btnUsuarioPanel.TabIndex = 98;
            btnUsuarioPanel.Text = "Mis Peticiones";
            btnUsuarioPanel.UseVisualStyleBackColor = false;
            // 
            // lblTITULO
            // 
            lblTITULO.AutoSize = true;
            lblTITULO.BackColor = Color.Transparent;
            lblTITULO.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTITULO.ForeColor = Color.Transparent;
            lblTITULO.Location = new Point(109, 34);
            lblTITULO.Name = "lblTITULO";
            lblTITULO.Size = new Size(189, 31);
            lblTITULO.TabIndex = 3;
            lblTITULO.Text = "MIS PETICIONES";
            lblTITULO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloRegistroPanel
            // 
            lblTituloRegistroPanel.AutoSize = true;
            lblTituloRegistroPanel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloRegistroPanel.Location = new Point(36, 136);
            lblTituloRegistroPanel.Name = "lblTituloRegistroPanel";
            lblTituloRegistroPanel.Size = new Size(42, 41);
            lblTituloRegistroPanel.TabIndex = 105;
            lblTituloRegistroPanel.Text = "...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 87);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 107;
            label1.Text = "PETICIONES /";
            // 
            // lblBreadCrumbUser
            // 
            lblBreadCrumbUser.AutoSize = true;
            lblBreadCrumbUser.BackColor = Color.Transparent;
            lblBreadCrumbUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBreadCrumbUser.ForeColor = Color.LimeGreen;
            lblBreadCrumbUser.Location = new Point(131, 88);
            lblBreadCrumbUser.Name = "lblBreadCrumbUser";
            lblBreadCrumbUser.Size = new Size(124, 20);
            lblBreadCrumbUser.TabIndex = 108;
            lblBreadCrumbUser.Text = "MIS PETICIONES";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(gbxPeticionesBtn);
            panel1.Controls.Add(gbxPeticiones);
            panel1.Location = new Point(-12, 236);
            panel1.Name = "panel1";
            panel1.Size = new Size(933, 511);
            panel1.TabIndex = 113;
            // 
            // gbxPeticionesBtn
            // 
            gbxPeticionesBtn.Controls.Add(btnVisualizarRegistro);
            gbxPeticionesBtn.Controls.Add(btnAgregarRegistro);
            gbxPeticionesBtn.Controls.Add(btnEliminarUsuario);
            gbxPeticionesBtn.Controls.Add(btnActualizar);
            gbxPeticionesBtn.Location = new Point(39, -4);
            gbxPeticionesBtn.Name = "gbxPeticionesBtn";
            gbxPeticionesBtn.Size = new Size(307, 92);
            gbxPeticionesBtn.TabIndex = 120;
            gbxPeticionesBtn.TabStop = false;
            // 
            // btnVisualizarRegistro
            // 
            btnVisualizarRegistro.Image = Properties.Resources.file__1_;
            btnVisualizarRegistro.Location = new Point(75, 17);
            btnVisualizarRegistro.Name = "btnVisualizarRegistro";
            btnVisualizarRegistro.Size = new Size(72, 72);
            btnVisualizarRegistro.TabIndex = 131;
            btnVisualizarRegistro.UseVisualStyleBackColor = true;
            btnVisualizarRegistro.Click += btnVisualizarRegistro_Click;
            // 
            // btnAgregarRegistro
            // 
            btnAgregarRegistro.Image = Properties.Resources.plus;
            btnAgregarRegistro.Location = new Point(1, 15);
            btnAgregarRegistro.Name = "btnAgregarRegistro";
            btnAgregarRegistro.Size = new Size(72, 72);
            btnAgregarRegistro.TabIndex = 128;
            btnAgregarRegistro.UseVisualStyleBackColor = true;
            btnAgregarRegistro.Click += btnAgregarRegistro_Click;
            // 
            // btnEliminarUsuario
            // 
            btnEliminarUsuario.Image = Properties.Resources.bin;
            btnEliminarUsuario.Location = new Point(150, 16);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Size = new Size(72, 72);
            btnEliminarUsuario.TabIndex = 129;
            btnEliminarUsuario.UseVisualStyleBackColor = true;
            btnEliminarUsuario.Click += btnEliminarUsuario_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Image = Properties.Resources.pen__1_;
            btnActualizar.Location = new Point(226, 16);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(72, 72);
            btnActualizar.TabIndex = 130;
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // gbxPeticiones
            // 
            gbxPeticiones.Controls.Add(dgvPeticiones);
            gbxPeticiones.Location = new Point(35, 95);
            gbxPeticiones.Name = "gbxPeticiones";
            gbxPeticiones.Size = new Size(865, 372);
            gbxPeticiones.TabIndex = 119;
            gbxPeticiones.TabStop = false;
            gbxPeticiones.Text = "Peticiones";
            // 
            // dgvPeticiones
            // 
            dgvPeticiones.AllowUserToAddRows = false;
            dgvPeticiones.AllowUserToDeleteRows = false;
            dgvPeticiones.AllowUserToOrderColumns = true;
            dgvPeticiones.AllowUserToResizeColumns = false;
            dgvPeticiones.AllowUserToResizeRows = false;
            dgvPeticiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPeticiones.BackgroundColor = SystemColors.Window;
            dgvPeticiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeticiones.Location = new Point(16, 35);
            dgvPeticiones.Name = "dgvPeticiones";
            dgvPeticiones.ReadOnly = true;
            dgvPeticiones.RowHeadersWidth = 51;
            dgvPeticiones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeticiones.Size = new Size(836, 316);
            dgvPeticiones.TabIndex = 69;
            dgvPeticiones.CellClick += dgvPeticiones_CellClick;
            // 
            // btnPeticionesUser
            // 
            btnPeticionesUser.BackColor = Color.White;
            btnPeticionesUser.FlatStyle = FlatStyle.Flat;
            btnPeticionesUser.ForeColor = SystemColors.ActiveCaptionText;
            btnPeticionesUser.Location = new Point(726, 200);
            btnPeticionesUser.Name = "btnPeticionesUser";
            btnPeticionesUser.Size = new Size(152, 36);
            btnPeticionesUser.TabIndex = 117;
            btnPeticionesUser.Text = "Peticiones";
            btnPeticionesUser.UseVisualStyleBackColor = false;
            btnPeticionesUser.Click += btnPeticionesUser_Click;
            // 
            // errorProviderPeticion
            // 
            errorProviderPeticion.ContainerControl = this;
            // 
            // AjustesCuenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(901, 725);
            Controls.Add(btnPeticionesUser);
            Controls.Add(topBarMenu);
            Controls.Add(lblBreadCrumbUser);
            Controls.Add(label1);
            Controls.Add(lblTituloRegistroPanel);
            Controls.Add(panel1);
            Name = "AjustesCuenta";
            topBarMenu.ResumeLayout(false);
            topBarMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            gbxPeticionesBtn.ResumeLayout(false);
            gbxPeticiones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPeticiones).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderPeticion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel topBarMenu;
        private PictureBox pictureBox2;
        private Button btnUsuarioPanel;
        private Label lblTITULO;
        private Label lblTituloRegistroPanel;
        private Label label1;
        private Label lblBreadCrumbUser;
        private Panel panel1;
        private Button btnPeticionesUser;
        private GroupBox gbxPeticiones;
        public DataGridView dgvPeticiones;
        private Button btnVisualizarRegistro;
        public Button btnAgregarRegistro;
        public Button btnActualizar;
        public Button btnEliminarUsuario;
        private GroupBox gbxPeticionesBtn;
        private ErrorProvider errorProviderPeticion;
        private Label label17;
        private Button button1;
    }
}
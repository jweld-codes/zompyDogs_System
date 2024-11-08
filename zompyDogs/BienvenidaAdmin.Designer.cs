namespace zompyDogs
{
    partial class BienvenidaAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BienvenidaAdmin));
            sidebarMenu = new Panel();
            btnAjustesCuenta = new Button();
            lblCerrarSession = new Label();
            lblNombreSideBar = new Label();
            btnMenu = new Button();
            btnPOS = new Button();
            btnStaff = new Button();
            btnPeticiones = new Button();
            pictureBox2 = new PictureBox();
            btnInicio = new Button();
            panelContenedor = new Panel();
            sidebarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // sidebarMenu
            // 
            sidebarMenu.BackColor = Color.FromArgb(31, 19, 10);
            sidebarMenu.Controls.Add(btnAjustesCuenta);
            sidebarMenu.Controls.Add(lblCerrarSession);
            sidebarMenu.Controls.Add(lblNombreSideBar);
            sidebarMenu.Controls.Add(btnMenu);
            sidebarMenu.Controls.Add(btnPOS);
            sidebarMenu.Controls.Add(btnStaff);
            sidebarMenu.Controls.Add(btnPeticiones);
            sidebarMenu.Controls.Add(pictureBox2);
            sidebarMenu.Controls.Add(btnInicio);
            sidebarMenu.Dock = DockStyle.Left;
            sidebarMenu.Location = new Point(0, 0);
            sidebarMenu.Name = "sidebarMenu";
            sidebarMenu.Size = new Size(213, 772);
            sidebarMenu.TabIndex = 2;
            // 
            // btnAjustesCuenta
            // 
            btnAjustesCuenta.BackColor = Color.Transparent;
            btnAjustesCuenta.FlatAppearance.BorderSize = 0;
            btnAjustesCuenta.FlatStyle = FlatStyle.Flat;
            btnAjustesCuenta.ForeColor = SystemColors.ButtonFace;
            btnAjustesCuenta.Image = (Image)resources.GetObject("btnAjustesCuenta.Image");
            btnAjustesCuenta.ImageAlign = ContentAlignment.MiddleLeft;
            btnAjustesCuenta.Location = new Point(46, 634);
            btnAjustesCuenta.Name = "btnAjustesCuenta";
            btnAjustesCuenta.Size = new Size(167, 51);
            btnAjustesCuenta.TabIndex = 16;
            btnAjustesCuenta.Text = "Ajustes";
            btnAjustesCuenta.UseVisualStyleBackColor = false;
            btnAjustesCuenta.Click += btnAjustesCuenta_Click;
            // 
            // lblCerrarSession
            // 
            lblCerrarSession.AutoSize = true;
            lblCerrarSession.Cursor = Cursors.Hand;
            lblCerrarSession.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCerrarSession.ForeColor = SystemColors.ButtonFace;
            lblCerrarSession.Location = new Point(33, 731);
            lblCerrarSession.Name = "lblCerrarSession";
            lblCerrarSession.Size = new Size(93, 17);
            lblCerrarSession.TabIndex = 13;
            lblCerrarSession.Text = "Cerrar Sessión";
            lblCerrarSession.Click += lblCerrarSession_Click;
            lblCerrarSession.MouseEnter += lblCerrarSession_MouseEnter;
            lblCerrarSession.MouseLeave += lblCerrarSession_MouseLeave;
            // 
            // lblNombreSideBar
            // 
            lblNombreSideBar.AutoSize = true;
            lblNombreSideBar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreSideBar.ForeColor = SystemColors.ButtonFace;
            lblNombreSideBar.Location = new Point(32, 710);
            lblNombreSideBar.Name = "lblNombreSideBar";
            lblNombreSideBar.Size = new Size(25, 23);
            lblNombreSideBar.TabIndex = 9;
            lblNombreSideBar.Text = "...";
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.Transparent;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.ForeColor = SystemColors.ButtonFace;
            btnMenu.Image = (Image)resources.GetObject("btnMenu.Image");
            btnMenu.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenu.Location = new Point(46, 443);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(167, 51);
            btnMenu.TabIndex = 12;
            btnMenu.Text = "Menú";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // btnPOS
            // 
            btnPOS.BackColor = Color.Transparent;
            btnPOS.FlatAppearance.BorderSize = 0;
            btnPOS.FlatStyle = FlatStyle.Flat;
            btnPOS.ForeColor = SystemColors.ButtonFace;
            btnPOS.Image = Properties.Resources.invoice;
            btnPOS.ImageAlign = ContentAlignment.MiddleLeft;
            btnPOS.Location = new Point(46, 386);
            btnPOS.Name = "btnPOS";
            btnPOS.Size = new Size(167, 51);
            btnPOS.TabIndex = 11;
            btnPOS.Text = "      Pedidos";
            btnPOS.UseVisualStyleBackColor = false;
            btnPOS.Click += btnPOS_Click;
            // 
            // btnStaff
            // 
            btnStaff.BackColor = Color.Transparent;
            btnStaff.FlatAppearance.BorderSize = 0;
            btnStaff.FlatStyle = FlatStyle.Flat;
            btnStaff.ForeColor = SystemColors.ButtonFace;
            btnStaff.Image = (Image)resources.GetObject("btnStaff.Image");
            btnStaff.ImageAlign = ContentAlignment.MiddleLeft;
            btnStaff.Location = new Point(46, 329);
            btnStaff.Name = "btnStaff";
            btnStaff.Size = new Size(167, 51);
            btnStaff.TabIndex = 10;
            btnStaff.Text = "Staff";
            btnStaff.UseVisualStyleBackColor = false;
            btnStaff.Click += btnStaff_Click;
            // 
            // btnPeticiones
            // 
            btnPeticiones.BackColor = Color.Transparent;
            btnPeticiones.FlatAppearance.BorderSize = 0;
            btnPeticiones.FlatStyle = FlatStyle.Flat;
            btnPeticiones.ForeColor = SystemColors.ButtonFace;
            btnPeticiones.Image = (Image)resources.GetObject("btnPeticiones.Image");
            btnPeticiones.ImageAlign = ContentAlignment.MiddleLeft;
            btnPeticiones.Location = new Point(48, 272);
            btnPeticiones.Name = "btnPeticiones";
            btnPeticiones.Size = new Size(167, 51);
            btnPeticiones.TabIndex = 8;
            btnPeticiones.Text = "Peticiones";
            btnPeticiones.UseVisualStyleBackColor = false;
            btnPeticiones.Click += btnPeticiones_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Enabled = false;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(209, 182);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // btnInicio
            // 
            btnInicio.BackColor = SystemColors.Window;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.ForeColor = SystemColors.ActiveCaptionText;
            btnInicio.Image = Properties.Resources.home__4_;
            btnInicio.ImageAlign = ContentAlignment.MiddleLeft;
            btnInicio.Location = new Point(48, 217);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(167, 51);
            btnInicio.TabIndex = 3;
            btnInicio.Text = "Inicio";
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(213, 0);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(919, 772);
            panelContenedor.TabIndex = 4;
            // 
            // BienvenidaAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1132, 772);
            Controls.Add(panelContenedor);
            Controls.Add(sidebarMenu);
            Name = "BienvenidaAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Load += BienvenidaAdmin_Load;
            sidebarMenu.ResumeLayout(false);
            sidebarMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel sidebarMenu;
        private PictureBox pictureBox2;
        private Button btnInicio;
        public Label lblNombreSideBar;
        private Button btnMenu;
        private Button btnPOS;
        private Button btnStaff;
        private Button btnPeticiones;
        private Label lblCerrarSession;
        private PictureBox pictureBox3;
        private Button btnAjustesCuenta;
        private Panel panelContenedor;
    }
}
namespace zompyDogs
{
    partial class EmpleadoBienvenida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpleadoBienvenida));
            sidebarMenu = new Panel();
            btnInicio = new Button();
            lblCerrarSession = new Label();
            lblNombreSideBar = new Label();
            btnMenu = new Button();
            btnPOS = new Button();
            pictureBox2 = new PictureBox();
            panelContenedor = new Panel();
            sidebarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // sidebarMenu
            // 
            sidebarMenu.BackColor = Color.FromArgb(31, 19, 10);
            sidebarMenu.Controls.Add(btnInicio);
            sidebarMenu.Controls.Add(lblCerrarSession);
            sidebarMenu.Controls.Add(lblNombreSideBar);
            sidebarMenu.Controls.Add(btnMenu);
            sidebarMenu.Controls.Add(btnPOS);
            sidebarMenu.Controls.Add(pictureBox2);
            sidebarMenu.Dock = DockStyle.Left;
            sidebarMenu.Location = new Point(0, 0);
            sidebarMenu.Name = "sidebarMenu";
            sidebarMenu.Size = new Size(213, 736);
            sidebarMenu.TabIndex = 3;
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.Transparent;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.ForeColor = SystemColors.Control;
            btnInicio.Image = Properties.Resources.home__4_;
            btnInicio.ImageAlign = ContentAlignment.MiddleLeft;
            btnInicio.Location = new Point(35, 228);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(178, 51);
            btnInicio.TabIndex = 19;
            btnInicio.Text = "Inicio";
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;
            // 
            // lblCerrarSession
            // 
            lblCerrarSession.AutoSize = true;
            lblCerrarSession.Cursor = Cursors.Hand;
            lblCerrarSession.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCerrarSession.ForeColor = SystemColors.ButtonFace;
            lblCerrarSession.Location = new Point(12, 685);
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
            lblNombreSideBar.Location = new Point(11, 664);
            lblNombreSideBar.Name = "lblNombreSideBar";
            lblNombreSideBar.Size = new Size(116, 23);
            lblNombreSideBar.TabIndex = 9;
            lblNombreSideBar.Text = "Juan Sánchez";
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.Transparent;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.ForeColor = SystemColors.ButtonFace;
            btnMenu.Image = (Image)resources.GetObject("btnMenu.Image");
            btnMenu.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenu.Location = new Point(35, 342);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(178, 51);
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
            btnPOS.Image = (Image)resources.GetObject("btnPOS.Image");
            btnPOS.ImageAlign = ContentAlignment.MiddleLeft;
            btnPOS.Location = new Point(35, 285);
            btnPOS.Name = "btnPOS";
            btnPOS.Size = new Size(178, 51);
            btnPOS.TabIndex = 11;
            btnPOS.Text = "      PUNTO DE VENTA";
            btnPOS.TextAlign = ContentAlignment.MiddleRight;
            btnPOS.UseVisualStyleBackColor = false;
            btnPOS.Click += btnPOS_Click;
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
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(213, 0);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(898, 736);
            panelContenedor.TabIndex = 12;
            // 
            // EmpleadoBienvenida
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1111, 736);
            Controls.Add(panelContenedor);
            Controls.Add(sidebarMenu);
            Name = "EmpleadoBienvenida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmpleadoBienvenida";
            sidebarMenu.ResumeLayout(false);
            sidebarMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel sidebarMenu;
        private Label lblCerrarSession;
        public Label lblNombreSideBar;
        private Button btnMenu;
        private Button btnPOS;
        private PictureBox pictureBox2;
        private Panel panelContenedor;
        private Button btnInicio;
    }
}
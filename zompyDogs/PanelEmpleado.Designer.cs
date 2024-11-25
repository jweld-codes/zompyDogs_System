namespace zompyDogs
{
    partial class PanelEmpleado
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
            panel2 = new Panel();
            lblNombreUser = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            dtgHistorialPedidos = new DataGridView();
            lblHistorial = new Label();
            topBarMenu = new Panel();
            pictureBox2 = new PictureBox();
            lblTITULO = new Label();
            panel6 = new Panel();
            lblTotalPedidas = new Label();
            label6 = new Label();
            panel1 = new Panel();
            lblTotalPedidosSem = new Label();
            label3 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgHistorialPedidos).BeginInit();
            topBarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel6.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(lblNombreUser);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(36, 89);
            panel2.Name = "panel2";
            panel2.Size = new Size(622, 208);
            panel2.TabIndex = 31;
            // 
            // lblNombreUser
            // 
            lblNombreUser.AutoSize = true;
            lblNombreUser.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreUser.Location = new Point(180, 74);
            lblNombreUser.Name = "lblNombreUser";
            lblNombreUser.Size = new Size(47, 46);
            lblNombreUser.TabIndex = 5;
            lblNombreUser.Text = "...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(179, 32);
            label1.Name = "label1";
            label1.Size = new Size(284, 38);
            label1.TabIndex = 4;
            label1.Text = "Bienvenido Empleado";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.team;
            pictureBox1.Location = new Point(25, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(136, 114);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // dtgHistorialPedidos
            // 
            dtgHistorialPedidos.AllowUserToAddRows = false;
            dtgHistorialPedidos.AllowUserToDeleteRows = false;
            dtgHistorialPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgHistorialPedidos.BackgroundColor = Color.FromArgb(239, 239, 239);
            dtgHistorialPedidos.BorderStyle = BorderStyle.Fixed3D;
            dtgHistorialPedidos.ColumnHeadersHeight = 42;
            dtgHistorialPedidos.Location = new Point(33, 491);
            dtgHistorialPedidos.Name = "dtgHistorialPedidos";
            dtgHistorialPedidos.RowHeadersWidth = 51;
            dtgHistorialPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgHistorialPedidos.Size = new Size(625, 224);
            dtgHistorialPedidos.TabIndex = 33;
            // 
            // lblHistorial
            // 
            lblHistorial.AutoSize = true;
            lblHistorial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHistorial.Location = new Point(36, 469);
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Size = new Size(64, 20);
            lblHistorial.TabIndex = 34;
            lblHistorial.Text = "Pedidos";
            // 
            // topBarMenu
            // 
            topBarMenu.BackColor = Color.FromArgb(31, 19, 10);
            topBarMenu.Controls.Add(pictureBox2);
            topBarMenu.Controls.Add(lblTITULO);
            topBarMenu.Dock = DockStyle.Top;
            topBarMenu.Location = new Point(0, 0);
            topBarMenu.Name = "topBarMenu";
            topBarMenu.Size = new Size(901, 81);
            topBarMenu.TabIndex = 117;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.home__4_;
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
            lblTITULO.Size = new Size(84, 31);
            lblTITULO.TabIndex = 3;
            lblTITULO.Text = "INICIO";
            lblTITULO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.Fixed3D;
            panel6.Controls.Add(lblTotalPedidas);
            panel6.Controls.Add(label6);
            panel6.Location = new Point(115, 327);
            panel6.Name = "panel6";
            panel6.Size = new Size(188, 118);
            panel6.TabIndex = 118;
            // 
            // lblTotalPedidas
            // 
            lblTotalPedidas.AutoSize = true;
            lblTotalPedidas.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPedidas.Location = new Point(28, 42);
            lblTotalPedidas.Name = "lblTotalPedidas";
            lblTotalPedidas.Size = new Size(52, 41);
            lblTotalPedidas.TabIndex = 17;
            lblTotalPedidas.Text = "00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(28, 10);
            label6.Name = "label6";
            label6.Size = new Size(124, 20);
            label6.TabIndex = 16;
            label6.Text = "Total de Pedidos";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lblTotalPedidosSem);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(324, 327);
            panel1.Name = "panel1";
            panel1.Size = new Size(285, 118);
            panel1.TabIndex = 119;
            // 
            // lblTotalPedidosSem
            // 
            lblTotalPedidosSem.AutoSize = true;
            lblTotalPedidosSem.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPedidosSem.Location = new Point(28, 42);
            lblTotalPedidosSem.Name = "lblTotalPedidosSem";
            lblTotalPedidosSem.Size = new Size(52, 41);
            lblTotalPedidosSem.TabIndex = 17;
            lblTotalPedidosSem.Text = "00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(28, 10);
            label3.Name = "label3";
            label3.Size = new Size(239, 20);
            label3.TabIndex = 16;
            label3.Text = "Total de Pedidos De Esta Semana";
            // 
            // PanelEmpleado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(901, 725);
            Controls.Add(panel1);
            Controls.Add(panel6);
            Controls.Add(topBarMenu);
            Controls.Add(panel2);
            Controls.Add(dtgHistorialPedidos);
            Controls.Add(lblHistorial);
            ForeColor = Color.Black;
            Name = "PanelEmpleado";
            Text = "PanelEmpleado";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgHistorialPedidos).EndInit();
            topBarMenu.ResumeLayout(false);
            topBarMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel2;
        public Label lblNombreUser;
        private Label label1;
        private PictureBox pictureBox1;
        private DataGridView dtgHistorialPedidos;
        private Label lblHistorial;
        private Panel topBarMenu;
        private PictureBox pictureBox2;
        private Label lblTITULO;
        private Panel panel6;
        private Label lblTotalPedidas;
        private Label label6;
        private Panel panel1;
        private Label lblTotalPedidosSem;
        private Label label3;
    }
}
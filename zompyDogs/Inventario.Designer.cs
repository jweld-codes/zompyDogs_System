namespace zompyDogs
{
    partial class Inventario
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
            pictureBox2 = new PictureBox();
            btnUsuarioPanel = new Button();
            lblTITULO = new Label();
            lblBreadCrumbUser = new Label();
            groupBox1 = new GroupBox();
            dgvProductos = new DataGridView();
            dgvEmpleados = new DataGridView();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dgvAdminis = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            btnNext = new Button();
            btnAtras = new Button();
            dgvUsuarios = new DataGridView();
            colCedula = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btnAgregarNuevoUsuario = new Button();
            lblTituloRegistroPanel = new Label();
            pictureBox1 = new PictureBox();
            txtBuscarUsuario = new TextBox();
            btnVisualizarRegistro = new Button();
            topBarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdminis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.FlatAppearance.BorderSize = 0;
            btnEditarUsuario.Image = Properties.Resources.pen__1_;
            btnEditarUsuario.Location = new Point(192, 203);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(72, 72);
            btnEditarUsuario.TabIndex = 110;
            btnEditarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnEliminarUsuario
            // 
            btnEliminarUsuario.FlatAppearance.BorderSize = 0;
            btnEliminarUsuario.Image = Properties.Resources.bin;
            btnEliminarUsuario.Location = new Point(270, 203);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Size = new Size(72, 72);
            btnEliminarUsuario.TabIndex = 109;
            btnEliminarUsuario.UseVisualStyleBackColor = true;
            // 
            // topBarMenu
            // 
            topBarMenu.BackColor = Color.FromArgb(31, 19, 10);
            topBarMenu.Controls.Add(pictureBox2);
            topBarMenu.Controls.Add(btnUsuarioPanel);
            topBarMenu.Controls.Add(lblTITULO);
            topBarMenu.Dock = DockStyle.Top;
            topBarMenu.Location = new Point(0, 0);
            topBarMenu.Name = "topBarMenu";
            topBarMenu.Size = new Size(901, 81);
            topBarMenu.TabIndex = 106;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.diet1;
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
            btnUsuarioPanel.Location = new Point(547, 45);
            btnUsuarioPanel.Name = "btnUsuarioPanel";
            btnUsuarioPanel.Size = new Size(152, 36);
            btnUsuarioPanel.TabIndex = 98;
            btnUsuarioPanel.Text = "Productos";
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
            lblTITULO.Size = new Size(150, 31);
            lblTITULO.TabIndex = 3;
            lblTITULO.Text = "INVENTARIO";
            lblTITULO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBreadCrumbUser
            // 
            lblBreadCrumbUser.AutoSize = true;
            lblBreadCrumbUser.BackColor = Color.Transparent;
            lblBreadCrumbUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBreadCrumbUser.ForeColor = Color.LimeGreen;
            lblBreadCrumbUser.Location = new Point(144, 99);
            lblBreadCrumbUser.Name = "lblBreadCrumbUser";
            lblBreadCrumbUser.Size = new Size(97, 20);
            lblBreadCrumbUser.TabIndex = 108;
            lblBreadCrumbUser.Text = "PRODUCTOS";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvProductos);
            groupBox1.Controls.Add(dgvEmpleados);
            groupBox1.Controls.Add(dgvAdminis);
            groupBox1.Controls.Add(btnNext);
            groupBox1.Controls.Add(btnAtras);
            groupBox1.Controls.Add(dgvUsuarios);
            groupBox1.Location = new Point(21, 299);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(837, 405);
            groupBox1.TabIndex = 103;
            groupBox1.TabStop = false;
            groupBox1.Text = "INVENTARIO";
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToOrderColumns = true;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.BackgroundColor = SystemColors.Window;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(15, 26);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.Size = new Size(800, 338);
            dgvProductos.TabIndex = 74;
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
            // btnNext
            // 
            btnNext.Image = Properties.Resources.arrow;
            btnNext.Location = new Point(51, 370);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(36, 29);
            btnNext.TabIndex = 71;
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnAtras
            // 
            btnAtras.Image = Properties.Resources.left_arrow;
            btnAtras.Location = new Point(15, 370);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(36, 29);
            btnAtras.TabIndex = 70;
            btnAtras.UseVisualStyleBackColor = true;
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
            label1.Location = new Point(46, 98);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 107;
            label1.Text = "INVENTARIO /";
            // 
            // btnAgregarNuevoUsuario
            // 
            btnAgregarNuevoUsuario.FlatAppearance.BorderSize = 0;
            btnAgregarNuevoUsuario.Image = Properties.Resources.plus;
            btnAgregarNuevoUsuario.Location = new Point(36, 204);
            btnAgregarNuevoUsuario.Name = "btnAgregarNuevoUsuario";
            btnAgregarNuevoUsuario.Size = new Size(72, 72);
            btnAgregarNuevoUsuario.TabIndex = 104;
            btnAgregarNuevoUsuario.UseVisualStyleBackColor = true;
            // 
            // lblTituloRegistroPanel
            // 
            lblTituloRegistroPanel.AutoSize = true;
            lblTituloRegistroPanel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloRegistroPanel.Location = new Point(36, 156);
            lblTituloRegistroPanel.Name = "lblTituloRegistroPanel";
            lblTituloRegistroPanel.Size = new Size(342, 41);
            lblTituloRegistroPanel.TabIndex = 105;
            lblTituloRegistroPanel.Text = "Registros de Productos";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.lupa;
            pictureBox1.Location = new Point(343, 100);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(41, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 102;
            pictureBox1.TabStop = false;
            // 
            // txtBuscarUsuario
            // 
            txtBuscarUsuario.Location = new Point(383, 100);
            txtBuscarUsuario.Multiline = true;
            txtBuscarUsuario.Name = "txtBuscarUsuario";
            txtBuscarUsuario.PlaceholderText = "Buscar Producto";
            txtBuscarUsuario.Size = new Size(479, 27);
            txtBuscarUsuario.TabIndex = 101;
            // 
            // btnVisualizarRegistro
            // 
            btnVisualizarRegistro.Image = Properties.Resources.file__1_;
            btnVisualizarRegistro.Location = new Point(114, 203);
            btnVisualizarRegistro.Name = "btnVisualizarRegistro";
            btnVisualizarRegistro.Size = new Size(72, 72);
            btnVisualizarRegistro.TabIndex = 115;
            btnVisualizarRegistro.UseVisualStyleBackColor = true;
            // 
            // Inventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(901, 725);
            Controls.Add(btnVisualizarRegistro);
            Controls.Add(btnEditarUsuario);
            Controls.Add(btnEliminarUsuario);
            Controls.Add(topBarMenu);
            Controls.Add(lblBreadCrumbUser);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(btnAgregarNuevoUsuario);
            Controls.Add(lblTituloRegistroPanel);
            Controls.Add(pictureBox1);
            Controls.Add(txtBuscarUsuario);
            Name = "Inventario";
            Text = "Inventario";
            topBarMenu.ResumeLayout(false);
            topBarMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdminis).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEditarUsuario;
        private Button btnEliminarUsuario;
        private Panel topBarMenu;
        private PictureBox pictureBox2;
        private Button btnUsuarioPanel;
        private Label lblTITULO;
        private Label lblBreadCrumbUser;
        private GroupBox groupBox1;
        private DataGridView dgvProductos;
        private DataGridView dgvEmpleados;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridView dgvAdminis;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Button btnNext;
        private Button btnAtras;
        private DataGridView dgvUsuarios;
        private DataGridViewTextBoxColumn colCedula;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn Column1;
        private Label label1;
        private Button btnAgregarNuevoUsuario;
        private Label lblTituloRegistroPanel;
        private PictureBox pictureBox1;
        private TextBox txtBuscarUsuario;
        private Button btnVisualizarRegistro;
    }
}
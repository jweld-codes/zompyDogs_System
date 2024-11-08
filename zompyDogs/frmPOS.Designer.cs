namespace zompyDogs
{
    partial class frmPOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOS));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            topBarMenu = new Panel();
            btnHistorial = new Button();
            pictureBox2 = new PictureBox();
            btnPuntoVenta = new Button();
            lblTITULO = new Label();
            panel1 = new Panel();
            label6 = new Label();
            lblSubtotal = new Label();
            btnCancelar = new Button();
            label13 = new Label();
            txtCodigoGenerado = new TextBox();
            label12 = new Label();
            groupBox1 = new GroupBox();
            label15 = new Label();
            btnEliminarOrden = new Button();
            txtPlatilloOrden = new TextBox();
            dgvPedido = new DataGridView();
            btnConfirmarPedido = new Button();
            panel = new Panel();
            categoryPanel = new Panel();
            panel6 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            lblTotalAPagar = new Label();
            label4 = new Label();
            label5 = new Label();
            panelContenedrPOS = new Panel();
            flpPOSPanel = new FlowLayoutPanel();
            bnSrcPedidos = new BindingSource(components);
            topBarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedido).BeginInit();
            panel.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            panelContenedrPOS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bnSrcPedidos).BeginInit();
            SuspendLayout();
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
            topBarMenu.Name = "topBarMenu";
            topBarMenu.Size = new Size(901, 81);
            topBarMenu.TabIndex = 106;
            // 
            // btnHistorial
            // 
            btnHistorial.BackColor = Color.Transparent;
            btnHistorial.FlatAppearance.BorderSize = 0;
            btnHistorial.FlatStyle = FlatStyle.Flat;
            btnHistorial.ForeColor = SystemColors.ButtonHighlight;
            btnHistorial.Location = new Point(718, 45);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(152, 36);
            btnHistorial.TabIndex = 99;
            btnHistorial.Text = "HISTORIAL";
            btnHistorial.UseVisualStyleBackColor = false;
            btnHistorial.Click += btnHistorial_Click;
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
            // btnPuntoVenta
            // 
            btnPuntoVenta.BackColor = Color.White;
            btnPuntoVenta.FlatAppearance.BorderSize = 0;
            btnPuntoVenta.FlatStyle = FlatStyle.Flat;
            btnPuntoVenta.ForeColor = SystemColors.ActiveCaptionText;
            btnPuntoVenta.Location = new Point(558, 45);
            btnPuntoVenta.Name = "btnPuntoVenta";
            btnPuntoVenta.Size = new Size(152, 36);
            btnPuntoVenta.TabIndex = 98;
            btnPuntoVenta.Text = "PUNTO DE VENTA";
            btnPuntoVenta.UseVisualStyleBackColor = false;
            // 
            // lblTITULO
            // 
            lblTITULO.AutoSize = true;
            lblTITULO.BackColor = Color.Transparent;
            lblTITULO.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTITULO.ForeColor = Color.Transparent;
            lblTITULO.Location = new Point(109, 34);
            lblTITULO.Name = "lblTITULO";
            lblTITULO.Size = new Size(205, 31);
            lblTITULO.TabIndex = 3;
            lblTITULO.Text = "PUNTO DE VENTA";
            lblTITULO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(lblSubtotal);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(txtCodigoGenerado);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(dgvPedido);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(579, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(322, 644);
            panel1.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 502);
            label6.Name = "label6";
            label6.Size = new Size(57, 17);
            label6.TabIndex = 98;
            label6.Text = "ISV 15%";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtotal.Location = new Point(115, 474);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(57, 25);
            lblSubtotal.TabIndex = 4;
            lblSubtotal.Text = "00.00";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.DarkRed;
            btnCancelar.ForeColor = SystemColors.Control;
            btnCancelar.Location = new Point(138, 589);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(179, 47);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "CANCELAR PEDIDO";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(94, 474);
            label13.Name = "label13";
            label13.Size = new Size(26, 25);
            label13.TabIndex = 3;
            label13.Text = "L.";
            // 
            // txtCodigoGenerado
            // 
            txtCodigoGenerado.BorderStyle = BorderStyle.FixedSingle;
            txtCodigoGenerado.Enabled = false;
            txtCodigoGenerado.Location = new Point(83, 22);
            txtCodigoGenerado.Name = "txtCodigoGenerado";
            txtCodigoGenerado.ReadOnly = true;
            txtCodigoGenerado.Size = new Size(223, 27);
            txtCodigoGenerado.TabIndex = 97;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(9, 479);
            label12.Name = "label12";
            label12.Size = new Size(79, 20);
            label12.TabIndex = 2;
            label12.Text = "SUBTOTAL:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(btnEliminarOrden);
            groupBox1.Controls.Add(txtPlatilloOrden);
            groupBox1.Location = new Point(5, 348);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(304, 115);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Editar Orden";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(24, 30);
            label15.Name = "label15";
            label15.Size = new Size(55, 20);
            label15.TabIndex = 1;
            label15.Text = "Platillo";
            // 
            // btnEliminarOrden
            // 
            btnEliminarOrden.FlatAppearance.BorderSize = 0;
            btnEliminarOrden.Image = Properties.Resources.delete2;
            btnEliminarOrden.Location = new Point(16, 51);
            btnEliminarOrden.Name = "btnEliminarOrden";
            btnEliminarOrden.Size = new Size(26, 29);
            btnEliminarOrden.TabIndex = 6;
            btnEliminarOrden.UseVisualStyleBackColor = true;
            btnEliminarOrden.Click += btnEliminarOrden_Click;
            // 
            // txtPlatilloOrden
            // 
            txtPlatilloOrden.BorderStyle = BorderStyle.FixedSingle;
            txtPlatilloOrden.Location = new Point(48, 53);
            txtPlatilloOrden.Name = "txtPlatilloOrden";
            txtPlatilloOrden.Size = new Size(250, 27);
            txtPlatilloOrden.TabIndex = 2;
            // 
            // dgvPedido
            // 
            dgvPedido.AllowUserToAddRows = false;
            dgvPedido.AllowUserToOrderColumns = true;
            dgvPedido.AllowUserToResizeColumns = false;
            dgvPedido.AllowUserToResizeRows = false;
            dgvPedido.BackgroundColor = SystemColors.Control;
            dgvPedido.BorderStyle = BorderStyle.None;
            dgvPedido.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            dgvPedido.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedido.GridColor = SystemColors.ScrollBar;
            dgvPedido.Location = new Point(5, 58);
            dgvPedido.Name = "dgvPedido";
            dgvPedido.RowHeadersVisible = false;
            dgvPedido.RowHeadersWidth = 51;
            dgvPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedido.Size = new Size(304, 284);
            dgvPedido.TabIndex = 0;
            dgvPedido.CellClick += dgvPedido_CellClick;
            // 
            // btnConfirmarPedido
            // 
            btnConfirmarPedido.BackColor = SystemColors.Highlight;
            btnConfirmarPedido.ForeColor = SystemColors.Control;
            btnConfirmarPedido.Location = new Point(237, 8);
            btnConfirmarPedido.Name = "btnConfirmarPedido";
            btnConfirmarPedido.Size = new Size(179, 47);
            btnConfirmarPedido.TabIndex = 1;
            btnConfirmarPedido.Text = "CONFIRMAR PEDIDO";
            btnConfirmarPedido.UseVisualStyleBackColor = false;
            btnConfirmarPedido.Click += btnConfirmarPedido_Click;
            // 
            // panel
            // 
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(categoryPanel);
            panel.Controls.Add(panel6);
            panel.Dock = DockStyle.Left;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(153, 644);
            panel.TabIndex = 2;
            // 
            // categoryPanel
            // 
            categoryPanel.Dock = DockStyle.Fill;
            categoryPanel.Location = new Point(0, 58);
            categoryPanel.Name = "categoryPanel";
            categoryPanel.Size = new Size(151, 584);
            categoryPanel.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.Controls.Add(label2);
            panel6.Controls.Add(label1);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(151, 58);
            panel6.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 15);
            label2.Name = "label2";
            label2.Size = new Size(133, 28);
            label2.TabIndex = 1;
            label2.Text = "CATEGORIAS";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 17);
            label1.Name = "label1";
            label1.Size = new Size(133, 28);
            label1.TabIndex = 0;
            label1.Text = "CATEGORIAS";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblTotalAPagar);
            panel3.Controls.Add(btnConfirmarPedido);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label5);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(153, 581);
            panel3.Name = "panel3";
            panel3.Size = new Size(426, 63);
            panel3.TabIndex = 3;
            // 
            // lblTotalAPagar
            // 
            lblTotalAPagar.AutoSize = true;
            lblTotalAPagar.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAPagar.Location = new Point(97, 17);
            lblTotalAPagar.Name = "lblTotalAPagar";
            lblTotalAPagar.Size = new Size(57, 25);
            lblTotalAPagar.TabIndex = 100;
            lblTotalAPagar.Text = "00.00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(76, 17);
            label4.Name = "label4";
            label4.Size = new Size(26, 25);
            label4.TabIndex = 99;
            label4.Text = "L.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 21);
            label5.Name = "label5";
            label5.Size = new Size(53, 20);
            label5.TabIndex = 98;
            label5.Text = "TOTAL:";
            // 
            // panelContenedrPOS
            // 
            panelContenedrPOS.Controls.Add(flpPOSPanel);
            panelContenedrPOS.Controls.Add(panel3);
            panelContenedrPOS.Controls.Add(panel1);
            panelContenedrPOS.Controls.Add(panel);
            panelContenedrPOS.Dock = DockStyle.Right;
            panelContenedrPOS.Location = new Point(0, 81);
            panelContenedrPOS.Name = "panelContenedrPOS";
            panelContenedrPOS.Size = new Size(901, 644);
            panelContenedrPOS.TabIndex = 109;
            // 
            // flpPOSPanel
            // 
            flpPOSPanel.Dock = DockStyle.Left;
            flpPOSPanel.Location = new Point(153, 0);
            flpPOSPanel.Name = "flpPOSPanel";
            flpPOSPanel.Size = new Size(426, 581);
            flpPOSPanel.TabIndex = 4;
            // 
            // frmPOS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(901, 725);
            Controls.Add(panelContenedrPOS);
            Controls.Add(topBarMenu);
            Name = "frmPOS";
            topBarMenu.ResumeLayout(false);
            topBarMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedido).EndInit();
            panel.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panelContenedrPOS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bnSrcPedidos).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel topBarMenu;
        private PictureBox pictureBox2;
        public Button btnPuntoVenta;
        private Label lblTITULO;
        private Panel panel1;
        private Button btnConfirmarPedido;
        private Panel panel;
        private Label label1;
        private Panel panel3;
        private Panel panelContenedrPOS;
        private FlowLayoutPanel flpPOSPanel;
        private Label lblSubtotal;
        private Label label13;
        private Label label12;
        private TextBox txtPlatilloOrden;
        private Label label15;
        private Button btnEliminarOrden;
        private GroupBox groupBox1;
        private Panel categoryPanel;
        private Panel panel6;
        private BindingSource bnSrcPedidos;
        public TextBox txtCodigoGenerado;
        private Button btnCancelar;
        private Label label2;
        public Button btnHistorial;
        public DataGridView dgvPedido;
        private Label label6;
        private Label lblTotalAPagar;
        private Label label4;
        private Label label5;
    }
}
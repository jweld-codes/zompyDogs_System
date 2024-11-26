namespace zompyDogs.CRUD.REPORTES
{
    partial class ImprimirFactura_Pedidos
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImprimirFactura_Pedidos));
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            btnAceptar = new Button();
            label2 = new Label();
            label6 = new Label();
            panel1 = new Panel();
            lblNumFac = new Label();
            lblFechaPedido = new Label();
            lblEmpleadoNombre = new Label();
            label12 = new Label();
            label10 = new Label();
            label8 = new Label();
            lblCodigoEmpleado = new Label();
            panel5 = new Panel();
            btnImprimir = new Button();
            label7 = new Label();
            panel2 = new Panel();
            dgvPlatillos = new DataGridView();
            panel3 = new Panel();
            label13 = new Label();
            lblSubtotal = new Label();
            label4 = new Label();
            label3 = new Label();
            label11 = new Label();
            lblISV = new Label();
            label5 = new Label();
            lblTotal = new Label();
            printPreviewFactura = new PrintPreviewDialog();
            printFactura = new System.Drawing.Printing.PrintDocument();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlatillos).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(btnAceptar);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(label6);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(490, 125);
            panel4.TabIndex = 132;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Enabled = false;
            pictureBox1.Image = Properties.Resources._588ae854_f3a0_4ffc_8412_725243b013fb_removebg_preview;
            pictureBox1.Location = new Point(32, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(104, 102);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 126;
            pictureBox1.TabStop = false;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.Transparent;
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.ForeColor = Color.Black;
            btnAceptar.Image = Properties.Resources.multiply;
            btnAceptar.Location = new Point(441, 3);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(38, 38);
            btnAceptar.TabIndex = 0;
            btnAceptar.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(158, 37);
            label2.Name = "label2";
            label2.Size = new Size(215, 41);
            label2.TabIndex = 127;
            label2.Text = "ZOMPY DOGS";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(204, 78);
            label6.Name = "label6";
            label6.Size = new Size(127, 20);
            label6.TabIndex = 127;
            label6.Text = "Factura de Pedido";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblNumFac);
            panel1.Controls.Add(lblFechaPedido);
            panel1.Controls.Add(lblEmpleadoNombre);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(lblCodigoEmpleado);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 125);
            panel1.Name = "panel1";
            panel1.Size = new Size(490, 162);
            panel1.TabIndex = 133;
            // 
            // lblNumFac
            // 
            lblNumFac.AutoSize = true;
            lblNumFac.Location = new Point(137, 17);
            lblNumFac.Name = "lblNumFac";
            lblNumFac.Size = new Size(25, 20);
            lblNumFac.TabIndex = 132;
            lblNumFac.Text = "00";
            // 
            // lblFechaPedido
            // 
            lblFechaPedido.AutoSize = true;
            lblFechaPedido.Location = new Point(137, 62);
            lblFechaPedido.Name = "lblFechaPedido";
            lblFechaPedido.Size = new Size(25, 20);
            lblFechaPedido.TabIndex = 131;
            lblFechaPedido.Text = "00";
            // 
            // lblEmpleadoNombre
            // 
            lblEmpleadoNombre.AutoSize = true;
            lblEmpleadoNombre.Location = new Point(137, 103);
            lblEmpleadoNombre.Name = "lblEmpleadoNombre";
            lblEmpleadoNombre.Size = new Size(25, 20);
            lblEmpleadoNombre.TabIndex = 130;
            lblEmpleadoNombre.Text = "00";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.Location = new Point(22, 103);
            label12.Name = "label12";
            label12.Size = new Size(89, 20);
            label12.TabIndex = 129;
            label12.Text = "EMPLEADO";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.Location = new Point(23, 17);
            label10.Name = "label10";
            label10.Size = new Size(110, 20);
            label10.TabIndex = 128;
            label10.Text = "NO° FACTURA";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(22, 62);
            label8.Name = "label8";
            label8.Size = new Size(56, 20);
            label8.TabIndex = 127;
            label8.Text = "FECHA";
            // 
            // lblCodigoEmpleado
            // 
            lblCodigoEmpleado.AutoSize = true;
            lblCodigoEmpleado.Location = new Point(137, 133);
            lblCodigoEmpleado.Name = "lblCodigoEmpleado";
            lblCodigoEmpleado.Size = new Size(25, 20);
            lblCodigoEmpleado.TabIndex = 116;
            lblCodigoEmpleado.Text = "00";
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(btnImprimir);
            panel5.Controls.Add(label7);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 622);
            panel5.Name = "panel5";
            panel5.Size = new Size(490, 56);
            panel5.TabIndex = 134;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.Yellow;
            btnImprimir.ForeColor = Color.Black;
            btnImprimir.Image = Properties.Resources.printer1;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(342, 8);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(137, 38);
            btnImprimir.TabIndex = 128;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(38, 13);
            label7.Name = "label7";
            label7.Size = new Size(218, 25);
            label7.TabIndex = 127;
            label7.Text = "¡Gracias Por Preferirnos!";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(dgvPlatillos);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 287);
            panel2.Name = "panel2";
            panel2.Size = new Size(490, 335);
            panel2.TabIndex = 135;
            // 
            // dgvPlatillos
            // 
            dgvPlatillos.AllowUserToAddRows = false;
            dgvPlatillos.AllowUserToDeleteRows = false;
            dgvPlatillos.AllowUserToResizeColumns = false;
            dgvPlatillos.AllowUserToResizeRows = false;
            dgvPlatillos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlatillos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPlatillos.BackgroundColor = Color.Snow;
            dgvPlatillos.BorderStyle = BorderStyle.None;
            dgvPlatillos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPlatillos.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dgvPlatillos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPlatillos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPlatillos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlatillos.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvPlatillos.Enabled = false;
            dgvPlatillos.EnableHeadersVisualStyles = false;
            dgvPlatillos.GridColor = SystemColors.MenuBar;
            dgvPlatillos.ImeMode = ImeMode.NoControl;
            dgvPlatillos.Location = new Point(-3, -1);
            dgvPlatillos.MultiSelect = false;
            dgvPlatillos.Name = "dgvPlatillos";
            dgvPlatillos.ReadOnly = true;
            dgvPlatillos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dgvPlatillos.RowHeadersVisible = false;
            dgvPlatillos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvPlatillos.ScrollBars = ScrollBars.None;
            dgvPlatillos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlatillos.ShowCellErrors = false;
            dgvPlatillos.ShowCellToolTips = false;
            dgvPlatillos.ShowEditingIcon = false;
            dgvPlatillos.ShowRowErrors = false;
            dgvPlatillos.Size = new Size(492, 211);
            dgvPlatillos.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label13);
            panel3.Controls.Add(lblSubtotal);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(lblISV);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(lblTotal);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 504);
            panel3.Name = "panel3";
            panel3.Size = new Size(490, 118);
            panel3.TabIndex = 131;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(38, 23);
            label13.Name = "label13";
            label13.Size = new Size(67, 25);
            label13.TabIndex = 121;
            label13.Text = "TOTAL";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblSubtotal.Location = new Point(416, 55);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(45, 19);
            lblSubtotal.TabIndex = 118;
            lblSubtotal.Text = "00.00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 77);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 117;
            label4.Text = "ISV (15%):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label3.Location = new Point(395, 78);
            label3.Name = "label3";
            label3.Size = new Size(20, 19);
            label3.TabIndex = 125;
            label3.Text = "L.";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(37, 53);
            label11.Name = "label11";
            label11.Size = new Size(68, 20);
            label11.TabIndex = 119;
            label11.Text = "Subtotal:";
            // 
            // lblISV
            // 
            lblISV.AutoSize = true;
            lblISV.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblISV.Location = new Point(416, 78);
            lblISV.Name = "lblISV";
            lblISV.Size = new Size(45, 19);
            lblISV.TabIndex = 120;
            lblISV.Text = "00.00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label5.Location = new Point(395, 55);
            label5.Name = "label5";
            label5.Size = new Size(20, 19);
            label5.TabIndex = 124;
            label5.Text = "L.";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(410, 20);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(65, 28);
            lblTotal.TabIndex = 122;
            lblTotal.Text = "00.00";
            // 
            // printPreviewFactura
            // 
            printPreviewFactura.AutoScrollMargin = new Size(0, 0);
            printPreviewFactura.AutoScrollMinSize = new Size(0, 0);
            printPreviewFactura.ClientSize = new Size(400, 300);
            printPreviewFactura.Enabled = true;
            printPreviewFactura.Icon = (Icon)resources.GetObject("printPreviewFactura.Icon");
            printPreviewFactura.Name = "printPreviewFactura";
            printPreviewFactura.Visible = false;
            // 
            // printFactura
            // 
            printFactura.DocumentName = "printFactura";
            printFactura.EndPrint += printFactura_EndPrint;
            printFactura.PrintPage += printFactura_PrintPage;
            // 
            // ImprimirFactura_Pedidos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(490, 678);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel5);
            Controls.Add(panel1);
            Controls.Add(panel4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ImprimirFactura_Pedidos";
            StartPosition = FormStartPosition.CenterScreen;
            Load += ImprimirFactura_Pedidos_Load;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPlatillos).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private PictureBox pictureBox1;
        public Button btnAceptar;
        private Label label2;
        private Label label6;
        private Panel panel1;
        public Label lblNumFac;
        public Label lblFechaPedido;
        public Label lblEmpleadoNombre;
        private Label label12;
        private Label label10;
        private Label label8;
        public Label lblCodigoEmpleado;
        private Panel panel5;
        private Button btnImprimir;
        private Label label7;
        private Panel panel2;
        public DataGridView dgvPlatillos;
        private Panel panel3;
        private Label label13;
        public Label lblSubtotal;
        private Label label4;
        public Label label3;
        private Label label11;
        public Label lblISV;
        public Label label5;
        public Label lblTotal;
        private PrintPreviewDialog printPreviewFactura;
        private System.Drawing.Printing.PrintDocument printFactura;
    }
}
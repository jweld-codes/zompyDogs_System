namespace zompyDogs.CRUD.REPORTES
{
    partial class ReporteVentas
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
            groupBox1 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            dgvHistorialPedidos = new DataGridView();
            groupBox5 = new GroupBox();
            groupBox6 = new GroupBox();
            button1 = new Button();
            groupBox8 = new GroupBox();
            groupBox7 = new GroupBox();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialPedidos).BeginInit();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(201, 115);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Diarios";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(6, 26);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(213, 431);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(14, 158);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(201, 141);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Mensual";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(14, 305);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(201, 141);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Anual";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button1);
            groupBox4.Controls.Add(dgvHistorialPedidos);
            groupBox4.Location = new Point(243, 274);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(304, 211);
            groupBox4.TabIndex = 122;
            groupBox4.TabStop = false;
            groupBox4.Text = "Historial de Ventas";
            // 
            // dgvHistorialPedidos
            // 
            dgvHistorialPedidos.AllowUserToAddRows = false;
            dgvHistorialPedidos.AllowUserToDeleteRows = false;
            dgvHistorialPedidos.AllowUserToOrderColumns = true;
            dgvHistorialPedidos.AllowUserToResizeColumns = false;
            dgvHistorialPedidos.AllowUserToResizeRows = false;
            dgvHistorialPedidos.BackgroundColor = SystemColors.Window;
            dgvHistorialPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorialPedidos.Location = new Point(6, 26);
            dgvHistorialPedidos.Name = "dgvHistorialPedidos";
            dgvHistorialPedidos.ReadOnly = true;
            dgvHistorialPedidos.RowHeadersWidth = 51;
            dgvHistorialPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialPedidos.Size = new Size(292, 143);
            dgvHistorialPedidos.TabIndex = 72;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(flowLayoutPanel1);
            groupBox5.Location = new Point(553, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(225, 473);
            groupBox5.TabIndex = 123;
            groupBox5.TabStop = false;
            groupBox5.Text = "Platillos más vendidos";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label5);
            groupBox6.Controls.Add(label4);
            groupBox6.Location = new Point(243, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(304, 125);
            groupBox6.TabIndex = 124;
            groupBox6.TabStop = false;
            groupBox6.Text = "Empleado con mayor número de ventas";
            // 
            // button1
            // 
            button1.Location = new Point(6, 175);
            button1.Name = "button1";
            button1.Size = new Size(115, 29);
            button1.TabIndex = 73;
            button1.Text = "Ver Historial";
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(groupBox1);
            groupBox8.Controls.Add(groupBox2);
            groupBox8.Controls.Add(groupBox3);
            groupBox8.Location = new Point(12, 12);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(225, 473);
            groupBox8.TabIndex = 126;
            groupBox8.TabStop = false;
            groupBox8.Text = "Total de Ventas";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(label6);
            groupBox7.Controls.Add(button2);
            groupBox7.Location = new Point(243, 143);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(304, 125);
            groupBox7.TabIndex = 125;
            groupBox7.TabStop = false;
            groupBox7.Text = "Ganacia Total";
            // 
            // button2
            // 
            button2.Location = new Point(183, 90);
            button2.Name = "button2";
            button2.Size = new Size(115, 29);
            button2.TabIndex = 74;
            button2.Text = "Ver Ganancias";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 49);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 67);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 0;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 63);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 0;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 37);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 0;
            label4.Text = "label4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 76);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 1;
            label5.Text = "label5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 51);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 75;
            label6.Text = "label6";
            // 
            // ReporteVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(790, 501);
            Controls.Add(groupBox7);
            Controls.Add(groupBox8);
            Controls.Add(groupBox5);
            Controls.Add(groupBox6);
            Controls.Add(groupBox4);
            Name = "ReporteVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Load += ReporteVentas_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorialPedidos).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        public DataGridView dgvHistorialPedidos;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private Button button1;
        private GroupBox groupBox8;
        private GroupBox groupBox7;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label label6;
    }
}
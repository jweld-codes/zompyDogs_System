namespace zompyDogs
{
    partial class PanelReportes
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
            label1 = new Label();
            repoVentas = new Button();
            repoGanacias = new Button();
            pictureBox3 = new PictureBox();
            label4 = new Label();
            pictureBox4 = new PictureBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(361, 55);
            label1.Name = "label1";
            label1.Size = new Size(165, 41);
            label1.TabIndex = 0;
            label1.Text = "REPORTES";
            // 
            // repoVentas
            // 
            repoVentas.Location = new Point(294, 390);
            repoVentas.Name = "repoVentas";
            repoVentas.Size = new Size(111, 29);
            repoVentas.TabIndex = 3;
            repoVentas.Text = "Ver Reporte";
            repoVentas.UseVisualStyleBackColor = true;
            repoVentas.Click += repoVentas_Click;
            // 
            // repoGanacias
            // 
            repoGanacias.Location = new Point(488, 390);
            repoGanacias.Name = "repoGanacias";
            repoGanacias.Size = new Size(105, 29);
            repoGanacias.TabIndex = 4;
            repoGanacias.Text = "Ver Reporte";
            repoGanacias.UseVisualStyleBackColor = true;
            repoGanacias.Click += repoGanacias_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.shopping_bag1;
            pictureBox3.Location = new Point(283, 281);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(125, 103);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(308, 247);
            label4.Name = "label4";
            label4.Size = new Size(82, 31);
            label4.TabIndex = 9;
            label4.Text = "Ventas";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.staff_training1;
            pictureBox4.Location = new Point(478, 281);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(125, 103);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 12;
            pictureBox4.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(484, 247);
            label5.Name = "label5";
            label5.Size = new Size(119, 31);
            label5.TabIndex = 11;
            label5.Text = "Ganancias";
            // 
            // PanelReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(901, 725);
            Controls.Add(pictureBox4);
            Controls.Add(label5);
            Controls.Add(pictureBox3);
            Controls.Add(label4);
            Controls.Add(repoGanacias);
            Controls.Add(repoVentas);
            Controls.Add(label1);
            Name = "PanelReportes";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button repoVentas;
        private Button repoGanacias;
        private PictureBox pictureBox3;
        private Label label4;
        private PictureBox pictureBox4;
        private Label label5;
    }
}
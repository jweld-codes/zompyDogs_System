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
            pictureBox3 = new PictureBox();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(368, 110);
            label1.Name = "label1";
            label1.Size = new Size(165, 41);
            label1.TabIndex = 0;
            label1.Text = "REPORTES";
            // 
            // repoVentas
            // 
            repoVentas.Location = new Point(307, 413);
            repoVentas.Name = "repoVentas";
            repoVentas.Size = new Size(111, 29);
            repoVentas.TabIndex = 3;
            repoVentas.Text = "Ver Reporte";
            repoVentas.UseVisualStyleBackColor = true;
            repoVentas.Click += repoVentas_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.shopping_bag1;
            pictureBox3.Location = new Point(296, 304);
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
            label4.Location = new Point(321, 270);
            label4.Name = "label4";
            label4.Size = new Size(82, 31);
            label4.TabIndex = 9;
            label4.Text = "Ventas";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.staff_training1;
            pictureBox1.Location = new Point(492, 304);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 103);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(502, 270);
            label2.Name = "label2";
            label2.Size = new Size(98, 31);
            label2.TabIndex = 14;
            label2.Text = "Facturas";
            // 
            // button1
            // 
            button1.Location = new Point(502, 413);
            button1.Name = "button1";
            button1.Size = new Size(105, 29);
            button1.TabIndex = 13;
            button1.Text = "Ver Reporte";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PanelReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(901, 725);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(pictureBox3);
            Controls.Add(label4);
            Controls.Add(repoVentas);
            Controls.Add(label1);
            Name = "PanelReportes";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button repoVentas;
        private PictureBox pictureBox3;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label2;
        private Button button1;
    }
}
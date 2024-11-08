namespace zompyDogs
{
    partial class ClaveOlvidada
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
            panel1 = new Panel();
            btnRegresar = new Button();
            pictureBox1 = new PictureBox();
            btnEnviarSolicitud = new Button();
            label2 = new Label();
            txtUserForget = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(31, 19, 10);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(btnRegresar);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnEnviarSolicitud);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtUserForget);
            panel1.Location = new Point(46, 46);
            panel1.Name = "panel1";
            panel1.Size = new Size(510, 338);
            panel1.TabIndex = 22;
            // 
            // btnRegresar
            // 
            btnRegresar.BackColor = Color.Transparent;
            btnRegresar.Cursor = Cursors.Hand;
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.ForeColor = SystemColors.ButtonHighlight;
            btnRegresar.Image = Properties.Resources.flecha_hacia_atras;
            btnRegresar.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegresar.Location = new Point(3, 3);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(131, 35);
            btnRegresar.TabIndex = 20;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = false;
            btnRegresar.Click += btnRegresar_Click;
            btnRegresar.MouseEnter += btnRegresar_MouseEnter;
            btnRegresar.MouseLeave += btnRegresar_MouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Enabled = false;
            pictureBox1.Image = Properties.Resources._588ae854_f3a0_4ffc_8412_725243b013fb_removebg_preview;
            pictureBox1.Location = new Point(158, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(184, 172);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // btnEnviarSolicitud
            // 
            btnEnviarSolicitud.Cursor = Cursors.Hand;
            btnEnviarSolicitud.Location = new Point(312, 243);
            btnEnviarSolicitud.Name = "btnEnviarSolicitud";
            btnEnviarSolicitud.Size = new Size(163, 34);
            btnEnviarSolicitud.TabIndex = 18;
            btnEnviarSolicitud.Text = "Enviar Solicitud";
            btnEnviarSolicitud.UseVisualStyleBackColor = true;
            btnEnviarSolicitud.Click += btnEnviarSolicitud_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Location = new Point(59, 218);
            label2.Name = "label2";
            label2.Size = new Size(204, 20);
            label2.TabIndex = 11;
            label2.Text = "Ingrese su nombre de usuario";
            // 
            // txtUserForget
            // 
            txtUserForget.Location = new Point(61, 243);
            txtUserForget.Multiline = true;
            txtUserForget.Name = "txtUserForget";
            txtUserForget.Size = new Size(245, 34);
            txtUserForget.TabIndex = 14;
            // 
            // ClaveOlvidada
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gettyimages_1042132904;
            ClientSize = new Size(610, 439);
            Controls.Add(panel1);
            Name = "ClaveOlvidada";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClaveOlvidada";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button btnEnviarSolicitud;
        private Label label2;
        private TextBox txtUserForget;
        private Button btnRegresar;
    }
}
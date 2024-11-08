namespace zompyDogs
{
    partial class Login
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
            label2 = new Label();
            txtUser = new TextBox();
            txtPassword = new TextBox();
            label3 = new Label();
            lblAnClaveOlv = new Label();
            btnIniciarSession = new Button();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            seeCloseIcon = new PictureBox();
            seeIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)seeCloseIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seeIcon).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Location = new Point(34, 212);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 11;
            label2.Text = "USUARIO";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(36, 237);
            txtUser.Multiline = true;
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(245, 34);
            txtUser.TabIndex = 14;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Location = new Point(34, 315);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(216, 34);
            txtPassword.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.White;
            label3.Location = new Point(32, 290);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 15;
            label3.Text = "CLAVE";
            // 
            // lblAnClaveOlv
            // 
            lblAnClaveOlv.AutoSize = true;
            lblAnClaveOlv.BackColor = Color.Transparent;
            lblAnClaveOlv.Cursor = Cursors.Hand;
            lblAnClaveOlv.ForeColor = Color.White;
            lblAnClaveOlv.Location = new Point(32, 358);
            lblAnClaveOlv.Name = "lblAnClaveOlv";
            lblAnClaveOlv.Size = new Size(204, 20);
            lblAnClaveOlv.TabIndex = 17;
            lblAnClaveOlv.Text = "¿Haz olvidado la contraseña?";
            lblAnClaveOlv.Click += lblAnClaveOlv_Click;
            lblAnClaveOlv.MouseEnter += lblAnClaveOlv_MouseEnter;
            lblAnClaveOlv.MouseLeave += lblAnClaveOlv_MouseLeave;
            // 
            // btnIniciarSession
            // 
            btnIniciarSession.Cursor = Cursors.Hand;
            btnIniciarSession.Location = new Point(36, 411);
            btnIniciarSession.Name = "btnIniciarSession";
            btnIniciarSession.Size = new Size(243, 48);
            btnIniciarSession.TabIndex = 18;
            btnIniciarSession.Text = "Iniciar Sessión";
            btnIniciarSession.UseVisualStyleBackColor = true;
            btnIniciarSession.Click += btnIniciarSession_Click;
            btnIniciarSession.KeyPress += btnIniciarSession_KeyPress;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Enabled = false;
            pictureBox1.Image = Properties.Resources._588ae854_f3a0_4ffc_8412_725243b013fb_removebg_preview;
            pictureBox1.Location = new Point(66, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(184, 172);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(31, 19, 10);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(seeCloseIcon);
            panel1.Controls.Add(seeIcon);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnIniciarSession);
            panel1.Controls.Add(lblAnClaveOlv);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtUser);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(34, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 510);
            panel1.TabIndex = 21;
            // 
            // seeCloseIcon
            // 
            seeCloseIcon.BackColor = Color.White;
            seeCloseIcon.Image = Properties.Resources.view_see_hide_eye_close_search_look_icon_232697;
            seeCloseIcon.Location = new Point(243, 315);
            seeCloseIcon.Name = "seeCloseIcon";
            seeCloseIcon.Size = new Size(38, 34);
            seeCloseIcon.SizeMode = PictureBoxSizeMode.Zoom;
            seeCloseIcon.TabIndex = 23;
            seeCloseIcon.TabStop = false;
            seeCloseIcon.Click += seeCloseIcon_Click;
            // 
            // seeIcon
            // 
            seeIcon.BackColor = Color.White;
            seeIcon.Image = Properties.Resources._5050_512;
            seeIcon.Location = new Point(243, 315);
            seeIcon.Name = "seeIcon";
            seeIcon.Size = new Size(38, 34);
            seeIcon.SizeMode = PictureBoxSizeMode.Zoom;
            seeIcon.TabIndex = 22;
            seeIcon.TabStop = false;
            seeIcon.Click += seeIcon_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gettyimages_1042132904;
            ClientSize = new Size(768, 585);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            KeyPreview = true;
            Name = "Login";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += Login_Load;
            KeyDown += Login_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)seeCloseIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)seeIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label2;
        private TextBox txtUser;
        private TextBox txtPassword;
        private Label label3;
        private Label lblAnClaveOlv;
        private Button btnIniciarSession;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Button btnCerrarFrm;
        private PictureBox pictureBox2;
        private PictureBox seeIcon;
        private PictureBox seeCloseIcon;
    }
}
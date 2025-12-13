namespace FormaVadras
{
    partial class FrmLogin
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
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            btnLokal = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(286, 240);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(222, 27);
            txtPassword.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(286, 173);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(222, 27);
            txtUsername.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(174, 176);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 7;
            label1.Text = "Korisničko ime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(174, 240);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 8;
            label2.Text = "Lozinka";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(330, 316);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(130, 67);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "Uloguj se";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnLokal
            // 
            btnLokal.Location = new Point(1, 2);
            btnLokal.Name = "btnLokal";
            btnLokal.Size = new Size(118, 36);
            btnLokal.TabIndex = 10;
            btnLokal.Text = "Izaberi lokal";
            btnLokal.UseVisualStyleBackColor = true;
            btnLokal.Click += btnLokal_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.vadras21;
            pictureBox1.Location = new Point(286, 61);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(209, 106);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(73, 107, 108);
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(btnLokal);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ulogujte se";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label1;
        private Label label2;
        private Button btnLogin;
        private Button btnLokal;
        private PictureBox pictureBox1;
    }
}
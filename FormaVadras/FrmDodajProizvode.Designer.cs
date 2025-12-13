namespace FormaVadras
{
    partial class FrmDodajProizvode
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
            txtDimenzije = new TextBox();
            txtBoja = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label1 = new Label();
            cmbProizvodi = new ComboBox();
            label2 = new Label();
            numKolicina = new NumericUpDown();
            label3 = new Label();
            txtCena = new TextBox();
            label4 = new Label();
            btnDodajProizvod = new Button();
            dgvProizvodi = new DataGridView();
            btnObrisiProizvod = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numKolicina).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProizvodi).BeginInit();
            SuspendLayout();
            // 
            // txtDimenzije
            // 
            txtDimenzije.Location = new Point(34, 244);
            txtDimenzije.Name = "txtDimenzije";
            txtDimenzije.Size = new Size(150, 27);
            txtDimenzije.TabIndex = 10;
            // 
            // txtBoja
            // 
            txtBoja.Location = new Point(34, 163);
            txtBoja.Name = "txtBoja";
            txtBoja.Size = new Size(150, 27);
            txtBoja.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(34, 221);
            label6.Name = "label6";
            label6.Size = new Size(76, 20);
            label6.TabIndex = 23;
            label6.Text = "Dimenzije";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(39, 306);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 22;
            label5.Text = "Količina";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(34, 140);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 21;
            label1.Text = "Boja";
            // 
            // cmbProizvodi
            // 
            cmbProizvodi.FormattingEnabled = true;
            cmbProizvodi.Location = new Point(34, 69);
            cmbProizvodi.Name = "cmbProizvodi";
            cmbProizvodi.Size = new Size(150, 28);
            cmbProizvodi.TabIndex = 24;
            cmbProizvodi.SelectedIndexChanged += cmbProizvodi_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(34, 46);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 25;
            label2.Text = "Proizvod";
            // 
            // numKolicina
            // 
            numKolicina.Location = new Point(34, 329);
            numKolicina.Name = "numKolicina";
            numKolicina.Size = new Size(150, 27);
            numKolicina.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(34, 391);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 28;
            label3.Text = "Jedinična cena";
            // 
            // txtCena
            // 
            txtCena.Location = new Point(34, 414);
            txtCena.Name = "txtCena";
            txtCena.Size = new Size(150, 27);
            txtCena.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(325, 104);
            label4.Name = "label4";
            label4.Size = new Size(95, 20);
            label4.TabIndex = 29;
            label4.Text = "Svi proizvodi";
            // 
            // btnDodajProizvod
            // 
            btnDodajProizvod.BackColor = Color.FromArgb(255, 255, 192);
            btnDodajProizvod.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDodajProizvod.ForeColor = SystemColors.ActiveCaptionText;
            btnDodajProizvod.Location = new Point(25, 467);
            btnDodajProizvod.Name = "btnDodajProizvod";
            btnDodajProizvod.Size = new Size(187, 53);
            btnDodajProizvod.TabIndex = 31;
            btnDodajProizvod.Text = "Dodaj proizvod";
            btnDodajProizvod.UseVisualStyleBackColor = false;
            btnDodajProizvod.Click += btnDodajProizvod_Click;
            // 
            // dgvProizvodi
            // 
            dgvProizvodi.BackgroundColor = SystemColors.ButtonHighlight;
            dgvProizvodi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProizvodi.Location = new Point(325, 140);
            dgvProizvodi.Name = "dgvProizvodi";
            dgvProizvodi.RowHeadersWidth = 51;
            dgvProizvodi.Size = new Size(541, 229);
            dgvProizvodi.TabIndex = 32;
            // 
            // btnObrisiProizvod
            // 
            btnObrisiProizvod.BackColor = Color.Red;
            btnObrisiProizvod.FlatAppearance.BorderSize = 0;
            btnObrisiProizvod.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnObrisiProizvod.ForeColor = SystemColors.ActiveCaptionText;
            btnObrisiProizvod.Location = new Point(869, 164);
            btnObrisiProizvod.Margin = new Padding(0);
            btnObrisiProizvod.Name = "btnObrisiProizvod";
            btnObrisiProizvod.Size = new Size(139, 39);
            btnObrisiProizvod.TabIndex = 33;
            btnObrisiProizvod.Text = "Obriši proizvod";
            btnObrisiProizvod.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(450, 460);
            button1.Name = "button1";
            button1.Size = new Size(265, 66);
            button1.TabIndex = 34;
            button1.Text = "Završi dodavanje";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FrmDodajProizvode
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(1045, 543);
            Controls.Add(button1);
            Controls.Add(btnObrisiProizvod);
            Controls.Add(dgvProizvodi);
            Controls.Add(btnDodajProizvod);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtCena);
            Controls.Add(numKolicina);
            Controls.Add(label2);
            Controls.Add(cmbProizvodi);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(txtDimenzije);
            Controls.Add(txtBoja);
            Name = "FrmDodajProizvode";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmDodajProizvode";
            ((System.ComponentModel.ISupportInitialize)numKolicina).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProizvodi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtDimenzije;
        private TextBox txtBoja;
        private Label label6;
        private Label label5;
        private Label label1;
        private ComboBox cmbProizvodi;
        private Label label2;
        private NumericUpDown numKolicina;
        private Label label3;
        private TextBox txtCena;
        private Label label4;
        private Button btnDodajProizvod;
        private DataGridView dgvProizvodi;
        private Button btnObrisiProizvod;
        private Button button1;
    }
}
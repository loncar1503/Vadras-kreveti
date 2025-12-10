namespace FormaVadras.UserControlls
{
    partial class UcKreirajPorudzbinu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBrRacuna = new TextBox();
            txtImePrezime = new TextBox();
            txtAdresa = new TextBox();
            txtBrojTelefona = new TextBox();
            datumPorudzbine = new DateTimePicker();
            datumIsporuke = new DateTimePicker();
            cmbTipObjekta = new ComboBox();
            chckKartica = new CheckBox();
            chckLift = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            btnDodajProizvode = new Button();
            label10 = new Label();
            dgvProizvodi = new DataGridView();
            label11 = new Label();
            txtNapomena = new RichTextBox();
            btnSacuvajPorudzbinu = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProizvodi).BeginInit();
            SuspendLayout();
            // 
            // txtBrRacuna
            // 
            txtBrRacuna.Location = new Point(180, 45);
            txtBrRacuna.Name = "txtBrRacuna";
            txtBrRacuna.Size = new Size(250, 27);
            txtBrRacuna.TabIndex = 6;
            // 
            // txtImePrezime
            // 
            txtImePrezime.Location = new Point(180, 112);
            txtImePrezime.Name = "txtImePrezime";
            txtImePrezime.Size = new Size(250, 27);
            txtImePrezime.TabIndex = 7;
            // 
            // txtAdresa
            // 
            txtAdresa.Location = new Point(180, 177);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(250, 27);
            txtAdresa.TabIndex = 8;
            // 
            // txtBrojTelefona
            // 
            txtBrojTelefona.Location = new Point(180, 238);
            txtBrojTelefona.Name = "txtBrojTelefona";
            txtBrojTelefona.Size = new Size(250, 27);
            txtBrojTelefona.TabIndex = 9;
            // 
            // datumPorudzbine
            // 
            datumPorudzbine.Location = new Point(180, 296);
            datumPorudzbine.Name = "datumPorudzbine";
            datumPorudzbine.Size = new Size(250, 27);
            datumPorudzbine.TabIndex = 10;
            // 
            // datumIsporuke
            // 
            datumIsporuke.Location = new Point(180, 354);
            datumIsporuke.Name = "datumIsporuke";
            datumIsporuke.Size = new Size(250, 27);
            datumIsporuke.TabIndex = 11;
            // 
            // cmbTipObjekta
            // 
            cmbTipObjekta.FormattingEnabled = true;
            cmbTipObjekta.Location = new Point(180, 416);
            cmbTipObjekta.Name = "cmbTipObjekta";
            cmbTipObjekta.Size = new Size(250, 28);
            cmbTipObjekta.TabIndex = 12;
            // 
            // chckKartica
            // 
            chckKartica.AutoSize = true;
            chckKartica.Location = new Point(196, 468);
            chckKartica.Name = "chckKartica";
            chckKartica.Size = new Size(18, 17);
            chckKartica.TabIndex = 13;
            chckKartica.UseVisualStyleBackColor = true;
            // 
            // chckLift
            // 
            chckLift.AutoSize = true;
            chckLift.Location = new Point(196, 510);
            chckLift.Name = "chckLift";
            chckLift.Size = new Size(18, 17);
            chckLift.TabIndex = 14;
            chckLift.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(38, 45);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 15;
            label1.Text = "Broj računa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(38, 354);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 16;
            label2.Text = "Datum isporuke";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(38, 296);
            label3.Name = "label3";
            label3.Size = new Size(134, 20);
            label3.TabIndex = 17;
            label3.Text = "Datum porudžbine";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(38, 238);
            label4.Name = "label4";
            label4.Size = new Size(95, 20);
            label4.TabIndex = 18;
            label4.Text = "Broj telefona";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(38, 177);
            label5.Name = "label5";
            label5.Size = new Size(98, 20);
            label5.TabIndex = 19;
            label5.Text = "Adresa i grad";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(38, 112);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 20;
            label6.Text = "Ime i prezime";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(38, 416);
            label7.Name = "label7";
            label7.Size = new Size(84, 20);
            label7.TabIndex = 21;
            label7.Text = "Tip objekta";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(38, 465);
            label8.Name = "label8";
            label8.Size = new Size(126, 20);
            label8.TabIndex = 22;
            label8.Text = "Plaćanje karticom";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(38, 507);
            label9.Name = "label9";
            label9.Size = new Size(75, 20);
            label9.TabIndex = 23;
            label9.Text = "Postoji lift";
            // 
            // btnDodajProizvode
            // 
            btnDodajProizvode.BackColor = Color.LemonChiffon;
            btnDodajProizvode.Location = new Point(588, 285);
            btnDodajProizvode.Name = "btnDodajProizvode";
            btnDodajProizvode.Size = new Size(265, 38);
            btnDodajProizvode.TabIndex = 24;
            btnDodajProizvode.Text = "Dodaj proizvode";
            btnDodajProizvode.UseVisualStyleBackColor = false;
            btnDodajProizvode.Click += btnDodajProizvode_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = SystemColors.ButtonHighlight;
            label10.Location = new Point(495, 21);
            label10.Name = "label10";
            label10.Size = new Size(71, 20);
            label10.TabIndex = 25;
            label10.Text = "Proizvodi";
            // 
            // dgvProizvodi
            // 
            dgvProizvodi.BackgroundColor = SystemColors.ButtonHighlight;
            dgvProizvodi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProizvodi.Location = new Point(495, 44);
            dgvProizvodi.Name = "dgvProizvodi";
            dgvProizvodi.RowHeadersWidth = 51;
            dgvProizvodi.Size = new Size(529, 229);
            dgvProizvodi.TabIndex = 26;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = SystemColors.ButtonHighlight;
            label11.Location = new Point(495, 335);
            label11.Name = "label11";
            label11.Size = new Size(83, 20);
            label11.TabIndex = 27;
            label11.Text = "Napomena";
            // 
            // txtNapomena
            // 
            txtNapomena.Location = new Point(495, 366);
            txtNapomena.Name = "txtNapomena";
            txtNapomena.Size = new Size(529, 107);
            txtNapomena.TabIndex = 29;
            txtNapomena.Text = "";
            // 
            // btnSacuvajPorudzbinu
            // 
            btnSacuvajPorudzbinu.BackColor = Color.LightGreen;
            btnSacuvajPorudzbinu.Location = new Point(588, 507);
            btnSacuvajPorudzbinu.Name = "btnSacuvajPorudzbinu";
            btnSacuvajPorudzbinu.Size = new Size(265, 66);
            btnSacuvajPorudzbinu.TabIndex = 30;
            btnSacuvajPorudzbinu.Text = "Sačuvaj porudžbinu";
            btnSacuvajPorudzbinu.UseVisualStyleBackColor = false;
            btnSacuvajPorudzbinu.Click += button2_Click;
            // 
            // UcKreirajPorudzbinu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            Controls.Add(btnSacuvajPorudzbinu);
            Controls.Add(txtNapomena);
            Controls.Add(label11);
            Controls.Add(dgvProizvodi);
            Controls.Add(label10);
            Controls.Add(btnDodajProizvode);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(chckLift);
            Controls.Add(chckKartica);
            Controls.Add(cmbTipObjekta);
            Controls.Add(datumIsporuke);
            Controls.Add(datumPorudzbine);
            Controls.Add(txtBrojTelefona);
            Controls.Add(txtAdresa);
            Controls.Add(txtImePrezime);
            Controls.Add(txtBrRacuna);
            Name = "UcKreirajPorudzbinu";
            Size = new Size(1087, 601);
            Load += UcKreirajPorudzbinu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProizvodi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtBrRacuna;
        private TextBox txtImePrezime;
        private TextBox txtAdresa;
        private TextBox txtBrojTelefona;
        private DateTimePicker datumPorudzbine;
        private DateTimePicker datumIsporuke;
        private ComboBox cmbTipObjekta;
        private CheckBox chckKartica;
        private CheckBox chckLift;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button btnDodajProizvode;
        private Label label10;
        public DataGridView dgvProizvodi;
        private Label label11;
        private RichTextBox txtNapomena;
        private Button btnSacuvajPorudzbinu;
    }
}

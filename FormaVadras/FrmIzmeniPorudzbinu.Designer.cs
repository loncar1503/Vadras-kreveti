namespace FormaVadras
{
    partial class FrmIzmeniPorudzbinu
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
            btnSacuvajPorudzbinu = new Button();
            txtNapomena = new RichTextBox();
            label11 = new Label();
            dgvProizvodi = new DataGridView();
            label10 = new Label();
            btnDodajProizvode = new Button();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            chckLift = new CheckBox();
            chckKartica = new CheckBox();
            cmbTipObjekta = new ComboBox();
            datumIsporuke = new DateTimePicker();
            datumPorudzbine = new DateTimePicker();
            txtBrojTelefona = new TextBox();
            txtAdresa = new TextBox();
            txtImePrezime = new TextBox();
            txtBrRacuna = new TextBox();
            cmbStatus = new ComboBox();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProizvodi).BeginInit();
            SuspendLayout();
            // 
            // btnSacuvajPorudzbinu
            // 
            btnSacuvajPorudzbinu.BackColor = Color.LightGreen;
            btnSacuvajPorudzbinu.Location = new Point(623, 539);
            btnSacuvajPorudzbinu.Name = "btnSacuvajPorudzbinu";
            btnSacuvajPorudzbinu.Size = new Size(265, 66);
            btnSacuvajPorudzbinu.TabIndex = 54;
            btnSacuvajPorudzbinu.Text = "Sačuvaj izmene";
            btnSacuvajPorudzbinu.UseVisualStyleBackColor = false;
            btnSacuvajPorudzbinu.Click += btnSacuvajPorudzbinu_Click;
            // 
            // txtNapomena
            // 
            txtNapomena.Location = new Point(530, 398);
            txtNapomena.Name = "txtNapomena";
            txtNapomena.Size = new Size(529, 107);
            txtNapomena.TabIndex = 53;
            txtNapomena.Text = "";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = SystemColors.ButtonHighlight;
            label11.Location = new Point(530, 367);
            label11.Name = "label11";
            label11.Size = new Size(83, 20);
            label11.TabIndex = 52;
            label11.Text = "Napomena";
            // 
            // dgvProizvodi
            // 
            dgvProizvodi.BackgroundColor = SystemColors.ButtonHighlight;
            dgvProizvodi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProizvodi.Location = new Point(530, 76);
            dgvProizvodi.Name = "dgvProizvodi";
            dgvProizvodi.RowHeadersWidth = 51;
            dgvProizvodi.Size = new Size(529, 229);
            dgvProizvodi.TabIndex = 51;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = SystemColors.ButtonHighlight;
            label10.Location = new Point(530, 53);
            label10.Name = "label10";
            label10.Size = new Size(71, 20);
            label10.TabIndex = 50;
            label10.Text = "Proizvodi";
            // 
            // btnDodajProizvode
            // 
            btnDodajProizvode.BackColor = Color.LemonChiffon;
            btnDodajProizvode.Location = new Point(623, 317);
            btnDodajProizvode.Name = "btnDodajProizvode";
            btnDodajProizvode.Size = new Size(265, 38);
            btnDodajProizvode.TabIndex = 49;
            btnDodajProizvode.Text = "Dodaj proizvode";
            btnDodajProizvode.UseVisualStyleBackColor = false;
            btnDodajProizvode.Click += btnDodajProizvode_Click_1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(73, 539);
            label9.Name = "label9";
            label9.Size = new Size(75, 20);
            label9.TabIndex = 48;
            label9.Text = "Postoji lift";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(73, 497);
            label8.Name = "label8";
            label8.Size = new Size(126, 20);
            label8.TabIndex = 47;
            label8.Text = "Plaćanje karticom";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(73, 448);
            label7.Name = "label7";
            label7.Size = new Size(84, 20);
            label7.TabIndex = 46;
            label7.Text = "Tip objekta";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(73, 144);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 45;
            label6.Text = "Ime i prezime";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(73, 209);
            label5.Name = "label5";
            label5.Size = new Size(98, 20);
            label5.TabIndex = 44;
            label5.Text = "Adresa i grad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(73, 270);
            label4.Name = "label4";
            label4.Size = new Size(95, 20);
            label4.TabIndex = 43;
            label4.Text = "Broj telefona";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(73, 328);
            label3.Name = "label3";
            label3.Size = new Size(134, 20);
            label3.TabIndex = 42;
            label3.Text = "Datum porudžbine";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(73, 386);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 41;
            label2.Text = "Datum isporuke";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(73, 77);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 40;
            label1.Text = "Broj računa";
            // 
            // chckLift
            // 
            chckLift.AutoSize = true;
            chckLift.Location = new Point(231, 542);
            chckLift.Name = "chckLift";
            chckLift.Size = new Size(18, 17);
            chckLift.TabIndex = 39;
            chckLift.UseVisualStyleBackColor = true;
            // 
            // chckKartica
            // 
            chckKartica.AutoSize = true;
            chckKartica.Location = new Point(231, 500);
            chckKartica.Name = "chckKartica";
            chckKartica.Size = new Size(18, 17);
            chckKartica.TabIndex = 38;
            chckKartica.UseVisualStyleBackColor = true;
            // 
            // cmbTipObjekta
            // 
            cmbTipObjekta.FormattingEnabled = true;
            cmbTipObjekta.Location = new Point(215, 448);
            cmbTipObjekta.Name = "cmbTipObjekta";
            cmbTipObjekta.Size = new Size(250, 28);
            cmbTipObjekta.TabIndex = 37;
            // 
            // datumIsporuke
            // 
            datumIsporuke.Location = new Point(215, 386);
            datumIsporuke.Name = "datumIsporuke";
            datumIsporuke.Size = new Size(250, 27);
            datumIsporuke.TabIndex = 36;
            // 
            // datumPorudzbine
            // 
            datumPorudzbine.Location = new Point(215, 328);
            datumPorudzbine.Name = "datumPorudzbine";
            datumPorudzbine.Size = new Size(250, 27);
            datumPorudzbine.TabIndex = 35;
            // 
            // txtBrojTelefona
            // 
            txtBrojTelefona.Location = new Point(215, 270);
            txtBrojTelefona.Name = "txtBrojTelefona";
            txtBrojTelefona.Size = new Size(250, 27);
            txtBrojTelefona.TabIndex = 34;
            // 
            // txtAdresa
            // 
            txtAdresa.Location = new Point(215, 209);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(250, 27);
            txtAdresa.TabIndex = 33;
            // 
            // txtImePrezime
            // 
            txtImePrezime.Location = new Point(215, 144);
            txtImePrezime.Name = "txtImePrezime";
            txtImePrezime.Size = new Size(250, 27);
            txtImePrezime.TabIndex = 32;
            // 
            // txtBrRacuna
            // 
            txtBrRacuna.Location = new Point(215, 77);
            txtBrRacuna.Name = "txtBrRacuna";
            txtBrRacuna.Size = new Size(250, 27);
            txtBrRacuna.TabIndex = 31;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(215, 21);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(151, 28);
            cmbStatus.TabIndex = 55;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = SystemColors.ButtonHighlight;
            label12.Location = new Point(73, 21);
            label12.Name = "label12";
            label12.Size = new Size(49, 20);
            label12.TabIndex = 56;
            label12.Text = "Status";
            // 
            // FrmIzmeniPorudzbinu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(1190, 656);
            Controls.Add(label12);
            Controls.Add(cmbStatus);
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
            Name = "FrmIzmeniPorudzbinu";
            Text = "FrmIzmeniPorudzbinu";
            ((System.ComponentModel.ISupportInitialize)dgvProizvodi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSacuvajPorudzbinu;
        private RichTextBox txtNapomena;
        private Label label11;
        public DataGridView dgvProizvodi;
        private Label label10;
        private Button btnDodajProizvode;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckBox chckLift;
        private CheckBox chckKartica;
        private ComboBox cmbTipObjekta;
        private DateTimePicker datumIsporuke;
        private DateTimePicker datumPorudzbine;
        private TextBox txtBrojTelefona;
        private TextBox txtAdresa;
        private TextBox txtImePrezime;
        private TextBox txtBrRacuna;
        private ComboBox cmbStatus;
        private Label label12;
    }
}
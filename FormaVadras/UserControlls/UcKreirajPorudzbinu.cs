using API_Vadras.DTO.Porudzbina;
using API_Vadras.DTO.StavkaPorudzbine;
using FormaVadras.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaVadras.UserControlls
{
    public partial class UcKreirajPorudzbinu : UserControl
    {
        public FrmDodajProizvode frmDodajProizvode;
        public List<KreirajStavkePorudzbineDTO> stavke;
        PorudzbinaContr porudzbinaContr;
        string lokal;
        public UcKreirajPorudzbinu(string lokal)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.lokal = lokal;
            porudzbinaContr = new PorudzbinaContr();

            PopuniPolja();
            stavke = new List<KreirajStavkePorudzbineDTO>();
        }

        private async void PopuniPolja()
        {
            txtBrRacuna.Text = await porudzbinaContr.UcitajBrojRacuna(lokal);
            txtBrRacuna.Enabled = false;
            cmbTipObjekta.DataSource = new List<string> { "Stan", "Kuća" };
            datumPorudzbine.Format = DateTimePickerFormat.Custom;
            datumPorudzbine.CustomFormat = "dd.MM.yyyy";
            datumIsporuke.Format = DateTimePickerFormat.Custom;
            datumIsporuke.CustomFormat = "dd.MM.yyyy";
            datumPorudzbine.Value = DateTime.Now;
            datumIsporuke.Value = DateTime.Now.AddDays(30);

        }

        private void btnDodajProizvode_Click(object sender, EventArgs e)
        {
            frmDodajProizvode = new FrmDodajProizvode(this);
            frmDodajProizvode.ShowDialog();
            AzurirajDgv();
        }
        public void AzurirajDgv()
        {

            dgvProizvodi.DataSource = null;
            dgvProizvodi.DataSource = stavke;
            dgvProizvodi.Columns["ProizvodId"].Visible = false;


            //dgvProizvodi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvProizvodi.Columns["Rb"].Width = 40;
            dgvProizvodi.Columns["Rb"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvProizvodi.Columns["Kolicina"].Width = 80;
            dgvProizvodi.Columns["Kolicina"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvProizvodi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProizvodi.Columns["FinalnaCena"].HeaderText = "Cena";
            dgvProizvodi.Columns["Rb"].HeaderText = "";

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Da li ste sigurni da zelite da kreirate ovu porudžbinu?", "Potvrda porudžbine", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dgvProizvodi.DataSource = null;
                KreirajPorudzbinuDTO porudzbina = new KreirajPorudzbinuDTO()
                {
                    BrRacuna = txtBrRacuna.Text,
                    ImePrezime = txtImePrezime.Text,
                    Adresa = txtAdresa.Text,
                    BrojTelefona = txtBrojTelefona.Text,
                    DatumIsporuke = datumIsporuke.Value,
                    DatumPorudzbine = datumPorudzbine.Value,
                    Napomena = txtNapomena.Text,
                    Stavke = stavke,
                    RadnikId = 1,
                };
                if (chckKartica.Checked)
                {
                    porudzbina.AparatZaKartice = true;
                }
                else porudzbina.AparatZaKartice = false;
                if (chckLift.Checked)
                {
                    porudzbina.Lift = true;
                }
                else porudzbina.Lift = false;
                if (cmbTipObjekta.SelectedIndex == 0)
                {
                    porudzbina.Stan = true;
                }
                else porudzbina.Stan = false;

                var brRacuna = await porudzbinaContr.KreirajPorudzbinu(porudzbina);

                if (brRacuna == null)
                {
                    MessageBox.Show("Došlo je do greške prilikom kreiranja porudžbine.");
                    return;
                }

                MessageBox.Show($"Porudžbina {brRacuna} je uspešno kreirana.");

            }
        }



        private void UcKreirajPorudzbinu_Load(object sender, EventArgs e)
        {

        }
    }
}

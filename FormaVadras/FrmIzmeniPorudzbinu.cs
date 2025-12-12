using API_Vadras.DTO.Porudzbina;
using API_Vadras.DTO.StavkaPorudzbine;
using API_Vadras.Repository.PorudzbinaRepo;
using Domain;
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

namespace FormaVadras
{
    public partial class FrmIzmeniPorudzbinu : Form
    {
        public FrmDodajProizvode frmDodajProizvode;
        PorudzbinaContr porudzbinaContr;
        VratiPorudzbinuDTO porudzbina;
        int idPorudzbine;
        string lokal;
        public BindingList<IzmeniStavkePorudzbineDTO> stavkeEdit;

        public FrmIzmeniPorudzbinu(int id)
        {
            idPorudzbine = id;
            InitializeComponent();
            stavkeEdit = new();
            porudzbinaContr = new PorudzbinaContr();

            this.Shown += FrmIzmeniPorudzbinu_Shown;          
        }
        private async void FrmIzmeniPorudzbinu_Shown(object sender, EventArgs e)
        {
            await UcitajStavke();
            await PopuniPolja();
        }
        private async Task UcitajStavke()
        {
            porudzbina = await porudzbinaContr.VratiPorudzbinu(idPorudzbine);
            foreach (var s in porudzbina.Stavke)
            {
                stavkeEdit.Add(new IzmeniStavkePorudzbineDTO
                {
                    Id = s.Id,
                    Rb = s.Rb,
                    Kolicina = s.Kolicina,
                    Boja = s.Boja,
                    Dimenzija = s.Dimenzija,
                    FinalnaCena = s.FinalnaCena,
                    ProizvodId = s.Proizvod.Id,
                    ProizvodNaziv=s.Proizvod.Naziv
                });
            }
        }

        private async Task PopuniPolja()
        {
            
            dgvProizvodi.DataSource = stavkeEdit;
            if (porudzbina.BrRacuna.StartsWith("P"))
            {
                lokal = "Piramida";
            }
            else lokal = "Banovo brdo";
            txtBrRacuna.Text = await porudzbinaContr.UcitajBrojRacuna(lokal);
            txtBrRacuna.Enabled = false;
            cmbTipObjekta.DataSource = new List<string> { "Stan", "Kuća" };
            datumPorudzbine.Format = DateTimePickerFormat.Custom;
            datumPorudzbine.CustomFormat = "dd.MM.yyyy";
            datumIsporuke.Format = DateTimePickerFormat.Custom;
            datumIsporuke.CustomFormat = "dd.MM.yyyy";
            datumPorudzbine.Value = porudzbina.DatumPorudzbine;
            datumIsporuke.Value = porudzbina.DatumIsporuke;
            dgvProizvodi.Columns["Id"].Visible = false;
            cmbStatus.DataSource = Enum.GetValues(typeof(Status));

            txtImePrezime.Text = porudzbina.ImePrezime;
            txtAdresa.Text = porudzbina.Adresa;
            txtNapomena.Text = porudzbina.Napomena;
            txtBrojTelefona.Text = porudzbina.BrojTelefona;
            if (porudzbina.Stan)
            {
                cmbTipObjekta.SelectedIndex = 0;
            }
            else cmbTipObjekta.SelectedIndex = 1;

            if (porudzbina.Lift)
            {
                chckLift.Checked = true;
            }
            if (porudzbina.AparatZaKartice)
            {
                chckKartica.Checked = true;
            }

            //dgvProizvodi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvProizvodi.Columns["Rb"].Width = 40;
            dgvProizvodi.Columns["Rb"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvProizvodi.Columns["Kolicina"].Width = 80;
            dgvProizvodi.Columns["Kolicina"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvProizvodi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProizvodi.Columns["FinalnaCena"].HeaderText = "Cena";
            dgvProizvodi.Columns["ProizvodNaziv"].HeaderText = "Naziv";

            dgvProizvodi.Columns["Rb"].HeaderText = "";
        }

        private async void OcistiPolja()
        {
            txtBrRacuna.Text = await porudzbinaContr.UcitajBrojRacuna(lokal);
            txtAdresa.Text = "";
            txtBrojTelefona.Text = "";
            txtImePrezime.Text = "";
            txtNapomena.Text = "";
        }

        private void btnDodajProizvode_Click_1(object sender, EventArgs e)
        {
            frmDodajProizvode = new FrmDodajProizvode(this, false);
            frmDodajProizvode.ShowDialog();
        }

        private async void btnSacuvajPorudzbinu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Da li ste sigurni da zelite da kreirate ovu porudžbinu?", "Potvrda porudžbine", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var izmenjena = new IzmeniPorudzbinuDTO
                {
                    BrRacuna = txtBrRacuna.Text,
                    ImePrezime = txtImePrezime.Text,
                    Adresa = txtAdresa.Text,
                    BrojTelefona = txtBrojTelefona.Text,
                    DatumPorudzbine = datumPorudzbine.Value,
                    DatumIsporuke = datumIsporuke.Value,
                    Napomena = txtNapomena.Text,
                    Status = (Status)cmbStatus.SelectedItem,


                    Stavke=stavkeEdit.ToList(),
                };
                if (chckKartica.Checked)
                {
                    izmenjena.AparatZaKartice = true;
                }
                else izmenjena.AparatZaKartice = false;
                if (chckLift.Checked)
                {
                    izmenjena.Lift = true;
                }
                else izmenjena.Lift = false;
                if (cmbTipObjekta.SelectedIndex == 0)
                {
                    izmenjena.Stan = true;
                }
                else izmenjena.Stan = false;


                MessageBox.Show($"Porudžbina {txtBrRacuna.Text} je uspešno izmenjena.");
                bool ok = await porudzbinaContr.IzmeniPorudzbinu(idPorudzbine, izmenjena);

                if (!ok)
                {
                    MessageBox.Show("Greška pri izmeni porudžbine.");
                    return;
                }

                OcistiPolja();
                this.Close();
            }
        }
    }
}

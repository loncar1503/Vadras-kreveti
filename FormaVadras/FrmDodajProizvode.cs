using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using Domain;
using API_Vadras.Controllers;
using FormaVadras.Controllers;
using API_Vadras.DTO.Proizvod;
using API_Vadras.DTO.StavkaPorudzbine;
using FormaVadras.UserControlls;

namespace FormaVadras
{
    public partial class FrmDodajProizvode : Form
    {
        UcKreirajPorudzbinu frmKreirajPoruzbinu;
        FrmIzmeniPorudzbinu frmIzmeniPorudzbinu;
        ProizvodContr pcontroller;
        bool kreiranje;
        public FrmDodajProizvode(UcKreirajPorudzbinu frmKreirajPoruzbinu, bool kreiranje)
        {
            InitializeComponent();
            this.kreiranje = kreiranje;
            pcontroller = new ProizvodContr();
            this.frmKreirajPoruzbinu = frmKreirajPoruzbinu;

            PopuniPolja();
        }
        public FrmDodajProizvode(FrmIzmeniPorudzbinu frmIzmeniPorudzbinu, bool kreiranje)
        {
            InitializeComponent();
            this.kreiranje = kreiranje;

            pcontroller = new ProizvodContr();
            this.frmIzmeniPorudzbinu = frmIzmeniPorudzbinu;

            PopuniPoljaIzmena();
        }

        private async void PopuniPolja()
        {
            dgvProizvodi.DataSource = frmKreirajPoruzbinu.stavke;

            // punimo comboBox
            cmbProizvodi.DataSource = await pcontroller.VratiSveProizvode();
            cmbProizvodi.DisplayMember = "Naziv"; // šta se vidi u listi
            cmbProizvodi.ValueMember = "Id";     // šta se krije iza (ID proizvoda)
            cmbProizvodi.SelectedIndex = -1;
            dgvProizvodi.Refresh();
            dgvProizvodi.Columns["ProizvodId"].Visible = false;


            dgvProizvodi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvProizvodi.Columns["Rb"].Width = 40;
            dgvProizvodi.Columns["Rb"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvProizvodi.Columns["Kolicina"].Width = 60;
            dgvProizvodi.Columns["Kolicina"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            //dgvProizvodi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvProizvodi.Columns["Rb"].Width = 40;
            dgvProizvodi.Columns["Rb"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvProizvodi.Columns["Kolicina"].Width = 80;
            dgvProizvodi.Columns["Kolicina"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvProizvodi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProizvodi.Columns["FinalnaCena"].HeaderText = "Cena";
            dgvProizvodi.Columns["Rb"].HeaderText = "";
        }
        private async void PopuniPoljaIzmena()
        {
            dgvProizvodi.DataSource = frmIzmeniPorudzbinu.stavkeEdit;

            // punimo comboBox
            cmbProizvodi.DataSource = await pcontroller.VratiSveProizvode();
            cmbProizvodi.DisplayMember = "Naziv"; // šta se vidi u listi
            cmbProizvodi.ValueMember = "Id";     // šta se krije iza (ID proizvoda)
            cmbProizvodi.SelectedIndex = -1;
            dgvProizvodi.Refresh();
            dgvProizvodi.Columns["Id"].Visible = false;
            dgvProizvodi.Columns["ProizvodId"].Visible = false;


            dgvProizvodi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvProizvodi.Columns["Rb"].Width = 40;
            dgvProizvodi.Columns["Rb"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvProizvodi.Columns["Kolicina"].Width = 60;
            dgvProizvodi.Columns["Kolicina"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

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


        private void btnDodajProizvod_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProizvodi.SelectedIndex != -1 && kreiranje)
                {
                    KreirajStavkePorudzbineDTO stavka = new KreirajStavkePorudzbineDTO()
                    {
                        Rb = frmKreirajPoruzbinu.stavke.Count() + 1,
                        Kolicina = Convert.ToInt32(numKolicina.Value),
                        Boja = txtBoja.Text,
                        Dimenzija = txtDimenzije.Text,
                        FinalnaCena = Int32.Parse(txtCena.Text),
                        ProizvodId = ((Proizvod)cmbProizvodi.SelectedItem).Id,
                        ProizvodNaziv= ((Proizvod)cmbProizvodi.SelectedItem).Naziv,
                    };

                    frmKreirajPoruzbinu.stavke.Add(stavka);

                    OcistiPolja();
                }
                if (cmbProizvodi.SelectedIndex != -1 && !kreiranje)
                {
                    IzmeniStavkePorudzbineDTO stavka = new IzmeniStavkePorudzbineDTO()
                    {
                        Id =null,
                        Rb = frmIzmeniPorudzbinu.stavkeEdit.Count() + 1,
                        Kolicina = Convert.ToInt32(numKolicina.Value),
                        Boja = txtBoja.Text,
                        Dimenzija = txtDimenzije.Text,
                        FinalnaCena = Int32.Parse(txtCena.Text),
                        ProizvodNaziv = ((Proizvod)cmbProizvodi.SelectedItem).Naziv,
                        ProizvodId = ((Proizvod)cmbProizvodi.SelectedItem).Id,


                    };

                    frmIzmeniPorudzbinu.stavkeEdit.Add(stavka);

                    OcistiPolja();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Cena nije u ispravnom formatu ili nije popunjena.");
            }


        }
        public void OcistiPolja()
        {
            txtBoja.Text = "";
            txtCena.Text = "";
            txtDimenzije.Text = "";
            numKolicina.Value = 0;
        }
        private void cmbProizvodi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProizvodi.SelectedIndex != -1)
            {
                txtCena.Text = ((Proizvod)cmbProizvodi.SelectedItem).Cena.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

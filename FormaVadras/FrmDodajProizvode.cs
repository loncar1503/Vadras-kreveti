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

        ProizvodContr pcontroller;
        public FrmDodajProizvode(UcKreirajPorudzbinu frmKreirajPoruzbinu)
        {
            InitializeComponent();
            pcontroller = new ProizvodContr();
            PopuniPolja();
            this.frmKreirajPoruzbinu = frmKreirajPoruzbinu;
            AzurirajDgv();
        }

        private async void PopuniPolja()
        {

            // punimo comboBox
            cmbProizvodi.DataSource = await pcontroller.VratiSveProizvode();
            cmbProizvodi.DisplayMember = "Naziv"; // šta se vidi u listi
            cmbProizvodi.ValueMember = "Id";     // šta se krije iza (ID proizvoda)
            cmbProizvodi.SelectedIndex = -1;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        public void AzurirajDgv()
        {
            dgvProizvodi.DataSource = null;
            dgvProizvodi.DataSource = frmKreirajPoruzbinu.stavke;
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

        private void btnDodajProizvod_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProizvodi.SelectedIndex != -1)
                {
                    KreirajStavkePorudzbineDTO stavka = new KreirajStavkePorudzbineDTO()
                    {
                        Rb = frmKreirajPoruzbinu.stavke.Count() + 1,
                        Kolicina = Convert.ToInt32(numKolicina.Value),
                        Boja = txtBoja.Text,
                        Dimenzija = txtDimenzije.Text,
                        FinalnaCena = Int32.Parse(txtCena.Text),
                        ProizvodId = ((Proizvod)cmbProizvodi.SelectedItem).Id
                    };

                    frmKreirajPoruzbinu.stavke.Add(stavka);
                    AzurirajDgv();
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

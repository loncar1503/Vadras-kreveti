using API_Vadras.DTO.Proizvod;
using Domain;
using FormaVadras.Controllers;
using FormaVadras.UserControlls;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace FormaVadras
{
    public partial class FrmMain : Form
    {
        public string lokal;
        public string apiKey;
        //private static readonly HttpClient client = new HttpClient
        //{
        //    BaseAddress = new Uri("https://localhost:7080/")
        //};
        private readonly UcKreirajPorudzbinu _ucKreiraj;
        private readonly UCSvePorudzbine _ucSve;
        private readonly UCHome _ucHome;
        Radnik radnik;
        public FrmMain(string lokal, Radnik r)
        {
            InitializeComponent();
            //this.FormClosed += FrmMain_FormClosed;
            this.lokal = lokal;
            this.Text = lokal;
            radnik = r;

            // kreiramo UC samo jednom
            _ucKreiraj = new UcKreirajPorudzbinu(lokal);
            _ucSve = new UCSvePorudzbine(); // ako mu treba lokal
            _ucHome = new UCHome();

            _ucKreiraj.Dock = DockStyle.Fill;
            _ucSve.Dock = DockStyle.Fill;
            _ucHome.Dock = DockStyle.Fill;

            // dodamo ih u panel jednom
            panel1.Controls.Add(_ucKreiraj);
            panel1.Controls.Add(_ucSve);
            panel1.Controls.Add(_ucHome);

            // na startu sakrij sve ili prikazi početni
            _ucKreiraj.Visible = false;
            _ucSve.Visible = false;

            // npr. prikaži pregled porudžbina na startu:
            // ShowScreen(_ucSve);
        }

        // helper za prebacivanje ekrana
        private void ShowScreen(UserControl uc)
        {
            panel1.SuspendLayout();

            foreach (Control c in panel1.Controls)
                c.Visible = false;

            uc.Visible = true;
            uc.BringToFront();

            panel1.ResumeLayout();
        }



        private void kreirajPorudzbinuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowScreen(_ucKreiraj);
        }

        //private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    Application.Exit();
        //}

        private void pregledPorudzbinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ucSve.RefreshDgv();
            ShowScreen(_ucSve);

        }

        private void početniEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowScreen(_ucHome);

        }

        private async void izlogujSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           await ApiClient.Client.PostAsync("api/radnici/logout", null);
            
           
           ApiClient.SetApiKey(string.Empty);

          radnik= null;

          this.Close(); // zatvara FrmMain → vraća se na Login
        }
    }
    }


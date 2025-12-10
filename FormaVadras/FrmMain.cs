using System.Net.Http;
using System.Net.Http.Json;
using Domain;
using System.Linq;
using System.Collections.Generic;
using API_Vadras.DTO.Proizvod;
using System.Text.Json;
using FormaVadras.UserControlls;

namespace FormaVadras
{
    public partial class FrmMain : Form
    {
        public string lokal;
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7080/")
        };
        private readonly UcKreirajPorudzbinu _ucKreiraj;
        private readonly UCSvePorudzbine _ucSve;
        private readonly UCHome _ucHome;
        public FrmMain(string lokal)
        {
            InitializeComponent();
            this.FormClosed += FrmMain_FormClosed;
            this.lokal = lokal;
            this.Text = lokal;

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

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pregledPorudzbinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowScreen(_ucSve);

        }

        private void početniEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowScreen(_ucHome);

        }
    }
}

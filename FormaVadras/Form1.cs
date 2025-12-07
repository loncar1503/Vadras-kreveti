using System.Net.Http;
using System.Net.Http.Json;
using Domain;
using System.Linq;
using System.Collections.Generic;
using API_Vadras.DTO.Proizvod;
using System.Text.Json;

namespace FormaVadras
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7080/")
        };
        public Form1()
        {
            InitializeComponent();
            PozoviApi();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                KreirajProizvodDTO p = new KreirajProizvodDTO()
                {
                    Naziv = "K3",
                    Cena = 17000
                };
                List<KreirajProizvodDTO> lp = new List<KreirajProizvodDTO>();
                lp.Add(p);
                await client.PostAsJsonAsync("api/Proizvod/dodaj-vise", lp);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri pozivu API-ja: " + ex.Message);
            }

        }

        private async void PozoviApi()
        {
            var proizvodi = await client.GetFromJsonAsync<List<Proizvod>>(
                   "api/Proizvod/ucitaj-proizvode");
            textBox1.Text = string.Join(Environment.NewLine,
                 proizvodi.Select(p => $"{p.Id} - {p.Naziv} ({p.Cena} RSD)"));
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Poziv GET /api/Proizvod/ucitaj-proizvode
                var proizvodi = await client.GetFromJsonAsync<List<Proizvod>>(
                    "api/Proizvod/ucitaj-proizvode");

                if (proizvodi == null || proizvodi.Count == 0)
                {
                    textBox2.Text = "Nema proizvoda u bazi.";
                    return;
                }

                // Svaki proizvod u novi red
                textBox2.Text = string.Join(Environment.NewLine,
                    proizvodi.Select(p => $"{p.Id} - {p.Naziv} ({p.Cena} RSD)"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri pozivu API-ja: " + ex.Message);
            }
        }
    }
}

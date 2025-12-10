using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Domain;

namespace FormaVadras.Controllers
{
    internal class ProizvodContr
    {
        
        public async Task<List<Proizvod>> VratiSveProizvode()
        {
            try
            {
                // poziv API-ja
                var proizvodi = await ApiClient.Client.GetFromJsonAsync<List<Proizvod>>(
                    "api/Proizvod/vrati-sve-proizvode");

                return proizvodi ?? new List<Proizvod>();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri pozivu API-ja: " + ex.Message);
                return new List<Proizvod>();

            }
        }

        
    }
}

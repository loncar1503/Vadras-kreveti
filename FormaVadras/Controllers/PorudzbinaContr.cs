using API_Vadras.DTO.Porudzbina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FormaVadras.Controllers
{
    internal class PorudzbinaContr
    {


        internal async Task<string> UcitajBrojRacuna(string lokal)
        {
            string url = $"api/porudzbina/generisi-broj?lokal={lokal}";

            var broj = await ApiClient.Client.GetStringAsync(url);
            return broj;
        }

        internal async Task<string?> KreirajPorudzbinu(KreirajPorudzbinuDTO porudzbina)
        {
            try
            {
                var response = await ApiClient.Client
                    .PostAsJsonAsync("api/Porudzbina/kreiraj-porudzbinu", porudzbina);

                if (!response.IsSuccessStatusCode)
                    return null;

                // API vraća broj ID-a kao int
                var brRacuna = await response.Content.ReadAsStringAsync();
                return brRacuna;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška API-ja: " + ex.Message);
                return null;
            }
        }

        internal async Task<List<UcitajSvePorudzbineDTO>> VratiSvePorudzbine()
        {
            try
            {
                var lista = await ApiClient.Client
                    .GetFromJsonAsync<List<UcitajSvePorudzbineDTO>>(
                        "api/Porudzbina/vrati-sve-porudzbine");

                return lista ?? new List<UcitajSvePorudzbineDTO>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška API-ja: " + ex.Message);
                return new List<UcitajSvePorudzbineDTO>();
            }


        }

        internal async Task<VratiPorudzbinuDTO> VratiPorudzbinu(int id)
        {
            var porudzbina = await ApiClient.Client
                .GetFromJsonAsync<VratiPorudzbinuDTO>($"api/Porudzbina/vrati-porudzbinu?id={id}");
            return porudzbina;
        }
    }
}

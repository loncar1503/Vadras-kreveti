using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormaVadras.Controllers
{
    internal static class ApiClient
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7080/")
        };

        public static HttpClient Client => _client;

        public static void SetApiKey(string apiKey)
        {
            // ukloni stari ključ
            _client.DefaultRequestHeaders.Remove("X-API-KEY");

            // dodaj novi ako postoji
            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                _client.DefaultRequestHeaders.Add("X-API-KEY", apiKey);
            }
        }
    }
}

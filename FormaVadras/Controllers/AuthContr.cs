using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FormaVadras.Controllers
{
    internal class AuthContr
    {
        public static async Task<LoginResult> LoginAsync(string username, string password)
        {
            var payload = new
            {
                Username = username,
                Password = password
            };

            var response = await ApiClient.Client
                .PostAsJsonAsync("api/radnici/login", payload);

            if (!response.IsSuccessStatusCode)
            {
                return new LoginResult { IsSuccess = false };
            }

            var result = await response.Content
                .ReadFromJsonAsync<LoginResponseDto>();

            if (result == null || string.IsNullOrWhiteSpace(result.ApiKey))
            {
                return new LoginResult { IsSuccess = false };
            }

            // 🔑 set API key (GLOBALNO)
            ApiClient.SetApiKey(result.ApiKey);

            return new LoginResult
            {
                IsSuccess = true,
                Radnik = result.Radnik
            };
        }
    }
}

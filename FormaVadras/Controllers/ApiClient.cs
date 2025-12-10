using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormaVadras.Controllers
{
    internal class ApiClient
    {
        public static readonly HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7080/")
        };
    }
}

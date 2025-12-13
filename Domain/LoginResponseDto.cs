using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LoginResponseDto
    {
        public string ApiKey { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public Radnik Radnik{ get; set; }
    }
}

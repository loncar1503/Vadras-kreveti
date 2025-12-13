using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ApiKey
    {
        public int Id { get; set; }

        public int RadnikId { get; set; }
        public Radnik Radnik { get; set; } = null!;

        public string Key { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }

        public bool IsActive { get; set; } = true;
    }
}

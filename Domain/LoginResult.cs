using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LoginResult
    {
        public bool IsSuccess { get; set; }
        public Radnik? Radnik { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureWebApp.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public long CardNumber { get; set; }
        public int ValidUntilMonth { get; set; }
        public int ValidUntilYear { get; set; }
        public int CVC { get; set; }
    }
}

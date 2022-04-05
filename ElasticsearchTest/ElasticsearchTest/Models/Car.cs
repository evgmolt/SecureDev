using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticsearchTest.Models
{
    internal class Car
    {
        public int? CarID { get; set; }
        public string Maker { get; set; }
        public string Color { get; set; }
        public Double? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

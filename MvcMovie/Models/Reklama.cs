using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Reklama
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double Price { get; set; }
        public string Level { get; set; }
        public int Fk_product { get; set; }
        public string ToStr { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Uzsakymas
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        public string Status { get; set; }
        public bool Rated { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Preke
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Pavadinimas")]
        public string? Name { get; set; } = null;
        [DisplayName("Aprašymas")]
        public string? Description { get; set; } = "nera apraso";

        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        public byte[]? Image { get; set; }
        public double Weight { get; set; }
        public double Rating { get; set; }

        public string? Ad { get; set; } = "";


    }
}

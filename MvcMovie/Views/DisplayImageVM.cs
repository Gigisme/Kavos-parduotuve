using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Views
{
    public class DisplayImageVM
    {
        public Preke Product { get; set; }
        public string? ImageHex { get; set; }
    }
}

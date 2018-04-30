using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upravitelj.Models
{
    public class Obavijest
    {
        public double id_obavijest { get; set; }
        public DateTime datum { get; set; }
        public char naslov { get; set; }
        public string opis { get; set; }
        public char dokument { get; set; }
        public char slika { get; set; }
        public int kategorija { get; set; }
        public int vidljiv { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upravitelj.Models
{
    public class Upit
    {
        public double id_upit { get; set; }
        public int id_stanar { get; set; }
        public DateTime datum { get; set; }
        public char naslov { get; set; }
        public string opis { get; set; }
        public int dogovoreno { get; set; }
    }
}
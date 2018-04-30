using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upravitelj.Models
{
    public class Stanar
    {
        public double id_stanar { get; set; }
        public char ime_prezime { get; set; }
        public int id_zgrada { get; set; }
        public int vrsta_korisnika { get; set; }
        public char mob { get; set; }
        public char email { get; set; }
        public char lozinka { get; set; }
        public string aktivacijski_link { get; set; }
        public int aktivan { get; set; }
    }
}
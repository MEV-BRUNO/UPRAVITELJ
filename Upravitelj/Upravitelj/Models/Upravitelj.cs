using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upravitelj.Models
{
    public class Upravitelj
    {
        public int id_upravitelj { get; set; }
        public char ime_prezime { get; set; }
        public char email { get; set; }
        public char lozinka { get; set; }
    }
}
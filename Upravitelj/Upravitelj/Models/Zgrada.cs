using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upravitelj.Models
{
    public class Zgrada
    {
        public int id_zgrada { get; set; }
        public char naziv { get; set; }
        public char ulica { get; set; }
        public char grad { get; set; }
        public int broj_stanara { get; set; }
    }
}
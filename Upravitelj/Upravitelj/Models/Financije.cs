using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upravitelj.Models
{
    public class Financije
    {
        public double id_financija { get; set; }
        public int id_zgrada { get; set; }
        public DateTime datum { get; set; }
        public int stanje { get; set; }
    }
}
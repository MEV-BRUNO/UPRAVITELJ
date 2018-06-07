using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Upravitelj.Models
{
    public class Upit
    {
        [Required]
        public int id { get; set; }
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public string naslov { get; set; }
        [Required]
        public string opis { get; set; }
        [Required]
        public bool odgovoren { get; set; }

    }
}
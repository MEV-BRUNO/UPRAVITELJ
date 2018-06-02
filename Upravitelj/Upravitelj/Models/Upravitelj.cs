using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upravitelj.Models
{
    public class Upravitelj
    {
        [Required]
        public int id_upravitelj { get; set; }

        [Range(1, 50, ErrorMessage = "Unesite vaše ime i prezime!")]
        [Required]
        public string ime_prezime { get; set; }

        [EmailAddress]
        [Required]
        public char email { get; set; }

        [Range(6, 20, ErrorMessage = "Lozinka se mora sastojati od 6 - 20 znakova!")]
        [Required]
        public string lozinka { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upravitelj.Models
{
    public class Stanar
    {
        [Required(ErrorMessage = "Unesite vaš ID!")]
        public double id_stanar { get; set; }

        [Required(ErrorMessage = "Unesite vaše ime i prezime!")]
        public string Ime_prezime { get; set; }

        [Required]
        public int id_zgrada { get; set; }

        [Required]
        public string vrsta_korisnika { get; set; }

        [StringLength(20)]
        public string mob { get; set; }

        [EmailAddress]
        public string email { get; set; }

        [Range(6, 20, ErrorMessage = "Lozinka se mora sastojati od 6 - 20 znakova!")]
        public string lozinka { get; set; }

        [StringLength(100)]
        public string aktivacijski_link { get; set; }

        [Range(typeof(bool), "1", "0")]
        public int aktivan { get; set; }

    }
}
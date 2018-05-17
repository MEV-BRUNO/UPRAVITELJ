﻿using System;
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

        [Required(1, 50, ErrorMessage = "Unesite vaše ime i prezime!")]
        public string ime_prezime { get; set; }

        [Required]
        public int id_zgrada { get; set; }

        [Required]
        public int vrsta_korisnika { get; set; }

        [StringLenght(20)]
        public string mob { get; set; }

        [EmailAddress]
        public char email { get; set; }

        [Range(6, 20, ErrorMessage = "Lozinka se mora sastojati od 6 - 20 znakova!")]
        public char lozinka { get; set; }

        [StringLenght(100)]
        public string aktivacijski_link { get; set; }

        [Range(typeof(bool), "1", "0")]
        public int aktivan { get; set; }

    }
}
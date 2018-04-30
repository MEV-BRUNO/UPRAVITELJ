﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upravitelj.Models
{
    public class Obavijest
    {
        [Required]
        public double id_obavijest { get; set; }

        [Required(ErrorMessage = "Upisite datum.")]
        [DataType(DataType.Date)]
        public DateTime datum { get; set; }

        [Required(1, 60, ErrorMessage = "Naslov je obavezan!")]
        public string naslov { get; set; }

        [Required(ErrorMessage = "Opis je obavezan!")]
        public string opis { get; set; }

        public char dokument { get; set; }

        public char slika { get; set; }

        [StringLenght(11)]
        public int kategorija { get; set; }

        [Range(typeof(bool),"1", "0")]
        public int vidljiv { get; set; }

    }
}
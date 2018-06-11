using System;
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

        [Range(1, 60, ErrorMessage = "Naslov je obavezan!")]
        [Required]
        public string naslov { get; set; }

        [Required(ErrorMessage = "Opis je obavezan!")]
        public string opis { get; set; }


        [Required]
        public char dokument { get; set; }

        [Required]
        public char slika { get; set; }

        [StringLenght(11)]
        [Required]
        public int kategorija { get; set; }

        [Range(typeof(bool),"1", "0")]
        [Required]
        public int vidljiv { get; set; }

    }
}
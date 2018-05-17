using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upravitelj.Models
{
    public class Upit
    {
        [Required]
        public double id_upit { get; set; }

        [Required]
        public int id_stanar { get; set; }

        [Range(ErrorMessage = "Upisite datum.")]
        [DataType(DataType.Date)]
        public DateTime datum { get; set; }

        [Range(1, 60, ErrorMessage = "Naslov je obavezan!")]
        public string naslov { get; set; }

        [Range(ErrorMessage = "Opis je obavezan!")]
        public string opis { get; set; }

        [Range(typeof(bool), "1", "0")]
        public int dogovoreno { get; set; }
    }
}

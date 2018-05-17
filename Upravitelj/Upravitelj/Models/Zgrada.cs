using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upravitelj.Models
{
    public class Zgrada
    {
        [Required]
        public int id_zgrada { get; set; }

        [Range(1, 50, ErrorMessage = "Naziv zgrade je obavezan!")]
        public string naziv { get; set; }

        [Range(1, 40, ErrorMessage = "Naziv ulice je obavezan!")]
        public string ulica { get; set; }

        [Range(1, 30, ErrorMessage = "Naziv grada je obavezan!")]
        public string grad { get; set; }

        [Required]
        public int broj_stanara { get; set; }
    }
}

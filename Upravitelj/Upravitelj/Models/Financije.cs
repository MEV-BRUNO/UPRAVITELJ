using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upravitelj.Models
{
    public class Financije
    {
        [Required]
        public int id_financija { get; set; }
        [Required]
        public int id_zgrada { get; set; }

        [Required(ErrorMessage = "Upisite datum.")]
        [DataType(DataType.Date)]
        public DateTime datum { get; set; }

        [Required]
        public double stanje { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Upravitelj.Models
{
    public class PrijavaViewModel
    {
        [Required]
        [Display(Name = "Korisnicko ime")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }
    }

    public class ZaboravljenaLozinkaViewModel
    {
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

    public class RegistracijaViewModel
    {
        [Required]
        [Display(Name = "Ime")]
        public string Ime { get; set; }

        [Required]
        [Display(Name = "Prezime")]
        public string Prezime { get; set; }

        [Required]
        [Display(Name = "Korisnicko ime")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Ponovite lozinku")]
        [Compare("Password", ErrorMessage = "Prva lozinka i ponovljena lozinka se ne poklapaju.")]
        public string ConfirmPassword { get; set; }

    }
}

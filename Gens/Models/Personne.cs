using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gens.Models
{
    public class Personne
    {
        public int PersonneId { get; set; }
        
        [Required(ErrorMessage = "Champs requis")]
        [StringLength(80, ErrorMessage = "Seulement 80 caractères")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Champs requis")]
        [Range(1,100, ErrorMessage = "Jusqu'à 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Champs requis")]
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "Champs requis")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Courriel invalid")]
        [StringLength(80, ErrorMessage = "Seulement 80 caractères")]
        public string Courriel { get; set; }

        [Required(ErrorMessage = "Champs requis")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Courriel invalid")]
        [StringLength(80, ErrorMessage = "Seulement 80 caractères")]
        [Compare("Courriel")]
        public string ConfirmationCourriel { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Models
{
    public class Utilisateur
    {
        public int UtilisateurId { get; set; }

        [Required(ErrorMessage = "Chmaps requis")]
        [StringLength(50, ErrorMessage = "Seulement 50 caractères")]
        [EmailAddress(ErrorMessage = "Courriel invalide")]
        [DataType(DataType.EmailAddress)]
        public string Courriel { get; set; }

        [Required(ErrorMessage = "Chmaps requis")]
        [StringLength(20, ErrorMessage = "Seulement 20 caractères")]
        [EmailAddress(ErrorMessage = "Password invalide")]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }

        public ICollection<InformationLogin> InformationLogin { get; set; }
        public ICollection<Curriculum> Curriculums { get; set; }
    }
}

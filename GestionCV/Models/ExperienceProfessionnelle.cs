using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Models
{
    public class ExperienceProfessionnelle
    {
        public int ExperienceProfessionnelleId { get; set; }

        [Required(ErrorMessage = "Chmaps requis")]
        [StringLength(50, ErrorMessage = "Seulement 50 caractères")]
        public string Entreprise { get; set; }

        [Required(ErrorMessage = "Chmaps requis")]
        [StringLength(50, ErrorMessage = "Seulement 50 caractères")]
        public string TitrePoste { get; set; }

        [Required(ErrorMessage = "Chmaps requis")]
        [Range(1920, 2020, ErrorMessage = "Année invalid")]
        public int AnneeDebut { get; set; }

        [Range(1920, 2020, ErrorMessage = "Année invalid")]
        public int AnneeFin { get; set; }

        [Required(ErrorMessage = "Chmaps requis")]
        [StringLength(1000, ErrorMessage = "Seulement 1000 caractères")]
        [DataType(DataType.MultilineText)]
        public string Activites { get; set; }

        public int CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Models
{
    public class Formation
    {
        public int FormationId { get; set; }
        
        public int TypeCoursId { get; set; }
        public TypeCours TypeCours { get; set; }

        [Required(ErrorMessage = "Chmaps requis")]
        [StringLength(50, ErrorMessage = "Seulement 50 caractères")]
        public string Institution { get; set; }

        [Required(ErrorMessage = "Chmaps requis")]
        [Range(1920,2020, ErrorMessage = "Année invalid")]
        public int AnneeDebut { get; set; }
        
        [Range(1920, 2020, ErrorMessage = "Année invalid")]
        public int AnneeFin { get; set; }

        [Required(ErrorMessage = "Chmaps requis")]
        [StringLength(50, ErrorMessage = "Seulement 50 caractères")]
        public string NomCours { get; set; }

        public int CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }
    }
}

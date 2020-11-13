using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Models
{
    public class Curriculum
    {
        public int CurriculumId { get; set; }

        [Required(ErrorMessage = "Chmaps requis")]
        [StringLength(50, ErrorMessage = "Seulement 50 caractères")]
        public string Nom { get; set; }

        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public ICollection<Objectif> Objectifs { get; set; }
        public ICollection<Formation> Formations { get; set; }
        public ICollection<ExperienceProfessionnelle> ExperiencesProfessionnelles { get; set; }
        public ICollection<Langue> Langues { get; set; }

    }
}
